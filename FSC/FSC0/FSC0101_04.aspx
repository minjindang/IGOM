<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0101_04.aspx.vb" Inherits="FSC0101_04" %>
<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc2" TagName="UcFlowDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<div>
<table width="100%">
    <tr>
        <td class="htmltable_Title">
            領物明細</td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width="100%" 
                CssClass="Grid" BorderWidth="0px" PagerStyle-HorizontalAlign="Right" AllowSorting="true">
                <Columns>
                    <asp:TemplateField HeaderText="項次">
                        <ItemStyle Width="20px" HorizontalAlign="Center"/>
                        <HeaderStyle Width="20px" />
                        <ItemTemplate>
                            <asp:Label ID="gvlbNo" runat="server" Text='<%# Container.DataItemIndex+1 %>' ></asp:Label>
                            <asp:Label ID="gvlbOrgcode" runat="server"  Text='<%# Bind("Orgcode")%>' Visible="false" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="領物類別">
                        <ItemTemplate>
                            <asp:Label ID="gvlbForm_type" runat="server"  Text='<%# Bind("Form_name")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="單位別">
                        <ItemTemplate>
                            <asp:Label ID="gvlbUnit_code" runat="server"  Text='<%# Bind("depart_name")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="領物申請人">
                        <ItemTemplate>
                            <asp:Label ID="gvlbUser_id" runat="server"  Text='<%# Bind("user_name")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="領物單編號">
                        <ItemTemplate>
                            <asp:Label ID="gvlbFlow_id" runat="server"  Text='<%# Bind("Flow_id")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="物料編號">
                        <ItemTemplate>
                            <asp:Label ID="gvlbMaterial_id" runat="server"  Text='<%# Bind("Material_id")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="物料名稱">
                        <ItemTemplate>
                            <asp:Label ID="gvlbMaterial_name" runat="server"  Text='<%# Bind("Material_name")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="單位">
                        <ItemTemplate>
                            <asp:Label ID="gvlbUnit" runat="server"  Text='<%# Bind("Unit")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="申請數量">
                        <ItemTemplate>
                            <asp:Label ID="gvlbApply_cnt" runat="server"  Text='<%# Bind("Apply_cnt")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="領用數量">
                        <ItemTemplate>
                            <asp:Textbox ID="gvtbOut_cnt" runat="server"  Text='<%# Bind("Apply_cnt")%>' ></asp:Textbox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="用途說明">
                        <ItemTemplate>
                            <asp:Label ID="gvlbMemo" runat="server"  Text='<%# Bind("Memo")%>' ></asp:Label>
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
        <td class="htmltable_Bottom">
            <asp:Button ID="cbConfirm" runat="server" Text="確定" OnClick="cbConfirm_Click" />
            <asp:Button ID="cbRest" runat="server" Text="清空重填" />
            <input id="cbPrint" type="button" value="列印" onclick="javascript: window.print();" class="nonPrinted" />  
            <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" />
        </td>
    </tr>
</table>
<uc2:UcFlowDetail runat="server" ID="UcFlowDetail" />
</div>
</asp:Content>