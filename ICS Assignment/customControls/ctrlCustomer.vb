Public Class ctrlCustomer
    Dim cust As New Customer
    Dim v As New Validator
    Function validateForm() As Boolean
        Dim b As Boolean = True

        If Not v.isName(txtFname.Text) Then b = False
        If Not v.isName(txtSname.Text) Then b = False
        If v.notEmpty(txtPhone.Text) And Not v.phone(txtPhone.Text) Then b = False
        If v.notEmpty(txtEmail.Text) And Not v.email(txtEmail.Text) Then b = False
        If Not v.notEmpty(txtAddress.Text) And v.isAddress(txtAddress.Text) Then b = False

        Return b
    End Function
    Sub loadCust(cust As Customer)
        With cust
            txtFname.Text = .fname
            txtSname.Text = .sname
            txtPhone.Text = .phone
            txtEmail.Text = .email
            txtAddress.Text = .address
        End With
    End Sub
    Sub enable()
        txtFname.Enabled = True
        txtSname.Enabled = True
        txtEmail.Enabled = True
        txtPhone.Enabled = True
        txtAddress.Enabled = True

    End Sub
    Sub disable()
        txtFname.Enabled = False
        txtSname.Enabled = False
        txtEmail.Enabled = False
        txtPhone.Enabled = False
        txtAddress.Enabled = False

    End Sub

    Private Sub txtFname_Validated(sender As Object, e As System.EventArgs) Handles txtFname.Validated
        ep.SetError(txtFname, "")
        txtFname.Text = v.properCase(txtFname.Text)
        validateForm()
    End Sub

    Private Sub txtFname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtFname.Validating
        If v.notEmpty(txtFname.Text) Then
            txtFname.Text = v.properCase(txtFname.Text)
            If Not v.isName(txtFname.Text) Then
                e.Cancel = True
                txtFname.Select(0, txtFname.Text.Length)
                ep.SetError(txtFname, v.message)
            End If
        Else
            e.Cancel = True
            ep.SetError(txtFname, "Cannot be empty")
        End If

    End Sub

    Private Sub txtSname_Validated(sender As Object, e As System.EventArgs) Handles txtSname.Validated
        ep.SetError(txtSname, "")
        txtSname.Text = v.properCase(txtSname.Text)
        validateForm()
    End Sub

    Private Sub txtSname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtSname.Validating
        If v.notEmpty(txtSname.Text) Then
            txtSname.Text = v.properCase(txtSname.Text)
            If Not v.isName(txtSname.Text) Then
                e.Cancel = True
                txtSname.Select(0, txtSname.Text.Length)
                ep.SetError(txtSname, v.message)
            End If
        Else
            e.Cancel = True
            ep.SetError(txtSname, "Cannot be empty")
        End If

    End Sub

    Private Sub txtEmail_Validated(sender As Object, e As System.EventArgs) Handles txtEmail.Validated
        ep.SetError(txtEmail, "")
        validateForm()
    End Sub

    Private Sub txtEmail_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtEmail.Validating
        If v.notEmpty(txtEmail.Text) And Not v.email(txtEmail.Text) Then
            e.Cancel = True
            txtEmail.Select(0, txtEmail.Text.Length)
            ep.SetError(txtEmail, v.message)
        End If

    End Sub

    Private Sub txtPhone_Validated(sender As Object, e As System.EventArgs) Handles txtPhone.Validated
        ep.SetError(txtPhone, "")
        validateForm()
    End Sub

    Private Sub txtPhone_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPhone.Validating
        If v.notEmpty(txtPhone.Text) And Not v.phone(txtPhone.Text) Then
            e.Cancel = True
            txtPhone.Select(0, txtPhone.Text.Length)
            ep.SetError(txtPhone, v.message)
        End If
    End Sub

    Private Sub txtAddress_Validated(sender As Object, e As System.EventArgs) Handles txtAddress.Validated
        ep.SetError(txtAddress, "")
        txtAddress.Text = v.properCase(txtAddress.Text)
        validateForm()
    End Sub

    Private Sub txtAddress_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAddress.Validating
        If v.notEmpty(txtAddress.Text) And Not v.isAddress(txtAddress.Text) Then
            e.Cancel = True
            txtAddress.Select(0, txtAddress.Text.Length)
            ep.SetError(txtAddress, v.message)
        End If
    End Sub

 
End Class
