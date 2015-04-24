<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PRO1104_01.aspx.cs" Inherits="PRO1104_01" %>

<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc1" TagName="UcDDLMember" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">軟體移轉申請
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>新保管單位/保管人
            </td>
            <td colspan="3">
                <uc1:UcDDLDepart runat="server" ID="ucDept" OnSelectedIndexChanged="ucDept_SelectedIndexChanged" />
                <uc1:UcDDLMember runat="server" ID="ucMember" />
            </td>
        </tr>
    </table>
    <div align="center">
        <asp:Button ID="DoneBtn" runat="server" Text="送出申請" OnClick="DoneBtn_Click" />
        <asp:Button ID="ClrBtn" runat="server" Text="清空重填" OnClick="ClrBtn_Click" />
    </div>
        <asp:GridView ID="GridViewA" runat="server"
            AutoGenerateColumns="false" OnPageIndexChanging="GridViewA_PageIndexChanging"
            AllowPaging="true" PagerSettings-Visible="true"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無您所屬的軟體資料!">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:TemplateField HeaderText="">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        <asp:CheckBox ID="cbAll" runat="server" OnCheckedChanged="cbAll_CheckedChanged" AutoPostBack="true" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cb" runat="server" />
                        <asp:Label ID="lbFlow_id" runat="server" Text='<%# Eval("Flow_id")%>' Visible="false" />
                        <asp:Label ID="lbUnit_code" runat="server" Text='<%# Eval("Unit_code")%>' Visible="false" />
                        <asp:Label ID="lbUser_id" runat="server" Text='<%# Eval("User_id")%>' Visible="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="OfficialNumber_id" HeaderText="公文文號" />
                <asp:BoundField DataField="Software_id" HeaderText="軟體編號" />
                <asp:BoundField DataField="Software_type_name" HeaderText="軟體類別" />
                <asp:BoundField DataField="Software_name" HeaderText="軟體名稱" />
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
        <div id="div1" runat="server" visible="false">
        <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
            PNow="1" PSize="25" Visible="true" />
        </div>

</asp:Content>

