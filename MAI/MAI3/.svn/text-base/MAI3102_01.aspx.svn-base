<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="MAI3102_01.aspx.vb" Inherits="MAI3102_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcShowDate.ascx" TagPrefix="uc1" TagName="UcShowDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                水電報修紀錄查詢
            </td>
        </tr>
        <tr>                    
            <td class="htmltable_Left" style="width:100px; height: 19px;">
                報修項目<asp:CheckBox ID="cbType_All" runat="server" AutoPostBack="true" OnCheckedChanged="cbType_All_CheckedChanged" />
            </td>
            <td class="TdHeightLight" style="width:250px; height: 19px;">
                <asp:CheckBoxList id="cblMaintain_type" runat="server" DataValueField="CODE_NO" DataTextField="CODE_DESC1" RepeatColumns="8" />
            </td>
                        
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                報修日期</td>
                <td class="htmltable_Right">
                    <uc1:UcDate runat="server" ID="UcDateS" />~<uc1:UcDate runat="server" ID="UcDateE" />
                </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                報修人姓名</td>
                <td class="htmltable_Right">
                    <asp:TextBox id="tbApply_name" runat="server" />
                </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                報修人分機</td>
                <td class="htmltable_Right">
                    <asp:TextBox id="tbApply_ext" runat="server" />
                </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                報修人單位</td>
                <td class="htmltable_Right">
                    <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                是否完成<asp:CheckBox ID="cbAll" runat="server" AutoPostBack="true" OnCheckedChanged="cbAll_CheckedChanged" /></td>
                <td class="htmltable_Right">
                    <asp:CheckBox ID="cbDone" runat="server" Text="已完成" />
                    <asp:CheckBox ID="cbUnDone" runat="server" Text="未完成" />
                </td>
        </tr>
        <tr>
            <td align="center" colspan="2" class="TdHeightLight">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" UseSubmitBehavior="false" />
                <input id="Reset" type="button" value="重填" />
                <asp:Button ID="btnExport" runat="server" Enabled="false" Text="匯出" />
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
                    AllowPaging="true" CssClass="Grid" PagerStyle-HorizontalAlign="right" Width="100%"
                    EmptyDataText="查無資料!!">
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemStyle HorizontalAlign="Center" Width="15px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
                            <ItemTemplate>
                                <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (container.dataitemindex+1).tostring() %>'></asp:Label>
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
                                <asp:Label ID="lbMaintain_kind_name" runat="server" Text='<%# Eval("Maintain_kind_name")%>'></asp:Label>
                            </Itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="報修項目">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <Itemtemplate>
                                <asp:Label ID="lbMaintain_type_name" runat="server" Text='<%# Eval("Maintain_type_name")%>'></asp:Label>
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
                                <asp:Label ID="lbChCase_status" runat="server" Text='<%# Eval("ChCase_status")%>'></asp:Label>
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
