/*************************************************************************
 *
 * DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
 *
 * @Authors:
 *       christiank, timop
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Ict.Petra.Client.CommonForms;

namespace Ict.Petra.Client.App.PetraClient
{
    /// <summary>
    /// Description of MainWindowContent.
    /// </summary>
    public partial class TUcoMainWindowContent : UserControl, IPetraUserControl
    {
        /// <summary>
        /// constructor
        /// </summary>
        public TUcoMainWindowContent()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
        }

        /// <summary>todoComment</summary>
        protected TFrmPetraModuleUtils FPetraUtilsObject;

        /// <summary>
        /// this provides general functionality for edit screens
        /// </summary>
        public TFrmPetraUtils PetraUtilsObject
        {
            get
            {
                return (TFrmPetraUtils)FPetraUtilsObject;
            }
            set
            {
                FPetraUtilsObject = (TFrmPetraModuleUtils)value;
                FPetraUtilsObject.ActionEnablingEvent += ActionEnabledEvent;
            }
        }

        /// <summary>
        /// todoComment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ActionEnabledEvent(object sender, ActionEventArgs e)
        {
            if (e.ActionName == "actPartnerModule")
            {
                btnPartner.ImageIndex = (e.Enabled ? 1 : 0);
                btnPartner.Enabled = e.Enabled;
            }

            if (e.ActionName == "actPersonnelModule")
            {
                btnPersonnel.ImageIndex = (e.Enabled ? 1 : 0);
                btnPersonnel.Enabled = e.Enabled;
            }

            if (e.ActionName == "actFinanceModule")
            {
                btnAccounts.ImageIndex = (e.Enabled ? 1 : 0);
                btnAccounts.Enabled = e.Enabled;
            }

            if (e.ActionName == "actConferenceModule")
            {
                btnConference.ImageIndex = (e.Enabled ? 1 : 0);
                btnConference.Enabled = e.Enabled;
            }

            if (e.ActionName == "actFinDevModule")
            {
                btnDevelopment.ImageIndex = (e.Enabled ? 1 : 0);
                btnDevelopment.Enabled = e.Enabled;
            }

            if (e.ActionName == "actSysManModule")
            {
                btnSysMan.ImageIndex = (e.Enabled ? 1 : 0);
                btnSysMan.Enabled = e.Enabled;
            }
        }

        /// <summary>
        /// todoComment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPartnerClick(System.Object sender, System.EventArgs e)
        {
            FPetraUtilsObject.OpenPartnerModule(sender, e);
        }

        /// <summary>
        /// todoComment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPersonnelClick(System.Object sender, System.EventArgs e)
        {
            FPetraUtilsObject.OpenPersonnelModule(sender, e);
        }

        /// <summary>
        /// todoComment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSysManClick(System.Object sender, System.EventArgs e)
        {
            FPetraUtilsObject.OpenSysManModule(sender, e);
        }

        /// <summary>
        /// todoComment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConferenceClick(System.Object sender, System.EventArgs e)
        {
            FPetraUtilsObject.OpenConferenceModule(sender, e);
        }

        /// <summary>
        /// todoComment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAccountsClick(System.Object sender, System.EventArgs e)
        {
            FPetraUtilsObject.OpenFinanceModule(sender, e);
        }

        /// <summary>
        /// todoComment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDevelopmentClick(System.Object sender, System.EventArgs e)
        {
            FPetraUtilsObject.OpenFinDevModule(sender, e);
        }
    }
}