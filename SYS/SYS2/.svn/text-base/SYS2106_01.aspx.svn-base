<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS2106_01.aspx.vb" Inherits="SYS2106_01" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">系統錯誤訊息查詢
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Title2" colspan="4">查詢條件
                        </td>
                    </tr>

                    <tr>
                        <td class="htmltable_Left" style="width: 100px">錯誤訊息
                        </td>
                        <td class="htmltable_Right" style="width: 250px">
                            <asp:TextBox ID="txtMessage" runat="server"></asp:TextBox></td>
                        <td class="htmltable_Left" style="width: 100px">日期區間
                        </td>
                        <td class="htmltable_Right" style="width: 250px">
                            <uc2:UcDate ID="UcDate1" runat="server"></uc2:UcDate>
                            <asp:Label ID="lbTip" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Bottom" colspan="4">
                            <asp:Button ID="btnQuery" runat="server" CausesValidation="False" Text="查詢" OnClick="btnQuery_Click" />
                            <input id="cbRest" type="button" value="重填" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 358px" valign="top">
                <table id="tbq" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
                    visible="false" class="tableStyle99">
                    <tr>
                        <td align="center" class="htmltable_Title2" colspan="3">查詢結果
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3" class="TdHeightLight">
                            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                                BorderWidth="0px" PagerStyle-HorizontalAlign="Right" AllowPaging="True" PageSize="30" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="項次">
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (container.dataitemindex+1).tostring() %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="錯誤訊息">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbMessage" runat="server" Text='<%# Eval("Message")%>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="日期">
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbcreate_date" runat="server" Text='<%# Eval("create_date")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <EmptyDataTemplate>
                                    查無資料
                                </EmptyDataTemplate>
                                <PagerStyle HorizontalAlign="Right" />
                                <RowStyle CssClass="Row" />
                                <AlternatingRowStyle CssClass="AlternatingRow" />
                                <PagerSettings Position="TopAndBottom" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr runat="server" id="tr2">
                        <td align="right" class="TdHeightLight" colspan="2">
                            <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvList" Other1="Ucpager2" PNow="1" PSize="30" Visible="true" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
