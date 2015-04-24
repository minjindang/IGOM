<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0101_33.aspx.vb" Inherits="FSC0101_33" %>

<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc1" TagName="UcFlowDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" >
    <table border = "1" cellpadding = "0" cellspacing = "0" width="100%"   class="tableStyle99">  
        <tr>
            <td class="htmltable_Title" colspan="2">
                表單明細
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">原保管單位</td>
            <td>
                <asp:Label ID="lbOldUnit_name" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">原保管人</td>
            <td>
                <asp:Label ID="lbOldKeeper_name" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">新保管單位</td>
            <td>
                <asp:Label ID="lbNewUnit_name" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">新保管人</td>
            <td>
                <asp:Label ID="lbNewKeeper_name" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width:100px" colspan="2">             
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Borderwidth="0px"
                    CssClass="Grid" PagerStyle-HorizontalAlign="Right" width="100%">
                    <Columns >
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbNo" runat="server" Text='<%# Container.DataItemIndex + 1%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Software_id" HeaderText="軟體編號" />
                        <asp:BoundField DataField="Software_name" HeaderText="軟體名稱" />
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <input id="cbPrint" type="button" value="列印" onclick="javascript: window.print();" class="nonPrinted" />                
                <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" />
            </td>
        </tr>
    </table>
    <uc1:UcFlowDetail runat="server" ID="UcFlowDetail" />
</asp:Content>
