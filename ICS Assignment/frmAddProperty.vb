Imports System.Data.SqlClient

''' <summary>
''' This form allows the agent to enter basic details of owner and property.
''' Further details (property description, photos, etc.) are added later.
''' </summary>
''' <remarks>Using 'search' prefills the 'owner' section with selected client</remarks>
Public Class frmAddProperty

    Dim props As New Properties
    Dim cust As New Customer
    Dim cp As New CustProp
    Dim v As New Validator

    Private Sub frmAddProperty_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        cust.loadCustomer(0)
        clearForm()
        cstmCounty.County = "Cork"
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        'controller
        If Customer.custid = 0 Then
            cust.createCustomer(txtFname.Text, txtSname.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text)
        End If

        props.CreateProperty(txtAdd1.Text, txtAdd2.Text, txtTown.Text, cstmCounty.County)

        'relation
        CustProp.relationType = "Owner"
        cp.link("Valuation Pending")

        'form
        frmAppointments.ShowDialog()
        Me.Close()

    End Sub
    ''' <summary>
    ''' The Find Customer form is shown, and the user selects a customer (or cancels).
    ''' The selected customer is loaded and displayed on form
    ''' </summary>
    ''' <param name="sender">not used</param>
    ''' <param name="e">not used</param>
    ''' <remarks></remarks>
    Private Sub btnSearchCustomers_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchCustomers.Click
        frmFindCustomer.ShowDialog()
        displayCustomer()
    End Sub

    Private Sub displayCustomer()
        cust.loadCustomer(Customer.custid)

        txtFname.Text = cust.fname
        txtSname.Text = cust.sname
        txtEmail.Text = cust.email
        txtPhone.Text = cust.phone
        txtAddress.Text = cust.address
        If Customer.custid > 0 Then
            txtFname.Enabled = False
            txtSname.Enabled = False
            txtEmail.Enabled = False
            txtPhone.Enabled = False
            txtAddress.Enabled = False
        Else
            txtFname.Enabled = True
            txtSname.Enabled = True
            txtEmail.Enabled = True
            txtPhone.Enabled = True
            txtAddress.Enabled = True
        End If

    End Sub
    Sub clearForm()
        cust.loadCustomer(0)
        displayCustomer()

    End Sub


    Private Sub frmAddProperty_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtEmail_Validated(sender As Object, e As System.EventArgs) Handles txtEmail.Validated
        ep.SetError(txtEmail, "")
    End Sub

    Private Sub txtEmail_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtEmail.Validating
        If Not v.email(txtEmail.Text) Then
            e.Cancel = True
            txtEmail.Select(0, txtEmail.Text.Length)
            ep.SetError(txtEmail, v.message)
        End If

    End Sub

    Private Sub txtFname_Validated(sender As Object, e As System.EventArgs) Handles txtFname.Validated
        ep.SetError(txtFname, "")
    End Sub

    Private Sub txtFname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtFname.Validating
        If Not v.isName(txtFname.Text) Then
            e.Cancel = True
            txtFname.Select(0, txtFname.Text.Length)
            ep.SetError(txtFname, v.message)
        End If
    End Sub
    Private Sub txtSname_Validated(sender As Object, e As System.EventArgs) Handles txtSname.Validated
        ep.SetError(txtSname, "")
    End Sub

    Private Sub txtSname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtSname.Validating
        If Not v.isName(txtSname.Text) Then
            e.Cancel = True
            txtSname.Select(0, txtSname.Text.Length)
            ep.SetError(txtSname, v.message)
        End If
    End Sub

    Private Sub txtAdd1_Validated(sender As Object, e As System.EventArgs) Handles txtAdd1.Validated
        ep.SetError(txtAdd1, "")
    End Sub

    Private Sub txtAdd1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAdd1.Validating
        If Not v.isName(txtAdd1.Text) Then
            e.Cancel = True
            txtAdd1.Select(0, txtAdd1.Text.Length)
            ep.SetError(txtAdd1, v.message)
        End If
    End Sub

    Private Sub txtTown_Validated(sender As Object, e As System.EventArgs) Handles txtTown.Validated
        ep.SetError(txtTown, "")
    End Sub

    Private Sub txtTown_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtTown.Validating
        If Not v.isName(txtTown.Text) Then
            e.Cancel = True
            txtTown.Select(0, txtTown.Text.Length)
            ep.SetError(txtTown, v.message)
        End If
    End Sub
End Class