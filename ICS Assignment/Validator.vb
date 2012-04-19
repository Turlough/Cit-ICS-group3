Public Class Validator
    Private msg As String
    Public ReadOnly Property message As String
        Get
            Return msg
        End Get
    End Property
    Public Function amountOffered(s As String) As Boolean
        If Not IsNumeric(s) Then
            msg = "Enter a Number"
            Return False
        Else
            msg = ""
            Return True
        End If
    End Function
    Public Function eMail(s As String) As Boolean
        If Not IsNumeric(s) Then
            msg = "Enter a Number"
            Return False
        Else
            msg = ""
            Return True
        End If
    End Function
End Class
