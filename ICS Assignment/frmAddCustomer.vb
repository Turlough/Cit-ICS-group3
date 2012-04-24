Imports System.Data.SqlClient

Public Class frmAddCustomer
    Dim cust As New Customer
    Dim v As New Validator


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If valid() Then
            cust.createCustomer(txtForename.Text, txtSurname.Text, txtAddress.Text, CInt(txtPhone.Text), txtEmail.Text)
            Me.Close()
        Else
            MsgBox("Invalid entry. Please review")
        End If

    End Sub
    Function valid() As Boolean
        Dim b As Boolean = True
        If Not v.isName(txtForename.Text) Then b = False
        If Not v.isName(txtSurname.Text) Then b = False
        If Not v.phone(txtPhone.Text) Then b = False
        If Not v.email(txtEmail.Text) Then b = False

        If b Then btnSave.Enabled = True Else btnSave.Enabled = False

        Return b
    End Function
    Private Sub txtForename_Validated(sender As Object, e As System.EventArgs) Handles txtForename.Validated

    End Sub

    Private Sub txtForename_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtForename.Validating

    End Sub
    Private Sub txtSurname_Validated(sender As Object, e As System.EventArgs) Handles txtSurname.Validated

    End Sub

    Private Sub txtSurname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtSurname.Validating

    End Sub
    Private Sub txtPhone_Validated(sender As Object, e As System.EventArgs) Handles txtPhone.Validated

    End Sub


    Private Sub txtPhone_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPhone.Validating

    End Sub


    Private Sub txtEmail_Validated(sender As Object, e As System.EventArgs) Handles txtEmail.Validated

    End Sub

    Private Sub txtEmail_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtEmail.Validating

    End Sub

End Class