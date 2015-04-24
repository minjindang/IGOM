<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT2106_01.aspx.vb" Inherits="MAT2106_01" %>

<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc2" %>
<%--<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc3" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>--%>
<%@ Register Src="~/UControl/MAT/UcDDLMatDepart.ascx" TagPrefix="uc1" TagName="UcDDLMatDepart" %>
<%@ Register Src="~/UControl/MAT/ucDDLMatMember.ascx" TagPrefix="uc1" TagName="ucDDLMatMember" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">領用物品明細表</td>
        </tr>
        <tr>
            <td class="htmltable_Left">查詢類別                    
            </td>
            <td style="width: 326px" colspan="3" runat="server" id="tdType">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <uc2:ucSaCode ID="ucType"  runat="server" Code_sys='014' Code_type='001' ControlType="RadioButtonList" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 100px; height: 19px;">單位別
            </td>
            <td class="TdHeightLight" style="width: 250px; height: 19px;">
        <%--        <uc1:UcDDLDepart runat="server" ID="ddlDepart_id" />--%>
                <uc1:UcDDLMatDepart runat="server" ID="ddlDepart_id" />
            </td>

        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 100px">員工姓名</td>
            <td class="htmltable_Right" style="width: 250px">
             <%--   <uc3:UcDDLMember runat="server" ID="ddlUser_name" />--%>
                <uc1:ucDDLMatMember runat="server" ID="ddlUser_name" />
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

