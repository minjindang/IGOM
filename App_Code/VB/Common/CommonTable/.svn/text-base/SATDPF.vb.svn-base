Imports Microsoft.VisualBasic
Imports System.Data

Namespace PAY.Logic
    Public Class SATDPF
        Public DAO As SATDPFDAO

        Public Sub New()
            DAO = New SATDPFDAO()
        End Sub
        Public Function SelectSATDPF(ByVal TDPF_ORGID As String, _
                                      ByVal TDPF_ITEM As String) As DataTable
            Dim dt As DataTable
            dt = DAO.SelectSATDPF(TDPF_ORGID, TDPF_ITEM)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function GetData(TDPF_ORGID As String) As DataTable
            Return DAO.GetData(TDPF_ORGID)
        End Function
    End Class
End Namespace