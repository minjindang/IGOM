Imports Microsoft.VisualBasic
Imports System

Public Class CastTypeFun

    Public Shared Function CastObjectToString(ByVal value As Object) As String
        Dim str As String
        Try
            str = Convert.ToString(value)
        Catch ex As Exception
            str = ""
        End Try
        Return str
    End Function

    Public Shared Function CastStringToDBString(ByVal value As String) As String
        If value = "" Or String.IsNullOrEmpty(value) Then
            Return Nothing
        End If

        Return value
    End Function

    Public Shared Function CastObjectToInteger(ByVal value As Object) As Integer
        Return CastObjectToInteger(value, 0)
    End Function
    Public Shared Function CastObjectToInteger(ByVal value As Object, ByVal failDefaultValue As Integer) As Integer

        Dim returnInt As Integer

        Try
            returnInt = Integer.Parse(value.ToString)
        Catch ex As Exception
            returnInt = failDefaultValue
        End Try

        Return returnInt

    End Function

    Public Shared Function CastObjectToDouble(ByVal value As Object, ByVal failDefaultValue As Integer) As Double

        Dim returnDouble As Double

        Try
            returnDouble = Double.Parse(value.ToString)
        Catch ex As Exception
            returnDouble = failDefaultValue
        End Try

        Return returnDouble

    End Function

    Public Shared Function CastStringToDate(ByVal value As String, ByVal failDefaultValue As Nullable(Of Date)) As Nullable(Of Date)

        Dim returnDate As Nullable(Of Date) = Nothing

        Try
            If value = "" Then
                Throw New Exception()
            End If
            returnDate = Date.Parse(value)
        Catch ex As Exception
            returnDate = failDefaultValue
        End Try

        Return returnDate

    End Function

    Public Shared Function CastObjectToDateStringFormat(ByVal value As Object, ByVal format As String, ByVal failDefaultValue As String) As String

        Dim returnStr As String
        Dim tmpDate As Date

        Try
            tmpDate = Date.Parse(value)
            returnStr = tmpDate.ToString(format)
        Catch ex As Exception
            returnStr = failDefaultValue
        End Try

        Return returnStr

    End Function

    Public Shared Function FillZero(ByVal value As Integer, ByVal bits As Integer) As String

        Dim returnStr As String
        Dim i As Integer

        returnStr = CType(value, String)

        Try
            For i = 1 To bits - returnStr.Length
                returnStr = "0" & returnStr
            Next
        Catch ex As Exception
            Return value
        End Try

        Return returnStr

    End Function


End Class
