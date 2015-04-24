<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3105_01.aspx.vb" Inherits="SYS3105_01"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="Table1" runat="server" border="1" cellpadding="0" cellspacing="0" class="tableStyle99"
    width="100%">
    <tr>
        <td class="htmltable_Title2" colspan="2">
            功能選單設定
        </td>
    </tr>
    <tr>
        <td valign="top">            
            <asp:TreeView ID="tv" runat="server" ImageSet="XPFileExplorer" NodeIndent="15">
                <ParentNodeStyle Font-Bold="False" />
                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" 
                    HorizontalPadding="0px" VerticalPadding="0px" />
                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" 
                    HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
            </asp:TreeView>
        </td>
        <td valign="top">
            <table id="tb" runat="server" border="1" cellpadding="0" cellspacing="0" class="tableStyle99" width="100%" > 
                <tr>
                    <td class="htmltable_Title" colspan="2">
                        維護節點</td>
                </tr>    
                <tr>
                    <td class="htmltable_Left">
                        上層代號</td>
                    <td>
                        <asp:Label ID="lbParent_func_id" runat="server" Width="80" Font-Bold="true"></asp:Label></td>                           
                </tr>                        
                <tr>
                    <td class="htmltable_Left">
                        功能代號</td>
                    <td>
                        <asp:TextBox ID="tbFunc_id" runat="server" Width="80" ReadOnly="true"></asp:TextBox></td>                            
                </tr>                        
                <tr>                         
                    <td class="htmltable_Left">
                        功能名稱</td>
                    <td>
                        <asp:TextBox ID="tbFunc_name" runat="server" Width="220"></asp:TextBox></td>                          
                </tr>                        
                <tr>
                    <td class="htmltable_Left">
                        順序</td>
                    <td>
                        <asp:TextBox ID="tbFunc_sort" runat="server" Width="50" MaxLength="2"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        功能種類</td>
                    <td>
                        <asp:DropDownList ID="ddlFunc_type" runat="server">
                            <asp:ListItem Text="單一" Value="I"></asp:ListItem>
                            <asp:ListItem Text="群組" Value="G"></asp:ListItem>
                        </asp:DropDownList></td>                                                     
                </tr>                        
                <tr>
                    <td class="htmltable_Left">
                        功能連結</td>
                    <td>
                        <asp:TextBox ID="tbFunc_url" runat="server" Width="250"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        功能備註說明</td>
                    <td>
                        <asp:TextBox ID="tbFunc_Memo" runat="server" Width="100%" TextMode="MultiLine" Rows="5" MaxLength="255" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="htmltable_Bottom" colspan="2">
                        <asp:Button ID="cbUpdate" runat="server" Text="確定" OnClick="cbUpdate_Click" Enabled="false"/>
                        <asp:Button ID="cbDelete" runat="server" Text="刪除" OnClick="cbDelete_Click" Enabled="false"/>
                        <asp:Button ID="cbCancel" runat="server" Text="取消" OnClick="cbCancel_Click" Enabled="false"/>
                        </td>
                </tr>
            </table>
            <br />
            <br />
            
            <table id="Table2" runat="server" border="1" cellpadding="0" cellspacing="0" class="tableStyle99" width="100%" > 
                <tr>
                    <td class="htmltable_Title" colspan="2">
                        新增節點</td>
                </tr>    
                <tr>
                    <td class="htmltable_Left">
                        上層代號</td>
                    <td>
                        <asp:Label ID="lbParent_func_id1" runat="server" Width="80" Font-Bold="true"></asp:Label></td>                           
                </tr>                        
                <tr>
                    <td class="htmltable_Left">
                        功能代號</td>
                    <td>
                        <asp:TextBox ID="tbFunc_id1" runat="server" Width="80"></asp:TextBox></td>                            
                </tr>                        
                <tr>                         
                    <td class="htmltable_Left">
                        功能名稱</td>
                    <td>
                        <asp:TextBox ID="tbFunc_name1" runat="server" Width="220"></asp:TextBox></td>                          
                </tr>                        
                <tr>
                    <td class="htmltable_Left">
                        順序</td>
                    <td>
                        <asp:TextBox ID="tbFunc_sort1" runat="server" Width="50" MaxLength="2"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        功能種類</td>
                    <td>
                        <asp:DropDownList ID="ddlFunc_type1" runat="server">
                            <asp:ListItem Text="單一" Value="I"></asp:ListItem>
                            <asp:ListItem Text="群組" Value="G"></asp:ListItem>
                        </asp:DropDownList></td>                                                     
                </tr>                        
                <tr>
                    <td class="htmltable_Left">
                        功能連結</td>
                    <td>
                        <asp:TextBox ID="tbFunc_url1" runat="server" Width="250"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        功能備註說明</td>
                    <td>
                        <asp:TextBox ID="tbFunc_Memo1" runat="server" Width="100%" TextMode="MultiLine" Rows="5" MaxLength="255" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="htmltable_Bottom" colspan="2">
                        <asp:Button ID="cbAdd" runat="server" Text="確定" OnClick="cbAdd_Click" Enabled="false" />
                        <asp:Button ID="cbCancel1" runat="server" Text="取消" OnClick="cbCancel_Click" Enabled="false"/>
                        </td>
                </tr>
            </table>
        </td>    
    </tr>
</table>

</asp:Content>

