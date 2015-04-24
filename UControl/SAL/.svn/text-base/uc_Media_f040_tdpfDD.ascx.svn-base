<%@ Control Language="VB" AutoEventWireup="false" CodeFile="uc_Media_f040_tdpfDD.ascx.vb" Inherits="uc_uc_Media_f040_tdpfDD" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:DropDownList ID="DropDownList_tdpf" runat="server" 
        DataSourceID="ObjectDataSource_tdpf" DataTextField="text" 
        DataValueField="tdpf_seqno" AutoPostBack="true">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource_tdpf" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="dt_SaTdpf_TableAdapters.uc_Media_f040_tdpfDD_TableAdapter">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox_orgid" DefaultValue="-1" Name="orgid" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <div id="div_info" runat="server" visible="false">
            orgid=<asp:TextBox ID="TextBox_orgid" runat="server"></asp:TextBox>
            selected=<asp:TextBox ID="TextBox_selected" runat="server"></asp:TextBox>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>