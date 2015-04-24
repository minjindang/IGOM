Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SALARY.Logic
    <System.ComponentModel.DataObject()> _
    Public Class SAL3116
        Public DAO As SAL3116DAO
        Public Sub New()
            DAO = New SAL3116DAO()
        End Sub

        Dim dtData As DataTable

        Public Function GetBankData(ByVal Orgcode As String) As DataTable
            dtData = DAO.GetBankData(Orgcode)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        Public Function GetBankNOData(ByVal BANK_CODE As String) As DataTable
            dtData = DAO.GetBankNOData(BANK_CODE)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        Public Function GetData(ByVal Orgcode As String, ByVal v_kind As String) As DataTable
            Dim dsData As DataSet = DAO.GetData(Orgcode, v_kind)
            If dsData Is Nothing Then
                Return Nothing
            Else
                Return dsData.Tables(0)
            End If
        End Function

        Public Function InsertOrUpdate(ByVal TDPM_ORGID As String, ByVal TDPM_KIND As String, ByVal TDPM_CODE_SYS As String, ByVal TDPM_CODE_KIND As String, ByVal TDPM_CODE_TYPE As String, _
                               ByVal TDPM_CODE_NO As String, ByVal TDPM_CODE As String, ByVal TDPM_TDPF_SEQNO As String, ByVal TDPM_MUSER As String, ByVal TDPM_MDATE As String) As Boolean
            Return DAO.InsertOrUpdate(TDPM_ORGID, TDPM_KIND, TDPM_CODE_SYS, TDPM_CODE_KIND, TDPM_CODE_TYPE, TDPM_CODE_NO, TDPM_CODE, TDPM_TDPF_SEQNO, TDPM_MUSER, TDPM_MDATE) > 0
        End Function
    End Class
End Namespace