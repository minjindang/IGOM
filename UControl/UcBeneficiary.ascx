<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcBeneficiary.ascx.vb" Inherits="UControl_UcBeneficiary" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<style>
    .modalBackground
{
    background-color:Gray;
    filter:alpha(opacity=50);
    opacity:0.5;
}
</style>

<asp:TextBox ID="txtBeneficiary_id" runat="server" Enabled="False" Width="100"></asp:TextBox>
<asp:TextBox ID="txtBeneficiary_name" runat="server" Enabled="False"></asp:TextBox>
<asp:Button ID="btnQuery" runat="server" Text="受款人查詢" />

<asp:ModalPopupExtender ID="btnQuery_ModalPopupExtender" runat="server" TargetControlID="btnQuery"
    PopupControlID="Panel1"
    BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>

<asp:Panel runat="server" ID="Panel1" BackColor="White"  >
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="500px">
            <tr>
                <td class="htmltable_Title" colspan="4">受款人查詢畫面
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">受款人帳號
                </td>
                <td>
                    <asp:TextBox ID="txtBeneficiary_id_Q" runat="server" Width="100"></asp:TextBox>
                </td>
                <td class="htmltable_Left">
                    受款人姓名
                </td>
                <td>
                    <asp:TextBox ID="txtBeneficiary_name_Q" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="DoneBtn" runat="server" Text="查詢" />
                    <asp:Button ID="ResetBtn" runat="server" Text="關閉" />
                </td>
            </tr>
        </table>
        <div id="div1" runat="server" visible="true">
            <asp:GridView ID="GridViewA" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px"
                Width="100%" EnableModelValidation="True">
                <PagerSettings Visible="True" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="選擇" />
                    <asp:BoundField DataField="Beneficiary_id" HeaderText="受款人帳號" />
                    <asp:BoundField DataField="Beneficiary_name" HeaderText="受款人姓名" /> 
                </Columns>
                <RowStyle CssClass="Row" />
                <HeaderStyle CssClass="Grid" />
                <AlternatingRowStyle CssClass="AlternatingRow" />
                <PagerSettings Position="TopAndBottom" />
                <EmptyDataRowStyle CssClass="EmptyRow" />
            </asp:GridView>

        </div>
    </div>
</asp:Panel>
