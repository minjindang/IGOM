<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="EMP3105_01.aspx.cs" Inherits="EMP_EMP3_EMP3105_01" %>

<%@ Register Src="../../UControl/SAL/UcSelectOrg.ascx" TagName="UcSelectOrg" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc3" %>
<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc4" %>
<%@ Register Src="../../UControl/SAL/ucSaProj.ascx" TagName="ucSaProj" TagPrefix="uc5" %>
<%@ Register Src="../../UControl/FSC/UcMember.ascx" TagName="UcMember" TagPrefix="uc6" %>
<%@ Register Src="../../UControl/UcOldMember.ascx" TagName="UcOldMember" TagPrefix="uc7" %>
<%@ Register Src="../../UControl/UcDDLDepart.ascx" TagName="UcDDLDepart" TagPrefix="uc8" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc2" TagName="UcDDLMember" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:Panel ID="pnlQueryEdit" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">人員資料設定
            </td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="4">查詢條件
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">單位名稱
            </td>
            <td class="htmltable_Right" style="width: 230px" colspan="3">
                <uc8:UcDDLDepart ID="cmbDepartID" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">人員姓名
            </td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="upnlUserName" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtUserName" runat="server" Width="100"></asp:TextBox>
                        <uc2:UcDDLMember runat="server" ID="ddlName" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="htmltable_Left" style="width: 120px">職務類別
            </td>
            <td class="htmltable_Right" style="width: 230px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <uc3:ucSaCode ID="ddlPememcodID" runat="server" Code_Kind="P" Code_sys="023" Code_type="022"
                            ControlType="2" Mode="query" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">員工編號
            </td>
            <td class="htmltable_Right" style="width: 230px">
                <uc6:UcMember ID="UcPersonal_id" runat="server" />
            </td>
            <td class="htmltable_Left" style="width: 120px">在職狀態
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddQuit_Job" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="N" Text="在職"></asp:ListItem>
                    <asp:ListItem Value="Y" Text="離職"></asp:ListItem>
                </asp:DropDownList>
                <asp:CheckBox ID="cbxQuit_job" runat="server" Text="含離職人員" Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">職稱
            </td>
            <td class="htmltable_Right" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <uc3:ucSaCode ID="ddlTitleNo" runat="server" Code_Kind="P" Code_sys="023" Code_type="012"
                            ControlType="2" Mode="query" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4">&nbsp;
                <asp:Button ID="btnFind" runat="server" CausesValidation="False" Text="查詢" OnClick="btnFind_Click" />
                <asp:Button ID="btnAdd" runat="server" Text="新增人員" CausesValidation="False" OnClick="btnAdd_Click" />
                <asp:Button ID="btnExport" runat="server" Text="匯出" Enabled="False" Visible="false" />
            </td>
        </tr>
    </table>
         </asp:Panel> 
    <asp:Panel ID="pnlEdit" runat="server" Visible="False">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
            <tr>
                <td class="htmltable_Title" colspan="5">
                    <asp:Label ID="lbTitle" runat="server" Text="人員資料"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" width="15%">
                    <span style="color: #ff0000">*</span>身分證號
                </td>
                <td class="htmltable_Right" width="35%">
                    <asp:TextBox ID="txtId_card" runat="server" MaxLength="10" Width="100px" AutoPostBack="true" OnTextChanged="txtId_card_TextChanged" ></asp:TextBox>
                    <asp:Button ID="cbQuery" runat="server" Text="查詢" CausesValidation="false" Visible="false" />
                </td>
                <td class="htmltable_Left" width="15%">
                    <span style="color: #ff0000">*</span>員工編號
                </td>
                <td class="htmltable_Right" width="35%">
                    <asp:TextBox ID="txtPersonnel_id" runat="server" MaxLength="10" Width="100px" Enabled="False"
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">
                    <span style="color: #ff0000">*</span>人員姓名
                </td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="txtUser_Name" runat="server" MaxLength="50" Width="100px"></asp:TextBox>
                </td>
                <td class="htmltable_Left" style="width: 150px">
                    <span style="color: #ff0000">*</span>主管層級
                </td>
                <td class="htmltable_Right">
                    <asp:DropDownList ID="cmbBossLevelID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbBossLevelID_SelectedIndexChanged" >
                        <asp:ListItem Value="0">非主管</asp:ListItem>
                        <asp:ListItem Value="1">一層主管</asp:ListItem>
                        <asp:ListItem Value="2">二層主管</asp:ListItem>
                        <asp:ListItem Value="3">三層主管</asp:ListItem>
                        <%--<asp:ListItem Value="4">四層主管</asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left"><span style="color: #ff0000">*</span>感應卡號
                </td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="txtYoyoCard4Edit" runat="server" MaxLength="20"></asp:TextBox>
                    <asp:HiddenField ID="hfOldYoyoCard" runat="server" />
                </td>
                <td class="htmltable_Left" style="width: 150px">
                    電子郵件
                </td>
                <td class="htmltable_Right">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" Width="250" Enabled="false" ></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    <%--<asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="(註：若無E-MAIL，請填入1。)"></asp:Label>--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="輸入的電子郵件有誤!" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*|[1]"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">
                    <span style="color: #ff0000">*</span>AD帳號
                </td>
                <td class="htmltable_Right" style="width: 250px">
                    <asp:TextBox ID="txtADID4Edit" runat="server"></asp:TextBox>
                </td>
                <!--
                <td class="htmltable_Left" style="width: 150px">
                    <span style="color: #ff0000">*</span>AD密碼
                </td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="txtUser_password" runat="server" Width="155px" TextMode="Password"></asp:TextBox>
                    <asp:HiddenField ID="HidPWD" runat="server" />
                </td>
                -->
                <td class="htmltable_Left" style="width: 150px">
                    可跨處室設定請假代理人
                </td>
                <td class="htmltable_Right" style="width: 250px">
                    <asp:RadioButtonList ID="rblMutiDepartDeputy_flag" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="是" Value="1"></asp:ListItem>
                        <asp:ListItem Text="否" Value="0" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr id="tr8" runat="server">
                <td class="htmltable_Left" style="width: 150px">
                    <span style="color: #ff0000">*</span>目前職稱
                </td>
                <td class="htmltable_Right">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <uc3:ucSaCode ID="cmbTitleNo4Edit" runat="server" Code_Kind="P" Code_sys="023" Code_type="012"
                                ControlType="2" Mode="selectone" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="htmltable_Left" style="width: 150px">
                    <span style="color: #ff0000">*</span>職務類別
                </td>
                <td class="htmltable_Right">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <%--<uc3:ucSaCode ID="ddlPEMEMCOD" runat="server" Code_Kind="P" Code_sys="023" Code_type="022"
                                ControlType="2" Mode="selectone" />--%>
                            <asp:DropDownList ID="ddlPEMEMCOD" runat="server" DataValueField="CODE_NO" DataTextField="CODE_DESC1"
                                 AutoPostBack="true" OnSelectedIndexChanged="ddlPEMEMCOD_SelectedIndexChanged"  />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">直撥電話
                </td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="txtLivePhone4Edit" runat="server"></asp:TextBox>
                </td>
                <td class="htmltable_Left" style="width: 150px">辦公室電話
                </td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="txtOffice_tel" runat="server" MaxLength="20" size="10"></asp:TextBox>
                    分機
                        <asp:TextBox ID="txtOffice_ext" runat="server" MaxLength="10" size="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">
                    <span style="color: #ff0000">*</span>差勤組別
                </td>
                <td class="htmltable_Right">
                    <asp:DropDownList ID="ddlPEKIND" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="htmltable_Left" style="width: 150px">
                    <span style="color: #ff0000">*</span>上班別
                </td>
                <td class="htmltable_Right">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:RadioButtonList ID="rblPEWKTYPE" runat="server" RepeatColumns="2">
                            </asp:RadioButtonList>
                            <uc3:ucSaCode ID="cmbShiftType4Edit" runat="server" Code_Kind="P" Code_sys="023"
                                Code_type="020" ControlType="1" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">
                    <span style="color: #ff0000">*</span>性別
                </td>
                <td class="htmltable_Right">
                    <asp:RadioButtonList ID="rblPESEX" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="男" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="女" Value="0"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="htmltable_Left" style="width: 150px">
                    <span style="color: #ff0000">*</span>
                    出生年月日
                </td>
                <td class="htmltable_Right">
                    <uc4:UcDate ID="txtPEBIRTHD" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">
                    <span style="color: #ff0000">*</span>官職等
                </td>
                <td class="htmltable_Right">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <uc3:ucSaCode ID="ddlPECRKCOD" runat="server" Code_Kind="P" Code_sys="023" Code_type="031"
                                ControlType="2" Mode="selectone" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="htmltable_Left" style="width: 150px">俸點
                </td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="txtPEPOINT" runat="server" size="8" MaxLength="10"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">主管職務加給
                </td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="txtPECHIEF" runat="server" MaxLength="10" size="8"></asp:TextBox>
                </td>
                <td class="htmltable_Left" style="width: 150px">專業加給
                </td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="txtPEPROFESS" runat="server" size="8" MaxLength="10"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none" >
                <td class="htmltable_Left" style="width: 150px">年制別
                </td>
                <td class="htmltable_Right" colspan="3" >
                    <asp:DropDownList ID="ddlPEYKIND" runat="server">
                        <asp:ListItem Value="1">歷年制</asp:ListItem>
                        <asp:ListItem Value="2">學年制</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">
                    <span style="color: #ff0000">*</span>初任公職日
                </td>
                <td class="htmltable_Right" colspan="3" >
                    <uc4:UcDate ID="UcJoinDate" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">
                    <span style="color: #ff0000">*</span>到職日
                </td>
                <td class="htmltable_Right">
                    <uc4:UcDate ID="txtPEACTDATE" runat="server" />
                </td>
                <td class="htmltable_Left" style="width: 150px">離職日期
                </td>
                <td class="htmltable_Right">
                    <uc4:UcDate ID="txtPELEVDATE" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">事假天數
                </td>
                <td class="htmltable_Right" >
                    <asp:TextBox ID="txtPEHDAY2" runat="server" MaxLength="2" size="5"></asp:TextBox>
                </td>
                <td class="htmltable_Left" style="width: 150px">病假天數
                </td>
                <td class="htmltable_Right" >
                    <asp:TextBox ID="txtPEHDAY3" runat="server" MaxLength="2" size="5"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none" >
                <td class="htmltable_Left" style="width: 150px">
                    <span style="color: #ff0000">*</span>登入類型
                </td>
                <td class="htmltable_Right">
                    <asp:DropDownList runat="server" ID="ddlLoginType">
                        <asp:ListItem Text="帳號/密碼" Value="1"></asp:ListItem>
                        <asp:ListItem Text="AD登入" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">休假年資計算起日
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbYearStartDate" runat="server" Width="100px"></asp:Label>
                </td>
                <td class="htmltable_Left" style="width: 150px">本年休假天數
                </td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="txtPEHDAY" runat="server" size="5" MaxLength="4"></asp:TextBox>
                    <asp:Button ID="cbCount" runat="server" Text="計算天數" OnClick="cbCount_Click" Style="margin-right: 0px" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px;display:none">休假年資
                </td>
                <td class="htmltable_Right" style="display:none">
                    <asp:Label ID="lbYear" runat="server" Width="100px"></asp:Label>
                    <asp:TextBox ID="txtPEHYEAR" runat="server" size="10" MaxLength="2" Visible="false"></asp:TextBox>
                    <asp:Label ID="lbYear_y" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lbYear_m" runat="server" Visible="False"></asp:Label>
                </td>
                <td class="htmltable_Left" style="width: 150px;">服務年資
                </td>
                <td class="htmltable_Right" >
                    <asp:TextBox ID="txtServiceYear" runat="server" size="10" MaxLength="2" ></asp:TextBox>
                </td>
                <td class="htmltable_Left" style="width: 160px">異動年資
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbChgYear" runat="server"></asp:Label>
                    <%--<input type="button" id="cbYear" value="年資異動" onclick="ShowYearSetting()" style="width: 90px"
                        runat="server" />--%>
                    <asp:Label ID="lbChgYear_y" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lbChgYear_m" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 160px">留職停薪年資
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbChgCntYear2" runat="server"></asp:Label>
                </td>

                <td class="htmltable_Left" style="width: 150px">休假年資
                </td>
                <td class="htmltable_Right" colspan="3">
                    <asp:Label ID="lbTotalYear" runat="server"></asp:Label>
                </td>
            </tr>
            <!--
            <td class="htmltable_Left" style="width: 150px">
                休假年資起算日</td>
            <td class="htmltable_Right"> 
                <asp:Label ID="lbCntYearStartDate" runat="server"></asp:Label>
            </td>
            -->
            <%--前兩年保留假--%>
            <%--<tr class="ui-helper-hidden">--%>
            <tr>
                <td class="htmltable_Left" style="width: 150px">前一年保留天數
                </td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="txtPerday1" runat="server" size="5" MaxLength="4"></asp:TextBox>
                </td>
                <td class="htmltable_Left" style="width: 150px">前兩年保留天數
                </td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="txtPerday2" runat="server" size="5" MaxLength="4"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px;display:none">是否可使用人員切換
                </td>
                <td class="htmltable_Right" style="display:none">
                    <asp:RadioButtonList ID="rblSyslogin" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="是" Value="1"></asp:ListItem>
                        <asp:ListItem Text="否" Value="0" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:HiddenField ID="hfRole" runat="server" />
                </td>
                <td class="htmltable_Left" style="width: 150px">是否為值班人員
                </td>
                <td class="htmltable_Right" colspan="3">
                    <asp:RadioButtonList ID="rbOnDuty" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="是" Value="1"></asp:ListItem>
                        <asp:ListItem Text="否" Value="0" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <%--<tr>
                <td class="htmltable_Right" colspan="4">
                    <asp:CheckBoxList ID="cblRoleName" runat="server" RepeatColumns="5">
                    </asp:CheckBoxList>
                </td>
            </tr>--%>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
            <tr>
                <td class="htmltable_Left" style="width: 150px" colspan="4">
                    <asp:Button ID="cbjoin" runat="server" Text="新增服務單位" OnClick="cbjoin_Click" />
                </td>
            </tr>
            <tr>
                <td style="width: 100%;" class="htmltable_Right" colspan="4">
                  <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                        <ContentTemplate>
                    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                        AllowPaging="True" PageSize="30" CssClass="Grid" PagerStyle-HorizontalAlign="Right"
                        Width="100%" OnDataBound="gvList_DataBound" EnableModelValidation="True" OnRowDataBound="gvList_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="機關名稱">
                                <ItemTemplate>
                               
                                            <asp:DropDownList ID="gvddlOrgcode" runat="server" DataTextField="Orgcode_name" DataValueField="Orgcode"
                                                OnSelectedIndexChanged="gvddlOrgcode_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="單位名稱" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <uc8:UcDDLDepart ID="ddlgvDeaprtId" runat="server" />                                           
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="服務類別" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlgvServicesType" runat="server">
                                                <asp:ListItem Value="0">佔缺單位</asp:ListItem>
                                                <asp:ListItem Value="1">服務單位</asp:ListItem>
                                                <asp:ListItem Value="2">兼職單位</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="服務時間(起)">
                                <ItemTemplate>
                                    <uc4:UcDate ID="gvtxtServiceSDate" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="服務時間(迄)">
                                <ItemTemplate>
                                    <uc4:UcDate ID="gvtxtServiceEDate" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="直屬主管" Visible="False">
                                <ItemTemplate>
                                    <uc8:UcDDLDepart ID="ddlgvBossDeaprtId" runat="server" OnSelectedIndexChanged="gvddlBossDepartID_changed" />
                                    <asp:UpdatePanel ID="PnlGVBoss" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="cmbGvBoss" runat="server">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="功能">
                                <ItemTemplate>
                                    <asp:Button ID="btnDel" runat="server" Text="刪除" OnClientClick="javascript:if(!confirm('是否確定要刪除？')) return false;"
                                        OnClick="doDelete" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" />
                    </asp:GridView>
                    </ContentTemplate></asp:UpdatePanel> 
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
            <tr>
                <td colspan="4">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" style="display:none" >
                        <tr>
                            <td class="htmltable_Title" colspan="4">員工個人簡介 
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left" style="width: 120px">自述
                            </td>
                            <td class="htmltable_Right" style="width: 230px">
                                <asp:TextBox ID="txtIntro_desc" runat="server" Rows="5" TextMode="MultiLine" Width="90%"></asp:TextBox>
                            </td>
                            <td class="htmltable_Left" style="width: 120px">專長
                            </td>
                            <td class="htmltable_Right" style="width: 230px">
                                <asp:TextBox ID="txtSkill_desc" runat="server" Rows="5" TextMode="MultiLine" Width="90%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left" style="width: 120px">興趣
                            </td>
                            <td class="htmltable_Right" style="width: 230px">
                                <asp:TextBox ID="txtSpecialty_desc" runat="server" Rows="5" TextMode="MultiLine"
                                    Width="90%"></asp:TextBox>
                            </td>
                            <td class="htmltable_Left" style="width: 120px">心情感言
                            </td>
                            <td class="htmltable_Right" style="width: 230px">
                                <asp:TextBox ID="txtMood_desc" runat="server" Rows="5" TextMode="MultiLine" Width="90%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left" style="width: 120px">照片
                            </td>
                            <td class="htmltable_Right" style="width: 230px" colspan="3">
                                <asp:TextBox ID="txtPicFile_path" runat="server" Visible="False"></asp:TextBox>
                                <asp:Image ID="imgPic" runat="server" Width="80px" />
                                <asp:FileUpload ID="FileUpload1" runat="server" Width="400px" />
                                <asp:Button ID="Button1" runat="server" Text="上傳" OnClick="Button1_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4">
                    <asp:Button ID="btnConfirm" runat="server" CausesValidation="False" Text="確認" OnClick="btnConfirm_Click" /><asp:Button
                        ID="btnBack" runat="server" Text="取消" CausesValidation="False" OnClick="btnBack_Click" />
                    <asp:Button ID="cbchange" runat="server" Text="人員異動" Visible="False" />
                    <asp:Button ID="cboldmember" runat="server" Text="存入舊帳號" Visible="False" />
                    <asp:HiddenField ID="hfMode" runat="server" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlQuery" runat="server" Visible="False">
        <table id="tbQ" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
            class="tableStyle99">
            <tr>
                <td class="htmltable_Title2" style="width: 100%" align="center">查詢結果
                </td>
            </tr>
            <tr>
                <td style="width: 100%;" class="TdHeightLight" colspan="2">
                    <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                        AllowPaging="True" PageSize="30" CssClass="Grid" PagerStyle-HorizontalAlign="Right"
                        Width="100%" EmptyDataText="查無資料!" EmptyDataRowStyle-ForeColor="Red" EnableModelValidation="True"
                        OnRowCommand="gvResult_RowCommand" OnRowDataBound="gvResult_RowDataBound"
                        OnPageIndexChanging="gvResult_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField Visible="False">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CB1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>                        
                            <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# ((GridViewRow) Container).RowIndex+1 %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="機關名稱">
                                <ItemTemplate>
                                    <asp:Label ID="lblOrgName" runat="server" Text='<%# getOrgName(DataBinder.Eval(Container.DataItem, "OrgCode").ToString()) %>'></asp:Label>
                                    <asp:HiddenField ID="hfOrgCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "OrgCode") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="單位名稱">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# getDepartName(DataBinder.Eval(Container.DataItem, "Depart_ID").ToString()) %>'></asp:Label>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Depart_ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="姓名(職稱)<br/>員工編號<br/>AD帳號">
                                <ItemStyle HorizontalAlign="Center" Width="145px" />
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("User_name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("User_name") %>'></asp:Label>
                                    (<asp:Label ID="Title_name" runat="server" Text='<%# getTitle_name(DataBinder.Eval(Container.DataItem, "Title_NO").ToString()) %>'></asp:Label>)
                                    <br />
                                    <asp:Label ID="lblIdCard" runat="server" Text='<%# Bind("id_card") %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("ad_id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="人員類別">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("EMPLOYEE_TYPE") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="EMPLOYEE_name" runat="server" Text='<%# getEMPLOYEEname(DataBinder.Eval(Container.DataItem, "EMPLOYEE_TYPE").ToString()) %>'></asp:Label>
                                    <asp:HiddenField ID="hfEmployeeType" runat="server" Value='<%# Bind("EMPLOYEE_TYPE") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>                   
                            <asp:TemplateField HeaderText="主管層級">
                            <ItemTemplate>
                                <asp:Label ID="BossLevelName" runat="server" Text='<%# getBossLevelName(DataBinder.Eval(Container.DataItem, "BOSS_LEVEL_ID").ToString()) %>'></asp:Label>
                             </ItemTemplate>
                            </asp:TemplateField>                     
                            <asp:TemplateField HeaderText="角色">
                            <ItemTemplate>
                                <asp:Label ID="RoleName" runat="server" Text='<%# getRoleName(DataBinder.Eval(Container.DataItem, "Role_id").ToString(),DataBinder.Eval(Container.DataItem, "ORGCODE").ToString()) %>'></asp:Label>
                             </ItemTemplate>
                            </asp:TemplateField>
                            <%--
                               <asp:TemplateField HeaderText="直屬主管">
                            <ItemTemplate>
                                <asp:Label ID="BossName" runat="server" Text='<%# getBossName(DataBinder.Eval(Container.DataItem, "BOSS_IDCARD").ToString()) %>'></asp:Label>
                             </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PEHYEAR" HeaderText="休假&lt;br/&gt;年資" HtmlEncode="False" />
                            <asp:BoundField DataField="PEHDAY" HeaderText="休假&lt;br/&gt;天數" HtmlEncode="False" />--%>
                            <asp:TemplateField HeaderText="功能" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label id="lbInitflag" runat="server" Text='<%# Eval("Init_flag") %>' Visible="false" />
                                    <asp:Label ID="lbYoyoCard_Change_flag" runat="server" Text='<%# Eval("YoyoCard_Change_flag") %>' Visible="false" />
                                    <asp:Label ID="lbDepart_Change_flag" runat="server" Text='<%# Eval("Depart_Change_flag") %>' Visible="false" />
                                    <asp:Button ID="btnPrint" runat="server" CommandArgument='<%# Eval("ID_card") %>' CommandName="Print" Text="匯出" Visible="false" />
                                    <asp:Button ID="btnUpdate" runat="server" CommandArgument='<%# Eval("ID_card") %>' CommandName="doUpdate" Text="修改" />
                                    <asp:Button ID="btnDel" runat="server" OnClick="btnDel_Click" OnClientClick="javascript:if(!confirm('一旦刪除就無法救回資料，是否確定要刪除？')) return false;" Text="刪除" />
                                    <asp:Button ID="btnYear" runat="server" CommandArgument='<%# Eval("ID_card") %>' CommandName="doYear" Text="年資異動" />
                                    <asp:Button ID="btnCheckIn" runat="server" CommandArgument='<%# Eval("ID_card") %>' CommandName="doCheckIn" Text="啟動報到流程" />
                                    <asp:Button ID="btnToOut" runat="server" CommandArgument='<%# Eval("ID_card") %>' CommandName="doToOut" Text="人員借調設定" />
                                    <asp:Button ID="btnChange" runat="server" CommandArgument='<%# Eval("ID_card") %>' CommandName="doChange" Text="門禁卡變更通知" Visible="false" />
                                    <%--<asp:Button ID="btnQuit" runat="server" Text="停用" OnClick="btnQuit_Click" OnClientClick="javascript:if(!confirm('是否確定停用？')) return false;" />--%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" />
                        <EmptyDataTemplate>
                            查無資料!!
                        </EmptyDataTemplate>
                        <RowStyle CssClass="Row" />
                        <AlternatingRowStyle CssClass="AlternatingRow" />
                        <PagerSettings Position="TopAndBottom" />
                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="right" class="TdHeightLight">
                    <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvResult" PNow="1" PSize="30" Visible="true" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
