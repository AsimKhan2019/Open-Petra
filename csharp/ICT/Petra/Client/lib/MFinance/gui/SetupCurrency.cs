/* auto generated with nant generateWinforms from SetupCurrency.yaml
 *
 * DO NOT edit manually, DO NOT edit with the designer
 * use a user control if you need to modify the screen content
 *
 */
/*************************************************************************
 *
 * DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
 *
 * @Authors:
 *       auto generated
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
using Ict.Petra.Shared;
using System.Resources;
using System.Collections.Specialized;
using Mono.Unix;
using Ict.Common;
using Ict.Common.Verification;
using Ict.Petra.Client.App.Core;
using Ict.Petra.Client.App.Core.RemoteObjects;
using Ict.Common.Controls;
using Ict.Petra.Client.CommonForms;

namespace Ict.Petra.Client.MFinance.Gui.Setup
{

  /// auto generated: Currency List
  public partial class TFrmSetupCurrency: System.Windows.Forms.Form, IFrmPetraEdit
  {
    private TFrmPetraEditUtils FPetraUtilsObject;

    private class FMainDS
    {
        public static Ict.Petra.Shared.MCommon.Data.ACurrencyTable ACurrency;
    }

    /// constructor
    public TFrmSetupCurrency(IntPtr AParentFormHandle) : base()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      #region CATALOGI18N

      // this code has been inserted by GenerateI18N, all changes in this region will be overwritten by GenerateI18N
      this.btnNew.Text = Catalog.GetString("&New");
      this.btnDelete.Text = Catalog.GetString("&Delete");
      this.lblDetailCurrencyCode.Text = Catalog.GetString("Currency Code:");
      this.lblDetailCurrencyName.Text = Catalog.GetString("Currency Name:");
      this.lblDetailCurrencySymbol.Text = Catalog.GetString("Currency Symbol:");
      this.lblDetailCountryCode.Text = Catalog.GetString("Country Code:");
      this.lblDetailDisplayFormat.Text = Catalog.GetString("Number of Decimals:");
      this.tbbSave.ToolTipText = Catalog.GetString("Saves changed data");
      this.tbbSave.Text = Catalog.GetString("&Save");
      this.mniFileSave.ToolTipText = Catalog.GetString("Saves changed data");
      this.mniFileSave.Text = Catalog.GetString("&Save");
      this.mniFilePrint.Text = Catalog.GetString("&Print...");
      this.mniClose.ToolTipText = Catalog.GetString("Closes this window");
      this.mniClose.Text = Catalog.GetString("&Close");
      this.mniFile.Text = Catalog.GetString("&File");
      this.mniEditUndoCurrentField.Text = Catalog.GetString("Undo &Current Field");
      this.mniEditUndoScreen.Text = Catalog.GetString("&Undo Screen");
      this.mniEditFind.Text = Catalog.GetString("&Find...");
      this.mniEdit.Text = Catalog.GetString("&Edit");
      this.mniHelpPetraHelp.Text = Catalog.GetString("&Petra Help");
      this.mniHelpBugReport.Text = Catalog.GetString("Bug &Report");
      this.mniHelpAboutPetra.Text = Catalog.GetString("&About Petra");
      this.mniHelpDevelopmentTeam.Text = Catalog.GetString("&The Development Team...");
      this.mniHelp.Text = Catalog.GetString("&Help");
      this.Text = Catalog.GetString("Currency List");
      #endregion

      FPetraUtilsObject = new TFrmPetraEditUtils(AParentFormHandle, this, stbMain);
      FPetraUtilsObject.SetStatusBarText(txtDetailCurrencyCode, Catalog.GetString("Enter a currency code"));
      FPetraUtilsObject.SetStatusBarText(txtDetailCurrencyName, Catalog.GetString("Enter the currency name"));
      FPetraUtilsObject.SetStatusBarText(txtDetailCurrencySymbol, Catalog.GetString("Enter the symbol which represents this currency"));
      FPetraUtilsObject.SetStatusBarText(cmbDetailCountryCode, Catalog.GetString("Enter a valid country code."));
      cmbDetailCountryCode.InitialiseUserControl();
      FPetraUtilsObject.SetStatusBarText(txtDetailDisplayFormat, Catalog.GetString("The format in which to display and accept input on a currency."));
      FMainDS.ACurrency = new Ict.Petra.Shared.MCommon.Data.ACurrencyTable();
      Ict.Common.Data.TTypedDataTable TypedTable;
      TRemote.MCommon.DataReader.GetData(Ict.Petra.Shared.MCommon.Data.ACurrencyTable.GetTableDBName(), null, out TypedTable);
      FMainDS.ACurrency.Merge(TypedTable);
      grdDetails.Columns.Clear();
      grdDetails.AddTextColumn("Currency Code", FMainDS.ACurrency.ColumnCurrencyCode);
      grdDetails.AddTextColumn("Currency Name", FMainDS.ACurrency.ColumnCurrencyName);
      grdDetails.AddTextColumn("Currency Symbol", FMainDS.ACurrency.ColumnCurrencySymbol);
      grdDetails.AddTextColumn("Country Code", FMainDS.ACurrency.ColumnCountryCode);
      grdDetails.AddTextColumn("Display Format", FMainDS.ACurrency.ColumnDisplayFormat);
      FPetraUtilsObject.ActionEnablingEvent += ActionEnabledEvent;

      FPetraUtilsObject.InitActionState();

    }

    private void TFrmPetra_Activated(object sender, EventArgs e)
    {
        FPetraUtilsObject.TFrmPetra_Activated(sender, e);
    }

    private void TFrmPetra_Load(object sender, EventArgs e)
    {
        FPetraUtilsObject.TFrmPetra_Load(sender, e);
    }

    private void TFrmPetra_Closing(object sender, CancelEventArgs e)
    {
        FPetraUtilsObject.TFrmPetra_Closing(sender, e);
    }

    private void Form_KeyDown(object sender, KeyEventArgs e)
    {
        FPetraUtilsObject.Form_KeyDown(sender, e);
    }

    private void TFrmPetra_Closed(object sender, EventArgs e)
    {
        // TODO? Save Window position

    }

    /// automatically generated, create a new record of ACurrency and display on the edit screen
    /// we create the table locally, no dataset
    public bool CreateNewACurrency()
    {
        Ict.Petra.Shared.MCommon.Data.ACurrencyRow NewRow = FMainDS.ACurrency.NewRowTyped();
        FMainDS.ACurrency.Rows.Add(NewRow);

        FPetraUtilsObject.SetChangedFlag();

        grdDetails.DataSource = new DevAge.ComponentModel.BoundDataView(FMainDS.ACurrency.DefaultView);
        grdDetails.Refresh();
        SelectDetailRowByDataTableIndex(FMainDS.ACurrency.Rows.Count - 1);

        return true;
    }

    private void SelectDetailRowByDataTableIndex(Int32 ARowNumberInTable)
    {
        Int32 RowNumberGrid = -1;
        for (int Counter = 0; Counter < grdDetails.DataSource.Count; Counter++)
        {
            bool found = true;
            foreach (DataColumn myColumn in FMainDS.ACurrency.PrimaryKey)
            {
                string value1 = FMainDS.ACurrency.Rows[ARowNumberInTable][myColumn].ToString();
                string value2 = (grdDetails.DataSource as DevAge.ComponentModel.BoundDataView).mDataView[Counter][myColumn.Ordinal].ToString();
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

    /// return the index in the detail datatable of the selected row, not the index in the datagrid
    private Int32 GetSelectedDetailDataTableIndex()
    {
        DataRowView[] SelectedGridRow = grdDetails.SelectedDataRowsAsDataRowView;

        if (SelectedGridRow.Length >= 1)
        {
            // this would return the index in the grid: return grdDetails.DataSource.IndexOf(SelectedGridRow[0]);
            // we could keep track of the order in the datatable ourselves: return Convert.ToInt32(SelectedGridRow[0][ORIGINALINDEX]);
            // does not seem to work: return grdDetails.DataSourceRowToIndex2(SelectedGridRow[0]);

            for (int Counter = 0; Counter < FMainDS.ACurrency.Rows.Count; Counter++)
            {
                bool found = true;
                foreach (DataColumn myColumn in FMainDS.ACurrency.PrimaryKey)
                {
                    if (FMainDS.ACurrency.Rows[Counter][myColumn].ToString() !=
                        SelectedGridRow[0][myColumn.Ordinal].ToString())
                    {
                        found = false;
                    }

                }
                if (found)
                {
                    return Counter;
                }
            }
        }

        return -1;
    }

    private void ShowDetails(Int32 ACurrentDetailIndex)
    {
        txtDetailCurrencyCode.Text = FMainDS.ACurrency[ACurrentDetailIndex].CurrencyCode;
        txtDetailCurrencyName.Text = FMainDS.ACurrency[ACurrentDetailIndex].CurrencyName;
        txtDetailCurrencySymbol.Text = FMainDS.ACurrency[ACurrentDetailIndex].CurrencySymbol;
        cmbDetailCountryCode.SetSelectedString(FMainDS.ACurrency[ACurrentDetailIndex].CountryCode);
        txtDetailDisplayFormat.Text = FMainDS.ACurrency[ACurrentDetailIndex].DisplayFormat;
    }

    private Int32 FPreviouslySelectedDetailRow = -1;
    private void FocusedRowChanged(System.Object sender, SourceGrid.RowEventArgs e)
    {
        // get the details from the previously selected row
        if (FPreviouslySelectedDetailRow != -1)
        {
            GetDetailsFromControls(FPreviouslySelectedDetailRow);
        }
        // display the details of the currently selected row; e.Row: first row has number 1
        ShowDetails(GetSelectedDetailDataTableIndex());
        FPreviouslySelectedDetailRow = GetSelectedDetailDataTableIndex();
        pnlDetails.Enabled = true;
    }

    private void GetDetailsFromControls(Int32 ACurrentDetailIndex)
    {
        if (ACurrentDetailIndex != -1)
        {
            FMainDS.ACurrency[ACurrentDetailIndex].CurrencyCode = txtDetailCurrencyCode.Text;
            FMainDS.ACurrency[ACurrentDetailIndex].CurrencyName = txtDetailCurrencyName.Text;
            FMainDS.ACurrency[ACurrentDetailIndex].CurrencySymbol = txtDetailCurrencySymbol.Text;
            FMainDS.ACurrency[ACurrentDetailIndex].CountryCode = cmbDetailCountryCode.GetSelectedString();
            FMainDS.ACurrency[ACurrentDetailIndex].DisplayFormat = txtDetailDisplayFormat.Text;
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

    /// auto generated
    public void FileSave(object sender, EventArgs e)
    {
        SaveChanges();
    }

    /// <summary>
    /// save the changes on the screen
    /// </summary>
    /// <returns></returns>
    public bool SaveChanges()
    {
        FPetraUtilsObject.OnDataSavingStart(this, new System.EventArgs());

//TODO?  still needed?      FMainDS.AApDocument.Rows[0].BeginEdit();
        GetDetailsFromControls(GetSelectedDetailDataTableIndex());

        // TODO: verification

        if (FPetraUtilsObject.VerificationResultCollection.Count == 0)
        {
            foreach (DataRow InspectDR in FMainDS.ACurrency.Rows)
            {
                InspectDR.EndEdit();
            }

            if (FPetraUtilsObject.HasChanges)
            {
                FPetraUtilsObject.WriteToStatusBar("Saving data...");
                this.Cursor = Cursors.WaitCursor;

                TSubmitChangesResult SubmissionResult;
                TVerificationResultCollection VerificationResult;

                Ict.Common.Data.TTypedDataTable SubmitDT = FMainDS.ACurrency.GetChangesTyped();

                // Submit changes to the PETRAServer
                try
                {
                    SubmissionResult = TRemote.MCommon.DataReader.SaveData(Ict.Petra.Shared.MCommon.Data.ACurrencyTable.GetTableDBName(), ref SubmitDT, out VerificationResult);
                }
                catch (System.Net.Sockets.SocketException)
                {
                    FPetraUtilsObject.WriteToStatusBar("Data could not be saved!");
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("The PETRA Server cannot be reached! Data cannot be saved!",
                        "No Server response",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                    bool ReturnValue = false;

                    // TODO OnDataSaved(this, new TDataSavedEventArgs(ReturnValue));
                    return ReturnValue;
                }
/* TODO ESecurityDBTableAccessDeniedException
*                  catch (ESecurityDBTableAccessDeniedException Exp)
*                  {
*                      FPetraUtilsObject.WriteToStatusBar("Data could not be saved!");
*                      this.Cursor = Cursors.Default;
*                      // TODO TMessages.MsgSecurityException(Exp, this.GetType());
*                      bool ReturnValue = false;
*                      // TODO OnDataSaved(this, new TDataSavedEventArgs(ReturnValue));
*                      return ReturnValue;
*                  }
*/
                catch (EDBConcurrencyException)
                {
                    FPetraUtilsObject.WriteToStatusBar("Data could not be saved!");
                    this.Cursor = Cursors.Default;

                    // TODO TMessages.MsgDBConcurrencyException(Exp, this.GetType());
                    bool ReturnValue = false;

                    // TODO OnDataSaved(this, new TDataSavedEventArgs(ReturnValue));
                    return ReturnValue;
                }
                catch (Exception exp)
                {
                    FPetraUtilsObject.WriteToStatusBar("Data could not be saved!");
                    this.Cursor = Cursors.Default;
                    TLogging.Log(
                        "An error occured while trying to connect to the PETRA Server!" + Environment.NewLine + exp.ToString(),
                        TLoggingType.ToLogfile);
                    MessageBox.Show(
                        "An error occured while trying to connect to the PETRA Server!" + Environment.NewLine +
                        "For details see the log file: " + TLogging.GetLogFileName(),
                        "Server connection error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                    bool ReturnValue = false;

                    // TODO OnDataSaved(this, new TDataSavedEventArgs(ReturnValue));
                    return ReturnValue;
                }

                switch (SubmissionResult)
                {
                    case TSubmitChangesResult.scrOK:

                        // Call AcceptChanges to get rid now of any deleted columns before we Merge with the result from the Server
                        FMainDS.ACurrency.AcceptChanges();

                        // Merge back with data from the Server (eg. for getting Sequence values)
                        FMainDS.ACurrency.Merge(SubmitDT, false);

                        // need to accept the new modification ID
                        FMainDS.ACurrency.AcceptChanges();

                        // Update UI
                        FPetraUtilsObject.WriteToStatusBar("Data successfully saved.");
                        this.Cursor = Cursors.Default;

                        // TODO EnableSave(false);

                        // We don't have unsaved changes anymore
                        FPetraUtilsObject.DisableSaveButton();

                        // TODO OnDataSaved(this, new TDataSavedEventArgs(ReturnValue));
                        return true;

                    case TSubmitChangesResult.scrError:

                        // TODO scrError
                        break;

                    case TSubmitChangesResult.scrNothingToBeSaved:

                        // TODO scrNothingToBeSaved
                        break;

                    case TSubmitChangesResult.scrInfoNeeded:

                        // TODO scrInfoNeeded
                        break;
                }
            }
        }

        return false;
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
        if (e.ActionName == "actSave")
        {
            tbbSave.Enabled = e.Enabled;
            mniFileSave.Enabled = e.Enabled;
        }
        if (e.ActionName == "actClose")
        {
            mniClose.Enabled = e.Enabled;
        }
        mniFilePrint.Enabled = false;
        mniEditUndoCurrentField.Enabled = false;
        mniEditUndoScreen.Enabled = false;
        mniEditFind.Enabled = false;
        mniHelpPetraHelp.Enabled = false;
        mniHelpBugReport.Enabled = false;
        mniHelpAboutPetra.Enabled = false;
        mniHelpDevelopmentTeam.Enabled = false;
    }

    /// auto generated
    protected void actClose(object sender, EventArgs e)
    {
        FPetraUtilsObject.ExecuteAction(eActionId.eClose);
    }

#endregion
  }
}
