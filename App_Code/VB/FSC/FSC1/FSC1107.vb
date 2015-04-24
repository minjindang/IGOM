Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    Public Class FSC1107
        Private DAO As FSC1107DAO

        Public Sub New()
            DAO = New FSC1107DAO()
        End Sub

       ''' <summary>
        ''' 回傳類別名稱與代碼
        ''' </summary>
        ''' <param name="CODE_SYS">子系統別</param>
        ''' <param name="CODE_TYPE">代碼類別</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCodeData(ByVal CODE_SYS As String, ByVal CODE_TYPE As String) As DataTable
            Dim dtData As DataTable
            dtData = DAO.GetCodeData(CODE_SYS, CODE_TYPE)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 新增【在職/服務中文證明資料檔】
        ''' </summary>
        ''' <param name="flow_id">表單編號</param>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <param name="Depart_id">單位代碼</param>
        ''' <param name="id_card">員工編號</param>
        ''' <param name="Apply_name">姓名</param>
        ''' <param name="Apply_date">申請日期</param>
        ''' <param name="Apply_type">申請類別</param>
        ''' <param name="Apply_copies">申請份數</param>
        ''' <param name="Purpose">用途</param>
        ''' <param name="Notes">備註說明</param>
        ''' <param name="Change_userid">異動人員</param>
        ''' <param name="Change_date">異動時間</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertWorkserviceProof(ByVal flow_id As String, ByVal Orgcode As String, ByVal Depart_id As String, ByVal id_card As String, ByVal Apply_name As String, ByVal Apply_date As String, ByVal Apply_type As String, ByVal Apply_copies As String, ByVal Purpose As String, ByVal Notes As String, ByVal Change_userid As String, ByVal Change_date As DateTime) As Integer
            Dim iCounts As Integer = 0
            iCounts = DAO.InsertWorkserviceProof(flow_id, Orgcode, Depart_id, id_card, Apply_name, Apply_date, Apply_type, Apply_copies, Purpose, Notes, Change_userid, Change_date)
            Return iCounts
        End Function

        Public Function UpdateWorkserviceProof(ByVal flow_id As String, ByVal Orgcode As String, ByVal Apply_type As String, ByVal Apply_copies As String, ByVal Purpose As String, ByVal Notes As String, ByVal Change_userid As String, ByVal Change_date As DateTime) As Boolean
            Dim wp As New FSC.Logic.WorkserviceProof()

            wp.FlowId = flow_id
            wp.Orgcode = Orgcode
            wp.ApplyType = Apply_type
            wp.ApplyCopies = Apply_copies
            wp.Purpose = Purpose
            wp.Notes = Notes
            wp.ChangeUserid = Change_userid
            wp.ChangeDate = Change_date

            Return wp.UpdateData()

        End Function
    End Class
End Namespace
