Public Class Appointment
    Inherits DBConnector

    Public chosenDate As DateTime

    Public start As Integer = 0
    Public finish As Integer = 0
    Public duration As Integer = 0
    Public notes As String = ""

    Structure temp
        Public chosenDate As DateTime
        Public start As Integer
        Public finish As Integer
        Public duration As Integer
        Public notes As String
    End Structure

    Function showAppointments() As DataTable
        SQL = "Select * from appointment where chosendate = '" & Format(chosenDate, "yyyy-MM-dd") & "'"
        SQL &= " ORDER BY start ASC"
        'MsgBox(SQL)
        Return getData(SQL)
    End Function
    Sub create()
        SQL = "INSERT INTO [MyTestDB].[dbo].[Appointment]"
        SQL &= " (custid,propid,chosendate,start,finish,notes)"
        SQL &= " VALUES ("
        SQL &= custid
        SQL &= "," & propid
        SQL &= ",'" & Format(chosenDate, "yyyy-MM-dd") & "'"
        SQL &= "," & start
        SQL &= "," & finish
        SQL &= ",'" & notes & "'"
        SQL &= ")"

        'MsgBox(SQL)
        insert(SQL)
    End Sub
    Sub makeGrid(grid As DataGridView)

        grid.Rows.Clear()

        Dim DT As DataTable = showAppointments()
        'A Dictionary is a hashtable, which makes searching easier
        Dim app As New temp
        Dim dict As New Dictionary(Of Integer, temp)
        With DT
            For a As Integer = 0 To .Rows.Count - 1
                app.chosenDate = .Rows(a).Item(3)
                app.start = .Rows(a).Item(4)
                app.finish = .Rows(a).Item(5)
                app.duration = app.finish - app.start
                app.notes = .Rows(a).Item(6)

                If Not dict.ContainsKey(app.start) Then
                    dict.Add(app.start, app)
                End If

            Next (a)
        End With

        'fill the grid, using hashtable to identify which elements are filled
        Dim strt As Integer = 9
        Dim val As Integer = 9
        For a As Integer = 0 To 8
            With grid
                strt = a + val
                .Rows.Add()
                .Rows(a).Cells(0).Value = strt

                If dict.ContainsKey(strt) Then
                    .Rows(a).Cells(1).Value = dict(strt).finish
                    .Rows(a).Cells(2).Value = dict(strt).notes
                    val += dict(strt).duration - 1 'skip next hours for longer appointments
                End If
            End With
        Next


    End Sub


End Class
