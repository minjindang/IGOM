<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="EMP3109_01.aspx.vb" Inherits="EMP3109_01" %>
<%@ Register Src="~/UControl/FSC/UcMember.ascx" TagPrefix="uc4" TagName="UcMember" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc3" TagName="UcDDLMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">行動裝置掛失停用作業</td>
                    </tr>
                    <tr>
                        <td class="htmltable_Title2" colspan="4">查詢條件</td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">單位別</td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                            <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                        </td>

                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px">員工姓名</td>
                        <td class="htmltable_Right" style="width: 250px">
                            <uc3:UcDDLMember runat="server" ID="UcDDLMember" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width:100px">
                            員工編號</td>
                            <td class="htmltable_Right">
                                <uc4:UcMember runat="server" ID="UcMember" />
                            </td>
                        </tr>
                     <tr>
                        <td class="htmltable_Left" style="width:120px; height: 26px;">是否停用</td>            
                        <td class="htmltable_Right" style="height: 26px" >
                            <asp:DropDownList ID="ddlisdisable" runat="server" AppendDataBoundItems="True">
                                <asp:ListItem Value="" Text="請選擇"></asp:ListItem>
                                <asp:ListItem Value="0" Text="使用中"></asp:ListItem>
                                <asp:ListItem Value="1" Text="停用"></asp:ListItem>
                            </asp:DropDownList>
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
                        <td class="htmltable_Title2" style="width: 100%" align="center">查詢結果
                        </td>
                    </tr>
                      <tr>
                        <td style="width: 100%" class="TdHeightLight" valign="top">
                            <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="false" BorderWidth="0px" PageSize="30"
                                AllowPaging="true" CssClass="Grid" PagerStyle-HorizontalAlign="right" Width="100%"
                                EmptyDataText="查無資料!!">
                                <Columns>
                                    <asp:TemplateField HeaderText="項次">
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (container.dataitemindex+1).tostring() %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="單位名稱">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbdepart_name" runat="server" Text='<%# Eval("depart_name")%>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="員工編號">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbId_card" runat="server" Text='<%# Eval("Id_card")%>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="員工姓名">
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbUser_name" runat="server" Text='<%# Eval("User_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="行動裝置唯一識別碼">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbUnique_id" runat="server" Text='<%# Eval("Unique_id")%>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="行動裝置種類">
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbmob_type" runat="server" Text='<%# Eval("mob_type")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="是否停用">
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbisDisable" runat="server" Text='<%# IIf(Eval("Is_disable"), "停用", "使用中")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="備註說明">
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbNotes" runat="server" Text='<%# Eval("Notes")%>'></asp:Label>
                                            <asp:TextBox ID="btnETextBox" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="btnDTextBox" runat="server" Visible="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="功能">
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Button ID="btnEnable" runat="server" Text="啟用" Visible="false" OnClick="btnEnable_Click" />
                                            <asp:Button ID="btnDisable" runat="server" Text="停用" Visible="false" OnClick="btnDisable_Click" />
                                            <asp:Button ID="btnOK" runat="server" Text="確定" Visible="false" OnClick="btnOK_Click" />
                                            <asp:Button ID="btnCancel" runat="server" Text="取消" Visible="false" OnClick="btnCancel_Click"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <EmptyDataTemplate>
                                    查無資料
                                </EmptyDataTemplate>
                                <RowStyle CssClass="Row" />
                                <HeaderStyle CssClass="Grid" />
                                <AlternatingRowStyle CssClass="AlternatingRow" />
                                <PagerSettings Position="TopAndBottom" />
                                <EmptyDataRowStyle CssClass="EmptyRow" />
                            </asp:GridView>
                        </td>
                    </tr>
                     <tr>
                        <td align="right" class="TdHeightLight" style="width: 100%">
                            <uc1:Ucpager ID="Ucpager" runat="server" EnableViewState="true" GridName="gvlist"
                                PNow="1" PSize="30" Visible="true" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
