﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFindProperties
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnLocateProperty = New System.Windows.Forms.Button()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.maxPrice = New System.Windows.Forms.NumericUpDown()
        Me.minPrice = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.maxBeds = New System.Windows.Forms.NumericUpDown()
        Me.minBeds = New System.Windows.Forms.NumericUpDown()
        Me.txtCounty = New System.Windows.Forms.TextBox()
        Me.txtTown = New System.Windows.Forms.TextBox()
        Me.txtAdd = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvProperties = New System.Windows.Forms.DataGridView()
        Me.btnSetActive = New System.Windows.Forms.Button()
        Me.btnOthers = New System.Windows.Forms.Button()
        Me.btnCreateAppointment = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtTownEdit = New System.Windows.Forms.TextBox()
        Me.txtAdd2 = New System.Windows.Forms.TextBox()
        Me.txtAdd1 = New System.Windows.Forms.TextBox()
        Me.txtCountyEdit = New System.Windows.Forms.TextBox()
        Me.txtOwner = New System.Windows.Forms.TextBox()
        Me.rtbDescription = New System.Windows.Forms.RichTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pbxPhoto = New System.Windows.Forms.PictureBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.maxPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.minPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.maxBeds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.minBeds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Location = New System.Drawing.Point(379, 583)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 16
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(476, 583)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 22
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnLocateProperty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbStatus)
        Me.SplitContainer1.Panel1.Controls.Add(Me.maxPrice)
        Me.SplitContainer1.Panel1.Controls.Add(Me.minPrice)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.maxBeds)
        Me.SplitContainer1.Panel1.Controls.Add(Me.minBeds)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCounty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtTown)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtAdd)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSetActive)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnOthers)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCreateAppointment)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCancel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnSave)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtPrice)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtStatus)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtTownEdit)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtAdd2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtAdd1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtCountyEdit)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtOwner)
        Me.SplitContainer1.Panel2.Controls.Add(Me.rtbDescription)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label17)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label16)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label15)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label14)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label12)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pbxPhoto)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnEdit)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnDelete)
        Me.SplitContainer1.Size = New System.Drawing.Size(1032, 613)
        Me.SplitContainer1.SplitterDistance = 472
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 36
        '
        'btnLocateProperty
        '
        Me.btnLocateProperty.Location = New System.Drawing.Point(307, 194)
        Me.btnLocateProperty.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnLocateProperty.Name = "btnLocateProperty"
        Me.btnLocateProperty.Size = New System.Drawing.Size(147, 53)
        Me.btnLocateProperty.TabIndex = 9
        Me.btnLocateProperty.Text = "Locate Property"
        Me.btnLocateProperty.UseVisualStyleBackColor = True
        '
        'cmbStatus
        '
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"Valuation Pending", "Documentation Pending", "Offer Accepted", "For Sale", "For Rent", "Off Market"})
        Me.cmbStatus.Location = New System.Drawing.Point(172, 1)
        Me.cmbStatus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(280, 24)
        Me.cmbStatus.TabIndex = 1
        '
        'maxPrice
        '
        Me.maxPrice.Location = New System.Drawing.Point(313, 160)
        Me.maxPrice.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.maxPrice.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.maxPrice.Name = "maxPrice"
        Me.maxPrice.Size = New System.Drawing.Size(100, 22)
        Me.maxPrice.TabIndex = 8
        '
        'minPrice
        '
        Me.minPrice.Location = New System.Drawing.Point(172, 160)
        Me.minPrice.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.minPrice.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.minPrice.Name = "minPrice"
        Me.minPrice.Size = New System.Drawing.Size(100, 22)
        Me.minPrice.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(419, 161)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 17)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "max"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(419, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 17)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "max"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(277, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 17)
        Me.Label10.TabIndex = 51
        Me.Label10.Text = "min"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(277, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 17)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "min"
        '
        'maxBeds
        '
        Me.maxBeds.Location = New System.Drawing.Point(313, 126)
        Me.maxBeds.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.maxBeds.Name = "maxBeds"
        Me.maxBeds.Size = New System.Drawing.Size(100, 22)
        Me.maxBeds.TabIndex = 6
        '
        'minBeds
        '
        Me.minBeds.Location = New System.Drawing.Point(172, 126)
        Me.minBeds.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.minBeds.Name = "minBeds"
        Me.minBeds.Size = New System.Drawing.Size(100, 22)
        Me.minBeds.TabIndex = 5
        '
        'txtCounty
        '
        Me.txtCounty.Location = New System.Drawing.Point(172, 94)
        Me.txtCounty.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCounty.Name = "txtCounty"
        Me.txtCounty.Size = New System.Drawing.Size(280, 22)
        Me.txtCounty.TabIndex = 4
        '
        'txtTown
        '
        Me.txtTown.Location = New System.Drawing.Point(172, 65)
        Me.txtTown.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTown.Name = "txtTown"
        Me.txtTown.Size = New System.Drawing.Size(280, 22)
        Me.txtTown.TabIndex = 3
        '
        'txtAdd
        '
        Me.txtAdd.Location = New System.Drawing.Point(172, 37)
        Me.txtAdd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAdd.Name = "txtAdd"
        Me.txtAdd.Size = New System.Drawing.Size(280, 22)
        Me.txtAdd.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 160)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 17)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "Price"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 17)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Number Of Beds"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 17)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "County"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 17)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Town"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 17)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 17)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Address"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.dgvProperties)
        Me.Panel1.Location = New System.Drawing.Point(3, 252)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(467, 354)
        Me.Panel1.TabIndex = 36
        '
        'dgvProperties
        '
        Me.dgvProperties.AllowUserToAddRows = False
        Me.dgvProperties.AllowUserToDeleteRows = False
        Me.dgvProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProperties.Location = New System.Drawing.Point(0, 0)
        Me.dgvProperties.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvProperties.Name = "dgvProperties"
        Me.dgvProperties.ReadOnly = True
        Me.dgvProperties.RowHeadersVisible = False
        Me.dgvProperties.RowTemplate.Height = 24
        Me.dgvProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProperties.Size = New System.Drawing.Size(467, 354)
        Me.dgvProperties.TabIndex = 11
        '
        'btnSetActive
        '
        Me.btnSetActive.Location = New System.Drawing.Point(17, 252)
        Me.btnSetActive.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSetActive.Name = "btnSetActive"
        Me.btnSetActive.Size = New System.Drawing.Size(208, 28)
        Me.btnSetActive.TabIndex = 52
        Me.btnSetActive.Text = "Set as Active Property"
        Me.btnSetActive.UseVisualStyleBackColor = True
        '
        'btnOthers
        '
        Me.btnOthers.Location = New System.Drawing.Point(463, 20)
        Me.btnOthers.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOthers.Name = "btnOthers"
        Me.btnOthers.Size = New System.Drawing.Size(75, 28)
        Me.btnOthers.TabIndex = 42
        Me.btnOthers.Text = "Others"
        Me.btnOthers.UseVisualStyleBackColor = True
        '
        'btnCreateAppointment
        '
        Me.btnCreateAppointment.Location = New System.Drawing.Point(304, 252)
        Me.btnCreateAppointment.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCreateAppointment.Name = "btnCreateAppointment"
        Me.btnCreateAppointment.Size = New System.Drawing.Size(235, 28)
        Me.btnCreateAppointment.TabIndex = 41
        Me.btnCreateAppointment.Text = "Create Appointment"
        Me.btnCreateAppointment.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(184, 583)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 40
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(283, 583)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 39
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(303, 46)
        Me.txtPrice.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(233, 22)
        Me.txtPrice.TabIndex = 10
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(303, 78)
        Me.txtStatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(233, 22)
        Me.txtStatus.TabIndex = 11
        '
        'txtTownEdit
        '
        Me.txtTownEdit.Location = New System.Drawing.Point(303, 176)
        Me.txtTownEdit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTownEdit.Name = "txtTownEdit"
        Me.txtTownEdit.Size = New System.Drawing.Size(233, 22)
        Me.txtTownEdit.TabIndex = 14
        '
        'txtAdd2
        '
        Me.txtAdd2.Location = New System.Drawing.Point(303, 144)
        Me.txtAdd2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAdd2.Name = "txtAdd2"
        Me.txtAdd2.Size = New System.Drawing.Size(233, 22)
        Me.txtAdd2.TabIndex = 13
        '
        'txtAdd1
        '
        Me.txtAdd1.Location = New System.Drawing.Point(303, 112)
        Me.txtAdd1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAdd1.Name = "txtAdd1"
        Me.txtAdd1.Size = New System.Drawing.Size(233, 22)
        Me.txtAdd1.TabIndex = 12
        '
        'txtCountyEdit
        '
        Me.txtCountyEdit.Location = New System.Drawing.Point(303, 208)
        Me.txtCountyEdit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCountyEdit.Name = "txtCountyEdit"
        Me.txtCountyEdit.Size = New System.Drawing.Size(233, 22)
        Me.txtCountyEdit.TabIndex = 15
        '
        'txtOwner
        '
        Me.txtOwner.Location = New System.Drawing.Point(303, 20)
        Me.txtOwner.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtOwner.Name = "txtOwner"
        Me.txtOwner.Size = New System.Drawing.Size(149, 22)
        Me.txtOwner.TabIndex = 32
        '
        'rtbDescription
        '
        Me.rtbDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbDescription.Location = New System.Drawing.Point(17, 288)
        Me.rtbDescription.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rtbDescription.Name = "rtbDescription"
        Me.rtbDescription.Size = New System.Drawing.Size(519, 288)
        Me.rtbDescription.TabIndex = 31
        Me.rtbDescription.Text = "Enter description here...."
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(228, 148)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 17)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "Address2"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(228, 116)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 17)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "Address1"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(243, 213)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 17)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "County"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(251, 180)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 17)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Town"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(247, 86)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 17)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Status"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(243, 49)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 17)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Price"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(233, 23)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 17)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Owner"
        '
        'pbxPhoto
        '
        Me.pbxPhoto.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.pbxPhoto.Location = New System.Drawing.Point(17, 7)
        Me.pbxPhoto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pbxPhoto.Name = "pbxPhoto"
        Me.pbxPhoto.Size = New System.Drawing.Size(203, 225)
        Me.pbxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxPhoto.TabIndex = 23
        Me.pbxPhoto.TabStop = False
        '
        'frmFindProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1032, 613)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmFindProperties"
        Me.Text = "Manage Properties"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.maxPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.minPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.maxBeds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.minBeds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnLocateProperty As System.Windows.Forms.Button
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents maxPrice As System.Windows.Forms.NumericUpDown
    Friend WithEvents minPrice As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents maxBeds As System.Windows.Forms.NumericUpDown
    Friend WithEvents minBeds As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtCounty As System.Windows.Forms.TextBox
    Friend WithEvents txtTown As System.Windows.Forms.TextBox
    Friend WithEvents txtAdd As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvProperties As System.Windows.Forms.DataGridView
    Friend WithEvents rtbDescription As System.Windows.Forms.RichTextBox
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pbxPhoto As System.Windows.Forms.PictureBox
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtTownEdit As System.Windows.Forms.TextBox
    Friend WithEvents txtAdd2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAdd1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCountyEdit As System.Windows.Forms.TextBox
    Friend WithEvents txtOwner As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnCreateAppointment As System.Windows.Forms.Button
    Friend WithEvents btnOthers As System.Windows.Forms.Button
    Friend WithEvents btnSetActive As System.Windows.Forms.Button
End Class
