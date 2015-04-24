<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="CAR1101_01.aspx.vb" Inherits="CAR1101_01" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>

<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">派車申請
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">類型
                </td>
                <td colspan="3">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <uc2:ucSaCode ID="ucCarType" runat="server" Code_sys="015" Code_type="002" ControlType="DropDownList" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">用車人數
                </td>
                <td>
                    <asp:TextBox ID="txtPassengerCnt" runat="server" MaxLength="2"></asp:TextBox>
                </td>
                <td class="htmltable_Left">車輛代號
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlCarName" runat="server" ControlType="DropDownList"></asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">用車頻率
                </td>
                <td colspan="3">
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                        <ContentTemplate>
                            <table style="border:none">
                                <tr style="border:none">
                                    <td style="border:none">
                                        <uc2:ucSaCode runat="server" ID="ucUse_frequency" Code_sys="015" Code_type="009" ControlType="DropDownList" ReturnEvent="true" OnCodeChanged="ucUse_frequency_CodeChanged" />
                                    </td>
                                    <td style="border:none">
                                        <asp:Panel runat="server" ID="pWeekday">
                                            每周<asp:DropDownList runat="server" ID="ddlWeekday">
                                                <asp:ListItem Value="1">一</asp:ListItem>
                                                <asp:ListItem Value="2">二</asp:ListItem>
                                                <asp:ListItem Value="3">三</asp:ListItem>
                                                <asp:ListItem Value="4">四</asp:ListItem>
                                                <asp:ListItem Value="5">五</asp:ListItem>
                                            </asp:DropDownList>
                                        </asp:Panel>
                                    </td>
                                    <td style="border:none">
                                        <asp:Panel runat="server" ID="pDays">
                                            每月<asp:DropDownList runat="server" ID="ddlDays" />日
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>


                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">用車時間
                </td>
                <td colspan="3">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table style="border:none">
                                <tr style="border:none">
                                    <td style="border:none">
                                        <asp:Panel runat="server" ID="pStartDate">
                                            起始日期
                                            <uc2:UcDate ID="ucStartDate" runat="server" />
                                            用車時間
                                            <uc2:ucSaCode ID="ucStartTime" runat="server" Code_sys="015" Code_type="006" Enabled="false" ControlType="DropDownList" />
                                             ~<uc2:ucSaCode ID="ucEndTime" runat="server" Code_sys="015" Code_type="006" Enabled="false" ControlType="DropDownList" />
                                        </asp:Panel>
                                    </td>
                                    <td style="border:none">
                                        <asp:Panel runat="server" ID="pEndDate">
                                           結束日期 
                                            <uc2:UcDate ID="ucEndDate" runat="server" />
                                            
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>


                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">出發時間
                </td>
                <td colspan="3">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <uc2:UcDate ID="ucDepartureDate" runat="server" />
                            <%--<uc2:ucSaCode ID="ucDepartureTime" runat="server" Code_sys="015" Code_type="006" ControlType="DropDownList" />--%>
                            <asp:TextBox ID="txtDepartureTimeS" runat="server" Width="25" MaxLength="2"></asp:TextBox>:
                            <asp:TextBox ID="txtDepartureTimeE" runat="server" Width="25" MaxLength="2"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">上車地點
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtLocation" runat="server" MaxLength="20"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">用車事由
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtReasonDesc" runat="server" Width="150" MaxLength="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">用車種類
                </td>
                <td colspan="3">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <uc2:ucSaCode ID="ucUseType" runat="server" Code_sys="015" Code_type="003" ControlType="RadioButtonList" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">緊急派車
                </td>
                <td colspan="3">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <uc2:ucSaCode ID="ucUrgentType" runat="server" Code_sys="015" Code_type="004" ControlType="RadioButtonList" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
       
            <tr>
                <td class="htmltable_Left">到達地點
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtDestinationDesc" runat="server" Width="150" MaxLength="20"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="AddBtn" runat="server" Text="送出申請" />
                    <asp:Button ID="ResetBtn" runat="server" Text="清空重填" />
                    <asp:Button ID="BackBtn" runat="server" Text="回上頁" OnClientClick="javascript: window.history.back();" /> 
                </td>
            </tr>
        </table>
        <div id="div1" runat="server" visible="true" align="center">

            <table style="width: 100%">
                <tr>
                    <td style="text-align: center">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="lbPreDate" runat="server">前一天</asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="text-align: center">
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblNow" runat="server" Text=""></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="text-align: center">
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="lbNextDate" runat="server">後一天</asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: center">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center">
                                    <RowStyle CssClass="Row" />
                                    <HeaderStyle CssClass="Grid" />
                                    <AlternatingRowStyle CssClass="AlternatingRow" />
                                    <PagerSettings Position="TopAndBottom" />
                                    <EmptyDataRowStyle CssClass="EmptyRow" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>


        </div>
    </div>
</asp:Content>

