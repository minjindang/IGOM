<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL3111_01.aspx.cs" Inherits="SAL_SAL3_SAL3111" %>
<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/UcROCYearMonth.ascx" TagName="UcROCYearMonth" TagPrefix="uc3" %>
<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc4" %>
<%@ Register Src="../../UControl/SAL/UcSelectOrg.ascx" TagName="UcSelectOrg" TagPrefix="uc5" %>
<%@ Register Src="../../UControl/UcDDLDepart.ascx" TagName="UcDDLDepart" TagPrefix="uc1" %>
<%@ Register src="../../UControl/SAL/ucDateDropDownList.ascx" tagname="ucDateDropDownList" tagprefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        function IsFloatText() {
            var charkc = window.event.keyCode
            if (charkc == 46 || (charkc >= 48 && charkc <= 57)) {
                return true;
            }
            return false;
        }
        </script>
        <!--
<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
<Triggers>
<asp:PostBackTrigger ControlID="Button_Caculate"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="btnShowDetailFinish"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="btnReset"></asp:PostBackTrigger>
</Triggers>
<ContentTemplate>  -->
    
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">
                薪資計算作業
            </td>
        </tr>
        <tr>
            <td colspan="4">
                ※請選擇計算條件
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" width="15%">
                計算項目
            </td>
            <td class="htmltable_Right" width="35%">
                <uc2:ucSaCode ID="cmb_uc_calitem" runat="server" Code_Kind="P" Code_sys="003" Code_type="005"
                    ControlType="2" />
            </td>
            <td class="htmltable_Left" width="15%">
                計算範圍
            </td>
            <td class="htmltable_Right" width="35%">
                <asp:DropDownList ID="cmbRangeSelection" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmb_uc_rangeselection_SelectedIndexChanged">
                    <asp:ListItem Value="001">全部(含臨時工)</asp:ListItem>
                    <asp:ListItem Value="002">全部(不含臨時工)</asp:ListItem>
                    <asp:ListItem Value="003">臨時工</asp:ListItem>                  
                    <asp:ListItem Value="005">挑選人員</asp:ListItem>
                </asp:DropDownList> 
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                計算年月
            </td>
            <td class="htmltable_Right">
                <uc6:ucDateDropDownList ID="UcROCYearMonth1" runat="server" Kind="YM" title="民國" />
                
            </td>
            <td class="htmltable_Left">
                <asp:Label ID="Label1" runat="server" Text="預定發放日期"></asp:Label>
            </td>
            <td class="htmltable_Right">
                <uc4:UcDate ID="txtUcDate" runat="server" />
            </td>
        </tr>
        <tr ID="pnlMonths" runat="server" Visible="false">
        <td colspan ="4">
      
                   <table class="tableStyle99" width="100%">

                    <tr>
                        <td class="htmltable_Left" width="15%">獎金月數
                        </td>
                        <td class="htmltable_Right"><asp:TextBox ID="txtMonths" runat="server"  onkeypress="return IsFloatText();"></asp:TextBox>月
                        </td>
                        </tr>
                        </table>
          
        </td>        
        </tr>
        <tr>
            <td colspan="4">
                <!--人員類別 Panel-->
                <asp:Panel ID="pnlUserOptions" runat="server">
                    <table class="tableStyle99" width="100%">
                    <tr>
                        <td colspan="4">
                            <table class="tableStyle99" width="100%">
                                <tr>
                                    <td class="htmltable_Left" width="15%">
                                        人員類別
                                    </td>
                                    <td class="htmltable_Right" colspan="3">
                                        <uc2:ucSaCode ID="ddlType" runat="server" Code_sys="002" Code_Kind="P" Code_type="017"
                                            ControlType="2" ShowMulti="True" ShowCode="True" />

                                    </td>
                                </tr>
                                <tr>
                                    <td class="htmltable_Left">
                                        在職狀態
                                    </td>
                                    <td class="htmltable_Right" width="35%">
                                        <asp:DropDownList ID="cmbOnJob" runat="server">
                                            <asp:ListItem Value="0">全部</asp:ListItem>
                                            <asp:ListItem Value="1">在職</asp:ListItem>
                                            <asp:ListItem Value="2">離職</asp:ListItem>
                                            <asp:ListItem Value="3">非員工</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="htmltable_Left" width="15%">
                                        依姓名查詢
                                    </td>
                                    <td class="htmltable_Right" width="35%">
                                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="htmltable_Left">
                                        占缺單位別
                                    </td>
                                    <td class="htmltable_Right">                                     

                                   <uc1:UcDDLDepart ID="UcDDLDepart" runat="server"  />
                                    </td>
                                    <td class="htmltable_Left">
                                        服務單位別
                                    </td>
                                    <td class="htmltable_Right">
                                   <uc1:UcDDLDepart ID="UcDDLDepart1" runat="server"  />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                <asp:Panel ID="pnlSerNO" runat="server"> <!--批號部分-->                   
                    <table class="tableStyle99" width="100%">
                        <tr>
                            <td class="htmltable_Left" width="15%">
                                請輸入批號
                            </td>
                            <td class="htmltable_Right" width="85%">
                                <asp:TextBox ID="edtBatNo" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="4">            
                <asp:Panel ID="pnlOthers" runat="server" Width="100%">    <!--其他新金發放項目-->
                    <table class="tableStyle99" width="100%">
                        <tr>
                            <td class="htmltable_Left">
                                需計算之其他薪津項目
                            </td>
                            <td class="htmltable_Right">
                                <asp:CheckBoxList ID="chkOtherItem" runat="server" AutoPostBack="True" OnSelectedIndexChanged="chkOtherItem_SelectedIndexChanged"
                                    RepeatColumns="5" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">

            </td>
        </tr>
    </table>

    <asp:GridView ID="gvResult" runat="server" CssClass="Grid" AutoGenerateColumns="False"
        EnableModelValidation="True" Width="100%" 
        onrowcommand="gvResult_RowCommand">
        <EmptyDataTemplate>
            查無資料!!
        </EmptyDataTemplate>
        <RowStyle CssClass="Row" />
        <AlternatingRowStyle CssClass="AlternatingRow" />
        <PagerSettings Position="TopAndBottom" />
        <Columns>
            <asp:TemplateField HeaderText="選項">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" />
                    <asp:HiddenField ID="hfPAYITEM_Code" runat="server" Value='<%# Bind("PAYITEM_Code") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="PAYITEM_CodeNo" />
            <asp:BoundField DataField="PAYITEM_Budget_code" />
            <asp:BoundField DataField="PAYITEM_Merge_flow_id" HeaderText="批號" />
            <asp:BoundField HeaderText="項目" DataField="ItemName" />
            <asp:BoundField DataField="BudgeName" HeaderText="預算來源" />
            <asp:BoundField DataField="sum_PAYITEM_Pay_amt" HeaderText="金額" />
            <asp:TemplateField HeaderText="明細">
                <ItemTemplate>
                    <asp:LinkButton ID="AddButton" runat="server" CommandName="ShowDetail" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                        Text="明細資料" /> 
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
    </asp:GridView>

    <asp:Panel ID="pnlDetail" runat="server" Visible="False">
        <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="False" CssClass="Grid"
            EnableModelValidation="True" Width="100%">
            <Columns>
                <asp:BoundField DataField="PAYITEM_Merge_flow_id" HeaderText="批號" />
                <asp:BoundField DataField="EmpName" HeaderText="姓名" />
                <asp:BoundField DataField="ItemName" HeaderText="項目" />
                <asp:TemplateField HeaderText="預算來源">
                    <ItemTemplate>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <uc2:ucSaCode ID="cmb_uc_BudgeSource" runat="server" Code_Kind="P" Code_sys="002"
                                    Code_type="018" ControlType="2" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="金額">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ID="edtAmount" Text='<%# DataBinder.Eval(Container.DataItem, "PAYITEM_Pay_amt") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PAYITEM_Budget_code" />
                <asp:BoundField DataField="PAYITEM_User_id" HeaderText="PAYITEM_User_id" />
                <asp:BoundField DataField="PAYITEM_codesys" />
                <asp:BoundField DataField="PAYITEM_codekind" />
                <asp:BoundField DataField="PAYITEM_codetype" />
                <asp:BoundField DataField="PAYITEM_codeno" />
                <asp:BoundField DataField="PAYITEM_code" />
            </Columns>
            <RowStyle CssClass="Row" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
        </asp:GridView>
    </asp:Panel>

        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                    <asp:Button ID="Button_Search" runat="server" Text="執行查詢" Visible="False" 
                        onclick="Button_Search_Click" />
                <asp:Button ID="Button_Caculate" runat="server" Text="計算" OnClick="Button_Caculate_Click" />
                    <asp:Button ID="btnShowDetailFinish" runat="server" Text="儲存" onclick="btnShowDetailFinish_Click"
                        Visible="False" />
                <asp:Button ID="btnReset" runat="server" Text="重置" onclick="btnReset_Click" />
                 
                    </td>
            </tr>
        </table>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="Grid"
            EnableModelValidation="True" Width="100%">
       <RowStyle CssClass="Row" />
       <AlternatingRowStyle CssClass="AlternatingRow" />
       <Columns>
            <asp:TemplateField HeaderText="選取">
                <ItemTemplate>
                    <asp:CheckBox ID="ch" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
                <asp:BoundField DataField="Base_idno" HeaderText="員工身分證號" />
                <asp:BoundField DataField="base_name" HeaderText="姓名" />
                <asp:BoundField DataField="base_dcode_name" HeaderText="職稱" />
                <asp:BoundField DataField="org_l1_name" HeaderText="職等" />
       </Columns>
    </asp:GridView>

        <!--
</ContentTemplate>
</asp:UpdatePanel>
-->
</asp:Content>
