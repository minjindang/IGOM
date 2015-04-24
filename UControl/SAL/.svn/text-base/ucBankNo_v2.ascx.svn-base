<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucBankNo_v2.ascx.vb" Inherits="uc_ucBankNo_v2" %>

    轉帳銀行
    <asp:DropDownList ID="oBankNoDDL" runat="server" 
    DataSourceID="oBankNoDDL_ObjectDataSource1" DataTextField="ccText" DataValueField="ccValue" />
    <br />
    轉帳帳號
    <asp:TextBox ID="TextBox_account_no" runat="server"></asp:TextBox> 
    
<asp:ObjectDataSource ID="oBankNoDDL_ObjectDataSource1" runat="server" 
    TypeName="DB_TableAdapters.DB_TableAdapter" SelectMethod="spExeSQLGetDataTable" >
    <SelectParameters> <asp:Parameter Name="SQLs" Type="String" ConvertEmptyStringToNull="false" DefaultValue="" /> </SelectParameters>
</asp:ObjectDataSource>

<asp:Panel ID="Configz" runat="server" Visible="false" >
    <div>_base_seqno = <asp:Label ID="_base_seqno" runat="server" /></div>
    <div>_UserOrgId = <asp:Label ID="_UserOrgId" runat="server" /></div>
    <div>Bank_code = <asp:TextBox ID="TextBox_bank_code" runat="server"></asp:TextBox></div>
</asp:Panel>
