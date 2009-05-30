/*************************************************************************
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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using Ict.Petra.Shared.MPartner.Partner.Data;
using Ict.Petra.Client.CommonForms;
using System.Globalization;
using Ict.Petra.Shared;
using Ict.Petra.Shared.MPartner;
using Ict.Petra.Client.MPartner;
using Ict.Petra.Client.MCommon;
using Ict.Petra.Client.App.Core;
using Ict.Petra.Client.App.Formatting;
using Ict.Common.Controls;
using Ict.Petra.Client.CommonControls;
using Ict.Common;

namespace Ict.Petra.Client.MPartner
{
    /// <summary>
    /// UserControl for editing Partner Details for a Partner of Partner Class PERSON.
    /// </summary>
    public class TUC_PartnerDetailsPerson : System.Windows.Forms.UserControl, IPetraEditUserControl
    {
        /// <summary> Required designer variable. </summary>
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Panel pnlPartnerDetailsPerson;
        private System.Windows.Forms.Label lblAcademicTitle;
        private TCmbAutoPopulated cmbMaritalStatus;
        private System.Windows.Forms.Label lblMaritalStatus;
        private TCmbAutoPopulated cmbLanguageCode;
        private System.Windows.Forms.TextBox txtLocalName;
        private System.Windows.Forms.TextBox txtPreviousName;
        private System.Windows.Forms.TextBox txtPreferredName;
        private System.Windows.Forms.Label lblDecorations;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblLanguageCode;
        private System.Windows.Forms.Label lblLocalName;
        private System.Windows.Forms.Label lblAcquisitionCode;
        private System.Windows.Forms.Label lblPreferredName;
        private System.Windows.Forms.TextBox txtDecorations;
        private System.Windows.Forms.TextBox txtAcademicTitle;
        private System.Windows.Forms.Label lblPreviousName;
        private System.Windows.Forms.GroupBox grpNames;
        private System.Windows.Forms.GroupBox grpMisc;
        private System.Windows.Forms.TextBox txtDateOfBirth;
        private TbtnCreated btnCreatedPerson;
        private TCmbAutoPopulated cmbAcquisitionCode;
        private System.Windows.Forms.Label lblMaritalStatusSince;
        private System.Windows.Forms.TextBox txtMaritalStatusSince;
        private System.Windows.Forms.GroupBox grpChristianSince;
        private System.Windows.Forms.Label lblChristianSince;
        private System.Windows.Forms.TextBox txtChristianSince;
        private System.Windows.Forms.TextBox txtChristianComment;
        private System.Windows.Forms.Panel pnlBirthDecoration;
        private System.Windows.Forms.Panel pnlPreferedPreviousName;
        private System.Windows.Forms.Panel pnlLocalName;
        private System.Windows.Forms.Panel pnlMaritalAcademic;
        private System.Windows.Forms.Panel pnlMaritalSince;
        private System.Windows.Forms.Panel pnlLanguageCode;
        private System.Windows.Forms.Panel pnlAcquisition;
        private System.Windows.Forms.Panel pnlOccupation;
        private System.Windows.Forms.Panel pnlChristianSinceYear;
        private System.Windows.Forms.Label lblComment;
        private TtxtAutoPopulatedButtonLabel txtOccupationCode;
        private System.Windows.Forms.Label lblMaritalStatusComment;
        private System.Windows.Forms.TextBox txtMaritalStatusComment;

        /// <summary>todoComment</summary>
        protected PartnerEditTDS FMainDS;
        private System.Object FSelectedAcquisitionCode;

        /// <summary>todoComment</summary>
        public TexpTextBoxStringLengthCheck expStringLengthCheckPerson;

        /// <summary>todoComment</summary>
        public PartnerEditTDS MainDS
        {
            get
            {
                return FMainDS;
            }

            set
            {
                FMainDS = value;
            }
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// <summary> Required method for Designer support  do not modify the contents of this method with the code editor. </summary> <summary> Required method for Designer support  do not modify the contents of this method with the code editor.
        /// </summary>
        /// </summary>
        /// <returns>void</returns>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(TUC_PartnerDetailsPerson));
            this.components = new System.ComponentModel.Container();
            this.pnlPartnerDetailsPerson = new System.Windows.Forms.Panel();
            this.btnCreatedPerson = new Ict.Common.Controls.TbtnCreated();
            this.grpMisc = new System.Windows.Forms.GroupBox();
            this.pnlOccupation = new System.Windows.Forms.Panel();
            this.txtOccupationCode = new Ict.Petra.Client.CommonControls.TtxtAutoPopulatedButtonLabel();
            this.pnlAcquisition = new System.Windows.Forms.Panel();
            this.lblAcquisitionCode = new System.Windows.Forms.Label();
            this.cmbAcquisitionCode = new Ict.Petra.Client.CommonControls.TCmbAutoPopulated();
            this.pnlLanguageCode = new System.Windows.Forms.Panel();
            this.lblLanguageCode = new System.Windows.Forms.Label();
            this.cmbLanguageCode = new Ict.Petra.Client.CommonControls.TCmbAutoPopulated();
            this.pnlMaritalSince = new System.Windows.Forms.Panel();
            this.txtMaritalStatusComment = new System.Windows.Forms.TextBox();
            this.lblMaritalStatusComment = new System.Windows.Forms.Label();
            this.lblMaritalStatusSince = new System.Windows.Forms.Label();
            this.txtMaritalStatusSince = new System.Windows.Forms.TextBox();
            this.pnlMaritalAcademic = new System.Windows.Forms.Panel();
            this.lblMaritalStatus = new System.Windows.Forms.Label();
            this.cmbMaritalStatus = new Ict.Petra.Client.CommonControls.TCmbAutoPopulated();
            this.lblAcademicTitle = new System.Windows.Forms.Label();
            this.txtAcademicTitle = new System.Windows.Forms.TextBox();
            this.pnlBirthDecoration = new System.Windows.Forms.Panel();
            this.txtDecorations = new System.Windows.Forms.TextBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.txtDateOfBirth = new System.Windows.Forms.TextBox();
            this.lblDecorations = new System.Windows.Forms.Label();
            this.grpNames = new System.Windows.Forms.GroupBox();
            this.pnlLocalName = new System.Windows.Forms.Panel();
            this.lblLocalName = new System.Windows.Forms.Label();
            this.txtLocalName = new System.Windows.Forms.TextBox();
            this.pnlPreferedPreviousName = new System.Windows.Forms.Panel();
            this.lblPreferredName = new System.Windows.Forms.Label();
            this.txtPreferredName = new System.Windows.Forms.TextBox();
            this.lblPreviousName = new System.Windows.Forms.Label();
            this.txtPreviousName = new System.Windows.Forms.TextBox();
            this.grpChristianSince = new System.Windows.Forms.GroupBox();
            this.pnlChristianSinceYear = new System.Windows.Forms.Panel();
            this.txtChristianSince = new System.Windows.Forms.TextBox();
            this.lblChristianSince = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtChristianComment = new System.Windows.Forms.TextBox();
            this.expStringLengthCheckPerson = new Ict.Petra.Client.CommonControls.TexpTextBoxStringLengthCheck(this.components);
            this.pnlPartnerDetailsPerson.SuspendLayout();
            this.grpMisc.SuspendLayout();
            this.pnlOccupation.SuspendLayout();
            this.pnlAcquisition.SuspendLayout();
            this.pnlLanguageCode.SuspendLayout();
            this.pnlMaritalSince.SuspendLayout();
            this.pnlMaritalAcademic.SuspendLayout();
            this.pnlBirthDecoration.SuspendLayout();
            this.grpNames.SuspendLayout();
            this.pnlLocalName.SuspendLayout();
            this.pnlPreferedPreviousName.SuspendLayout();
            this.grpChristianSince.SuspendLayout();
            this.pnlChristianSinceYear.SuspendLayout();
            this.SuspendLayout();

            //
            // pnlPartnerDetailsPerson
            //
            this.pnlPartnerDetailsPerson.Anchor =
                ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPartnerDetailsPerson.AutoScroll = true;
            this.pnlPartnerDetailsPerson.AutoScrollMinSize = new System.Drawing.Size(550, 330);
            this.pnlPartnerDetailsPerson.Controls.Add(this.btnCreatedPerson);
            this.pnlPartnerDetailsPerson.Controls.Add(this.grpMisc);
            this.pnlPartnerDetailsPerson.Controls.Add(this.grpNames);
            this.pnlPartnerDetailsPerson.Controls.Add(this.grpChristianSince);
            this.pnlPartnerDetailsPerson.Location = new System.Drawing.Point(0, 0);
            this.pnlPartnerDetailsPerson.Name = "pnlPartnerDetailsPerson";
            this.pnlPartnerDetailsPerson.Size = new System.Drawing.Size(634, 342);
            this.pnlPartnerDetailsPerson.TabIndex = 0;

            //
            // btnCreatedPerson
            //
            this.btnCreatedPerson.Anchor =
                ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnCreatedPerson.CreatedBy = null;
            this.btnCreatedPerson.DateCreated = new System.DateTime((System.Int64) 0);
            this.btnCreatedPerson.DateModified = new System.DateTime((System.Int64) 0);
            this.btnCreatedPerson.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreatedPerson.Image = ((System.Drawing.Image)(resources.GetObject('b' + "tnCreatedPerson.Image")));
            this.btnCreatedPerson.Location = new System.Drawing.Point(616, 2);
            this.btnCreatedPerson.ModifiedBy = null;
            this.btnCreatedPerson.Name = "btnCreatedPerson";
            this.btnCreatedPerson.Size = new System.Drawing.Size(14, 16);
            this.btnCreatedPerson.TabIndex = 3;
            this.btnCreatedPerson.Tag = "dontdisable";

            //
            // grpMisc
            //
            this.grpMisc.Anchor =
                ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMisc.Controls.Add(this.pnlOccupation);
            this.grpMisc.Controls.Add(this.pnlAcquisition);
            this.grpMisc.Controls.Add(this.pnlLanguageCode);
            this.grpMisc.Controls.Add(this.pnlMaritalSince);
            this.grpMisc.Controls.Add(this.pnlMaritalAcademic);
            this.grpMisc.Controls.Add(this.pnlBirthDecoration);
            this.grpMisc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMisc.Location = new System.Drawing.Point(4, 68);
            this.grpMisc.Name = "grpMisc";
            this.grpMisc.Size = new System.Drawing.Size(610, 208);
            this.grpMisc.TabIndex = 1;
            this.grpMisc.TabStop = false;
            this.grpMisc.Text = "Miscellaneous";

            //
            // pnlOccupation
            //
            this.pnlOccupation.BackColor = System.Drawing.SystemColors.Control;
            this.pnlOccupation.Controls.Add(this.txtOccupationCode);
            this.pnlOccupation.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOccupation.Font =
                new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.pnlOccupation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlOccupation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pnlOccupation.Location = new System.Drawing.Point(3, 181);
            this.pnlOccupation.Name = "pnlOccupation";
            this.pnlOccupation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlOccupation.Size = new System.Drawing.Size(604, 23);
            this.pnlOccupation.TabIndex = 21;

            //
            // txtOccupationCode
            //
            this.txtOccupationCode.ASpecialSetting = true;
            this.txtOccupationCode.ButtonText = "&Occupation...";
            this.txtOccupationCode.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtOccupationCode.ButtonWidth = 108;
            this.txtOccupationCode.ListTable = TtxtAutoPopulatedButtonLabel.TListTableEnum.OccupationList;
            this.txtOccupationCode.Location = new System.Drawing.Point(17, 0);
            this.txtOccupationCode.MaxLength = 32767;
            this.txtOccupationCode.Name = "txtOccupationCode";
            this.txtOccupationCode.PartnerClass = "";
            this.txtOccupationCode.PreventFaultyLeaving = false;
            this.txtOccupationCode.ReadOnly = false;
            this.txtOccupationCode.Size = new System.Drawing.Size(584, 23);
            this.txtOccupationCode.TabIndex = 16;
            this.txtOccupationCode.TextBoxWidth = 170;
            this.txtOccupationCode.VerificationResultCollection = null;
            this.txtOccupationCode.ClickButton += new TDelegateClickButton(this.TxtOccupationCode_ClickButton);

            //
            // pnlAcquisition
            //
            this.pnlAcquisition.BackColor = System.Drawing.SystemColors.Control;
            this.pnlAcquisition.Controls.Add(this.lblAcquisitionCode);
            this.pnlAcquisition.Controls.Add(this.cmbAcquisitionCode);
            this.pnlAcquisition.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAcquisition.Font =
                new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.pnlAcquisition.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlAcquisition.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pnlAcquisition.Location = new System.Drawing.Point(3, 158);
            this.pnlAcquisition.Name = "pnlAcquisition";
            this.pnlAcquisition.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlAcquisition.Size = new System.Drawing.Size(604, 23);
            this.pnlAcquisition.TabIndex = 20;

            //
            // lblAcquisitionCode
            //
            this.lblAcquisitionCode.Location = new System.Drawing.Point(17, 0);
            this.lblAcquisitionCode.Name = "lblAcquisitionCode";
            this.lblAcquisitionCode.Size = new System.Drawing.Size(108, 22);
            this.lblAcquisitionCode.TabIndex = 12;
            this.lblAcquisitionCode.Text = "&Acquisition Code:";
            this.lblAcquisitionCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //
            // cmbAcquisitionCode
            //
            this.cmbAcquisitionCode.Anchor =
                ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAcquisitionCode.ComboBoxWidth = 95;
            this.cmbAcquisitionCode.Filter = null;
            this.cmbAcquisitionCode.ListTable = TCmbAutoPopulated.TListTableEnum.AcquisitionCodeList;
            this.cmbAcquisitionCode.Location = new System.Drawing.Point(127, 0);
            this.cmbAcquisitionCode.Name = "cmbAcquisitionCode";
            this.cmbAcquisitionCode.SelectedItem = ((System.Object)(resources.GetObject('c' + "mbAcquisitionCode.SelectedItem")));
            this.cmbAcquisitionCode.SelectedValue = null;
            this.cmbAcquisitionCode.Size = new System.Drawing.Size(512, 22);
            this.cmbAcquisitionCode.TabIndex = 13;

            if (this.cmbAcquisitionCode.CausesValidation)
            {
                // strange; there was no assignment in delphi.net; but that is not allowed in c#
            }

            this.cmbAcquisitionCode.Leave += new System.EventHandler(this.CmbAcquisitionCode_Leave);

            //
            // pnlLanguageCode
            //
            this.pnlLanguageCode.BackColor = System.Drawing.SystemColors.Control;
            this.pnlLanguageCode.Controls.Add(this.lblLanguageCode);
            this.pnlLanguageCode.Controls.Add(this.cmbLanguageCode);
            this.pnlLanguageCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLanguageCode.Font =
                new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.pnlLanguageCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlLanguageCode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pnlLanguageCode.Location = new System.Drawing.Point(3, 135);
            this.pnlLanguageCode.Name = "pnlLanguageCode";
            this.pnlLanguageCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlLanguageCode.Size = new System.Drawing.Size(604, 23);
            this.pnlLanguageCode.TabIndex = 19;

            //
            // lblLanguageCode
            //
            this.lblLanguageCode.Location = new System.Drawing.Point(17, 0);
            this.lblLanguageCode.Name = "lblLanguageCode";
            this.lblLanguageCode.Size = new System.Drawing.Size(108, 22);
            this.lblLanguageCode.TabIndex = 10;
            this.lblLanguageCode.Text = "Lang&uage Code:";
            this.lblLanguageCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //
            // cmbLanguageCode
            //
            this.cmbLanguageCode.Anchor =
                ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLanguageCode.ComboBoxWidth = 57;
            this.cmbLanguageCode.Filter = null;
            this.cmbLanguageCode.ListTable = TCmbAutoPopulated.TListTableEnum.LanguageCodeList;
            this.cmbLanguageCode.Location = new System.Drawing.Point(127, 0);
            this.cmbLanguageCode.Name = "cmbLanguageCode";
            this.cmbLanguageCode.SelectedItem = ((System.Object)(resources.GetObject('c' + "mbLanguageCode.SelectedItem")));
            this.cmbLanguageCode.SelectedValue = null;
            this.cmbLanguageCode.Size = new System.Drawing.Size(468, 22);
            this.cmbLanguageCode.TabIndex = 11;

            //
            // pnlMaritalSince
            //
            this.pnlMaritalSince.Controls.Add(this.txtMaritalStatusComment);
            this.pnlMaritalSince.Controls.Add(this.lblMaritalStatusComment);
            this.pnlMaritalSince.Controls.Add(this.lblMaritalStatusSince);
            this.pnlMaritalSince.Controls.Add(this.txtMaritalStatusSince);
            this.pnlMaritalSince.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMaritalSince.Location = new System.Drawing.Point(3, 63);
            this.pnlMaritalSince.Name = "pnlMaritalSince";
            this.pnlMaritalSince.Size = new System.Drawing.Size(604, 72);
            this.pnlMaritalSince.TabIndex = 18;

            //
            // txtMaritalStatusComment
            //
            this.txtMaritalStatusComment.Anchor =
                ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaritalStatusComment.Font = new System.Drawing.Font("Verdana",
                8.25f,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point,
                (byte)0);
            this.txtMaritalStatusComment.Location = new System.Drawing.Point(127, 24);
            this.txtMaritalStatusComment.Multiline = true;
            this.txtMaritalStatusComment.Name = "txtMaritalStatusComment";
            this.txtMaritalStatusComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMaritalStatusComment.Size = new System.Drawing.Size(472, 44);
            this.txtMaritalStatusComment.TabIndex = 19;
            this.txtMaritalStatusComment.Text = "";

            //
            // lblMaritalStatusComment
            //
            this.lblMaritalStatusComment.Font = new System.Drawing.Font("Verdana",
                8.25f,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point,
                (byte)0);
            this.lblMaritalStatusComment.Location = new System.Drawing.Point(1, 27);
            this.lblMaritalStatusComment.Name = "lblMaritalStatusComment";
            this.lblMaritalStatusComment.Size = new System.Drawing.Size(124, 40);
            this.lblMaritalStatusComment.TabIndex = 18;
            this.lblMaritalStatusComment.Text = "Marital Status Comment:";
            this.lblMaritalStatusComment.TextAlign = System.Drawing.ContentAlignment.TopRight;

            //
            // lblMaritalStatusSince
            //
            this.lblMaritalStatusSince.Location = new System.Drawing.Point(1, 0);
            this.lblMaritalStatusSince.Name = "lblMaritalStatusSince";
            this.lblMaritalStatusSince.Size = new System.Drawing.Size(124, 22);
            this.lblMaritalStatusSince.TabIndex = 4;
            this.lblMaritalStatusSince.Text = "Marital Status Si&nce:";
            this.lblMaritalStatusSince.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //
            // txtMaritalStatusSince
            //
            this.txtMaritalStatusSince.Font = new System.Drawing.Font("Verdana",
                8.25f,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point,
                (byte)0);
            this.txtMaritalStatusSince.Location = new System.Drawing.Point(127, 0);
            this.txtMaritalStatusSince.Name = "txtMaritalStatusSince";
            this.txtMaritalStatusSince.Size = new System.Drawing.Size(94, 21);
            this.txtMaritalStatusSince.TabIndex = 5;
            this.txtMaritalStatusSince.Text = "";

            //
            // pnlMaritalAcademic
            //
            this.pnlMaritalAcademic.Controls.Add(this.lblMaritalStatus);
            this.pnlMaritalAcademic.Controls.Add(this.cmbMaritalStatus);
            this.pnlMaritalAcademic.Controls.Add(this.lblAcademicTitle);
            this.pnlMaritalAcademic.Controls.Add(this.txtAcademicTitle);
            this.pnlMaritalAcademic.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMaritalAcademic.Location = new System.Drawing.Point(3, 40);
            this.pnlMaritalAcademic.Name = "pnlMaritalAcademic";
            this.pnlMaritalAcademic.Size = new System.Drawing.Size(604, 23);
            this.pnlMaritalAcademic.TabIndex = 17;

            //
            // lblMaritalStatus
            //
            this.lblMaritalStatus.Location = new System.Drawing.Point(17, 0);
            this.lblMaritalStatus.Name = "lblMaritalStatus";
            this.lblMaritalStatus.Size = new System.Drawing.Size(108, 22);
            this.lblMaritalStatus.TabIndex = 2;
            this.lblMaritalStatus.Text = "Mari&tal Status:";
            this.lblMaritalStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //
            // cmbMaritalStatus
            //
            this.cmbMaritalStatus.ComboBoxWidth = 39;
            this.cmbMaritalStatus.Filter = null;
            this.cmbMaritalStatus.ListTable = TCmbAutoPopulated.TListTableEnum.MaritalStatusList;
            this.cmbMaritalStatus.Location = new System.Drawing.Point(127, 0);
            this.cmbMaritalStatus.Name = "cmbMaritalStatus";
            this.cmbMaritalStatus.SelectedItem = ((System.Object)(resources.GetObject('c' + "mbMaritalStatus.SelectedItem")));
            this.cmbMaritalStatus.SelectedValue = null;
            this.cmbMaritalStatus.Size = new System.Drawing.Size(211, 22);
            this.cmbMaritalStatus.TabIndex = 3;

            //
            // lblAcademicTitle
            //
            this.lblAcademicTitle.Location = new System.Drawing.Point(351, 0);
            this.lblAcademicTitle.Name = "lblAcademicTitle";
            this.lblAcademicTitle.Size = new System.Drawing.Size(104, 22);
            this.lblAcademicTitle.TabIndex = 8;
            this.lblAcademicTitle.Text = "A&cademic Title:";
            this.lblAcademicTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //
            // txtAcademicTitle
            //
            this.txtAcademicTitle.Anchor =
                ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcademicTitle.Font =
                new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtAcademicTitle.Location = new System.Drawing.Point(459, 0);
            this.txtAcademicTitle.Name = "txtAcademicTitle";
            this.txtAcademicTitle.Size = new System.Drawing.Size(140, 21);
            this.txtAcademicTitle.TabIndex = 9;
            this.txtAcademicTitle.Text = "";

            //
            // pnlBirthDecoration
            //
            this.pnlBirthDecoration.Controls.Add(this.txtDecorations);
            this.pnlBirthDecoration.Controls.Add(this.lblDateOfBirth);
            this.pnlBirthDecoration.Controls.Add(this.txtDateOfBirth);
            this.pnlBirthDecoration.Controls.Add(this.lblDecorations);
            this.pnlBirthDecoration.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBirthDecoration.Location = new System.Drawing.Point(3, 17);
            this.pnlBirthDecoration.Name = "pnlBirthDecoration";
            this.pnlBirthDecoration.Size = new System.Drawing.Size(604, 23);
            this.pnlBirthDecoration.TabIndex = 16;

            //
            // txtDecorations
            //
            this.txtDecorations.Anchor =
                ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecorations.Font =
                new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtDecorations.Location = new System.Drawing.Point(459, 0);
            this.txtDecorations.Name = "txtDecorations";
            this.txtDecorations.Size = new System.Drawing.Size(140, 21);
            this.txtDecorations.TabIndex = 8;
            this.txtDecorations.Text = "";

            //
            // lblDateOfBirth
            //
            this.lblDateOfBirth.Location = new System.Drawing.Point(21, 0);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(104, 22);
            this.lblDateOfBirth.TabIndex = 0;
            this.lblDateOfBirth.Text = "&Date of Birth:";
            this.lblDateOfBirth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //
            // txtDateOfBirth
            //
            this.txtDateOfBirth.Font =
                new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtDateOfBirth.Location = new System.Drawing.Point(127, 0);
            this.txtDateOfBirth.Name = "txtDateOfBirth";
            this.txtDateOfBirth.Size = new System.Drawing.Size(94, 21);
            this.txtDateOfBirth.TabIndex = 1;
            this.txtDateOfBirth.Text = "";

            //
            // lblDecorations
            //
            this.lblDecorations.Location = new System.Drawing.Point(351, 0);
            this.lblDecorations.Name = "lblDecorations";
            this.lblDecorations.Size = new System.Drawing.Size(104, 21);
            this.lblDecorations.TabIndex = 6;
            this.lblDecorations.Text = "Dec&orations:";
            this.lblDecorations.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //
            // grpNames
            //
            this.grpNames.Anchor =
                ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNames.Controls.Add(this.pnlLocalName);
            this.grpNames.Controls.Add(this.pnlPreferedPreviousName);
            this.grpNames.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpNames.Location = new System.Drawing.Point(4, 0);
            this.grpNames.Name = "grpNames";
            this.grpNames.Size = new System.Drawing.Size(610, 68);
            this.grpNames.TabIndex = 0;
            this.grpNames.TabStop = false;
            this.grpNames.Text = "Names";

            //
            // pnlLocalName
            //
            this.pnlLocalName.Controls.Add(this.lblLocalName);
            this.pnlLocalName.Controls.Add(this.txtLocalName);
            this.pnlLocalName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLocalName.Location = new System.Drawing.Point(3, 40);
            this.pnlLocalName.Name = "pnlLocalName";
            this.pnlLocalName.Size = new System.Drawing.Size(604, 24);
            this.pnlLocalName.TabIndex = 7;

            //
            // lblLocalName
            //
            this.lblLocalName.Location = new System.Drawing.Point(17, 0);
            this.lblLocalName.Name = "lblLocalName";
            this.lblLocalName.Size = new System.Drawing.Size(108, 23);
            this.lblLocalName.TabIndex = 4;
            this.lblLocalName.Text = "&Local Name:";
            this.lblLocalName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //
            // txtLocalName
            //
            this.txtLocalName.Anchor =
                ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalName.Font =
                new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtLocalName.Location = new System.Drawing.Point(127, 0);
            this.txtLocalName.Name = "txtLocalName";
            this.txtLocalName.Size = new System.Drawing.Size(472, 21);
            this.txtLocalName.TabIndex = 5;
            this.txtLocalName.Text = "";

            //
            // pnlPreferedPreviousName
            //
            this.pnlPreferedPreviousName.Controls.Add(this.lblPreferredName);
            this.pnlPreferedPreviousName.Controls.Add(this.txtPreferredName);
            this.pnlPreferedPreviousName.Controls.Add(this.lblPreviousName);
            this.pnlPreferedPreviousName.Controls.Add(this.txtPreviousName);
            this.pnlPreferedPreviousName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPreferedPreviousName.Location = new System.Drawing.Point(3, 17);
            this.pnlPreferedPreviousName.Name = "pnlPreferedPreviousName";
            this.pnlPreferedPreviousName.Size = new System.Drawing.Size(604, 23);
            this.pnlPreferedPreviousName.TabIndex = 6;

            //
            // lblPreferredName
            //
            this.lblPreferredName.Location = new System.Drawing.Point(17, 0);
            this.lblPreferredName.Name = "lblPreferredName";
            this.lblPreferredName.Size = new System.Drawing.Size(108, 23);
            this.lblPreferredName.TabIndex = 0;
            this.lblPreferredName.Text = "&Preferred Name:";
            this.lblPreferredName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //
            // txtPreferredName
            //
            this.txtPreferredName.Font =
                new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtPreferredName.Location = new System.Drawing.Point(127, 0);
            this.txtPreferredName.Name = "txtPreferredName";
            this.txtPreferredName.Size = new System.Drawing.Size(142, 21);
            this.txtPreferredName.TabIndex = 1;
            this.txtPreferredName.Text = "";

            //
            // lblPreviousName
            //
            this.lblPreviousName.Location = new System.Drawing.Point(319, 0);
            this.lblPreviousName.Name = "lblPreviousName";
            this.lblPreviousName.Size = new System.Drawing.Size(136, 22);
            this.lblPreviousName.TabIndex = 2;
            this.lblPreviousName.Text = "P&revious Name:";
            this.lblPreviousName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //
            // txtPreviousName
            //
            this.txtPreviousName.Anchor =
                ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPreviousName.Font =
                new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtPreviousName.Location = new System.Drawing.Point(459, 0);
            this.txtPreviousName.Name = "txtPreviousName";
            this.txtPreviousName.Size = new System.Drawing.Size(140, 21);
            this.txtPreviousName.TabIndex = 3;
            this.txtPreviousName.Text = "";

            //
            // grpChristianSince
            //
            this.grpChristianSince.Anchor =
                ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpChristianSince.Controls.Add(this.pnlChristianSinceYear);
            this.grpChristianSince.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChristianSince.Location = new System.Drawing.Point(4, 276);
            this.grpChristianSince.Name = "grpChristianSince";
            this.grpChristianSince.Size = new System.Drawing.Size(610, 66);
            this.grpChristianSince.TabIndex = 2;
            this.grpChristianSince.TabStop = false;
            this.grpChristianSince.Text = "Christian since";
            this.grpChristianSince.Visible = false;

            //
            // pnlChristianSinceYear
            //
            this.pnlChristianSinceYear.Controls.Add(this.txtChristianSince);
            this.pnlChristianSinceYear.Controls.Add(this.lblChristianSince);
            this.pnlChristianSinceYear.Controls.Add(this.lblComment);
            this.pnlChristianSinceYear.Controls.Add(this.txtChristianComment);
            this.pnlChristianSinceYear.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChristianSinceYear.Location = new System.Drawing.Point(3, 17);
            this.pnlChristianSinceYear.Name = "pnlChristianSinceYear";
            this.pnlChristianSinceYear.Size = new System.Drawing.Size(604, 46);
            this.pnlChristianSinceYear.TabIndex = 5;

            //
            // txtChristianSince
            //
            this.txtChristianSince.Font =
                new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtChristianSince.Location = new System.Drawing.Point(84, 0);
            this.txtChristianSince.MaxLength = 4;
            this.txtChristianSince.Name = "txtChristianSince";
            this.txtChristianSince.Size = new System.Drawing.Size(39, 21);
            this.txtChristianSince.TabIndex = 1;
            this.txtChristianSince.Text = "8888";

            //
            // lblChristianSince
            //
            this.lblChristianSince.Location = new System.Drawing.Point(1, 0);
            this.lblChristianSince.Name = "lblChristianSince";
            this.lblChristianSince.Size = new System.Drawing.Size(82, 21);
            this.lblChristianSince.TabIndex = 0;
            this.lblChristianSince.Text = "&Year:";
            this.lblChristianSince.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //
            // lblComment
            //
            this.lblComment.Location = new System.Drawing.Point(127, 0);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(66, 21);
            this.lblComment.TabIndex = 6;
            this.lblComment.Text = "Comment:";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //
            // txtChristianComment
            //
            this.txtChristianComment.Anchor =
                ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top |
                                                       System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChristianComment.Font = new System.Drawing.Font("Verdana",
                8.25f,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point,
                (byte)0);
            this.txtChristianComment.Location = new System.Drawing.Point(195, 0);
            this.txtChristianComment.MaxLength = 500;
            this.txtChristianComment.Multiline = true;
            this.txtChristianComment.Name = "txtChristianComment";
            this.txtChristianComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChristianComment.Size = new System.Drawing.Size(405, 42);
            this.txtChristianComment.TabIndex = 2;
            this.txtChristianComment.Text = "";
            this.txtChristianComment.TextChanged += new System.EventHandler(this.TxtChristianComment_TextChanged);

            //
            // TUC_PartnerDetailsPerson
            //
            this.Controls.Add(this.pnlPartnerDetailsPerson);
            this.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Name = "TUC_PartnerDetailsPerson";
            this.Size = new System.Drawing.Size(634, 342);
            this.pnlPartnerDetailsPerson.ResumeLayout(false);
            this.grpMisc.ResumeLayout(false);
            this.pnlOccupation.ResumeLayout(false);
            this.pnlAcquisition.ResumeLayout(false);
            this.pnlLanguageCode.ResumeLayout(false);
            this.pnlMaritalSince.ResumeLayout(false);
            this.pnlMaritalAcademic.ResumeLayout(false);
            this.pnlBirthDecoration.ResumeLayout(false);
            this.grpNames.ResumeLayout(false);
            this.pnlLocalName.ResumeLayout(false);
            this.pnlPreferedPreviousName.ResumeLayout(false);
            this.grpChristianSince.ResumeLayout(false);
            this.pnlChristianSinceYear.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        public TUC_PartnerDetailsPerson() : base()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            // I18N: assign proper font which helps to read asian characters
            txtLocalName.Font = TAppSettingsManager.GetDefaultBoldFont();
            txtPreviousName.Font = TAppSettingsManager.GetDefaultBoldFont();
            txtPreferredName.Font = TAppSettingsManager.GetDefaultBoldFont();
        }

        /// <summary>
        /// todoComment
        /// </summary>
        /// <param name="Disposing"></param>
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

        private TFrmPetraEditUtils FPetraUtilsObject;

        /// <summary>
        /// this provides general functionality for edit screens
        /// </summary>
        public TFrmPetraEditUtils PetraUtilsObject
        {
            get
            {
                return FPetraUtilsObject;
            }
            set
            {
                FPetraUtilsObject = value;
            }
        }

        #region Public methods

        /// <summary>
        /// todoComment
        /// </summary>
        public void InitialiseUserControl()
        {
            Binding DateFormatBinding;
            Binding NullableNumberFormatBinding;

            // Names GroupBox
            txtPreferredName.DataBindings.Add("Text", FMainDS.PPerson, PPersonTable.GetPreferedNameDBName());
            txtPreviousName.DataBindings.Add("Text", FMainDS.PPartner, PPartnerTable.GetPreviousNameDBName());
            txtLocalName.DataBindings.Add("Text", FMainDS.PPartner, PPartnerTable.GetPartnerShortNameLocDBName());
            txtDecorations.DataBindings.Add("Text", FMainDS.PPerson, PPersonTable.GetDecorationsDBName());
            txtAcademicTitle.DataBindings.Add("Text", FMainDS.PPerson, PPersonTable.GetAcademicTitleDBName());
            txtOccupationCode.PerformDataBinding(FMainDS.PPerson.DefaultView, PPersonTable.GetOccupationCodeDBName());

            // Miscellaneous GroupBox
            DateFormatBinding = new Binding("Text", FMainDS.PPerson, PPersonTable.GetDateOfBirthDBName());
            DateFormatBinding.Format += new ConvertEventHandler(DataBinding.DateTimeToLongDateString);
            DateFormatBinding.Parse += new ConvertEventHandler(DataBinding.LongDateStringToDateTime);
            txtDateOfBirth.DataBindings.Add(DateFormatBinding);
            DateFormatBinding = new Binding("Text", FMainDS.PPerson, PPersonTable.GetMaritalStatusSinceDBName());
            DateFormatBinding.Format += new ConvertEventHandler(DataBinding.DateTimeToLongDateString);
            DateFormatBinding.Parse += new ConvertEventHandler(DataBinding.LongDateStringToDateTime);
            txtMaritalStatusSince.DataBindings.Add(DateFormatBinding);

            // DataBind AutoPopulatingComboBoxes
            cmbAcquisitionCode.PerformDataBinding(FMainDS.PPartner, PPartnerTable.GetAcquisitionCodeDBName());
            cmbMaritalStatus.PerformDataBinding(FMainDS.PPerson, PPersonTable.GetMaritalStatusDBName());
            cmbLanguageCode.PerformDataBinding(FMainDS.PPartner, PPartnerTable.GetLanguageCodeDBName());

            // Christian since GroupBox
            this.txtChristianComment.DataBindings.Add("Text", FMainDS.PPerson, PPersonTable.GetBelieverSinceCommentDBName());
            NullableNumberFormatBinding = new Binding("Text", FMainDS.PPerson, PPersonTable.GetBelieverSinceYearDBName());
            NullableNumberFormatBinding.Format += new ConvertEventHandler(DataBinding.Int32ToNullableNumber_2);
            NullableNumberFormatBinding.Parse += new ConvertEventHandler(DataBinding.NullableNumberToInt32);
            this.txtChristianSince.DataBindings.Add(NullableNumberFormatBinding);
            this.txtMaritalStatusComment.DataBindings.Add("Text", FMainDS,
                PPersonTable.GetTableName() + "." + PFamilyTable.GetMaritalStatusCommentDBName());
            btnCreatedPerson.UpdateFields(FMainDS.PPerson);

            // Extender Provider
            this.expStringLengthCheckPerson.RetrieveTextboxes(this);

            // Set StatusBar Texts
            FPetraUtilsObject.SetStatusBarText(txtPreferredName, PPersonTable.GetPreferedNameHelp());
            FPetraUtilsObject.SetStatusBarText(txtPreviousName, PPartnerTable.GetPreviousNameHelp());
            FPetraUtilsObject.SetStatusBarText(txtLocalName, PPartnerTable.GetPartnerShortNameLocHelp());
            FPetraUtilsObject.SetStatusBarText(txtDecorations, PPersonTable.GetDecorationsHelp());
            FPetraUtilsObject.SetStatusBarText(txtAcademicTitle, PPersonTable.GetAcademicTitleHelp());
            FPetraUtilsObject.SetStatusBarText(txtOccupationCode, PPersonTable.GetOccupationCodeHelp());
            FPetraUtilsObject.SetStatusBarText(txtDateOfBirth, PPersonTable.GetDateOfBirthHelp());
            FPetraUtilsObject.SetStatusBarText(txtMaritalStatusSince, PPersonTable.GetMaritalStatusSinceHelp());
            FPetraUtilsObject.SetStatusBarText(cmbAcquisitionCode, PPartnerTable.GetAcquisitionCodeHelp());
            FPetraUtilsObject.SetStatusBarText(cmbMaritalStatus, PPersonTable.GetMaritalStatusHelp());
            FPetraUtilsObject.SetStatusBarText(cmbLanguageCode, PPartnerTable.GetLanguageCodeHelp());
            FPetraUtilsObject.SetStatusBarText(txtChristianSince, PPersonTable.GetBelieverSinceYearHelp());
            FPetraUtilsObject.SetStatusBarText(txtChristianComment, PPersonTable.GetBelieverSinceCommentHelp());
            #region Verification
            txtOccupationCode.VerificationResultCollection = FPetraUtilsObject.VerificationResultCollection;
            #endregion
            ApplySecurity();
        }

        #endregion

        #region Helper functions
        private void ApplySecurity()
        {
            if (!UserInfo.GUserInfo.IsTableAccessOK(TTableAccessPermission.tapMODIFY, PPartnerTable.GetTableDBName()))
            {
                // need to disable all Fields that are DataBound to p_partner
                // MessageBox.Show('Disabling p_partner fields...');
                CustomEnablingDisabling.DisableControl(pnlPreferedPreviousName, txtPreviousName);
                CustomEnablingDisabling.DisableControl(pnlLocalName, txtLocalName);
                CustomEnablingDisabling.DisableControl(pnlAcquisition, cmbAcquisitionCode);
                CustomEnablingDisabling.DisableControl(pnlAcquisition, cmbLanguageCode);
            }

            if (!UserInfo.GUserInfo.IsTableAccessOK(TTableAccessPermission.tapMODIFY, PPersonTable.GetTableDBName()))
            {
                // need to disable all Fields that are DataBound to p_person
                CustomEnablingDisabling.DisableControlGroup(pnlBirthDecoration);
                CustomEnablingDisabling.DisableControlGroup(pnlMaritalAcademic);
                CustomEnablingDisabling.DisableControlGroup(pnlMaritalSince);
                CustomEnablingDisabling.DisableControlGroup(pnlOccupation);
                CustomEnablingDisabling.DisableControlGroup(pnlChristianSinceYear);
                CustomEnablingDisabling.DisableControl(pnlPreferedPreviousName, txtPreferredName);
            }
        }

        #endregion

        #region Event Handlers
        private void TxtOccupationCode_ClickButton(string LabelStringIn,
            string TextBoxStringIn,
            out string LabelStringOut,
            out string TextBoxStringOut)
        {
// TODO Occupation
            LabelStringOut = null;
            TextBoxStringOut = "";
#if TODO
            TCmdMPartner mCmdMPartner;
            String mOccupationCode;

            // call Progress from here
            mCmdMPartner = new TCmdMPartner();
            mCmdMPartner.OpenOccupationFindScreen(this.ParentForm, out mOccupationCode);

            // I can only return the Occupation Code
            TextBoxStringOut = mOccupationCode;
            LabelStringOut = null;
#endif
        }

        private void TxtChristianComment_TextChanged(System.Object sender, System.EventArgs e)
        {
            // messagebox.Show('MaxLength: ' + this.txtChristianComment.MaxLength.ToString + this.txtChristianComment.Text);
        }

        /// <summary>
        /// checks that the Acquisition Code is valid.
        /// </summary>
        /// <returns>void</returns>
        private void CmbAcquisitionCode_Leave(System.Object sender, System.EventArgs e)
        {
            DataTable DataCacheAcquisitionCodeTable;
            PAcquisitionRow TmpRow;
            DialogResult UseAlthoughUnassignable;

            try
            {
                // check if the publication selected is valid, if not, gives warning.
                DataCacheAcquisitionCodeTable = TDataCache.TMPartner.GetCacheablePartnerTable(TCacheablePartnerTablesEnum.AcquisitionCodeList);
                TmpRow = (PAcquisitionRow)DataCacheAcquisitionCodeTable.Rows.Find(new Object[] { this.cmbAcquisitionCode.SelectedItem.ToString() });

                if (TmpRow != null)
                {
                    if (TmpRow.ValidAcquisition)
                    {
                        FSelectedAcquisitionCode = cmbAcquisitionCode.SelectedItem;
                    }
                    else
                    {
                        UseAlthoughUnassignable = MessageBox.Show(CommonResourcestrings.StrErrorTheCodeIsNoLongerActive1 + " '" +
                            this.cmbAcquisitionCode.SelectedItem.ToString() + "' " +
                            CommonResourcestrings.StrErrorTheCodeIsNoLongerActive2 + "\r\n" +
                            CommonResourcestrings.StrErrorTheCodeIsNoLongerActive3 + "\r\n" + "\r\n" +
                            "Message Number: " + ErrorCodes.PETRAERRORCODE_VALUEUNASSIGNABLE + "\r\n" +
                            "File Name: " + this.GetType().FullName, "Invalid Data Entered",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);

                        if (UseAlthoughUnassignable == System.Windows.Forms.DialogResult.No)
                        {
                            // If user selects not to use the publication, the recent publication code is selected.
                            this.cmbAcquisitionCode.SelectedItem = FSelectedAcquisitionCode;
                        }
                        else
                        {
                            FSelectedAcquisitionCode = cmbAcquisitionCode.SelectedItem;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion
    }
}