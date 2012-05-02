Imports System.Data.SqlClient

Public Class frmAddCustomer
    Dim cust As New Customer
    Dim v As New Validator



    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        With CtrlCustomer1
            If .validateForm() Then
                cust.insert(.txtFname.Text, .txtSname.Text, .txtAddress.Text, .txtPhone.Text, .txtEmail.Text)
                clear()
                Me.Close()
            Else
                MsgBox("Invalid entry. Please review")
            End If
        End With
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        frmFindCustomer.ShowDialog()
        clear()
        Me.Close()
    End Sub
    Sub clear()
        ' ensure clear
        With CtrlCustomer1
            .txtFname.Text = ""
            .txtSname.Text = ""
            .txtAddress.Text = ""
            .txtPhone.Text = ""
            .txtEmail.Text = ""
        End With
    End Sub
End Class