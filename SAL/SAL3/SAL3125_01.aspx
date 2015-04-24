<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL3125_01.aspx.cs" Inherits="SAL_SAL3_SAL3125" %>

<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc3" %>
<%@ Register Src="../../UControl/UcROCYearMonth.ascx" TagName="UcROCYearMonth" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/SAL/ucDateDropDownList.ascx" TagName="ucDateDropDownList"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 
            <table class="tableStyle99" width="100%">
                <tr>
                    <td class="htmltable_Title" colspan="4">
                        勞健保投保金額調整作業
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        員工類別
                    </td>
                    <td class="htmltable_Right">
                        <uc3:ucSaCode ID="cmb_uc_EmployeeType" runat="server" Code_Kind="P" Code_sys="002"
                            Code_type="017" ControlType="2" Mode="query" />
                    </td>
                    <td class="htmltable_Left">
                        回推月份起算點
                    </td>
                    <td class="htmltable_Right" style="width: 326px">
                        <uc4:ucDateDropDownList ID="cmb_uc_YearMonth" runat="server" Kind="YM" title="民國" />
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        報表名稱
                    </td>
                    <td class="htmltable_Right" colspan="3">
                        <asp:DropDownList ID="cmbReportType" runat="server">
                            <asp:ListItem Value="001" Text="勞健保投保金額調整計算表" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="002" Text="調昇勞健保投保金額明細表"></asp:ListItem>
                            <asp:ListItem Value="003">調降勞健保投保金額明細表</asp:ListItem>
                            <asp:ListItem Value="004">補收勞健保及眷屬健保費自付差額明細表</asp:ListItem>
                            <asp:ListItem Value="005">退回勞健保及眷屬健保費自付差額明細表</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                        <asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click" 
                          />
                        <asp:Button ID="btnAdjust" runat="server" Text="調整" OnClick="btnAdjust_Click" />
                        <asp:Button ID="btnPrint" runat="server" Text="列印" OnClick="btnPrint_Click" />
                        <asp:Button ID="btnExport" runat="server" Text="匯出申報表" OnClick="btnExport_Click"
                            Visible="False" />
                    </td>
                </tr>
            </table>
    
    <!-- 資料查詢結果 Panel-->
    <asp:Panel ID="pnlResult" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title2">
                    查詢結果
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <asp:GridView ID="gvResult" runat="server" CssClass="Grid" Width="100%" AutoGenerateColumns="False"
                        EnableModelValidation="True" OnRowDataBound="gvResult_RowDataBound" AllowPaging="True"
                        OnDataBinding="gvResult_DataBinding" OnDataBound="gvResult_DataBound" 
                        PageSize="30" onpageindexchanging="gvResult_PageIndexChanging">
                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                        <EmptyDataTemplate>
                            查無資料!!
                        </EmptyDataTemplate>
                        <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkAll_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <HeaderTemplate>
                        <table width="100%" >
                           <tr>
                              <td rowspan="2" width="10%">
                                姓名
                              </td>
                              <td colspan="2" width="10%"> 
                                  <asp:Label ID="lbheader1" runat="server" Text=""></asp:Label>
                              </td>
                              <td colspan="2" width="10%"> 
                                  <asp:Label ID="lbheader2" runat="server" Text=""></asp:Label>
                              </td>
                              <td colspan="2" width="10%"> 
                                  <asp:Label ID="lbheader3" runat="server" Text=""></asp:Label>
                              </td>
                              <td rowspan ="2" width="10%">
                              不休假加班費
                              </td>
                              <td width="10%">
                              三個月平均工資
                              </td>
                              <td colspan ="2" width="10%">
                              舊勞保
                              </td>
                              <td colspan="2" width="10%">
                              新勞保
                              </td>
                              <td colspan="2" width="10%">
                              舊健保
                              </td>
                              <td colspan="2" width="10%">
                              新健保
                              </td>
                           </tr>
                           <tr>
                              <td width="5%">
                              薪資
                              </td>
                              <td width="5%">
                              加班費
                              </td>
                               <td width="5%">
                              薪資
                              </td>
                              <td width="5%">
                              加班費
                              </td>
                                <td width="5%">
                              薪資
                              </td>
                              <td width="5%">
                              加班費
                              </td>
                              <td width="10%">
                              投保金額
                              </td>
                              <td width="5%">
                              投保金額
                              </td>
                              <td width="5%">
                              自付額
                              </td>
                               <td width="5%">
                              投保金額
                              </td>
                              <td width="5%">
                              自付額
                              </td>
                               <td width="5%">
                              投保金額
                              </td>
                              <td width="5%">
                              自付額
                              </td>
                              <td width="5%">
                              投保金額
                              </td>
                              <td width="5%">
                              自付額
                              </td>
                           </tr>
                        </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                           <table width="100%" >
                           <tr>
                              <td align="left" width="10%">
                                   <asp:Label ID="lbl_BASE_NAME" runat="server" Text='<%# Eval("BASE_NAME") %>'></asp:Label>
                                    <asp:Label ID="lbl_BASE_SEQNO" runat="server" Text='<%# Eval("Base_seqno") %>' Visible="False"></asp:Label>
                                    <asp:Label ID="lbl_STWS_LEVEL_New" runat="server" Text='<%# STWS_LEVEL_New(Eval("BASE_SEQNO").ToString())  %>'
                                        Visible="False"></asp:Label>
                                    <asp:Label ID="lbl_STWS_LEVEL_002_New" runat="server" Text='<%# STWS_LEVEL_002_New(Eval("BASE_SEQNO").ToString()) %>'
                                        Visible="False"></asp:Label>
                                    <asp:Label ID="lbl_base_labor_series" runat="server" Text='<%# Eval("base_labor_series") %>'
                                        Visible="False"></asp:Label>
                              </td>
                              <td align="right" width="5%"> 
                               <asp:Label ID="Label1" runat="server" Text='<%# sum_payod_amt_1(Eval("Base_seqno").ToString()) %>'></asp:Label>
                              </td>
                              <td align="right" width="5%"> 
                                 <asp:Label ID="Label2" runat="server" Text='<%# sum_payod_amt_005_1(Eval("Base_seqno").ToString()) %>'></asp:Label>
                              </td>
                              <td align="right" width="5%"> 
                                    <asp:Label ID="Label3" runat="server" Text='<%# sum_payod_amt_2(Eval("Base_seqno").ToString()) %>'></asp:Label>
                              </td>
                              <td align="right" width="5%">
                                <asp:Label ID="Label4" runat="server" Text='<%# sum_payod_amt_005_2(Eval("Base_seqno").ToString()) %>'></asp:Label>
                              </td>
                              <td align="right" width="5%">
                                <asp:Label ID="Label5" runat="server" Text='<%# sum_payod_amt_3(Eval("Base_seqno").ToString()) %>'></asp:Label>
                              </td>
                              <td align="right" width="5%">
                                <asp:Label ID="Label6" runat="server" Text='<%# sum_payod_amt_005_3(Eval("Base_seqno").ToString()) %>'></asp:Label>
                              </td>
                              <td align="right" width="10%">
                                 <asp:Label ID="Label7" runat="server" Text='<%# sum_payod_amt_NoLeave(Eval("Base_seqno").ToString()) %>'></asp:Label>
                              </td>
                              <td align="right" width="10%">
                                <asp:Label ID="Label8" runat="server" Text='<%# avg3Months(Eval("Base_seqno").ToString()) %>'></asp:Label>
                              </td>
                              <td align="right" width="5%">
                                  <asp:Label ID="Label9" runat="server" Text='<%# stws_stand_001(Eval("base_labor_series").ToString()) %>'></asp:Label>
                              </td>
                              <td align="right" width="5%">
                                  <asp:Label ID="Label10" runat="server" Text='<%# sum_payod_amt_001(Eval("BASE_SEQNO").ToString()) %>'></asp:Label>
                              </td>
                              <td align="right" width="5%">
                                  <asp:Label ID="Label11" runat="server" Text='<%# stws_stand_001_001(Eval("BASE_SEQNO").ToString()) %>'></asp:Label>
                              </td>
                              <td align="right" width="5%">
                                  <asp:Label ID="Label12" runat="server" Text='<%# sum_payod_amt_001_001(Eval("base_labor_status").ToString(),
                                  Eval("base_labor_series").ToString(),Eval("base_lab_jif").ToString(),Eval("base_fins_self").ToString(),
                                  Eval("BASE_BDATE").ToString(),Eval("BASE_EDATE").ToString(),Eval("base_lab1").ToString(),
                                  Eval("base_lab2").ToString(),Eval("base_lab3").ToString(),Eval("base_fins_kind").ToString()
                                  ) %>'></asp:Label>
                              </td>
                              <td align="right" width="5%">
                                  <asp:Label ID="Label13" runat="server" Text='<%# stws_stand_002(Eval("base_fins_series").ToString()) %>'></asp:Label>
                              </td>
                              <td align="right" width="5%">
                                  <asp:Label ID="Label14" runat="server" Text='<%# Eval("base_fin_amt") %>'></asp:Label>
                              </td>
                              <td align="right" width="5%">
                                  <asp:Label ID="lbl_stws_stand_002_New" runat="server" Text='<%# stws_stand_002_New(Eval("BASE_SEQNO").ToString()) %>'></asp:Label>
                              </td>
                              <td align="right" width="5%">
                                  <asp:Label ID="lbl_Stws_dct" runat="server" Text='<%# Stws_dct(Eval("BASE_SEQNO").ToString()) %>'></asp:Label>
                              </td>
                           </tr>                        
                        </table>
                        </ItemTemplate>
                        </asp:TemplateField>  
                        </Columns>
                        <PagerSettings Position="TopAndBottom" />
                        <PagerStyle HorizontalAlign="Right" />
                    </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>
            </tr>
            <tr>
                <td align="right">
                    <uc1:Ucpager ID="Ucpager1" runat="server" GridName="gvResult" PNow="1" PSize="30" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnAdjOK" runat="server" Text="確定" OnClick="btnAdjOK_Click" Visible="False" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:TextBox ID="txtMode" runat="server" Visible="False"></asp:TextBox>
</asp:Content>
