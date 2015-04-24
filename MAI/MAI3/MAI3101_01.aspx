<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="MAI3101_01.aspx.cs" Inherits="MAI3101_01" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/UcShowDate.ascx" TagPrefix="uc1" TagName="UcShowDate" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLAuthorityDepart" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc1" TagName="UcDDLAuthorityMember" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">報修紀錄查詢
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">申請類別
                <asp:CheckBox ID="cbKindAll" runat="server" AutoPostBack="true" OnCheckedChanged="cbKindAll_CheckedChanged" />
            </td>
            <td colspan="3">
                <asp:CheckBoxList ID="cblKind" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" 
                    DataTextField="code_desc1" DataValueField="code_no"></asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">報修日期
            </td>
            <td class="htmltable_Right" colspan="3">
                <uc1:UcDate runat="server" ID="UcDateS" />
                ~
                <uc1:UcDate runat="server" ID="UcDateE" />
            </td>
        </tr>
        <tr id="tr3" runat="server">            
            <td class="htmltable_Left">報修人分機
            </td>
            <td class="htmltable_Right" colspan="3">
                <asp:TextBox ID="tbExt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">報修人單位
            </td>
            <td class="htmltable_Right" style="width:400px">
                <uc1:UcDDLAuthorityDepart runat="server" ID="UcDDLAuthorityDepart" OnSelectedIndexChanged="UcDDLAuthorityDepart_SelectedIndexChanged" />
            </td>
            <td class="htmltable_Left">報修人姓名
            </td>
            <td class="htmltable_Right">
                <uc1:UcDDLAuthorityMember runat="server" ID="UcDDLAuthorityMember" />
            </td>
        </tr>
        
        <tr>
            <td class="htmltable_Left">匯出的欄位
                <asp:CheckBox ID="cbColAll" runat="server" AutoPostBack="true" OnCheckedChanged="cbColAll_CheckedChanged" />
            </td>
            <td colspan="3">
                <asp:CheckBoxList ID="cblColumn" runat="server" RepeatColumns="6" RepeatDirection="Horizontal">
                    <asp:ListItem Text="表單編號" Value="Flow_id"></asp:ListItem>
                    <asp:ListItem Text="申請人姓名" Value="Apply_name"></asp:ListItem>
                    <asp:ListItem Text="填寫人姓名" Value="Writer_name"></asp:ListItem>
                    <asp:ListItem Text="申請類別" Value="Maintain_kind"></asp:ListItem>
                    <asp:ListItem Text="申請項目" Value="Maintain_type"></asp:ListItem>
                    <asp:ListItem Text="問題描述" Value="Problem_desc"></asp:ListItem>
                    <asp:ListItem Text="原表單編號" Value="Old_flowid"></asp:ListItem>
                    <asp:ListItem Text="申請人分機" Value="Apply_ext"></asp:ListItem>
                    <asp:ListItem Text="填寫人分機" Value="Problem_analyze"></asp:ListItem>
                    <asp:ListItem Text="問題確認人員" Value="Confirm_name"></asp:ListItem>
                    <asp:ListItem Text="問題確認人員分機" Value="Confirm_ext"></asp:ListItem>
                    <asp:ListItem Text="問題分析" Value="Problem_analyze"></asp:ListItem>
                    <asp:ListItem Text="預定完成日" Value="Predict_date"></asp:ListItem>
                    <asp:ListItem Text="處理人員" Value="Handle_name"></asp:ListItem>
                    <asp:ListItem Text="作業類別" Value="Operate_type"></asp:ListItem>
                    <asp:ListItem Text="處理狀態" Value="Handle_type"></asp:ListItem>
                    <asp:ListItem Text="處理回覆" Value="Handle_desc"></asp:ListItem>
                    <asp:ListItem Text="開始處理日" Value="Handle_sdate"></asp:ListItem>
                    <asp:ListItem Text="處理時數" Value="Handle_hours"></asp:ListItem>
                    <asp:ListItem Text="處理人員分機" Value="Handle_hours"></asp:ListItem>                    
                    <asp:ListItem Text="處理型態" Value="Handle_type"></asp:ListItem>
                    <asp:ListItem Text="完成處理日" Value="Handle_edate"></asp:ListItem>
                    <asp:ListItem Text="回覆日期" Value="Reply_date"></asp:ListItem>
                    <asp:ListItem Text="維運登錄" Value="Maintain_code"></asp:ListItem>
                    <asp:ListItem Text="批核結果" Value="Case_status"></asp:ListItem>
                    <asp:ListItem Text="批核說明" Value="Comment"></asp:ListItem>
                    <asp:ListItem Text="批核記錄" Value="Record"></asp:ListItem>                    
                </asp:CheckBoxList>
            </td>
        </tr>
    </table>
    <div style="text-align:center">
        <asp:Button ID="btnQuery" runat="server" Text="查詢" UseSubmitBehavior="false" OnClick="btnQuery_Click" />
        <input id="Reset" type="button" value="重填" />
        <asp:Button ID="btnExport" runat="server" Enabled="false" Text="匯出" OnClick="btnExport_Click" />
    </div>

    
    <table id="tbq" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
        visible="false" class="tableStyle99">
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="false" BorderWidth="0px" PageSize="30"
                    AllowPaging="true" CssClass="Grid" Width="100%" OnPageIndexChanging="gvlist_PageIndexChanging"
                    EmptyDataText="查無資料!!">
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemStyle HorizontalAlign="Center" Width="15px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
                            <ItemTemplate>
                                <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (Container.DataItemIndex+1).ToString() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="表單編號">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtFlow_id" runat="server" Text='<%# Eval("Flow_id")%>' OnClick="lbtFlow_id_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="報修人姓名">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <Itemtemplate>
                                <asp:Label ID="lbApply_name" runat="server" Text='<%# Eval("Apply_name")%>'></asp:Label>
                            </Itemtemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="報修人分機">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <Itemtemplate>
                                <asp:Label ID="lbApply_ext" runat="server" Text='<%# Eval("Apply_ext")%>'></asp:Label>
                            </Itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="報修人單位">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <Itemtemplate>
                                <asp:Label ID="lbDepart_Name" runat="server" Text='<%# Eval("Depart_Name")%>'></asp:Label>
                            </Itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="報修類別">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <Itemtemplate>
                                <asp:Label ID="lbMaintain_kind_name" runat="server" Text='<%# Eval("Maintain_kind")%>'></asp:Label>
                            </Itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="報修項目">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <Itemtemplate>
                                <asp:Label ID="lbMaintain_type_name" runat="server" Text='<%# Eval("Maintain_type")%>'></asp:Label>
                            </Itemtemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="申請日期">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <Itemtemplate>
                                <uc1:UcShowDate runat="server" ID="UcShowDate" Text='<%# Eval("Apply_date")%>' />
                            </Itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="處理情形">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <Itemtemplate>
                                <asp:Label ID="lbChCase_status" runat="server" Text='<%# Eval("Case_status")%>'></asp:Label>
                            </Itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="完成處理日">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <Itemtemplate>
                                <asp:Label ID="lbHandle_edate" runat="server" Text='<%# Eval("Handle_edate")%>'></asp:Label>
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
    </table>
</asp:Content>

