Public Class frmHomeScreen

    Dim schedule As New Appointment
    Dim cust As New Customer
    Dim prop As New Properties

    Private Sub btnAddProperty_Click(sender As System.Object, e As System.EventArgs) Handles btnAddProperty.Click
        frmAddProperty.Show()
        ' Me.Hide()
    End Sub

    Public Sub showDetails()
        Dim S As String
        If Customer.custid > 0 Then
            cust.loadCustomer(Customer.custid)

            S = cust.fname & cust.sname & vbCr
            S &= cust.address & vbCr & vbCr
            S &= cust.phone & vbCr
            S &= cust.email & vbCr

            lblCustomer.Text = S
        End If
        If Properties.propid > 0 Then
            prop.loadProperty(Properties.propid)

            S = prop.add1 & vbCr
            S &= prop.add2 & vbCr
            S &= prop.town & vbCr
            S &= prop.county & vbCr

            lblProperty.Text = S
        End If

        dgvSchedule.DataSource = schedule.showAppointments()
    End Sub

    Private Sub HomeScreen_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        schedule.chosenDate = Now
        With dgvSchedule

            .DataSource = schedule.showAppointments()

            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(2).Visible = False
            .Columns(3).Width = 150
            .Columns(4).Width = 50
            .Columns(5).Width = 50
            .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        End With

    End Sub

    Private Sub btnCreateAppointment_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateAppointment.Click
        frmAppointments.Show()
        'Me.Hide()
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddToolStripMenuItem.Click
        frmAddCustomer.Show()
    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        frmFindCustomer.Show()
    End Sub
End Class