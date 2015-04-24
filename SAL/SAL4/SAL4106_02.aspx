<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SAL4106_02.aspx.vb" Inherits="SAL4106_02" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc1" %>
<%@ Register src="~/UControl/UcShowDate.ascx" tagname="UcShowDate" tagprefix="uc2" %>
<%@ Register src="~/UControl/UcShowTime.ascx" tagname="UcShowTime" tagprefix="uc3" %>
<%@ Register src="~/UControl/UcROCYear.ascx" tagname="UcROCYear" tagprefix="uc4" %>
<%@ Register Src="~/UControl/UcDateTime.ascx" TagName="UcDateTime" TagPrefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">申請區間設定-新增
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;"><span style="color:Red">*</span>申請類別</td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                             <asp:DropDownList ID="ddlApply_type" runat="server" AutoPostBack="true" AppendDataBoundItems="True"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px"><span style="color:Red">*</span>申請年度</td>
                        <td class="htmltable_Right" style="width: 250px">
                             <uc4:UcROCYear ID="ddlAcademicYear" runat="server" />
                        </td>
                    </tr>
                    <tr id="tr1" runat="server" visible="false" >
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">申請學期</td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                         <asp:TextBox ID="txtSemeter" runat="server" MaxLength="2" Width="30px" ></asp:TextBox><span style="color:blue">註：申請類別為「子女教育補助費」，則要寫入</span></td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px"><span style="color:Red">*</span>申請日期(起)</td>
                        <td class="TdHeightLight">
                            <uc1:UcDate ID="UcDate1" runat="server" />
                            <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td class="htmltable_Left" style="width: 100px"><span style="color:Red">*</span>申請時間(起)</td>
                        <td class="TdHeightLight">
                            <asp:TextBox ID="UcDateTime1" runat="server" MaxLength="4" Width="50px" ></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" ForeColor="Blue" Text="※填寫範例:0000"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td class="htmltable_Left" style="width: 100px"><span style="color:Red">*</span>申請日期(迄)</td>
                        <td class="TdHeightLight">
                            <uc1:UcDate ID="UcDate2" runat="server" />
                            <asp:Label ID="Label2" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td class="htmltable_Left" style="width: 100px"><span style="color:Red">*</span>申請時間(迄)</td>
                        <td class="TdHeightLight">
                           <asp:TextBox ID="UcDateTime2" runat="server" MaxLength="4" Width="50px" ></asp:TextBox>
                           <asp:Label ID="Label4" runat="server" ForeColor="Blue" Text="※填寫範例:0000"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;"><span style="color:Red">*</span>開放狀態</td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                             <asp:DropDownList ID="ddlStatus" runat="server" AppendDataBoundItems="True">
                                <asp:ListItem Value="" Text="請選擇"></asp:ListItem>
                                <asp:ListItem Value="N" Text="不開放申請"></asp:ListItem>
                                <asp:ListItem Value="Y" Text="開放申請"></asp:ListItem>
                             </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" class="TdHeightLight">
                            <asp:Button ID="btnOK" runat="server" Text="確定"/>
                            <asp:Button ID="btnCancel" runat="server" Text="取消"/>
                            <input id="Reset" type="button" value="重填" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 358px" valign="top">
                <table id="tbq" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
                    visible="false" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title2" style="width: 100%" align="center">查詢結果
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
                               
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" />
                                <EmptyDataTemplate>
                                    查無資料!!
                                </EmptyDataTemplate>
                                <RowStyle CssClass="Row" />
                                <HeaderStyle CssClass="Grid" />
                                <AlternatingRowStyle CssClass="AlternatingRow" />
                                <PagerSettings Position="TopAndBottom" />
                                <EmptyDataRowStyle CssClass="EmptyRow" />
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
            </td>
        </tr>
    </table>
</asp:Content>
