<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT2111_01.aspx.vb" Inherits="MAT_MAT2_MAT2111_01" %>
 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <asp:HiddenField ID="hfFlow_id" runat="server" />
        <table width="100%" id="GridViewTable" runat="server" class="tableStyle99">
            <tr id="trQueryResult" runat="server">
                <td class="htmltable_Title">
                    <asp:Label runat="server" ID="lblTitle" /></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width="100%"
                        CssClass="Grid" BorderWidth="0px" PagerStyle-HorizontalAlign="Right">
                        <Columns>
                            <asp:BoundField DataField="Form_type" HeaderText="領用類別" />
                            <asp:BoundField DataField="Unit_Code" HeaderText="單位別" />
                            <asp:BoundField DataField="User_id" HeaderText="領物申請人" />
                            <asp:BoundField DataField="Flow_id" HeaderText="領物單編號" />
                            <asp:BoundField DataField="Material_id" HeaderText="物料編號" />
                            <asp:BoundField DataField="Material_name" HeaderText="物料名稱" />
                            <asp:BoundField DataField="Apply_cnt" HeaderText="申請數量" />
                            <asp:TemplateField HeaderText="領用數量">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtOut_cnt" runat="server" Width="90px" MaxLength="50" Text='<%# Eval("Apply_cnt")%>'></asp:TextBox>
                                    <asp:HiddenField ID="hfDetails_id" runat="server" Value='<%# Eval("Details_id")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Unit" HeaderText="單位" />
                            <asp:BoundField DataField="Memo" HeaderText="用途說明" />
                        </Columns>
                        <EmptyDataTemplate>
                            無成批領物明細資料
                        </EmptyDataTemplate>
                        <PagerStyle HorizontalAlign="Right" />
                        <RowStyle CssClass="Row" />
                        <AlternatingRowStyle CssClass="AlternatingRow" />
                        <EmptyDataRowStyle CssClass="EmptyRow" />
                    </asp:GridView>
                </td>
            </tr>

        </table>
        <div align="center" id="divButton" runat="server">
            <asp:Button ID="DoneBtn" runat="server" Text="確認" />
            <asp:Button ID="ResetBtn" runat="server" Text="清空重填" />
            <input id="cbPrint"
                type="button" value="列印" onclick="javascript: window.print();" class="nonPrinted" />
        </div>

</asp:Content>

