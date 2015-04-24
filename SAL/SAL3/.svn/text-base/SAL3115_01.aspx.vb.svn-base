Imports System.Data
Imports FSCPLM.Logic
Imports SALARY.Logic
Imports System.Transactions
Imports System.IO

Partial Class SAL_SAL3_SAL3115_01
    Inherits BaseWebForm


    'Dim pagecount As Integer = 20

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox_orgid.Text = LoginManager.OrgCode
        Me.SQLs1()
        Me.GridView_batengf.DataBind()

    End Sub

    Protected Sub SQLs1()
        Dim v_orgid As String = Me.TextBox_orgid.Text
        Dim szSQL As String = ""

        szSQL &= " SELECT TOP 100 s1.*, "
        szSQL &= " s2.unit_dep  ,"
        szSQL &= " ISNULL((SELECT TOP 1 base_name FROM SAL_sabase WHERE base_orgid=TRN_orgid and base_idno=TRN_USERID),'') as user_name ,"
        szSQL &= " isnull((select code_desc1 FROM SYS_CODE WHERE code_sys='003' and code_type='005' and code_no=trn_kind),'') as kind_name "
        szSQL &= " FROM SAL_SABATTRN s1  "
        szSQL &= " LEFT JOIN SAL_saunit s2 ON s1.TRN_ORGID=s2.unit_no  "
        szSQL &= " WHERE 1=1  AND TRN_ORGID='" & v_orgid & "'  "
        szSQL &= " ORDER BY TRN_BOOKTIME DESC"

        Me.TextBox_SQLs1.Text = szSQL

    End Sub

    Protected Sub GridView_batengf_PageIndexChanging1(sender As Object, e As GridViewPageEventArgs) Handles GridView_batengf.PageIndexChanging
        GridView_batengf.PageIndex = e.NewPageIndex
        Me.SQLs1()
        Me.GridView_batengf.DataBind()
    End Sub

    Protected Function Unit_Name(ByVal unit_dep, ByVal user_name, ByVal kind_name) As String
        Dim rv As String = ""

        rv = unit_dep & ":" & kind_name

        If user_name <> "" Then
            rv &= "<br />(執行人員:" & user_name & ")"
        End If

        Return rv

    End Function

    Protected Function YM_Name(ByVal v_ym) As String
        Dim rv As String = ""
        Dim ym As String = v_ym.ToString
        If Len(ym) = 4 Then
            rv = CStr(CInt(ym) - 1911) & "年"
        ElseIf Len(ym) = 6 Then
            rv = CStr(CInt(Mid(ym, 1, 4)) - 1911) & "年" & CStr(Mid(ym, 5, 2)) & "月"
        Else
            rv = "&nbsp;"
        End If
        Return rv
    End Function

    Protected Function Status_Name(ByVal stat) As String
        Dim rv As String = ""
        stat = stat.ToString
        Select Case stat
            Case "W"
                rv = "排程中"
            Case "T"
                rv = "作業中"
            Case "F"
                rv = "作業完成"
            Case "E"
                rv = "作業失敗"
            Case Else
        End Select

        Return rv
    End Function

    Protected Function Time_Name(ByVal time) As String
        Dim rv As String = ""
        time = time.ToString
        If Len(time) = 14 Then
            rv = CStr(CInt(Mid(time, 1, 4)) - 1911) & "年" & Mid(time, 5, 2) & "月" & Mid(time, 7, 2) & "日<br />" & Mid(time, 9, 2) & "時" & Mid(time, 11, 2) & "分" & Mid(time, 13, 2) & "秒"
        Else
            rv = time
        End If
        Return rv
    End Function

    Protected Function Btn_Vis(ByVal status, ByVal orgid, ByVal cnt) As Boolean
        Dim rv As Boolean = False

        status = status.ToString

        If (status = "F") And (orgid = Me.TextBox_orgid.Text) Then 'And (CInt(cnt) = 1) Then
            rv = True
        End If

        Return rv
    End Function



    Protected Sub GridView_batengf_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)

        Me.GridView_batengf.PageIndex = e.NewPageIndex
        Me.GridView_batengf.DataBind()
    End Sub
End Class
