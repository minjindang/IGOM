<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL2118_01.aspx.cs" Inherits="SAL_SAL2_SAL2118" %>

<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc3" %>
<%@ Register Src="../../UControl/SAL/UcSelectOrg.ascx" TagName="UcSelectOrg" TagPrefix="uc4" %>
<%@ Register src="../../UControl/SAL/ucDateTextBox.ascx" tagname="ucDateTextBox" tagprefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

            <table class="tableStyle99" width="100%">
                <tr>
                    <td class="htmltable_Title" colspan="4">
                        員工所得資料查詢
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        單位別
                    </td>
                    <td class="htmltable_Right">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate><uc4:UcSelectOrg ID="cmb_uc_Org" runat="server" ShowMulti="True" /></ContentTemplate>
                        </asp:UpdatePanel>
                        
                    </td>
                    <td showmulti="True" class="htmltable_Left">
                        員工姓名
                    </td>
                    <td class="htmltable_Right">
                        <asp:TextBox ID="txtUserName" runat="server" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        人員類別
                    </td>
                    <td class="htmltable_Right">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate><uc3:ucSaCode ID="cmb_uc_UserType" runat="server" Code_Kind="P" Code_sys="002" Code_type="017"
                            ControlType="2" Mode="query" ShowMulti="True" /></ContentTemplate>
                        </asp:UpdatePanel>
                        
                    </td>
                    <td class="htmltable_Left">
                        員工編號
                    </td>
                    <td class="htmltable_Right">
                        <asp:TextBox ID="txtUserNO" runat="server" MaxLength="6"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="htmltable_Left">
                        發放種類
                    </td>
                    <td class="htmltable_Right">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                        <uc3:ucSaCode ID="cmb_uc_itemType" runat="server" Code_Kind="P" Code_sys="003" Code_type="005"
                            ControlType="2" />
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        
                    </td>
                    <td class="htmltable_Left">
                        <asp:UpdatePanel ID="upnl_OtherItemLabel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate><asp:Label ID="lblItemName" runat="server" Text="項目" Visible="False"></asp:Label></ContentTemplate>
                        </asp:UpdatePanel>
                        
                    </td>
                    <td class="htmltable_Right">
                        <asp:UpdatePanel ID="upnl_OtherItems" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <asp:DropDownList ID="cmbOtherItems" runat="server" Visible="False">
                        </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>


                <tr>
                    <td class="htmltable_Left"><span style="color: Red">*</span>
                        發放日期
                    </td>
                    <td class="htmltable_Right" colspan="3">
                        <uc2:UcDate ID="ucDatePay" runat="server" />
                        
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                        <asp:Button ID="Button_report" runat="server" Text="匯出" OnClick="Button_report_Click" />
                        <asp:Button ID="Button1" runat="server" Text="重置" onclick="Button1_Click"  Visible="false"/>
                    </td>
                </tr>
            </table>

</asp:Content>
