Imports System.Data.SqlClient
Public Class frmFindCustomer
    Dim cust As New Customer
    Dim dSql As String
    Dim sSql As String
    Private Sub frmFindCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadData()
        'set the default value to "first name"
        If cbxField.Items.Count > 0 Then
            cbxField.SelectedIndex = 0    ' The first item has index 0 '
        End If
        'hide controls
        disableEdit()
        ctrlAdmin.Visible = False
        btnProperties.Visible = False
    End Sub
    Private Sub frmFindCustomer_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

    End Sub
    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        loadData()
    End Sub

    Private Sub loadData()
        With dgvCustomers
            .DataSource = cust.findCustomer(txtSearch.Text, cbxField.Text)
            .Columns(0).Visible = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            .Columns("address").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        End With
    End Sub

    Private Sub dgvCustomers_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCustomers.CellClick
        With dgvCustomers
            Dim r As Integer = e.RowIndex
            If r >= 0 Then
                .Rows(r).Selected = True    ' select the entire row
                Customer.custid = .Rows(r).Cells(0).Value ' get the customer ID (PK)
                showCustomer()
            End If
        End With
    End Sub

    Private Sub showCustomer()
        If Customer.custid > 0 Then

            cust.load(Customer.custid)
            ctrlCust.loadCust(cust)
            ctrlAdmin.Visible = True
            btnProperties.Visible = True
        Else
            ctrlAdmin.Visible = False
            btnProperties.Visible = False
        End If
        disableEdit()
    End Sub

    Sub EnableEdit()
        ctrlCust.enable()
    End Sub

    Sub disableEdit()
        ctrlCust.disable()
    End Sub

    Private Sub btnProperties_Click(sender As System.Object, e As System.EventArgs) Handles btnProperties.Click

    End Sub

    Private Sub btnSet_Click(sender As System.Object, e As System.EventArgs) Handles btnSet.Click
        Me.Close()
    End Sub

    Private Sub ctrlAdmin_Delete(sender As Object, e As System.EventArgs) Handles ctrlAdmin.Delete
        cust.delete(Customer.custid)
        Customer.custid = 0 'reset custid
        cust.load(0)
        ctrlCust.loadCust(cust)
        loadData()
        showCustomer()
    End Sub

    Private Sub ctrlAdmin_Edit(sender As Object, e As System.EventArgs) Handles ctrlAdmin.Edit
        EnableEdit()
    End Sub

    Private Sub ctrlAdmin_Save(sender As Object, e As System.EventArgs) Handles ctrlAdmin.Save
        If Customer.custid > 0 Then
            With cust
                .fname = ctrlCust.txtFname.Text
                .sname = ctrlCust.txtSname.Text
                .address = ctrlCust.txtAddress.Text
                .phone = ctrlCust.txtPhone.Text
                .email = ctrlCust.txtEmail.Text
                'save
                .update()
            End With
            cust.load(Customer.custid)
            loadData()
            showCustomer()
            disableEdit()
        Else
            MsgBox("No customer selected")
        End If
    End Sub


End Class