Imports System.Data.SqlClient

Public Class frmAddCustomer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ' Dim sqCon As New SqlClient.SqlConnection("Server=.\SQLExpress;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\MyTestDB.mdf;Database=MyTestDB; Trusted_Connection=Yes;")
        'Dim sqCon As New SqlClient.SqlConnection("Server=SQLNCLI10.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MyTestDB;Data Source=(local);")
        Dim sqCon As New SqlClient.SqlConnection(My.Settings.dbConnectorString)
        Dim sqCmd As New SqlClient.SqlCommand

        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox5.Text = "") Then
            MsgBox("empty box")
            Exit Sub
        End If


        sqCmd.Connection = sqCon            'create the DB connection
        sqCmd.CommandText = "INSERT INTO [MyTestDB].[dbo].[Customer] VALUES ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "')"
        sqCon.Open()                        'open the connection
        sqCmd.ExecuteNonQuery()             'execute the SQL command
        sqCon.Close()                       'close the connection
        Me.Hide()
        Form1.Show()


    End Sub
End Class