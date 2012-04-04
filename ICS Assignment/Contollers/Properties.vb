Public Class Properties
    Inherits DBConnector

    Public add1 As String
    Public add2 As String
    Public town As String
    Public county As String
    Public description As String
    Public numBeds As Integer
    Public price As Integer
    Public status As String
    Public imageSource As String
    Public photo As Image

    Sub CreateProperty(a1 As String, a2 As String, town As String, county As String)

        add1 = a1
        add2 = a2
        Me.town = town
        Me.county = county

        SQL = "INSERT INTO [MyTestDB].[dbo].[Property]"
        SQL &= " (add1,add2,town,county)"
        SQL &= " VALUES ("
        SQL &= "'" & a1 & "'"
        SQL &= ",'" & a2 & "'"
        SQL &= ",'" & town & "'"
        SQL &= ",'" & county & "')"

        propid = insert(SQL)
    End Sub

    Function findProp(value As String, col As String) As DataTable
        If col = "" Then col = "town"
        SQL = "SELECT * FROM property WHERE " & col & " LIKE '" & value & "%' "
        Return getData(SQL)
    End Function

    Sub loadProperty(id As Integer)
        SQL = "SELECT * FROM property WHERE id =" & id
        Dim DT As DataTable = getData(SQL)

        With DT.Rows(0)
            propid = id
            add1 = .Item(1)
            add2 = .Item(2)
            town = .Item(3)
            county = .Item(4)
            'toString converts dbNull to ""
            description = .Item(5).ToString
            status = .Item(7).ToString
            'must check
            If Not IsDBNull(.Item(6)) Then
                numBeds = .Item(6)
            Else
                numBeds = 0
            End If

            If Not IsDBNull(.Item(9)) Then
                price = .Item(9)
            Else
                price = 0
            End If
            'get photo from blob
            photo = getPhoto()
        End With

        DT = Nothing
    End Sub
    Function findProperty(ByVal add As String, ByVal town As String, ByVal county As String, ByVal minbeds As Integer, ByVal maxbeds As Integer, ByVal minprice As Integer, ByVal maxprice As Integer, Status As String) As DataTable

        Dim s As String = " WHERE"
        SQL = "Select * FROM property"
        If add.Length > 0 Then
            SQL &= s & " (add1 LIKE '%" & add & "%' OR add2 LIKE '%" & add & "%')"
            s = " AND"
        End If
        If minbeds > 0 Or maxbeds > 0 Then
            SQL &= s & " numbeds BETWEEN " & minbeds & " AND " & maxbeds
            s = " AND"
        End If
        If maxprice > 0 Then
            SQL &= s & " price BETWEEN " & minprice & " AND " & maxprice
            s = " AND"
        End If
        If town.Length > 0 Then
            SQL &= s & " UPPER(town) = '" & UCase(town) & "'"
            s = " AND"
        End If
        If county.Length > 0 Then
            SQL &= s & " UPPER(county) = '" & UCase(county) & "'"
            s = " AND"
        End If
        If Status.Length > 0 Then
            SQL &= s & " status = '" & Status & "'"
            s = " AND"
        End If

        'MsgBox(SQL)
        Return getData(SQL)

    End Function
    Sub updateProperty()
        SQL = "UPDATE property SET"
        SQL &= " add1 = '" & add1 & "'"
        SQL &= ", add2 = '" & add2 & "'"
        SQL &= ", town = '" & town & "'"
        SQL &= ", county = '" & county & "'"
        SQL &= ", description = '" & description & "'"
        SQL &= ", numbeds = " & numBeds
        SQL &= ", status = '" & status & "'"
        SQL &= ", price = " & price
        'SQL &= ", photo = " & photo

        SQL &= " WHERE id = " & propid

        update(SQL)
    End Sub
    Sub setPhoto(img As Image)
        SQL = "UPDATE property SET photo = @Img WHERE id = " & propid
        Using cmd As New System.Data.SqlClient.SqlCommand(SQL)
            Dim par As New SqlClient.SqlParameter("@Img", SqlDbType.Image)
            par.Value = img
            cmd.Parameters.Add(par)
            update(cmd)
        End Using
    End Sub
    Function getPhoto() As Image
        SQL = "SELECT photo FROM property WHERE id = " & propid
        Dim dt As DataTable = getData(SQL)


        Dim img As Image = Nothing
        Try
            Dim b As Byte() = CType(dt.Rows(0).Item(0), Byte())
            Using ms As New IO.MemoryStream(b)
                img = Image.FromStream(ms)
            End Using
            dt = Nothing
        Catch ex As Exception
            Return Nothing
        End Try

        Return img
    End Function
End Class
