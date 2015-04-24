<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FSC3112_04.aspx.vb" Inherits="FSC3112_04" %>
<%@ Import Namespace="FSCPLM.Logic" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    body {
	    background-color: #FFFFFF;
	    margin: 0px;
	    font-size:15px;
	    font-family: 微軟正黑體,Microsoft JhengHei;
	    font-weight: bold;
	    font-size: 10pt;
    }
    .tableStyle99 {
	    margin: 1px 0px 1px 0px;
	    background-color: #FFFFFF;
	    border-collapse: collapse;
	    color: #000000;
	    padding: 1px;
	    border: 1px solid #C5C386;
	    font-family: 微軟正黑體,Microsoft JhengHei, Arial, Helvetica, Verdana, sans-serif;
    }
    .tableStyle99 th {
	    height: 22px;
	    color: #000000;
	    font-family: 微軟正黑體,Microsoft JhengHei,Arial, Helvetica, Verdana, sans-serif;
	    text-align: center;
	    font-weight: normal;
	    background-color: #FBE983;
	    border: 1px solid #C87E06;
    }
    .tableStyle99 td {
	    border: 1px solid #C5C386;
	    padding: 1px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:794px; margin: 0px auto;">
        <%
            Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            Dim departid As String = Request.QueryString("did")
            Dim idcard As String = Request.QueryString("id")
            Dim yyymm As String = Request.QueryString("ym")
            Dim scheduleId As String = Request.QueryString("sid")
            Dim quitJobFlag As String = Request.QueryString("qjflag")
            Dim employeeType As String = Request.QueryString("et")
            Dim target As String = Request.QueryString("t")
            Dim bll As New FSC.Logic.FSC3112()
            Dim org As New FSC.Logic.Org()

            Dim dt As DataTable = bll.GetData(orgcode, departid, idcard, yyymm, scheduleId, quitJobFlag, employeeType, target)
            
            
        %>
        <table width="100%">
            <tr>
                <td align="center" style="font-size:large;" colspan="7">
                    <%=org.GetOrgcodeName(orgcode) & "  " & yyymm.Substring(0, 3) & " 年 " & yyymm.Substring(3) & " 月  值日輪值表"%>
                </td>
            </tr>
        </table>

        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
            <tr>
                <td align="center">日</td>
                <td align="center">一</td>
                <td align="center">二</td>
                <td align="center">三</td>
                <td align="center">四</td>
                <td align="center">五</td>
                <td align="center">六</td>
            </tr>
            <%
                Dim sdate As Date = DateTimeInfo.GetPublicDate(yyymm & "01")
                
                Response.Write("<tr>")
                
                Dim w As Integer = 0
                For w = 0 To 6
                    Dim week As Integer = sdate.DayOfWeek()
                    
                    Response.Write("<td style='width:14%; height:120px;' valign='top'>")
                    
                    If w = week Then
                        
                        Response.Write(sdate.Day & "<br/>")
                        
                        Dim rs() As DataRow = dt.Select(" sche_date=" & DateTimeInfo.GetRocDate(sdate))
                        
                        For Each r As DataRow In rs
                            Dim s As New StringBuilder()
                            s.Append(org.GetDepartName(orgcode, r("depart_id").ToString())).Append("<br/>")
                            s.Append(r("name")).Append(":").Append(r("user_name").ToString()).Append("<br/>")
                            Response.Write(s.ToString())
                        Next
                                                    
                        sdate = sdate.AddDays(1)
                    End If
                    
                    Response.Write("</td>")
                    
                    
                    If sdate.Month <> CommonFun.getInt(yyymm.Substring(3)) Then
                        Exit For
                    End If
                    
                    If w = 6 Then
                        Response.Write("</tr>")
                        Response.Write("<tr>")
                        w = -1
                    End If
                    
                Next
                    
                For x As Integer = w + 1 To 6
                    Response.Write("<td>")
                    Response.Write("</td>")
                Next
                Response.Write("</tr>")
                
            %>

        </table>   
         
        <table width="100%">
            <tr>
                <td valign="top" style="width:70px;">
                    備值人員:</td>
                <td valign="top">
                    <%=GetPreData(yyymm)%>
                </td>
            </tr>
        </table>

        <table>
            <tr>
                <td colspan="3">
                    備註:</td>
            </tr>
            <tr>
                <td valign="top">
                    一、</td>
                <td valign="top" colspan="2">
                    請確實按照排定日期實施輪值，因故請他人代或換值時應於二日前將值日代(換)單送人事室登錄。值日時請先詳閱值日要點；另值日人員於值日前，請先接值人員連絡，以避免有漏接情事。
                </td>
            </tr>
            <tr>
                <td valign="top">
                    二、</td>
                <td valign="top">                    
                    輪值交接時間：
                </td>
                <td valign="top">
                    (一)平常日(週一至週五)時間為每日上午八時三十分。<br/>
                    (二)例假日分日、夜兩班、日班為上午八時三十分，夜班下午五時三十分。
                </td>
            </tr>
            <tr>
                <td valign="top">
                    三、</td>
                <td valign="top" colspan="2">   
                    週一至週五值日人員下午五時三十分及例假日均應至一樓值日室值日，非用餐交錯時間，不得壇離崗亭，至晚上十時始可至值日休息室休息，以確保門禁安全，壇離職守者從嚴議處。
                </td>
            </tr>  
            <tr>
                <td valign="top">
                    四、</td>
                <td valign="top" colspan="2">   
                    值日人員平時於下班時間收到公文掛信、快遞或包裏時應立即登記在收文登記簿上並於信封上加蓋收文章，交班時應親自將所收信件交文書科或接班人當面簽收。
                </td>
            </tr>  
            <tr>
                <td valign="top">
                    五、</td>
                <td valign="top" colspan="2">   
                    值日人員離開值日室或休息室時均立即將門窗鎖上，以防值日室物品失竊。
                </td>
            </tr>  
            <tr>
                <td valign="top">
                    六、</td>
                <td valign="top" colspan="2">   
                    值日補休於次日起六個月內(不扣除例假日)補休完畢；補休可以時計；逾期視同棄權。
                </td>
            </tr>     
        </table>
    </div>
    </form>
</body>
</html>
<%
    Dim yyymm As String = Request.QueryString("ym")
    HttpContext.Current.Response.ContentType = "Application/msword"
    HttpContext.Current.Response.AddHeader("Content-disposition", "attachment; filename=" & yyymm & HttpUtility.UrlEncode("值日輪值表", Encoding.UTF8) & ".doc")
    HttpContext.Current.Response.End()
 %>