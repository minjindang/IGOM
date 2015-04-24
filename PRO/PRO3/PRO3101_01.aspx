<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PRO3101_01.aspx.cs" Inherits="PRO_PRO3_PRO3101_01" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc1" TagName="UcDDLMember" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">軟體保管查詢及維護</td>
            </tr>
            <tr>
                <td class="htmltable_Left">公文文號</td>
                <td style="width: 326px">
                    <asp:TextBox ID="txtOfficialNumber_id" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td class="htmltable_Left">軟體編號</td>
                <td style="width: 326px">
                    <asp:TextBox ID="txtSoftware_id" runat="server" Width="100px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">核准日期區間</td>
                <td style="width: 326px">
                    <uc1:UcDate runat="server" ID="ucLast_dateS" />
                    ~
                    <uc1:UcDate runat="server" ID="ucLast_dateE" />
                </td>
                <td class="htmltable_Left">來源單位</td>
                <td>
                    <asp:TextBox ID="txtSoftwareUnit_name" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">保管單位</td>
                <td style="width: 326px">
                    <uc1:UcDDLDepart runat="server" ID="ucUnit_code" OnSelectedIndexChanged="ucUnit_code_SelectedIndexChanged" />
                </td>
                <td class="htmltable_Left">保管人</td>
                <td style="width: 326px">
                    <uc1:UcDDLMember runat="server" ID="ucUser_id" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">軟體名稱</td>
                <td colspan="3">
                    <asp:TextBox ID="txtSoftware_name" runat="server" Width="120px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">費用</td>
                <td colspan="3">
                    <asp:RadioButton ID="rbRange" runat="server" AutoPostBack="false" Text="區間" GroupName="price" RepeatLayout="Flow" />
                    <asp:TextBox ID="txtFee_amtS" runat="server" Text="" Width="77px" />
                    ~
                    <asp:TextBox ID="txtFee_amtE" runat="server" Text="" Width="77px" />
                    <asp:RadioButton ID="rbLess" runat="server" AutoPostBack="false" Text="小於" GroupName="price" RepeatLayout="Flow" />
                    <asp:TextBox ID="txtFee_amtL" runat="server" Text="" Width="77px" />
                    <asp:RadioButton ID="rbMore" runat="server" AutoPostBack="false" Text="大於" GroupName="price" RepeatLayout="Flow" />
                    <asp:TextBox ID="txtFee_amtM" runat="server" Text="" Width="77px" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">換頁條件</td>
                <td colspan="3">
                    <asp:RadioButtonList ID="rblOrder" runat="server" AutoPostBack="True" RepeatColumns="7" RepeatLayout="Flow">
                        <asp:ListItem Value="Unit_code" Selected="True">依保管單位</asp:ListItem>
                        <asp:ListItem Value="User_id">依保管人</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>

        </table>
        <div align="center">
            <asp:Button ID="btnQry" runat="server" Text="查詢" OnClick="btnQry_Click" />
            <asp:Button ID="btnClr" runat="server" Text="清空重填" OnClick="btnClr_Click" />
            <asp:Button ID="btnPrint" runat="server" Text="列印盤點清冊" OnClick="btnPrint_Click" />
        </div>
        <div id="div1" runat="server" visible="false">
            <asp:GridView ID="GridViewA" runat="server"
                AutoGenerateColumns="False" OnPageIndexChanging="GridViewA_PageIndexChanging"
                AllowPaging="True" PagerSettings-Visible="false" OnRowCommand="GridViewA_RowCommand"
                CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!!">
                <PagerSettings Visible="false" />
                <Columns>
                    <asp:BoundField DataField="Index" HeaderText="序號" />
                    <asp:BoundField DataField="OfficialNumber_id" HeaderText="公文文號" />
                    <asp:BoundField DataField="Software_id" HeaderText="軟體編號" />
                    <asp:BoundField DataField="Software_name" HeaderText="軟體名稱" />
                    <asp:BoundField DataField="Software_type" HeaderText="軟體別" />
                    <asp:BoundField DataField="SoftwareKind_type" HeaderText="使用版別" />
                    <asp:BoundField DataField="Sofeware_cnt" HeaderText="數量" />
                    <asp:BoundField DataField="Fee_amt" HeaderText="費用" />
                    <asp:BoundField DataField="departname" HeaderText="保管單位" />
                    <asp:BoundField DataField="username" HeaderText="保管人" />
                    <asp:BoundField DataField="Register_date" HeaderText="登記日期" />
                    <asp:TemplateField HeaderText="維護">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>  
                            <asp:Button ID="btn1" runat="server" Text="維護" CommandName="Maintain" CommandArgument='<%# Eval("Flow_id")%>' />
                            <asp:Button ID="btn2" CommandName="GoDelete" CommandArgument='<%# Eval("Flow_id")%>'
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
                PNow="1" PSize="10" Visible="true" />
        </div>
    </div>
</asp:Content>

