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
        'show nothing until row clicked
        hideDetails()
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

        If e.RowIndex < 0 Then Exit Sub 'column clicked for sorting, ignore

        With dgvOffers
            'get buyer
            buyerId = .Rows(e.RowIndex).Cells(0).Value
            'get property
            prop.load(.Rows(e.RowIndex).Cells(1).Value())
            'get price
            Dim s As String = .Rows(e.RowIndex).Cells(2).Value.ToString
            If val.numeric(s) Then
                price = CInt(s)
            Else
                price = 0
            End If

            'get owner
            cust = prop.getRelatedCustomer("Owner")
            vendorId = Customer.custid
            cust.load(vendorId)

            showDetails()
            btnAccept.Enabled = True

        End With
    End Sub
    Sub showDetails()
        cust.load(buyerId) 'load buyer
        lblBuyer.Text = cust.fullName
        cust.load(vendorId) 'load vendor
        lblOwner.Text = cust.fullName

        lblProperty.Text = prop.fullAddress
        txtPrice.Text = price

        lblOfferedPrice.Text = price
        lblPropertyPrice.Text = prop.price

    End Sub
    Sub hideDetails()
        lblBuyer.Text = "None Selected"
        lblOwner.Text = "None Selected"
        lblProperty.Text = "None Selected"
        txtPrice.Text = ""
        lblOfferedPrice.Text = ""
        lblPropertyPrice.Text = ""

        btnAccept.Enabled = False

    End Sub

    Private Sub btnAccept_Click(sender As System.Object, e As System.EventArgs) Handles btnAccept.Click
        price = 0
        If val.numeric(txtPrice.Text) Then
            price = CInt(txtPrice.Text)
        Else
            MsgBox("The price must be a number!")
            Exit Sub
        End If
        If price > 0 Then
            'update property
            prop.price = price
            prop.status = "Off Market"
            prop.update()

            'update buyer relationship
            cp.setRelation(buyerId, Properties.propid, "Owner")
            'delete previous owner relationship
            cp.delete(Properties.propid, vendorId)
            'delete history (offers, prospective buyers, etc. All but current owner)
            cp.clearHistory(Properties.propid)

            Me.Close()
        Else
            MsgBox("Enter the price accepted")
        End If
    End Sub

End Class