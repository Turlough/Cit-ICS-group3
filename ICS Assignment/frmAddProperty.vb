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
        cust.load(0)
        clearForm()
        CtrlProperty1.cstmCounty.County = "Cork"
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'validate
        If Not CtrlProperty1.validateForm() Or Not CtrlCustomer1.validateForm Then
            MsgBox("Invalid Entry. Please review your submission")
            Exit Sub
        End If
        With CtrlCustomer1
            If Customer.custid = 0 Then
                cust.insert(.txtFname.Text, .txtSname.Text, .txtAddress.Text, .txtPhone.Text, .txtEmail.Text)
            End If
        End With
        With CtrlProperty1
            props.insert(.txtAdd1.Text, .txtAdd2.Text, .txtTown.Text, .cstmCounty.County)
        End With

        'relation
        If rbOwner.Checked Then
            CustProp.relationType = "Owner"
        Else
            CustProp.relationType = "Landlord"
        End If
        cp.link("Valuation Pending")

        'form
        frmAppointments.ShowDialog()
        Me.Close()

    End Sub

    Private Sub btnSearchCustomers_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchCustomers.Click
        frmFindCustomer.ShowDialog()
        displayCustomer()
    End Sub

    Private Sub displayCustomer()
        cust.load(Customer.custid)
        CtrlCustomer1.loadCust(cust)

        If Customer.custid > 0 Then
            CtrlCustomer1.disable()
        Else
            CtrlCustomer1.enable()
        End If

    End Sub
    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        clearForm()
    End Sub
    Sub clearForm()
        cust.load(0)
        displayCustomer()
    End Sub


End Class