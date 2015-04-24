<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="Mobile_main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/Mobile/scripts/jquery.mobile-1.3.2.css")%>">
    <script src="<%= Page.ResolveClientUrl("~/Mobile/scripts/jquery-1.9.1.min.js")%>"></script>
    <script src="<%= Page.ResolveClientUrl("~/Mobile/scripts/jquery.mobile-1.3.2.min.js")%>"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" height="50" bgcolor="#3F74D1">
                
                <tr>
                    <td width="20%"></td>
                    <td align="center">
                        <asp:Label ID="lblPageTitle" runat="server" Text="IGOM" Font-Size="26px" ForeColor="White"></asp:Label></td>
                    <td width="20%" align="center">                        <asp:Button ID="btnLogout" runat="server" Text="登出" UseSubmitBehavior="False" OnClick="btnLogout_Click" />
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="5">
                <tr>
                    <td width="33%">
                        <asp:LinkButton ID="lnk1201" runat="server" OnClick="LinkButton1_Click1">
                            <asp:Image ID="Image1" runat="server" ImageUrl="images/1201.png" AlternateText="一般請假" Width="100%" /></asp:LinkButton>
                    </td>


                    <td width="33%">
                        <asp:LinkButton ID="lnk1202" runat="server" OnClick="lnk1202_Click">
                            <asp:Image ID="Image2" runat="server" ImageUrl="images/1202.png" AlternateText="申請公差" Width="100%" /></asp:LinkButton>
                      </td>
                    <td width="33%">
                        <asp:LinkButton ID="lnk1203" runat="server" OnClick="lnk1203_Click" >
                            <asp:Image ID="Image3" runat="server" ImageUrl="images/1203.png" AlternateText="加班費請領" Width="100%" /></asp:LinkButton>
                        </td>
                </tr>

                <tr>
                    <td width="33%">
                        <asp:LinkButton ID="lnk1204" runat="server" OnClick="lnk1204_Click">
                            <asp:Image ID="Image4" runat="server" ImageUrl="images/1204.png" AlternateText="加班費請領(適用勞基法)" Width="100%" /></asp:LinkButton>
                    </td>


                    <td>
                        <asp:LinkButton ID="lnk2201" runat="server" OnClick="lnk2201_Click">
                            <asp:Image ID="Image5" runat="server" ImageUrl="images/2201.png" AlternateText="出勤記錄(異常)查詢" Width="100%" /></asp:LinkButton>
                      </td>
                    <td width="33%">
                        <asp:LinkButton ID="lnk2202" runat="server" OnClick="lnk2202_Click" >
                            <asp:Image ID="Image6" runat="server" ImageUrl="images/2202.png" AlternateText="請假記錄查詢" Width="100%" /></asp:LinkButton>
                        </td>
                </tr>

                <tr>
                    <td width="33%">
                        <asp:LinkButton ID="lnk2203" runat="server" OnClick="lnk2203_Click">
                            <asp:Image ID="Image7" runat="server" ImageUrl="images/2203.png" AlternateText="加班記錄查詢" Width="100%" /></asp:LinkButton>
                    </td>


                    <td>
                        <asp:LinkButton ID="lnk2204" runat="server" OnClick="lnk2204_Click">
                            <asp:Image ID="Image8" runat="server" ImageUrl="images/2204.png" AlternateText="公差紀錄查詢" Width="100%" /></asp:LinkButton>
                      </td>
                    <td width="33%">
                        <asp:LinkButton ID="lnk0204" runat="server" OnClick="lnk0204_Click" >
                            <asp:Image ID="Image9" runat="server" ImageUrl="images/0204.png" AlternateText="待辦/待核清單" Width="100%" /></asp:LinkButton>
                        </td>
                </tr>

            </table>


            <table width="100%" runat="server" Visible="false">
                <tr>
                    <td>
                        <asp:Button UseSubmitBehavior="False" ID="btnMob0204" runat="server" Text="待辦/核案件" OnClick="btnMob0204_Click" />
                        <asp:Button UseSubmitBehavior="False" ID="btnMob1201" runat="server" Text="一般請假" OnClick="btnMob1201_Click" />
                        <asp:Button UseSubmitBehavior="False" ID="btnMob1202" runat="server" Text="申請公差" OnClick="btnMob1202_Click" />
                        <asp:Button UseSubmitBehavior="False" ID="btnMob1203" runat="server" Text="加班費請領" OnClick="btnMob1203_Click" />
                        <asp:Button UseSubmitBehavior="False" ID="btnMob1204" runat="server" Text="加班費請領(適用勞基法)" OnClick="btnMob1204_Click" />
                        <asp:Button UseSubmitBehavior="False" ID="btnMob2201" runat="server" Text="出勤記錄異常查詢"
                            OnClick="btnMob2201_Click" />
                        <asp:Button ID="btnMob2202" runat="server" Text="請假記錄查詢" UseSubmitBehavior="False" OnClick="btnMob2202_Click" />
                        <asp:Button ID="btnMob2203" runat="server" Text="加班記錄查詢" UseSubmitBehavior="False" OnClick="btnMob2203_Click" />
                        <asp:Button ID="btnMob2204" runat="server" Text="公差記錄查詢" UseSubmitBehavior="False" OnClick="btnMob2204_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
