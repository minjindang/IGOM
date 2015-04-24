<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="SYS3106_02.aspx.vb" Inherits="SYS3106_02" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border = "0" cellpadding = "0" cellspacing = "0" width = "100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
            角色權限控管</td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                角色代號
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="txtRole_id" runat="server"></asp:TextBox>
            </td>
            <td class="htmltable_Left">
                角色名稱
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="txtRole_name" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                是否為管理者
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlManager_flag" runat="server">
                    <asp:ListItem Value="N">否</asp:ListItem>
                    <asp:ListItem Value="Y">是</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="htmltable_Left">
                目前狀態
            </td>
            <td class="htmltable_Right" colspan="3">
                <asp:DropDownList ID="ddlRole_status" runat="server">
                    <asp:ListItem Value="1">正常</asp:ListItem>
                    <asp:ListItem Value="2">停用</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                上層管理者
            </td>
            <td class="htmltable_Right" colspan="3">
                <asp:DropDownList ID="ddlBoss_Role" runat="server" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4">
                <asp:Button ID="btnAdd" runat="server" Text="確認" /><asp:Button ID="cbBack" runat="server"
                    Text="回上頁" /></td>
        </tr>
    </table>
</asp:Content>
