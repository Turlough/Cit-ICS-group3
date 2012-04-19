Public Class frmAcceptOffer
    Private buyerId As Integer
    Private vendorId As Integer
    Private price As Integer
    Private cust As New Customer
    Private prop As New Properties
    Private cp As New CustProp
    Private val As New Validator


    Private Sub frmAcceptOffer_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        showBuyers()
    End Sub
    Sub showBuyers()
        With dgvOffers
            .DataSource = cp.getOffers
            .Columns(0).Visible = False 'buyer id
            .Columns(1).Visible = False 'prop id
            .Columns(2).Visible = False 'price offered
            .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
    End Sub

    Private Sub dgvOffers_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOffers.CellClick
        With dgvOffers
            'get buyer
            buyerId = .Rows(e.RowIndex).Cells(0).Value
            'get property
            prop.loadProperty(.Rows(e.RowIndex).Cells(1).Value())
            'get price
            Dim s As String = .Rows(e.RowIndex).Cells(2).Value.ToString
            If val.amountOffered(s) Then
                price = CInt(s)
            Else
                price = 0
            End If

            'get owner
            cust = prop.getRelatedCustomer("Owner")
            vendorId = Customer.custid
            cust.loadCustomer(vendorId)

            showDetails()

        End With
    End Sub
    Sub showDetails()
        cust.loadCustomer(buyerId) 'load buyer
        lblBuyer.Text = cust.fullName
        cust.loadCustomer(vendorId) 'load vendor
        lblOwner.Text = cust.fullName

        lblProperty.Text = prop.fullAddress
        txtPrice.Text = price

    End Sub

    Private Sub btnAccept_Click(sender As System.Object, e As System.EventArgs) Handles btnAccept.Click

        If val.amountOffered(txtPrice.Text) Then
            price = CInt(txtPrice.Text)
            'update property
            prop.price = price
            prop.status = "Offer Accepted"
            prop.updateProperty()

            'update buyer relationship
            cp.setRelation(buyerId, Properties.propid, "Buyer")


        Else
            MsgBox("Enter the price accepted")
        End If
    End Sub
End Class