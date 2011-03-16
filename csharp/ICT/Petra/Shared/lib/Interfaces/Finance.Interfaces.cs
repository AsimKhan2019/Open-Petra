// Auto generated with nant generateGlue, based on csharp\ICT\Petra\Definitions\NamespaceHierarchy.yml
// and the Server c# files (eg. UIConnector implementations)
// Do not change this file manually.
//
//
// DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
//
// @Authors:
//       auto generated
//
// Copyright 2004-2011 by OM International
//
// This file is part of OpenPetra.org.
//
// OpenPetra.org is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// OpenPetra.org is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with OpenPetra.org.  If not, see <http://www.gnu.org/licenses/>.
//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Ict.Common;
using Ict.Common.Verification;
using Ict.Petra.Shared.Interfaces.MFinance.AP;
using Ict.Petra.Shared.Interfaces.MFinance.AR;
using Ict.Petra.Shared.Interfaces.MFinance.Budget;
using Ict.Petra.Shared.Interfaces.MFinance.Cacheable;
using Ict.Petra.Shared.Interfaces.MFinance.ImportExport;
using Ict.Petra.Shared.Interfaces.MFinance.Gift;
using Ict.Petra.Shared.Interfaces.MFinance.GL;
using Ict.Petra.Shared.Interfaces.MFinance.ICH;
using Ict.Petra.Shared.Interfaces.MFinance.PeriodEnd;
using Ict.Petra.Shared.Interfaces.MFinance.Reporting;
using Ict.Petra.Shared.Interfaces.MFinance.Setup;
using Ict.Petra.Shared.Interfaces.MFinance.AP.UIConnectors;
using Ict.Petra.Shared.Interfaces.MFinance.AP.WebConnectors;
using Ict.Petra.Shared.Interfaces.MFinance.AR.WebConnectors;
using Ict.Petra.Shared.Interfaces.MFinance.Budget.UIConnectors;
using Ict.Petra.Shared.Interfaces.MFinance.ImportExport.WebConnectors;
using Ict.Petra.Shared.Interfaces.MFinance.Gift.UIConnectors;
using Ict.Petra.Shared.Interfaces.MFinance.Gift.WebConnectors;
using Ict.Petra.Shared.Interfaces.MFinance.GL.UIConnectors;
using Ict.Petra.Shared.Interfaces.MFinance.GL.WebConnectors;
using Ict.Petra.Shared.Interfaces.MFinance.ICH.UIConnectors;
using Ict.Petra.Shared.Interfaces.MFinance.PeriodEnd.UIConnectors;
using Ict.Petra.Shared.Interfaces.MFinance.Reporting.UIConnectors;
using Ict.Petra.Shared.Interfaces.MFinance.Setup.UIConnectors;
#region ManualCode
using System.Xml;
using System.Collections.Specialized;
using Ict.Common.Data;
using Ict.Petra.Shared.MFinance;
using Ict.Petra.Shared.MFinance.Account.Data;
using Ict.Petra.Shared.MFinance.AP.Data;
using Ict.Petra.Shared.MFinance.GL.Data;
using Ict.Petra.Shared.MFinance.Gift.Data;
using Ict.Petra.Shared.MPartner.Partner.Data;
using Ict.Petra.Shared.Interfaces.AsynchronousExecution;
#endregion ManualCode
using Ict.Petra.Shared.Interfaces.MFinance.Setup.WebConnectors;
namespace Ict.Petra.Shared.Interfaces.MFinance
{
    /// <summary>auto generated</summary>
    public interface IMFinanceNamespace : IInterface
    {
        /// <summary>access to sub namespace</summary>
        IAPNamespace AP
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        IARNamespace AR
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        IBudgetNamespace Budget
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        ICacheableNamespace Cacheable
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        IImportExportNamespace ImportExport
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        IGiftNamespace Gift
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        IGLNamespace GL
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        IICHNamespace ICH
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        IPeriodEndNamespace PeriodEnd
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        IReportingNamespace Reporting
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        ISetupNamespace Setup
        {
            get;
        }

    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.AP
{
    /// <summary>auto generated</summary>
    public interface IAPNamespace : IInterface
    {
        /// <summary>access to sub namespace</summary>
        IAPUIConnectorsNamespace UIConnectors
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        IAPWebConnectorsNamespace WebConnectors
        {
            get;
        }

    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.AP.UIConnectors
{
    /// <summary>auto generated</summary>
    public interface IAPUIConnectorsNamespace : IInterface
    {
        /// <summary>auto generated from Connector constructor (Ict.Petra.Server.MFinance.AP.UIConnectors.TFindUIConnector)</summary>
        IAPUIConnectorsFind Find();
        /// <summary>auto generated from Connector constructor (Ict.Petra.Server.MFinance.AP.UIConnectors.TSupplierEditUIConnector)</summary>
        IAPUIConnectorsSupplierEdit SupplierEdit();
        /// <summary>auto generated from Connector constructor and GetData (Ict.Petra.Server.MFinance.AP.UIConnectors.TSupplierEditUIConnector)</summary>
        IAPUIConnectorsSupplierEdit SupplierEdit(ref AccountsPayableTDS ADataSet,
                                                 Int64 APartnerKey);
    }

    /// <summary>auto generated</summary>
    public interface IAPUIConnectorsFind : IInterface
    {
        /// <summary>auto generated from Connector property (Ict.Petra.Server.MFinance.AP.UIConnectors.TFindUIConnector)</summary>
        IAsynchronousExecutionProgress AsyncExecProgress
        {
            get;
        }

        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.AP.UIConnectors.TFindUIConnector)</summary>
        void FindSupplier(DataTable ACriteriaData);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.AP.UIConnectors.TFindUIConnector)</summary>
        void FindInvoices(DataTable ACriteriaData);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.AP.UIConnectors.TFindUIConnector)</summary>
        void PerformSearch(DataTable ACriteriaData);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.AP.UIConnectors.TFindUIConnector)</summary>
        void StopSearch(object ASender,
                        EventArgs AArgs);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.AP.UIConnectors.TFindUIConnector)</summary>
        DataTable GetDataPagedResult(System.Int16 APage,
                                     System.Int16 APageSize,
                                     out System.Int32 ATotalRecords,
                                     out System.Int16 ATotalPages);
    }

    /// <summary>auto generated</summary>
    public interface IAPUIConnectorsSupplierEdit : IInterface
    {
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.AP.UIConnectors.TSupplierEditUIConnector)</summary>
        bool CanFindSupplier(Int64 APartnerKey);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.AP.UIConnectors.TSupplierEditUIConnector)</summary>
        AccountsPayableTDS GetData(Int64 APartnerKey);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.AP.UIConnectors.TSupplierEditUIConnector)</summary>
        TSubmitChangesResult SubmitChanges(ref AccountsPayableTDS AInspectDS,
                                           out TVerificationResultCollection AVerificationResult);
    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.AP.WebConnectors
{
    /// <summary>auto generated</summary>
    public interface IAPWebConnectorsNamespace : IInterface
    {
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.AP.WebConnectors.TTransactionWebConnector)</summary>
        AccountsPayableTDS LoadAApDocument(Int32 ALedgerNumber,
                                           Int32 AAPNumber);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.AP.WebConnectors.TTransactionWebConnector)</summary>
        AccountsPayableTDS CreateAApDocument(Int32 ALedgerNumber,
                                             Int64 APartnerKey,
                                             bool ACreditNoteOrInvoice);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.AP.WebConnectors.TTransactionWebConnector)</summary>
        TSubmitChangesResult SaveAApDocument(ref AccountsPayableTDS AInspectDS,
                                             out TVerificationResultCollection AVerificationResult);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.AP.WebConnectors.TTransactionWebConnector)</summary>
        AccountsPayableTDS CreateAApDocumentDetail(Int32 ALedgerNumber,
                                                   Int32 AApNumber,
                                                   string AApSupplier_DefaultExpAccount,
                                                   string AApSupplier_DefaultCostCentre,
                                                   decimal AAmount,
                                                   Int32 ALastDetailNumber);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.AP.WebConnectors.TTransactionWebConnector)</summary>
        AccountsPayableTDS FindAApDocument(Int32 ALedgerNumber,
                                           Int64 ASupplierKey,
                                           string ADocumentStatus,
                                           bool IsCreditNoteNotInvoice,
                                           bool AHideAgedTransactions);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.AP.WebConnectors.TTransactionWebConnector)</summary>
        bool PostAPDocuments(Int32 ALedgerNumber,
                             List <Int32> AAPDocumentNumbers,
                             DateTime APostingDate,
                             out TVerificationResultCollection AVerifications);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.AP.WebConnectors.TTransactionWebConnector)</summary>
        bool PostAPPayments(AccountsPayableTDSAApPaymentTable APayments,
                            AccountsPayableTDSAApDocumentPaymentTable ADocumentPayments,
                            DateTime APostingDate,
                            out TVerificationResultCollection AVerifications);
    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.AR
{
    /// <summary>auto generated</summary>
    public interface IARNamespace : IInterface
    {
        /// <summary>access to sub namespace</summary>
        IARWebConnectorsNamespace WebConnectors
        {
            get;
        }

    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.AR.WebConnectors
{
    /// <summary>auto generated</summary>
    public interface IARWebConnectorsNamespace : IInterface
    {
    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.Budget
{
    /// <summary>auto generated</summary>
    public interface IBudgetNamespace : IInterface
    {
        /// <summary>access to sub namespace</summary>
        IBudgetUIConnectorsNamespace UIConnectors
        {
            get;
        }

    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.Budget.UIConnectors
{
    /// <summary>auto generated</summary>
    public interface IBudgetUIConnectorsNamespace : IInterface
    {
    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.Cacheable
{
    /// <summary>auto generated</summary>
    public interface ICacheableNamespace : IInterface
    {
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MFinance.Instantiator.Cacheable.TCacheableNamespace)</summary>
        System.Data.DataTable GetCacheableTable(Ict.Petra.Shared.MFinance.TCacheableFinanceTablesEnum ACacheableTable,
                                                System.String AHashCode,
                                                out System.Type AType);
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MFinance.Instantiator.Cacheable.TCacheableNamespace)</summary>
        System.Data.DataTable GetCacheableTable(Ict.Petra.Shared.MFinance.TCacheableFinanceTablesEnum ACacheableTable,
                                                System.String AHashCode,
                                                System.Int32 ALedgerNumber,
                                                out System.Type AType);
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MFinance.Instantiator.Cacheable.TCacheableNamespace)</summary>
        void RefreshCacheableTable(Ict.Petra.Shared.MFinance.TCacheableFinanceTablesEnum ACacheableTable);
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MFinance.Instantiator.Cacheable.TCacheableNamespace)</summary>
        void RefreshCacheableTable(Ict.Petra.Shared.MFinance.TCacheableFinanceTablesEnum ACacheableTable,
                                   out System.Data.DataTable ADataTable);
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MFinance.Instantiator.Cacheable.TCacheableNamespace)</summary>
        void RefreshCacheableTable(Ict.Petra.Shared.MFinance.TCacheableFinanceTablesEnum ACacheableTable,
                                   System.Int32 ALedgerNumber);
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MFinance.Instantiator.Cacheable.TCacheableNamespace)</summary>
        void RefreshCacheableTable(Ict.Petra.Shared.MFinance.TCacheableFinanceTablesEnum ACacheableTable,
                                   System.Int32 ALedgerNumber,
                                   out System.Data.DataTable ADataTable);
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MFinance.Instantiator.Cacheable.TCacheableNamespace)</summary>
        TSubmitChangesResult SaveChangedStandardCacheableTable(TCacheableFinanceTablesEnum ACacheableTable,
                                                               ref TTypedDataTable ASubmitTable,
                                                               int ALedgerNumber,
                                                               out TVerificationResultCollection AVerificationResult);
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MFinance.Instantiator.Cacheable.TCacheableNamespace)</summary>
        TSubmitChangesResult SaveChangedStandardCacheableTable(TCacheableFinanceTablesEnum ACacheableTable,
                                                               ref TTypedDataTable ASubmitTable,
                                                               out TVerificationResultCollection AVerificationResult);
    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.ImportExport
{
    /// <summary>auto generated</summary>
    public interface IImportExportNamespace : IInterface
    {
        /// <summary>access to sub namespace</summary>
        IImportExportWebConnectorsNamespace WebConnectors
        {
            get;
        }

    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.ImportExport.WebConnectors
{
    /// <summary>auto generated</summary>
    public interface IImportExportWebConnectorsNamespace : IInterface
    {
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.ImportExport.WebConnectors.TBankImportWebConnector)</summary>
        TSubmitChangesResult StoreNewBankStatement(ref AEpStatementTable AStmtTable,
                                                   AEpTransactionTable ATransTable,
                                                   out TVerificationResultCollection AVerificationResult);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.ImportExport.WebConnectors.TBankImportWebConnector)</summary>
        AEpStatementTable GetImportedBankStatements(DateTime AStartDate);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.ImportExport.WebConnectors.TBankImportWebConnector)</summary>
        bool DropBankStatement(Int32 AEpStatementKey);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.ImportExport.WebConnectors.TBankImportWebConnector)</summary>
        BankImportTDS GetBankStatementTransactionsAndMatches(Int32 AStatementKey,
                                                             Int32 ALedgerNumber);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.ImportExport.WebConnectors.TBankImportWebConnector)</summary>
        bool CommitMatches(BankImportTDS AMainDS);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.ImportExport.WebConnectors.TBankImportWebConnector)</summary>
        Int32 CreateGiftBatch(BankImportTDS AMainDS,
                              Int32 ALedgerNumber,
                              Int32 AStatementKey,
                              Int32 AGiftBatchNumber,
                              out TVerificationResultCollection AVerificationResult);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.ImportExport.WebConnectors.TBankImportWebConnector)</summary>
        Int32 CreateGLBatch(BankImportTDS AMainDS,
                            Int32 ALedgerNumber,
                            Int32 AStatementKey,
                            Int32 AGLBatchNumber,
                            out TVerificationResultCollection AVerificationResult);
    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.Gift
{
    /// <summary>auto generated</summary>
    public interface IGiftNamespace : IInterface
    {
        /// <summary>access to sub namespace</summary>
        IGiftUIConnectorsNamespace UIConnectors
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        IGiftWebConnectorsNamespace WebConnectors
        {
            get;
        }

    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.Gift.UIConnectors
{
    /// <summary>auto generated</summary>
    public interface IGiftUIConnectorsNamespace : IInterface
    {
    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.Gift.WebConnectors
{
    /// <summary>auto generated</summary>
    public interface IGiftWebConnectorsNamespace : IInterface
    {
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Gift.WebConnectors.TAdjustmentWebConnector)</summary>
        Int32 FieldChangeAdjustment(Int32 ALedgerNumber,
                                    Int64 ARecipientKey,
                                    DateTime AStartDate,
                                    DateTime AEndDate,
                                    Int64 AOldField,
                                    DateTime ADateCorrection,
                                    bool AWithReceipt);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Gift.WebConnectors.TGuiTools)</summary>
        Boolean GetMotivationGroupAndDetail(Int64 partnerKey,
                                            ref String motivationGroup,
                                            ref String motivationDetail);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Gift.WebConnectors.TNewDonorSubscriptionsWebConnector)</summary>
        NewDonorTDS GetNewDonorSubscriptions(string APublicationCode,
                                             DateTime ASubscriptionStartFrom,
                                             DateTime ASubscriptionStartUntil,
                                             string AExtractName,
                                             bool ADropForeignAddresses);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Gift.WebConnectors.TNewDonorSubscriptionsWebConnector)</summary>
        StringCollection PrepareNewDonorLetters(ref NewDonorTDS AMainDS,
                                                string AHTMLTemplate);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Gift.WebConnectors.TReceiptingWebConnector)</summary>
        string CreateAnnualGiftReceipts(Int32 ALedgerNumber,
                                        DateTime AStartDate,
                                        DateTime AEndDate,
                                        string AHTMLTemplate);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Gift.WebConnectors.TTransactionWebConnector)</summary>
        GiftBatchTDS CreateAGiftBatch(Int32 ALedgerNumber,
                                      DateTime ADateEffective);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Gift.WebConnectors.TTransactionWebConnector)</summary>
        GiftBatchTDS CreateAGiftBatch(Int32 ALedgerNumber);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Gift.WebConnectors.TTransactionWebConnector)</summary>
        GiftBatchTDS LoadAGiftBatch(Int32 ALedgerNumber);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Gift.WebConnectors.TTransactionWebConnector)</summary>
        GiftBatchTDS LoadTransactions(Int32 ALedgerNumber,
                                      Int32 ABatchNumber);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Gift.WebConnectors.TTransactionWebConnector)</summary>
        TSubmitChangesResult SaveGiftBatchTDS(ref GiftBatchTDS AInspectDS,
                                              out TVerificationResultCollection AVerificationResult);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Gift.WebConnectors.TTransactionWebConnector)</summary>
        bool PostGiftBatch(Int32 ALedgerNumber,
                           Int32 ABatchNumber,
                           out TVerificationResultCollection AVerifications);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Gift.WebConnectors.TTransactionWebConnector)</summary>
        bool ExportAllGiftBatchData(ref ArrayList batches,
                                    Hashtable requestParams,
                                    out String exportString,
                                    out TVerificationResultCollection AMessages);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Gift.WebConnectors.TTransactionWebConnector)</summary>
        bool ImportGiftBatches(Hashtable requestParams,
                               String importString,
                               out TVerificationResultCollection AMessages);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Gift.WebConnectors.TGiftSetupWebConnector)</summary>
        GiftBatchTDS LoadMotivationDetails(Int32 ALedgerNumber);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Gift.WebConnectors.TGiftSetupWebConnector)</summary>
        TSubmitChangesResult SaveMotivationDetails(ref GiftBatchTDS AInspectDS,
                                                   out TVerificationResultCollection AVerificationResult);
    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.GL
{
    /// <summary>auto generated</summary>
    public interface IGLNamespace : IInterface
    {
        /// <summary>access to sub namespace</summary>
        IGLUIConnectorsNamespace UIConnectors
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        IGLWebConnectorsNamespace WebConnectors
        {
            get;
        }

    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.GL.UIConnectors
{
    /// <summary>auto generated</summary>
    public interface IGLUIConnectorsNamespace : IInterface
    {
    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.GL.WebConnectors
{
    /// <summary>auto generated</summary>
    public interface IGLWebConnectorsNamespace : IInterface
    {
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.GL.WebConnectors.TRevaluationWebConnector)</summary>
        bool Revaluate(int ALedgerNum,
                       int AAccoutingPeriod,
                       string ARevaluationCostCenter,
                       string[] AForeignCurrency,
                       decimal[] ANewExchangeRate,
                       out TVerificationResultCollection AVerificationResult);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector)</summary>
        bool GetCurrentPeriodDates(Int32 ALedgerNumber,
                                   out DateTime AStartDate,
                                   out DateTime AEndDate);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector)</summary>
        bool GetCurrentPostingRangeDates(Int32 ALedgerNumber,
                                         out DateTime AStartDateCurrentPeriod,
                                         out DateTime AEndDateLastForwardingPeriod);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector)</summary>
        bool GetPeriodDates(Int32 ALedgerNumber,
                            Int32 AYearNumber,
                            Int32 ADiffPeriod,
                            Int32 APeriodNumber,
                            out DateTime AStartDatePeriod,
                            out DateTime AEndDatePeriod);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector)</summary>
        GLBatchTDS CreateABatch(Int32 ALedgerNumber);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector)</summary>
        GLBatchTDS LoadABatch(Int32 ALedgerNumber,
                              TFinanceBatchFilterEnum AFilterBatchStatus);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector)</summary>
        GLBatchTDS LoadAJournal(Int32 ALedgerNumber,
                                Int32 ABatchNumber);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector)</summary>
        GLBatchTDS LoadATransaction(Int32 ALedgerNumber,
                                    Int32 ABatchNumber,
                                    Int32 AJournalNumber);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector)</summary>
        GLBatchTDS LoadATransAnalAttrib(Int32 ALedgerNumber,
                                        Int32 ABatchNumber,
                                        Int32 AJournalNumber,
                                        Int32 ATransactionNumber);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector)</summary>
        GLSetupTDS LoadAAnalysisAttributes(Int32 ALedgerNumber);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector)</summary>
        TSubmitChangesResult SaveGLBatchTDS(ref GLBatchTDS AInspectDS,
                                            out TVerificationResultCollection AVerificationResult);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector)</summary>
        bool PostGLBatch(Int32 ALedgerNumber,
                         Int32 ABatchNumber,
                         out TVerificationResultCollection AVerifications);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector)</summary>
        string GetStandardCostCentre(Int32 ALedgerNumber);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector)</summary>
        decimal GetDailyExchangeRate(string ACurrencyFrom,
                                     string ACurrencyTo,
                                     DateTime ADateEffective);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector)</summary>
        decimal GetCorporateExchangeRate(string ACurrencyFrom,
                                         string ACurrencyTo,
                                         DateTime AStartDate,
                                         DateTime AEndDate);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector)</summary>
        bool CancelGLBatch(out GLBatchTDS MainDS,
                           Int32 ALedgerNumber,
                           Int32 ABatchNumber,
                           out TVerificationResultCollection AVerifications);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector)</summary>
        bool ExportAllGLBatchData(ref ArrayList batches,
                                  Hashtable requestParams,
                                  out String exportString);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector)</summary>
        bool ImportGLBatches(Hashtable requestParams,
                             String importString,
                             out TVerificationResultCollection AMessages);
    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.ICH
{
    /// <summary>auto generated</summary>
    public interface IICHNamespace : IInterface
    {
        /// <summary>access to sub namespace</summary>
        IICHUIConnectorsNamespace UIConnectors
        {
            get;
        }

    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.ICH.UIConnectors
{
    /// <summary>auto generated</summary>
    public interface IICHUIConnectorsNamespace : IInterface
    {
    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.PeriodEnd
{
    /// <summary>auto generated</summary>
    public interface IPeriodEndNamespace : IInterface
    {
        /// <summary>access to sub namespace</summary>
        IPeriodEndUIConnectorsNamespace UIConnectors
        {
            get;
        }

    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.PeriodEnd.UIConnectors
{
    /// <summary>auto generated</summary>
    public interface IPeriodEndUIConnectorsNamespace : IInterface
    {
    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.Reporting
{
    /// <summary>auto generated</summary>
    public interface IReportingNamespace : IInterface
    {
        /// <summary>access to sub namespace</summary>
        IReportingUIConnectorsNamespace UIConnectors
        {
            get;
        }

    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.Reporting.UIConnectors
{
    /// <summary>auto generated</summary>
    public interface IReportingUIConnectorsNamespace : IInterface
    {
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MFinance.Instantiator.Reporting.UIConnectors.TReportingUIConnectorsNamespace)</summary>
        void SelectLedger(System.Int32 ALedgerNr);
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MFinance.Instantiator.Reporting.UIConnectors.TReportingUIConnectorsNamespace)</summary>
        void GetRealPeriod(System.Int32 ADiffPeriod,
                           System.Int32 AYear,
                           System.Int32 APeriod,
                           out System.Int32 ARealPeriod,
                           out System.Int32 ARealYear);
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MFinance.Instantiator.Reporting.UIConnectors.TReportingUIConnectorsNamespace)</summary>
        void GetLedgerPeriodDetails(out System.Int32 ANumberAccountingPeriods,
                                    out System.Int32 ANumberForwardingPeriods,
                                    out System.Int32 ACurrentPeriod,
                                    out System.Int32 ACurrentYear);
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MFinance.Instantiator.Reporting.UIConnectors.TReportingUIConnectorsNamespace)</summary>
        System.DateTime GetPeriodStartDate(System.Int32 AYear,
                                           System.Int32 ADiffPeriod,
                                           System.Int32 APeriod);
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MFinance.Instantiator.Reporting.UIConnectors.TReportingUIConnectorsNamespace)</summary>
        System.DateTime GetPeriodEndDate(System.Int32 AYear,
                                         System.Int32 ADiffPeriod,
                                         System.Int32 APeriod);
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MFinance.Instantiator.Reporting.UIConnectors.TReportingUIConnectorsNamespace)</summary>
        System.Data.DataTable GetAvailableFinancialYears(System.Int32 ADiffPeriod,
                                                         out System.String ADisplayMember,
                                                         out System.String AValueMember);
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MFinance.Instantiator.Reporting.UIConnectors.TReportingUIConnectorsNamespace)</summary>
        System.Data.DataTable GetReceivingFields(out System.String ADisplayMember,
                                                 out System.String AValueMember);
    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.Setup
{
    /// <summary>auto generated</summary>
    public interface ISetupNamespace : IInterface
    {
        /// <summary>access to sub namespace</summary>
        ISetupUIConnectorsNamespace UIConnectors
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        ISetupWebConnectorsNamespace WebConnectors
        {
            get;
        }

    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.Setup.UIConnectors
{
    /// <summary>auto generated</summary>
    public interface ISetupUIConnectorsNamespace : IInterface
    {
    }

}


namespace Ict.Petra.Shared.Interfaces.MFinance.Setup.WebConnectors
{
    /// <summary>auto generated</summary>
    public interface ISetupWebConnectorsNamespace : IInterface
    {
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Setup.WebConnectors.TGLSetupWebConnector)</summary>
        GLSetupTDS LoadAccountHierarchies(Int32 ALedgerNumber);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Setup.WebConnectors.TGLSetupWebConnector)</summary>
        GLSetupTDS LoadCostCentreHierarchy(Int32 ALedgerNumber);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Setup.WebConnectors.TGLSetupWebConnector)</summary>
        TSubmitChangesResult SaveGLSetupTDS(Int32 ALedgerNumber,
                                            ref GLSetupTDS AInspectDS,
                                            out TVerificationResultCollection AVerificationResult);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Setup.WebConnectors.TGLSetupWebConnector)</summary>
        string ExportAccountHierarchy(Int32 ALedgerNumber,
                                      string AAccountHierarchyName);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Setup.WebConnectors.TGLSetupWebConnector)</summary>
        string ExportCostCentreHierarchy(Int32 ALedgerNumber);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Setup.WebConnectors.TGLSetupWebConnector)</summary>
        bool ImportAccountHierarchy(Int32 ALedgerNumber,
                                    string AHierarchyName,
                                    string AXmlAccountHierarchy);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Setup.WebConnectors.TGLSetupWebConnector)</summary>
        bool ImportCostCentreHierarchy(Int32 ALedgerNumber,
                                       string AXmlHierarchy);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Setup.WebConnectors.TGLSetupWebConnector)</summary>
        bool ImportNewLedger(Int32 ALedgerNumber,
                             string AXmlLedgerDetails,
                             string AXmlAccountHierarchy,
                             string AXmlCostCentreHierarchy,
                             string AXmlMotivationDetails);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Setup.WebConnectors.TGLSetupWebConnector)</summary>
        bool CanDeleteAccount(Int32 ALedgerNumber,
                              string AAccountCode);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Setup.WebConnectors.TGLSetupWebConnector)</summary>
        bool CreateNewLedger(Int32 ALedgerNumber,
                             String ALedgerName,
                             String ACountryCode,
                             String ABaseCurrency,
                             String AIntlCurrency,
                             DateTime ACalendarStartDate,
                             Int32 ANumberOfPeriods,
                             Int32 ACurrentPeriod,
                             Int32 ANumberOfFwdPostingPeriods,
                             out TVerificationResultCollection AVerificationResult);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Setup.WebConnectors.TGLSetupWebConnector)</summary>
        ALedgerTable GetAvailableLedgers();
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Setup.WebConnectors.TGLSetupWebConnector)</summary>
        AFreeformAnalysisTable LoadAFreeformAnalysis(Int32 ALedgerNumber);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Setup.WebConnectors.TGLSetupWebConnector)</summary>
        int CheckDeleteAFreeformAnalysis(Int32 ALedgerNumber,
                                         String ATypeCode,
                                         String AAnalysisValue);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MFinance.Setup.WebConnectors.TGLSetupWebConnector)</summary>
        int CheckDeleteAAnalysisType(String ATypeCode);
    }

}

