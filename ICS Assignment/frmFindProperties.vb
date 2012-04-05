﻿Imports System.Data.SqlClient

Public Class frmFindProperties


    Dim prop As New Properties

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'TODO: default to relationship type
        If cmbStatus.Items.Count > 0 Then
            cmbStatus.SelectedIndex = 0    ' The first item has index 0 '
        End If
        btnDelete.Visible = False
        btnEdit.Visible = False
        btnSave.Visible = False
        btnCancel.Visible = False
    End Sub

    Private Sub btnLocateProperty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocateProperty.Click
        refreshPropertyList()
    End Sub
    Sub refreshPropertyList()
        With dgvProperties
            .DataSource = prop.findProperty(txtAdd.Text, txtTown.Text, txtCounty.Text, minBeds.Value, maxBeds.Value, minPrice.Value, maxPrice.Value, cmbStatus.Text)
            .Columns(0).Visible = False
            .Columns(8).Visible = False
        End With


    End Sub


    Private Sub dgvProperties_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProperties.CellContentClick
        With dgvProperties
            Dim r As Integer = e.RowIndex
            .Rows(r).Selected = True    ' select the entire row
            Properties.propid = .Rows(r).Cells(0).Value ' get the property ID (PK)
        End With
        fillDetails()
        btnDelete.Visible = True
        btnEdit.Visible = True


    End Sub
    Sub fillDetails()
        prop.loadProperty(Properties.propid)
        With prop
            txtAdd1.Text = .add1
            txtAdd2.Text = .add2
            txtTownEdit.Text = .town
            txtCountyEdit.Text = .county
            rtbDescription.Text = .description
            txtStatus.Text = .status
            txtPrice.Text = .price
            pbxPhoto.Image = .photo

        End With

    End Sub

    Private Sub pbxPhoto_Click(sender As System.Object, e As System.EventArgs) Handles pbxPhoto.Click
        Dim d As New OpenFileDialog()
        Dim s As String
        d.InitialDirectory = "E:\ICS\houses"
        s = d.ShowDialog()
        prop.imageSource = d.FileName
        pbxPhoto.Load(prop.imageSource)

        With My.Computer.FileSystem
            If .f Then
        End With


    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        enableEdit()

    End Sub
    Sub enableEdit()
        btnEdit.Visible = False
        btnDelete.Visible = False
        btnSave.Visible = True
        btnCancel.visible = True
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        With prop
            .add1 = txtAdd1.Text
            .add2 = txtAdd2.Text
            .town = txtTownEdit.Text
            .county = txtCountyEdit.Text
            .description = rtbDescription.Text
            .status = txtStatus.Text
            .price = CInt(txtPrice.Text)
            .photo = pbxPhoto.Image

            'update DB
            .updateProperty()
            .setPhoto()
        End With
        'hide show buttons
        btnEdit.Visible = True
        btnDelete.Visible = True
        btnSave.Visible = False
        btnCancel.Visible = False
        'refresh table
        refreshPropertyList()

    End Sub
End Class