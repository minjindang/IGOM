<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3114_01.aspx.vb" Inherits="SYS3114_01"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                常用片語維護</td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                申請種類
            </td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList runat="server" ID="ddlphrases_kind" DataTextField="CODE_DESC1" DataValueField="CODE_NO" AutoPostBack="true" ></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                申請項目
            </td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList runat="server" ID="ddlphrases_type" DataTextField="CODE_DESC1" DataValueField="CODE_NO" AutoPostBack="true" ></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                常用片語
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbphrases" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                是否啟用</td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlvisable_flag" runat="server">
                    <asp:ListItem value="1">啟用</asp:ListItem>
                    <asp:ListItem value="0">停用</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <asp:Button ID="cbQuery" runat="server" Text="查詢" />
                <input id="cbReset" type="button" value="重填" />
               <asp:Button ID="cbAdd" runat="server" Text="新增" /></td>
        </tr>
    </table>
    <br />
    
    <table id="dataList" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" visible="false">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                查詢結果
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30"
                    BorderWidth="0px" CssClass="Grid" PagerStyle-HorizontalAlign="Right" Width="100%"
                    EmptyDataText="查無資料!!">
                    <Columns>
                       <asp:TemplateField HeaderText="項次">
                           <ItemStyle HorizontalAlign="Center" Width="15px" />
                              <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
                                <ItemTemplate>
                                  <asp:Label ID="lblno" runat="server" Text='<%# (container.dataitemindex+1).tostring() %>'></asp:Label>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Kind_Name" HeaderText="申請種類" ></asp:BoundField>
                        <asp:BoundField DataField="Type_Name" HeaderText="申請項目" ></asp:BoundField>
                        <asp:BoundField DataField="phrases" HeaderText="常用片語" ></asp:BoundField>
                        <asp:BoundField DataField="visable" HeaderText="是否起用"  />
                         <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblID" Text='<%# Bind("id") %>' Visible="false" />
                                <asp:Button runat="server" ID="cbUpdate" Text="修改" onclick="cbUpdate_Click" />
                                <asp:Button runat="server" ID="cbDelete" Text="刪除" onclick="cbDelete_Click" OnClientClick="javascript:if(!confirm('是否確定刪除？')) return false;" />
                            </ItemTemplate>
                            <ItemStyle  HorizontalAlign="center" Width="100px" />
                        </asp:TemplateField> 
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <EmptyDataTemplate>
                        查無資料!!
                    </EmptyDataTemplate>
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right" class="TdHeightLight" style="width: 100%">
                <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvList"
                    PNow="1" PSize="30" Visible="true" />
            </td>
        </tr>        
    </table>
</asp:Content>

