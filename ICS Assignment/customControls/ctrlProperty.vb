Public Class ctrlProperty

    Dim v As New Validator
    Function validateForm() As Boolean
        Dim b As Boolean = True

        If Not v.isAddress(txtAdd1.Text) Then b = False
        If v.notEmpty(txtAdd2.Text) And Not v.isName(txtAdd2.Text) Then b = False
        If Not v.isName(txtTown.Text) Then b = False

        Return b
    End Function
    Sub loadProp(prop As Properties)
        With prop
            txtadd1.Text = .add1
            txtadd2.Text = .add2
            txtTown.Text = .town
            cstmCounty.Text = .county
        End With
    End Sub
    Sub enable()
        txtadd1.Enabled = True
        txtadd2.Enabled = True
        txttown.Enabled = True
        cstmCounty.Enabled = True

    End Sub
    Sub disable()
        txtadd1.Enabled = False
        txtadd2.Enabled = False
        txtTown.Enabled = False
        cstmCounty.Enabled = False

    End Sub
    Private Sub txtAdd1_Validated(sender As Object, e As System.EventArgs) Handles txtAdd1.Validated
        ep.SetError(txtAdd1, "")
        txtAdd1.Text = v.prepareForSql(txtAdd1.Text)
        validateForm()
    End Sub

    Private Sub txtAdd1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAdd1.Validating
        If v.notEmpty(txtAdd1.Text) Then
            txtAdd1.Text = v.prepareForSql(txtAdd1.Text)
            If Not v.isAddress(txtAdd1.Text) Then
                e.Cancel = True
                txtAdd1.Select(0, txtAdd1.Text.Length)
                ep.SetError(txtAdd1, v.message)
            End If
        Else
            e.Cancel = True
            ep.SetError(txtAdd1, "Cannot be empty")
        End If
    End Sub
    Private Sub txtAdd2_Validated(sender As Object, e As System.EventArgs) Handles txtAdd2.Validated
        ep.SetError(txtAdd2, "")
        txtAdd2.Text = v.prepareForSql(txtAdd2.Text)
        validateForm()
    End Sub

    Private Sub txtAdd2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAdd2.Validating
        If v.notEmpty(txtAdd2.Text) Then
            txtAdd2.Text = v.prepareForSql(txtAdd2.Text)
            If v.notEmpty(txtAdd2.Text) And Not v.isName(txtAdd2.Text) Then
                e.Cancel = True
                txtAdd2.Select(0, txtAdd2.Text.Length)
                ep.SetError(txtAdd2, v.message)
            End If
        Else
            'do nothing
        End If
    End Sub
    Private Sub txtTown_Validated(sender As Object, e As System.EventArgs) Handles txtTown.Validated
        ep.SetError(txtTown, "")
        txtTown.Text = v.prepareForSql(txtTown.Text)
        validateForm()
    End Sub

    Private Sub txtTown_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtTown.Validating
        If v.notEmpty(txtTown.Text) Then
            txtTown.Text = v.prepareForSql(txtTown.Text)
            If Not v.isName(txtTown.Text) Then
                e.Cancel = True
                txtTown.Select(0, txtTown.Text.Length)
                ep.SetError(txtTown, v.message)
            End If
        Else
            'do nothing
        End If
    End Sub
End Class
