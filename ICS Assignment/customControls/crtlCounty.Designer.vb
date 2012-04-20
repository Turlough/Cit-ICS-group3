<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class crtlCounty
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
        Me.cbxCounty = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cbxCounty
        '
        Me.cbxCounty.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxCounty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxCounty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxCounty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCounty.FormattingEnabled = True
        Me.cbxCounty.Items.AddRange(New Object() {"Antrim", "Armagh", "Carlow", "Cavan", "Clare", "Cork", "Derry", "Donegal", "Down", "Dublin", "Fermanagh", "Galway", "Kerry", "Kildare", "Kilkenny", "Laois", "Leitrim", "Limerick", "Longford", "Louth", "Mayo", "Meath", "Monaghan", "Offaly", "Roscommon", "Sligo", "Tipperary", "Tyrone", "Waterford", "Westmeath", "Wexford", "Wicklow"})
        Me.cbxCounty.Location = New System.Drawing.Point(3, 3)
        Me.cbxCounty.Name = "cbxCounty"
        Me.cbxCounty.Size = New System.Drawing.Size(165, 21)
        Me.cbxCounty.Sorted = True
        Me.cbxCounty.TabIndex = 0
        '
        'crtlCounty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cbxCounty)
        Me.Name = "crtlCounty"
        Me.Size = New System.Drawing.Size(168, 26)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbxCounty As System.Windows.Forms.ComboBox

End Class
