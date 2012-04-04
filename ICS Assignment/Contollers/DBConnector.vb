Imports System.Data.SqlClient

''' <summary>
''' This is the superclass for Customer, Property, and Appointment.
''' It hosts protected generic methods for its subclasses.
''' It also maintains static state variables, while the application is running.
''' These relate the subclasses by id, typically.
''' </summary>
''' <remarks>CustProp does not use ID</remarks>
Public Class DBConnector
    Dim sqCon As New SqlClient.SqlConnection(My.Settings.dbConnectorString)
    Dim sqCmd As New SqlClient.SqlCommand

    Public Shared custid As Integer = 0
    Public Shared propid As Integer = 0
    Public Shared appointmentid As Integer = 0
    Public Shared relationType As String = "Owner"
    Public Shared agent As String = "Jamie"

    Protected SQL As String = ""

    Sub New()
        sqCmd.Connection = sqCon
    End Sub

    ''' <summary>
    ''' Provide it with a 'select' SQL string, and it will return a datatable.
    ''' The datatable can be hooked to form controls
    ''' </summary>
    ''' <param name="SQL">A select statement</param>
    ''' <returns>A DataTable of returned rows</returns>
    ''' <remarks></remarks>
    Protected Function getData(SQL As String) As DataTable
        sqCmd.CommandText = SQL
        Return getData(sqCmd)
    End Function

    ''' <summary>
    ''' Provide it with a 'select' SqlCommand, and it will return a datatable.
    ''' The datatable can be hooked to form controls
    ''' </summary>
    ''' <param name="cmd">A preprepared SqlCommand</param>
    ''' <returns>A DataTable of returned rows.</returns>
    ''' <remarks></remarks>
    Protected Function getData(cmd As SqlCommand) As DataTable
        Dim TA As New SqlDataAdapter(cmd)
        Dim DT As New DataTable
        sqCon.Open()
        TA.Fill(DT)
        sqCon.Close()
        Return DT

    End Function

    ''' <summary>
    ''' Provide it with an 'insert' statement, and it will return the ID of the inserted row
    ''' </summary>
    ''' <param name="SQL">An insert statement</param>
    ''' <returns>The ID of the inserted record</returns>
    ''' <remarks></remarks>
    Protected Function insert(SQL As String) As Integer
        'auto append return value
        Dim rtrn As String = ";SELECT SCOPE_IDENTITY()"
        If Not InStr(SQL, rtrn) Then
            SQL = SQL & rtrn
        End If
        'execute
        Dim ID As Integer
        sqCmd.Connection = sqCon            'create the DB connection
        sqCmd.CommandText = SQL
        sqCon.Open()                        'open the connection
        ID = sqCmd.ExecuteScalar()        'execute the SQL command
        sqCon.Close()                       'close the connection
        Return ID
    End Function

    Protected Sub quickInsert(SQL As String)
        Dim ID As Integer
        sqCmd.Connection = sqCon            'create the DB connection
        sqCmd.CommandText = SQL
        sqCon.Open()                        'open the connection
        ID = sqCmd.ExecuteNonQuery()        'execute the SQL command
        sqCon.Close()                       'close the connection
    End Sub
    Protected Sub update(SQL As String)
        sqCmd.Connection = sqCon            'create the DB connection
        sqCmd.CommandText = sql
        sqCon.Open()                        'open the connection
        sqCmd.ExecuteNonQuery()        'execute the SQL command
        sqCon.Close()                       'close the connection
    End Sub
    Protected Sub update(cmd As SqlClient.SqlCommand)
        sqCmd.Connection = sqCon            'create the DB connection
        sqCon.Open()                        'open the connection
        sqCmd.ExecuteNonQuery()        'execute the SQL command
        sqCon.Close()                       'close the connection
    End Sub

End Class
