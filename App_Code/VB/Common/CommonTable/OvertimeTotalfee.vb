Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    <System.ComponentModel.DataObject()> _
    Public Class OvertimeTotalfee
        Public DAO As OvertimeTotalfeeDAO

        Public Sub New()
            DAO = New OvertimeTotalfeeDAO()
        End Sub

        Public Function InsertOvertimeTotalfee(ByVal Orgcode As String, ByVal budget_year As String) As Boolean

            Dim fdt As DataTable = New FSCorg().GetOrgcodeByOrgcode(Orgcode)

            For Each fdr As DataRow In fdt.Rows
                For type As Integer = 1 To 2
                    If DAO.GetCount(Orgcode, fdr("DepartID").ToString(), budget_year, type) <= 0 Then
                        DAO.InsertData(Orgcode, fdr("DepartID").ToString(), budget_year, type)
                    End If
                Next
            Next

            '技工、工友、駕駛
            If DAO.GetCount(Orgcode, "xxxx", budget_year, "1") <= 0 Then
                DAO.InsertData(Orgcode, "xxxx", budget_year, "1")
            End If

            Return True
        End Function

        Public Function GetOvertimeTotalfee(ByVal Orgcode As String, ByVal budget_type As String, ByVal budget_year As String, Optional ByVal Depart_id As String = Nothing) As DataTable
            Return DAO.GetData(Orgcode, budget_type, budget_year, Depart_id).Tables(0)
        End Function

        Public Function GetSumByYear(ByVal Orgcode As String, ByVal budget_year As String, ByVal budget_type As String) As Integer
            Dim obj As Object = DAO.GetSumByYear(Orgcode, budget_year, budget_type)
            If IsDBNull(obj) Then
                Return 0
            End If
            Return CType(obj, Integer)
        End Function

        Public Function GetAllSumFee(ByVal Orgcode As String, ByVal Depart_id As String, ByVal budget_year As String, ByVal budget_type As String) As DataTable
            Return DAO.GetAllSumData(Orgcode, depart_id, budget_year, budget_type).Tables(0)
        End Function

        Public Function UpdateData(ByVal Orgcode As String, ByVal Depart_id As String, _
                                  ByVal budget_year As String, ByVal budget_type As String, _
                                  Optional ByVal fee1 As Integer = Nothing, Optional ByVal fee2 As Integer = Nothing, Optional ByVal fee3 As Integer = Nothing, _
                                  Optional ByVal fee4 As Integer = Nothing, Optional ByVal fee5 As Integer = Nothing, Optional ByVal fee6 As Integer = Nothing, _
                                  Optional ByVal fee7 As Integer = Nothing, Optional ByVal fee8 As Integer = Nothing, Optional ByVal fee9 As Integer = Nothing, _
                                  Optional ByVal fee10 As Integer = Nothing, Optional ByVal fee11 As Integer = Nothing, Optional ByVal fee12 As Integer = Nothing) As Boolean

            Return DAO.UpdateData(Orgcode, Depart_id, budget_year, budget_type, fee1, fee2, fee3, fee4, fee5, fee6, fee7, fee8, fee9, fee10, fee11, fee12) = 1
        End Function

        Public Function UpdateFee(ByVal Orgcode As String, ByVal Depart_id As String, ByVal ym As String, ByVal budget_type As String, ByVal fee As Integer) As Boolean
            Return DAO.UpdateFee(Orgcode, Depart_id, ym, budget_type, fee) = 1
        End Function

        Public Function InserData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal ym As String, ByVal budget_type As String, ByVal fee1 As Integer, ByVal fee2 As Integer, ByVal fee3 As Integer, ByVal fee4 As Integer, ByVal fee5 As Integer, ByVal fee6 As Integer, ByVal fee7 As Integer, ByVal fee8 As Integer, ByVal fee9 As Integer, ByVal fee10 As Integer, ByVal fee11 As Integer, ByVal fee12 As Integer) As Boolean
            Return DAO.InsertData(Orgcode, Depart_id, ym, budget_type, fee1, fee2, fee3, fee4, fee5, fee6, fee7, fee8, fee9, fee10, fee11, fee12) = 1
        End Function

        Public Function InsertFee(ByVal Orgcode As String, ByVal Depart_id As String, ByVal ym As String, ByVal budget_type As String, ByVal fee As Integer) As Boolean
            Return DAO.InsertFee(Orgcode, Depart_id, ym, budget_type, fee) = 1
        End Function

        Public Function GetCount(ByVal Orgcode As String, ByVal Depart_id As String, ByVal ym As String, ByVal budget_type As String) As Integer
            Dim obj As Object = DAO.GetCount(Orgcode, Depart_id, ym, budget_type)

            If obj Is Nothing Then
                Return 0
            End If
            Return CType(obj, Integer)
        End Function
    End Class
End Namespace