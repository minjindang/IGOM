<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL3101_01.aspx.cs" Inherits="SAL_SAL3_SAL3101_01" %>

<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/SAL/ucDateTextBox.ascx" TagName="ucDateTextBox"
    TagPrefix="uc3" %>
<%@ Register Src="../../UControl/SAL/ucSaSpesup.ascx" TagName="ucSaSpesup" TagPrefix="uc5" %>
<%@ Register Src="../../UControl/SAL/ucSaBase_Kdo.ascx" TagName="ucSaBase_Kdo" TagPrefix="uc8" %>
<%@ Register Src="../../UControl/SAL/ucSaProj.ascx" TagName="ucSaProj" TagPrefix="uc4" %>
<%@ Register Src="../../UControl/UcDDLDepart.ascx" TagName="UcDDLDepart" TagPrefix="uc6" %>
<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc7" %>
<%@ Register Src="../../UControl/SAL/ucSaStws.ascx" TagName="ucSaStws" TagPrefix="uc9" %>
<%@ Register Src="../../UControl/SAL/ucSaBase_Bank.ascx" TagName="ucSaBase_Bank"
    TagPrefix="uc10" %>
<%@ Register src="../../UControl/SAL/ucSaBase_Other_Sal.ascx" tagname="ucSaBase_Other_Sal" tagprefix="uc11" %>
<%@ Register Src="../../UControl/UcDDLDepart.ascx" TagName="UcDDLDepart" TagPrefix="uc8" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc2" TagName="UcDDLMember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        function IsFloatText() {
            var charkc = window.event.keyCode
            if (charkc == 46 || (charkc >= 48 && charkc <= 57)) {
                return true;
            }
            return false;
        }

        function checkword(str) {
            return str.match(/^[0-9a-zA-Z]*$/);
        }
        </script>


    <asp:Panel ID="pndConditions" runat="server">

    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">
                員工薪資基本資料維護
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" width="15%">
                <!--職類-->
                員工類別
            </td>
            <td class="htmltable_Right">
                <uc2:ucSaCode ID="ddl_emp_type" runat="server" Code_sys="002" Code_type="017" Code_Kind="P"
                    ControlType="2" Mode="query" />
            </td>
            <td class="htmltable_Left" >單位名稱
            </td>
            <td class="htmltable_Right" colspan="3">
                <uc8:UcDDLDepart ID="cmbDepartID" runat="server" />               
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" width="15%">
                在職狀態
            </td>
            <td class="htmltable_Right" width="35%">
                <asp:DropDownList ID="DropDownList_base_edate" runat="server">
                    <asp:ListItem Value="0" Text="全部"></asp:ListItem>
                    <asp:ListItem Value="1" Text="在職" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="2" Text="已離職"></asp:ListItem>
                    <asp:ListItem Value="3" Text="已退休"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="htmltable_Left" width="15%">
                依人名或員工編號
            </td>
            <td width="35%">
                <asp:TextBox ID="TextBox_Search_str" runat="server"></asp:TextBox>
                <uc2:UcDDLMember runat="server" ID="ddlName" />
            </td>
        </tr>      
        <tr>
            <td class="htmltable_Bottom" colspan="4">
                <asp:Button ID="Button_Search" runat="server" OnClick="Button_Search_Click" 
                    Text="查詢員工" />
                <asp:Button ID="Button_Sort" runat="server" onclick="Button_Sort_Click" 
                    Text="列印順序設定" />
                <!--
            <asp:Button ID="Button_New" runat="server" Text="新增員工資料" />
            
            <asp:Button ID="Button_Import" runat="server" Text="自p2k帶入人事資料" />
            <asp:Button ID="Button_ImportRetire" runat="server" Text="匯入退休人員資料" />-->
            </td>
        </tr>
    </table>
    </asp:Panel>
    <!-- -->
    <asp:Panel ID="pnlQueryResult" runat="server" Visible="false">
        <table class="tableStyle99" width="100%">
        <tr><td class="htmltable_Title2">查詢結果</td></tr>
        <tr><td>
        <asp:GridView ID="GridView_SaBase" runat="server" AutoGenerateColumns="False" AllowPaging="True"
            BorderWidth="0px" 
            Width="100%" CssClass="Grid" EnableModelValidation="True" PageSize="30" OnRowCommand="GridView_SaBase_RowCommand"
            OnSelectedIndexChanged="GridView_SaBase_SelectedIndexChanged" 
                DataKeyNames="BASE_SEQNO" 
                onpageindexchanging="GridView_SaBase_PageIndexChanging" 
                onselectedindexchanging="GridView_SaBase_SelectedIndexChanging">
            <EmptyDataTemplate>
                查無人員資料
            </EmptyDataTemplate>
            <Columns>
                <asp:TemplateField HeaderText="員工編號">
                    <ItemTemplate>        
                                 <asp:Label ID="lbseqno" runat="server" Text='<%# Eval("Base_seqno") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="員工姓名">
                    <ItemTemplate>              
                               <asp:Label ID="lbname" runat="server" Text='<%# Eval("Base_name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="人員分類">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("job_name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="職稱">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("base_dcode_name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="官等">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("org_l3_name") %>' Style='<%# FStyle(Eval("org_l3_name")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="職等">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("org_l1_name") %>' Style='<%# FStyle(Eval("org_l1_name")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="俸階">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("org_l2_name") %>' Style='<%# FStyle(Eval("org_l2_name")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="在職狀態">                    
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# GetStatus( Eval("base_retire") , Eval("base_edate")) %>'></asp:Label>
                    </ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="維護">
                    <ItemTemplate>
                        <asp:Button ID="btnModify" runat="server" Text="修改"  CommandArgument='<%# Eval("BASE_SEQNO") %>'
                                        CommandName="doUpdate" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle HorizontalAlign="Right" />
            <RowStyle CssClass="Row" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
            
        </asp:GridView>
        </td></tr>
        <tr><td align="right">
            <uc1:Ucpager ID="Ucpager2" runat="server" GridName="GridView_SaBase" 
                PSize="30" />
            </td></tr>
        </table>
    </asp:Panel>
    <!--------------------------------------------------------------------------------------------------------------------------------------------------->
    <asp:Panel ID="pnlModify" runat="server" Visible="false">
        <!-- Part I -->
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4" style="text-align: center; vertical-align: middle">
                    修改員工基本資料<asp:Label ID="Label_Title" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" width="15%">
                    員工姓名
                </td>
                <td class="htmltable_Right" width="35%">
                    <asp:TextBox ID="edit_base_name" runat="server" Width="105"></asp:TextBox>
                </td>
                <td class="htmltable_Left" width="15%">
                    身分證號
                </td>
                <td class="htmltable_Right" width="35%">
                    <asp:TextBox ID="edit_base_idno" runat="server" Width="105" MaxLength="10"></asp:TextBox>
                    <br />
                    <asp:CheckBox ID="edit_base_ermk" Text=" 錯誤註記" runat="server" Visible="false" />
                </td>
            </tr>
            <div id="show002_1" runat="server">
                <tr>
                    <%--    <td class="htmltable_Left">所屬機關</td>
            <td class="htmltable_Right">
                <asp:Label ID="Label_base_orgid" runat="server" Text=""></asp:Label>
            </td>--%>
                    <td class="htmltable_Left">
                        人員分類
                    </td>
                    <td class="htmltable_Right">
                        <uc2:ucSaCode ID="edit_base_prono" runat="server" Code_sys="002" Code_type="017"
                            Code_Kind="P" ControlType="2" Mode="edit" />
                        <asp:Label ID="lb_edit_base_prono" runat="server" Text="" Visible="False"></asp:Label>
                    </td>
                    <td class="htmltable_Left">
                        兼職人員
                    </td>
                    <td class="htmltable_Right">
                        <asp:RadioButtonList ID="edit_base_parttime" runat="server" RepeatDirection="Horizontal"
                            AutoPostBack="true" OnSelectedIndexChanged="edit_base_parttime_SelectedIndexChanged">
                            <asp:ListItem Value="Y"> 是 || </asp:ListItem>
                            <asp:ListItem Value="N" Selected="True"> 否 </asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        現職員工
                    </td>
                    <td class="htmltable_Right">
                        <asp:RadioButtonList ID="edit_base_status" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="Y" Selected="True"> 是 || </asp:ListItem>
                            <asp:ListItem Value="N"> 否 </asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="htmltable_Left">
                        性別
                    </td>
                    <td class="htmltable_Right">
                        <asp:RadioButtonList ID="edit_base_sex" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="M" Selected="True"> 男 || </asp:ListItem>
                            <asp:ListItem Value="F"> 女 </asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        科室
                    </td>
                    <td class="htmltable_Right" >
                        <uc6:UcDDLDepart ID="ddl_Depart4Edit" runat="server" />
                    </td>
                    <td class="htmltable_Left">
                    預算來源
                    </td>
                    <td class="htmltable_Right">                     
                        <uc2:ucSaCode ID="ddl_Budget_code" runat="server" Code_Kind="P" Code_sys="002" Code_type="018"
                            ControlType="2" Mode="edit" />
                        <asp:Label ID="lb_Budget_code" runat="server" Text="" Visible="False"></asp:Label>                     
                    </td>
                    <!--<td class="htmltable_Left">
                    <asp:Label runat="server" ID="lbl" Text="簡任非主管"></asp:Label>
                </td>
                <td class="htmltable_Right">
                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal"
                        AutoPostBack="True" 
                        onselectedindexchanged="RadioButtonList3_SelectedIndexChanged">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="2" Selected="True">否</asp:ListItem>
                    </asp:RadioButtonList>
                    <div runat="server" id="divshowDate" visible="false">
                        
                        <uc7:UcDate ID="UcDateTextBox1" runat="server" />
                    </div>
                </td>-->
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        到職日期
                    </td>
                    <td class="htmltable_Right">
                        <uc7:UcDate ID="edit_base_bdate" runat="server" />
                    </td>
                    <td class="htmltable_Left">
                        離職日期
                    </td>
                    <td class="htmltable_Right">
                        <uc7:UcDate ID="edit_base_edate" runat="server" />
                    </td>
                </tr>
                <div id="show007_1" runat="server">
                    <tr id="div_show_projdate" visible="false" runat="server">
                        <td class="htmltable_Left">
                            工作計畫日期起迄(不使用)
                        </td>
                        <td class="htmltable_Right" colspan="3">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <uc7:UcDate ID="edit_base_proj_bdate" runat="server" />
                                    </td>
                                    <td>
                                        &nbsp; &nbsp;～&nbsp; &nbsp;
                                    </td>
                                    <td>
                                        <uc7:UcDate ID="edit_base_proj_edate" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            停職日期
                        </td>
                        <td class="htmltable_Right">
                            <uc7:UcDate ID="edit_base_quit_date" runat="server" />
                        </td>
                        <td class="htmltable_Left">
                            停職給薪狀態
                        </td>
                        <td class="htmltable_Right">
                            <uc2:ucSaCode ID="edit_base_quit_rezn" runat="server" Mode="edit" Code_sys="002"
                                Code_type="004" ControlType="2" />
                            <asp:Label ID="lb_edit_base_quit_rezn" runat="server" Text="" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            職業類別
                        </td>
                        <td class="htmltable_Right">
                            <uc2:ucSaCode ID="edit_base_dcodesys" runat="server" Code_sys="002" Code_type="001"
                                Code_Kind="P" ControlType="2" Mode="edit" />
                            <asp:Label ID="lb_edit_base_dcodesys" runat="server" Text="" Visible="False"></asp:Label>
                        </td>
                        <td class="htmltable_Left" style="height: 21px">
                            職稱
                        </td>
                        <td class="htmltable_Right" style="height: 21px">
                            <asp:TextBox ID="edit_base_dcode_name" runat="server" Text="" Visible="false"></asp:TextBox>
                            <uc7:UcDate ID="edit_base_job_date" runat="server" Visible="false" />
                            <uc2:ucSaCode ID="edit_base_dcode" runat="server" Mode="edit" Code_sys="002" Code_type="002"
                                ControlType="2" Code_Kind="P" />
                            <asp:Label ID="lb_edit_base_dcode" runat="server" Text="" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            官等
                        </td>
                        <td class="htmltable_Right">
                            <asp:UpdatePanel ID="UpdatePanel_org_l3" runat="server" ChildrenAsTriggers="false"
                                UpdateMode="Conditional">
                                <ContentTemplate>
                                    <uc2:ucSaCode ID="edit_base_org_l3" runat="server" Mode="edit" Code_sys="002" Code_type="003"
                                        ControlType="2" Code_Kind="P" ReturnEvent="true" />
                                    <asp:Label ID="lb_edit_base_org_l3" runat="server" Text="" Visible="False"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="edit_base_org_l3" EventName="CodeChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td class="htmltable_Left">
                            職等
                        </td>
                        <td class="htmltable_Right">
                            <asp:UpdatePanel ID="UpdatePanel_org_l1" runat="server" ChildrenAsTriggers="false"
                                UpdateMode="Conditional">
                                <ContentTemplate>
                                    <uc2:ucSaCode ID="edit_base_org_l1" runat="server" Mode="edit" Code_sys="002" Code_type="006"
                                        ControlType="2" Code_Kind="P" ReturnEvent="true" />
                                    <asp:Label ID="lb_edit_base_org_l1" runat="server" Text="" Visible="False"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="edit_base_org_l3" EventName="CodeChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="edit_base_org_l1" EventName="CodeChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            權理職等
                        </td>
                        <td class="htmltable_Right">
                            <asp:UpdatePanel ID="UpdatePanel_in_l1" runat="server" ChildrenAsTriggers="false"
                                UpdateMode="Conditional">
                                <ContentTemplate>
                                    <uc2:ucSaCode ID="edit_base_in_l1" runat="server" Mode="edit" Code_sys="002" Code_type="006"
                                        ControlType="2" Code_Kind="P" Visible="true" ReturnEvent="true" />
                                    <asp:Label ID="lb_edit_base_in_l1" runat="server" Text="" Visible="False"></asp:Label>
                                    <uc2:ucSaCode ID="edit_base_in_l3" runat="server" Mode="edit" Code_sys="002" Code_type="009"
                                        ControlType="2" Code_Kind="P" Visible="true" />
                                    <asp:Label ID="lb_edit_base_in_l3" runat="server" Text="" Visible="False"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="edit_base_org_l3" EventName="CodeChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="edit_base_org_l1" EventName="CodeChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td class="htmltable_Left">
                            年功奉
                        </td>
                        <td class="htmltable_Right">
                            <asp:UpdatePanel ID="UpdatePanel_org_l2" runat="server" ChildrenAsTriggers="false"
                                UpdateMode="Conditional">
                                <ContentTemplate>
                                    <uc2:ucSaCode ID="edit_base_org_l2" runat="server" Mode="edit" Code_sys="002" Code_type="009"
                                        ControlType="2" Code_Kind="P" ReturnEvent="true" />
                                    <asp:Label ID="lb_edit_base_org_l2" runat="server" Text="" Visible="False"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="edit_base_org_l3" EventName="CodeChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="edit_base_org_l1" EventName="CodeChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="edit_base_org_l2" EventName="CodeChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </div>
                <div runat="server" id="show007_2">
                    <div runat="server" id="div_showKDB">
                        <tr>
                            <td class="htmltable_Left">
                                適用俸（薪）表
                            </td>
                            <td class="htmltable_Right">
                                <asp:UpdatePanel ID="UpdatePanel_kdb" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <uc2:ucSaCode ID="edit_base_kdb" runat="server" Code_sys="001" Code_type="001" Mode="edit"
                                            ControlType="2" Code_Kind="P" />
                                        <asp:Label ID="lb_edit_base_kdb" runat="server" Text="" Visible="False"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="edit_base_kdb" EventName="CodeChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td class="htmltable_Left">
                                俸點(薪點)
                            </td>
                            <td class="htmltable_Right">
                                <asp:UpdatePanel ID="UpdatePanel_ptb" runat="server" ChildrenAsTriggers="false" UpdateMode="conditional">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="edit_base_ptb_type" runat="server" RepeatDirection="Horizontal"
                                            AutoPostBack="True" OnSelectedIndexChanged="edit_base_ptb_type_SelectedIndexChanged">
                                            <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                                            <asp:ListItem Value="2">否</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <div id="div_ptb_1" runat="server">
                                            <asp:TextBox ID="edit_base_ptb" runat="server" Width="56"  onkeypress="return IsFloatText();">0</asp:TextBox>點
                                        </div>
                                        <div id="div_ptb_2" runat="server" visible="false">
                                            <asp:TextBox ID="edit_base_alt_amt" runat="server" Width="56"  onkeypress="return IsFloatText();">0</asp:TextBox>元
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="edit_base_ptb_type" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="edit_base_kdb" EventName="CodeChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="edit_base_org_l3" EventName="CodeChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="edit_base_org_l1" EventName="CodeChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="edit_base_org_l2" EventName="CodeChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </div>
                </div>
                <div runat="server" id="show007_3">
                    <div runat="server" id="div_showKDP">
                        <tr>
                            <td class="htmltable_Left">
                                <asp:Label runat="server" Text="專業加給" ID="lblbase_kdpTitle"></asp:Label>
                            </td>
                            <td colspan="3" class="htmltable_Right">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel_kdp" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <uc2:ucSaCode ID="edit_base_kdp" runat="server" Mode="edit" Code_sys="001" Code_type="003"
                                                        ReturnEvent="true" ControlType="2" Code_Kind="P"/>
                                                    <asp:Label ID="lb_edit_base_kdp" runat="server" Text="" Visible="False"></asp:Label>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="edit_base_kdp" EventName="CodeChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="edit_base_org_l3" EventName="CodeChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="edit_base_org_l1" EventName="CodeChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="edit_base_in_l1" EventName="CodeChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel_kdp_1" runat="server" ChildrenAsTriggers="false"
                                                UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div id="div_kdp" runat="server" visible="false">
                                                        &nbsp;加給金額
                                                        <uc5:ucSaSpesup ID="edit_base_kdp_series" runat="server" v_KdcKdp="KDP" v_Type="003" />
                                                        <asp:Label ID="lb_edit_base_kdp_series" runat="server" Visible="False"></asp:Label>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="edit_base_kdp" EventName="CodeChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="edit_base_org_l3" EventName="CodeChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="edit_base_org_l1" EventName="CodeChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="edit_base_in_l1" EventName="CodeChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </div>
                    <div runat="server" id="div_showKDC">
                        <tr>
                            <td class="htmltable_Left">
                                主管加給
                            </td>
                            <td colspan="3" class="htmltable_Right">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel_kdc" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <uc2:ucSaCode ID="edit_base_kdc" runat="server" Mode="edit" Code_sys="001" Code_type="004"
                                                        ReturnEvent="true" ControlType="2" Code_Kind="P"/>
                                                    <asp:Label ID="lb_edit_base_kdc" runat="server" Text="" Visible="False"></asp:Label>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="edit_base_kdc" EventName="CodeChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="edit_base_org_l3" EventName="CodeChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="edit_base_org_l1" EventName="CodeChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="edit_base_in_l1" EventName="CodeChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td colspan="2">
                                            <asp:UpdatePanel ID="UpdatePanel_kdc_2" runat="server" ChildrenAsTriggers="false"
                                                UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div id="div_kdc" runat="server" visible="false">
                                                        &nbsp;加給金額
                                                        <uc5:ucSaSpesup ID="edit_base_kdc_series" runat="server" v_KdcKdp="KDC" v_Type="004" />
                                                        <asp:Label ID="lb_edit_base_kdc_series" runat="server" Visible="False"></asp:Label>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="edit_base_kdc" EventName="CodeChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="edit_base_org_l3" EventName="CodeChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="edit_base_org_l1" EventName="CodeChanged" />
                                                    <asp:AsyncPostBackTrigger ControlID="edit_base_in_l1" EventName="CodeChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </div>
                    <tr>
                        <td class="htmltable_Left">
                            其他專業加給
                        </td>
                        <td colspan="3" class="htmltable_Right">
                            <asp:UpdatePanel ID="UpdatePanel_kdo" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:RadioButtonList ID="edit_base_kdo" runat="server" RepeatDirection="Horizontal"
                                        AutoPostBack="True" 
                                        onselectedindexchanged="edit_base_kdo_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="Y">有</asp:ListItem>
                                        <asp:ListItem Value="N">無</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <div id="div_kdo" runat="server" visible="false">
                                        <uc8:ucSaBase_Kdo ID="UcSaBase_Kdo_1" runat="server" />
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="edit_base_kdo" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </div>
                <!--沒用了-->
                <div runat="server" id="show007_4" visible="false">
                    <tr>
                        <td class="htmltable_Left">
                            契約類型
                        </td>
                        <td class="htmltable_Right" colspan="3">
                            <uc2:ucSaCode ID="UcSaCode2" runat="server" Mode="edit" Code_sys="002" Code_type="016"
                                ControlType="2" Code_Kind="P" />
                            <asp:Label ID="lb_UcSaCode2" runat="server" Text="" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            學歷
                        </td>
                        <td class="htmltable_Right">
                            <uc2:ucSaCode ID="UcSaCode3" runat="server" Mode="edit" Code_sys="002" Code_type="011"
                                ControlType="2" Code_Kind="P" />
                            <asp:Label ID="lb_UcSaCode3" runat="server" Text="" Visible="False"></asp:Label>
                        </td>
                        <td class="htmltable_Left">
                            學校名稱
                        </td>
                        <td class="htmltable_Right">
                            <asp:TextBox runat="server" ID="txtSchool"></asp:TextBox>
                        </td>
                    </tr>
                </div>
            </div>
            <!--<tr>
            <td class="htmltable_Left">
                連絡電話
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="edit_base_tel" runat="server" Width="200" Text="0"></asp:TextBox>
            </td>
            <td class="htmltable_Left">
                院內分機
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="edit_base_telno" runat="server" Width="24" Text="0"></asp:TextBox>
            </td>
        </tr>-->
            <tr>
                <td class="htmltable_Left">
                    戶籍地址
                </td>
                <td colspan="3" class="htmltable_Right">
                    <asp:TextBox ID="edit_base_addr" runat="server" Width="400" MaxLength="60"></asp:TextBox>
                </td>
            </tr>
            <!--
        <tr>
            <td class="htmltable_Left">
                聯絡地址
            </td>
            <td colspan="3" class="htmltable_Right">
                <asp:TextBox ID="edit_base_addr2" runat="server" Width="400"></asp:TextBox>
            </td>
        </tr>
        -->
            <tr>
                <td class="htmltable_Left">
                    E-Mail
                </td>
                <td colspan="3" class="htmltable_Right">
               <!--     <asp:TextBox ID="edit_base_email" runat="server" Width="300" MaxLength="100"></asp:TextBox>  -->
                    <asp:Label ID="base_email" runat="server" Text=""></asp:Label>
                    <asp:CheckBox ID="edit_base_sentmail" runat="server" Checked="true" Visible="false"
                        Text=" 以e-mail寄發薪水條" />
 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="edit_base_email"
                            ErrorMessage="輸入的電子郵件有誤!" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*|[1]"></asp:RegularExpressionValidator>  
                    <%--      <asp:CheckBox ID="edit_base_sentmsg" runat="server" Text=" 以e公務寄發薪水條" />--%>
                </td>
            </tr>
            <!-- 沒用 -->
            <div runat="server" id="DivshowCar" visible="false">
                <tr>
                    <td class="htmltable_Left">
                        車號
                    </td>
                    <td class="htmltable_Right">
                        <asp:TextBox ID="edit_base_carno" runat="server"></asp:TextBox>
                    </td>
                    <td class="htmltable_Left">
                        車輛使用人
                    </td>
                    <td class="htmltable_Right">
                        <asp:TextBox ID="edit_base_bossname" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </div>
        </table>
        <!---------------------------------------------------------------------------------------------------------------------------->
        <div id="table003" runat="server" width="100%">
            <table class="tableStyle99" width="100%">
                <tr>
                    <td class="htmltable_Title" align="center" colspan="4 ">
                        《薪資設定》
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="htmltable_Left">
                        政務官離職儲金
                    </td>
                    <td colspan="3" class="htmltable_Right">
                        <asp:CheckBox ID="edit_base_govadof" runat="server" Text=" 適用政務官離職儲金" Visible="false" />
                        <asp:RadioButtonList ID="r_base_govadof" runat="server" RepeatDirection="Horizontal"
                            AutoPostBack="true">
                            <asp:ListItem Value="Y"> 是 || </asp:ListItem>
                            <asp:ListItem Value="N" Selected="True"> 否 </asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        退休喪亡互助金
                    </td>
                    <td class="htmltable_Right" colspan="3">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                            AutoPostBack="true">
                            <asp:ListItem Value="Y"> 是 || </asp:ListItem>
                            <asp:ListItem Value="N" Selected="True"> 否 </asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <%--  <td  class="htmltable_Left" align="center">其他褔利互助金</td>
            <td colspan="3"  class="htmltable_Right">
                <uc2:ucSaCode ID="edit_base_welo" runat="server" Mode="edit"
                    Code_sys="001" Code_type="002" />
            </td>--%>
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        年終獎金
                    </td>
                    <td class="htmltable_Right" colspan="3">
                        <asp:DropDownList ID="edit_base_priz" runat="server">
                            <asp:ListItem Value="Y">全年</asp:ListItem>
                            <asp:ListItem Value="N">-無-</asp:ListItem>
                            <asp:ListItem Value="T">依實際在職月份</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="display: none">
                    <td class="htmltable_Left" width="15%">
                        退撫離職
                    </td>
                    <td class="htmltable_Right" width="35%">
                        <asp:TextBox ID="edit_base_pre" runat="server">0</asp:TextBox>
                    </td>
                    <td class="htmltable_Left" width="15%">
                        機關負擔
                    </td>
                    <td class="htmltable_Right" width="35%">
                        <asp:TextBox ID="edit_base_pred" runat="server">0</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        其他薪金項目勾選
                    </td>
                    <td class="htmltable_Right" colspan="3">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:CheckBox ID="edit_base_pol" Text=" 警務津貼" runat="server" />
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel_hous" runat="server" ChildrenAsTriggers="False"
                                        UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <!--<asp:CheckBox ID="edit_base_hous_YN" Text=" 房屋津貼" runat="server" AutoPostBack="true"
                                                            OnCheckedChanged="edit_base_hous_YN_CheckedChanged" />-->
                                                         房屋津貼
                                                         <asp:DropDownList ID="cmb_base_hous" runat="server">
                                                            <asp:ListItem Value="0">無</asp:ListItem>
                                                            <asp:ListItem Value="1">700</asp:ListItem>
                                                            <asp:ListItem Value="2">600</asp:ListItem>
                                                            <asp:ListItem Value="3">500</asp:ListItem>
                                                            <asp:ListItem Value="4">400</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <!--<td>
                                                        <div id="div_hous" runat="server" visible="false">
                                                            <uc2:ucSaCode ID="edit_base_hous" runat="server" Code_sys="006" Code_type="004" Code_Kind="P"
                                                                ControlType="2" Mode="query" />
                                                        </div>
                                                    </td>-->
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="edit_base_hous_YN" EventName="CheckedChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:CheckBox ID="edit_base_welg" Text=" 退休喪亡互助金 " runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        所得稅扣繳
                    </td>
                    <td class="htmltable_Right" colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel_tax" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="edit_base_tax" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="True" OnSelectedIndexChanged="edit_base_tax_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="無"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="照表扣繳" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="定額扣繳"></asp:ListItem>
                                    <asp:ListItem Value="5" Text="5%扣繳"></asp:ListItem>
                                </asp:RadioButtonList>
                                <div id="div_tax_1" runat="server" visible="false">
                                    定額扣繳額
                                    <asp:TextBox ID="edit_base_tax_dct" runat="server" Width="60">0</asp:TextBox>
                                </div>
                                <div id="div_tax_2" runat="server" visible="false">
                                    <asp:TextBox ID="edit_base_numerator" runat="server" Width="30" MaxLength="3" Text="1"></asp:TextBox>／
                                    <asp:TextBox ID="edit_base_denominator" runat="server" Width="30" MaxLength="3" Text="1"></asp:TextBox>
                                    (分子/分母)(完全中學適用)
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="edit_base_tax" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left" align="center">
                        其他應發代扣項目
                    </td>
                    <td colspan="3" class="htmltable_Right">
                        <asp:UpdatePanel ID="UpdatePanel_other" runat="server" ChildrenAsTriggers="False"
                            UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="edit_base_other_sal" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="True" 
                                    onselectedindexchanged="edit_base_other_sal_SelectedIndexChanged">
                                    <asp:ListItem Value="Y">有</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="N">無</asp:ListItem>
                                </asp:RadioButtonList>
                                <div id="div_other_sal" runat="server" visible="false">
                                    <uc11:ucSaBase_Other_Sal ID="ucSaBase_Other_Sal1" runat="server" />
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="edit_base_other_sal" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left" width="15%">
                        日薪
                    </td>
                    <td class="htmltable_Right" width="35%">
                        <asp:TextBox ID="edit_base_day_sal" runat="server" Width="100" onkeypress="return IsFloatText();">0</asp:TextBox>
                    </td>
                    <td class="htmltable_Left" width="15%">
                        時薪
                    </td>
                    <td class="htmltable_Right" width="35%">
                        <asp:TextBox ID="edit_base_hour_sal" runat="server" Width="100" onkeypress="return IsFloatText();">0</asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <!------------------------------------------------->
        <div id="table004" runat="server">
            <table class="tableStyle99" width="100%">
                <tr>
                    <td class="htmltable_Title" align="center" colspan="4">
                        《保險資料設定》
                    </td>
                </tr>
                <tr>
                    <td width="15%" class="htmltable_Left">
                        保險種類
                    </td>
                    <td class="htmltable_Right">
                        <asp:UpdatePanel ID="UpdatePanel_fins_1" runat="server"  ChildrenAsTriggers="False"
                            UpdateMode="Conditional">
                            <ContentTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <asp:RadioButtonList ID="edit_base_fins_kind" runat="server" RepeatColumns="4" RepeatLayout="Flow"
                                                RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="edit_base_fins_kind_SelectedIndexChanged">
                                                <asp:ListItem Value="001" Text=" 公保 " Selected="true"></asp:ListItem>                                         
                                                <asp:ListItem Value="002" Text=" 勞保 "></asp:ListItem>
                                                <asp:ListItem Value="003" Text=" 勞保(自訂) "></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr id="div_fins_series" runat="server" visible="false">
                                        <td>
                                            &nbsp; 勞保&nbsp;
                                            <uc9:ucSaStws ID="edit_base_labor_series" runat="server" v_No="001" />
                                        </td>
                                        <td>
                                            健保&nbsp;
                                            <uc9:ucSaStws ID="edit_base_fins_series" runat="server" v_No="002" />
                                        </td>
                                    </tr>
                                    <tr id="div_fins_y65" runat="server" visible="false">
                                        <td colspan="2">
                                            <asp:CheckBox ID="edit_base_lab_jif" Text=" 勞保年滿65歲 " ForeColor="red" runat="server" />
                                        </td>
                                    </tr>
                                    <tr id="div_labor_chk" runat="server" visible="false">
                                        <td colspan="2">
                                            <asp:CheckBox ID="edit_base_lab1" Text="普通事故" runat="server" />
                                            <asp:CheckBox ID="edit_base_lab2" Text="就業保險" runat="server" />
                                            <asp:CheckBox ID="edit_base_lab3" Text="職業災害" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="edit_base_fins_kind" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="edit_base_pen_type" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td class="htmltable_Left">
                        公保年資
                    </td>
                    <td class="htmltable_Right">
                        <asp:UpdatePanel ID="UpdatePanel_fins_2" runat="server" ChildrenAsTriggers="false"
                            UpdateMode="conditional">
                            <ContentTemplate>
                                <asp:CheckBox ID="edit_base_pn_y30" runat="server" />
                                公保年滿30年
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="edit_base_fins_kind" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="edit_base_pen_type" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr id="fins_kind" runat="server" visible ="true" >
                    <td class="htmltable_Left">
                        勞工退休金
                    </td>
                    <td class="htmltable_Right" id="pen_type">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="conditional">
                            <ContentTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left">
                                            <div id="div_pen_tpye" runat="server" visible="false">
                                                <asp:RadioButtonList ID="edit_base_pen_type" runat="server" RepeatDirection="Horizontal"
                                                    AutoPostBack="true" OnSelectedIndexChanged="edit_base_pen_type_SelectedIndexChanged">
                                                    <asp:ListItem Value="0" Text="無" Selected="true"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="舊制"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="新制"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </td>
                                        <td style="width: 40%">
                                            <div id="div_pen_series" runat="server" visible ="false">
                                                <uc9:ucSaStws ID="edit_base_pen_series" runat="server" v_No="005" v_Mode="" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="edit_base_fins_kind" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="edit_base_pen_type" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td class="htmltable_Left">
                        勞工退休金<br />
                        自行提繳率
                    </td>
                    <td class="htmltable_Right" id="pen_rate">
                        <asp:UpdatePanel ID="UpdatePanel_fins_4" runat="server" ChildrenAsTriggers="false"
                            UpdateMode="conditional">
                            <ContentTemplate>
                                <div id="div_pen_rate" runat="server" visible="false" >
                                    <asp:TextBox ID="edit_base_pen_rate" Text="0" runat="server" Width="30" MaxLength="3"></asp:TextBox>％
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="edit_base_fins_kind" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="edit_base_pen_type" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
               <!-- <tr>
                    <td class="htmltable_Left" width="15%">
                        試算勞工<br>
                        平均月退金額 
                    </td>
                    <td class="htmltable_Right" width="35%">
                        預定退休日
                        <uc7:UcDate ID="UcDateTextBox_RetireDate" runat="server" />
                        前六個月不休假加班費總計<asp:TextBox ID="txtUnrestAmt" runat="server" onkeypress="return IsFloatText();"></asp:TextBox>
                        <asp:Button ID="btnCalcRetire" runat="server" OnClick="btnCalcRetire_Click" 
                            Text="計算" />
                    </td>
                    <td class="htmltable_Left" width="15%">
                        勞工平均月退金額
                    </td>
                    <td class="htmltable_Right" width="35%">
                        <asp:Label runat="server" ID="lblRetireAmt" Text=""></asp:Label>
                    </td>
                </tr>   -->
                <tr>
                    <td class="htmltable_Left">
                        扶養人數
                    </td>
                    <td class="htmltable_Right">
                        <asp:TextBox ID="edit_base_prov" runat="server" Width="24" Text="0"  onkeypress="return IsFloatText();"></asp:TextBox>
                        人
                    </td>
                    <td class="htmltable_Left">
                       公勞保自付註記
                    </td>
                    <td class="htmltable_Right">
                        <asp:RadioButtonList ID="edit_base_fins_self" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1.00" Text=" 全額 " Selected="True"></asp:ListItem>
                            <asp:ListItem Value="0.75" Text=" 3/4 "></asp:ListItem>
                            <asp:ListItem Value="0.50" Text=" 1/2 "></asp:ListItem>
                            <asp:ListItem Value="0.00" Text=" 全免 "></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:TextBox ID="edt_BASE_FINS_SELF_DESC" runat="server" MaxLength="100" TextMode="MultiLine"
                            Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left" align="center">
                        眷口健保口數<br />
                        (不包含本人)
                    </td>
                    <td class="htmltable_Right" colspan="3">
                        ●健保自付3/4口數(輕殘/菸捐) &nbsp;
                        <asp:TextBox ID="edit_base_fins_noq" runat="server" Width="30" Text="0" onkeypress="return IsFloatText();"></asp:TextBox>
                        人&nbsp; ●健保自付1/2口數(中殘/菸捐) &nbsp;
                        <asp:TextBox ID="edit_base_fins_noh" runat="server" Width="30" Text="0" onkeypress="return IsFloatText();"></asp:TextBox>
                        人&nbsp;<br />
                        ●健保免繳口數(重殘及低收入戶)
                        <asp:TextBox ID="edit_base_fins_nof" runat="server" Width="30" Text="0" onkeypress="return IsFloatText();"></asp:TextBox>
                        人&nbsp; ●健保地方補助口數(65歲以上長者)
                        <asp:TextBox ID="edit_base_fins_nol" runat="server" Width="30" Text="0" onkeypress="return IsFloatText();"></asp:TextBox>
                        人&nbsp;<br />
                        ●健保自付3/4且是地方補助<u>雙重身份</u>口數(輕殘/菸捐+65歲以上長者)
                        <asp:TextBox ID="edit_base_fins_noq_nol" runat="server" Width="30" Text="0" onkeypress="return IsFloatText();"></asp:TextBox>
                        人&nbsp;<br />
                        ●健保自付1/2且是地方補助<u>雙重身份</u>口數(中殘/菸捐+65歲以上長者)
                        <asp:TextBox ID="edit_base_fins_noh_nol" runat="server" Width="30" Text="0" onkeypress="return IsFloatText();"></asp:TextBox>
                        人&nbsp;<br />
                        ●<em>健保眷口總人數</em>
                        <asp:TextBox ID="edit_base_fins_no" runat="server" Width="30" Text="0" onkeypress="return IsFloatText();"></asp:TextBox>
                        <em>人</em><br />
                        <asp:TextBox ID="txt_BASE_FINS_PAR_DESC" runat="server" Width="100%" MaxLength="100"
                            TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left" align="center">
                        健保自付註記
                    </td>
                    <td class="htmltable_Right" colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="edit_base_fins_health_self" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1.00" Text=" 全額 " Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="0.75" Text=" 3/4 "></asp:ListItem>
                                    <asp:ListItem Value="0.50" Text=" 1/2 "></asp:ListItem>
                                    <asp:ListItem Value="0.00" Text=" 全免 "></asp:ListItem>
                                    <asp:ListItem Value="-1.00" Text=" 不保健保 "></asp:ListItem>
                                </asp:RadioButtonList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="edit_base_parttime" EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="edit_base_fins_health_self" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:RadioButtonList ID="edit_base_fins_y65" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0.00" Text=" 非55歲原住民 " Selected="True"></asp:ListItem>
                            <asp:ListItem Value="1.00" Text=" 55歲原住民 "></asp:ListItem>
                        </asp:RadioButtonList>
                           <asp:TextBox ID="BASE_HEALTH_SELF_DESC" runat="server" Width="100%" MaxLength="100"
                            TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
              
                <tr>
                    <td class="htmltable_Left" align="center" style="color: red;">
                        個人健保標準金額
                    </td>
                    <td class="htmltable_Right" colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:TextBox ID="edit_base_fin_amt" runat="server" Width="60" Text="0" onkeypress="return IsFloatText();"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="edit_base_parttime" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left" align="center" style="color: red;">
                        機關負擔健保金額
                    </td>
                    <td class="htmltable_Right" colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:TextBox ID="edit_base_fin_sup_amt"  onkeypress="return IsFloatText();" runat="server" Width="60" Text="0"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="edit_base_parttime" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
             <!--   <tr>
                    <td class="htmltable_Left" align="center">
                        實物代金眷口數
                    </td>
                    <td class="htmltable_Right" colspan="3">
                        ●大口
                        <asp:TextBox ID="edit_base_dct_a" runat="server" Width="30" Text="0" onkeypress="return IsFloatText();"></asp:TextBox>
                        人 &nbsp;&nbsp; ●中口
                        <asp:TextBox ID="edit_base_dct_b" runat="server" Width="30" Text="0" onkeypress="return IsFloatText();"></asp:TextBox>
                        人 &nbsp;&nbsp; ●小口
                        <asp:TextBox ID="edit_base_dct_c" runat="server" Width="30" Text="0" onkeypress="return IsFloatText();"></asp:TextBox>
                        人
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left" align="center">
                        個人實物代金註記
                    </td>
                    <td class="htmltable_Right" colspan="3">
                        <asp:RadioButtonList ID="edit_base_replace_amt" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0" Text=" 無 " Selected="true"></asp:ListItem>
                            <asp:ListItem Value="930" Text=" 有 "></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>  -->
            </table>
        </div>
        <!------------------------------------------------------->
        <div id="DivShowRetire" runat="server">
            <table class="tableStyle99" width="100%">
                <tr>
                    <td class="htmltable_Title" colspan="4 ">
                        《退休人員資訊》
                    </td>
                </tr>
                <!--
            <tr>
                <td class="htmltable_Left" width="15%">
                    是否退休
                </td>
                <td class="htmltable_Right" width="35%">
                    <asp:RadioButtonList ID="rblRetire" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="Y" Text=" 是 " Selected="true"></asp:ListItem>
                        <asp:ListItem Value="N" Text=" 否 "></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="htmltable_Left" width="15%">
                    是否可領取</br>三節慰問金
                </td>
                <td class="htmltable_Right" width="35%">
                    <asp:RadioButtonList ID="rblYearamt" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="Y" Text=" 是 " Selected="true"></asp:ListItem>
                        <asp:ListItem Value="N" Text=" 否 "></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    退撫種類
                </td>
                <td class="htmltable_Right" colspan="3">
                    <asp:RadioButtonList ID="rblRetireType" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="001" Text="月退休金" Selected="true"></asp:ListItem>
                        <asp:ListItem Value="002" Text="月撫慰金"></asp:ListItem>
                        <asp:ListItem Value="003" Text="月撫恤金"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    是否為遺族
                </td>
                <td class="htmltable_Right" colspan="3">
                    <asp:UpdatePanel runat="server" ID="PanelFamily" ChildrenAsTriggers="false" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:RadioButtonList ID="rblFamily" runat="server" RepeatDirection="Horizontal" 
                                AutoPostBack="true" onselectedindexchanged="rblFamily_SelectedIndexChanged">
                                <asp:ListItem Value="Y" Text=" 是 " Selected="true"></asp:ListItem>
                                <asp:ListItem Value="N" Text=" 否 "></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:Label runat="server" ID="lbOriScript" Text="原退休人員姓名:"></asp:Label>
                            <asp:Label runat="server" ID="lbOriName"></asp:Label>
                            <asp:Label runat="server" ID="lbOriIdno" Visible="false"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="rblFamily" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            
                <tr>
                    <td class="htmltable_Left">
                        其他帳戶
                    </td>
                    <td class="htmltable_Right" colspan="3">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel5" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <ContentTemplate>
                                銀行名稱：
                                <uc2:ucSaCode ID="UcSaCode_bank" runat="server" Code_sys="004" Code_type="002" Code_Kind="P"
                                    ControlType="2" Orgid='<%# Eval("BASE_ORGID")%>' CommandArgument='<%# Eval("BASE_SEQNO") %>' />
                                帳號：<asp:TextBox runat="server" ID="txtOtherAcc" Width="30%"> </asp:TextBox></td>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="UcSaCode_bank" />
                            </Triggers>
                        </asp:UpdatePanel>
                </tr>
                -->
            </table>
        </div>
        <!-------------------------------------------------------->
        <div id="table005" runat="server" width="100%">
            <table class="tableStyle99" width="100%">
                <tr>
                    <td class="htmltable_Title" align="center" colspan="4">
                        《銀行設定》
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <uc10:ucSaBase_Bank ID="ucSaBase_Bank_1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <!------------------------------------------------------------->
        <div id="table006" runat="server">
            <table class="tableStyle99" width="100%">
                <tr>
                    <td width="15%" class="htmltable_Left">
                        選擇備註欄
                    </td>
                    <td class="htmltable_Right" colspan="3">
                        <asp:DropDownList ID="edit_base_memo_sel" runat="server">
                            <asp:ListItem Value="1">備註一</asp:ListItem>
                            <asp:ListItem Value="2">備註二</asp:ListItem>
                            <asp:ListItem Value="3">備註三</asp:ListItem>
                        </asp:DropDownList>
                        <%-- (員工薪資單 - 字數限制25個中文字，薪津清冊 - 字數限制 7個中文字；列印身分證字號後為 2個中文字)--%>
                        <asp:TextBox ID="edit_base_memo" runat="server" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        備註一
                    </td>
                    <td class="htmltable_Right" colspan="3">
                        <asp:TextBox ID="edit_base_memo1" runat="server" Rows="3" TextMode="MultiLine" Width="400"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        備註二
                    </td>
                    <td class="htmltable_Right" colspan="3">
                        <asp:TextBox ID="edit_base_memo2" runat="server" Rows="3" TextMode="MultiLine" Width="400"></asp:TextBox>                         
                      <uc2:ucSaCode ID="UcSaCode1" runat="server" Code_sys="002" Code_type="020" Code_Kind="P"
                    ControlType="2" Mode="edit" />
                    </td>                   
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        備註三
                    </td>
                    <td class="htmltable_Right" colspan="3">
                        <asp:TextBox ID="edit_base_memo3" runat="server" Rows="3" TextMode="MultiLine" Width="400"></asp:TextBox>
                    </td>
                </tr>
              <!--  <tr>
                    <td class="htmltable_Left">
                        貸款總金額
                    </td>
                    <td class="htmltable_Right" colspan="3">
                        <asp:TextBox ID="txt_BASE_RAMT" runat="server" onkeypress="return IsFloatText();"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">
                        尚未清償金額
                    </td>
                    <td class="htmltable_Right">
                        <asp:TextBox ID="txt_BASE_NAMT" runat="server" onkeypress="return IsFloatText();"></asp:TextBox>
                    </td>
                    <td class="htmltable_Left">
                        每月清償金額
                    </td>
                    <td class="htmltable_Right">
                        <asp:TextBox ID="txt_BASE_MAMT" runat="server" onkeypress="return IsFloatText();"></asp:TextBox>
                    </td>
                </tr>  -->
            </table>
            <table class="tableStyle99" width="100%">
                <tr>
                    <td class="htmltable_Bottom">
                        <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" Text="儲存修改"
                            OnClick="UpdateButton_Click" />
                        <asp:Button ID="ButtonClose" runat="server" CausesValidation="False" Text="取消" 
                            onclick="ButtonClose_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <!-- Hidden -->
    <div id="info" style="display: none;">
        Orgid=<asp:TextBox ID="edit_base_orgid" runat="server"></asp:TextBox><br />
        Seqno=<asp:TextBox ID="edit_base_seqno" runat="server"></asp:TextBox><br />
        Fmode=<asp:TextBox ID="TextBox_Fmode" runat="server"></asp:TextBox><br />
        Act=<asp:TextBox ID="TextBox_Act" runat="server"></asp:TextBox><br />
        projdate=<asp:TextBox ID="TextBox_show_projdate" runat="server" Text=""></asp:TextBox><br />
        role=<asp:TextBox ID="TextBox_role" runat="server" Text=""></asp:TextBox><br />
        <asp:TextBox ID="txt_BASE_PRTS" runat="server"></asp:TextBox>
    </div>
</asp:Content>
