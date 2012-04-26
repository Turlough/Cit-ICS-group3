Imports System.Text.RegularExpressions
Imports System.Globalization.TextInfo


Public Class Validator
    Private msg As String
    Public ReadOnly Property message As String
        Get
            Return msg
        End Get
    End Property
    Private Function err(s As String) As Boolean
        msg = s
        Return s.Length > 0
    End Function

    Public Function numeric(s As String) As Boolean
        If Not IsNumeric(s) Then
            msg = "Must be a number"
            Return False
        Else
            msg = ""
            Return True
        End If
    End Function
    Public Function isName(s As String) As Boolean
        Dim re As New Regex("^[A-Z][a-z A-Z'-]*$")
        If Not re.IsMatch(s) Then
            msg = "Invalid characters. Be more alphabetical"
            Return False
        Else
            msg = ""
            Return True
        End If
    End Function
    Public Function isAddress(s As String) As Boolean
        Dim re As New Regex("^(([0-9a-zA-Z \.#,'-])+\r?\n?){1,5}\z")
        If Not re.IsMatch(s) Then
            msg = "Accepted characters are: Letters, Numbers, Spaces and Characters( . # , ' - )" & vbCr & "Maximum of 5 lines."
            Return False
        Else
            msg = ""
            Return True
        End If
    End Function

    Public Function notEmpty(s As String) As Boolean
        If s.Length = 0 Then
            msg = "You need to enter text"
            Return False
        Else
            msg = ""
            Return True
        End If
    End Function

    Public Function email(s As String) As Boolean
        'Dim re As New Regex("^([0-9a-zA-Z]+[-._+&amp;])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$")
        Dim re As New Regex("^([\w\.!#\$%&'*\+-\/=\?\^`\{\|\}\~]+@\w+\.(\w{2,255})(\.\w{2,255})?)$")

        If Not re.IsMatch(s) Then
            msg = "Accepted characters in an email address host portion (eg: host@domain.subdomain) are:  ! # $ % & ' * + - / = ? ^ _ ` { | } ~ " & vbCr & "The domain and subdomain(s) must contain a minimum of 2 characters and may only contain letters, numbers, or underscore."
            Return False
        Else
            msg = ""
            Return True
        End If

    End Function

    Public Function phone(s As String) As Boolean
        'Return numeric(s) 'TODO regex
        Dim re As New Regex("^([\d \(\)\+-])+$")

        If Not re.IsMatch(s) Then
            msg = "Invalid Phone number (Phone numbers can contain only numbers, spaces, brackets, or hyphens (-))"
            Return False
        Else
            msg = ""
            Return True
        End If
    End Function

    Public Function properCase(ByVal s As String) As String
        If IsNothing(s) Or s = "" Then Return ""

        s = s.Trim() 'remove surrounding spaces
        s = StrConv(s, VbStrConv.ProperCase) 'use proper case
        Return s
    End Function

    Public Function addApostrophe(ByVal s As String) As String
        If IsNothing(s) Or s = "" Then Return ""
        s = Replace(s, Chr(39), "''") 'escape single quote
        s = s.Trim() 'remove surrounding spaces
        Return s
    End Function
End Class