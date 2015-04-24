<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="SYS3106_01.aspx.vb" Inherits="SYS3106_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">  
    <table border = "0" cellpadding = "0" cellspacing = "0" width = "100%" class="tableStyle99" id="TABLE1" runat="server">
        <tr>
            <td class="htmltable_Title">
            角色權限維護</td>
        </tr>
        <tr>
            <td class="TdHeightLight">
                <asp:Button ID="btnAdd" runat="server" Text="新增角色"  />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Right">                       
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" CssClass="Grid" PageSize="30"
                    BorderWidth="0px" PagerStyle-HorizontalAlign="Right" AllowPaging="True" Width="100%">                                                                        
                    <Columns>
                        <asp:TemplateField HeaderText="角色代號">                           
                            <ItemTemplate>
                                <asp:Label ID="lbRole_id" runat="server" Text='<%# Bind("Role_id") %>'></asp:Label>
                                <asp:Label ID="lbOrgcode" runat="server" Text='<%# Bind("Orgcode") %>' Visible="false" ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="角色名稱">
                            <ItemTemplate>
                                <asp:Label ID="lbRole_name" runat="server" Text='<%# Bind("Role_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="上層管理者">
                            <ItemTemplate>
                                <asp:Label ID="lbBoss_Role" runat="server" Text='<%# Bind("Boss_RoleName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="管理者">
                            <ItemTemplate>
                                <asp:Label ID="lbManagerFlag" runat="server" Text='<%# IIf(Eval("Manager_flag") = "Y", "是", "否")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="目前狀態">
                            <ItemTemplate>
                                <asp:Label ID="lbrole_status" runat="server" Text='<%# IIf(Eval("role_status") = "1", "正常", "停用")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="功能">
                            <ItemTemplate>
                                <asp:Button ID="Button1" runat="server" CommandArgument='<%# Eval("Role_id") %>'
                                        CommandName="UpdateRole" Text="修改" />
                                <asp:Button ID="btnSetModule" runat="server" CommandArgument='<%# Eval("Role_id") %>'
                                        CommandName="SetModule" Text="權限設定" />
                                <asp:Button ID="Button2" runat="server" CommandArgument='<%# Eval("Role_id") %>'
                                        CommandName="SetForm" Text="表單設定" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" CssClass="Pager"></PagerStyle>
                    <EmptyDataTemplate>
                    </EmptyDataTemplate>
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td  align="right" class="TdHeightLight" colspan="2">
                 <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvList"
                        Other1="Ucpager2" PNow="1" PSize="30" Visible="true" />
            </td>
        </tr> 
    </table>
</asp:Content>
