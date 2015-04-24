<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3116_01.aspx.vb" Inherits="SYS3116_01"  %>

<%@ Register Src="~/UControl/SYS/UcDDLForm.ascx" TagPrefix="uc1" TagName="UcDDLForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                表單規則說明</td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                表單
            </td>
            <td class="htmltable_Right">
                <uc1:UcDDLForm runat="server" ID="UcDDLForm" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <asp:Button ID="cbQuery" runat="server" Text="查詢" />
                <input id="cbReset" type="button" value="重填" />
               <asp:Button ID="cbAdd" runat="server" Text="新增" /></td>
        </tr>
    </table>
    <br />
    
    <table id="dataList" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" visible="false">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                查詢結果
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30"
                    BorderWidth="0px" CssClass="Grid" PagerStyle-HorizontalAlign="Right" Width="100%"
                    EmptyDataText="查無資料!!">
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label id="gvlbNo" runat="server" Text='<%# (Container.DataItemIndex+1).tostring() %>'></asp:Label>
                                <asp:HiddenField ID="gvhfFormId" runat="server" Value='<%# Eval("Form_id")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Form_name" HeaderText="表單名稱" ></asp:BoundField>
                        <asp:BoundField DataField="Describe" HeaderText="表單規則說明" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="ifattach_name" HeaderText="補附件上傳" />
                        <asp:TemplateField ItemStyle-Width="130px">
                            <ItemTemplate>
                                <asp:Button ID="gvcbUpdate" runat="server" OnClick="gvcbUpdate_Click" Text="修改" />
                                <asp:Button ID="gvcbDelete" runat="server" OnClientClick="javascript:if(!confirm('是否確定要刪除?')) return false;" OnClick="gvcbDelete_Click" Text="刪除" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <EmptyDataTemplate>
                        查無資料!!
                    </EmptyDataTemplate>
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right" class="TdHeightLight" style="width: 100%">
                <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvList"
                    PNow="1" PSize="30" Visible="true" />
            </td>
        </tr>        
    </table>
</asp:Content>

