Imports System.Data.SqlClient

Public Class frmAppointments

    Dim app As New Appointment
    Dim cust As New Customer
    Dim prop As New Properties
    Dim cp As New CustProp
    Dim DT As New DataTable


    Sub setDefaults()
        'display cust and prop details
        If Customer.custid > 0 Then
            cust.loadCustomer(Customer.custid)
            txtName.Text = cust.fullName
        Else
            txtName.Text = ""
        End If

        If Properties.propid > 0 Then
            prop.loadProperty(Properties.propid)
            txtPlace.Text = prop.fullAddress
        Else
            txtPlace.Text = ""
        End If

        If Customer.custid > 0 And Properties.propid > 0 Then
            'enable add appointment
            btnAdd.Enabled = True
            Times.Enabled = True

            'Build default appointment notes
            Dim rt As String, s As New System.Text.StringBuilder
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
            s.Append(String.Format("Meet {0} at", cust.fullName))
            s.AppendLine(prop.fullAddress)
            s.Append(String.Format("for {0}", rt))

            txtName.Text = cust.fullName
            txtPlace.Text = prop.fullAddress
            txtNotes.Text = s.ToString
        Else
            btnAdd.Enabled = False
            Times.Enabled = False
        End If

    End Sub
    Private Sub frmCalendar_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        setDefaults()
        app.chosenDate = Now()



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
                'TODO create edit and delete functions for appointments
                frmAppointmentOptions.ShowDialog()
            End If


        End With

    End Sub

    Private Sub fillTimes()
        'Times.DataSource = app.showAppointments()
        app.makeGrid(Times)

        'Default time text boxes to first empty timeslot
        For Each r As DataGridViewRow In Times.Rows
            If r.Cells(1).Value = 0 Then
                txtStart.Text = r.Cells(0).Value
                txtFinish.Text = CInt(r.Cells(0).Value + 1)
                r.Selected = True
                Exit For
            Else
                r.Selected = False
            End If
        Next

    End Sub



    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        app.notes = txtNotes.Text
        app.create()

        fillTimes() 'refresh this datagrid
        frmHomeScreen.showDetails() 'refresh calendar on home screen
        Me.Close()

    End Sub

    Private Sub btnSearchCust_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchCust.Click
        frmFindCustomer.ShowDialog()
        setDefaults()
    End Sub

    Private Sub btnSearchProp_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchProp.Click
        frmFindProperties.ShowDialog()
        setDefaults()
    End Sub
End Class