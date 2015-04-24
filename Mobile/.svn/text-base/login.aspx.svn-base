<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Mobile_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/Mobile/scripts/jquery.mobile-1.3.2.css")%>">
    <script src="<%= Page.ResolveClientUrl("~/Mobile/scripts/jquery-1.9.1.min.js")%>"></script>
    <script src="<%= Page.ResolveClientUrl("~/Mobile/scripts/jquery.mobile-1.3.2.min.js")%>"></script>
    <!--<link rel="stylesheet" href="http://code.jquery.com/mobile/1.3.2/jquery.mobile-1.3.2.min.css">
<script src="http://code.jquery.com/jquery-1.8.3.min.js"></script>
<script src="http://code.jquery.com/mobile/1.3.2/jquery.mobile-1.3.2.min.js"></script>-->
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <script type='text/javascript'>
        function getDeviceID(DeviceID,DeviceType) {
            var elem = document.getElementById("txtDeviceID");
            elem.value = DeviceID;
            var elem2 = document.getElementById("txtDeviceType");
            elem2.value = DeviceType;
            //alert('This is alert dialog');
        }
    </script>
</head>
<body leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
        <div data-role="page" data-theme="b">
            <table width="100%" height="50" bgcolor="#3F74D1">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblPageTitle" runat="server" Text="IGOM 登入" Font-Size="26px" ForeColor="White"></asp:Label></td>
                </tr>
            </table>
            <table width="90%" cellpadding="1" align="center">
                <tr>
                    <td>帳號</td>
                    <td>
                        <asp:TextBox ID="txtAcc" runat="server" MaxLength="10" Text=""></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>密碼</td>
                    <td>
                        <asp:TextBox ID="txtPass" runat="server" MaxLength="12" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <%--<tr>
                                <td style="height:2px;"></td>
                                <td>
                                    <asp:TextBox ID="tbcode" runat="server" Width="80px" MaxLength="5"></asp:TextBox>
                                    <asp:Image ID="Image1" runat="server" ImageUrl="ValidateCode.ashx" ImageAlign="Top" />
                                </td>
                            </tr>--%>
                <tr>
                    <td height="250">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <%--<a href="user_guide.doc"><span style="font-size:15px;">使用者手冊</span></a>--%>
                        <asp:Button UseSubmitBehavior="False" ID="Button1" runat="server" OnClick="Button1_Click" Text="確定" ToolTip="登入整合性總務作業管理資訊系統" />
                        &nbsp;&nbsp;
                        
                    </td>
                </tr>


            </table>
            <div style="display:none">
                <asp:TextBox ID="txtDeviceID" runat="server" Text=""></asp:TextBox>
                <asp:TextBox ID="txtDeviceType" runat="server" Text=""></asp:TextBox>
            </div>
        </div>
    </form>
</body>
</html>
