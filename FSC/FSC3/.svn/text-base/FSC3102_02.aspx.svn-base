<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC3102_02.aspx.vb" Inherits="FSC3102_02" EnableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="tbLeaveEmailNoticeSetting" border = "1" cellpadding = "0" cellspacing = "0" width="100%"   class="tableStyle99">                
        <tr>
            <td colspan="4" class="htmltable_Title">
                預設代理人資料維護</td>
        </tr>
    </table>
    <table id="dataList" runat="server" visible="false" border="0" cellpadding="0" cellspacing="0"  width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title2" colspan="4">
                查詢結果
            </td>
        </tr>
        <tr>
            <td colspan="4" class="htmltable_Bottom">
                <asp:Button ID="btnBack" runat="server" Text="返回" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%;" class="htmltable_Right" colspan="4">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Borderwidth="0px" AllowPaging="True" PageSize="30"
                        CssClass="Grid" PagerStyle-HorizontalAlign="Right" width="100%" EmptyDataText="查無資料">                       
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1%> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="職稱">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbPosid" runat="server" Text='<%# Eval("user_title") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="代理人姓名">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbUser_name" runat="server" Text='<%# Eval("User_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="代理人職稱">
                            <ItemTemplate>
                                <asp:Label ID="gv_lbTitle_no" runat="server" Text='<%# Eval("title_name") %>'></asp:Label>
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
                                <asp:Button ID="gv_cbEdit" runat="server" Text="修改" OnClick="gv_cbEdit_Click" CommandArgument='<%# Eval("id")%>' />
                                <asp:Button ID="gv_cbDelete" runat="server" OnClick="gv_cbDelete_Click" CommandArgument='<%# Eval("id") %>'
                                                         OnClientClick="javascript:if(!confirm('是否確定刪除？')) return false;" Text="刪除" />

                                <asp:Label ID="gv_lbDeputy_idcard" runat="server" Text='<%# Eval("id_card") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle width="110px" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <EmptyDataTemplate>
                        查無資料!!
                    </EmptyDataTemplate>
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />                    
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right" class="TdHeightLight" colspan="4">
                <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvList"
                    PNow="1" PSize="30" Visible="true" />
            </td>
        </tr>                 
    </table>
</asp:Content>

