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
                �Z�O��ƺ��@
            </td>
        </tr>
       
        <tr>
            <td class="htmltable_Title2">
                �d�ߵ��G</td>
        </tr>
        <tr>
            <td class="TdHeightLight">
                <asp:Button ID="cbAdd" runat="server" Text="�s�W" />
             </td>   
        </tr>
        <tr>
            <td align="right" class="TdHeightLight">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False"
                     Borderwidth="0px" CssClass="Grid" PagerStyle-HorizontalAlign="Right"
                    width="100%" EmptyDataText="�d�L���">
                    <Columns>
                        <asp:TemplateField HeaderText="�Z�O�N�X">
                            <ItemTemplate>
                                <asp:Label ID="lbid" runat="server" Text='<%# Bind("id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbScheduleId" runat="server" Text='<%# Bind("Schedule_id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�Z�O�W��">
                            <ItemTemplate>
                                <asp:Label ID="lbName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�W�Z�ɶ�">
                            <ItemTemplate>
                                <uc3:UcShowTime ID="UcShowTime1" runat="server" Text='<%# Bind("Start_time") %>'/>
                                ~<uc3:UcShowTime ID="UcShowTime2" runat="server" Text='<%# Bind("End_time") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�ȥ�ɶ�">
                            <ItemTemplate>
                                <uc3:UcShowTime ID="UcShowTime3" runat="server"  Text='<%# Bind("Noon_stime") %>'/>
                                ~<uc3:UcShowTime ID="UcShowTime4" runat="server" Text='<%# Bind("Noon_etime") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���Ȩ�d�ɶ�">
                            <ItemTemplate>
                                <uc3:UcShowTime ID="UcShowTime5" runat="server" Text='<%# Bind("Nooncard_stime") %>'/>
                                ~<uc3:UcShowTime ID="UcShowTime6" runat="server" Text='<%# Bind("Nooncard_etime") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>                 
                        <asp:TemplateField HeaderText="���@">
                            <ItemTemplate>
                                <asp:Button ID="cbUpdate" runat="server" Text="�ק�" onclick="cbUpdate_Click" />
                                <asp:Button ID="cbDelete" runat="server" Text="�R��" onclick="cbDelete_Click" OnClientClick="javascript:if(!confirm('�O�_�T�w�n�R���H')) return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        �d�L���!!
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
