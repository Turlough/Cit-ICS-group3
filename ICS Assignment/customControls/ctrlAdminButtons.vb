Public Class ctrlAdminButtons
    Inherits UserControl
    Public dSql As String
    Public eSql As String

    Public Event Save As EventHandler
    Public Event Edit As EventHandler
    Public Event Delete As EventHandler

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        'confirm
        If MsgBox("Confirm Delete", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Exit Sub
        RaiseEvent Delete(Me, New EventArgs)
    End Sub


    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If btnEdit.Text = "Edit" Then
            RaiseEvent Edit(Me, New EventArgs)
            btnEdit.Text = "Save"
        Else
            RaiseEvent Save(Me, New EventArgs)
            btnEdit.Text = "Edit"
        End If
    End Sub
End Class
