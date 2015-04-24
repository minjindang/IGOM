<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT1102_02.aspx.vb" Inherits="MAT_MAT1_MAT1102_02" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">單位領物申請
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">領用類別
            </td>
            <td colspan="3">單位領用
            </td>
        </tr> 
        <tr>
            <td class="htmltable_Left">領物單編號
            </td>
            <td style="width: 326px">
               <asp:TextBox ID="txtFlowId" runat="server" Enabled="false" ></asp:TextBox>
            </td>
            <td class="htmltable_Left">填單人員
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtModUserId" runat="server" Enabled="false" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">申請日期
            </td>
            <td style="width: 326px">
                 <asp:TextBox ID="txtApplyDate" runat="server" Enabled="false" ></asp:TextBox>
            </td>
            <td class="htmltable_Left">領物人員
            </td>
            <td style="width: 326px">
                <asp:DropDownList ID="ddlUserId" runat="server"></asp:DropDownList>
            </td>
        </tr>
    </table>
    <div id="div1" runat="server" align="center">
        <asp:GridView ID="GridViewA" runat="server" AutoGenerateColumns="False"
            PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px"
            Width="100%" EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="Index" HeaderText="序號" />
                <asp:BoundField DataField="Material_name" HeaderText="物料名稱" /> 
                <asp:TemplateField HeaderText="申請數量">
                    <ItemTemplate>
                        <asp:TextBox ID="txtApplyCnt" runat="server" Text='<%# Bind("Apply_cnt") %>'></asp:TextBox>
                        <asp:HiddenField ID="hfMaterial_id" runat="server" Value='<%# Bind("Material_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Unit" HeaderText="單位" />   
                <asp:TemplateField HeaderText="用途及備註">
                    <ItemTemplate>
                        <asp:TextBox ID="txtMemo" runat="server" Text='<%# Bind("Memo") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="維護">
                    <ItemTemplate> 
                        <asp:Button ID="btnDelete"
                            runat="server" Text="刪除" OnClick="btnDelete_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
        <asp:Button ID="ResetBtn" runat="server" Text="重填物料" PostBackUrl="~/MAT/MAT1/MAT1102_01.aspx" />
        <asp:Button ID="DonBtn" runat="server" Text="送出申請" />
        <asp:Button ID="BackBtn" runat="server" Text="回上頁" Visible="false" />
    </div>
</asp:Content>

