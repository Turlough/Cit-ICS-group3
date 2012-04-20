Imports System.Data.SqlClient

Public Class frmAddCustomer
    Dim cust As New Customer


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If isValid() Then
            cust.createCustomer(txtForename.Text, txtSurname.Text, txtAddress.Text, CInt(txtPhone.Text), txtEmail.Text)
            Me.Close()
        End If
    End Sub
    Private Function isValid() As Boolean
        Dim b As Boolean = True
        Dim v As New Validator
        Dim msg As String = ""
        If v.empty(txtForename.Text) Then
            msg &= "Forename not entered" & vbCr
            b = False
        End If
        If v.empty(txtSurname.Text) Then
            msg &= "Surname not entered" & vbCr
            b = False
        End If
        Return (b)
    End Function



End Class