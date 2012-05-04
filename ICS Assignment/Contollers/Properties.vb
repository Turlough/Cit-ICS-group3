﻿Public Class Properties
    Inherits DBConnector

    Public add1 As String
    Public add2 As String
    Public town As String
    Public county As String
    Public description As String = "Enter description here...."
    Public numBeds As Integer
    Public price As Long
    Public status As String

    Public photo As Image

    Overloads Sub insert(a1 As String, a2 As String, town As String, county As String)
        add1 = a1
        add2 = a2
        Me.town = town
        Me.county = county

        insert()
    End Sub
    Overloads Sub insert()
        SQL = "INSERT INTO property"
        SQL &= " (add1,add2,town,county,status)"
        SQL &= " VALUES ("
        SQL &= "'" & wrap(add1) & "'"
        SQL &= ",'" & wrap(add2) & "'"
        SQL &= ",'" & wrap(town) & "'"
        SQL &= ",'" & wrap(county) & "'"
        SQL &= ",'" & "Valuation Pending" & "')"

        propid = insert(SQL)
    End Sub

    Function findProp(value As String, col As String) As DataTable
        If col = "" Then col = "town"
        SQL = "SELECT * FROM property WHERE " & col & " LIKE '" & value & "%' "
        Return getData(SQL)
    End Function
    Function getRelatedCustomer(relType As String) As Customer
        SQL = "Select customer.id from "
        SQL &= " (customer inner join custprop on customer.id = custprop.customerid)"
        SQL &= " inner join property on custprop.propertyid=property.id"
        SQL &= " where custprop.propertyid = " & propid
        SQL &= " and custprop.relationshiptype='" & wrap(relType) & "'"

        Dim DT As DataTable = getData(SQL)
        With DT
            If .Rows.Count > 0 Then
                custid = .Rows(0).Item(0)
                Dim cust As New Customer
                cust.load(custid)
                Return cust
            Else
                custid = 0
                Return Nothing
            End If
        End With
    End Function
    ReadOnly Property fullAddress() As String
        Get
            If propid > 0 Then
                Dim s As String
                s = add1 & vbCrLf
                If Not add2.Length = 0 Then
                    s &= add2 & vbCrLf
                End If
                s &= town & vbCrLf
                s &= "Co. " & county
                Return s
            Else
                Return ""
            End If

        End Get
    End Property

    Sub load(id As Integer)
        propid = id
        SQL = "SELECT * FROM property WHERE id =" & id
        Dim DT As DataTable = getData(SQL)
        If DT.Rows.Count > 0 Then
            With DT.Rows(0)

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

            End With
        End If


        DT = Nothing
    End Sub

    Function findProperty(ByVal add As String, ByVal town As String, ByVal county As String, ByVal minbeds As Integer, ByVal maxbeds As Integer, ByVal minprice As Integer, ByVal maxprice As Integer, Status As String) As DataTable

        Dim s As String = " WHERE"
        SQL = "Select * FROM property"
        If add.Length > 0 Then
            SQL &= s & " (add1 LIKE '%" & wrap(add) & "%' OR add2 LIKE '%" & wrap(add) & "%')"
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
            SQL &= s & " UPPER(town) = '" & wrap(UCase(town)) & "'"
            s = " AND"
        End If
        If county.Length > 0 Then
            SQL &= s & " UPPER(county) = '" & wrap(UCase(county)) & "'"
            s = " AND"
        End If
        If Status.Length > 0 Then
            SQL &= s & " status = '" & wrap(Status) & "'"
            s = " AND"
        End If

        'MsgBox(SQL)
        Return getData(SQL)

    End Function
    Overloads Sub update()
        SQL = "UPDATE property SET"
        SQL &= " add1 = '" & wrap(add1) & "'"
        SQL &= ", add2 = '" & wrap(add2) & "'"
        SQL &= ", town = '" & wrap(town) & "'"
        SQL &= ", county = '" & wrap(county) & "'"
        SQL &= ", description = '" & wrap(description) & "'"
        SQL &= ", numbeds = " & numBeds
        SQL &= ", status = '" & wrap(status) & "'"
        SQL &= ", price = " & price
        'SQL &= ", photo = " & photo

        SQL &= " WHERE id = " & propid

        update(SQL)
    End Sub
    Function getCustomers() As DataTable
        SQL = "Select c.id,relationshiptype,fname,lname,cp.price from "
        SQL &= " (customer c inner join custprop cp on c.id = cp.customerid)"
        SQL &= " inner join property p on cp.propertyid=p.id"
        SQL &= " where cp.propertyid = " & propid

        Return getData(SQL)

    End Function
    ReadOnly Property imageSource As String
        Get
            Return "c:\Auctioneer\img\" & propid & ".jpg"
        End Get
    End Property
    Public Sub makeOffer(price As Integer)
        'TODO- stored procedure instead
        SQL = String.Format("IF EXISTS (SELECT 1 FROM custprop WHERE customerid= {0} AND propertyid= {1})", custid, propid)
        'if exists, update it
        SQL &= " UPDATE custprop SET"
        SQL &= " relationshiptype = 'Offer Made'"
        SQL &= String.Format(", price = {0}", price)
        SQL &= String.Format(" WHERE customerid={0} AND propertyid={1}", custid, propid)
        'Otherwise, insert it
        SQL &= " ELSE"
        SQL &= " INSERT INTO custprop (customerid,propertyid,relationshiptype,status,price,agent)"
        SQL &= String.Format(" VALUES ({0},{1},'Offer Made', 'Active', {2},'{3}')", custid, propid, price, wrap(agent))


        execute(SQL)
    End Sub
    Public Sub insertOffer(price As Integer)
        SQL = "Insert into custprop (customerid,propertyid,relationshiptype,status,price,agent) values ("
        SQL &= custid & ","
        SQL &= propid & ","
        SQL &= "'Offer Made',"
        SQL &= "'Active',"
        SQL &= price
        SQL &= ",'" & wrap(agent) & "')"

        quickInsert(SQL)
    End Sub
    Sub delete(id As Integer)
        SQL = "DELETE FROM custprop WHERE propertyid = " & id
        SQL &= ";DELETE FROM property WHERE id = " & id

        execute(SQL)
    End Sub
End Class
