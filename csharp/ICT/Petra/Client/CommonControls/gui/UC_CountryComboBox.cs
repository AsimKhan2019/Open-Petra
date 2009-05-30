﻿/*************************************************************************
 *
 * DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
 *
 * @Authors:
 *       christiank
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Ict.Common.Controls;
using Ict.Petra.Client.App.Core;
using Ict.Petra.Shared.MPartner;
using Ict.Petra.Shared.MCommon.Data;
using System.Globalization;

namespace Ict.Petra.Client.CommonControls
{
    /// <summary>
    /// A UserControl that consists of a ComboBox with Country Code entries and a
    /// label to its right that displays the name of the country.
    ///
    /// Interesting feature: this control fetches its list entries on its own from
    /// the Client DataCache!
    ///
    /// @Comment Have a look at the UC_PartnerEdit_PartnerTabSet to see how DataBinding
    ///          works with this UserControl (it's quite easy!)
    ///          Important: Always DataBind this UserControl to a DataColumn of a
    ///          DataTable - otherwise a changed Country selection will not be
    ///          automatically reflected in a DataTable/DataSet!
    /// </summary>
    public class TUC_CountryComboBox : System.Windows.Forms.UserControl
    {
        /// <summary> Required designer variable. </summary>
        private System.ComponentModel.IContainer components = null;
        private TCmbLabelled cmbCountry;
        private DataTable FDataCache_CountryListTable;
        private Boolean FUserControlInitialised;
        private Boolean FAddNotSetValue = false;
        private String FNotSetValue;
        private String FNotSetDisplay;

        /// <summary>todoComment</summary>
        public System.Object SelectedValue
        {
            get
            {
                return cmbCountry.cmbCombobox.SelectedValue;
            }

            set
            {
                cmbCountry.cmbCombobox.SelectedValue = value;
            }
        }

        /// <summary>
        /// This Event is thrown when the internal ComboBox throws the SelectedValueChanged Event.
        ///
        /// </summary>
        public event TSelectedValueChangedEventHandler SelectedValueChanged;

        #region Windows Form Designer generated code

        /// <summary>
        /// <summary> Required method for Designer support  do not modify the contents of this method with the code editor. </summary> <summary> Required method for Designer support  do not modify the contents of this method with the code editor.
        /// </summary>
        /// </summary>
        /// <returns>void</returns>
        private void InitializeComponent()
        {
            this.cmbCountry = new TCmbLabelled();
            this.SuspendLayout();

            //
            // cmbCountry
            //
            this.cmbCountry.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                     System.Windows.Forms.AnchorStyles.Left |
                                     System.Windows.Forms.AnchorStyles.Right;
            this.cmbCountry.BackColor = System.Drawing.SystemColors.Control;
            this.cmbCountry.ColumnWidthCol1 = 50;
            this.cmbCountry.ColumnWidthCol2 = 200;
            this.cmbCountry.ColumnWidthCol3 = 0;
            this.cmbCountry.ColumnWidthCol4 = 0;
            this.cmbCountry.ComboBoxWidth = 50;
            this.cmbCountry.DisplayInColumn1 = "p_country_code_c";
            this.cmbCountry.DisplayInColumn2 = "p_country_name_c";
            this.cmbCountry.DisplayInColumn3 = null;
            this.cmbCountry.DisplayInColumn4 = null;
            this.cmbCountry.DisplayMember = "";
            this.cmbCountry.Font = new System.Drawing.Font("Verdana",
                8.25f,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point,
                (Byte)0);
            this.cmbCountry.ImageColumn = 0;
            this.cmbCountry.Images = null;
            this.cmbCountry.LabelDisplaysColumn = "p_country_name_c";
            this.cmbCountry.Location = new System.Drawing.Point(0, 0);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(388, 21);
            this.cmbCountry.TabIndex = 0;
            this.cmbCountry.ValueMember = "";

            //
            // TUC_CountryComboBox
            //
            this.Controls.Add(this.cmbCountry);
            this.Name = "TUC_CountryComboBox";
            this.Size = new System.Drawing.Size(388, 22);
            this.ResumeLayout(false);
        }

        #endregion

        private void CmbCombobox_SelectedValueChanged(System.Object sender, EventArgs e)
        {
            if (SelectedValueChanged != null)
            {
                SelectedValueChanged(this, e);
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public TUC_CountryComboBox()
            : base()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        /// <summary>
        /// <summary> Clean up any resources being used. </summary>
        /// </summary>
        /// <returns>void</returns>
        protected override void Dispose(Boolean Disposing)
        {
            if (Disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(Disposing);
        }

        /// <summary>
        /// Initialise the user control
        /// </summary>
        public void InitialiseUserControl()
        {
            if (!(DesignMode))
            {
                // Pass on any set Tag
                cmbCountry.Tag = this.Tag;
                cmbCountry.cmbCombobox.Tag = this.Tag;
                FDataCache_CountryListTable = TDataCache.TMPartner.GetCacheablePartnerTable(TCacheablePartnerTablesEnum.CountryList);
                cmbCountry.cmbCombobox.BeginUpdate();
                cmbCountry.cmbCombobox.DataSource = FDataCache_CountryListTable.DefaultView;
                cmbCountry.cmbCombobox.DisplayMember = "p_country_code_c";
                cmbCountry.cmbCombobox.ValueMember = "p_country_code_c";
                cmbCountry.cmbCombobox.EndUpdate();

                //	cmbCountry.cmbCombobox.SelectedItem = null;
                this.cmbCountry.cmbCombobox.SelectedValueChanged += new System.EventHandler(this.CmbCombobox_SelectedValueChanged);
                FUserControlInitialised = true;
            }
        }

        /// <summary>
        /// Adds a row to the combo box repesenting the "not set" state
        /// </summary>
        /// <param name="NotSetValue">The Value when NotSet state is true</param>
        /// <param name="NotSetDisplay">The DisplayedText when NotSet state is true</param>
        public void AddNotSetRow(String NotSetValue,
            String NotSetDisplay)
        {
            //store the special instructions
            this.FAddNotSetValue = true;
            this.FNotSetValue = NotSetValue;
            this.FNotSetDisplay = NotSetDisplay;
            PCountryRow Dr = (PCountryRow)FDataCache_CountryListTable.NewRow();
            Dr.CountryName = FNotSetDisplay;
            Dr.CountryCode = FNotSetValue;
            FDataCache_CountryListTable.Rows.InsertAt(Dr, 0);
        }

        /// <summary>
        /// Selects the special NotSet row, if enabled.
        /// </summary>
        public void SelectNotSetRow()
        {
            if (FAddNotSetValue)
            {
                cmbCountry.cmbCombobox.SelectedValue = FNotSetValue;
            }
            else
            {
                throw new Exception("AddNotSetRow must be called before this method can work");
            }
        }

        /// <summary>
        /// Test for whether the control is in NotSet state
        /// </summary>
        /// <returns>True if the control is "NotSet"</returns>
        public bool NoValueSet()
        {
            if (FAddNotSetValue)
            {
                if (cmbCountry.cmbCombobox.SelectedValue == null)
                {
                    return true;
                }

                return (cmbCountry.cmbCombobox.SelectedValue.ToString() == FNotSetValue) || (cmbCountry.cmbCombobox.SelectedValue.ToString() == "");
            }
            else
            {
                throw new Exception("AddNotSetRow must be called before this function can work");
            }
        }

        /// <summary>
        /// DataBind user control to the specified source and column
        /// </summary>
        /// <param name="ADataSource">The source to bind to</param>
        /// <param name="AColumnName">The column to bind to</param>
        public void PerformDataBinding(System.ComponentModel.MarshalByValueComponent ADataSource, String AColumnName)
        {
            if (!FUserControlInitialised)
            {
                InitialiseUserControl();
            }

            // MessageBox.Show((ADataSource as DataView).Count.ToString );
            cmbCountry.cmbCombobox.DataBindings.Add("SelectedValue", ADataSource, AColumnName);
        }
    }
}