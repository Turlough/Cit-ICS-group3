Imports System.Data.SqlClient

Public Class frmCalendar

    Dim app As New Appointment
    Dim DT As New DataTable

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()



    End Sub
    Private Sub frmCalendar_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        app.chosenDate = Now()
        cbDuration.SelectedIndex = 0
        txtNotes.Text = "Add notes here"
        txtStart.Text = "14"
        fillTimes()

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        With DateTimePicker1
            app.chosenDate = .Value
        End With
        fillTimes()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Times.CellContentClick
        'MsgBox(e.RowIndex + 9)
        Dim duration As Integer = CInt(cbDuration.Text)
        app.start = e.RowIndex + 9
        app.finish = app.start + duration
        For a As Integer = 0 To duration
            Times.Rows(e.RowIndex + 1).Selected = True
        Next

    End Sub

    Private Sub fillTimes()


        'app.makeGrid(Times)
        'Times.DataSource = app.showAppointments()

        With Times
            '.Columns.Add("id", "ID")
            '.Columns.Add("custid", "Customer")
            '.Columns.Add("propid", "Property")
            '.Columns.Add("chosenDate", "Date")
            '.Columns.Add("start", "Start")
            '.Columns.Add("finish", "Finish")
            '.Columns.Add("notes", "notes")

            '.Columns(1).Visible = False
            '.Columns(2).Visible = False
            '.Columns(3).Visible = False


        End With

    End Sub



    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Dim strt As Integer = CInt(txtStart.Text)
        app.start = strt
        app.finish = strt + 1
        app.notes = txtNotes.Text
        app.create()
        fillTimes()

    End Sub

End Class