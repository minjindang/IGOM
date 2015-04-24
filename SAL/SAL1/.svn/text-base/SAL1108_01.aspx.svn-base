<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL1108_01.aspx.cs" Inherits="SAL_SAL1_SAL1108_01" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UControl/UcROCYearMonth.ascx" TagName="UcROCYearMonth" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<style type="text/css">
    .modalBackground
{
    background-color:Gray;
    filter:alpha(opacity=50);
    opacity:0.5;
}
</style>

    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">環保志工服務費申請</td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">申請年月</td>
                <td colspan="3">
                    <uc2:UcROCYearMonth ID="UcDate1" runat="server" />
                </td> 
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;" > 
                    <asp:Button ID="btn_submit" runat="server" Text="送出申請" OnClick="btn_submit_Click" />
                    <asp:Button ID="btn_Confirm" runat="server" Text="確認" visible="false" OnClick="btn_submit_Click" />
                    <asp:Button ID="btnMergePrint" runat="server" Text="印領清冊" Enabled="false" OnClick="btnMergePrint_Click" />                    
                    <asp:Button ID="btnSelect" runat="server" Text="挑選志工" />
                    <asp:Button ID="btnBack" runat="server" Text="回上頁" OnClick="btnBack_Click" Visible="false" />
                </td>
            </tr>

        </table>
    </div>
   <div id="div1" runat="server"> 
        <asp:GridView ID="GridViewA" runat="server"
            AutoGenerateColumns="False" 
            AllowPaging="False" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
            <PagerSettings Visible="False" />
            <Columns> 
                <asp:BoundField DataField="BASE_SEQNO" HeaderText="人員編號" />
                <asp:BoundField DataField="BASE_NAME" HeaderText="姓名" />
                <asp:TemplateField HeaderText="申請金額">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:HiddenField ID="hfMainId" runat="server" Value='<%# Eval("main_id") %>'  />
                        <asp:HiddenField ID="hfId" runat="server" Value='<%# Eval("id") %>' />
                        <asp:TextBox ID="txtApply_amt" Style="text-align: right" runat="server"  MaxLength="6" Text='<%# Eval("Apply_amt") %>'></asp:TextBox>
                    <%--    <asp:HiddenField ID="hfNon_id" runat="server" Value='<%# Eval("Id_card") %>'  />--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="cbDelete" runat="server" OnClick="cbDelete_Click" Text="刪除" />
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

    
<asp:ModalPopupExtender ID="btnQuery_ModalPopupExtender" runat="server" TargetControlID="btnSelect"
    PopupControlID="Panel1"
    BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>
    
<asp:Panel runat="server" ID="Panel1">
    <div>
        <table id="table1" class="tableStyle99" border="1" cellpadding="0" cellspacing ="0" width="100%">
            <tr>
                <td colspan = "2" class="htmltable_Title2" style ="text-align:center">
                   挑選環保志工
                </td>        
            </tr>
            <tr>
                <td class="htmltable_Left">
                    身分證
                </td>
                <td >
                    <asp:TextBox ID="tbIDNO" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    姓名
                </td>
                <td >
                    <asp:TextBox ID="tbName" runat="server"></asp:TextBox>                    
                </td>
            </tr>
            <tr>
                <td colspan='2' class="htmltable_Bottom">
                    <asp:Button ID="cbConfirm" runat="server" Text="查詢" OnClick="cbConfirm_Click"/>
                    <asp:Button ID="cbCancel" runat="server" Text="取消" OnClick="cbCancel_Click"/>
                </td>
            </tr>
        </table>   
        <table id="table2" class="tableStyle99" border="1" cellpadding="0" cellspacing ="0" width="100%">
            <tr>
                <td>                    
                    <asp:GridView ID="gv" runat="server"
                        AutoGenerateColumns="False" CssClass="Grid"
                        AllowPaging="true" 
                        CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" OnPageIndexChanging="gv_PageIndexChanging">
                        <PagerSettings Visible="true" />
                        <Columns> 
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="gvCbx" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="BASE_SEQNO" HeaderText="人員編號" />
                            <asp:BoundField DataField="BASE_NAME" HeaderText="姓名" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="cbPick" runat="server" Text="帶入" OnClick="cbPick_Click"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
</asp:Content>

