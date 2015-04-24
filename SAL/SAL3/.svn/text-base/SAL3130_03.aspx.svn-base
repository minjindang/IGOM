<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master"
    AutoEventWireup="false" CodeFile="SAL3130_03.aspx.vb" Inherits="SAL3130_03" %>

<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc1" TagName="UcDDLMember" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">薪資異動通知作業-設定發送名單
            </td>
        </tr>
        </table>
    <table id="tbq" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
        class="tableStyle99">

        <tr>
            <td style="width: 100%"  valign="top">
                <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="False"
                    AllowPaging="True" CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
                            <ItemTemplate>
                                <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (container.dataitemindex+1).tostring() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位名稱">
                            <HeaderStyle />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" OnSelectedIndexChanged="UcDDLDepart_SelectedIndexChanged"/>
                                <asp:Label ID="lbSend_departid" runat="server" Text='<%# Eval("Send_departid")%>' Visible="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="人員姓名">
                            <HeaderStyle />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <uc1:UcDDLMember runat="server" ID="UcDDLMember" />
                                <asp:Label ID="lbSend_idcard" runat="server" Text='<%# Eval("Send_idcard")%>' Visible="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="維護" >
                            <HeaderStyle />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Button ID="btnInsert" runat="server" Text="插入" OnClick="btnInsert_Click" />
                                <asp:Button ID="btnDel" runat="server" Text="刪除" OnClick="btnDel_Click" OnClientClick="javascript:if(!confirm('是否確定刪除?')) return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        查無資料!!
                    </EmptyDataTemplate>
                    <RowStyle CssClass="Row" />
                    <HeaderStyle CssClass="Grid" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right" class="TdHeightLight" style="width: 100%">
                <uc1:UcPager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvlist"
                    PNow="1" PSize="25" Visible="false" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom">
                <asp:Button ID="cbConfirm" runat="server" Text="確認" OnClick="cbConfirm_Click" />
                <asp:Button ID="cbBack" runat="server" Text="回上頁" />
            </td>
        </tr>
    </table>
</asp:Content>

