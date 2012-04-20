Public Class ctrlFname
    Dim cust As New Customer
    Public Property fname As String
        Set(value As String)
            cbx.Text = value
        End Set
        Get
            Return cbx.Text
        End Get
    End Property

    Private Sub cbx_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbx.KeyPress
        cbx.Items.Clear()
        If fname.Length > 2 Then
            Dim dt As DataTable = cust.forenames(fname)
            For Each r As DataRow In dt.Rows
                cbx.Items.Add(r.Item(0))
            Next
        End If


    End Sub


End Class
