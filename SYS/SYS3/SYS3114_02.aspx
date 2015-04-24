<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3114_02.aspx.vb" Inherits="SYS3114_02"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                常用片語設定</td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                 <span style="color: #ff0000">*</span>申請種類
            </td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList runat="server" ID="ddlphrases_kind" DataTextField="CODE_DESC1" DataValueField="CODE_NO" AutoPostBack="true" ></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                <span style="color: #ff0000">*</span>申請項目
            </td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList runat="server" ID="ddlphrases_type" DataTextField="CODE_DESC1" DataValueField="CODE_NO" AutoPostBack="true" ></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                <span style="color: #ff0000">*</span>常用片語</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbphrases" runat="server"></asp:TextBox></td>
        </tr>
        
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 <span style="color: #ff0000">*</span>是否啟用</td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlvisable_flag" runat="server">
                    <asp:ListItem value="1" Selected="True">啟用</asp:ListItem>
                    <asp:ListItem value="0">停用</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <asp:Button ID="cbConfirm" runat="server" Text="確認" />
                <input id="cbReset" type="button" value="重填" />
                <asp:Button ID="cbCancel" runat="server" Text="取消" />
                </td>
        </tr>
    </table>
    <br />
   
    </asp:Content>

