<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC4102_02.aspx.vb" Inherits="FSC4102_02" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table id="TABLE2" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
        class="tableStyle99">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                ���q���H���]�w
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnToFSC4102_01" runat="server" CausesValidation="False" Text="E-mail�޲z���]�w" />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px" 
                    CssClass="Grid" PagerStyle-HorizontalAlign="Right" Width="100%"
                    EmptyDataText="�d�L���">
                    <Columns>
                        <asp:BoundField DataField="num" HeaderText="����" ItemStyle-Width="100px" HeaderStyle-Width="100px" />
                        <asp:BoundField DataField="Leave_name" HeaderText="�t���O" />
                        <asp:BoundField DataField="User_names" HeaderText="����H" />
                        <asp:TemplateField HeaderText="���@">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" CommandArgument='<%# Eval("Leave_type") & ","  &  Eval("Leave_name") %>'
                                    CommandName="Modify" Text="�ק�" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <EmptyDataTemplate>
                        �d�L���!!
                    </EmptyDataTemplate>
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
    </table>
            
</asp:Content>
