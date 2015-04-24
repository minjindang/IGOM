<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FSC3114_01.aspx.vb" Inherits="FSC3114_01" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="<%= Page.ResolveClientUrl("~/CSS/css.css")%>" rel="stylesheet" type="text/css" /> 
    <link href="<%= Page.ResolveClientUrl("~/CSS/syntegra3.css")%>" rel="stylesheet" type="text/css" /> 
    <link rel="stylesheet" type="text/css" media="all" href="<%= Page.ResolveClientUrl("~/css/aqua.css")%>" />     
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/js/jquery-1.4.2.min.js") %>"></script>  
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/js/jquery.blockUI.js")%>"></script>   
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/js/jquery.maxlength.js")%>"></script>   
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/js/jquery-ui-1.8.18.custom.min.js")%>"></script>   
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/js/DgJScript.js")%>"></script>     
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/js/utils.js")%>"></script>        
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/js/roc.js")%>"></script>          
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/js/CalendarPopup.js")%>"></script>     
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/js/function.js")%>"></script>     
    <link type="text/css" href="<%= Page.ResolveClientUrl("~/CSS/smoothness/jquery-ui-1.8.18.custom.css")%>" rel="stylesheet" /> 
</head>
<body onload="showMsg();">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <input type="hidden" id="alertMsg" />  
        <input type="hidden" id="callback" /> 
        <table width="100%" class="tableStyle99">
            <tr>
                <td class="htmltable_Title" colspan="2">線上刷卡作業</td>
            </tr>
            <tr>
                <td class="htmltable_Left"><span style="color:red">*</span>AD帳號</td>
                <td class="htmltable_Right">                
                    <asp:TextBox ID="tbAD_id" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left"><span style="color:red">*</span>刷卡日期</td>
                <td class="htmltable_Right">                
                    <uc1:UcDate runat="server" ID="UcDate" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left"><span style="color:red">*</span>刷卡別</td>
                <td class="htmltable_Right">                
                    <asp:RadioButton ID="rbType1" runat="server" GroupName="PHITYPE" Checked="true" />上班卡
                    <asp:RadioButton ID="rbType2" runat="server" GroupName="PHITYPE" />下班卡
                </td>
            </tr>
            <tr>
                <td colspan="2" class="htmltable_Bottom">
                    <asp:Button ID="btnRun" runat="server" Text="確定" />
                </td>
            </tr>
        </table>
    </div>
    <div style='text-align:center'>
        <span id="Clock" style="font-size:3.5cm;"></span>
    </div>
    <script type="text/javascript">
        function tick() {
            var today;
            today = new Date();
            Clock.innerHTML = today.toLocaleTimeString();
            window.setTimeout("tick()", 1000);
        }
        tick();
    </script>
    </form>
</body>
</html>
