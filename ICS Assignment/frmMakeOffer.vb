Imports System.Windows.Forms

Public Class frmMakeOffer
    Private cust As New Customer
    Private prop As New Properties
    Private cp As New CustProp
    Dim buyer As Integer
    Dim vendor As Integer

    Private Sub frmMakeOffer_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        showDetails()


    End Sub
    Sub showDetails()

        If Properties.propid > 0 Then
            prop.load(Properties.propid)
            cust = prop.getRelatedCustomer("Owner")
            vendor = Customer.custid 'set when showing dialog)
            lblProperty.Text = prop.fullAddress
            txtAmount.Text = prop.price
            lblAskingPrice.Text = prop.price
            cust.load(buyer) 'reset buyer
        End If
        If Customer.custid > 0 Then
            buyer = Customer.custid
            cust.load(Customer.custid)
            Me.lblCustomer.Text = cust.fullName
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
End Class
