<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT4103_01.aspx.vb" Inherits="MAT4103_01" %>

<%@ Register Src="~/UControl/MAT/UcMaterialId.ascx" TagPrefix="uc1" TagName="UcMaterialId" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">物料編號調整作業
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">原物料編號
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtMaterial_id" runat="server" AutoPostBack="true" ></asp:TextBox>
                <uc1:UcMaterialId runat="server" ID="UcMaterialId" OnChecked="UcMaterialId_Checked" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">物料名稱
            </td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtMaterial_name" runat="server" Enabled="false"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">單位
            </td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtUnit" runat="server" Enabled="false"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">新物料編號
            </td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlMaterialClass_id" runat="server" AutoPostBack="true"></asp:DropDownList>
                        <asp:TextBox ID="txtNewMaterial_id" runat="server"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <div align="center">
        <asp:Button ID="SaveBtn" runat="server" Text="存檔" />
        <asp:Button ID="RestoreBtn" runat="server" Text="清空重填" />
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
            <br />
            <asp:Button ID="btnY" runat="server" Text="是" Visible="False" />
            <asp:Button ID="btnN" runat="server" Text="否" Visible="False" />
        </asp:Panel>
    </div>
</asp:Content>

