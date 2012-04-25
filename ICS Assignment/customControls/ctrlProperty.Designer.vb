<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlProperty
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.cstmCounty = New WindowsApplication1.crtlCounty()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAdd1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAdd2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTown = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ep = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cstmCounty
        '
        Me.cstmCounty.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cstmCounty.CausesValidation = False
        Me.cstmCounty.County = ""
        Me.cstmCounty.Location = New System.Drawing.Point(94, 88)
        Me.cstmCounty.Name = "cstmCounty"
        Me.cstmCounty.Size = New System.Drawing.Size(271, 26)
        Me.cstmCounty.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Address Line 1*"
        '
        'txtAdd1
        '
        Me.txtAdd1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAdd1.Location = New System.Drawing.Point(93, 8)
        Me.txtAdd1.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAdd1.Name = "txtAdd1"
        Me.txtAdd1.Size = New System.Drawing.Size(272, 20)
        Me.txtAdd1.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 40)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Address Line 2"
        '
        'txtAdd2
        '
        Me.txtAdd2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAdd2.Location = New System.Drawing.Point(93, 37)
        Me.txtAdd2.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAdd2.Name = "txtAdd2"
        Me.txtAdd2.Size = New System.Drawing.Size(272, 20)
        Me.txtAdd2.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 66)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Town*"
        '
        'txtTown
        '
        Me.txtTown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTown.Location = New System.Drawing.Point(93, 63)
        Me.txtTown.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTown.Name = "txtTown"
        Me.txtTown.Size = New System.Drawing.Size(272, 20)
        Me.txtTown.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(49, 91)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "County*"
        '
        'ep
        '
        Me.ep.ContainerControl = Me
        '
        'ctrlProperty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cstmCounty)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAdd1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAdd2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTown)
        Me.Controls.Add(Me.Label4)
        Me.Name = "ctrlProperty"
        Me.Size = New System.Drawing.Size(400, 125)
        CType(Me.ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cstmCounty As WindowsApplication1.crtlCounty
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAdd1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAdd2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTown As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ep As System.Windows.Forms.ErrorProvider

End Class
