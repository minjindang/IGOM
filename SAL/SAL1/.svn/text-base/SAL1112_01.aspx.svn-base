<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SAL1112_01.aspx.vb" Inherits="SAL1112_01"  %>

<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLAuthorityDepart" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc1" TagName="UcDDLAuthorityMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td align="left" class="htmltable_Title" colspan="4">
                加班費請領</td>
        </tr>
        <tr>
            <td align="left" class="htmltable_Title2" colspan="4">
                條件畫面
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                查詢年月</td>
            <td colspan="3" class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True">
                </asp:DropDownList>年<asp:DropDownList ID="ddlMonth" runat="server">
                </asp:DropDownList>月
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr id="tr1" runat="server" visible="false" >
            <td class="htmltable_Left" style="width: 120px">單位名稱
            </td>
            <td class="htmltable_Right" style="width: 230px" colspan="3">
                <uc1:UcDDLAuthorityDepart runat="server" ID="UcDDLDepart" OnSelectedIndexChanged="UcDDLDepart_SelectedIndexChanged" />
            </td>
        </tr>            
        <tr id="tr2" runat="server" visible="false">
            <td class="htmltable_Left">人員姓名</td>
            <td colspan="3">
                <uc1:UcDDLAuthorityMember runat="server" ID="UcDDLMember" />
            </td>
        </tr>
    </table>
    <div style="text-align:center">
        <asp:Button ID="cbQuery" runat="server"  Text="查詢" />
        <asp:Button ID="toUpdate" runat="server" Text="送出申請" />
        <input id="toReset" type="button" runat="server" value="重填" />
        <asp:Button ID="toCancel" runat="server" Text="回上頁" Visible="false" />
        <asp:Button ID="toCount" runat="server" Text="自動計算" Visible="false" />
        <asp:Button ID="toPrint" runat="server" Text="請領清冊" Visible="false" />
        <asp:Button ID="cbRTP2" runat="server" Text="加班單明細" Visible="False" />
    </div>

    <table width="100%" class="tableStyle99" >
        <tr>
            <td class="htmltable_Left" style="width: 120px">每小時加班費
            </td>
            <td class="htmltable_Right" style="width: 230px" colspan="7">
                <asp:Label ID="lbHourPay" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="8" valign="top" class="TdHeightLight">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Borderwidth="0px"
                    CssClass="Grid" PagerStyle-HorizontalAlign="Right"
                    ShowFooter="false" width="100%">
                    <PagerSettings Position="TopAndBottom" />
                    <FooterStyle CssClass="Foot" />
                    <RowStyle CssClass="Row" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label ID="lbNo" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                
                                <asp:HiddenField ID="hfCheckType" runat="server" value='<%# Bind("CheckType")%>'/>
                                <asp:HiddenField ID="hdApplyHour1" runat="server" Value='<%# Bind("Apply_Hour_1") %>' />
                                <asp:HiddenField ID="hdApplyHour2" runat="server" Value='<%# Bind("Apply_Hour_2") %>' />
                                <asp:HiddenField ID="hdApplyHour3" runat="server" Value='<%# Bind("Apply_Hour_3") %>' /> 
                                <asp:HiddenField ID="hfPRATYPE" runat="server" value='<%# Bind("PRATYPE") %>'/>    

                                <asp:HiddenField ID="hfPRADDD" runat="server" value='<%# Bind("PRADDD") %>'/> 
                                <asp:HiddenField ID="hfPRADDE" runat="server" value='<%# Bind("PRADDE") %>'/> 
                                <asp:HiddenField ID="hfPRSTIME" runat="server" value='<%# Bind("PRSTIME") %>'/> 
                                <asp:HiddenField ID="hfPRETIME" runat="server" value='<%# Bind("PRETIME") %>'/> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PRNAME" HeaderText="人員姓名" />
                        <asp:TemplateField HeaderText="加班日期起">
                            <ItemTemplate>
                                <asp:Label ID="lbPRADDD_name" runat="server" Text='<%# Bind("PRADDD_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="加班日期迄">
                            <ItemTemplate>
                                <asp:Label ID="lbPRADDE_name" runat="server" Text='<%# Bind("PRADDE_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="加班類別">
                            <ItemTemplate>
                                <asp:Label ID="lbPRATYPE_name" runat="server" Text='<%# IIf(Eval("PRATYPE")="1","一般","專案") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="申請時間" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbStart_time" runat="server" Text='<%# Bind("Start_time") %>'></asp:Label>~<asp:Label ID="lbEnd_time" runat="server" Text='<%# Bind("End_time") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="加班時間">
                            <ItemTemplate>
                                <asp:Label ID="lbPRSTIME_name" runat="server" Text='<%# Bind("PRSTIME_name") %>'></asp:Label>~<asp:Label ID="lbPRETIME_name" runat="server" Text='<%# Bind("PRETIME_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="加班時數">
                            <ItemTemplate>
                                <asp:Label ID="lbPRADDH" runat="server" Text='<%# Bind("PRADDH") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="已休時數">
                            <ItemTemplate>
                                <asp:Label ID="lbPRPAYH" runat="server" Text='<%# Bind("PRPAYH") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="已領時數">
                            <ItemTemplate>
                                <asp:Label ID="lbPRMNYH" runat="server" Text='<%# Bind("PRMNYH") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>       
                        <asp:TemplateField HeaderText="請領時數">
                            <ItemTemplate>
                                <asp:TextBox ID="tbApply_hour" runat="server" Width="40" MaxLength="3" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="延長工時1-2小時(1)" Visible="false">
                            <ItemTemplate>
                                <asp:TextBox ID="tbApplyHour1" runat="server" Text='<%# Bind("Apply_Hour_1") %>'
                                    width="50px"></asp:TextBox>                                 
                            </ItemTemplate>
                            <HeaderStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="延長工時3-4小時(2)" Visible="false">
                            <ItemTemplate>
                                <asp:TextBox ID="tbApplyHour2" runat="server" Text='<%# Bind("Apply_Hour_2") %>'
                                    width="50px"></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="假日加班1-8小時(3)" Visible="false">
                            <ItemTemplate>
                                <asp:TextBox ID="tbApplyHour3" runat="server" Text='<%# Bind("Apply_Hour_3") %>'
                                    width="50px"></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="事由">
                            <ItemTemplate>
                                <asp:Label ID="lbPRREASON" runat="server" Text='<%# Bind("PRREASON") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <EmptyDataTemplate>
                        查無資料
                    </EmptyDataTemplate>
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hfYear" runat="server" />
    <asp:HiddenField ID="hfMonth" runat="server" />
    <asp:HiddenField ID="hfPESEX" runat="server" EnableViewState="true" />
    <asp:HiddenField ID="hfPEKIND" runat="server" EnableViewState="true" />
    <asp:HiddenField ID="hfLimit" runat="server" />
    <asp:HiddenField ID="hfLimit_H" runat="server"/>
    <asp:HiddenField ID="hfF1" runat="server" />
    <asp:HiddenField ID="hfF2" runat="server" />
    <asp:HiddenField ID="hfIsApply" runat="server" Value="false" />
    <asp:HiddenField ID="hfEmployeeType" runat="server" />
    <asp:HiddenField ID="hfDepart_id" runat="server" />
    <asp:HiddenField ID="hfId_card" runat="server" />
</asp:Content>

