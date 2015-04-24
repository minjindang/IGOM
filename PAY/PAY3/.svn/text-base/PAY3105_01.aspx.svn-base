<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="PAY3105_01.aspx.vb" Inherits="PAY_PAY3_PAY3105_01" %>

<%@ Register Src="~/UControl/UcBank.ascx" TagPrefix="uc1" TagName="UcBank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">受款人帳號維護
            </td>
        </tr>
         <tr>
            <td class="htmltable_Left">受款人編號
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtBeneficiary_id" runat="server" MaxLength="20"></asp:TextBox>
            </td>
            <td class="htmltable_Left">受款人姓名
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtBeneficiary_name" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>銀行代碼/名稱
            </td>
            <td style="width: 326px">
                <uc1:UcBank runat="server" ID="ucBank" />
            </td>
              <td class="htmltable_Left">受款人帳號
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtBankAccount_nos" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div align="center">
        <asp:Button ID="AddBtn" runat="server" Text="新增" />
        <asp:Button ID="QryBtn" runat="server" Text="查詢" />
        <asp:Button ID="ResetBtn" runat="server" Text="清空重填" />
    </div>

    <table id="div1" runat="server" visible="false" width="100%" class="tableStyle99">
        <tr>
            <td>
                <asp:GridView ID="GridViewA" runat="server"
                    AutoGenerateColumns="False"
                    AllowPaging="True" CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%"  EmptyDataText="查無資料!!">
                    <Columns>
                        <asp:BoundField DataField="Beneficiary_id" HeaderText="受款人編號" />
                        <asp:BoundField DataField="Beneficiary_name" HeaderText="受款人姓名" />
                        <asp:BoundField DataField="Bank_id" HeaderText="銀行代碼" />
                        <asp:BoundField DataField="Bank_name" HeaderText="銀行名稱" />
                        <asp:BoundField DataField="BankAccount_nos" HeaderText="受款人帳號" />
                        <asp:TemplateField HeaderText="維護">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Button ID="btn1" runat="server" Text="維護"
                                    CommandArgument='<%# Eval("Beneficiary_id")%>'
                                    CommandName="Maintain" />
                                <asp:Button ID="btn2" CommandName="GoDelete"
                                    runat="server" Text="刪除" OnClientClick="return confirm('是否確定要刪除?');"
                                    CommandArgument='<%# Eval("Beneficiary_id")%>' />
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
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                </asp:GridView>
            </td>
        </tr>        
    </table>
    <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
        PNow="1" PSize="10" Visible="true" />
</asp:Content>

