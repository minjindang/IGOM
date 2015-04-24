<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    EnableEventValidation="false"
    CodeFile="PAY1101_01.aspx.vb" Inherits="PAY_PAY1_PAY1101_01" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%@ Register Src="~/UControl/UcPager.ascx" TagName="UcPager" TagPrefix="uc1" %>
<%@ Register src="~/UControl/SAL/ucSaCode.ascx" tagname="ucSaCode" tagprefix="uc2" %>
    <%@ Register Src="~/UControl/FSC/UcAttachment.ascx" TagPrefix="uc1" TagName="UcAttachment" %>


    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">請購申請</td>
        </tr>
        <tr>
            <td class="htmltable_Left">申請日期</td>
            <td style="width: 326px" colspan="3">
              <asp:TextBox ID="ApplyDate" runat="server" Text="" Enabled="false" Width="70px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><font size="3" color="red"> *</font >用途摘要</td>
            <td style="width: 326px" colspan="3">
                <asp:TextBox ID="Use_desc" runat="server" Rows="3" TextMode="MultiLine" Width="400" Text=""></asp:TextBox></td>
        </tr>
        <tr>
            <td class="htmltable_Left" >請購類別</td>
            <td colspan="3">
                <uc2:ucSaCode ID="ucSaCode1" runat="server" Code_sys="014" Code_type="002" ControlType="RadioButtonList"/>
            </td>
           </tr> 
        <tr>
            <td class="htmltable_Left">附件</td>
            <td style="width: 326px" colspan="3">
                <%-- <asp:FileUpload ID="FileUpload_txt" runat="server" Width="300" CssClass="AlternatingRow"/>--%>
                <uc1:UcAttachment runat="server" ID="UcAttachment" />
            </td>
        </tr>
    </table>
    <div id="div1" runat="server" visible="false">
            <asp:GridView ID="GridViewA" runat="server"
                AutoGenerateColumns="False"
                AllowPaging="True" PagerSettings-Visible="false"
                CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!" 
                 DataKeyNames="No_id">
                <PagerSettings Visible="False" />
                <Columns>
                    <asp:TemplateField HeaderText="編號">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="No_id" runat="server" Text='<%# Eval("No_id")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="項目名稱">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:textbox ID="Item_name" runat="server" Text='<%# Eval("Item_name")%>'></asp:textbox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="規格">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:textbox ID="Specification_desc" runat="server" Text='<%# Eval("Specification_desc")%>'></asp:textbox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="單位">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:textbox ID="Unit" runat="server" Text='<%# Eval("Unit")%>'></asp:textbox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="數量">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:textbox ID="Apply_cnt" runat="server" Text='<%# Eval("Apply_cnt")%>'></asp:textbox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="維護">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Button ID="InsertButton" runat="server" Text="插入" Visible="False" CommandName="InsertButton" OnClick="InsertButton_Click"/>
                            <asp:Button ID="DeleteButton" runat="server" Text="刪除" CommandName="DeleteButton" CommandArgument="DeleteButton" Visible="True" OnClientClick="return confirm('確認要刪除嗎？');"/>
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
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                    <asp:Button ID="InsertBtn" runat="server" Text="新增一筆資料" Visible="false"/>
                    <asp:Button ID="SubmitBtn" runat="server" Text="送出申請" />
                    <asp:Button ID="PrintBtn" runat="server" Text="列印請購單" OnClick="PrintBtn_Click" />
                    <asp:Button ID="BackBtn" runat="server" Text="回上頁" OnClick="BackBtn_Click" Visible="False" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
