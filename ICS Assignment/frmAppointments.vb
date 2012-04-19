Imports System.Data.SqlClient

Public Class frmAppointments

    Dim app As New Appointment
    Dim cust As New Customer
    Dim prop As New Properties
    Dim cp As New CustProp
    Dim DT As New DataTable

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        setDefaults()

    End Sub
    Sub setDefaults()
        Try
            cust.loadCustomer(Customer.custid)
            prop.loadProperty(Properties.propid)

            Dim n As String, p As String, rt As String, s As New System.Text.StringBuilder

            n = cust.fname & " " & cust.sname
            p = prop.add1 & ", "
            If Not prop.add2 = "" Then
                p &= prop.add2 & ", "
            End If
            p &= prop.town & vbCr

            Select Case CustProp.relationType
                Case "Owner"
                    rt = "Valuation"
                Case "Prospective Buyer"
                    rt = "Viewing"
                Case "Prospective Tenant"
                    rt = "Viewing"
                Case Else
                    rt = "Meeting"
            End Select

            s.AppendLine(UCase(rt))
            s.Append("Meet " & n)
            s.Append(" at ")
            s.AppendLine(p)
            s.Append("for " & rt)

            txtName.Text = n
            txtPlace.Text = p
            txtNotes.Text = s.ToString
        Catch ex As Exception
            MsgBox("Cust or Prop not set")
        End Try

    End Sub
    Private Sub frmCalendar_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        app.chosenDate = Now()

        txtStart.Text = "14"
        fillTimes()

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        With DateTimePicker1
            app.chosenDate = .Value
        End With

        fillTimes()

    End Sub

    Private Sub Times_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Times.CellClick

        'TODO ensure contiguous selection

        'Toggling selection
        With Times.Rows(e.RowIndex)
            If .Cells(1).Value Is Nothing Then

                'set variables
                app.start = Times.SelectedRows(0).Cells(0).Value
                For Each r As DataGridViewRow In Times.SelectedRows
                    If r.Cells(0).Value < app.start Then
                        app.start = r.Cells(0).Value
                    End If
                Next
                Dim duration As Integer = Times.SelectedRows.Count
                app.finish = app.start + duration
                'display
                txtStart.Text = app.start & ":00"
                txtFinish.Text = app.finish & ":00"
            Else
                'TODO offer update/cancel
                MsgBox("This time is booked")
            End If


        End With

    End Sub

    Private Sub fillTimes()
        'Times.DataSource = app.showAppointments()
        app.makeGrid(Times)

    End Sub



    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click


        app.notes = txtNotes.Text
        app.create()

        fillTimes() 'refresh this datagrid
        frmHomeScreen.showDetails() 'refresh calendar on home screen
        frmHomeScreen.Show()
        Me.Close()

    End Sub

End Class