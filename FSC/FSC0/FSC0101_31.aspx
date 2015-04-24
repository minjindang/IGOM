<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0101_31.aspx.vb" Inherits="FSC0101_31" %>

<%@ Register Src="~/UControl/FSC/UcAttachment.ascx" TagPrefix="uc1" TagName="UcAttachment" %>
<%@ Register Src="~/UControl/SYS/UcCustomNext.ascx" TagPrefix="uc1" TagName="UcCustomNext" %>
<%@ Register Src="~/UControl/UcShowDate.ascx" TagPrefix="uc1" TagName="UcShowDate" %>
<%@ Register Src="~/UControl/UcShowTime.ascx" TagPrefix="uc1" TagName="UcShowTime" %>
<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc1" TagName="UcFlowDetail" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" >
    <table border = "1" cellpadding = "0" cellspacing = "0" width="100%"   class="tableStyle99">  
        <tr>
            <td class="htmltable_Title">
                表單明細
            </td>
        </tr>
        <tr>
            <td style="width:100px">
                                
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Borderwidth="0px"
                    CssClass="Grid" PagerStyle-HorizontalAlign="Right" width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbNo" runat="server" Text='<%# Container.DataItemIndex + 1%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位">
                            <ItemTemplate>
                                <asp:Label id="lbDepart_name" runat="server" Text='<%# Eval("Depart_name")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="人員姓名">
                            <ItemTemplate>
                                <asp:Label id="lbUser_name" runat="server" Text='<%# Eval("User_name")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="日期">
                            <ItemTemplate>
                                <uc1:UcShowDate runat="server" ID="UcShowDate" Text='<%# Eval("Officialout_Date") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="地點">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbPlace_start" Text='<%# Bind("Place_start")%>' />
                                <asp:Label runat="server" ID="lbPlace_end" Text='<%# Bind("Place_end")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Introduction" HeaderText="工作紀要" />
                        <asp:BoundField DataField="Train" HeaderText="火車" />
                        <asp:BoundField DataField="Car" HeaderText="汽車" />
                        <asp:BoundField DataField="Plane" HeaderText="高鐵飛機輪船費(附證件)" />
                        <asp:BoundField DataField="Food" HeaderText="膳雜費" />
                        <asp:BoundField DataField="Live" HeaderText="住宿費" />
                        <asp:TemplateField HeaderText="住宿加計交通費<br />(旅行業代收轉付)">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbSudden" Text='<%# Eval("Sudden") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Recipnumber" HeaderText="單據號數" />
                        <asp:BoundField DataField="Note" HeaderText="備註" />
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
