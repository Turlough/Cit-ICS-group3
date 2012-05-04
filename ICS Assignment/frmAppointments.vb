Imports System.Data.SqlClient

Public Class frmAppointments

    Dim app As New Appointment
    Dim cust As New Customer
    Dim prop As New Properties
    Dim ownerId As Integer
    Dim curId As Integer
    Dim cp As New CustProp
    Dim DT As New DataTable
    Private Sub frmCalendar_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        'setup form & controls
        setDefaults()
        app.chosenDate = Now()

        fillTimes()
        ctrlAdmin.Visible = False

    End Sub

    Sub setDefaults()
        'display cust and prop details
        curId = Customer.custid
        If Customer.custid > 0 Then
            cust.load(Customer.custid)
            txtName.Text = cust.fullName
        Else
            txtName.Text = ""
        End If

        If Properties.propid > 0 Then
            prop.load(Properties.propid)
            cust = prop.getRelatedCustomer("Owner")
            ownerId = Customer.custid
            'reset original customer

            txtPlace.Text = prop.fullAddress
            cust.load(curId)
        Else
            ownerId = 0
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
            s.Append(String.Format("Meet {0} at ", cust.fullName))
            s.AppendLine(prop.fullAddress)
            s.Append(String.Format("for {0}", rt))

            txtName.Text = cust.fullName
            txtPlace.Text = prop.fullAddress
            txtNotes.Text = s.ToString
        Else
            btnAdd.Enabled = False

        End If

    End Sub


    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        With DateTimePicker1
            app.chosenDate = .Value
        End With

        fillTimes()

    End Sub

    Private Sub Times_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Times.CellClick
        With Times.Rows(e.RowIndex)
            'evaluate edit or add mode (timeslot is active or inactive)
            If .Cells("finish").Value Is Nothing Then

                'show/hide buttons
                ctrlAdmin.Visible = False
                btnAdd.Visible = True
                'locate first selected row
                app.start = Times.SelectedRows(0).Cells("start").Value
                For Each r As DataGridViewRow In Times.SelectedRows
                    If r.Cells("start").Value < app.start Then
                        app.start = r.Cells("start").Value
                    End If
                Next
                'set variables
                Dim duration As Integer = Times.SelectedRows.Count
                app.finish = app.start + duration
                'display
                txtStart.Text = app.start & ":00"
                txtFinish.Text = app.finish & ":00"
            Else

                'display
                ctrlAdmin.Visible = True
                btnAdd.Visible = False
            End If
        End With
    End Sub

    Private Sub fillTimes()
        'Times.DataSource = app.showAppointments()
        app.makeGrid(Times)

        'Default time text boxes to first empty timeslot
        For Each r As DataGridViewRow In Times.Rows
            If r.Cells("finish").Value = 0 Then
                app.start = r.Cells("start").Value
                app.finish = r.Cells("start").Value + 1
                txtStart.Text = app.start & ":00"
                txtFinish.Text = app.finish & ":00"
                r.Selected = True
                Exit For
            Else
                r.Selected = False
            End If
        Next

    End Sub



    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        cp.setRelation(Customer.custid, Properties.propid, CustProp.relationType)
        app.notes = txtNotes.Text
        app.insert()

        fillTimes() 'refresh this datagrid
        frmHomeScreen.showDetails() 'refresh calendar on home screen
        Me.Close()

    End Sub

    Private Sub btnSearchCust_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchCust.Click
        frmFindCustomer.ShowDialog()
        curId = Customer.custid
        'establish relation
        If curId = ownerId And Not curId = 0 Then
            CustProp.relationType = "Owner"
        Else
            'set a default
            CustProp.relationType = "Prospective Buyer"
        End If
        setDefaults()
    End Sub

    Private Sub btnSearchProp_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchProp.Click
        frmFindProperties.ShowDialog()
        setDefaults()
    End Sub

    Private Sub ctrlAdmin_EnableEdit(sender As Object, e As System.EventArgs) Handles ctrlAdmin.Edit
        app.id = Times.SelectedRows(0).Cells("id").Value
        app.load(app.id)
        If app.id > 0 Then
            cust.load(Appointment.custid)
            prop.load(Appointment.propid)

            setDefaults()
            app.delete(app.id) 'delete so all fields can be edited
            fillTimes()
        Else
            MsgBox("Select the appointment to edit first")
        End If
    End Sub

    Private Sub ctrlAdmin_Deleted(sender As Object, e As System.EventArgs) Handles ctrlAdmin.Delete
        app.id = Times.SelectedRows(0).Cells("id").Value
        If app.id > 0 Then
            app.delete(app.id)
            fillTimes() 'refresh this datagrid
            frmHomeScreen.showDetails() 'refresh calendar on home screen
            setDefaults()
        Else
            MsgBox("You must select a non empty timeslot")
        End If
        ctrlAdmin.Visible = False
        btnAdd.Enabled = True

    End Sub


    Private Sub ctrlAdmin_Save(sender As Object, e As System.EventArgs) Handles ctrlAdmin.Save
        app.notes = txtNotes.Text
        app.insert()

        fillTimes() 'refresh this datagrid
        frmHomeScreen.showDetails() 'refresh calendar on home screen
    End Sub
End Class