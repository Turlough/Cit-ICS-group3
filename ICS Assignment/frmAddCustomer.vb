Imports System.Data.SqlClient

Public Class frmAddCustomer
    Dim cust As New Customer


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        cust.createCustomer(txtForename.Text, txtSurname.Text, txtAddress.Text, CInt(txtPhone.Text), txtEmail.Text)
        Me.Close()

    End Sub


End Class