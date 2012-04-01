Public Class Properties
    Inherits DBConnector

    Public add1 As String
    Public add2 As String
    Public town As String
    Public county As String
    Public description As String
    Public numBeds As Integer
    Public floorArea As Integer
    Public status As String

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
            status = .Item(8).ToString
            'must check
            If Not IsDBNull(.Item(6)) Then
                numBeds = .Item(6)
            End If
            If Not IsDBNull(.Item(7)) Then
                floorArea = CInt(.Item(7).ToString)
            End If
        End With

        DT = Nothing
    End Sub
End Class
