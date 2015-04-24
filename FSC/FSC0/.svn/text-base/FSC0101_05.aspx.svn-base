<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0101_05.aspx.vb" Inherits="FSC0101_05" %>
<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc2" TagName="UcFlowDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div>
<table width="100%">
    <tr>
        <td class="htmltable_Title" colspan="2">
            表單明細</td>
    </tr>
    <tr>
        <td class="htmltable_Left">用途摘要</td>
        <td class="htmltable_Right">
            <asp:Label ID="lbUseDesc" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left">請購類別</td>
        <td class="htmltable_Right">
            <asp:RadioButtonList ID="rbxPurchaseType" runat="server" Enabled="false" 
                DataTextField="code_desc1" DataValueField="code_no" RepeatDirection="Horizontal">
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Right" colspan="2">
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width="100%" 
                CssClass="Grid" BorderWidth="0px" PagerStyle-HorizontalAlign="Right" AllowSorting="true">
                <Columns>
                    <asp:TemplateField HeaderText="項次">
                        <ItemStyle Width="20px" HorizontalAlign="Center"/>
                        <HeaderStyle Width="20px" />
                        <ItemTemplate>
                            <asp:Label ID="gvlbNo" runat="server" Text='<%# Container.DataItemIndex+1 %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="項目名稱">
                        <ItemTemplate>
                            <asp:Label ID="gvlbItem_name" runat="server"  Text='<%# Bind("Item_name")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="規格">
                        <ItemTemplate>
                            <asp:Label ID="gvlbSpecification_desc" runat="server"  Text='<%# Bind("Specification_desc")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="單位">
                        <ItemTemplate>
                            <asp:Label ID="gvlbUnit" runat="server"  Text='<%# Bind("Unit")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="數量">
                        <ItemTemplate>
                            <asp:Label ID="gvlbApply_cnt" runat="server"  Text='<%# Bind("Apply_cnt")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    無資料
                </EmptyDataTemplate>
                <PagerStyle HorizontalAlign="Right" />
                <RowStyle CssClass="Row" />
                <AlternatingRowStyle CssClass="AlternatingRow" />
                <EmptyDataRowStyle CssClass="EmptyRow" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td colspan="2"  class="htmltable_Bottom">
            <input type="button" value="列印" onclick="javascript: window.print();" class="nonPrinted" />
            <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" />
        </td>
    </tr>
</table>
<uc2:UcFlowDetail runat="server" ID="UcFlowDetail" />
</div>

</asp:Content>