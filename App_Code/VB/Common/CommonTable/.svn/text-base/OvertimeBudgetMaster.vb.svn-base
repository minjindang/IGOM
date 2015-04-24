Imports Microsoft.VisualBasic
Imports System.Data

Namespace SAL.Logic
    <System.ComponentModel.DataObject()> _
    Public Class OvertimeBudgetMaster
        Public DAO As OvertimeBudgetMasterDAO
        Public Sub New()
            DAO = New OvertimeBudgetMasterDAO()
        End Sub

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetBudget_year(ByVal Orgcode As String) As DataTable
            Dim ds As DataSet = DAO.GetBudget_year(Orgcode)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function


        Public Function GetOvertimeBudgetMasterByQuery(ByVal Orgcode As String, ByVal Budget_year As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByQuery(Orgcode, Budget_year)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetRemaining_applyIsNData(ByVal Orgcode As String, ByVal Budget_year As String) As DataTable
            Dim ds As DataSet = DAO.GetRemaining_applyIsNData(Orgcode, Budget_year)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        ''' <summary>
        ''' 新增或異動 Overtime_budget_master 的 budget_type不為0時，新增 Overtime_budget 子檔資料
        ''' </summary>
        ''' <param name="Orgcode"></param>
        ''' <param name="budget_year"></param>
        ''' <param name="create_userid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertOvertimeBudget(ByVal Orgcode As String, ByVal budget_year As String, ByVal create_userid As String) As Boolean
            Dim fdt As DataTable = New FSC.Logic.Org().GetDataByOrg(Orgcode)

            'Dim ob As New OvertimeBudget

            'For Each fdr As DataRow In fdt.Rows
            '    For type As Integer = 1 To 2
            '        If Not ob.InsertOvertimeBudget(Orgcode, fdr("DepartID").ToString(), budget_year, type, create_userid) Then
            '            Return False
            '        End If
            '    Next
            'Next

            ''技工、工友、駕駛
            'If Not ob.InsertOvertimeBudget(Orgcode, "xxxx", budget_year, "1", create_userid) Then
            '    Return False
            'End If

            Return True
        End Function

        Public Function InsertOvertimeBudgetMaster(ByVal Orgcode As String, ByVal budget_year As String, ByVal budget_type As String, ByVal budget_public As Integer, _
                                     ByVal budget_fund As Integer, ByVal close_date As String, ByVal Remaining_apply As String, ByVal UnAnnualFee_lock As String, ByVal create_userid As String) As Boolean

            Return DAO.InsertData(Orgcode, budget_year, budget_type, budget_public, budget_fund, close_date, Remaining_apply, UnAnnualFee_lock, create_userid) = 1
        End Function

        Public Function UpdateOvertimeBudgetMaster(ByVal Orgcode As String, ByVal budget_year As String, ByVal budget_type As String, _
                                    ByVal budget_public As Integer, ByVal budget_fund As Integer, ByVal close_date As String, _
                                    ByVal Remaining_apply As String, ByVal UnAnnualFee_lock As String, ByVal update_userid As String) As Boolean
            Return DAO.UpdateData(Orgcode, budget_year, budget_type, budget_public, budget_fund, close_date, Remaining_apply, UnAnnualFee_lock, update_userid) = 1
        End Function

        Public Function Getfee(ByVal Orgcode As String, ByVal budget_year As String, ByVal budget_type As String) As Integer
            Dim fee As Integer = 0
            'Dim mdt As DataTable = New FSC.Logic.Member().GetMemberByBudgetType(Orgcode, budget_type)

            Dim cpapr18m As New FSC.Logic.CPAPR18M()

            'For Each mdr As DataRow In mdt.Rows
            '    fee += cpapr18m.GetSumPrpayfee(mdr("Id_card").ToString(), budget_year)
            'Next

            Return fee
        End Function

        Public Function GetChangeBudgetTypeUrl(ByVal Orgcode As String, ByVal budget_year As String, _
                                            ByVal budget_type As String, ByVal Org_budget_type As String, ByVal Id_card As String) As String

            'Dim ob As New OvertimeBudget

            'If Org_budget_type = "0" And ob.GetDataCount(Orgcode, budget_year) <= 0 Then

            '    If Not New OvertimeBudgetMaster().InsertOvertimeBudget(Orgcode, budget_year, Id_card) Then
            '        Return String.Empty
            '    End If

            'Else
            '    ob.UpdateDefault(Orgcode, budget_year, Id_card)
            'End If

            Dim callback As String = String.Empty
            Select Case budget_type
                Case "1"
                    callback = "FSC3203_02_Y.aspx"
                Case "2"
                    callback = "FSC3203_02_S.aspx"
                Case "3"
                    callback = "FSC3203_02_M.aspx"
                Case Else
                    callback = "FSC3203_02_Y.aspx"
            End Select

            Return callback
        End Function


    End Class
End Namespace