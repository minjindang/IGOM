Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class SAL_SABANK
        Public DAO As SAL_SABANKDAO

        Public Sub New()
            DAO = New SAL_SABANKDAO()
        End Sub

        Public Function GetOne() As DataRow
            Dim dt As DataTable = DAO.SelectOne()
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(Optional BANK_SEQNO As String = "") As DataTable
            Dim dt As DataTable = DAO.SelectAll(BANK_SEQNO)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(BANK_SEQNO As String, BANK_ORGID As String, BANK_SAL_ITEM As String, BANK_CODE As String, BANK_BANK_NO As String, BANK_MUSER As String, BANK_MDATE As String, BANK_TDPF_SEQNO As String)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(BANK_SEQNO) Then
                psList.Add(New SqlParameter("@BANK_SEQNO", BANK_SEQNO))
            Else
                psList.Add(New SqlParameter("@BANK_SEQNO", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BANK_ORGID) Then
                psList.Add(New SqlParameter("@BANK_ORGID", BANK_ORGID))
            Else
                psList.Add(New SqlParameter("@BANK_ORGID", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BANK_SAL_ITEM) Then
                psList.Add(New SqlParameter("@BANK_SAL_ITEM", BANK_SAL_ITEM))
            Else
                psList.Add(New SqlParameter("@BANK_SAL_ITEM", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BANK_CODE) Then
                psList.Add(New SqlParameter("@BANK_CODE", BANK_CODE))
            Else
                psList.Add(New SqlParameter("@BANK_CODE", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BANK_BANK_NO) Then
                psList.Add(New SqlParameter("@BANK_BANK_NO", BANK_BANK_NO))
            Else
                psList.Add(New SqlParameter("@BANK_BANK_NO", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BANK_MUSER) Then
                psList.Add(New SqlParameter("@BANK_MUSER", BANK_MUSER))
            Else
                psList.Add(New SqlParameter("@BANK_MUSER", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BANK_MDATE) Then
                psList.Add(New SqlParameter("@BANK_MDATE", BANK_MDATE))
            Else
                psList.Add(New SqlParameter("@BANK_MDATE", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BANK_TDPF_SEQNO) Then
                psList.Add(New SqlParameter("@BANK_TDPF_SEQNO", BANK_TDPF_SEQNO))
            Else
                psList.Add(New SqlParameter("@BANK_TDPF_SEQNO", DBNull.Value))
            End If


            DAO.Insert(psList.ToArray())
        End Sub

        Public Sub Modify(BANK_SEQNO As String, BANK_ORGID As String, BANK_SAL_ITEM As String, BANK_CODE As String, BANK_BANK_NO As String, BANK_MUSER As String, BANK_MDATE As String, BANK_TDPF_SEQNO As String)

            Dim dr As DataRow = GetOne()

            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(BANK_SEQNO) Then
                psList.Add(New SqlParameter("@BANK_SEQNO", BANK_SEQNO))
            Else
                psList.Add(New SqlParameter("@BANK_SEQNO", dr("BANK_SEQNO")))
            End If
            If Not String.IsNullOrEmpty(BANK_ORGID) Then
                psList.Add(New SqlParameter("@BANK_ORGID", BANK_ORGID))
            Else
                psList.Add(New SqlParameter("@BANK_ORGID", dr("BANK_ORGID")))
            End If
            If Not String.IsNullOrEmpty(BANK_SAL_ITEM) Then
                psList.Add(New SqlParameter("@BANK_SAL_ITEM", BANK_SAL_ITEM))
            Else
                psList.Add(New SqlParameter("@BANK_SAL_ITEM", dr("BANK_SAL_ITEM")))
            End If
            If Not String.IsNullOrEmpty(BANK_CODE) Then
                psList.Add(New SqlParameter("@BANK_CODE", BANK_CODE))
            Else
                psList.Add(New SqlParameter("@BANK_CODE", dr("BANK_CODE")))
            End If
            If Not String.IsNullOrEmpty(BANK_BANK_NO) Then
                psList.Add(New SqlParameter("@BANK_BANK_NO", BANK_BANK_NO))
            Else
                psList.Add(New SqlParameter("@BANK_BANK_NO", dr("BANK_BANK_NO")))
            End If
            If Not String.IsNullOrEmpty(BANK_MUSER) Then
                psList.Add(New SqlParameter("@BANK_MUSER", BANK_MUSER))
            Else
                psList.Add(New SqlParameter("@BANK_MUSER", dr("BANK_MUSER")))
            End If
            If Not String.IsNullOrEmpty(BANK_MDATE) Then
                psList.Add(New SqlParameter("@BANK_MDATE", BANK_MDATE))
            Else
                psList.Add(New SqlParameter("@BANK_MDATE", dr("BANK_MDATE")))
            End If
            If Not String.IsNullOrEmpty(BANK_TDPF_SEQNO) Then
                psList.Add(New SqlParameter("@BANK_TDPF_SEQNO", BANK_TDPF_SEQNO))
            Else
                psList.Add(New SqlParameter("@BANK_TDPF_SEQNO", dr("BANK_TDPF_SEQNO")))
            End If


            DAO.Update(psList.ToArray())


        End Sub

        Public Sub Remove()
            DAO.Delete()
        End Sub

    End Class
End Namespace
