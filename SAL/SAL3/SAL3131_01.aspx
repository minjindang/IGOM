<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL3131_01.aspx.cs" Inherits="SAL3131_01" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">評審出席費、講師費請資料釐正
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                <span style="color:red" >*</span>申請類別案件編號
            </td>
            <td colspan="3">
                <asp:TextBox ID="tbFlow_id" runat="server" MaxLength="11" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" class="TdHeightLight">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click" />
                <input id="Reset" type="button" value="重填" />
            </td>
        </tr>
    </table>

    
    <table id="tbq" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
        visible="false" class="tableStyle99">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                查詢結果
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="false" BorderWidth="0px" PageSize="30"
                    AllowPaging="true" CssClass="Grid" PagerStyle-HorizontalAlign="right" Width="100%" OnPageIndexChanging="gvlist_PageIndexChanging"
                    EmptyDataText="查無資料!!">
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemStyle HorizontalAlign="Center" Width="15px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
                            <ItemTemplate>
                                <asp:Label ID="lbNUm" runat="server" Text='<%# (Container.DataItemIndex+1).ToString() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemStyle HorizontalAlign="Center" Width="15px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
                            <HeaderTemplate>
                                <asp:CheckBox ID="cbSelectAll" runat="server" AutoPostBack="True" OnCheckedChanged="cbSelectAll_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="cbx" runat="server" />
                                <asp:Label ID="lbid" runat="server" Text='<%# Eval("id") %>' Visible="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="申請-身分證號/護照<br />現行-身分證號/護照">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <Itemtemplate>
                                <asp:Label ID="lbFee_BASE_IDNO" runat="server" Text='<%# Eval("Fee_BASE_IDNO") %>' />
                                <asp:TextBox ID="tbFee_BASE_IDNO" runat="server" Text='<%# Eval("Fee_BASE_IDNO") %>' Visible="false" />
                                <br />
                                <asp:Label ID="lbBASE_IDNO" runat="server" Text='<%# Eval("BASE_IDNO") %>' />
                            </Itemtemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="申請-姓名<br />現行-姓名">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <Itemtemplate>
                                <asp:Label ID="lbFee_BASE_NAME" runat="server" Text='<%# Eval("Fee_BASE_NAME") %>' />
                                <br />
                                <asp:Label ID="lbBASE_NAME" runat="server" Text='<%# Eval("BASE_NAME") %>' />
                            </Itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="申請-服務單位<br />現行-服務單位">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <Itemtemplate>
                                <asp:Label ID="lbFee_BASE_SERVICE_PLACE_DESC" runat="server" Text='<%# Eval("Fee_BASE_SERVICE_PLACE_DESC") %>' />
                                <br />
                                <asp:Label ID="lbBASE_SERVICE_PLACE_DESC" runat="server" Text='<%# Eval("BASE_SERVICE_PLACE_DESC") %>' />
                            </Itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="申請-職稱<br />現行-職稱">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <Itemtemplate>
                                <asp:Label ID="lbFee_BASE_DCODE_NAME" runat="server" Text='<%# Eval("Fee_BASE_DCODE_NAME") %>' />
                                <br />
                                <asp:Label ID="lbBASE_DCODE_NAME" runat="server" Text='<%# Eval("BASE_DCODE_NAME") %>' />
                            </Itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="申請-戶籍地址<br />現行-戶籍地址">
                            <ItemStyle HorizontalAlign="Center" Width="300px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="300px" />
                            <Itemtemplate>
                                <asp:Label ID="lbFee_BASE_ADDR" runat="server" Text='<%# Eval("Fee_BASE_ADDR") %>' />
                                <asp:TextBox ID="tbFee_BASE_ADDR" runat="server" Text='<%# Eval("Fee_BASE_ADDR") %>' Width="260px" Visible="false" />
                                <br />
                                <asp:Label ID="lbBASE_ADDR" runat="server" Text='<%# Eval("BASE_ADDR") %>' />
                            </Itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="申請-銀行資料<br />現行-銀行資料">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <Itemtemplate>
                                <asp:Label ID="lbBASE_BANK_CODE" runat="server" Text='<%# Eval("BASE_BANK_CODE") %>' />-
                                <asp:Label ID="lbBASE_BANK_NO" runat="server" Text='<%# Eval("BASE_BANK_NO") %>' />
                                <br />
                                <asp:Label ID="lbBANK_CODE" runat="server" Text='<%# Eval("BANK_CODE") %>' />-
                                <asp:Label ID="lbBANK_BANK_NO" runat="server" Text='<%# Eval("BANK_BANK_NO") %>' />
                            </Itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="維護">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <Itemtemplate>
                                <asp:Button ID="btnUpdate" runat="server" Text="更新" OnClick="btnUpdate_Click" />
                                <asp:Button ID="btnConfirm" runat="server" Text="確定" Visible="false" OnClick="btnConfirm_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="取消" Visible="false" OnClick="btnCancel_Click" />
                            </Itemtemplate>
                        </asp:TemplateField>
                    </Columns>
                    <pagerstyle horizontalalign="Right" />
                        <emptydatatemplate>
                            查無資料!!
                        </emptydatatemplate>
                    <rowstyle cssclass="Row" />
                    <headerstyle cssclass="Grid" />
                    <alternatingrowstyle cssclass="AlternatingRow" />
                    <pagersettings position="TopAndBottom" />
                    <emptydatarowstyle cssclass="EmptyRow" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right" class="TdHeightLight" style="width: 100%">
                <uc1:Ucpager ID="Ucpager" runat="server" EnableViewState="true" GridName="gvlist"
                    PNow="1" PSize="30" Visible="true" />
            </td>
        </tr>
        <tr>
            <td align="center" class="TdHeightLight" style="width: 100%">
                <asp:Button ID="btnAllUpdate" runat="server" Text="更新現行資料" Visible="false" OnClick="btnAllUpdate_Click" />
            </td>
        </tr>       
    </table>
</asp:Content>

