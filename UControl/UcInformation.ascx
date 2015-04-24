<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcInformation.ascx.vb" Inherits="UControl_UcInformation" %>
<asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CssClass="Grid"
    width="100%" ShowHeader="False">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink ID="gv_hl1" runat="server" Text='<%# Bind("Inf_title") %>' Target="_blank"></asp:HyperLink>
                <asp:Label ID="gv_lbSerial_nos" runat="server" Text='<%# Bind("Serial_nos") %>' Visible="false"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Label ID="gv_lb2" runat="server" Text='<%# Bind("Inf_title") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink ID="gv_hl3" runat="server" Text='<%# Bind("Inf_title") %>' NavigateUrl='<%# Bind("Inf_link") %>' Target="_blank"></asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
