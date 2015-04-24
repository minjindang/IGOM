<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcFlowDetail.ascx.vb" Inherits="UControl_SYS_UcFlowDetail" %>
<asp:HiddenField ID="hfFlowId" runat="server" />
<asp:HiddenField ID="hfOrgcode" runat="server" />
<asp:DataList ID="dl" runat="server" RepeatDirection="Horizontal" CssClass="DataList">
    <ItemTemplate>
        <table>
            <tr>
                <td align="center">
                    <asp:Label ID="gv_lbtext" runat="server" Text='<%# Bind("text") %>' /><br/>
                    <asp:Image ID="gv_img" runat="server" ImageUrl='<%# Bind("img_url")%>' /><br/>
                    <asp:Label ID="gv_lbagreeName" runat="server" Text='<%# Bind("agree_name")%>' /><br/>
                    <asp:Label ID="gv_lbagreeDate" runat="server" Text='<%# Bind("agree_date")%>' /><br/>
                    <asp:Label ID="gv_lbagreeTime" runat="server" Text='<%# Bind("agree_time")%>' /><br/>
                    <asp:Label ID="gv_lbagreeFlag" runat="server" Text='<%# Bind("agree_flag")%>' /><br/>
                </td>
                <td>                    
                    <asp:Image ID="gv_img2" runat="server" ImageUrl='<%# Bind("img_url2")%>' Visible='<%# IIf(String.IsNullOrEmpty(Eval("img_url2")), False, True)%>' />
                </td>
            </tr>
        </table>        
    </ItemTemplate>
</asp:DataList>

