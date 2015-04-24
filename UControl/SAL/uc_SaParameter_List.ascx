<%@ Control Language="VB" AutoEventWireup="false" CodeFile="uc_SaParameter_List.ascx.vb" Inherits="uc_uc_SaParameter_List" %>

<table style="width:100%;" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="width:60%">
            &nbsp;民國
            <asp:DropDownList ID="DropDownList_ym" runat="server" 
            AutoPostBack="True" 
            DataSourceID="ObjectDataSource_ym" 
            DataTextField="ymstr"
            DataValueField="parameter_ym" >
            </asp:DropDownList>
            實施
        </td>
        <td style="width:40%; text-align:center;">
            &nbsp;
            <asp:Label ID="Label_value" runat="server" Text=""></asp:Label>
        </td>
    </tr>
</table>

<asp:ObjectDataSource ID="ObjectDataSource_ym" runat="server"
    OldValuesParameterFormatString="original_{0}" SelectMethod="spExeSQLGetDataTable"
    TypeName="DB_TableAdapters.DB_TableAdapter">
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox_ym" DefaultValue="select top 1 * from saparameter where 1=0"
            Name="SQLs" PropertyName="Text" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

<div id="div_info" runat="server" visible="false">
    CODE_SYS  = <asp:TextBox ID="TextBox_code_sys" runat="server"></asp:TextBox><br />
    CODE_KIND = <asp:TextBox ID="TextBox_code_kind" runat="server"></asp:TextBox><br />
    CODE_TYPE = <asp:TextBox ID="TextBox_code_type" runat="server"></asp:TextBox><br />
    CODE_NO   = <asp:TextBox ID="TextBox_code_no" runat="server"></asp:TextBox><br />
    <hr />
    YM_SQL    = <asp:TextBox ID="TextBox_ym" runat="server"></asp:TextBox><br />
</div>