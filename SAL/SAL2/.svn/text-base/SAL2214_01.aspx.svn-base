<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" 
CodeFile="SAL2214_01.aspx.vb" Inherits="SAL_SAL2_SAL2214_01" %>
<%@ Register Src="~/UControl/UcROCYear.ascx" TagName="UcROCYear" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table class="tableStyle99" width="100%">
    <tr>
        <td class="htmltable_Title">所得扣繳憑單</td>
    </tr>
    <tr>
        <td class="htmltable_Left"><uc1:UcROCYear id="UcROCYear" runat="server" /></td>
    </tr>
    <tr>
        <td class="htmltable_Bottom" align="center">
            <asp:Button ID="Button_search" runat="server" Text="  查  詢  "/>
        </td>
    </tr>                        
<tr>
    <td style="width: 100%" class="TdHeightLight" valign="top">
    <div runat="server">
        <asp:GridView ID="gvList" runat="server" 
        AutoGenerateColumns="False" AllowPaging="false" PagerSettings-Visible="false"
        CellPadding="1" CellSpacing="1" BorderWidth="0px" EmptyDataText="查無資料!!" >
            <EmptyDataTemplate>
                目前無任何資料!!
            </EmptyDataTemplate>
            <Columns>
                <asp:TemplateField>
                    <HeaderStyle CssClass="item_col" />
                    <ItemStyle CssClass="col_1" HorizontalAlign="Center" Width="10%" />
                    <ItemTemplate>
                        <asp:CheckBox ID="chk" runat="server" />
                        <asp:TextBox ID="TextBox_form" runat="server" Text='<%# Eval("Engf_Form") %>' Visible="false" ></asp:TextBox>
                        <asp:TextBox ID="TextBox_seqno" runat="server" Text='<%# Eval("Engf_Seqno") %>' Visible="false" ></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="姓名">
                    <HeaderStyle CssClass="item_col" />
                    <ItemStyle CssClass="col_1" HorizontalAlign="Center" Width="45%" />
                    <ItemTemplate>
                        <asp:Label ID="Label_name" runat="server" Text='<%# Eval("Base_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="身分證字號">
                    <HeaderStyle CssClass="item_col" />
                    <ItemStyle CssClass="col_1" HorizontalAlign="Center" Width="45%" />
                    <ItemTemplate>
                        <asp:Label ID="Label_idno" runat="server" Text='<%# Eval("Engf_Idno") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" /> 
        </asp:GridView>
    </div>
    <td></td>
</tr>
</table>
</asp:Content>

