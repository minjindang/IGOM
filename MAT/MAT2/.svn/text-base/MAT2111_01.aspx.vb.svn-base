Imports FSCPLM.Logic
Imports System.Data
Imports System.Transactions

Partial Class MAT_MAT2_MAT2111_01
    Inherits BaseWebForm

    Dim dao As New MAT1103
    Dim flowID As String
    Dim flowDR As DataRow

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            flowID = Request.QueryString("flow_id")
            hfFlow_id.Value = flowID
            If dao.isBatch(flowID) Then
                Me.lblTitle.Text = "成批領物明細"
            Else
                If dao.getFormType(flowID, LoginManager.OrgCode) = "001" Then
                    Me.lblTitle.Text = "個人領物"
                Else
                    Me.lblTitle.Text = "單位領物"
                End If
            End If
            BindGV()
        End If

    End Sub

    Private Sub BindGV()
        GetFlowOne()
        Me.gv.DataSource = dao.GetByFlow(flowID, LoginManager.OrgCode)
        Me.gv.DataBind()
        'Dim f As New Flow
        Dim Next_step As String = CommonFun.SetDataRow(flowDR, "Next_step")
        'Me.divButton.Visible = (Next_step = GetLastStep() + 1)
        Me.divButton.Visible = (GetLastStep() = 0)
    End Sub

    Protected Function GetLastStep() As Integer
        GetFlowOne()
        '先依人員
        'Dim Last_step As Integer = New FlowOutpostId().GetMaxOutpost_seq(LoginManager.OrgCode, _
        '                                                                 LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), _
        '                                                                 CommonFun.SetDataRow(flowDR, "Apply_id"), _
        '                                                                 CommonFun.SetDataRow(flowDR, "Leave_group"))

        ''再依職稱
        'If Last_step = Nothing Then
        '    Last_step = New FlowOutpostId().GetMaxOutpost_seq(LoginManager.OrgCode, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), _
        '                                                      CommonFun.SetDataRow(flowDR, "Apply_Posid"), CommonFun.SetDataRow(flowDR, "Leave_group"))
        'End If
        'Return Last_step
    End Function

    Private Sub GetFlowOne()
        If flowDR Is Nothing Then
            flowDR = dao.queryFlowOne(hfFlow_id.Value, LoginManager.OrgCode)
        End If

    End Sub

    Protected Sub DoneBtn_Click(sender As Object, e As EventArgs) Handles DoneBtn.Click
        For Each gr As GridViewRow In Me.gv.Rows
            Dim details_id As String = CType(gr.FindControl("hfDetails_id"), HiddenField).Value
            Dim outCnt As String = CType(gr.FindControl("txtOut_cnt"), TextBox).Text
            dao.UpdateOutCnt(hfFlow_id.Value, LoginManager.OrgCode, details_id, outCnt)
        Next
        '下一關 
        Dim err As New StringBuilder
        GetFlowOne()
        'Dim f As New Flow
        'f.Apply_Name = CommonFun.SetDataRow(flowDR, "Apply_Name")
        'f.Flow_id = hfFlow_id.Value
        'f.Orgcode = LoginManager.OrgCode
        'f.Comment = ""
        'f.Case_status = "1"

        Try
            '    '取表單資料
            '    f.RunInitFlow() 
            '    Using trans As New TransactionScope 
            '       f.RunFlow()  
            '        trans.Complete()
            '    End Using

        Catch fex As FlowException
            err.Append("表單(" & hfFlow_id.Value & ")，" & fex.Message() & "。\n")
        Catch ex As Exception
            err.Append("批核表單(" & hfFlow_id.Value & ")時，系統發生錯誤，請洽人事管理人員。\n")
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
        End Try
        CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "修改完成")
        'Me.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Close", "window.close()", True)
    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        BindGV()
    End Sub



End Class
