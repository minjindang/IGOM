<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL1106_01.aspx.cs" Inherits="SAL_SAL1_SAL1106_01" %>

<%@ Register Src="~/UControl/UcROCYear.ascx" TagName="UcROCYear" TagPrefix="uc2" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc2" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/FSC/UcMember.ascx" TagName="UcMember" TagPrefix="uc6" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagName="UcDDLDepart" TagPrefix="uc8" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">未休假加班費申請</td>
            </tr>
            <tr>
                <td class="htmltable_Left">申請年度</td>
                <td colspan="3">
                    <uc2:UcROCYear ID="ucApply_yy" runat="server" />
                     <uc2:UcDDLDepart runat="server" ID="ucDepart_id" Visible="false"  />
                    <uc2:UcDDLMember runat="server" ID="ucUser_name" Visible="false"  />
                </td>
            </tr>
            <tr id="trDepart_id" runat="server" >
            <td class="htmltable_Left" style="width: 120px">單位名稱
            </td>
            <td class="htmltable_Right" style="width: 230px" colspan="3">
                <uc8:UcDDLDepart ID="cmbDepartID" runat="server" />
            </td>
        </tr>            
            <tr id="trPersonnel01" runat="server">
                <td class="htmltable_Left">人員姓名</td>
                <td colspan="3">
                    <asp:UpdatePanel ID="upnlUserName" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtUserName" runat="server" Width="100"></asp:TextBox>
                        <uc2:UcDDLMember runat="server" ID="ddlName" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            </tr>
            <tr id="trPersonnel02" runat="server">
                <td class="htmltable_Left">員工編號</td>
                <td colspan="3">
                    <uc6:UcMember ID="UcPersonal_id" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="btn_query" runat="server" Text="查詢" OnClick="btn_query_Click" />
                    <asp:Button ID="btn_submit" runat="server" Text="送出申請" OnClick="btn_submit_Click" />
                    <asp:Button ID="btn_back" runat="server" Text="回上頁" OnClick="btn_back_Click" Visible="false" />
                </td>
            </tr>
        </table>
    </div>
    <div>

        <table class="Grid" style="width: 100%">
            <tr>
                <th rowspan="2">員工姓名
                </th>
                <th rowspan="2">發給年度
                </th>
                <th rowspan="2">
                    <asp:Label ID="lblApply_yyTitle" runat="server" Visible="false" ></asp:Label>可休天數
                </th>
                <th colspan="4">休假天數
                </th>
                <th rowspan="2">可請領天數
                </th>
                <th colspan="2">請輸入申請
                </th>
            </tr>

            <tr>
                <th>實休
                </th>
                <th>國內(一般)

                </th>
                <th>國內(刷卡)

                </th>
                <th>國外

                </th>
                <th>天數

                </th>
                <th>金額

                </th>

            </tr>
            <tr align="center">
                <td colspan="10">超過14天後的申請統計(累計已請領天數:0天)[累計請領金額:0元整]
                </td>
            </tr>
            <tr  align="center">
                <td>
                    <asp:Label ID="lblUser_name" runat="server"></asp:Label>
                    <asp:Label ID="lbId_card" runat="server" Visible="false" />
                </td>
                <td>
                    <asp:Label ID="lblApply_yy" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPEHDAY" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLeaveType1" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLeaveType2" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLeaveType3" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLeaveType4" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPEHYEAR2" runat="server"></asp:Label>
                </td>
                <td>
                            <asp:TextBox ID="txtDays" runat="server" OnTextChanged="txtDays_TextChanged" AutoPostBack="true" Width="50"></asp:TextBox>天
                            <asp:DropDownList runat="server" ID="ddlHours" OnSelectedIndexChanged="ddlHours_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="0">0</asp:ListItem>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                            </asp:DropDownList>小時
                </td>
                <td>                    
                            <asp:TextBox ID="txtApply_amount" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>

