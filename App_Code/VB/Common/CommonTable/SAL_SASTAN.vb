Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class SAL_SASTAN
        Public DAO As SAL_SASTANDAO

        Public Sub New()
            DAO = New SAL_SASTANDAO()
        End Sub

        Public Function GetOne() As DataRow
            Dim dt As DataTable = DAO.SelectOne()
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(Optional STAN_NO As String = "", Optional STAN_SAL_POINT As String = "", Optional STAN_YM As String = "") As DataTable
            Dim dt As DataTable = DAO.SelectAll(STAN_NO, STAN_SAL_POINT, STAN_YM)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(STAN_YM As String, STAN_TYPE As String, STAN_NO As String, STAN_SAL_POINT As String, STAN_SAL As Double, STAN_MUSER As String, STAN_MDATE As String)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(STAN_YM) Then
                psList.Add(New SqlParameter("@STAN_YM", STAN_YM))
            Else
                psList.Add(New SqlParameter("@STAN_YM", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(STAN_TYPE) Then
                psList.Add(New SqlParameter("@STAN_TYPE", STAN_TYPE))
            Else
                psList.Add(New SqlParameter("@STAN_TYPE", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(STAN_NO) Then
                psList.Add(New SqlParameter("@STAN_NO", STAN_NO))
            Else
                psList.Add(New SqlParameter("@STAN_NO", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(STAN_SAL_POINT) Then
                psList.Add(New SqlParameter("@STAN_SAL_POINT", STAN_SAL_POINT))
            Else
                psList.Add(New SqlParameter("@STAN_SAL_POINT", DBNull.Value))
            End If
            If Not STAN_SAL = Double.MinValue Then
                psList.Add(New SqlParameter("@STAN_SAL", STAN_SAL))
            Else
                psList.Add(New SqlParameter("@STAN_SAL", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(STAN_MUSER) Then
                psList.Add(New SqlParameter("@STAN_MUSER", STAN_MUSER))
            Else
                psList.Add(New SqlParameter("@STAN_MUSER", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(STAN_MDATE) Then
                psList.Add(New SqlParameter("@STAN_MDATE", STAN_MDATE))
            Else
                psList.Add(New SqlParameter("@STAN_MDATE", DBNull.Value))
            End If


            DAO.Insert(psList.ToArray())
        End Sub

        Public Sub Modify(STAN_YM As String, STAN_TYPE As String, STAN_NO As String, STAN_SAL_POINT As String, STAN_SAL As Double, STAN_MUSER As String, STAN_MDATE As String)

            Dim dr As DataRow = GetOne()

            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(STAN_YM) Then
                psList.Add(New SqlParameter("@STAN_YM", STAN_YM))
            Else
                psList.Add(New SqlParameter("@STAN_YM", dr("STAN_YM")))
            End If
            If Not String.IsNullOrEmpty(STAN_TYPE) Then
                psList.Add(New SqlParameter("@STAN_TYPE", STAN_TYPE))
            Else
                psList.Add(New SqlParameter("@STAN_TYPE", dr("STAN_TYPE")))
            End If
            If Not String.IsNullOrEmpty(STAN_NO) Then
                psList.Add(New SqlParameter("@STAN_NO", STAN_NO))
            Else
                psList.Add(New SqlParameter("@STAN_NO", dr("STAN_NO")))
            End If
            If Not String.IsNullOrEmpty(STAN_SAL_POINT) Then
                psList.Add(New SqlParameter("@STAN_SAL_POINT", STAN_SAL_POINT))
            Else
                psList.Add(New SqlParameter("@STAN_SAL_POINT", dr("STAN_SAL_POINT")))
            End If
            If Not STAN_SAL = Double.MinValue Then
                psList.Add(New SqlParameter("@STAN_SAL", STAN_SAL))
            Else
                psList.Add(New SqlParameter("@STAN_SAL", dr("STAN_SAL")))
            End If
            If Not String.IsNullOrEmpty(STAN_MUSER) Then
                psList.Add(New SqlParameter("@STAN_MUSER", STAN_MUSER))
            Else
                psList.Add(New SqlParameter("@STAN_MUSER", dr("STAN_MUSER")))
            End If
            If Not String.IsNullOrEmpty(STAN_MDATE) Then
                psList.Add(New SqlParameter("@STAN_MDATE", STAN_MDATE))
            Else
                psList.Add(New SqlParameter("@STAN_MDATE", dr("STAN_MDATE")))
            End If


            DAO.Update(psList.ToArray())


        End Sub

        Public Sub Remove()
            DAO.Delete()
        End Sub

    End Class
End Namespace
