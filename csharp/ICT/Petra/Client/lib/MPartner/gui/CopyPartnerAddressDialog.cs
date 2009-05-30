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
using System.Windows.Forms;
using Ict.Petra.Client.CommonForms;
using Ict.Petra.Client.MPartner.Applink;

namespace Ict.Petra.Client.MPartner
{
    /// <summary>
    /// Description of TCopyPartnerAddressDialogWinForm.
    /// </summary>
    public partial class TCopyPartnerAddressDialogWinForm : TFrmPetraDialog
    {
        private TCmdMPartner CmdMPartner = new TCmdMPartner();
        private Int64 FPartnerKey, FSiteKey = 0;
        private Int32 FLocationKey = 0;

        public TCopyPartnerAddressDialogWinForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
        }

        public void SetParameters(Int64 APartnerKey, Int64 ASiteKey, Int32 ALocationKey)
        {
            FPartnerKey = APartnerKey;
            FSiteKey = ASiteKey;
            FLocationKey = ALocationKey;
        }

        private string GetFormattedAddress(string AAddressLayout)
        {
            string ReturnValue;

//			MessageBox.Show("FPartnerKey: " + FPartnerKey.ToString() + "FSiteKey: " + FSiteKey.ToString() +
//			                "FLocationKey: " + FLocationKey.ToString() + "AAddressLayout: " + AAddressLayout);
            ReturnValue = CmdMPartner.GetFormattedAddress(this, FPartnerKey,
                FSiteKey, FLocationKey, AAddressLayout);

//			MessageBox.Show("ReturnValue: " + ReturnValue);
            return ReturnValue;
        }
    }
}