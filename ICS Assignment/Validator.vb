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
        Dim re As New Regex("^[A-Z][a-z A-Z]*$")
        If Not re.IsMatch(s) Then
            msg = "Invalid characters. Be more alphabetical"
            Return False
        Else
            msg = ""
            Return True
        End If
    End Function
    Public Function isAddress(s As String) As Boolean
        Dim re As New Regex("^[0-9a-z A-Z][a-z A-Z]*$")
        If Not re.IsMatch(s) Then
            msg = "Invalid characters. Be more alphabetical"
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
        Dim re As New Regex("^([0-9a-zA-Z]+[-._+&amp;])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$")
        If Not re.IsMatch(s) Then
            msg = "Invalid Email Addrees"
            Return False
        Else
            msg = ""
            Return True
        End If

    End Function
    Public Function phone(s As String) As Boolean
        Return numeric(s) 'TODO regex
    End Function

    Public Function prepareForSql(ByVal s As String) As String
        If IsNothing(s) Or s = "" Then Return ""

        s = Replace(s, Chr(39), "''") 'escape single quote
        s = s.Trim() 'remove surrounding spaces
        s = StrConv(s, VbStrConv.ProperCase) 'use proper case

        Return s
    End Function

End Class
