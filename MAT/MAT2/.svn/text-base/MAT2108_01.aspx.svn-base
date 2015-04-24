<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT2108_01.aspx.vb" Inherits="MAT2108_01" %>
<%@ Register Src="~/UControl/MAT/UcMaterialId.ascx" TagPrefix="uc1" TagName="UcMaterialClass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">單項物品領用統計年報表
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">物料編號
            </td>
            <td colspan="3">
        <%--        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate> 
                </ContentTemplate>
                </asp:UpdatePanel>--%> 
                 
                        <asp:TextBox ID="tbMaterial_id1" runat="server" Width="120px" Text="" MaxLength="9"></asp:TextBox>
                        <uc1:UcMaterialClass runat="server" ID="MATselect1" OnChecked="UcMaterialClassB_Checked" />
                        &nbsp;&nbsp;~&nbsp;&nbsp;
			            <asp:TextBox ID="tbMaterial_id2" runat="server" Width="120px" Text="" MaxLength="9"></asp:TextBox>
                        <uc1:UcMaterialClass runat="server" ID="MATselect2" OnChecked="UcMaterialClassE_Checked" />
                 
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">統計年度
            </td>
            <td colspan="3">
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                     <ContentTemplate>
                         民國<asp:DropDownList ID="ddlyear" runat="server" AutoPostBack="true" />年
                     </ContentTemplate>
                 </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                <asp:Button ID="PrintBtn" runat="server" Text="列印" />
                <asp:Button ID="ResetBtn" runat="server" Text="清空重填" />
            </td>
        </tr>
    </table>

</asp:Content>

