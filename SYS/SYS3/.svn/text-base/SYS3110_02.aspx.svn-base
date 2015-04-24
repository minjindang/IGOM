<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3110_02.aspx.vb" Inherits="SYS3110_02"  %>

<%@ Register Src="~/UControl/UCTabButton.ascx" TagPrefix="uc1" TagName="UCTabButton" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" runat="server" id="Table1">
       <tr>
            <td class="htmltable_Left">
                假別類型
            </td>
            <td class="htmltable_Right">           
                <asp:DropDownList ID="ddlleaveGroup" runat="server" autopostback="true">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                假別
            </td>
            <td class="htmltable_Right">           
                <asp:DropDownList ID="ddlLeaveType" runat="server">
                </asp:DropDownList></td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" runat="server" id="Table2">
       <tr>
            <td class="htmltable_Title" colspan="2">
                自訂表單設定</td>
       </tr>
        <tr>
            <td class="htmltable_Left">
                備註
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbMark" runat="server"></asp:TextBox>          
            </td>
        </tr>
        <%--<tr>
            <td class="htmltable_Left">
                假別說明
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbExplanation" runat="server"></asp:TextBox>          
            </td>
        </tr>--%>
        <tr>
            <td class="htmltable_Left">
                是否適用
            </td>
            <td class="htmltable_Right">
                表單條件           
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                <asp:CheckBox ID="cbIsApply" runat="server" checked="true" Enabled="false"/>
            </td>
            <td class="htmltable_Right">
                表單申請人           
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                <asp:CheckBox ID="cbIsApllyDate" runat="server" checked="true" Enabled="false"/>
            </td>
            <td class="htmltable_Right">
                申請時間           
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                <asp:CheckBox ID="cbIsApllyDateSE" runat="server" checked="true" Enabled="false"/>
            </td>
            <td class="htmltable_Right">
                申請時間           
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                <asp:CheckBox ID="cbIsReason" runat="server" checked="true" Enabled="false"/>
            </td>
            <td class="htmltable_Right">
                申請事由           
            </td>
        </tr>
        <%--<tr>
            <td class="htmltable_Left">
                <asp:CheckBox ID="cbIsDetail" runat="server" checked="true" Enabled="false"/>
            </td>
            <td class="htmltable_Right">
                摘要說明           
            </td>
        </tr>--%>
        <tr>
            <td class="htmltable_Left">
                <asp:CheckBox ID="cbIsAttach" runat="server" checked="true" Enabled="false"/>
            </td>
            <td class="htmltable_Right">
                附件           
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                <asp:CheckBox ID="cbIsCustom1" runat="server"/>
            </td>
            <td class="htmltable_Right">
                自訂欄位1           
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" colspan="2">
                表單管理者
            </td>
        </tr>
        <tr>
            <td class="htmltable_Right" colspan="2">
                <asp:CheckBoxList ID="cblRoleName" runat="server">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <asp:Button ID="cbConfirm" runat="server" Text="確認" />
                <input id="cbReset" type="button" value="重填" />
                <input id="cbAdd" type="button" value="取消" onclick="document.location.href = 'SYS3110_01.aspx'" />
                <asp:Button ID="cbCopy" runat="server" Text="複製" /><asp:Label ID="isCopy" runat="server" visible="false" />
            </td>
        </tr>
    </table>
</asp:Content>