<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL2116_01.aspx.cs" Inherits="SAL_SAL2_SAL2116_01" %>

<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/UcROCYearMonth.ascx" TagName="UcROCYearMonth" TagPrefix="uc3" %>
<%@ Register src="../../UControl/SAL/ucDateDropDownList.ascx" tagname="ucDateDropDownList" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">
                每月所得統計表
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="uPnlStep1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlStep1" runat="server">
                <table class="tableStyle99" width="100%">
                    <tr>
                        <td colspan="4">
                            第一步：設定薪資向募集薪資年月
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            發放種類
                        </td>
                        <td class="htmltable_Right">
                            <uc2:ucSaCode ID="cmb_uc_PayType" runat="server" Code_Kind="P" Code_sys="003" Code_type="005"
                                ControlType="2" />
                        </td>
                        <td class="htmltable_Left">
                            薪資年月
                        </td>
                        <td class="htmltable_Right">
                            
                            <uc4:ucDateDropDownList ID="cmb_uc_YearMonth" runat="server" Kind="YM" 
                                title="民國" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" class="htmltable_Bottom">
                            <asp:Button ID="btnStep1Next" runat="server" Text="下一步" OnClick="Button1_Click" /><asp:Button
                                ID="Button2" runat="server" Text="重置" OnClick="Button2_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upnlStep2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlStep2" runat="server" Visible="False">
                <table class="tableStyle99" width="100%">
                    <tr>
                        <td colspan="4">
                            第二步：選擇其他應發代扣項
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            項目種類
                        </td>
                        <td class="htmltable_Right">
                            <uc2:ucSaCode ID="cmb_uc_ItemType" runat="server" Code_Kind="D" Code_sys="005" Code_type="001"
                                ControlType="2" ReturnEvent="True" />
                        </td>
                        <td class="htmltable_Left">
                            項目名稱
                        </td>
                        <td class="htmltable_Right">
                            <asp:DropDownList ID="cmb_ItemName" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" class="htmltable_Bottom">
                            <asp:Button ID="Button5" runat="server" Text="上一步" OnClick="Button5_Click" />
                            <asp:Button ID="Button3" runat="server" Text="下一步" OnClick="Button3_Click" />
                            <asp:Button ID="Button4" runat="server" Text="重置" onclick="Button4_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:UpdatePanel ID="upnlStep3" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="pnlStep3" runat="server" Visible="False">
                        <table class="tableStyle99" width="100%">
                            <tr>
                                <td colspan="4">
                                    第三步：設定發放日期及列印方式
                                </td>
                            </tr>
                            <tr>
                                <td class="htmltable_Left">
                                    發放日期
                                </td>
                                <td class="htmltable_Right" colspan="3">
                                    <asp:DropDownList ID="cmbDateStep3" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" class="htmltable_Bottom">
                                    <asp:Button ID="Button1" runat="server" Text="上一步" OnClick="Button1_Click1" />
                                    <asp:Button ID="btnStep3Next" runat="server" Text="下一步" OnClick="Button6_Click" />
                                    <asp:Button ID="Button7" runat="server" Text="重置" onclick="Button7_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- Step 4 -->
    <asp:UpdatePanel ID="upnlStep4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlStep4" runat="server" Visible="False">
                <table class="tableStyle99" width="100%">
                    <tr>
                        <td colspan="4">
                            第四步：設定費用來源
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            預算來源
                        </td>
                        <td class="htmltable_Right">
                            <uc2:ucSaCode ID="cmb_uc_BudgeSource" runat="server" Code_Kind="P" Code_sys="002"
                                Code_type="018" ControlType="2" ReturnEvent="True" />
                        </td>
                        <td class="htmltable_Left">
                            人員類別
                        </td>
                        <td class="htmltable_Right">
                            <uc2:ucSaCode ID="cmb_uc_EmpType" runat="server" Code_Kind="P" Code_sys="002" Code_type="017"
                                ControlType="2" ReturnEvent="True" Mode="Select" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            所得類別
                        </td>
                        <td class="htmltable_Right" colspan="3">
                            <uc2:ucSaCode ID="cmb_uc_SalaryType" runat="server" Code_Kind="P" Code_sys="003"
                                Code_type="004" ControlType="2" ReturnEvent="True" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" class="htmltable_Bottom">
                            <asp:Button ID="Button8" runat="server" Text="上一步" OnClick="Button8_Click" />
                            <asp:Button ID="Button9" runat="server" Text="下一步" OnClick="Button9_Click" />
                            <asp:Button ID="Button10" runat="server" Text="重置" onclick="Button10_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upnlStep5" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGrnReport"></asp:PostBackTrigger>
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="pnlStep5" runat="server" Visible="False">
                <table class="tableStyle99" width="100%">
                    <tr>
                        <td colspan="4" class="htmltable_Bottom">
                            <asp:Button ID="Button11" runat="server" Text="上一步" OnClick="Button11_Click" />
                            <asp:Button ID="btnGrnReport" runat="server" Text="產生報表" OnClick="Button12_Click" />
                            <asp:Button ID="Button13" runat="server" Text="重置" onclick="Button13_Click" />
                        </td>
                    </tr>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
