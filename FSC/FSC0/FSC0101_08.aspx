<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0101_08.aspx.vb" Inherits="FSC0101_08" %>
<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc2" TagName="UcFlowDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style type="text/css">
hr {
	border:0; height:1px; background-color:#C5C386;
	color:#C5C386	/* IE6 */
}
</style>
<div>
<table width="100%">
    <tr>
        <td class="htmltable_Title">
            表單明細<!--財產類申請-財產移轉申請(換保管人、不換保管人)--></td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width="100%" 
                CssClass="Grid" BorderWidth="0px" PagerStyle-HorizontalAlign="Right" AllowSorting="true">
                <Columns>
                    <asp:TemplateField HeaderText="財產編號">
                        <ItemStyle HorizontalAlign="Center" Width="180"/>
                        <ItemTemplate>
                            
                            <asp:Label ID="gvlbProperty_id" runat="server"  Text='<%# Bind("Property_id")%>' ></asp:Label>-
                            <asp:Label ID="gvlbProperty_class" runat="server"  Text='<%# Bind("Property_class")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="財產名稱">
                        <ItemStyle HorizontalAlign="Center" Width="220"/>
                        <ItemTemplate>
                            <asp:Label ID="gvlbProperty_name" runat="server"  Text='<%# Bind("Property_name")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            原保管單位
                            <hr />
                            新保管單位
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="gvlbOldUnit_code" runat="server"  Text='<%# Bind("OldUnit_name")%>' ></asp:Label>&nbsp;
                            <hr />
                            <asp:Label ID="gvlbNewUnit_code" runat="server"  Text='<%# Bind("NewUnit_name")%>' ></asp:Label>&nbsp;
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            原保管人
                            <hr />
                            新保管人
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="gvlbOldUnit_code" runat="server"  Text='<%# Bind("OldKeeper_name")%>' ></asp:Label>&nbsp;
                            <hr />
                            <asp:Label ID="gvlbNewUnit_code" runat="server"  Text='<%# Bind("NewKeeper_name")%>' ></asp:Label>&nbsp;
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            原放置地點
                            <hr />
                            新放置地點
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="gvlbOldUnit_code" runat="server"  Text='<%# Bind("OldLocation")%>' ></asp:Label>&nbsp;
                            <hr />
                            <asp:Label ID="gvlbNewUnit_code" runat="server"  Text='<%# Bind("NewLocation")%>' ></asp:Label>&nbsp;
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
            <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" />
        </td>
    </tr>
</table>
<uc2:UcFlowDetail runat="server" ID="UcFlowDetail" />
</div>

</asp:Content>