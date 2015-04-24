<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucSaSpesup.ascx.vb" Inherits="uc_ucSaSpesup" %>
<asp:DropDownList ID="DropDownList_series" runat="server" DataSourceID="ObjectDataSource_dl" DataTextField="SPESUP_SAL" DataValueField="SPESUP_SERIES" CssClass="formcss">
</asp:DropDownList>

<asp:ObjectDataSource ID="ObjectDataSource_dl" runat="server"
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByType2" TypeName="dt_SaSpesup_TableAdapters.SASPESUP_TableAdapter">
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox_type" DefaultValue="-1" Name="type" PropertyName="Text"
            Type="String" />
        <asp:ControlParameter ControlID="TextBox_no" DefaultValue="-1" Name="no" PropertyName="Text"
            Type="String" />
        <asp:ControlParameter ControlID="TextBox_ym" DefaultValue="-1" Name="ym" PropertyName="Text"
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<div id="info" style="display:none">
TYPE=<asp:TextBox ID="TextBox_type" runat="server" Text="004"></asp:TextBox><br/>
NO=<asp:TextBox ID="TextBox_no" runat="server" Text ="001"></asp:TextBox><br />
YM=<asp:TextBox ID="TextBox_ym" runat="server" Text="201405"></asp:TextBox><br />
Selected=<asp:TextBox ID="TextBox_selected" runat="server"></asp:TextBox><br />
</div>
