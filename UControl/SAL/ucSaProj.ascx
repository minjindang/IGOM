<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucSaProj.ascx.vb" Inherits="uc_ucSaProj" %>
<asp:DropDownList ID="DropDownList_proj_no" runat="server" DataSourceID="ObjectDataSource_dl" DataTextField="proj_code_name" DataValueField="proj_code" CssClass="formcss">
</asp:DropDownList><asp:ObjectDataSource ID="ObjectDataSource_dl" runat="server"
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByOrgid" TypeName="dt_SaProj_TableAdapters.SAPROJ_TableAdapter">
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox_orgid" DefaultValue="-1" Name="Orgid" PropertyName="Text"
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<div id="info" runat="server" style="display:none">
    Mode = 
    <asp:TextBox ID="TextBox_mode" runat="server"></asp:TextBox><br />
    Orgid =
    <asp:TextBox ID="TextBox_orgid" runat="server"></asp:TextBox><br />
    Selected = 
    <asp:TextBox ID="TextBox_selected" runat="server"></asp:TextBox><br />
</div>