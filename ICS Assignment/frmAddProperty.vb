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



    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        'controller
        If Customer.custid = 0 Then
            cust.createCustomer(txtFname.Text, txtSname.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text)
        End If
        props.CreateProperty(txtAdd1.Text, txtAdd2.Text, txtTown.Text, txtCounty.Text)

        'relation
        CustProp.relationType = "Owner"
        cp.link("Pending")

        'form
        Me.Hide()
        frmHomeScreen.showDetails()
        frmAppointments.Show()
    End Sub
    ''' <summary>
    ''' The Find Customer form is shown, and the user selects a customer (or cancels).
    ''' The selected customer is loaded and displayed on form
    ''' </summary>
    ''' <param name="sender">not used</param>
    ''' <param name="e">not used</param>
    ''' <remarks></remarks>
    Private Sub btnSearchCustomers_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchCustomers.Click
        frmFindCustomer.Show()
        loadCustomer()
    End Sub

    Private Sub loadCustomer()
        If Customer.custid = 0 Then
            Exit Sub
        End If
        cust.loadCustomer(Customer.custid)

        txtFname.Text = cust.fname
        txtSname.Text = cust.sname
        txtEmail.Text = cust.email
        txtPhone.Text = cust.phone
        txtAddress.Text = cust.address

    End Sub
End Class