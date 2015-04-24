<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    EnableEventValidation="false"
    CodeFile="MAT4102_01.aspx.vb" Inherits="MAT4102_01" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">分類號維護</td>
            </tr>
            <tr>
                <td class="htmltable_Left">分類編號</td>
                <td style="width: 326px">
                    <asp:TextBox ID="MaterialClass_idTb" runat="server" Width="100px" MaxLength="5"></asp:TextBox>
                </td>
                <td class="htmltable_Left">物料分類名稱</td>
                <td style="width: 326px">
                    <asp:TextBox ID="MaterialClass_nameTb" runat="server" Width="150px" MaxLength="60"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="InsertBtn" runat="server" Text="新增" OnClick="InsertBtn_Click" />
                    <asp:Button ID="SelectBtn" runat="server" Text="查詢" OnClick="SelectBtn_Click" />
                    <asp:Button ID="ResetBtn" runat="server" Text="清空重填" OnClick="ResetBtn_Click" />
                    <asp:Button ID="Status" runat="server" Text="" Visible="false" />
                </td>
            </tr>
        </table>
        <div id="div1" runat="server" visible="false">
            <asp:GridView ID="GridViewA" runat="server"
                AutoGenerateColumns="False"
                AllowPaging="True" PagerSettings-Visible="false"
                CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!">
                <PagerSettings Visible="False" />
                <Columns>
                    <asp:TemplateField HeaderText="分類編號">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Label ID="Label_tabname1" runat="server" Text='<%# Eval("MaterialClass_id")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="物料分類名稱">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Label ID="Label_tabid" runat="server" Text='<%# Eval("MaterialClass_name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="更新日期">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Label ID="Label_tabid1" runat="server" Text='<%# FSCPLM.Logic.DateTimeInfo.ConvertToDisplay(FSCPLM.Logic.DateTimeInfo.GetRocDate(Eval("Mod_date")))%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="更新人員">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Label ID="Label_tabid2" runat="server" Text='<%# Eval("ModUser_Name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="維護">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Button ID="MaintainButton" runat="server" Text="維護" CommandName="editor" CommandArgument='<%#Eval("MaterialClass_id")%>' />
                            <asp:Button ID="DeleteButton" runat="server" Text="刪除" CommandName="remove" CommandArgument='<%#Eval("MaterialClass_id")%>' OnClientClick="return confirm('確認要刪除嗎？');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
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
