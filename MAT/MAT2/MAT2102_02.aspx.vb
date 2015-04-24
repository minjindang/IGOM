Imports System.Data
Imports FSCPLM.Logic
Partial Class MAT2102_02
    Inherits BaseWebForm

    Dim dbA As DataTable
    Dim ReceiveS As String = ""
    Dim ReceiveE As String = ""
    Dim Material_idS As String = ""
    Dim Material_idE As String = ""
    Dim User_name As String = ""
    Dim ApplyRadioButton As String = ""
    Dim OrgCodeDropDownList As String = ""
    Dim SortRadioButtonList As String = ""
    Dim PagingRadioButtonList As String = ""
    Dim pagerowcnt As Integer = 0
#Region " 初始化"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("ReceiveS"))) Then
                ReceiveS = Server.HtmlEncode(Request("ReceiveS").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("ReceiveE"))) Then
                ReceiveE = Server.HtmlEncode(Request("ReceiveE").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("Material_idS"))) Then
                Material_idS = Server.HtmlEncode(Request("Material_idS").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("Material_idE"))) Then
                Material_idE = Server.HtmlEncode(Request("Material_idE").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("User_name"))) Then
                User_name = Server.HtmlEncode(Request("User_name").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("ApplyRadioButton"))) Then
                ApplyRadioButton = Server.HtmlEncode(Request("ApplyRadioButton"))
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("OrgCodeDropDownList"))) Then
                OrgCodeDropDownList = Server.HtmlEncode(Request("OrgCodeDropDownList").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("SortRadioButtonList"))) Then
                SortRadioButtonList = Server.HtmlEncode(Request("SortRadioButtonList").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("PagingRadioButtonList"))) Then
                PagingRadioButtonList = Server.HtmlEncode(Request("PagingRadioButtonList").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("pagerowcnt"))) Then
                pagerowcnt = Integer.Parse(Server.HtmlEncode(Request("pagerowcnt")))
            End If
            PrintBtn_Click(ReceiveS, _
                           ReceiveE, _
                           Material_idS, _
                           Material_idE, _
                           User_name, _
                           ApplyRadioButton, _
                           OrgCodeDropDownList, _
                           SortRadioButtonList, _
                           PagingRadioButtonList, _
                           pagerowcnt)
        End If
    End Sub
#End Region


#Region " 列印"
    Protected Sub PrintBtn_Click(ByVal ReceiveS As String, _
                                 ByVal ReceiveE As String, _
                                 ByVal Material_idS As String, _
                                 ByVal Material_idE As String, _
                                 ByVal User_name As String, _
                                 ByVal ApplyRadioButton As String, _
                                 ByVal OrgCodeDropDownList As String, _
                                 ByVal SortRadioButtonList As String, _
                                 ByVal PagingRadioButtonList As String, _
                                 ByVal pagerowcnt As Integer)

        Dim dt As New DataTable
        Dim mc As MAT2102 = New MAT2102()
        Dim theDTReport As CommonLib.DTReport
        Dim strParam(3) As String '宣告字串陣列
        Dim TitleName As String = IIf(ApplyRadioButton.Equals("001"), "個人領用物品", "單位領用物品")

        dt = mc.MAT2102SelectData(ApplyRadioButton, _
                                SortRadioButtonList, _
                                Material_idS, _
                                Material_idE, _
                                ReceiveS, _
                                ReceiveE, _
                                OrgCodeDropDownList, _
                                User_name)

        Dim group(1) As String
        If PagingRadioButtonList = "0" Then '依單位分頁
            group(0) = "Unit_name"
            group(1) = "Unit_name"
        ElseIf PagingRadioButtonList = "1" Then '依員工分頁
            group(0) = "User_id"
            group(1) = "User_name"
        ElseIf PagingRadioButtonList = "2" Then '依物品編號分頁
            group(0) = "Material_id"
            group(1) = "Material_name"
        End If

        strParam(0) = Server.HtmlEncode(Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")) '製表日期
        strParam(1) = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)) '製表人
        strParam(2) = ReceiveS + "至" + ReceiveE '領用日期起~迄
        strParam(3) = TitleName

        theDTReport = New CommonLib.DTReport(Server.MapPath("~/Report/MAT/MAT2102_" & PagingRadioButtonList & ".mht"), dt)
        theDTReport.Param = strParam
        theDTReport.ExportFileName = TitleName

        theDTReport.PageGroupColumns = group
        theDTReport.PageGroupKeyColumns = group

        theDTReport.ExportToWord()
        dt.Dispose()
    End Sub

#End Region
End Class


