<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3118_01.aspx.vb" Inherits="SYS3118_01"  %>

<%@ Register Src="~/UControl/UcShowDate.ascx" TagPrefix="uc1" TagName="UcShowDate" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/UcDDLDepart02.ascx" TagPrefix="uc1" TagName="UcDDLDepart02" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                紙本表單維護</td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                單位
            </td>
            <td class="htmltable_Right">
                <uc1:UcDDLDepart02 runat="server" ID="UcDDLDepart" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <asp:Button ID="cbQuery" runat="server" Text="查詢" />
                <input id="cbReset" type="button" value="重填" />
               <asp:Button ID="cbAdd" runat="server" Text="新增" /></td>
        </tr>
    </table>
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
                        <asp:TemplateField HeaderText="項次" ItemStyle-Width="50">
                            <ItemTemplate>
                                <asp:Label id="gvlbNo" runat="server" Text='<%# (Container.DataItemIndex+1).tostring() %>'></asp:Label>
                                <asp:HiddenField ID="gvhfPath" runat="server" Value='<%# Eval("Path")%>' />
                                <asp:HiddenField ID="gvhfRealName" runat="server" Value='<%# Eval("Real_name")%>' />
                                <asp:HiddenField ID="gvhfFileName" runat="server" Value='<%# Eval("File_name")%>' />
                                <asp:HiddenField ID="gvhfId" runat="server" Value='<%# Eval("id")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="表單名稱">
                            <ItemTemplate>                                
                                <asp:Label ID="gvlbFileName" runat="server" Text='<%# Eval("File_name")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="上架時間">
                            <ItemTemplate>
                                <uc1:UcShowDate runat="server" ID="UcShowDate1" Text='<%# Eval("Start_date")%>' />
                                <uc1:UcDate runat="server" ID="gvUcDate1" Visible="false" Text='<%# Eval("Start_date")%>' />
                                ~
                                <uc1:UcShowDate runat="server" ID="UcShowDate2" Text='<%# Eval("End_date")%>' />
                                <uc1:UcDate runat="server" ID="gvUcDate2" Visible="false" Text='<%# Eval("End_date")%>' />                   
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="下架註記">
                            <ItemTemplate>
                                <asp:Label ID="gvlbremoved_flag" runat="server" Text='<%# IIf(Eval("removed_flag") = "Y", "已下架", "否")%>' />
                                <asp:RadioButtonList ID="gvrblFlag" runat="server" Visible="false" >
                                    <asp:ListItem Value="Y">是</asp:ListItem>
                                    <asp:ListItem Value="N" Selected="True" >否</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="130px">
                            <ItemTemplate>
                                <asp:Button ID="gvcbDelete" runat="server" OnClientClick="javascript:if(!confirm('是否確定刪除檔案?')) return false;" OnClick="gvcbDelete_Click" Text="刪除" />
                                <asp:Button ID="gvcbUpdate" runat="server" OnClick="gvcbUpdate_Click" Text="更新" Visible="false" />
                                <asp:Button ID="gvcbConfirm" runat="server" OnClick="gvcbConfirm_Click" Text="確定" Visible="false" />
                                <asp:Button ID="gvcbCancel" runat="server" OnClick="gvcbCancel_Click" Text="取消" Visible="false" />
                                <asp:Button ID="gvcbExample" runat="server" OnClick="gvcbExample_Click" Text="下載範例檔" />
                                <asp:Button ID="gvcbModify" runat="server" Text="維護" OnClick="gvcbModify_Click" />
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

