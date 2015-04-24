<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL2111_01.aspx.cs" Inherits="SAL_SAL2_SAL2111" %>
<%@ Register Src="~/UControl/UcROCYearMonth.ascx" TagName="UcROCYearMonth" TagPrefix="uc2" %>
<%@ Register src="../../UControl/SAL/ucSaCode.ascx" tagname="ucSaCode" tagprefix="uc3" %>
<%@ Register src="../../UControl/SAL/ucDateDropDownList.ascx" tagname="ucDateDropDownList" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

            <table class="tableStyle99" width="100%">
                <tr>
                    <td class="htmltable_Title" colspan="4">與上月薪資發放比較
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">人員類別</td>
                    <td class="htmltable_Right">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate><uc3:ucSaCode ID="cmb_uc_UserType" runat="server"  Code_Kind="P" Code_sys="002"
                            Code_type="017" ControlType="2" Mode="query" ShowMulti="True" /></ContentTemplate>
                        </asp:UpdatePanel>
                        

                    </td>
                    <td class="htmltable_Left">發放年月</td>
                    <td class="htmltable_Right" style="width: 326px">
                         
                        <uc4:ucDateDropDownList ID="UcDate1" runat="server" Kind="YM" />
                        
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">預算來源
                    </td>
                    <td class="htmltable_Right" style="width: 326px" colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <uc3:ucSaCode ID="cmbBudget" runat="server"  Code_Kind="P" Code_sys="002"
                            Code_type="018" ControlType="2" Mode="query" /></ContentTemplate>
                        </asp:UpdatePanel>
                        

                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                        <asp:Button ID="Button_report" runat="server" Text="列印" 
                            onclick="Button_report_Click" />
                    </td>
                </tr>

            </table>

            <div id="div_info" runat="server" style="display: none">
                ORGID=<asp:TextBox ID="TextBox_orgid" runat="server"></asp:TextBox><br />
                MID=<asp:TextBox ID="TextBox_mid" runat="server"></asp:TextBox><br />
            </div>
 

</asp:Content>

