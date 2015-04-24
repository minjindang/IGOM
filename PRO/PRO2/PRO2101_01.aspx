<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PRO2101_01.aspx.cs" Inherits="PRO_PRO2_PRO2101_01" %>
 
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>
<%@ Register Src="~/UControl/PRO/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLAuthorityDepart" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">財產保管查詢
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">種類
                </td>
                <td colspan="3">
                    <uc1:ucSaCode runat="server" id="ucFA01_KIND" Code_sys="016" Code_type="006" ControlType="DropDownList" DDLDefaultValue="true"  />
                </td> 
            </tr>
            
            <tr>
                <td class="htmltable_Left">總號
                </td>
                <td>
                    <asp:TextBox ID="txtFA01_MASTNO" runat="server"></asp:TextBox> 
                </td>
                <td class="htmltable_Left">分類編號 
                </td>
                <td>
                    <asp:TextBox ID="txtFA01_CLSNO" runat="server"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">保管單位
                </td>
                <td>
                    <uc1:UcDDLAuthorityDepart runat="server" ID="UcDDLAuthorityDepart" />
                </td>
                <td class="htmltable_Left">保管人
                </td>
                <td>
                    <asp:TextBox ID="txtFA01_ACCUSER" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td class="htmltable_Left">購置日期
                </td>
                <td>
                    <uc1:UcDate runat="server" ID="ucFA01_BUYDTS" />
                    ~
                    <uc1:UcDate runat="server" ID="ucFA01_BUYDTE" />
                </td>
                <td class="htmltable_Left">金額
                </td>
                <td>

                    <asp:TextBox ID="txtFA01_AMT" runat="server"></asp:TextBox>元以上 
                </td>
            </tr>

            <tr>
                <td class="htmltable_Left">堪用
                </td> 
                <td>
                    <asp:RadioButtonList ID="rblFA01_SUBDUE" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="是">是</asp:ListItem>
                        <asp:ListItem Value="否">否</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="htmltable_Left">查詢筆數
                </td>
                <td>
                    <asp:TextBox ID="tbCount" runat="server" Text="10"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="htmltable_Left">逾使用年限
                </td> 
                <td colspan="3">
                    <asp:RadioButtonList ID="rblFA01_BUYDT" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="Y">已逾期</asp:ListItem>
                        <asp:ListItem Value="N">未逾期</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <div align="center">
            <asp:Button ID="QryBtn" runat="server" Text="查詢" OnClick="QryBtn_Click" />
            <asp:Button ID="ResetBtn" runat="server" Text="清空重填" OnClick="ResetBtn_Click" />
            <asp:Button ID="ExportBtn" runat="server" Text="產製EXCEL檔" OnClick="ExportBtn_Click" />
        </div>
        <div id="div1" runat="server" visible="false">
            <asp:GridView ID="GridViewA" runat="server"
                AutoGenerateColumns="False" OnPageIndexChanging="GridViewA_PageIndexChanging"
                AllowPaging="True" PagerSettings-Position="Bottom"
                CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" OnRowDataBound="GridViewA_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="Index" HeaderText="項次" />
                    <asp:BoundField DataField="FA01_MASTNO" HeaderText="總號" />
                    <asp:BoundField DataField="FA01_CLSNO" HeaderText="分類編號" /> 
                      <asp:TemplateField HeaderText="品名">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate> 
                            <asp:HiddenField ID="lbFA01_MASTNO" runat="server" Value='<%# Eval("FA01_MASTNO") %>' />
                            <asp:HiddenField ID="lbFA01_CLSNO" runat="server" Value='<%# Eval("FA01_CLSNO") %>' />
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "PRO2101_02.aspx?FA01_MASTNO=" +Eval("FA01_MASTNO") + "&FA01_CLSNO=" + Eval("FA01_CLSNO")  %>'><%# Eval("FA01_NAME")%></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="FA01_BUYDT" HeaderText="購置日" />
                    <asp:BoundField DataField="FA02_RANGE" HeaderText="年限" />
                    <asp:BoundField DataField="FA01_QTY" HeaderText="數量" DataFormatString="{0:0.##}" />
                    <asp:BoundField DataField="FA01_AMT" HeaderText="金額" DataFormatString="{0:0.##}"/>
                    <asp:BoundField DataField="FA01_ACCUSER" HeaderText="保管人" />
                    <asp:BoundField DataField="FA01_USER" HeaderText="使用人" />
                    <asp:BoundField DataField="FA01_STOREROOM" HeaderText="保管單位" />
                    <asp:BoundField DataField="FA01_LOCATION" HeaderText="放置地點" />
                    <asp:BoundField DataField="FA01_DECDT" HeaderText="減損年月" />
                    <asp:BoundField DataField="FA01_UP" HeaderText="異動人" />
                    <asp:BoundField DataField="FA01_UPDATEDT" HeaderText="異動日期" />
                    <asp:BoundField DataField="FA01_CREATDT" HeaderText="建檔日期" />
                    <asp:BoundField DataField="FA01_KIND" HeaderText="備註" />
                </Columns>
                <RowStyle CssClass="Row" />
                <HeaderStyle CssClass="Grid" />
                <AlternatingRowStyle CssClass="AlternatingRow" />
                <PagerSettings Position="TopAndBottom" />
                <EmptyDataRowStyle CssClass="EmptyRow" />
            </asp:GridView>
            <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
                PNow="1" PSize="10" Visible="true" />
        </div>
    </div>
</asp:Content>

