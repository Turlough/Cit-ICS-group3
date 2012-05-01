Public Class frmHomeScreen

    Dim schedule As New Appointment
    Dim cust As New Customer
    Dim prop As New Properties



    Public Sub showDetails()
        If Customer.custid > 0 Then
            cust.load(Customer.custid)
            lblCustomer.Text = cust.fullName
        End If
        If Properties.propid > 0 Then
            prop.load(Properties.propid)
            lblProperty.Text = prop.fullAddress
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
    Private Sub btnAddProperty_Click(sender As System.Object, e As System.EventArgs) Handles btnAddProperty.Click
        frmAddProperty.ShowDialog()
        showDetails()
    End Sub
    Private Sub btnManageAppointment_Click(sender As System.Object, e As System.EventArgs) Handles btnManageAppointment.Click
        frmAppointments.ShowDialog()
        showDetails()
    End Sub


    Private Sub btnSearchProperty_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchProperty.Click
        frmFindProperties.ShowDialog()
        showDetails()
    End Sub

    Private Sub btnMakeOffer_Click(sender As System.Object, e As System.EventArgs) Handles btnMakeOffer.Click
        frmMakeOffer.ShowDialog()
        showDetails()
    End Sub

    Private Sub btnAcceptOffer_Click(sender As System.Object, e As System.EventArgs) Handles btnAcceptOffer.Click
        frmAcceptOffer.ShowDialog()
        showDetails()

    End Sub

    Private Sub frmHomeScreen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dtpAppointments_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpAppointments.ValueChanged
        schedule.chosenDate = dtpAppointments.Value
        showDetails()
    End Sub

    '**************
    'TOOLSTRIP
    '*************
    Private Sub AddToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddToolStripMenuItem.Click
        frmAddCustomer.ShowDialog()
        showDetails()
    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        frmFindCustomer.ShowDialog()
        showDetails()
    End Sub
    Private Sub AddToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles AddToolStripMenuItem1.Click
        frmAddProperty.ShowDialog()
        showDetails()
    End Sub

    Private Sub SearchToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles SearchToolStripMenuItem1.Click
        frmFindProperties.ShowDialog()
        showDetails()
    End Sub

    Private Sub AddToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles AddToolStripMenuItem2.Click
        frmAppointments.ShowDialog()
        showDetails()
    End Sub

    Private Sub SearchToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles SearchToolStripMenuItem2.Click
        frmAppointments.ShowDialog()
        showDetails()
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HelpToolStripMenuItem.Click
        Process.Start("https://docs.google.com/document/d/1rN8nrWDhxz1RFoI5kSZLK7gVFcXZiNvR1XlKoLl79xg/edit")
    End Sub
End Class