Imports System.Data
Imports System.Collections.Generic

Namespace EMP.Logic
    Public Class DepartEmpDAO
        Inherits BaseDAO

        Public Function GetDataByIdcard(idCard As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Id_card", idCard)
            Return GetDataByExample("Emp_Depart_Emp", d)
        End Function
        
        Public Function GetDataByServiceType(ByVal idCard As String, ByVal serviceType As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Id_card", idCard)

            If Not String.IsNullOrEmpty(serviceType) Then
                d.Add("Service_type", serviceType)
            End If

            Return GetDataByExample("Emp_Depart_Emp", d)
        End Function

    End Class
End Namespace