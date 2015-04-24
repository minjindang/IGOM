<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucSaStws.ascx.vb" Inherits="uc_ucSaStws" %>
<asp:DropDownList ID="DropDownList_level" runat="server" DataSourceID="ObjectDataSource_dl" DataTextField="STWS_STAND" DataValueField="STWS_LEVEL">
</asp:DropDownList>

<asp:ObjectDataSource ID="ObjectDataSource_dl" runat="server"
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByNo" TypeName="dt_SaStws_TableAdapters.SASTWS_TableAdapter">
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox_no" DefaultValue="-1" Name="no" PropertyName="Text"
            Type="String" />
        <asp:ControlParameter ControlID="TextBox_ym" DefaultValue="-1" Name="ym" PropertyName="Text"
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<div id="info" style="display:none">
NO=<asp:TextBox ID="TextBox_no" runat="server"></asp:TextBox><br />
YM=<asp:TextBox ID="TextBox_ym" runat="server"></asp:TextBox><br />
MODE=<asp:TextBox ID="TextBox_mode" runat="server"></asp:TextBox><br />
Selected=<asp:TextBox ID="TextBox_selected" runat="server"></asp:TextBox><br />
</div>