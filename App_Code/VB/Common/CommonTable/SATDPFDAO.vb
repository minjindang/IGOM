Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace PAY.Logic
    Public Class SATDPFDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub
        Public Function SelectSATDPF(ByVal TDPF_ORGID As String, _
                                      ByVal TDPF_ITEM As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = ""
            StrSQL &= "select top 1 * from SAL_SATDPF "
            StrSQL &= "where 1 = 1 "
            StrSQL &= "and TDPF_ORGID=@TDPF_ORGID "
            StrSQL &= "and TDPF_ITEM=@TDPF_ITEM "
            'If Not String.IsNullOrEmpty(PettyCash_nosS) Then
            '    StrSQL &= "and PAY_LendPetty_main.PettyCash_nos >= @PettyCash_nosS "
            'End If
            Dim ps() As SqlParameter = {New SqlParameter("@TDPF_ORGID", TDPF_ORGID), _
                                        New SqlParameter("@TDPF_ITEM", TDPF_ITEM)}
            Return Query(StrSQL, ps)
        End Function


        Public Function GetData(TDPF_ORGID As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" Select TDPF_BRANCH, TDPF_CUSTOM ") '客戶代號
            sql.AppendLine(" From SAL_SATDPF A INNER JOIN SAL_SATDPM B ON A.TDPF_SEQNO=B.TDPM_TDPF_SEQNO ")
            sql.AppendLine(" where  B.TDPM_KIND='005' AND B.TDPM_CODE_SYS='005' AND B.TDPM_CODE_KIND='D' ")
            sql.AppendLine(" AND B.TDPM_CODE_TYPE='001' AND B.TDPM_CODE_NO='702' AND B.TDPM_CODE='001' ")
            sql.AppendLine(" AND B.TDPM_ORGID=@TDPF_ORGID ")
            Dim ps() As SqlParameter = {New SqlParameter("@TDPF_ORGID", TDPF_ORGID)}
            Return Query(sql.ToString(), ps)
        End Function
    End Class
End Namespace