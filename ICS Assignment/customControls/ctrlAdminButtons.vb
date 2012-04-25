Public Class ctrlAdminButtons
    Inherits UserControl
    Public dSql As String
    Public eSql As String

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        'confirm
        If MsgBox("Confirm Delete", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Exit Sub
        'delete
        Dim dbc As New DBConnector
        dbc.execute(dSql)
        dbc = Nothing
    End Sub


    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If btnEdit.Text = "Edit" Then

            btnEdit.Text = "Save"
        Else
            Dim dbc As New DBConnector
            dbc.execute(eSql)
            btnEdit.Text = "Edit"
            dbc = Nothing
        End If
    End Sub
End Class
