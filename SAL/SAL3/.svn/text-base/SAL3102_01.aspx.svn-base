<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL3102_01.aspx.cs" Inherits="SAL_SAL3_VBOld_SAL3102_01" %>

<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc1" %>
<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc3" %>
<%@ Register src="../../UControl/SAL/ucBankNo_v2.ascx" tagname="ucBankNo_v2" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- 查詢條件 -->
    <asp:Panel ID="pnlCondition" runat="server">

    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">
                非員工薪資基本資料維護
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                依人名或身份證號
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="v_Search_str__" runat="server" MaxLength="20" />
            </td>
            <td class="htmltable_Left">
                身份別
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="v_base_type__" runat="server">
                    <asp:ListItem Value="ALL" Text="---全部---" Selected="True" />
                    <asp:ListItem Value="1" Text="個人" />
                    <asp:ListItem Value="2" Text="外僑" />
                    <asp:ListItem Value="3" Text="事業機關" />
                    <asp:ListItem Value="NUL" Text="(尚未設定)" />
                </asp:DropDownList>
            </td>
        </tr>
        <!--<tr>
            <td class="htmltable_Left">
                排序
            </td>
            <td colspan="3" class="htmltable_Right">
                <asp:DropDownList ID="v_orders__" runat="server">
                    <asp:ListItem Value="base_name" Text="姓名" />
                    <asp:ListItem Value="" Text="列印順序" Selected="True" />
                </asp:DropDownList>
            </td>
        </tr>-->
        <tr>
            <td colspan="4" class="htmltable_Bottom">
                <asp:Button ID="b_ToSearch" runat="server" Text="查詢" OnClick="b_ToSearch_Click" />
                <asp:Button ID="b_ToAdd" runat="server" Text="新增" OnClick="b_ToAdd_Click" />
                <asp:Button ID="b_ShowAll" runat="server" Text="顯示全部" OnClick="b_ShowAll_Click" />
            </td>
        </tr>
    </table>
        </asp:Panel>
    <!-- 結果 Grid -->
    <asp:Panel ID="pnlResult" runat="server" Visible="False">
        <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title2">
                查詢結果
            </td>
        </tr>            <tr>
                <td>
                   
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        AllowPaging="True" 
                        CssClass="Grid" CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%"
                        OnRowCommand="GridView1_RowCommand" EnableModelValidation="True" 
                        onpageindexchanging="GridView1_PageIndexChanging">
                        <EmptyDataTemplate>
                            查無人員資料
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="身份別" SortExpression="base_type">
                                <ItemTemplate>
                                    <asp:Label ID="c_base_type" runat="server" Text='<%# SALARY.Logic.app.GetBaseTypeText( Eval("base_type").ToString() ) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="身份證號/護照/統編" SortExpression="base_idno">
                                <ItemTemplate>
                                    <asp:LinkButton ID="c_base_idno_LinkButton" runat="server" Text='<%# Eval("base_idno") %>'
                                        CommandName="EditX" CommandArgument='<%# Eval("base_seqno").ToString() + ";" + Eval("base_orgid").ToString() %>'
                                        ToolTip='<%# Eval("base_seqno").ToString() + ";" + Eval("base_orgid").ToString() %>'
                                        CausesValidation="false" ForeColor="Black" Font-Underline="false" />
                                    <asp:Label ID="c_base_idno" runat="server" Text='<%# Eval("base_idno") %>' Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="姓名/職稱" SortExpression="base_name">
                                <ItemTemplate>
                                    <asp:LinkButton ID="c_base_idno_LinkButton_2" runat="server" Text='<%# Eval("base_name") %>'
                                        CommandName="EditX" CommandArgument='<%# Eval("base_seqno").ToString() + ";" + Eval("base_orgid").ToString() %>'
                                        ToolTip='<%# Eval("base_seqno").ToString() + ";" + Eval("base_orgid").ToString() %>'
                                        CausesValidation="false" ForeColor="Black" Font-Underline="false" />
                                    <asp:Label ID="c_base_name" runat="server" Text='<%# Eval("base_name") %>' Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="最近修改日期" SortExpression="base_mdate">
                                <ItemTemplate>
                                    <asp:Label ID="c_base_mdate" runat="server" Text='<%# SALARY.Logic.pub.FormatDateString( Eval("base_mdate").ToString() ) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="隱藏註記">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# ConvertYNtoTrueFalse2(Eval("base_isMarked").ToString()) %>' />
                                    <asp:CheckBox ID="cb_checkBox1" runat="server" Checked='<%# ConvertYNtoTrueFalse(Eval("base_isMarked").ToString()) %>'  Visible="false" />
                                    <asp:Label ID="c_base_seqno" runat="server" Text='<%# Eval("base_seqno") %>' Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="base_isMarked" SortExpression="base_isMarked" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="c_base_isMarked" runat="server" Text='<%# Eval("base_isMarked") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="base_seqno" SortExpression="base_seqno" Visible="false">
                                <ItemTemplate>
                                    *
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="base_prono" SortExpression="base_prono" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="c_base_prono" runat="server" Text='<%# Eval("base_prono") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="維護">
                                <ItemTemplate>
                                    <asp:Button ID="Button1" runat="server" Text="修改" CommandName="EditX" CommandArgument='<%# Eval("base_seqno").ToString() + ";" + Eval("base_orgid").ToString() %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="Row" />
                        <AlternatingRowStyle CssClass="AlternatingRow" />
                        <PagerSettings Position="TopAndBottom" />
                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                    </asp:GridView>
                     <uc1:Ucpager ID="Ucpager1" runat="server" GridName="GridView1" PNow="1" 
                        PSize="30" />
                </td>
            </tr>
            <!--<tr>
                <td class="htmltable_Bottom" align="center">
                    <asp:Button ID="b_toMark" runat="server" Text="儲存註記" 
                        OnClientClick="javascript: return confirm('儲存註記');" onclick="b_toMark_Click" />
                </td>
            </tr>-->
        </table>
    </asp:Panel>
    <!-- 修改 PANEL-->
    <asp:Panel ID="pnlModify" runat="server" Visible="False">
        <table style="width: 100%" class="tableStyle99">
            <tr>
                <td class="htmltable_Title" colspan="4" style="text-align: center">
                    <asp:Label ID="Label_title" runat="server" Text="修改非員工基本資料"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" width="15%">
                    <asp:Label ID="Label_name" runat="server" Text="人員姓名"></asp:Label>
                </td>
                <td class="htmltable_Right" width="35%">
                    <asp:TextBox ID="_base_name" runat="server" Width="105" />
                </td>
                <td class="htmltable_Left" style="display: __display__" name="isMarked" id="isMarked"
                    width="35%">
                    隱藏註記
                </td>
                <td class="htmltable_Right" name="isMarked2" id="isMarked2" style="display: __display__">
                    <asp:CheckBox ID="_base_isMarked" runat="server" Text="隱藏" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    <asp:Label ID="Label_idno" runat="server" Text="身分證字號"></asp:Label>
                </td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="_base_idno" runat="server" Columns="15" />
                </td>
                <td class="htmltable_Left" id="div_ermk" runat="server">
                    錯誤註記
                </td>
                <td class="htmltable_Right" id="div_ermk2" runat="server">
                    <asp:CheckBox ID="_base_ermk" runat="server" Text="錯誤" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" id="div_status" runat="server">
                    本署員工
                </td>
                <td class="htmltable_Right" id="div_status2" runat="server">
                    <asp:RadioButtonList ID="_base_status" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="Y"> 是 </asp:ListItem>
                        <asp:ListItem Value="N" Selected="true"> 否 </asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="htmltable_Left" id="div_sex" runat="server">
                    性別
                </td>
                <td class="htmltable_Right" id="div_sex2" runat="server">
                    <asp:RadioButtonList ID="_base_sex" runat="server" RepeatDirection="Horizontal" DefaultSelectedIndex="0">
                        <asp:ListItem Value="M" Selected="True"> 男 </asp:ListItem>
                        <asp:ListItem Value="F"> 女 </asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
<%--            <tr>
                <td class="htmltable_Left" style="width: 120px" runat="server" id="div_Dates">
                    到職日期
                </td>
                <td class="htmltable_Right" id="div_Dates2" runat="server">
                    <!-- edit_base_bdate-->
                    <uc2:UcDate ID="edit_base_bdate" runat="server" />
                </td>
                <td class="htmltable_Left" runat="server" id="div_Datee">
                    離職日期
                </td>
                <td class="htmltable_Right" runat="server" id="div_Datee2">
                    <!-- edit_base_edate-->
                    <uc2:UcDate ID="edit_base_edate" runat="server" />
                </td>
            </tr>--%>
            <tr>
                <td class="htmltable_Left">
                    兼職人員
                </td>
                <td class="htmltable_Right">
                    <asp:RadioButtonList ID="edit_base_parttime" runat="server" RepeatDirection="Horizontal"
                        AutoPostBack="true">
                        <asp:ListItem Value="Y"> 是 </asp:ListItem>
                        <asp:ListItem Value="N" Selected="True"> 否 </asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="htmltable_Left">
                    出生年月日
                </td>
                <td class="htmltable_Right">
                    <!-- edit_baseext_birthday -->
                    <uc2:UcDate ID="edit_baseext_birthday" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    身份別
                </td>
                <td class="htmltable_Right">
                    <asp:RadioButtonList ID="_base_type" RepeatDirection="Horizontal" runat="server"
                        AutoPostBack="true" 
                        onselectedindexchanged="_base_type_SelectedIndexChanged">
                        <asp:ListItem Value="1" Selected="true">個人&nbsp;</asp:ListItem>
                        <asp:ListItem Value="2">外僑&nbsp;</asp:ListItem>
                        <asp:ListItem Value="3">事業機關&nbsp;</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="htmltable_Left">
                    員工類別
                </td>
                <td class="htmltable_Right">
                    <uc1:ucSaCode ID="_base_prono" runat="server" Code_sys="002" Code_type="017" Code_Kind="P" ControlType="2" Code_Remark1="N" Mode="edit" />
                </td>
            </tr>
            <div runat="server" id="div_DcodeName">
                <tr>
                    <td class="htmltable_Left">
                        職稱
                    </td>
                    <td class="htmltable_Right" runat="server" id="div_DcodeName2">
                        <asp:TextBox runat="server" ID="txtDcodeName" Text='<%# Bind("BASE_DCODE_NAME") %>'></asp:TextBox>
                    </td>
                    <td class="htmltable_Right" colspan="2">
                </tr>
            </div>
            <tr>
                <td class="htmltable_Left">
                    地址
                </td>
                <td class="htmltable_Right" colspan="3">
                    <asp:TextBox ID="_base_addr" runat="server" Width="60%" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    email
                </td>
                <td colspan="3" class="htmltable_Right">
                    <asp:TextBox ID="_base_email" runat="server" Width="60%" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="_base_email"
                            ErrorMessage="輸入的電子郵件有誤!" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*|[1]"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    執行業務別
                </td>
                <td colspan="3" class="htmltable_Right">
                    <!-- _base_prof -->
                    <uc3:ucSaCode ID="_base_prof" runat="server" Code_sys="002" Code_type="019" Code_Kind="P"
                        ControlType="2" Mode="edit" />
                </td>
            </tr>
<%--            <tr>
                <td class="htmltable_Left">
                    健保種類
                </td>
                <td colspan="3" class="htmltable_Right">
                    <asp:RadioButtonList ID="rbt_base_fins_kind" runat="server" RepeatDirection="Horizontal"
                        AutoPostBack="true">
                        <asp:ListItem Value="001"> 公健</asp:ListItem>
                        <asp:ListItem Value="002"> 勞健 </asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>--%>
            <tr runat="server" id="div_bank">
                <td class="htmltable_Title" colspan="4" style="text-align: center" bgcolor="#dddddd">
                    《銀行設定》
                </td>
            </tr>
            <tr runat="server" id="div_bank2">
                <td class="htmltable_Left">
                    銀行帳號
                </td>
                <td class="htmltable_Right" colspan="3">
                    <uc4:ucBankNo_v2 ID="ucBankNo_v2_bank" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="text-align: center">
                    ※備註
                </td>
                <td class="htmltable_Right" colspan="3">
                    <asp:TextBox ID="_base_memo" runat="server" Columns="100" Rows="7" TextMode="MultiLine" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" valign="top" colspan="4">
                    <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="UpdateX"
                        Text="儲存" OnClick="UpdateButton_Click" />
                    <asp:Button ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="取消" onclick="UpdateCancelButton_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Configz" runat="server" Visible="false">
        <div>
            _base_seqno
            <asp:TextBox ID="_base_seqno" runat="server" />
            <asp:TextBox ID="txtShowAll" runat="server" />
            <asp:TextBox ID="MODE" runat="server" />
        </div>
    </asp:Panel>
</asp:Content>
