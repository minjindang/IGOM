<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL1101_01.aspx.cs" Inherits="SAL_SAL1_SAL1101_01" %>

<%@ Register Src="~/UControl/UcPager.ascx" TagName="UcPager" TagPrefix="uc1" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc2" %>
<%@ Register Src="~/UControl/SAL/UcReset.ascx" TagName="UcReset" TagPrefix="uc3" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">短程車費申請</td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color:red">*</span>事由</td>
            <td style="width: 326px" colspan="3">
                <asp:TextBox ID="txtApply_desc" runat="server" Text="" Width="200px" MaxLength="50" Rows="2" TextMode="MultiLine"></asp:TextBox>
                <asp:HiddenField ID="hfFlow_id" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color:red">*</span>乘車日期</td>
            <td style="width: 326px">
                <uc4:UcDate ID="ucCost_date" runat="server" />
            </td>

            <td class="htmltable_Left"><span style="color:red">*</span>申請車資</td>
            <td style="width: 326px">
                <asp:TextBox ID="txtApply_amt" runat="server" Width="70" Text="" MaxLength="6"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                <asp:Button ID="InsertBtn" runat="server" Text="新增" OnClick="InsertBtn_Click" />
                <asp:HiddenField ID="hfModifyIndex" runat="server" />
                <asp:Button ID="SubmitBtn" runat="server" Text="送出申請" OnClick="SubmitBtn_Click" />
                <asp:Button ID="PrintBtn" runat="server" Text="列印" OnClick="PrintBtn_Click" />
                <asp:Button ID="ResetBtn" runat="server" Text="清空重填" OnClick="ResetBtn_Click" />
                <asp:Button ID="BackBtn" runat="server" Text="回上頁" OnClick="BackBtn_Click" Visible="false" />
            </td>
        </tr>
    </table>
    <div id="div1" runat="server">
        <asp:GridView ID="GridViewA" runat="server"
            AutoGenerateColumns="False"
            AllowPaging="True" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbx" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Depart_name" HeaderText="單位別" />
                <asp:BoundField DataField="PEMEMCOD" HeaderText="人員類別" />
                <asp:BoundField DataField="User_name" HeaderText="姓名" />
                <asp:BoundField DataField="Apply_desc" HeaderText="事由" />
                <asp:BoundField DataField="Cost_date" HeaderText="乘車日期" />
                <asp:BoundField DataField="Apply_amt" HeaderText="申請車資" />
                <asp:TemplateField HeaderText="維護">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:HiddenField ID="hfApply_desc" runat="server" Value='<%# Eval("Apply_desc") %>' />
                        <asp:HiddenField ID="hfCost_date" runat="server" Value='<%# Eval("Cost_date") %>' />
                        <asp:HiddenField ID="hfApply_amt" runat="server" Value='<%# Eval("Apply_amt") %>' />
                        <asp:HiddenField ID="hfId" runat="server" Value='<%# Eval("id") %>' />
                        <asp:Button ID="btnMain" runat="server" Text="維護" CommandName="Maintain" OnClick="btnMain_Click" />
                        <asp:Button ID="btnDelete" CommandName="GoDelete" runat="server" Text="刪除" OnClick="btnDelete_Click" OnClientClick="return confirm('是否確定要刪除?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
        <asp:HiddenField ID="hfOrgcode" runat="server" />
        <asp:HiddenField ID="hfDepartId" runat="server" />
        <asp:HiddenField ID="hfUserId" runat="server" />
    </div>
     <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                <asp:Button ID="SubmitBtn2" runat="server" Text="送出申請" OnClick="SubmitBtn_Click" />
                <asp:Button ID="PrintBtn2" runat="server" Text="列印" OnClick="PrintBtn_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

