<%@ Page Language="VB" MasterPageFile="~/MasterPage/PrintPage.master" AutoEventWireup="false" CodeFile="SYS3108_06.aspx.vb" Inherits="SYS3108_06"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title2">
                表單說明</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvFormList" runat="server" AutoGenerateColumns="False" CssClass="Grid" HeaderStyle-Font-Size="Small"
                    PagerStyle-HorizontalAlign="Right" width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="申請類別">
                            <ItemTemplate>
                                <asp:Label ID="lblMasterCodeName" runat="server" Text='<%# Bind("form_name")%>' Font-Size="small"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle  width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="申請項目">
                            <ItemTemplate>
                                <asp:Label ID="lblDetailCodeName" runat="server" Text='<%# Bind("form_desc")%>' Font-Size="small"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Title2">
                查詢結果
            </td>
        </tr>
        <tr>
            <td class="htmltable_Right">
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" ShowHeader="false" BorderStyle="none" BorderWidth="0" BorderColor="white"
                    width="100%" PagerStyle-HorizontalAlign="Right" AllowPaging="True" PageSize="30" EmptyDataText="查無資料!">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div style="margin-bottom:2px">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("User_name") %>' Font-Size="Small" Font-Bold="true"></asp:Label>
                                    (<asp:Label ID="Label2" runat="server" Text='<%# Bind("Depart_name") %>' Font-Size="Small" Font-Bold="true"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Title_name") %>' Font-Size="Small" Font-Bold="true"></asp:Label>)
                                </div>
                                <asp:GridView ID="gvi" runat="server" AutoGenerateColumns="False" Borderwidth="0px"
                                    CssClass="Grid" width="100%" PagerStyle-HorizontalAlign="Right" AllowPaging="True" PageSize="30" EmptyDataText="查無資料!">                
                                    <Columns>
                                        <asp:TemplateField HeaderText="類型" ItemStyle-width="120px" HeaderStyle-Font-Size="Small">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_lbformName" runat="server" Text='<%# Bind("form_name")%>' Font-Size="Small" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="簽核流程">
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="Small" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate><asp:Label ID="gv_lbOutpostName" runat="server" Text='<%# Bind("outpost_name")%>' Font-Size="Small" /></ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle HorizontalAlign="Right" />
                                    <PagerSettings Position="TopAndBottom" />
                                    <AlternatingRowStyle CssClass="AlternatingRow" />
                                    <RowStyle CssClass="Row" />
                                    <EmptyDataRowStyle CssClass="EmptyRow" />
                                </asp:GridView>         
                                      
                                <asp:Label ID="gv_lbOrgcode" runat="server" Text='<%# Bind("Orgcode") %>' Visible="false"></asp:Label>
                                <asp:Label ID="gv_lbId_card" runat="server" Text='<%# Bind("Id_card") %>' Visible="false"></asp:Label>
                                <asp:Label ID="gv_lbDepart_id" runat="server" Text='<%# Bind("Depart_id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="gv_lbTitle_no" runat="server" Text='<%# Bind("Title_no") %>'  Visible="false"></asp:Label>
                                <asp:Label ID="gv_lbEmployee_type" runat="server" Text='<%# Bind("Employee_type") %>'  Visible="false"></asp:Label>
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                 </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

