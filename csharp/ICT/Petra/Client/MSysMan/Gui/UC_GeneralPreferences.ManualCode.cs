//
// DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
//
// @Authors:
//       timop, peters
//
// Copyright 2004-2015 by OM International
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
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.Xml;
using Ict.Common;
using Ict.Common.IO;
using Ict.Petra.Client.App.Core.RemoteObjects;
using Ict.Petra.Client.App.Core;
using Ict.Petra.Client.CommonForms;
using Ict.Petra.Shared;
using Ict.Petra.Shared.MSysMan;

namespace Ict.Petra.Client.MSysMan.Gui
{
    public partial class TUC_GeneralPreferences
    {
        private bool LanguageChanged = false;
        private bool WasSaveWindowPropertiesInitiallyChecked = true;

        private void InitializeManualCode()
        {
            DataTable CultureTable = new DataTable();

            CultureTable.Columns.Add("Value", typeof(string));
            CultureTable.Columns.Add("Display", typeof(string));

            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                if (!ci.IsNeutralCulture)
                {
                    DataRow row = CultureTable.NewRow();
                    row[0] = ci.Name;
                    row[1] = ci.EnglishName;
                    CultureTable.Rows.Add(row);
                }
            }

            CultureTable.DefaultView.Sort = "Display";

            cmbCulture.DisplayMember = "Display";
            cmbCulture.ValueMember = "Value";
            cmbCulture.DataSource = CultureTable.DefaultView;

            // load languages from names of language sub directories
            string[] LanguageDirectories = Directory.GetDirectories(TAppSettingsManager.ApplicationDirectory);

            string LanguagesAvailable = "en-EN";

            foreach (String directory in LanguageDirectories)
            {
                if (File.Exists(directory + Path.DirectorySeparatorChar + "OpenPetra.resources.dll"))
                {
                    LanguagesAvailable = StringHelper.AddCSV(
                        LanguagesAvailable,
                        directory.Substring(
                            directory.LastIndexOf(Path.DirectorySeparatorChar) + 1));
                }
            }

            cmbLanguage.SetDataSourceStringList(LanguagesAvailable);

            // for the moment default to english, because translations are not fully supported, and the layout does not adjust
            string LanguageCode = "en-EN";
            string CultureCode = CultureInfo.CurrentCulture.Name;
            TRemote.MSysMan.Maintenance.WebConnectors.GetLanguageAndCulture(ref LanguageCode, ref CultureCode);

            cmbCulture.SetSelectedString(CultureCode);
            cmbLanguage.SetSelectedString(LanguageCode);

            llbLaunchpadLink.Click += LaunchpadLinkClicked;

            // Petra imports may use Chinese characters
            chkImportAsianANSI.Checked = TUserDefaults.GetBooleanDefault(TTextFileEncoding.ALLOW_MBCS_TEXT_ENCODING, false);

            // Get the number of recent partners that the user has set, if not found take 10 as default value.
            nudNumberOfPartners.Value = TUserDefaults.GetInt16Default(MSysManConstants.USERDEFAULT_NUMBEROFRECENTPARTNERS, 10);
            nudNumberOfPartners.Maximum = 10;

            // Startup Module
            PopulateStartupModuleList();
            cmbInitialSelectedModule.SetSelectedString(TUserDefaults.GetStringDefault(TUserDefaults.NamedDefaults.MODULE_TO_OPEN_AT_STARTUP,
                    "Partner"), 0);

            // Other preferences
            chkEscClosesScreen.Checked = TUserDefaults.GetBooleanDefault(TUserDefaults.NamedDefaults.USERDEFAULT_ESC_CLOSES_SCREEN, true);
            chkSaveWindowProperties.Checked = TUserDefaults.GetBooleanDefault(TUserDefaults.NamedDefaults.USERDEFAULT_SAVE_WINDOW_POS_AND_SIZE, true);

            WasSaveWindowPropertiesInitiallyChecked = chkSaveWindowProperties.Checked;
        }

        /// <summary>
        /// Gets the data from all UserControls on this TabControl.
        /// </summary>
        /// <returns>void</returns>
        public void GetDataFromControls()
        {
        }

        /// make sure that the primary key cannot be edited anymore
        public void SetPrimaryKeyReadOnly(bool AReadOnly)
        {
        }

        private void Language_Click(Object Sender, EventArgs e)
        {
            LanguageChanged = true;
        }

        /// <summary>
        /// Saves any changed preferences to s_user_defaults
        /// </summary>
        /// <returns>void</returns>
        public DialogResult SaveGeneralTab()
        {
            // First, we need to show any dialogs that may result in Cancel
            if (chkSaveWindowProperties.Checked && !WasSaveWindowPropertiesInitiallyChecked)
            {
                // The user wants to start saving the window positions etc.
                // If we have some information about this that we stored previously, we can offer to use it again...
                string localAppDataPath = Path.Combine(
                    TAppSettingsManager.GetLocalAppDataPath(),
                    CommonFormsResourcestrings.StrFolderOrganisationName,
                    System.Diagnostics.FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductName);
                string settingsFileName = String.Format(CommonFormsResourcestrings.StrScreenPositionsFileName, UserInfo.GUserInfo.UserID);
                string settingsPath = Path.Combine(localAppDataPath, settingsFileName);

                if (File.Exists(settingsPath))
                {
                    string msg = String.Format("{0}{1}{1}{2}",
                        CommonFormsResourcestrings.StrReuseScreenPositionsMessage1,
                        Environment.NewLine,
                        CommonFormsResourcestrings.StrReuseScreenPositionsMessage2);

                    bool DoNotShowMessageBoxEverytime = false;

                    TFrmExtendedMessageBox extendedMessageBox = new TFrmExtendedMessageBox(FPetraUtilsObject.GetForm());

                    // customise button text
                    extendedMessageBox.YesButtonText = Catalog.GetString("Keep");
                    extendedMessageBox.NoButtonText = Catalog.GetString("Discard");

                    extendedMessageBox.ShowDialog(msg,
                        CommonFormsResourcestrings.StrReuseScreenPositionsTitle,
                        string.Empty,
                        TFrmExtendedMessageBox.TButtons.embbYesNoCancel, TFrmExtendedMessageBox.TIcon.embiQuestion);
                    TFrmExtendedMessageBox.TResult result = extendedMessageBox.GetResult(out DoNotShowMessageBoxEverytime);

                    if (result == TFrmExtendedMessageBox.TResult.embrCancel)
                    {
                        return DialogResult.Cancel;
                    }
                    else if (result == TFrmExtendedMessageBox.TResult.embrNo)
                    {
                        try
                        {
                            // Delete the old file
                            File.Delete(settingsPath);
                        }
                        catch (Exception ex)
                        {
                            TLogging.Log(String.Format("Exception occurred while deleting the window position file '{0}': {1}",
                                    settingsPath,
                                    ex.Message), TLoggingType.ToLogfile);
                        }
                    }
                    else if (result == TFrmExtendedMessageBox.TResult.embrYes)
                    {
                        // Load the information we have already
                        PetraUtilsObject.LoadWindowPositionsFromFile();
                    }
                }
            }

            if (LanguageChanged)
            {
                string LanguageCode = cmbLanguage.GetSelectedString();
                string CultureCode = cmbCulture.GetSelectedString();

                // send to server
                TRemote.MSysMan.Maintenance.WebConnectors.SetLanguageAndCulture(LanguageCode, CultureCode);

                // set local settings for client
                Catalog.Init(LanguageCode, CultureCode);

                // TODO: can we reload the main window with the new language?
                MessageBox.Show(Catalog.GetString("Please restart the OpenPetra client to see the new language"),
                    Catalog.GetString("Restart the client"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            TUserDefaults.SetDefault(TTextFileEncoding.ALLOW_MBCS_TEXT_ENCODING, chkImportAsianANSI.Checked);
            TUserDefaults.SetDefault(MSysManConstants.USERDEFAULT_NUMBEROFRECENTPARTNERS, nudNumberOfPartners.Value);
            TUserDefaults.SetDefault(TUserDefaults.NamedDefaults.USERDEFAULT_ESC_CLOSES_SCREEN, chkEscClosesScreen.Checked);
            TUserDefaults.SetDefault(TUserDefaults.NamedDefaults.USERDEFAULT_SAVE_WINDOW_POS_AND_SIZE, chkSaveWindowProperties.Checked);
            TUserDefaults.SetDefault(TUserDefaults.NamedDefaults.MODULE_TO_OPEN_AT_STARTUP, cmbInitialSelectedModule.GetSelectedString());

            return DialogResult.OK;
        }

        private Boolean ViewMode
        {
            get
            {
                return ((TFrmUserPreferencesDialog)ParentForm).ViewMode;
            }
        }

        /// <summary>
        /// to be called when the client has logged in
        /// </summary>
        public static void InitLanguageAndCulture()
        {
            TRemote.MSysMan.Maintenance.WebConnectors.LoadLanguageAndCultureFromUserDefaults();

            // for the moment default to english, because translations are not fully supported, and the layout does not adjust
            string LanguageCode = "en-EN";
            string CultureCode = CultureInfo.CurrentCulture.Name;
            TRemote.MSysMan.Maintenance.WebConnectors.GetLanguageAndCulture(ref LanguageCode, ref CultureCode);

            // set local settings for client
            Catalog.Init(LanguageCode, CultureCode);
        }

        /// <summary>
        /// Event is fired when the Launchpad Translation Platform LinkLabel is 'clicked'.
        /// </summary>
        /// <param name="ASender">The Launchpad Translation Platform LinkLabel.</param>
        /// <param name="e">Not evaluated.</param>
        /// <returns>void</returns>
        private void LaunchpadLinkClicked(object ASender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://translations.openpetra.org");
        }

        private void PopulateStartupModuleList()
        {
            DataTable moduleTable = new DataTable();

            moduleTable.Columns.Add("Value", typeof(System.String));
            moduleTable.Columns.Add("Display", typeof(System.String));

            TYml2Xml parser = new TYml2Xml(TAppSettingsManager.GetValue("UINavigation.File"));
            XmlDocument UINavigation = parser.ParseYML2XML();

            XmlNode OpenPetraNode = UINavigation.FirstChild.NextSibling.FirstChild;
            XmlNode SearchBoxesNode = OpenPetraNode.FirstChild;
            XmlNode MainMenuNode = SearchBoxesNode.NextSibling;

            XmlNodeList modules = MainMenuNode.ChildNodes;

            foreach (XmlNode n in modules)
            {
                string moduleName = n.Name;

                if ((moduleName != "Settings") && (moduleName != "CrossLedgerSetup"))
                {
                    bool hasLabelAttribute = n.Attributes["Label"] != null;
                    DataRow row = moduleTable.NewRow();
                    row["Value"] = n.Name;
                    row["Display"] = hasLabelAttribute ? n.Attributes["Label"].Value.Replace("&", "") : n.Name;
                    moduleTable.Rows.Add(row);
                }
            }

            cmbInitialSelectedModule.ValueMember = "Value";
            cmbInitialSelectedModule.DisplayMember = "Display";
            cmbInitialSelectedModule.DataSource = moduleTable.DefaultView;
        }
    }
}