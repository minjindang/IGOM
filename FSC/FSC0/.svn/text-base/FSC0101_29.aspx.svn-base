<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0101_29.aspx.vb" Inherits="FSC0101_29" %>

<%@ Register Src="~/UControl/FSC/UcAttachment.ascx" TagPrefix="uc1" TagName="UcAttachment" %>
<%@ Register Src="~/UControl/SYS/UcCustomNext.ascx" TagPrefix="uc1" TagName="UcCustomNext" %>
<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc2" TagName="UcFlowDetail" %>

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
                    <Columns >
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbNo" runat="server" Text='<%# Container.DataItemIndex + 1%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="表單編號">
                            <ItemTemplate>
                                <asp:Label id="lbFlow_id" runat="server" Text='<%# Eval("Flow_id")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位">
                            <ItemTemplate>
                                <asp:Label id="lbDepart_name" runat="server" Text='<%# Eval("Depart_name")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="人員姓名">
                            <ItemTemplate>
                                <asp:Label id="lbPRNAME" runat="server" Text='<%# Eval("PRNAME")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="加班日期起">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbPRADDD_name" runat="server" Text='<%# Bind("PRADDD_name") %>'></asp:Label>
                                <asp:Label ID="gv_lbPRADDD" runat="server" Text='<%# Bind("PRADDD") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="加班日期迄">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbPRADDE_name" runat="server" Text='<%# Bind("PRADDE_name") %>'></asp:Label>
                                <asp:Label ID="gv_lbPRADDE" runat="server" Text='<%# Bind("PRADDE") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="加班類別">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbPRATYPE_name" runat="server" Text='<%# IIf(Eval("PRATYPE")="1","一般","專案") %>'></asp:Label>
                                <asp:Label ID="gv_lbPRATYPE" runat="server" Text='<%# Bind("PRATYPE") %>' Visible="false"></asp:Label>
                                <asp:hiddenfield ID="hftype" runat="server" value='<%# Bind("PRATYPE") %>'></asp:hiddenfield>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="申請時間" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbStart_time" runat="server" Text='<%# Bind("Start_time") %>'></asp:Label>
                                ~ <asp:Label ID="gv_lbEnd_time" runat="server" Text='<%# Bind("End_time") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="加班時間">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbPRSTIME_name" runat="server" Text='<%# Bind("PRSTIME_name") %>'></asp:Label>
                                ~ <asp:Label ID="gv_lbPRETIME_name" runat="server" Text='<%# Bind("PRETIME_name") %>'></asp:Label>
                                <asp:Label ID="gv_lbPRSTIME" runat="server" Text='<%# Bind("PRSTIME") %>' Visible="false"></asp:Label>
                                <asp:Label ID="gv_lbPRETIME" runat="server" Text='<%# Bind("PRETIME") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="加班時數">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbPRADDH" runat="server" Text='<%# Bind("PRADDH") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="已休時數">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbPRPAYH" runat="server" Text='<%# Bind("PRPAYH") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="已領時數">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbPRMNYH" runat="server" Text='<%# Bind("PRMNYH") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="請領時數">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbApply_hour" runat="server" Text='<%# Bind("Apply_hour") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="事由">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbPRREASON" runat="server" Text='<%# Bind("PRREASON") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
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
    <uc2:UcFlowDetail runat="server" ID="UcFlowDetail" />
</asp:Content>
