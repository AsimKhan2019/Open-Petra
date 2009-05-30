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
using System.Windows.Forms;
using System.Collections;
using Ict.Common.Verification;

namespace Ict.Petra.Shared
{
    /// Contains functions for processing of error messages, etc.
    public class Messages
    {
        /// <summary>
        /// format an error message using the errors from Verification Result
        /// </summary>
        /// <param name="AMessageHeadline"></param>
        /// <param name="AVerificationResult"></param>
        /// <returns></returns>
        public static String BuildMessageFromVerificationResult(String AMessageHeadline, TVerificationResultCollection AVerificationResult)
        {
            String ReturnValue;
            IEnumerator VerificationResultEnum;
            TVerificationResult VerificationResultEntry;

            if (AMessageHeadline == null)
            {
                AMessageHeadline = "Saving of data failed!" + Environment.NewLine + "Reasons:";
            }

            // MessageBox.Show('AVerificationResult.Count: ' + AVerificationResult.Count.ToString);
            ReturnValue = AMessageHeadline + Environment.NewLine;
            VerificationResultEnum = AVerificationResult.GetEnumerator();

            while (VerificationResultEnum.MoveNext())
            {
                VerificationResultEntry = ((TVerificationResult)VerificationResultEnum.Current);
                ReturnValue = ReturnValue + "  * [" + VerificationResultEntry.FResultContext + "] " + VerificationResultEntry.FResultText +
                              Environment.NewLine + Environment.NewLine;
            }

            return ReturnValue;
        }
    }
}