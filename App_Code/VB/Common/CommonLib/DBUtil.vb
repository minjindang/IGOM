Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System

Public Class DBUtil

    Public Shared Sub SetParamsNull(ByRef params As SqlParameterCollection)
        Dim nullDB As DBNull = DBNull.Value
        If Not IsNothing(params) Then
            For Each para As SqlParameter In params
                If IsNothing(para) OrElse para.Value.Equals(nullDB) OrElse IsNothing(nullDB) Then
                    para.Value = DBNull.Value
                End If
            Next
        End If
    End Sub

    Public Shared Sub SetParamsNull(ByRef params() As System.Data.SqlClient.SqlParameter)
        If params Is Nothing Then Return
        For Each param As System.Data.SqlClient.SqlParameter In params
            If param.Value Is Nothing OrElse param.Value.Equals(DBNull.Value) Then
                param.Value = DBNull.Value
            End If
        Next
    End Sub

    Public Shared Sub SetParamsNull(ByRef param As SqlParameter)
        Dim nullDB As DBNull = DBNull.Value
        If IsNothing(param) OrElse param.Value.Equals(nullDB) OrElse IsNothing(nullDB) Then
            param.Value = DBNull.Value
        End If
    End Sub

End Class
