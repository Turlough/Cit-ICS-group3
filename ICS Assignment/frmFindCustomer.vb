Imports System.Data.SqlClient
Public Class frmFindCustomer
    Dim cust As New Customer
    Private Sub frmFindCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadData()

        'set the default value to "first name"
        If cbxField.Items.Count > 0 Then
            cbxField.SelectedIndex = 0    ' The first item has index 0 '
        End If
        btnArchive.Visible = False
        btnEdit.Visible = False
        btnProperties.Visible = False


    End Sub


    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        loadData()

    End Sub
    Private Sub loadData()
        With dgvCustomers
            .DataSource = cust.findCustomer(txtSearch.Text, cbxField.Text)
            .Columns(0).Visible = False
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
            With cust
                .loadCustomer(Customer.custid)
                txtFname.Text = .fname
                txtSname.Text = .sname
                txtPhone.Text = .phone
                txtEmail.Text = .email
                txtAddress.Text = .address
            End With
            btnArchive.Visible = True
            btnEdit.Visible = True
            btnProperties.Visible = True
        End If

    End Sub


    Private Sub btnArchive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchive.Click
        cust.delete(Customer.custid)
        Customer.custid = 0 'reset custid
        loadData()
    End Sub


End Class