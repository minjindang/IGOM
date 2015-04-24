<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC4107_01.aspx.vb" Inherits="FSC4107_01"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
$(function() {
	$( "#tabs" ).tabs();
});
</script>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                差勤參數設定</td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                差勤組別
            </td>
            <td class="htmltable_Right">           
                <asp:DropDownList ID="ddlPDKIND" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <asp:Button ID="cbQuery" runat="server" Text="查詢" />
                <input id="cbReset" type="button" value="重填" />
                <input id="cbAdd" type="button" value="新增" onclick="document.location.href='FSC4107_02.aspx'" /></td>
        </tr>
    </table>
    <br />
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" runat="server" id="tbSetting">
        <tr>
            <td class="htmltable_Title" colspan="2">
                差勤參數設定</td>
        </tr>
        <tr>
            <td>            
            <div id="tabs">
            <ul>
	            <li><a href="#tabs-1">上限設定</a></li>
	            <li><a href="#tabs-2">刷卡設定</a></li>
	            <li><a href="#tabs-3">班別設定</a></li>
            </ul>
            <div id="tabs-1">	            
            <asp:GridView ID="ltgv" runat="server" AutoGenerateColumns="false" CssClass="Grid">            
                <Columns>
                    <asp:TemplateField HeaderText="描述">
                        <ItemTemplate>
                            <asp:Label ID="lbPCKIND" runat="server" Text='<%# Bind("PCKIND") %>' Width="280" Visible="false"></asp:Label>
                            <asp:Label ID="lbPCITEM" runat="server" Text='<%# Bind("PCITEM") %>' Width="280" Visible="false"></asp:Label>
                            <asp:Label ID="lbPCCODE" runat="server" Text='<%# Bind("PCCODE") %>' Width="280" Visible="false"></asp:Label>
                            <asp:Label ID="lbPCDESC" runat="server" Text='<%# Bind("PCDESC") %>' Width="280"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="值">
                        <ItemTemplate>
                            <asp:Textbox ID="tbPCPARM1" runat="server" Text='<%# Bind("PCPARM1") %>' Width="80" MaxLength="5" ></asp:Textbox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>        
            </asp:GridView>
            </div>            
	        <div id="tabs-2">
            <asp:GridView ID="reggv" runat="server" AutoGenerateColumns="false" CssClass="Grid"> 
                <Columns>
                    <asp:TemplateField HeaderText="描述">
                        <ItemTemplate>
                            <asp:Label ID="lbPCKIND" runat="server" Text='<%# Bind("PCKIND") %>' Width="280" Visible="false"></asp:Label>
                            <asp:Label ID="lbPCITEM" runat="server" Text='<%# Bind("PCITEM") %>' Width="280" Visible="false"></asp:Label>
                            <asp:Label ID="lbPCCODE" runat="server" Text='<%# Bind("PCCODE") %>' Width="280" Visible="false"></asp:Label>
                            <asp:Label ID="lbPCDESC" runat="server" Text='<%# Bind("PCDESC") %>' Width="280"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="值">
                        <ItemTemplate>
                            <asp:Textbox ID="tbPCPARM1" runat="server" Text='<%# Bind("PCPARM1") %>' Width="80" MaxLength="1" ></asp:Textbox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>            
	        <div id="tabs-3">
            <asp:GridView ID="wtgv" runat="server" AutoGenerateColumns="false" CssClass="Grid">    
                <Columns>
                    <asp:TemplateField HeaderText="描述">
                        <ItemTemplate>
                            <asp:Label ID="lbPCKIND" runat="server" Text='<%# Bind("PCKIND") %>' Width="280" Visible="false"></asp:Label>
                            <asp:Label ID="lbPCITEM" runat="server" Text='<%# Bind("PCITEM") %>' Width="280" Visible="false"></asp:Label>
                            <asp:Label ID="lbPCCODE" runat="server" Text='<%# Bind("PCCODE") %>' Width="280" Visible="false"></asp:Label>
                            <asp:Label ID="lbPCDESC" runat="server" Text='<%# Bind("PCDESC") %>' Width="280"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="起">
                        <ItemTemplate>
                            <asp:Textbox ID="tbPCPARM1" runat="server" Text='<%# Bind("PCPARM1") %>' Width="80" MaxLength="4" ></asp:Textbox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="迄">
                        <ItemTemplate>
                            <asp:Textbox ID="tbPCPARM2" runat="server" Text='<%# Bind("PCPARM2") %>' Width="80" MaxLength="4" ></asp:Textbox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>            
            </div>
            </div>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom">
            <asp:Button ID="cbConfirm" runat="server" Text="確認" />
            </td>
        </tr>
    </table>
</asp:Content>

