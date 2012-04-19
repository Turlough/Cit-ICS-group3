Public Class CustProp
    Inherits DBConnector
    Public priceRel As Long

    Public Sub link(status As String)
        SQL = "INSERT INTO CustProp"
        SQL &= " (agent,status,customerid,propertyid,relationshiptype)"
        SQL &= " VALUES ("
        SQL &= "'" & agent & "'"
        SQL &= ",'" & status & "'"
        SQL &= "," & custid
        SQL &= "," & propid
        SQL &= ",'" & relationType & "')"

        quickInsert(SQL)
    End Sub
    Public Function getOffers() As DataTable
        SQL = "SELECT c.id, p.id, cp.price"
        SQL &= ", cp.relationshipType AS Type"
        SQL &= ", (c.fname + ' ' + c.lname) AS Buyer"
        SQL &= ", (p.add1 + ' ' + p.add2 + ' ' + p.town + ' ' + p.county) AS Prop"
        SQL &= " FROM activecustomers c INNER JOIN custprop cp ON c.id=cp.customerid"
        SQL &= " INNER JOIN activeproperties p ON p.id=cp.propertyid"
        SQL &= " WHERE cp.relationshiptype <> 'Owner'"
        SQL &= " ORDER BY cp.propertyid DESC, cp.customerid DESC"

        Return getData(SQL)
    End Function
    Public Sub setRelation(c As Integer, p As Integer, type As String)
        SQL = "UPDATE custprop SET relationshiptype ='" & type & "'"
        SQL &= " WHERE customerid= " & c
        SQL &= " AND propertyid = " & p

        quickInsert(SQL)
    End Sub

End Class
