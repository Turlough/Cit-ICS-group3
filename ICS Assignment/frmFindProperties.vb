Imports System.Data.SqlClient

Public Class frmFindProperties

    Dim prop As New Properties
    Dim cust As New Customer

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'TODO: default to relationship type
        If cmbStatus.Items.Count > 0 Then
            cmbStatus.SelectedIndex = 0    ' The first item has index 0 '
        End If
        CtrlAdminButtons1.Visible = False
        btnCreateAppointment.Visible = False
        btnSetActive.Visible = True
        'Disable editing textboxes
        txtOwner.ReadOnly = True
        txtPrice.ReadOnly = True
        txtStatus.ReadOnly = True
        CtrlProperty1.disable()
        rtbDescription.ReadOnly = True

    End Sub

    Private Sub frmFindProperties_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        refreshPropertyList()
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        refreshPropertyList()
    End Sub

    Private Sub btnLocateProperty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocateProperty.Click
        refreshPropertyList()
    End Sub

    Sub refreshPropertyList()
        With dgvProperties
            .DataSource = prop.findProperty(txtAdd.Text, txtTown.Text, txtCounty.Text, minBeds.Value, maxBeds.Value, minPrice.Value, maxPrice.Value, cmbStatus.Text)
            .Columns(0).Visible = False
            .Columns(8).Visible = False
        End With
        'set default appointment type
        Select Case cmbStatus.Text
            Case "Valuation Pending"
                btnCreateAppointment.Text = "Create Valuation Appointment"
            Case "For Sale"
                btnCreateAppointment.Text = "Create Viewing Appointment"
            Case Else
                btnCreateAppointment.Text = "Create Appointment"
        End Select

    End Sub

    Private Sub dgvProperties_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProperties.CellClick
        With dgvProperties
            Dim r As Integer = e.RowIndex
            If r >= 0 Then
                .Rows(r).Selected = True    ' select the entire row
                Properties.propid = .Rows(r).Cells(0).Value ' get the property ID (PK)
                fillDetails()
                disableEdit()
            End If
        End With
        CtrlAdminButtons1.Visible = True
    End Sub
    Sub fillDetails()
        prop.loadProperty(Properties.propid)
        CtrlProperty1.loadProp(prop)
        cust = prop.getRelatedCustomer("Owner")
        With prop
            txtOwner.Text = cust.fullName
            rtbDescription.Text = .description
            txtStatus.Text = .status
            txtPrice.Text = .price
            With My.Computer.FileSystem

                If .FileExists(prop.imageSource) Then
                    pbxPhoto.Load(prop.imageSource)
                ElseIf .FileExists("c:/img/0.jpg") Then
                    pbxPhoto.Load("c:/img/0.jpg")
                Else
                    pbxPhoto.Image = Nothing
                End If
            End With

        End With
        btnSetActive.Visible = True
    End Sub

    Private Sub pbxPhoto_Click(sender As System.Object, e As System.EventArgs) Handles pbxPhoto.Click
        Dim d As New OpenFileDialog()
        Dim s As String
        d.InitialDirectory = My.Settings.sourceFolder

        d.ShowDialog()
        s = d.FileName

        'handle user cancels
        If s.Length > 0 Then
            pbxPhoto.Load(s)
            FileCopy(s, prop.imageSource)
            'remember last source location
            My.Settings.sourceFolder = My.Computer.FileSystem.GetParentPath(s)
        End If
    End Sub

    
    Sub enableEdit()
        CtrlProperty1.enable()
        btnCreateAppointment.Visible = True
        'Enable textboxes
        txtOwner.ReadOnly = False
        txtPrice.ReadOnly = False
        txtStatus.ReadOnly = False
        rtbDescription.ReadOnly = False

        CtrlProperty1.enable()
    End Sub
    Sub disableEdit()
        CtrlProperty1.disable()
        btnCreateAppointment.Visible = True
        'disable textboxes
        txtOwner.ReadOnly = True
        txtPrice.ReadOnly = True
        txtStatus.ReadOnly = True
        rtbDescription.ReadOnly = True

        CtrlProperty1.disable()
    End Sub

    Function nextStatus() As String
        Dim p As Integer = CLng(txtPrice.Text)
        Select Case cmbStatus.Text
            Case "Valuation Pending"
                If p > 0 Then
                    Return "For Sale"
                Else
                    Return "Valuation Pending"
                End If
            Case Else
                Return cmbStatus.Text
        End Select
    End Function

    Private Sub btnCreateAppointment_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateAppointment.Click

        Select Case cmbStatus.Text
            Case "Valuation Pending"
                'owner details already loaded, so show appointment form
                frmAppointments.Show()
            Case "For Sale"
                'add customer first - a prospective buyer or tenant
                frmAddCustomer.ShowDialog()
                cust.loadCustomer(Customer.custid)
                CustProp.relationType = "Prospective Buyer"
                Dim cp As New CustProp
                cp.link("Active")
                frmAppointments.Show()
            Case Else
                frmAppointments.Show()
        End Select
    End Sub

    Private Sub btnOthers_Click(sender As System.Object, e As System.EventArgs) Handles btnOthers.Click
        frmRelations.ShowDialog()
    End Sub

    Private Sub btnSetActivate_Click(sender As System.Object, e As System.EventArgs) Handles btnSetActive.Click
        Me.Close()
    End Sub

    Private Sub CtrlAdminButtons1_Delete(sender As Object, e As System.EventArgs) Handles CtrlAdminButtons1.Delete
        If Properties.propid > 0 Then
            prop.delete(Properties.propid)
            prop.loadProperty(0)
            CtrlProperty1.loadProp(prop)
            CtrlAdminButtons1.Visible = False
        Else
            MsgBox("Select a property before deleting it!")
        End If
    End Sub

    Private Sub CtrlAdminButtons1_Edit(sender As Object, e As System.EventArgs) Handles CtrlAdminButtons1.Edit
        enableEdit()
    End Sub

    Private Sub CtrlAdminButtons1_Save(sender As Object, e As System.EventArgs) Handles CtrlAdminButtons1.Save
        With prop
            .add1 = CtrlProperty1.txtAdd1.Text
            .add2 = CtrlProperty1.txtAdd2.Text
            .town = CtrlProperty1.txtTown.Text
            .county = CtrlProperty1.cstmCounty.Text
            .description = rtbDescription.Text
            .status = nextStatus()
            .price = CLng(txtPrice.Text)
            .photo = pbxPhoto.Image

            'update DB
            .updateProperty()

        End With
        'hide show buttons
        disableEdit()

        'refresh table and details
        refreshPropertyList()
        fillDetails()
    End Sub
End Class