﻿/*************************************************************************
 *
 * DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
 *
 * @Authors:
 *       timh
 *
 * Copyright 2004-2009 by OM International
 *
 * This file is part of OpenPetra.org.
 *
 * OpenPetra.org is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * OpenPetra.org is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with OpenPetra.org.  If not, see <http://www.gnu.org/licenses/>.
 *
 ************************************************************************/
using System;
using System.Collections;
using System.Data;
using System.Data.Odbc;
using System.Threading;
using System.Windows.Forms;
using Ict.Common;
using Ict.Common.Verification;
using Ict.Petra.Shared;
using Ict.Petra.Shared.RemotedExceptions;
using Ict.Petra.Shared.Interfaces.AsynchronousExecution;
using Ict.Petra.Shared.Interfaces.MPartner.Partner;
using Ict.Petra.Shared.Interfaces.MPartner.Partner.UIConnectors;
using Ict.Petra.Shared.MCommon.Data.Cascading;
using Ict.Petra.Shared.MPartner;
using Ict.Petra.Shared.MPartner.Mailroom.Data.Access;
using Ict.Petra.Shared.MPartner.Mailroom.Data;
using Ict.Petra.Shared.MPartner.Partner.Data.Access;
using Ict.Petra.Shared.MPartner.Partner.Data;
using Ict.Petra.Server.MCommon;
using Ict.Petra.Server.MFinance;
using Ict.Petra.Server.MPartner.Partner;

namespace Ict.Petra.Server.MPartner.Partner.UIConnectors
{
    /// <summary>
    /// Partner Location Search Screen UIConnector
    ///
    /// </summary>
    public class TPartnerLocationFindUIConnector : TConfigurableMBRObject, IPartnerUIConnectorsPartnerLocationFind
    {
        private TAsynchronousExecutionProgress FAsyncExecProgress;
        private DataTable FCriteria;
        private Thread FFindThread;
        private TPagedDataSet FPagedDataSetObject;

        /// <summary>Property accessor Returns reference to the Asynchronous execution control object to the caller</summary>
        public IAsynchronousExecutionProgress AsyncExecProgress
        {
            get
            {
#if DEBUGMODE
                if (TSrvSetting.DL >= 7)
                {
                    Console.WriteLine("TPartnerLocationSearchUIConnector: AsyncExecProgress reqeusted.");
                }
#endif
                return FAsyncExecProgress;
            }
        }

        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="ACriteriaData"></param>
        public TPartnerLocationFindUIConnector(DataTable ACriteriaData) : base()
        {
            Hashtable ColumnNameMapping;
            String CustomWhereCriteria;
            TDynamicSearchHelper CriteriaBuilder;
            PLocationTable miLocationTable;
            ArrayList InternalParameters;
            OdbcParameter miParam;
            DataRow CriteriaRow;

            FCriteria = ACriteriaData;
            FAsyncExecProgress = new TAsynchronousExecutionProgress();
            FPagedDataSetObject = new TPagedDataSet();
            FPagedDataSetObject.AsyncExecProgress = FAsyncExecProgress;
            ColumnNameMapping = null;

            // get the first and only row
            CriteriaRow = ACriteriaData.Rows[0];

            // used to help with strong typing of columns
            miLocationTable = new PLocationTable();
            InternalParameters = new ArrayList();
            CustomWhereCriteria = "";

            if (CriteriaRow["Addr1"].ToString().Length > 0)
            {
                CriteriaBuilder = new TDynamicSearchHelper(miLocationTable,
                    PLocationTable.GetTableDBName(), miLocationTable.ColumnLocality, CriteriaRow, "Addr1", "Addr1Match", ref CustomWhereCriteria,
                    ref InternalParameters);
            }

            if (CriteriaRow["Street2"].ToString().Length > 0)
            {
                CriteriaBuilder = new TDynamicSearchHelper(miLocationTable,
                    PLocationTable.GetTableDBName(), miLocationTable.ColumnStreetName, CriteriaRow, "Street2", "Street2Match",
                    ref CustomWhereCriteria,
                    ref InternalParameters);
            }

            if (CriteriaRow["Addr3"].ToString().Length > 0)
            {
                CriteriaBuilder = new TDynamicSearchHelper(miLocationTable,
                    PLocationTable.GetTableDBName(), miLocationTable.ColumnAddress3, CriteriaRow, "Addr3", "Addr3Match", ref CustomWhereCriteria,
                    ref InternalParameters);
            }

            if (CriteriaRow["City"].ToString().Length > 0)
            {
                CriteriaBuilder = new TDynamicSearchHelper(miLocationTable,
                    PLocationTable.GetTableDBName(), miLocationTable.ColumnCity, CriteriaRow, "City", "CityMatch", ref CustomWhereCriteria,
                    ref InternalParameters);
            }

            if (CriteriaRow["PostCode"].ToString().Length > 0)
            {
                CriteriaBuilder = new TDynamicSearchHelper(miLocationTable,
                    PLocationTable.GetTableDBName(), miLocationTable.ColumnPostalCode, CriteriaRow, "PostCode", "PostCodeMatch",
                    ref CustomWhereCriteria,
                    ref InternalParameters);
            }

            if (CriteriaRow["County"].ToString().Length > 0)
            {
                CriteriaBuilder = new TDynamicSearchHelper(miLocationTable,
                    PLocationTable.GetTableDBName(), miLocationTable.ColumnCounty, CriteriaRow, "County", "CountyMatch", ref CustomWhereCriteria,
                    ref InternalParameters);
            }

            if (CriteriaRow["Country"].ToString().Length > 0)
            {
                CriteriaBuilder = new TDynamicSearchHelper(miLocationTable,
                    PLocationTable.GetTableDBName(), miLocationTable.ColumnCountryCode, CriteriaRow, "Country", "CountryMatch",
                    ref CustomWhereCriteria,
                    ref InternalParameters);
            }

            if (CriteriaRow["LocationKey"].ToString().Length > 0)
            {
                // DISREGARD ALL OTHER SEARCH CRITERIA!!!
                CustomWhereCriteria = "";
                InternalParameters = new ArrayList();

                CustomWhereCriteria = String.Format("{0} AND PUB.{1}.{2} = ?", CustomWhereCriteria,
                    PLocationTable.GetTableDBName(), PLocationTable.GetLocationKeyDBName());

                miParam = new OdbcParameter("", OdbcType.Decimal, 10);
                miParam.Value = (object)CriteriaRow["LocationKey"];
                InternalParameters = new ArrayList();
                InternalParameters.Add(miParam);
            }

            Console.WriteLine("WHERE CLAUSE: " + CustomWhereCriteria);
            FPagedDataSetObject.FindParameters = new TPagedDataSet.TAsyncFindParameters(
                " p_city_c, p_postal_code_c,  p_locality_c, p_street_name_c, p_address_3_c, p_county_c, p_country_code_c, p_location_key_i, p_site_key_n ",
                "PUB_p_location ",
                " p_location_key_i<>-1 " + CustomWhereCriteria + ' ',
                "p_city_c ",
                ColumnNameMapping,
                ((OdbcParameter[])(InternalParameters.ToArray(typeof(OdbcParameter)))));

            // fields
            // table
            // where
            // order by
            // both empty for now
            try
            {
                ThreadStart ThreadStartDelegate = new ThreadStart(FPagedDataSetObject.ExecuteQuery);
                FFindThread = new Thread(ThreadStartDelegate);
                FFindThread.Start();
            }
            catch (Exception)
            {
                throw;
            }
        }

#if DEBUGMODE
        /// destructor
        ~TPartnerLocationFindUIConnector()
        {
            if (TSrvSetting.DL >= 9)
            {
                Console.WriteLine(this.GetType().FullName + ".FINALIZE called!");
            }
        }
#endif



        /// <summary>
        /// todoComment
        /// </summary>
        /// <param name="APage"></param>
        /// <param name="APageSize"></param>
        /// <param name="ATotalRecords"></param>
        /// <param name="ATotalPages"></param>
        /// <returns></returns>
        public DataTable GetDataPagedResult(System.Int16 APage, System.Int16 APageSize, out System.Int32 ATotalRecords, out System.Int16 ATotalPages)
        {
            DataTable ReturnValue;

#if DEBUGMODE
            if (TSrvSetting.DL >= 7)
            {
                Console.WriteLine(this.GetType().FullName + ".GetDataPagedResult called.");
            }
#endif
            Console.WriteLine(this.GetType().FullName + ".GetDataPagedResult called.");
            ReturnValue = FPagedDataSetObject.GetData(APage, APageSize);
            ATotalPages = FPagedDataSetObject.TotalPages;
            ATotalRecords = FPagedDataSetObject.TotalRecords;
            return ReturnValue;
        }
    }
}