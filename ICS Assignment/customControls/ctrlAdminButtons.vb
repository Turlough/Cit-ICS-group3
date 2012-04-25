Public Class ctrlAdminButtons

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        'confirm
        If MsgBox("Confirm Delete", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Exit Sub
        'delete

    End Sub


    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If btnDelete.Text = "Edit" Then

            btnDelete.Text = "Save"
        Else

            btnDelete.Text = "Edit"
        End If)
    End Sub
End Class
