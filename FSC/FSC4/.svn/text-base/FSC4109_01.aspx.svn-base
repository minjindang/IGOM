<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC4109_01.aspx.vb" Inherits="FSC4109_01"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                假別上限設定</td>
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
            <td class="htmltable_Left">
                假別
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlPDVTYPE" runat="server">
                </asp:DropDownList></td>
        </tr>
        
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                職務類別</td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlPEMEMCOD" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <asp:Button ID="cbQuery" runat="server" Text="查詢" />
                <input id="cbReset" type="button" value="重填" />
                <asp:Button ID="cbAdd" runat="server" Text="新增" />
                </td>
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
                        <asp:BoundField DataField="PDKIND" HeaderText="差勤組別" ></asp:BoundField>
                        <asp:BoundField DataField="PDMEMCODNAME" HeaderText="職務類別" ></asp:BoundField>
                        <asp:BoundField DataField="PDVTYPENAME" HeaderText="假別" ></asp:BoundField>
                        <asp:BoundField DataField="PDYEARB" HeaderText="休假年資(起)" />
                        <asp:BoundField DataField="PDYEARE" HeaderText="休假年資(迄)"  />
                        <asp:BoundField DataField="PDDAYS" HeaderText="上限天數"  />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbPDKIND" Text='<%# Bind("PDKIND") %>' Visible="false" />
                                <asp:Label runat="server" ID="lbPDMEMCOD" Text='<%# Bind("PDMEMCOD") %>' Visible="false" />
                                <asp:Label runat="server" ID="lbPDVTYPE" Text='<%# Bind("PDVTYPE") %>' Visible="false" />
                                <asp:Label runat="server" ID="lbPDYEARB" Text='<%# Bind("PDYEARB") %>' Visible="false" />
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

