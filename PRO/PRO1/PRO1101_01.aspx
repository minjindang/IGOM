<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PRO1101_01.aspx.cs" Inherits="PRO_PRO1_PRO1101_01" %>

<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc1" TagName="UcDDLMember" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">財產移轉申請
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>原保管單位
            </td>
            <td colspan="3"> 
                <asp:CheckBoxList ID="cblStoreRoom" runat="server" RepeatColumns="10" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>新保管單位/保管人
            </td>
            <td colspan="3">
                <uc1:UcDDLDepart runat="server" ID="ucDept" OnSelectedIndexChanged="ucDept_SelectedIndexChanged" />
                <uc1:UcDDLMember runat="server" ID="ucMember" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">新放置地點
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtNewLocation" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">查詢筆數
            </td>
            <td colspan="3">
                <asp:TextBox ID="tbCount" runat="server" Text="10"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div align="center">
        <asp:Button ID="QryBtn" runat="server" Text="查詢" OnClick="QryBtn_Click" />
        <asp:Button ID="DoneBtn" runat="server" Text="確認" OnClick="DoneBtn_Click" />
        <asp:Button ID="ClrBtn" runat="server" Text="清空重填" OnClick="ClrBtn_Click" />
    </div>

    <table width="100%">
        <tr>
            <td>
                <asp:GridView ID="GridViewA" runat="server" PageSize="25"  CssClass="Grid"
                    AutoGenerateColumns="false" OnPageIndexChanging="GridViewA_PageIndexChanging"
                    AllowPaging="true" PagerSettings-Visible="true"
                    CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無可轉移資料!">
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <HeaderStyle CssClass="item_col0" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:CheckBox ID="cbox" runat="server" Text="" />
                                <asp:HiddenField ID="hfFA01_MASTNO" Value='<%# Eval("FA01_MASTNO") %>' runat="server" />
                                <asp:HiddenField ID="hfFA01_CLSNO" Value='<%# Eval("FA01_CLSNO") %>' runat="server" />
                                <asp:HiddenField ID="hfFA01_NAME" Value='<%# Eval("FA01_NAME") %>' runat="server" />
                                <asp:HiddenField ID="hfFA01_STOREROOM" Value='<%# Eval("FA01_STOREROOM") %>' runat="server" />
                                <asp:HiddenField ID="hfFA01_ACCUSER" Value='<%# Eval("FA01_ACCUSER") %>' runat="server" />
                                <asp:HiddenField ID="hfFA01_LOCATION" Value='<%# Eval("FA01_LOCATION") %>' runat="server" />
                                <asp:HiddenField ID="hfFA01_BUYDT" Value='<%# Eval("FA01_BUYDT") %>' runat="server" />
                                <asp:HiddenField ID="hfFA01_KIND" Value='<%# Eval("FA01_KIND") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FA01_MASTNO" HeaderText="財產總號" />
                        <asp:BoundField DataField="FA01_CLSNO" HeaderText="分類編號" />
                        <asp:BoundField DataField="FA01_NAME" HeaderText="財產名稱" />
                        <asp:BoundField DataField="FA01_KIND" HeaderText="財產別" />
                        <asp:BoundField DataField="FA01_LOCATION" HeaderText="放置地點" />
                    </Columns>
                    <RowStyle CssClass="Row" />
                    <HeaderStyle CssClass="Grid" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                </asp:GridView>
            </td>
        </tr>
    </table>
        
        <div id="div1" runat="server" visible="false">
        <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
            PNow="1" PSize="25" Visible="true" />
    </div>

</asp:Content>

