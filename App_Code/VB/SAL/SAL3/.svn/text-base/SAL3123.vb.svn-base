Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SALARY.Logic


    <System.ComponentModel.DataObject()> _
    Public Class SAL3123
        Public DAO As SAL3123DAO
        Public Sub New()
            DAO = New SAL3123DAO()
        End Sub

        Public Function getSeqno(ByVal orgid As String, ByVal idno As String) As String
            Return DAO.getSeqno(orgid, idno)
        End Function

        Public Function delete() As Boolean
            Return DAO.delete() > 0
        End Function

        Public Function insert(ByVal family_orgid As String, ByVal family_seqno As String, ByVal family_id As String, _
                               ByVal family_name As String, ByVal family_amt As String, ByVal family_muser As String) As Boolean
            Return DAO.insert(family_orgid, family_seqno, family_id, family_name, family_amt, family_muser) > 0
        End Function
    End Class
End Namespace
