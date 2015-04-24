<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL1102_01.aspx.cs" Inherits="SAL_SAL1_SAL1102_01"  EnableEventValidation="false" %>

<%@ Register Src="~/UControl/UcROCYearMonth.ascx" TagName="UcROCYearMonth" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">值班費申請</td>
            </tr>
            <tr>
                <td class="htmltable_Left">申請年月</td>
                <td>
                    <uc2:UcROCYearMonth ID="UcDate1" runat="server" />
                    <asp:HiddenField ID="hfYearMonth" runat="server" />
                </td>
            </tr>

            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="btn_search" runat="server" Text="查詢" OnClick="btn_search_Click" />
                    <asp:Button ID="btn_export" runat="server" Text="匯出" 
                        OnClick="btn_export_Click" />
                    <asp:Button ID="btn_submit" runat="server" Text="送出申請" OnClick="btn_submit_Click" />
                    <asp:Button ID="BackBtn" runat="server" Text="回上頁" OnClick="BackBtn_Click" Visible="false" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="GridViewA" runat="server"
            AutoGenerateColumns="False"
            AllowPaging="false" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:CheckBox ID="gvCbx" runat="server" Checked="true" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        <asp:CheckBox ID="gvCbxAll" runat="server" AutoPostBack="true" OnCheckedChanged="gvCbxAll_CheckedChanged" Checked="true" />
                    </HeaderTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Depart_name" HeaderText="單位" />
                <asp:BoundField DataField="User_name" HeaderText="姓名" />
                <asp:BoundField DataField="Sche_date" HeaderText="值班日期" />
                <asp:BoundField DataField="Start_time" HeaderText="值班起時" />
                <asp:BoundField DataField="End_time" HeaderText="值班迄時" /> 
                <asp:TemplateField HeaderText="值班時數">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:TextBox runat="server" Width="100" ID="txtSchedule_hours" Text='<%# Eval("Schedule_hours")%>' MaxLength="3"></asp:TextBox>
                        <asp:Label ID="lbApplyHour_cnt" runat="server" Text='<%# Eval("ApplyHour_cnt") %>' Visible="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="可補休" Visible="false" >
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chis_rest" Checked="true" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Leave_hours" HeaderText="已補休時數" Visible="false" />
                <asp:TemplateField HeaderText="值班費金額">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:TextBox runat="server" Width="100" ID="txtDuty_fee" Text='<%# Eval("Duty_fee")%>' MaxLength="5"></asp:TextBox>
                        <asp:HiddenField runat="server" ID="hf_Depart_id" Value='<%# Eval("Depart_id")%>' />
                        <asp:HiddenField runat="server" ID="hf_id_card" Value='<%# Eval("id_card")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="備註" Visible="true">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:TextBox runat="server" Width="200" ID="txtmemo" MaxLength="50"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
    </div>
</asp:Content>

