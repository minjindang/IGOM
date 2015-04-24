<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="FSC0101_24.aspx.cs" Inherits="FSC_FSC0_FSC0101_24" %>
<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc2" TagName="UcFlowDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:DataList ID="DataList1" runat="server" RepeatLayout="Flow" OnItemDataBound="DataList1_ItemDataBound">
        <HeaderTemplate>
            <table class="Grid" style="width: 100%">
                <tr>
                    <td class="htmltable_Title" colspan="11">表單明細</td>
                </tr>
                <tr>
                     <th rowspan="2">表單編號
                    </th>
                    <th rowspan="2">員工姓名
                    </th>
                    <th rowspan="2">發給年度
                    </th>
                    <th rowspan="2">
                        <asp:Label ID="lblApply_yyTitle" runat="server"></asp:Label>年可休天數
                    </th>
                    <th colspan="4">休假天數
                    </th>
                    <th rowspan="2">可請領天數
                    </th>
                    <th colspan="2">申請
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
                    <th>天數/小時 
                    </th>
                    <th>金額 
                    </th> 
                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr align="center">
                <td>
                    <asp:Label ID="lblFlow_id" runat="server" Text='<%# Eval("Flow_id") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblUser_name" runat="server" Text='<%# Eval("User_name") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblApply_yy" runat="server" Text='<%# Eval("Annual_year") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPEHDAY" runat="server" Text='<%# Eval("Annual_days") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLeaveType1" runat="server" Text='<%# Eval("Vacation_days") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLeaveType2" runat="server" Text='<%# Eval("Vacation_internal") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLeaveType3" runat="server" Text='<%# Eval("Vacation_card") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLeaveType4" runat="server" Text='<%# Eval("Abroad_days") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPEHYEAR2" runat="server" Text='<%# Eval("Usable_days") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDays" runat="server"></asp:Label>/
                    <asp:Label ID="lblHours" runat="server"></asp:Label>
                    <asp:HiddenField ID="hfPay_days" runat="server" Value='<%# Eval("Pay_days") %>' />
                </td>
                <td>
                    <asp:TextBox ID="txtApply_amount" runat="server" Enabled="false" Text='<%# Eval("Apply_fee") %>'></asp:TextBox>
                </td>
            </tr>
        </ItemTemplate> 
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:DataList>




    <div align="center">
        <input id="cbPrint" type="button" value="列印" onclick="javascript: window.print();" class="nonPrinted" />
        <asp:Button ID="btnBack" runat="server" Text="回上頁" OnClick="btnBack_Click" />
        <asp:Button ID="btnMergePrint" runat="server" Text="印領清冊" Visible="false" OnClick="btnMergePrint_Click" />
    </div>
    <uc2:UcFlowDetail runat="server" ID="UcFlowDetail" />
</asp:Content>

