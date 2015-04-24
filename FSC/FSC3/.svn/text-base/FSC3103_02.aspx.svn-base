<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC3103_02.aspx.vb" Inherits="FSC3103_02" %>
<%@ Register src="../../UControl/UcMember.ascx" tagname="UcMember" tagprefix="uc1" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
                直屬主管設定</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                人員姓名</td>
            <td class="htmltable_Right" style="width: 230px">
                <asp:Label ID="lbName" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                服務類別</td>
            <td class="htmltable_Right" style="width: 230px">
                <asp:DropDownList ID="ddlServiceType" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                主管機關</td>
            <td class="htmltable_Right" style="width: 230px"> 
                <asp:DropDownList ID="ddlOrg" runat="server" ></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                主管單位</td>
            <td class="htmltable_Right" style="width: 230px">
                <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                主管姓名</td>
            <td class="htmltable_Right" >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <contenttemplate>
                <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                    </contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                &nbsp;<asp:Button ID="btnConfrim" runat="server" Text="確定" />
                <asp:Button ID="btnCancel" runat="server" text="取消"/>
            </td>
        </tr>
    </table>
</asp:Content>
