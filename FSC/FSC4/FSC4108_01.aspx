<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC4108_01.aspx.vb" Inherits="FSC4108_01"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                假別規則說明</td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                差勤組別
            </td>
            <td class="htmltable_Right">           
                <asp:DropDownList ID="ddlLeaveKind" runat="server">
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                假別
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlLeaveType" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                職務類別</td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlMEMCOD" runat="server">
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
                        <asp:BoundField DataField="Leave_kind" HeaderText="差勤組別" ></asp:BoundField>
                        <asp:BoundField DataField="Leave_type_name" HeaderText="假別" ></asp:BoundField>
                        <asp:BoundField DataField="Memcod_name" HeaderText="職務類別" ></asp:BoundField>
                        <asp:BoundField DataField="Describe" HeaderText="假別規則說明" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Limit" HeaderText="申請期限天數" />
                        <asp:BoundField DataField="Limit_date_format" HeaderText="申請期限日期" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbid" Text='<%# Bind("id")%>' Visible="false" />
                                <asp:Label runat="server" ID="lbOrgcode" Text='<%# Bind("Orgcode") %>' Visible="false" />
                                <asp:Label runat="server" ID="lbDepart_id" Text='<%# Bind("Depart_id") %>' Visible="false" />
                                <asp:Label runat="server" ID="lbLeave_kind" Text='<%# Bind("Leave_kind") %>' Visible="false" />
                                <asp:Label runat="server" ID="lbLeave_type" Text='<%# Bind("Leave_type") %>' Visible="false" />
                                <asp:Label runat="server" ID="lbMemcod" Text='<%# Bind("Memcod") %>' Visible="false" />
                                <asp:Button runat="server" ID="cbUpdate" Text="修改" onclick="cbUpdate_Click" />
                                <asp:Button runat="server" ID="cbCopy" Text="複製" onclick="cbCopy_Click" />
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

