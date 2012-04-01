Imports System.Data.SqlClient

Public Class frmAddCustomer
    Dim cust As New Customer


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If (txtForename.Text = "" Or txtSurname.Text = "" Or txtAddress.Text = "") Then
            MsgBox("empty box")
            Exit Sub
        End If
        cust.createCustomer(txtForename.Text, txtSurname.Text, txtAddress.Text, CInt(txtPhone.Text), txtEmail.Text)
    End Sub
End Class