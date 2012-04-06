Public Class CustProp
    Inherits DBConnector

    Public Sub link(status As String)
        SQL = "INSERT INTO [MyTestDB].[dbo].[CustProp]"
        SQL &= " (agent,status,customerid,propertyid,relationshiptype)"
        SQL &= " VALUES ("
        SQL &= "'" & agent & "'"
        SQL &= ",'" & status & "'"
        SQL &= "," & custid
        SQL &= "," & propid
        SQL &= ",'" & relationType & "')"

        quickInsert(SQL)
    End Sub

End Class
