Public Class CustProp
    Inherits DBConnector
    Public priceRel As Long

    Public Sub link(status As String)
        SQL = "INSERT INTO CustProp"
        SQL &= " (agent,status,customerid,propertyid,relationshiptype)"
        SQL &= " VALUES ("
        SQL &= "'" & wrap(agent) & "'"
        SQL &= ",'" & wrap(status) & "'"
        SQL &= "," & wrap(custid)
        SQL &= "," & propid
        SQL &= ",'" & wrap(relationType) & "')"

        quickInsert(SQL)
    End Sub

    Public Function getOffers() As DataTable
        SQL = "SELECT c.id, p.id, cp.price"
        SQL &= ", cp.relationshipType AS Type"
        SQL &= ", (c.fname + ' ' + c.lname) AS Buyer"
        SQL &= ", (p.add1 + ' ' + p.add2 + ' ' + p.town + ', Co. ' + p.county) AS Prop"
        SQL &= " FROM activecustomers c INNER JOIN custprop cp ON c.id=cp.customerid"
        SQL &= " INNER JOIN activeproperties p ON p.id=cp.propertyid"
        SQL &= " WHERE cp.relationshiptype = 'Offer Made'"
        SQL &= " ORDER BY cp.propertyid DESC, cp.customerid DESC"

        Return getData(SQL)
    End Function
    Public Sub setRelation(c As Integer, p As Integer, type As String)
        'update model
        relationType = type
        'store
        SQL = String.Format("IF EXISTS (SELECT 1 FROM custprop WHERE customerid= {0} AND propertyid= {1})", c, p)
        'if exists, update it
        SQL &= " UPDATE custprop SET"
        SQL &= String.Format(" relationshiptype = '{0}'", type)
        SQL &= String.Format(" WHERE customerid={0} AND propertyid={1}", c, p)
        'Otherwise, insert it
        SQL &= " ELSE"
        SQL &= " INSERT INTO custprop (customerid,propertyid,relationshiptype,status,agent)"
        SQL &= String.Format(" VALUES ({0},{1},'{2}', 'Active', '{3}')", c, p, type, wrap(agent))

        execute(SQL)
        'TODO- stored procedure instead
    End Sub
    Public Sub delete(propid As Integer, custid As Integer)
        SQL = String.Format("DELETE FROM custprop WHERE customerid = {0} AND propertyid = {1}", custid, propid)
        execute(SQL)
    End Sub
    'removes all related customers except the owner from custprop
    Public Sub clearHistory(propid As Integer)
        SQL = String.Format("DELETE FROM custprop WHERE propertyid = {0} AND NOT relationshiptype = 'Owner'", propid)
        execute(SQL)
    End Sub
End Class
