<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC3101_01.aspx.vb" Inherits="FSC3101_01"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="tbLeaveEmailNoticeSetting" border = "1" cellpadding = "0" cellspacing = "0" width="100%"   class="tableStyle99">                
        <tr>
            <td colspan="6" class="htmltable_Title">
                設定職務代理人</td>
        </tr>
        <tr>
            <td class="TdHeightLight">
                <asp:Button ID="cbAdd" runat="server"  PostBackUrl="" Text="新增職務代理人" /></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                    DataKeyNames="id" PagerStyle-HorizontalAlign="Right"
                    width="100%">
                    <PagerSettings FirstPageText="" LastPageText="" NextPageText="" Position="TopAndBottom"
                        PreviousPageText="" />
                    <RowStyle CssClass="Row" />
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbno" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="職稱代碼" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbPosid" runat="server" ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="職稱名稱" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbPosname" runat="server" ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="代理人姓名">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbUser_name" runat="server" Text='<%# Bind("User_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="代理人職稱代碼" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbTitle_no" runat="server" Text='<%# Bind("Title_no") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="代理人職稱名稱">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbTitle_name" runat="server" Text='<%# Bind("Title_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="代理類別">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbDeput_TypeName" runat="server" Text='<%# Bind("Deput_TypeName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="預設代理">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbDeputy_flag" runat="server" Text='<%# Bind("Deputy_flag") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="順序">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbDeputy_seq" runat="server" Text='<%# Bind("Deputy_seq")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="維護">
                            <ItemTemplate>
                                <asp:Button ID="gv_cbEdit" runat="server" OnClick="gv_cbEdit_Click" Text="修改" />
                                <asp:Button ID="gv_cbDelete" runat="server" OnClientClick="javascript:if(!confirm('是否確定刪除？')) return false;"
                                    Text="刪除" onclick="gv_cbDelete_Click" />
                                <asp:Label ID="gvlbid" runat="server" Text='<%# Bind("id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="gvlbDeputy_idcard" runat="server" Text='<%# Bind("Id_card") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle width="110px" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                </asp:GridView>            
            </td>
        </tr>
    </table>
</asp:Content>

