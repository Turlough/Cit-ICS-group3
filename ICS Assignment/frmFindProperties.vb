Imports System.Data.SqlClient

Public Class frmFindProperties

    Dim prop As New Properties
    Dim cust As New Customer

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'TODO: default to relationship type
        If cmbStatus.Items.Count > 0 Then
            cmbStatus.SelectedIndex = 0    ' The first item has index 0 
        End If
        disableEdit()
        btnSetActive.Enabled = False
        CtrlAdminButtons1.Visible = False
        btnCreateAppointment.Enabled = False
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

        prop.load(Properties.propid)
        CtrlProperty1.loadProp(prop)
        'get the owner's name quickly, then reset original customer
        If Properties.propid > 0 Then
            Dim cid As Integer = Customer.custid
            Dim name As String = prop.getRelatedCustomer("Owner").fullName
            'reset original customer 
            cust.load(cid)
            txtOwner.Text = name
        Else
            txtOwner.Text = ""
            disableEdit()
        End If


        'display property details
        With prop

            rtbDescription.Text = .description
            ctrlPropStat.cbxStatus.Text = .status
            txtPrice.Text = .price
            CtrlProperty1.cstmCounty.cbxCounty.Text = .county
            'locate photograph, if any
            With My.Computer.FileSystem

                If .FileExists(prop.imageSource) Then
                    pbxPhoto.Load(prop.imageSource)
                ElseIf .FileExists("c:/Auctioneer/img/0.jpg") Then
                    pbxPhoto.Load("c:/Auctioneer/img/0.jpg")
                Else
                    pbxPhoto.Image = Nothing
                End If
            End With

        End With
        btnSetActive.Enabled = True
        btnCreateAppointment.Enabled = True
    End Sub

    Private Sub pbxPhoto_Click(sender As System.Object, e As System.EventArgs) Handles pbxPhoto.Click
        'only if there is an active property
        If Properties.propid = 0 Then Exit Sub

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
        'Enable textboxes
        txtPrice.ReadOnly = False
        ctrlPropStat.Enabled = True
        rtbDescription.ReadOnly = False
        pbxPhoto.Enabled = True
        rtbDescription.Enabled = True

    End Sub
    Sub disableEdit()
        CtrlProperty1.disable()


        'disable textboxes
        txtPrice.ReadOnly = True
        ctrlPropStat.Enabled = False
        rtbDescription.ReadOnly = True
        pbxPhoto.Enabled = False
        rtbDescription.Enabled = False

    End Sub

    Sub nextStatus()
        Dim p As Long = CLng(txtPrice.Text)
        Select Case cmbStatus.Text
            Case "Valuation Pending"
                If p > 0 Then
                    ctrlPropStat.cbxStatus.Text = "For Sale"
                Else
                    ctrlPropStat.cbxStatus.Text = "Valuation Pending"
                End If
            Case Else

        End Select
    End Sub

    Private Sub btnCreateAppointment_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateAppointment.Click

        Select Case cmbStatus.Text
            Case "Valuation Pending"
                'owner details already loaded, so show appointment form
                frmAppointments.Show()
            Case "Documentation Pending"
            Case "Off Market"

            Case "For Sale"
                selectAndLink("Prospective Buyer")
                frmAppointments.ShowDialog()
            Case "For Rent"
                selectAndLink("Prospective Tenant")
                frmAppointments.ShowDialog()
            Case Else
                frmAppointments.ShowDialog()
        End Select

    End Sub
    Sub selectAndLink(relationType As String)
        'add customer first - a prospective buyer or tenant
        frmAddCustomer.ShowDialog()
        cust.load(Customer.custid)
        CustProp.relationType = relationType
        'Dim cp As New CustProp
        'cp.link("Active") 'creates database record of link
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
            prop.load(0)
            CtrlProperty1.loadProp(prop)
            CtrlAdminButtons1.Visible = False
            refreshPropertyList()
            prop.load(0)
            fillDetails()
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

            nextStatus() 'this function automates valuation pending to for sale
            .status = ctrlPropStat.cbxStatus.Text

            .price = CLng(txtPrice.Text)
            .photo = pbxPhoto.Image

            'update DB
            .update()

        End With
        'hide show buttons
        disableEdit()

        'refresh table and details
        refreshPropertyList()
        fillDetails()
    End Sub


    Private Sub txtPrice_Validated(sender As Object, e As System.EventArgs) Handles txtPrice.Validated
        nextStatus()
    End Sub


End Class