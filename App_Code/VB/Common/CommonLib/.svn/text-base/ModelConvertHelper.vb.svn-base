Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.Reflection

Public Class ModelConvertHelper(Of T As New)

    Public Shared Function convertToModel(ByVal dt As DataTable) As IList

        ' 定義集合
        Dim ts As IList = New ArrayList()

        ' 獲得此模型的類型
        Dim type As Type = GetType(T)

        Dim tempName As String = ""

        For Each dr As DataRow In dt.Rows
            Dim t As New T()

            ' 獲得此模型的公共屬性
            Dim propertys As PropertyInfo() = t.[GetType]().GetProperties()

            For Each pi As PropertyInfo In propertys
                tempName = pi.Name

                ' 檢查DataTable是否包含此列
                If dt.Columns.Contains(tempName) Then
                    ' 判斷此屬性是否有Setter
                    If Not pi.CanWrite Then
                        Continue For
                    End If

                    Dim value As Object = dr(tempName)
                    If value IsNot DBNull.Value Then
                        pi.SetValue(t, value, Nothing)
                    End If
                End If
            Next

            ts.Add(t)
        Next

        Return ts

    End Function

End Class
