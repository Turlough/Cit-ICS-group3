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
        SQL = "SELECT * FROM ActiveCustomers WHERE " & col & " LIKE '%" & wrap(value) & "%' "
        Return getData(SQL)
    End Function
    ReadOnly Property fullName() As String
        Get
            Return fname & " " & sname
        End Get
    End Property

    Overloads Sub insert(fname As String, sname As String, address As String, phone As String, email As String)
        'initialise
        Me.fname = fname
        Me.sname = sname
        Me.address = address
        Me.phone = phone
        Me.email = email
        'insert
        insert()

    End Sub
    Overloads Sub insert()
        SQL = "INSERT INTO customer"
        SQL &= " (fname,lname,address,phone,email)"
        SQL &= " VALUES ("
        SQL &= "'" & wrap(fname) & "'"
        SQL &= ",'" & wrap(sname) & "'"
        SQL &= ",'" & wrap(address) & "'"
        SQL &= ",'" & wrap(phone) & "'"
        SQL &= ",'" & wrap(email) & "')"

        custid = insert(SQL)
    End Sub

    Sub load(id As Integer)
        If id = 0 Then clear()
        SQL = "SELECT * FROM Customer WHERE id =" & id
        Dim DT As DataTable = getData(SQL)
        If DT.Rows.Count = 1 Then
            With DT.Rows(0)
                custid = id
                fname = .Item(1)
                sname = .Item(2)
                email = .Item(3).ToString
                phone = .Item(4).ToString
                address = .Item(5).ToString
                status = .Item(6).ToString
            End With
        Else
            clear()
        End If

        DT = Nothing
    End Sub
    Sub delete(id As Integer)
        SQL = "EXEC sp_ArchiveCustomer " & id
        execute(SQL)
        clear()
    End Sub
    Overloads Sub update()
        SQL = "UPDATE customer SET "
        SQL &= String.Format(" fname = '{0}'", wrap(fname))
        SQL &= String.Format(", lname = '{0}'", wrap(sname))
        SQL &= String.Format(", email = '{0}'", wrap(email))
        SQL &= String.Format(", phone = '{0}'", wrap(phone))
        SQL &= String.Format(", address = '{0}'", wrap(address))
        SQL &= String.Format(", status = '{0}'", wrap(status))
        SQL &= " WHERE id=" & custid

        execute(SQL)

    End Sub
    Sub clear()
        custid = 0
        fname = ""
        sname = ""
        email = ""
        phone = ""
        address = ""
        status = ""
    End Sub
    Function forenames(fn As String) As DataTable
        SQL = "SELECT fname FROM customer WHERE fname LIKE '" & fn & "%'"
        Return getData(SQL)
    End Function
End Class
