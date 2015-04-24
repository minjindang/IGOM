<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcBank.ascx.vb" Inherits="UControl_UcBank" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<style>
    .modalBackground
{
    background-color:Gray;
    filter:alpha(opacity=50);
    opacity:0.5;
}
</style>

<asp:TextBox ID="txtBank_id" runat="server" Enabled="False"></asp:TextBox>
<asp:TextBox ID="txtBank_name" runat="server" Enabled="False"></asp:TextBox>
<asp:Button ID="btnQuery" runat="server" Text="代碼查詢" />

<asp:ModalPopupExtender ID="btnQuery_ModalPopupExtender" runat="server" TargetControlID="btnQuery"
    PopupControlID="Panel1"
    BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>

<asp:Panel runat="server" ID="Panel1"  >
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">銀行代碼查詢
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">銀行代碼
                </td>
                <td style="width: 326px">
                    <asp:TextBox ID="txtBank_id_Q" runat="server"></asp:TextBox>
                </td>
                <td class="htmltable_Left">
                    銀行簡稱
                </td>
                <td style="width: 326px">
                    <asp:TextBox ID="txtBankAbbreviation_name_Q" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="DoneBtn" runat="server" Text="查詢" />
                    <asp:Button ID="ResetBtn" runat="server" Text="關閉" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <div id="div1" runat="server" visible="true">
                        <asp:GridView ID="GridViewA" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px"
                            Width="100%" EnableModelValidation="True">
                            <PagerSettings Visible="True" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText="選擇" />
                                <asp:BoundField DataField="Bank_id" HeaderText="銀行代碼" />
                                <asp:BoundField DataField="BankAbbreviation_name" HeaderText="銀行簡稱" />
                                <asp:BoundField DataField="Bank_name" HeaderText="銀行名稱" /> 
                            </Columns>
                            <RowStyle CssClass="Row" />
                            <HeaderStyle CssClass="Grid" />
                            <AlternatingRowStyle CssClass="AlternatingRow" />
                            <PagerSettings Position="TopAndBottom" />
                            <EmptyDataRowStyle CssClass="EmptyRow" />
                            <EmptyDataTemplate>
                                查無資料!
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>        
    </div>
</asp:Panel>
