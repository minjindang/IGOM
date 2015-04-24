<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="SAL2117_01.aspx.vb" Inherits="SAL2117_01" %>

<%@ Register Src="~/UControl/SAL/ucDateTextBox.ascx" TagName="ucDateTextBox" TagPrefix="uc4" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc1" %>
<%@ Register Src="~/UControl/SAL/ucSaProj.ascx" TagName="ucSaProj" TagPrefix="uc2" %>
<%@ Register Src="~/UControl/SAL/ucDateDropDownList.ascx" TagName="ucDateDropDownList"
    TagPrefix="uc3" %>    
<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc3" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <table class="tableStyle99" border="0" cellspacing="0" cellpadding="0" style="line-height: 160%; width: 100%">
        <tr>
            <td class="htmltable_Title" colspan="4">
                技工工友調整工餉發放清冊
            </td>
        </tr>                
        <tr>
            <td class="htmltable_Left">
                人員類別
            </td>
            <td align="left" class="htmltable_Right">
            <%--   <uc2:ucSaProj ID="UcSaProj_proj_code" runat="server" Mode="query" />--%>
                    <asp:DropDownList ID="ddlsaproj" runat="server">
                    <asp:ListItem Text="技工工友" Value="006"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="htmltable_Left">
                發放年月
            </td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <uc3:ucDateDropDownList ID="UcDateDropDownList_YM_Start" Kind="005" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
            <tr>
            <td class="htmltable_Left">
                預算來源
            </td>
            <td class="htmltable_Right" colspan = "3" > 
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <uc3:ucSaCode ID="ddl_Budget_code" runat="server" Code_Kind="P" Code_sys="002" Code_type="018"
                            ControlType="2" Mode="query" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>   
            </tr>                       
        <tr>
            <td colspan="4" class="htmltable_Bottom">
                <asp:Button ID="Button_reportCover" runat="server" Text="列印" CssClass="button" />
<%--                    <asp:Button ID="Button_reportCover" runat="server" Text="列印封面" CssClass="button" />--%>
                <asp:Literal ID="Literal1" runat="server" Visible="false" ></asp:Literal>
            </td>
        </tr>
    </table>
          
    <div id="div_info" runat="server" style="display: none">
        ORGID=<asp:TextBox ID="TextBox_orgid" runat="server"></asp:TextBox><br />
        MID=<asp:TextBox ID="TextBox_mid" runat="server"></asp:TextBox><br />
    </div>
</asp:Content>
