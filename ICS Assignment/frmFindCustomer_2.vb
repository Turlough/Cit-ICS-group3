Imports System.Data.SqlClient
Public Class frmFindCustomer
    ' Dim sqCon As New SqlClient.SqlConnection("Server=.\SQLExpress;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\MyTestDB.mdf;Database=MyTestDB; Trusted_Connection=Yes;")
    'Dim sqCon As New SqlClient.SqlConnection("Server=SQLNCLI10.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MyTestDB;Data Source=(local);")
    Dim sqCon As New SqlClient.SqlConnection(My.Settings.dbConnectorString)
    Dim sqCmd As New SqlClient.SqlCommand
    Private custid As Integer
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadData()

        'set the default value to "first name"
        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0    ' The first item has index 0 '
        End If
        Button1.Visible = False
        Button2.Visible = False


    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        loadData()

    End Sub
    Private Sub loadData()


        'define the DB connection and search string
        sqCmd.Connection = sqCon
        Dim col As String = "fName"

        Select Case ComboBox1.Text
            Case "First Name"
                col = "fName"
            Case "Second Name"
                col = "lName"
            Case "Email"
                col = "email"
            Case "Phone"
                col = "phone"
            Case "Address"
                col = "address"
        End Select
        Dim s As String = TextBox3.Text

        sqCmd.CommandText = "SELECT * FROM Customer WHERE " & col & " LIKE '" & s & "%' "
        sqCon.Open()                        'open the DB connection

        Dim TA As New SqlDataAdapter(sqCmd)
        Dim DT As New DataTable
        TA.Fill(DT)

        With DataGridView1
            .DataSource = DT
            .Columns(0).Visible = False
        End With

        sqCon.Close()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        With DataGridView1
            Dim r As Integer = e.RowIndex

            .Rows(r).Selected = True    ' select the entire row
            custid = .Rows(r).Cells(0).Value ' get the customer ID (PK)

        End With

        Button1.Visible = True
        Button2.Visible = True

    End Sub
    Sub ReturnCustomerID()
        Form1.custid = Me.custid
        'MsgBox("form2 says " & Form1.custid)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button4.Click, Button2.Click
        ReturnCustomerID()
        Me.Close()

    End Sub
End Class