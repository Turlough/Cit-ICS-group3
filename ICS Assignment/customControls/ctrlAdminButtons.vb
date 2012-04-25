Public Class ctrlAdminButtons
    Inherits UserControl
    Public dSql As String
    Public eSql As String

    Public Event Saved As EventHandler
    Public Event EnableEdit As EventHandler
    Public Event Deleted As EventHandler

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        'confirm
        If MsgBox("Confirm Delete", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Exit Sub
        'delete
        Dim dbc As New DBConnector
        dbc.execute(dSql)
        dbc = Nothing

        RaiseEvent Deleted(Me, New EventArgs)
    End Sub


    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If btnEdit.Text = "Edit" Then

            btnEdit.Text = "Save"

            RaiseEvent EnableEdit(Me, New EventArgs)
        Else
            Dim dbc As New DBConnector
            dbc.execute(eSql)
            btnEdit.Text = "Edit"
            dbc = Nothing

            RaiseEvent Saved(Me, New EventArgs)
        End If
    End Sub
End Class
