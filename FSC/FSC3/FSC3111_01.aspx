<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC3111_01.aspx.vb" Inherits="FSC3111_01" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register src="~/UControl/UcShowTime.ascx" tagname="UcShowTime" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
                班別資料維護
            </td>
        </tr>
       
        <tr>
            <td class="htmltable_Title2">
                查詢結果</td>
        </tr>
        <tr>
            <td class="TdHeightLight">
                <asp:Button ID="cbAdd" runat="server" Text="新增" />
             </td>   
        </tr>
        <tr>
            <td align="right" class="TdHeightLight">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False"
                     Borderwidth="0px" CssClass="Grid" PagerStyle-HorizontalAlign="Right"
                    width="100%" EmptyDataText="查無資料">
                    <Columns>
                        <asp:TemplateField HeaderText="班別代碼">
                            <ItemTemplate>
                                <asp:Label ID="lbid" runat="server" Text='<%# Bind("id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbScheduleId" runat="server" Text='<%# Bind("Schedule_id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="班別名稱">
                            <ItemTemplate>
                                <asp:Label ID="lbName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="上班時間">
                            <ItemTemplate>
                                <uc3:UcShowTime ID="UcShowTime1" runat="server" Text='<%# Bind("Start_time") %>'/>
                                ~<uc3:UcShowTime ID="UcShowTime2" runat="server" Text='<%# Bind("End_time") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="午休時間">
                            <ItemTemplate>
                                <uc3:UcShowTime ID="UcShowTime3" runat="server"  Text='<%# Bind("Noon_stime") %>'/>
                                ~<uc3:UcShowTime ID="UcShowTime4" runat="server" Text='<%# Bind("Noon_etime") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="中午刷卡時間">
                            <ItemTemplate>
                                <uc3:UcShowTime ID="UcShowTime5" runat="server" Text='<%# Bind("Nooncard_stime") %>'/>
                                ~<uc3:UcShowTime ID="UcShowTime6" runat="server" Text='<%# Bind("Nooncard_etime") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>                 
                        <asp:TemplateField HeaderText="維護">
                            <ItemTemplate>
                                <asp:Button ID="cbUpdate" runat="server" Text="修改" onclick="cbUpdate_Click" />
                                <asp:Button ID="cbDelete" runat="server" Text="刪除" onclick="cbDelete_Click" OnClientClick="javascript:if(!confirm('是否確定要刪除？')) return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        查無資料!!
                    </EmptyDataTemplate>
                    <PagerStyle HorizontalAlign="Right" />                    
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle  CssClass="EmptyRow" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    
    
</asp:Content>
