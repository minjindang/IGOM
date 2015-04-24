<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SAL2113_01.aspx.vb" Inherits="SAL2113_01" %>

<%@ Register src="../../UControl/SAL/ucSaCode.ascx" tagname="ucSaCode" tagprefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" border="0" cellspacing="0" cellpadding="0" style="line-height: 160%; width: 100%">
        <tr>
            <td class="htmltable_Title">
                補充保費繳費單
            </td>
        </tr>
        <tr class="col_5">
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="RadioButtonList_step" Width="100%" runat="server" AutoPostBack="true"
                    RepeatDirection="Horizontal">
                    <asp:ListItem Text="保險對象各類所得" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="投保單位(機關負擔)" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    <br />
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title2">
                查詢
            </td>
        </tr>
        <tr>
            <td>
            <table class="tableStyle99" width="100%">
                            <tr id="div_nhi" runat="server">
                                <td class="htmltable_Left">
                                    <div >
                                        選擇投保單位:                                    
                                    </div>
                                </td>
                                <td class="htmltable_Right" colspan="3">
                                    <asp:DropDownList ID="ddlNHINO" runat="server">
                                    </asp:DropDownList>
                                        &nbsp;&nbsp;
                                    <asp:CheckBox ID="cbSum" Visible="false" runat="server" Text="計算所有投保單位薪資（50）給付總額" />
                                </td>
                            </tr>
                            <tr>
                                <td   class="htmltable_Left">選擇給付年月：
                                </td>
                                <td class="htmltable_Right" colspan="3">
                                    <asp:DropDownList ID="ddlYY" runat="server">
                                    </asp:DropDownList>&nbsp;年&nbsp;
                                    <asp:DropDownList ID="ddlMM" runat="server">
                                        <asp:ListItem Value="01" Text="01"></asp:ListItem>
                                        <asp:ListItem Value="02" Text="02"></asp:ListItem>
                                        <asp:ListItem Value="03" Text="03"></asp:ListItem>
                                        <asp:ListItem Value="04" Text="04"></asp:ListItem>
                                        <asp:ListItem Value="05" Text="05"></asp:ListItem>
                                        <asp:ListItem Value="06" Text="06"></asp:ListItem>
                                        <asp:ListItem Value="07" Text="07"></asp:ListItem>
                                        <asp:ListItem Value="08" Text="08"></asp:ListItem>
                                        <asp:ListItem Value="09" Text="09"></asp:ListItem>
                                        <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                        <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                        <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                    </asp:DropDownList>&nbsp;月&nbsp;
                                </td>                             
                            </tr>
                            <tr>
                             <td class="htmltable_Left">
                                  預算來源：
                                </td>
                                <td class="htmltable_Right" colspan ="3" >
                                       <uc2:ucSaCode ID="UcSaCode1" runat="server"  Code_Kind="P" Code_sys="002"
                            Code_type="018" ControlType="2" Mode="query" Budget_Code="Y" ShowMulti="True" />
                                </td>  
                            </tr>
                            <tr>
                                <td colspan="4" align="center" class="TdHeightLight">
                                    <asp:Button ID="btnSearch" runat="server" Text="查詢" class="button" 
                                       />
                                </td>
                            </tr>
                        </table>
            </td>
        </tr>
    </table>
    <div runat="server" id="div_rptunit">
        <table cellspacing="1" cellpadding="1" class="tableStyle99" width="100%">
            <tr>
                <td colspan="3" class="htmltable_Title2">給付年月：
                        <asp:Label ID="lbUnitYY" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" class="TdHeightLight">
                    <asp:GridView ID="gvExt" BorderWidth="0" runat="server"
                        PagerSettings-Mode="NextPreviousFirstLast" AutoGenerateColumns="False"
                        CellPadding="1" CellSpacing="1" CssClass="Grid"
                        Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="項目">
                                <ItemTemplate>
                                    &nbsp;&nbsp;
                            <asp:Label ID="lbCode_Desc1" runat="server" Text='<%# Eval("Code_Desc1") %>'></asp:Label>
                                    <asp:Label ID="lbCode_No" runat="server" Text='<%# Eval("Code_No") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Cssclass="htmltable_Right" HorizontalAlign="left" />
                                <HeaderStyle Width="30%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="應繳金額">
                                <ItemTemplate>
                                    &nbsp;&nbsp;
                            <asp:TextBox ID="txtAmt" Text='<%# Bind("amt") %>' runat="server"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Cssclass="htmltable_Right" HorizontalAlign="left" />
                                <HeaderStyle Width="50%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="列印">
                                <ItemTemplate>
                                    <asp:Button ID="btnPrint" CommandName="Print" runat="server" Text="列印" CssClass="button" />
                                </ItemTemplate>
                                <ItemStyle Cssclass="htmltable_Right" HorizontalAlign="center" />
                                <HeaderStyle Width="20%" />
                            </asp:TemplateField>
                        </Columns>
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
        </table>

    </div>

    <div runat="server" id="div_rptnhi">
        <table cellspacing="1" cellpadding="1" class="tableStyle99" width="100%">
            <tr>
                <td style="width: 30%" class="htmltable_Left">投保單位
                </td>
                <td class="htmltable_Right" colspan="3" >
                    <asp:Label ID="lbNhiNO_show" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lbNhiNO" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Label ID="lbNhiSum" runat="server" Text="" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 30%" class="htmltable_Left">給付年月
                </td>
                <td class="htmltable_Right" colspan="3">
                    <asp:Label ID="lbNhiYY" runat="server" Text=""></asp:Label>
                </td>
            </tr>
               <tr>
                <td style="width: 30%" class="htmltable_Left">預算來源
                </td>
                <td class="htmltable_Right" colspan="3">
                    <asp:Label ID="lb_budget" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 30%" class="htmltable_Left">員工本月薪資總額
                </td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" BackColor="LightGray"></asp:TextBox>
                </td>
                  <td style="width: 30%" class="htmltable_Left">非員工本月薪資總額
                </td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="TextBox2" runat="server" ReadOnly="true" BackColor="LightGray"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 30%" class="htmltable_Left">本月薪資總額
                </td>
                <td class="htmltable_Right" colspan="3">
                    <asp:TextBox ID="txtNhiTot" runat="server" ReadOnly="true" BackColor="LightGray"></asp:TextBox>
                    <asp:Label ID="lbNhiTot" runat="server" Text="" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 30%" class="htmltable_Left">本月投保金總額
                </td>
                <td class="htmltable_Right" colspan="3">
                    <asp:TextBox ID="txtNhiFin" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 30%" class="htmltable_Left">應繳補充保費試算金額
                </td>
                <td class="htmltable_Right" colspan="3">
                    <asp:TextBox ID="txtNhiAmt" runat="server" Text="0" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="TdHeightLight" align="center" colspan="4">
                    <asp:Button ID="btnNhiCalc" runat="server" Text="試算"  />
                    <asp:Button ID="btnNhi" runat="server" Text="列印繳款書"  />
                </td>
            </tr>
        </table>
    </div>
    <asp:Label Visible="false" runat="server" ID="Message1"></asp:Label>
</asp:Content>
