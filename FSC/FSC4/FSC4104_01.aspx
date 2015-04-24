<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC4104_01.aspx.vb" Inherits="FSC4104_01"  %>

<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                年度行事曆設定</td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="2">
                查詢條件</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px ">
                年月</td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="DD_Year" runat="server" >
                </asp:DropDownList>年
                <asp:DropDownList ID="DD_Month" runat="server" >
                </asp:DropDownList>月
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" /><input id="Reset2" type="button"
                value="重填" /><asp:Button ID="cbAdd" runat="server" Text="新增" />
                <asp:Button ID="btnPrint" runat="server" Enabled="false" Text="匯出" />
                <asp:Button ID="btnImport" runat="server" Text="匯入"  Visible="false"  />
                <a href="../../report/fsc/FSC4104_01_sample.xls" id="lbtnSample" runat="server" visible="false"  >匯入格式下載</a>
                
            </td>
        </tr>
    </table>
<br />
    <table id="tbQ" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" visible="false">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                查詢結果</td>
        </tr>
        <tr>
            <td style="width: 100%" align="right">
                <asp:Button ID="cbConfirm" runat="server" Text="確認" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False"
                     Borderwidth="0px" CssClass="Grid" PagerStyle-HorizontalAlign="Right"
                    width="100%" EmptyDataText="查無資料">
                    <Columns>
                        <asp:TemplateField HeaderText="日期">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lbDATE" runat="server" Text='<%# Bind("PBDDATE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="星期別">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lbWEEK" runat="server" Text='<%# Bind("PBDWEEK") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="上班區別">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lbTYPE" runat="server" Text='<%# Bind("PBDTYPE") %>' Visible="false"></asp:Label>
                                <asp:DropDownList ID="ddlTYPE" runat="server" SelectedValue='<%# Bind("PBDTYPE") %>'>
                                    <asp:ListItem Text="全日上班" value="0"></asp:ListItem>
                                    <asp:ListItem Text="上班半日" value="1"></asp:ListItem>
                                    <asp:ListItem Text="放假" value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="說明">
                            <ItemTemplate>
                                <asp:Label ID="lbDESC" runat="server" Text='<%# Bind("PBDDESC") %>' Visible="false"></asp:Label>
                                <asp:Textbox ID="tbDESC" runat="server" Text='<%# Bind("PBDDESC") %>' Width="300px"></asp:Textbox>
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
        <tr>
            <td style="width: 100%" align="right">
                <asp:Button ID="cbConfirm2" runat="server" Text="確認" />
            </td>
        </tr>
    </table>
    </asp:Content>
