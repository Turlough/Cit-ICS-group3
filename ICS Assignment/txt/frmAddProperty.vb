Imports System.Data.SqlClient

Public Class frmAddProperty

    Dim img As String
    Public id As Integer
    Dim controller As Properties


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        controller.CreateProperty(txtAdd1.Text, txtAdd2.Text, txtTown.Text, txtCounty.Text, txtDescription.Text, 1, "For Sale")

        frmHomeScreen.Show()
        'NewPropertyScreen.Show()

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim d As FileDialog = OpenFileDialog1

        d.ShowDialog()
        img = d.FileName
        MsgBox(img)

    End Sub
End Class