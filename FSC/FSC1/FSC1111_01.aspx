<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC1111_01.aspx.vb" Inherits="FSC1111_01"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="dataList" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" visible="true">
        <tr>
            <td class="htmltable_Title" style="width: 100%" align="center">
                線上下載紙本表單
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30"
                    BorderWidth="0px" CssClass="Grid" PagerStyle-HorizontalAlign="Right" Width="100%"
                    EmptyDataText="查無資料!!">
                    <Columns>
                        <asp:TemplateField HeaderText="項次" ItemStyle-Width="50">
                            <ItemTemplate>
                                <asp:Label id="gvlbNo" runat="server" Text='<%# (Container.DataItemIndex+1).tostring() %>'></asp:Label>
                                <asp:HiddenField ID="gvhfPath" runat="server" Value='<%# Eval("Path")%>' />
                                <asp:HiddenField ID="gvhfRealName" runat="server" Value='<%# Eval("Real_name")%>' />
                                <asp:HiddenField ID="gvhfFileName" runat="server" Value='<%# Eval("File_name")%>' />
                                <asp:HiddenField ID="gvhfId" runat="server" Value='<%# Eval("id")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="紙本表單名稱">
                            <ItemTemplate>                                
                                <asp:Label ID="gvlbFileName" runat="server" Text='<%# Eval("File_name")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="功能" ItemStyle-Width="130px">
                            <ItemTemplate>
                                <asp:Button ID="gvcbExample" runat="server" OnClick="gvcbExample_Click" Text="下載" />
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

