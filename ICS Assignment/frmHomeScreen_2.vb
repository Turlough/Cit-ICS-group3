Public Class frmHomeScreen

    Dim schedule As New Appointment

    Private Sub btnAddProperty_Click(sender As System.Object, e As System.EventArgs) Handles btnAddProperty.Click
        frmAddProperty.Show()

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

    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddToolStripMenuItem.Click
        frmAddCustomer.Show()

    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        frmFindCustomer.Show()

    End Sub
End Class