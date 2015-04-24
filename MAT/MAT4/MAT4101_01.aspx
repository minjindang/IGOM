<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT4101_01.aspx.vb" Inherits="MAT4101_01" %>

<%@ Register src="~/UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc2" %>
<%@ Register Src="~/UControl/MAT/UcMaterialId.ascx" TagPrefix="uc1" TagName="UcMaterialClass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">
                    物料基本資料維護-查詢
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">物料編號
                </td>
                <td style="width: 326px">
                   <asp:TextBox ID="txtMaterialId" runat="server" Width="120px" Text="" MaxLength="9"></asp:TextBox>
                    <uc1:UcMaterialClass runat="server" ID="UcMaterialClassB" OnChecked="UcMaterialClassB_Checked" />
                </td>
              <td class="htmltable_Left">存放地點
                </td>
                <td style="width: 326px">
                    <asp:TextBox ID="txtLocation" runat="server" Width="150px"></asp:TextBox>
                </td>
            </tr>
         <%--   <tr>
                <td class="htmltable_Left">建檔日期
                </td>
                <td colspan="3">
                    <uc2:UcDate ID="ucModDate" runat="server" />
                </td>
            </tr>--%>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="AddBtn" runat="server" Text="新增" PostBackUrl="~/MAT/MAT4/MAT4101_02.aspx" />
                    <asp:Button ID="QryBtn" runat="server" Text="查詢" />
                    <asp:Button ID="ResetBtn" runat="server" Text="清空重填" PostBackUrl="~/MAT/MAT4/MAT4101_01.aspx" />
                </td>
            </tr>
        </table>
        <div id="div1" runat="server" visible="false">
            <asp:GridView ID="GridViewA" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px"
                Width="100%" EmptyDataText="查無資料!!"> 
                <Columns>
                    <asp:BoundField DataField="Material_id" HeaderText="物料編號" />
                    <asp:BoundField DataField="Material_name" HeaderText="物料名稱" />
                    <asp:BoundField DataField="Unit" HeaderText="單位" />
                    <asp:TemplateField HeaderText="單位領用限量(單位/月)">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="label1" Text='<%# Eval("UnitLimit_cnt").ToString() + "/" + Eval("UnitLimitMM_cnt").ToString()%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="員工領用限量(單位/月)">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="label2" Text='<%# Eval("PersonLimit_cnt").ToString() + "/" + Eval("PersonLimitMM_cnt").ToString() %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Safe_cnt" HeaderText="安全庫存數量" />
                    <asp:BoundField DataField="Reserve_cnt" HeaderText="目前庫存數量" />
                    <asp:BoundField DataField="Available_cnt" HeaderText="目前可用餘額" />
                    <asp:BoundField DataField="Location" HeaderText="存放地點" />
                    <asp:BoundField DataField="Memo" HeaderText="備註說明" />
                         <asp:TemplateField HeaderText="異動日期">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbMod_date" Text='<%# FSCPLM.Logic.DateTimeInfo.ConvertToDisplay(FSCPLM.Logic.DateTimeInfo.GetRocDate(Eval("Mod_date")))%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
               <%--     <asp:BoundField DataField="Mod_date" HeaderText="異動日期" DataFormatString="{0:d}" />--%>
                    <asp:TemplateField HeaderText="維護">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Button ID="btnAdd" runat="server" Text="維護" CommandName="Maintain" CommandArgument='<%# Eval("Material_id")%>' />
                            <asp:Button ID="btnDelete" CommandName="GoDelete" CommandArgument='<%# Eval("Material_id")  %>'
                                runat="server" Text="刪除" OnClientClick="return confirm('是否確定要刪除?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                       查無資料!!
                 </EmptyDataTemplate>
                <RowStyle CssClass="Row" />
                <HeaderStyle CssClass="Grid" />
                <AlternatingRowStyle CssClass="AlternatingRow" />
                <PagerSettings Position="TopAndBottom" />
                <EmptyDataRowStyle CssClass="EmptyRow" />
            </asp:GridView>
                      <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
                        Other1="Ucpager2" PNow="1" PSize="10" Visible="true" />
        </div>
    </div>

</asp:Content>

