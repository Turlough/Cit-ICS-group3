Imports System.Data.SqlClient

Public Class frmAddCustomer
    Dim cust As New Customer
    Dim v As New Validator


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        With CtrlCustomer1
            If .validateForm() Then
                cust.createCustomer(.txtFname.Text, .txtSname.Text, .txtAddress.Text, .txtPhone.Text, .txtEmail.Text)
                Me.Close()
            Else
                MsgBox("Invalid entry. Please review")
            End If
        End With
    End Sub

End Class