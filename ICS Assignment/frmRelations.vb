Public Class frmRelations
    Dim cust As New Customer
    Dim prop As New Properties

    Private Sub frmRelations_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        prop.load(Properties.propid)
        txtAddress.Text = prop.fullAddress
        dgvCustomers.DataSource = prop.getCustomers
        dgvCustomers.Columns(0).Visible = False
    End Sub


End Class