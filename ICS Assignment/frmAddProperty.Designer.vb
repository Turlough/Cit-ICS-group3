<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddProperty
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
        Me.components = New System.ComponentModel.Container()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CtrlCustomer1 = New WindowsApplication1.ctrlCustomer()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnSearchCustomers = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CtrlProperty1 = New WindowsApplication1.ctrlProperty()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbLandlord = New System.Windows.Forms.RadioButton()
        Me.rbOwner = New System.Windows.Forms.RadioButton()
        Me.ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(488, 626)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(112, 55)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.CtrlCustomer1)
        Me.GroupBox1.Controls.Add(Me.btnClear)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.btnSearchCustomers)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 16)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(591, 295)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Owner"
        '
        'CtrlCustomer1
        '
        Me.CtrlCustomer1.Location = New System.Drawing.Point(31, 47)
        Me.CtrlCustomer1.Margin = New System.Windows.Forms.Padding(5)
        Me.CtrlCustomer1.Name = "CtrlCustomer1"
        Me.CtrlCustomer1.Size = New System.Drawing.Size(457, 241)
        Me.CtrlCustomer1.TabIndex = 14
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(496, 260)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(72, 28)
        Me.btnClear.TabIndex = 13
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(325, 27)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(162, 17)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Search for existing client"
        '
        'btnSearchCustomers
        '
        Me.btnSearchCustomers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearchCustomers.Location = New System.Drawing.Point(496, 21)
        Me.btnSearchCustomers.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearchCustomers.Name = "btnSearchCustomers"
        Me.btnSearchCustomers.Size = New System.Drawing.Size(72, 28)
        Me.btnSearchCustomers.TabIndex = 11
        Me.btnSearchCustomers.Text = "Search"
        Me.btnSearchCustomers.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.CtrlProperty1)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 396)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(593, 210)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Property"
        '
        'CtrlProperty1
        '
        Me.CtrlProperty1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlProperty1.Location = New System.Drawing.Point(3, 23)
        Me.CtrlProperty1.Margin = New System.Windows.Forms.Padding(5)
        Me.CtrlProperty1.Name = "CtrlProperty1"
        Me.CtrlProperty1.Size = New System.Drawing.Size(568, 154)
        Me.CtrlProperty1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.rbLandlord)
        Me.GroupBox3.Controls.Add(Me.rbOwner)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 324)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(593, 66)
        Me.GroupBox3.TabIndex = 20
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Relationship"
        '
        'rbLandlord
        '
        Me.rbLandlord.AutoSize = True
        Me.rbLandlord.Location = New System.Drawing.Point(319, 25)
        Me.rbLandlord.Margin = New System.Windows.Forms.Padding(4)
        Me.rbLandlord.Name = "rbLandlord"
        Me.rbLandlord.Size = New System.Drawing.Size(85, 21)
        Me.rbLandlord.TabIndex = 1
        Me.rbLandlord.Text = "Landlord"
        Me.rbLandlord.UseVisualStyleBackColor = True
        '
        'rbOwner
        '
        Me.rbOwner.AutoSize = True
        Me.rbOwner.Checked = True
        Me.rbOwner.Location = New System.Drawing.Point(221, 25)
        Me.rbOwner.Margin = New System.Windows.Forms.Padding(4)
        Me.rbOwner.Name = "rbOwner"
        Me.rbOwner.Size = New System.Drawing.Size(70, 21)
        Me.rbOwner.TabIndex = 0
        Me.rbOwner.TabStop = True
        Me.rbOwner.Text = "Owner"
        Me.rbOwner.UseVisualStyleBackColor = True
        '
        'ep
        '
        Me.ep.ContainerControl = Me
        '
        'frmAddProperty
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 695)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSave)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmAddProperty"
        Me.Text = "AddPropertyDetails"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnSearchCustomers As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbLandlord As System.Windows.Forms.RadioButton
    Friend WithEvents rbOwner As System.Windows.Forms.RadioButton
    Friend WithEvents ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents CtrlCustomer1 As WindowsApplication1.ctrlCustomer
    Friend WithEvents CtrlProperty1 As WindowsApplication1.ctrlProperty
End Class
