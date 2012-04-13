Public Class Customer
    Inherits DBConnector

    Public fname As String
    Public sname As String
    Public address As String
    Public phone As String
    Public email As String
    Public status As String


    Function findCustomer(value As String, col As String) As DataTable
        If col = "" Then col = "fname"
        SQL = "SELECT * FROM ActiveCustomers WHERE " & col & " LIKE '%" & value & "%' "
        Return getData(SQL)
    End Function
    ReadOnly Property fullName() As String
        Get
            Return fname & " " & sname
        End Get
    End Property

    Sub createCustomer(fname As String, sname As String, address As String, phone As String, email As String)
        'initialise
        Me.fname = fname
        Me.sname = sname
        Me.address = address
        Me.phone = phone
        Me.email = email
        'insert
        SQL = "INSERT INTO [MyTestDB].[dbo].[Customer]"
        SQL &= " (fname,lname,address,phone,email)"
        SQL &= " VALUES ("
        SQL &= "'" & fname & "'"
        SQL &= ",'" & sname & "'"
        SQL &= ",'" & address & "'"
        SQL &= ",'" & phone & "'"
        SQL &= ",'" & email & "')"

        custid = insert(SQL)
    End Sub

    Sub loadCustomer(id As Integer)
        SQL = "SELECT * FROM Customer WHERE id =" & id
        Dim DT As DataTable = getData(SQL)
        With DT.Rows(0)
            custid = id
            fname = .Item(1)
            sname = .Item(2)
            email = .Item(3)
            phone = .Item(4)
            address = .Item(5)
            status = .Item(6).ToString
        End With
        DT = Nothing
    End Sub
    Sub delete(id As Integer)
        SQL = "EXEC sp_ArchiveCustomer " & id
        update(SQL) 'TODO- dont use super.update. Tidy the command structure
    End Sub
End Class
