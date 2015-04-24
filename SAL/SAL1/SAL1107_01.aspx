<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL1107_01.aspx.cs" Inherits="SAL_SAL1_SAL1107_01" %>

<%@ Register Src="~/UControl/UcROCYearMonth.ascx" TagName="UcROCYearMonth" TagPrefix="uc15" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">替代役交通費申請</td>
        </tr>
        <tr>
            <td class="htmltable_Left">申請年月</td>
            <td style="width: 326px" runat="server">
                <uc15:UcROCYearMonth ID="ucApply_ym" runat="server" />
            </td>
            <td class="htmltable_Left">每年申請金額</td>
            <td runat="server">
                <asp:TextBox ID="txtAllApply_amt" runat="server" Text="" MaxLength="6"></asp:TextBox>
                <asp:Button ID="InsertAllAmtBtn" runat="server" Text="確認" OnClick="InsertAllAmtBtn_Click" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%"> 
                <asp:Button ID="SubmitBtn" runat="server" Text="送出申請" OnClick="SubmitBtn_Click" /> 
                <asp:Button ID="btnMergePrint" runat="server" Text="印領清冊" Enabled="false" OnClick="btnMergePrint_Click" />
        <input id="btnGoBack" type="button" value="回上頁" onclick="javascript: window.history.back();" class="nonPrinted" />  
            </td>
        </tr>
    </table>
    <div>
        <asp:GridView ID="GridViewA" runat="server"
            AutoGenerateColumns="False" OnRowDeleting="GridViewA_RowDeleting"
            AllowPaging="True" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
            <PagerSettings Visible="False" />
            <Columns> 
                <asp:BoundField DataField="User_name" HeaderText="姓名" />
                <asp:BoundField DataField="Depart_name" HeaderText="單位名稱" />
                <asp:BoundField DataField="Employee_type" HeaderText="人員類別" />  
                 <asp:TemplateField HeaderText="申請金額">
                    <HeaderStyle  HorizontalAlign="Center" />
                    <ItemStyle />
                    <ItemTemplate>
                        <asp:TextBox ID="txtApply_amt" runat="server" maxlength="6" ></asp:TextBox>
                        <asp:HiddenField ID="hfNon_id" runat="server" Value='<%# Eval("Id_card") %>'  />
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="維護" Visible="false" >
                    <HeaderStyle  HorizontalAlign="Center" />
                    <ItemStyle />
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" CommandName="GoDelete" runat="server" Text="刪除" OnClick="btnDelete_Click" OnClientClick="return confirm('是否確定要刪除?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
    </div>

</asp:Content>

