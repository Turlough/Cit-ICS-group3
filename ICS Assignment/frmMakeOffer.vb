Imports System.Windows.Forms

Public Class frmMakeOffer
    Private cust As New Customer
    Private prop As New Properties
    Private cp As New CustProp
    Dim buyer As Integer
    Dim vendor As Integer
    Dim vendorName As String

    Private Sub frmMakeOffer_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        showDetails()


    End Sub
    Sub showDetails()
        buyer = Customer.custid
        If Customer.custid > 0 Then
            cust.load(Customer.custid)
            Me.lblCustomer.Text = cust.fullName
        Else
            Me.lblCustomer.Text = ""
        End If

        If Properties.propid > 0 Then
            prop.load(Properties.propid)
            'get owner details
            cust = prop.getRelatedCustomer("Owner")
            vendor = Customer.custid
            vendorName = cust.fullName
            'show property details
            lblProperty.Text = prop.fullAddress & vbCr & vbCr & "Owner: " & vendorName
            txtAmount.Text = prop.price
            lblAskingPrice.Text = prop.price
            'reload the buyer
            cust.load(buyer) 'reset buyer
        End If

        'The owner cannot buy his own property!
        If buyer = vendor And Not buyer = 0 Then
            MsgBox(String.Format("The owner ({0}) is the active customer, and cannot buy this property!", vendorName))
            'select another customer
            frmFindCustomer.ShowDialog()
            cust.load(Customer.custid)
            'recursively call this function
            showDetails()
        End If
        If Customer.custid > 0 And Properties.propid > 0 Then
            gbxOffer.Visible = True
        Else
            gbxOffer.Visible = False
        End If
    End Sub

    Private Sub btnSearchCustomer_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchCustomer.Click
        frmFindCustomer.ShowDialog()
        buyer = Customer.custid
        showDetails()

    End Sub

    Private Sub btnAddCustomer_Click(sender As System.Object, e As System.EventArgs) Handles btnAddCustomer.Click
        frmAddCustomer.ShowDialog()
        buyer = Customer.custid
        showDetails()

    End Sub

    Private Sub btnSearchProperty_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchProperty.Click
        frmFindProperties.ShowDialog()
        prop.load(Properties.propid)
        'Ensure its for sale
        While Not prop.status = "For Sale"
            Dim msg As String = String.Format("This property is not for sale. Its status is '{0}'", prop.status)
            'permit exit on cancel (eg there are no properties for sale)
            If MsgBox(msg, MsgBoxStyle.RetryCancel) = vbCancel Then
                Exit Sub
            Else
                'repeat search until valid property selected
                frmFindProperties.ShowDialog()
                prop.load(Properties.propid)
            End If
        End While
        showDetails()
    End Sub


    Private Sub btnMakeOffer_Click(sender As System.Object, e As System.EventArgs) Handles btnMakeOffer.Click
        Dim v As New Validator
        If v.numeric(txtAmount.Text) Then
            makeOffer()
        Else
            MsgBox(v.message)
        End If
    End Sub
    Sub makeOffer()
        cust.load(buyer)
        Dim p As Integer = CLng(txtAmount.Text)
        prop.makeOffer(p)
        'notifyOwner()

        frmRelations.ShowDialog() 'shows customers related to the property, including new propspect
        Me.Close()

    End Sub
    Sub notifyOwner()
        Dim m As New Mailer
        'TODO complete notifyOwner
    End Sub

    Private Sub txtAmount_Validated(sender As Object, e As System.EventArgs) Handles txtAmount.Validated
        ep.SetError(txtAmount, "")
    End Sub

    Private Sub txtAmount_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAmount.Validating
        Dim v As New Validator, p As String = txtAmount.Text

        If Not v.numeric(p) Then 'must be numeric
            e.Cancel = True
            txtAmount.Select(0, txtAmount.Text.Length)
            ep.SetError(txtAmount, v.message)
            Exit Sub
        End If
        If p.Length > 10 Then 'overflows on ten digits
            e.Cancel = True
            txtAmount.Select(0, txtAmount.Text.Length)
            ep.SetError(txtAmount, "Ten digits maximum")
            Exit Sub
        End If
        If CLng(p) < 1 Then 'minimum price
            e.Cancel = True
            txtAmount.Select(0, txtAmount.Text.Length)
            ep.SetError(txtAmount, "Minimum offer of one euro")
        End If

    End Sub
End Class
