Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class SAL_SAPARAMETER
        Public DAO As SAL_SAPARAMETERDAO

        Public Sub New()
            DAO = New SAL_SAPARAMETERDAO()
        End Sub

        Public Function GetOne(PARAMETER_CODE_KIND As String, PARAMETER_CODE_NO As String, PARAMETER_CODE_SYS As String, PARAMETER_CODE_TYPE As String, PARAMETER_YM As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(PARAMETER_CODE_KIND, PARAMETER_CODE_NO, PARAMETER_CODE_SYS, PARAMETER_CODE_TYPE, PARAMETER_YM)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(Optional PARAMETER_CODE_KIND As String = "", Optional PARAMETER_CODE_NO As String = "", _
                                  Optional PARAMETER_CODE_SYS As String = "", Optional PARAMETER_CODE_TYPE As String = "", _
                                  Optional PARAMETER_YM As String = "") As DataTable
            Dim dt As DataTable = DAO.SelectAll(PARAMETER_CODE_KIND,PARAMETER_CODE_NO,PARAMETER_CODE_SYS,PARAMETER_CODE_TYPE,PARAMETER_YM )
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(PARAMETER_YM As String, PARAMETER_CODE_SYS As String, PARAMETER_CODE_KIND As String, PARAMETER_CODE_TYPE As String, PARAMETER_CODE_NO As String, PARAMETER_VALUE As String, PARAMETER_MUSER As String, PARAMETER_MDATE As String)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(PARAMETER_YM) Then
                psList.Add(New SqlParameter("@PARAMETER_YM", PARAMETER_YM))
            Else
                psList.Add(New SqlParameter("@PARAMETER_YM", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PARAMETER_CODE_SYS) Then
                psList.Add(New SqlParameter("@PARAMETER_CODE_SYS", PARAMETER_CODE_SYS))
            Else
                psList.Add(New SqlParameter("@PARAMETER_CODE_SYS", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PARAMETER_CODE_KIND) Then
                psList.Add(New SqlParameter("@PARAMETER_CODE_KIND", PARAMETER_CODE_KIND))
            Else
                psList.Add(New SqlParameter("@PARAMETER_CODE_KIND", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PARAMETER_CODE_TYPE) Then
                psList.Add(New SqlParameter("@PARAMETER_CODE_TYPE", PARAMETER_CODE_TYPE))
            Else
                psList.Add(New SqlParameter("@PARAMETER_CODE_TYPE", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PARAMETER_CODE_NO) Then
                psList.Add(New SqlParameter("@PARAMETER_CODE_NO", PARAMETER_CODE_NO))
            Else
                psList.Add(New SqlParameter("@PARAMETER_CODE_NO", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PARAMETER_VALUE) Then
                psList.Add(New SqlParameter("@PARAMETER_VALUE", PARAMETER_VALUE))
            Else
                psList.Add(New SqlParameter("@PARAMETER_VALUE", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PARAMETER_MUSER) Then
                psList.Add(New SqlParameter("@PARAMETER_MUSER", PARAMETER_MUSER))
            Else
                psList.Add(New SqlParameter("@PARAMETER_MUSER", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PARAMETER_MDATE) Then
                psList.Add(New SqlParameter("@PARAMETER_MDATE", PARAMETER_MDATE))
            Else
                psList.Add(New SqlParameter("@PARAMETER_MDATE", DBNull.Value))
            End If


            DAO.Insert(psList.ToArray())
        End Sub

        Public Sub Modify(PARAMETER_CODE_KIND As String, PARAMETER_CODE_NO As String, PARAMETER_CODE_SYS As String, PARAMETER_CODE_TYPE As String, PARAMETER_YM As String, _
PARAMETER_VALUE As String, PARAMETER_MUSER As String, PARAMETER_MDATE As String)

            Dim dr As DataRow = GetOne(PARAMETER_CODE_KIND, PARAMETER_CODE_NO, PARAMETER_CODE_SYS, PARAMETER_CODE_TYPE, PARAMETER_YM)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@PARAMETER_CODE_KIND", PARAMETER_CODE_KIND))
            psList.Add(New SqlParameter("@PARAMETER_CODE_NO", PARAMETER_CODE_NO))
            psList.Add(New SqlParameter("@PARAMETER_CODE_SYS", PARAMETER_CODE_SYS))
            psList.Add(New SqlParameter("@PARAMETER_CODE_TYPE", PARAMETER_CODE_TYPE))
            psList.Add(New SqlParameter("@PARAMETER_YM", PARAMETER_YM))
            If Not String.IsNullOrEmpty(PARAMETER_VALUE) Then
                psList.Add(New SqlParameter("@PARAMETER_VALUE", PARAMETER_VALUE))
            Else
                psList.Add(New SqlParameter("@PARAMETER_VALUE", dr("PARAMETER_VALUE")))
            End If
            If Not String.IsNullOrEmpty(PARAMETER_MUSER) Then
                psList.Add(New SqlParameter("@PARAMETER_MUSER", PARAMETER_MUSER))
            Else
                psList.Add(New SqlParameter("@PARAMETER_MUSER", dr("PARAMETER_MUSER")))
            End If
            If Not String.IsNullOrEmpty(PARAMETER_MDATE) Then
                psList.Add(New SqlParameter("@PARAMETER_MDATE", PARAMETER_MDATE))
            Else
                psList.Add(New SqlParameter("@PARAMETER_MDATE", dr("PARAMETER_MDATE")))
            End If


            DAO.Update(psList.ToArray())


        End Sub

        Public Sub Remove(PARAMETER_CODE_KIND As String, PARAMETER_CODE_NO As String, PARAMETER_CODE_SYS As String, PARAMETER_CODE_TYPE As String, PARAMETER_YM As String)
            DAO.Delete(PARAMETER_CODE_KIND, PARAMETER_CODE_NO, PARAMETER_CODE_SYS, PARAMETER_CODE_TYPE, PARAMETER_YM)
        End Sub

    End Class
End Namespace
