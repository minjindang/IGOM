<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL2114_01.aspx.cs" Inherits="SAL_SAL2_SAL2114" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <table class="tableStyle99" width="100%">
                <tr>
                    <td class="htmltable_Title" colspan="4">所得額統計表
                    </td>
                </tr>
                <tr>
                     <td class="htmltable_Left">請輸入發放年月</td>
                     <td class="htmltable_Right">民國
                     <asp:DropDownList ID="DropDownList_Year" runat="server" AutoPostBack="True">
                         </asp:DropDownList>年
                         <asp:DropDownList ID="DropDownList_Month" runat="server" AutoPostBack="True">
                             <asp:ListItem></asp:ListItem>
                             <asp:ListItem Value="01">01</asp:ListItem>
                             <asp:ListItem Value="02">02</asp:ListItem>
                             <asp:ListItem Value="03">03</asp:ListItem>
                             <asp:ListItem Value="04">04</asp:ListItem>
                             <asp:ListItem Value="05">05</asp:ListItem>
                             <asp:ListItem Value="06">06</asp:ListItem>
                             <asp:ListItem Value="07">07</asp:ListItem>
                             <asp:ListItem Value="08">08</asp:ListItem>
                             <asp:ListItem Value="09">09</asp:ListItem>
                             <asp:ListItem Value="10">10</asp:ListItem>
                             <asp:ListItem Value="11">11</asp:ListItem>
                             <asp:ListItem Value="12">12</asp:ListItem>
                         </asp:DropDownList>月
                     </td>
                    <td class="htmltable_Left">排序</td>
                    <td class="htmltable_Right">
                        <asp:DropDownList ID="ddlsort" runat="server">
                            <asp:ListItem Text="依所得年月排序" Value="依所得年月排序"></asp:ListItem>                          
                            <asp:ListItem Text="依所得項目排序" Value="依所得項目排序"></asp:ListItem>
                            <asp:ListItem Text="依所得金額排序" Value="依所得金額排序"></asp:ListItem>
                            <asp:ListItem Text="依所得件數排序" Value="依所得件數排序"></asp:ListItem>
                        </asp:DropDownList>
                    </td> 
                </tr>
                <tr>
                    <td colspan="4">本頁統計資料均是依據目前資料庫之資料即時統計而成</td>                   
                </tr>
                <tr>
                    <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                        <asp:Button ID="Button_report" runat="server" Text="列印統計報表" 
                            onclick="Button_report_Click" />
                    </td>
                </tr>               
            </table>
</asp:Content>

