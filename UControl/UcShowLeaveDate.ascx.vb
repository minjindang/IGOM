Imports System.Data
Imports FSCPLM.Logic

Partial Class UControl_UcShowLeaveDate
    Inherits System.Web.UI.UserControl

#Region "Fields"
    Private _Flow_id As String
    Private _Orgcode As String
    Private _Leave_ngroup As String
    Private _Leave_type As String
    Private _Start_date As String
    Private _Start_time As String
    Private _End_date As String
    Private _End_time As String
#End Region

#Region "Property"
    Public Property Flow_id() As String
        Get
            Return _Flow_id
        End Get
        Set(ByVal value As String)
            _Flow_id = value
        End Set
    End Property

    Public Property Orgcode() As String
        Get
            Return _Orgcode
        End Get
        Set(ByVal value As String)
            _Orgcode = value
        End Set
    End Property

    Public Property Leave_ngroup() As String
        Get
            Return _Leave_ngroup
        End Get
        Set(ByVal value As String)
            _Leave_ngroup = value
        End Set
    End Property

    Public Property Start_date() As String
        Get
            Return _Start_date
        End Get
        Set(ByVal value As String)
            _Start_date = value
        End Set
    End Property

    Public Property Start_time() As String
        Get
            Return _Start_time
        End Get
        Set(ByVal value As String)
            _Start_time = value
        End Set
    End Property

    Public Property End_date() As String
        Get
            Return _End_date
        End Get
        Set(ByVal value As String)
            _End_date = value
        End Set
    End Property

    Public Property End_time() As String
        Get
            Return _End_time
        End Get
        Set(ByVal value As String)
            _End_time = value
            Bind()
        End Set
    End Property
#End Region

    Dim dt As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Bind()
        Try
            dt.Columns.Add("Start_date", GetType(String))
            dt.Columns.Add("Start_time", GetType(String))
            dt.Columns.Add("End_date", GetType(String))
            dt.Columns.Add("End_time", GetType(String))
            dt.Columns.Add("Leave_name", GetType(String))
            Bind_Local()
        Catch ex As Exception
        End Try
    End Sub


    Protected Sub Bind_Local()
        'Dim Orgcode As String = String.Empty

        'If String.IsNullOrEmpty(Me.Orgcode) Then
        '    Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        'Else
        '    Orgcode = Me.Orgcode
        'End If

        'If Mid(Me.Leave_ngroup, 2) = "2" And Mid(Me.Leave_ngroup, 1, 1) <> "B" Then
        '    '多次差假狀況

        '    '取得申請人的資料
        '    Dim mdt As DataTable = New Flow().GetApplyData(Me.Flow_id, Orgcode)
        '    If mdt.Rows.Count <= 0 Then Return
        '    Dim mdr As DataRow = mdt.Rows(0)
        '    Dim Metadb_id As String = mdr("Metadb_id").ToString()

        '    Dim plmConn As String = ConnectDB.GetDBString()
        '    Dim p2kConn As String = ConnectDB.GetCPADBString(Metadb_id)

        '    If Mid(Me.Leave_ngroup, 1, 1) = "A" Then
        '        '多次請假

        '        '取多次表單檔
        '        Dim fm As FlowMultidate = New FlowMultidate()
        '        Dim fmdt As DataTable = fm.GetData(Me.Flow_id, Orgcode)

        '        If fmdt Is Nothing OrElse fmdt.Rows.Count <= 0 Then

        '            Dim po15m_dt As DataTable = Nothing
        '            '判斷是否結案
        '            If (mdr("Last_pass") = "0" And (mdr("Case_status") = "0" Or mdr("Case_status") = "1")) Or _
        '               (mdr("Last_pass") = "1" And (mdr("Case_status") = "2" Or mdr("Case_status") = "4")) Then
        '                '未批核, 已批核(取消或不同意), 抓plm裡的po15m
        '                po15m_dt = New CPAPO15M(plmConn).GetCPAPO15MByFlow_id(Me.Flow_id)
        '            Else
        '                '已批核(成功), 抓p2k裡的po15m 
        '                po15m_dt = New CPAPO15M(p2kConn).GetCPAPO15MByFlow_id(Me.Flow_id)
        '            End If

        '            If po15m_dt.Rows.Count > 0 Then
        '                For Each po15m_dr As DataRow In po15m_dt.Rows
        '                    addRow(po15m_dr("POVDATEB").ToString(), po15m_dr("POVTIMEB").ToString(), po15m_dr("POVDATEE").ToString(), po15m_dr("POVTIMEE").ToString())
        '                Next
        '            Else
        '                addRow(Me.Start_date, Me.Start_time, Me.End_date, Me.End_time)
        '            End If
        '        Else
        '            For Each dr As DataRow In fmdt.Rows
        '                addRow(dr("Start_date").ToString(), dr("Start_time").ToString(), dr("End_date").ToString(), dr("End_time").ToString())
        '            Next
        '        End If
        '    End If

        '    If Mid(Me.Leave_ngroup, 1, 1) = "C" Then
        '        '多次公差

        '        Dim pp16m_dt As DataTable = Nothing

        '        '取多次表單檔
        '        Dim fm As FlowMultidate = New FlowMultidate()
        '        Dim fmdt As DataTable = fm.GetData(Me.Flow_id, Orgcode)

        '        If fmdt Is Nothing OrElse fmdt.Rows.Count <= 0 Then
        '            '判斷是否結案
        '            If (mdr("Last_pass") = "0" And (mdr("Case_status") = "0" Or mdr("Case_status") = "1")) Or _
        '               (mdr("Last_pass") = "1" And (mdr("Case_status") = "2" Or mdr("Case_status") = "4")) Then
        '                '未批核, 已批核(取消或不同意), 抓plm裡的pp16m
        '                pp16m_dt = New CPAPP16M(plmConn).GetCPAPP16MByFlow_id(Me.Flow_id)
        '            Else
        '                '已批核(成功), 抓p2k裡的pp16m 
        '                pp16m_dt = New CPAPP16M(p2kConn).GetCPAPP16MByFlow_id(Me.Flow_id)
        '            End If

        '            If pp16m_dt.Rows.Count > 0 Then
        '                For Each pp16m_dr As DataRow In pp16m_dt.Rows
        '                    addRow(pp16m_dr("PPBUSDATEB").ToString(), pp16m_dr("PPTIMEB").ToString(), pp16m_dr("PPBUSDATEE").ToString(), pp16m_dr("PPTIMEE").ToString())
        '                Next
        '            Else
        '                addRow(Me.Start_date, Me.Start_time, Me.End_date, Me.End_time)
        '            End If
        '        Else
        '            For Each dr As DataRow In fmdt.Rows
        '                addRow(dr("Start_date").ToString(), dr("Start_time").ToString(), dr("End_date").ToString(), dr("End_time").ToString())
        '            Next
        '        End If
        '    End If

        '    If Mid(Me.Leave_ngroup, 1, 1) = "E" Or Mid(Me.Leave_ngroup, 1, 1) = "D" Then
        '        '專案加班 or 公差補休
        '        addRow(Me.Start_date, Me.Start_time, Me.End_date, Me.End_time)
        '    End If

        'ElseIf Mid(Me.Leave_ngroup, 1, 1) = "B" Then
        '    '出國請假

        '    Dim fo_dt As DataTable = New FlowOutside().GetFlowOutsideByFlow_id(Me.Flow_id, Orgcode)
        '    Dim me_dt As DataTable
        '    If fo_dt.Rows.Count > 0 Then
        '        For Each fo_dr As DataRow In fo_dt.Rows
        '            '0981105 Update 
        '            me_dt = New Member().GetDataByIdcard(fo_dr("Deputy_idcard").ToString())
        '            '20130528局長與非局長的代理人顯示
        '            If Not fo_dr("apply_posid").Equals("1020") Then
        '                addRow(fo_dr("Start_date").ToString(), fo_dr("Start_time").ToString(), fo_dr("End_date").ToString(), fo_dr("End_time").ToString(), fo_dr("leave_name").ToString(), me_dt.Rows(0)("User_name").ToString())
        '            Else
        '                addRow(fo_dr("Start_date").ToString(), fo_dr("Start_time").ToString(), fo_dr("End_date").ToString(), fo_dr("End_time").ToString(), fo_dr("leave_name").ToString(), fo_dr("Level_Deputy").ToString())
        '            End If
        '        Next
        '    Else
        '        Dim fdt As DataTable = New Flow().GetFlowByFlow_id(Me.Flow_id, Orgcode)
        '        Dim Leave_name As String = String.Empty
        '        If fdt IsNot Nothing And fdt.Rows.Count > 0 Then
        '            Leave_name = fdt.Rows(0)("leave_name").ToString()
        '        End If
        '        addRow(Me.Start_date, Me.Start_time, Me.End_date, Me.End_time, Leave_name)
        '    End If

        'ElseIf Mid(Me.Leave_ngroup, 1, 1) = "F" Then
        '    addRow(Me.Start_date, Me.Start_time, "", "")
        'Else
        '    addRow(Me.Start_date, Me.Start_time, Me.End_date, Me.End_time)
        'End If

        'dl.DataSource = dt
        'dl.DataBind()
    End Sub

    '0981105 Update 
    Protected Sub addRow(ByVal dateb As String, ByVal timeb As String, ByVal datee As String, ByVal timee As String, Optional ByVal Leave_name As String = Nothing, Optional ByVal Deputy_Name As String = Nothing)
        Dim dti As New DateTimeInfo
        Dim dr As DataRow = dt.NewRow
        'dr("Start_date") = dti.ConvertToDisplay(dateb)
        'dr("Start_time") = dti.ConvertToDisplayTime(timeb)
        'dr("End_date") = dti.ConvertToDisplay(datee)
        'dr("End_time") = dti.ConvertToDisplayTime(timee)
        'dr("Leave_name") = IIf(Not String.IsNullOrEmpty(Leave_name), "(" & Leave_name & IIf(Not String.IsNullOrEmpty(Deputy_Name), " 代理人：" & Deputy_Name, "") & ")", "")
        'dt.Rows.Add(dr)
    End Sub

    Protected Sub dl_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dl.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            If Not String.IsNullOrEmpty(CType(e.Item.FindControl("dl_lbLeave_name"), Label).Text) Then
                CType(e.Item.FindControl("dl_lbLeave_name"), Label).Visible = True
            End If
            If String.IsNullOrEmpty(CType(e.Item.FindControl("dl_lbEnd_date"), Label).Text) Then
                CType(e.Item.FindControl("dl_lb"), Label).Visible = False
            End If
        End If
    End Sub
End Class
