Public Class crtlCounty
    Inherits UserControl
    Public Property County As String
        Get
            Return cbxCounty.Text
        End Get
        Set(value As String)
            Dim i As Integer = cbxCounty.FindStringExact(value)
            If Not i < 0 Then cbxCounty.SelectedIndex = i
        End Set
    End Property
    Public ReadOnly Property isValid As Boolean
        Get
            If County = "" Then Return False
            Return cbxCounty.FindStringExact(County) >= 0
        End Get
    End Property
   

End Class
