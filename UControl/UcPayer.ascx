<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcPayer.ascx.vb" Inherits="UControl_UcPayer" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<style>
    .modalBackground
    {
        background-color: Gray;
        filter: alpha(opacity=50);
        opacity: 0.5;
    }
</style>

<asp:TextBox ID="txtPayer_id" runat="server" Enabled="False"></asp:TextBox>
<asp:TextBox ID="txtPayer_name" runat="server" Enabled="False"></asp:TextBox>
<asp:Button ID="btnQuery" runat="server" Text="付款人查詢" />

<asp:ModalPopupExtender ID="btnQuery_ModalPopupExtender" runat="server" TargetControlID="btnQuery"
    PopupControlID="Panel1"
    BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>

<asp:Panel runat="server" ID="Panel1" BackColor="White">
    <div id="Div_Approve_Query" runat="server">
        <asp:GridView ID="GridViewA" runat="server" AutoGenerateColumns="False" AllowPaging="True"
            PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px"
            Width="100%" EnableModelValidation="True">
            <PagerSettings Visible="True" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="選擇" />
                <asp:BoundField DataField="Payer_id" HeaderText="付款人代號" />
                <asp:BoundField DataField="Payer_name" HeaderText="付款人名稱" />
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
        <asp:Button ID="btnClose" runat="server" Text="取消" />
    </div>
</asp:Panel>
