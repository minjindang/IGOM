<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL1105_01.aspx.cs" Inherits="SAL_SAL1_SAL1105_01" %>


<%@ Register Src="~/UControl/UcROCYear.ascx" TagName="UcROCYear" TagPrefix="uc2" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">健檢補助費申請</td>
            </tr>
            <tr>
                <td class="htmltable_Left">申請年度</td>
                <td class="htmltable_Right" style="width: 326px">
                    <uc2:ucrocyear id="ucApply_yy" runat="server" />
                </td>
                <td class="htmltable_Left">申請金額</td>
                <td class="htmltable_Right" style="width: 326px">
                    <asp:TextBox ID="txtApply_amt" runat="server" Enabled="false"></asp:TextBox>
                     元
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left"><font size="3" color="red">*</font>健檢日期</td>
                <td colspan="3">
                    <uc3:ucdate id="ucCheck_date" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;"> 
                    <asp:Button ID="btn_submit" runat="server" Text="送出申請" OnClick="btn_submit_Click" />
                    <asp:Button ID="btn_print" runat="server" Text="列印" OnClick="btn_print_Click" />
                    <asp:Button ID="btn_back" runat="server" Text="回上頁" OnClick="btn_back_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="GridViewA" runat="server"
            AutoGenerateColumns="False" DataKeyNames=""
            AllowPaging="True" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:BoundField DataField="User_name" HeaderText="姓名" />
                <asp:BoundField DataField="Apply_yy" HeaderText="申請年度" />
                <asp:BoundField DataField="Check_date" HeaderText="健檢日期" />
                <asp:BoundField DataField="Apply_amt" HeaderText="申請金額" /> 
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
    </div>
</asp:Content>

