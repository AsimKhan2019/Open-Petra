// auto generated with nant generateWinforms from UC_AccountAnalysisAttributes.yaml and template controlMaintainTable
//
// DO NOT edit manually, DO NOT edit with the designer
//
//
// DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
//
// @Authors:
//       auto generated
//
// Copyright 2004-2010 by OM International
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Ict.Petra.Shared;
using System.Resources;
using System.Collections.Specialized;
using GNU.Gettext;
using Ict.Common;
using Ict.Common.Verification;
using Ict.Petra.Client.App.Core;
using Ict.Petra.Client.App.Core.RemoteObjects;
using Ict.Common.Controls;
using Ict.Petra.Client.CommonForms;
using Ict.Petra.Shared.MFinance.Account.Data;

namespace Ict.Petra.Client.MFinance.Gui.Setup
{

  /// auto generated user control
  public partial class TUC_AccountAnalysisAttributes: System.Windows.Forms.UserControl, Ict.Petra.Client.CommonForms.IFrmPetra
  {
    private TFrmPetraEditUtils FPetraUtilsObject;

    private Ict.Petra.Shared.MFinance.GL.Data.GLSetupTDS FMainDS;

    /// constructor
    public TUC_AccountAnalysisAttributes() : base()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      #region CATALOGI18N

      // this code has been inserted by GenerateI18N, all changes in this region will be overwritten by GenerateI18N
      this.btnNew.Text = Catalog.GetString("&New");
      this.btnDelete.Text = Catalog.GetString("&Delete");
      this.lblDetailAnalysisTypeCode.Text = Catalog.GetString("Analysis Type Code:");
      this.lblDetailActive.Text = Catalog.GetString("Active:");
      #endregion

    }

    /// helper object for the whole screen
    public TFrmPetraEditUtils PetraUtilsObject
    {
        set
        {
            FPetraUtilsObject = value;
        }
    }

    /// dataset for the whole screen
    public Ict.Petra.Shared.MFinance.GL.Data.GLSetupTDS MainDS
    {
        set
        {
            FMainDS = value;
            MessageBox.Show("tst1> " + (FMainDS.AAnalysisAttribute == null).ToString());
        }
    }

    /// needs to be called after FMainDS and FPetraUtilsObject have been set
    public void InitUserControl()
    {
      FPetraUtilsObject.SetStatusBarText(cmbDetailAnalysisTypeCode, Catalog.GetString("Select the type of analysis for the account."));
      cmbDetailAnalysisTypeCode.InitialiseUserControl();
      FPetraUtilsObject.SetStatusBarText(chkDetailActive, Catalog.GetString("Select if analysis attribute can be used"));
      grdDetails.Columns.Clear();
      grdDetails.AddTextColumn("Analysis Type Code", FMainDS.AAnalysisAttribute.ColumnAnalysisTypeCode);
      grdDetails.AddCheckBoxColumn("Active", FMainDS.AAnalysisAttribute.ColumnActive);
      FPetraUtilsObject.ActionEnablingEvent += ActionEnabledEvent;

      DataView myDataView = FMainDS.AAnalysisAttribute.DefaultView;
      myDataView.AllowNew = false;
      grdDetails.DataSource = new DevAge.ComponentModel.BoundDataView(myDataView);

      ShowData();
    }

    /// automatically generated, create a new record of AAnalysisAttribute and display on the edit screen
    public bool CreateNewAAnalysisAttribute()
    {
        // we create the table locally, no dataset
        AAnalysisAttributeRow NewRow = FMainDS.AAnalysisAttribute.NewRowTyped(true);
        NewRowManual(ref NewRow);
        FMainDS.AAnalysisAttribute.Rows.Add(NewRow);

        FPetraUtilsObject.SetChangedFlag();

        grdDetails.DataSource = new DevAge.ComponentModel.BoundDataView(FMainDS.AAnalysisAttribute.DefaultView);
        grdDetails.Refresh();
        SelectDetailRowByDataTableIndex(FMainDS.AAnalysisAttribute.Rows.Count - 1);

        return true;
    }

    private void SelectDetailRowByDataTableIndex(Int32 ARowNumberInTable)
    {
        Int32 RowNumberGrid = -1;
        for (int Counter = 0; Counter < grdDetails.DataSource.Count; Counter++)
        {
            bool found = true;
            foreach (DataColumn myColumn in FMainDS.AAnalysisAttribute.PrimaryKey)
            {
                string value1 = FMainDS.AAnalysisAttribute.Rows[ARowNumberInTable][myColumn].ToString();
                string value2 = (grdDetails.DataSource as DevAge.ComponentModel.BoundDataView).DataView[Counter][myColumn.Ordinal].ToString();
                if (value1 != value2)
                {
                    found = false;
                }
            }
            if (found)
            {
                RowNumberGrid = Counter + 1;
            }
        }
        grdDetails.Selection.ResetSelection(false);
        grdDetails.Selection.SelectRow(RowNumberGrid, true);
        // scroll to the row
        grdDetails.ShowCell(new SourceGrid.Position(RowNumberGrid, 0), true);

        FocusedRowChanged(this, new SourceGrid.RowEventArgs(RowNumberGrid));
    }

    /// return the selected row
    public AAnalysisAttributeRow GetSelectedDetailRow()
    {
        DataRowView[] SelectedGridRow = grdDetails.SelectedDataRowsAsDataRowView;

        if (SelectedGridRow.Length >= 1)
        {
            return (AAnalysisAttributeRow)SelectedGridRow[0].Row;
        }

        return null;
    }

    private void ShowData()
    {
        FPetraUtilsObject.DisableDataChangedEvent();
        pnlDetails.Enabled = false;
        if (FMainDS.AAnalysisAttribute != null)
        {
            DataView myDataView = FMainDS.AAnalysisAttribute.DefaultView;
            myDataView.AllowNew = false;
            grdDetails.DataSource = new DevAge.ComponentModel.BoundDataView(myDataView);
            if (myDataView.Count > 0)
            {
                grdDetails.Selection.ResetSelection(false);
                grdDetails.Selection.SelectRow(1, true);
                FocusedRowChanged(this, new SourceGrid.RowEventArgs(1));
                pnlDetails.Enabled = !FPetraUtilsObject.DetailProtectedMode;
            }
        }
        FPetraUtilsObject.EnableDataChangedEvent();
    }

    private void ShowDetails(AAnalysisAttributeRow ARow)
    {
        FPetraUtilsObject.DisableDataChangedEvent();
        if (ARow == null)
        {
            pnlDetails.Enabled = false;
        }
        else
        {
            FPreviouslySelectedDetailRow = ARow;
            cmbDetailAnalysisTypeCode.SetSelectedString(ARow.AnalysisTypeCode);
            cmbDetailAnalysisTypeCode.Enabled = (ARow.RowState == DataRowState.Added);
            if (ARow.IsActiveNull())
            {
                chkDetailActive.Checked = false;
            }
            else
            {
                chkDetailActive.Checked = ARow.Active;
            }
            pnlDetails.Enabled = !FPetraUtilsObject.DetailProtectedMode;
        }
        FPetraUtilsObject.EnableDataChangedEvent();
    }

    private AAnalysisAttributeRow FPreviouslySelectedDetailRow = null;
    private void FocusedRowChanged(System.Object sender, SourceGrid.RowEventArgs e)
    {
        // get the details from the previously selected row
        if (FPreviouslySelectedDetailRow != null)
        {
            GetDetailsFromControls(FPreviouslySelectedDetailRow);
        }
        // display the details of the currently selected row
        FPreviouslySelectedDetailRow = GetSelectedDetailRow();
        ShowDetails(FPreviouslySelectedDetailRow);
    }

    /// get the data from the controls and store in the currently selected detail row
    public void GetDataFromControls()
    {
        GetDetailsFromControls(FPreviouslySelectedDetailRow);
    }

    private void GetDetailsFromControls(AAnalysisAttributeRow ARow)
    {
        if (ARow != null)
        {
            ARow.BeginEdit();
            ARow.AnalysisTypeCode = cmbDetailAnalysisTypeCode.GetSelectedString();
            ARow.Active = chkDetailActive.Checked;
            GetDetailDataFromControlsManual(ARow);
            ARow.EndEdit();
        }
    }

#region Implement interface functions
    /// auto generated
    public void RunOnceOnActivation()
    {
    }

    /// <summary>
    /// Adds event handlers for the appropiate onChange event to call a central procedure
    /// </summary>
    public void HookupAllControls()
    {
    }

    /// auto generated
    public void HookupAllInContainer(Control container)
    {
        FPetraUtilsObject.HookupAllInContainer(container);
    }

    /// auto generated
    public bool CanClose()
    {
        return FPetraUtilsObject.CanClose();
    }

    /// auto generated
    public TFrmPetraUtils GetPetraUtilsObject()
    {
        return (TFrmPetraUtils)FPetraUtilsObject;
    }
#endregion

#region Action Handling

    /// auto generated
    public void ActionEnabledEvent(object sender, ActionEventArgs e)
    {
        if (e.ActionName == "actNew")
        {
            btnNew.Enabled = e.Enabled;
        }
        if (e.ActionName == "actDelete")
        {
            btnDelete.Enabled = e.Enabled;
        }
    }

#endregion
  }
}
