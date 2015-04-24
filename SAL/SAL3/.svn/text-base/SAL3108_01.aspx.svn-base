<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL3108_01.aspx.cs" Inherits="SAL_SAL3_SAL3108_01" %>

<%@ Register Src="../../UControl/SAL/UcSelectOrg.ascx" TagName="UcSelectOrg" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc3" %>
<%@ Register Src="../../UControl/UcMember.ascx" TagName="UcMember" TagPrefix="uc4" %>
<%@ Register Src="../../UControl/UcROCYear.ascx" TagName="UcROCYear" TagPrefix="uc5" %>
<%@ Register Src="../../UControl/SAL/ucSaSpesup.ascx" TagName="ucSaSpesup" TagPrefix="uc6" %>
<%@ Register Src="../../UControl/UcDDLDepart.ascx" TagName="UcDDLDepart" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlInput" runat="server">

    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">
                年終獎金專業加給維護
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                單位
            </td>
            <td>
                <uc2:UcSelectOrg ID="cmbDepartID" runat="server" ShowMulti="True" />
            </td>
            <td class="htmltable_Left">
                員工類別
            </td>
            <td>
                <uc3:ucSaCode ID="cmbEmployeeType" runat="server" Code_Kind="P" Code_sys="002" Code_type="017"
                    ControlType="2" Mode="query" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                員工編號
            </td>
            <td>
                <asp:TextBox ID="txtIDCard" runat="server" MaxLength="6"></asp:TextBox>
            </td>
            <td class="htmltable_Left">
                人員姓名
            </td>
            <td>
                <asp:TextBox ID="txtEmpName" runat="server" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                在職狀態
            </td>
            <td>
                <asp:DropDownList ID="ddl_status" runat="server">
                    <asp:ListItem Value="0">--全部--</asp:ListItem>
                    <asp:ListItem Selected="True" Value="1">在職</asp:ListItem>
                    <asp:ListItem Value="2">已離職</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="htmltable_Left">
                年終獎金發放年度
            </td>
            <td>
                <uc5:UcROCYear ID="cmbYear" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" clsee="htmltable_Bottom">
                <asp:Button ID="Button_sabase" runat="server" Text="帶入專業加給" OnClick="Button_sabase_Click" />
                <asp:Button ID="Button_Search" runat="server" Text="查詢" OnClick="Button_Search_Click" />
                <asp:Button ID="btn_New" runat="server" Text="新增" OnClick="btn_New_Click" />
                <asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" 
                    Visible="False" />
            </td>
        </tr>
    </table>
        </asp:Panel>
    <asp:Panel ID="pnlQuery" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_Save"></asp:PostBackTrigger>
                <asp:PostBackTrigger ControlID="btn_Delete"></asp:PostBackTrigger>
                <asp:PostBackTrigger ControlID="btnClose"></asp:PostBackTrigger>
            </Triggers>
            <ContentTemplate>
                <table class="tableStyle99" width="100%">
                    <tr>
                        <td class="htmltable_Title2" >
                            查詢結果
                        </td>
                    </tr>
                    <tr id="button" runat ="server" >
                        <td>
                            <asp:Button ID="btn_Save" runat="server" Text="儲存" OnClick="btn_Save_Click" />
                            <asp:Button ID="btn_Delete" runat="server" Text="刪除" OnClientClick="javascript:if(!confirm('是否確定要刪除？')) return false;"
                                OnClick="btn_Delete_Click" />
                            <asp:Button ID="btnClose" runat="server" Text="關閉" OnClick="btnClose_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                CellPadding="1" CellSpacing="1" BorderWidth="0px"
                                Width="100%" CssClass="Grid" OnRowDataBound="gvResult_RowDataBound" EnableModelValidation="True"
                                PageSize="30" onpageindexchanging="gvResult_PageIndexChanging">
                                <EmptyDataTemplate>
                                    查無資料
                                </EmptyDataTemplate>
                                <PagerSettings></PagerSettings>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox_Seqno" runat="server"></asp:CheckBox>
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="CheckBox_All" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox_All_CheckedChanged">
                                            </asp:CheckBox>
                                        </HeaderTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="身分證字號">
                                        <ItemTemplate>
                                            <asp:Label ID="id" runat="server" Text='<%# Eval("BOUNS_ID") %>' Visible="False" />
                                            <asp:Label ID="orgid" runat="server" Text='<%# Eval("BASE_ORGID") %>' Visible="False" />
                                            <asp:Label ID="seqno" runat="server" Text='<%# Eval("BASE_SEQNO") %>' Visible="False" />
                                            <asp:Label ID="year" runat="server" Text='<%# Eval("BOUNS_YEAR") %>' Visible="False" />
                                            <asp:Label ID="idno" runat="server" Text='<%# Eval("BASE_IDNO") %>' />
                                            <asp:Label ID="kdp" runat="server" Text='<%# Eval("BOUNS_KDP") %>' Visible="False" />
                                            <asp:Label ID="series" runat="server" Text='<%# Eval("BOUNS_KDP_SERIES") %>' Visible="False" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="姓名">
                                        <ItemTemplate>
                                            <asp:Label ID="name" runat="server" Text='<%# Eval("BASE_NAME") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="專業加給">
                                        <ItemTemplate>
                                            <uc3:ucSaCode ID="cmbBossAdd" runat="server" Code_Kind="P" Code_sys="001" Code_type="003"
                                                Code_no='<%# Eval("BOUNS_KDP") %>' ControlType="2" Mode="edit" OnCodeChanged="UcSaCode1_CodeChanged"
                                                ReturnEvent="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="加給金額">
                                        <ItemTemplate>
                                            <uc6:ucSaSpesup ID="UcSaSpesup1" runat="server" v_Type="003" v_No='<%# Eval("BOUNS_KDP")%>'
                                                v_Series='<%# Eval("BOUNS_KDP_SERIES") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="月數">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddl_month" runat="server" SelectedValue='<%# Eval("BOUNS_KDP_MON") %>'>
                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                <asp:ListItem Value="5">5</asp:ListItem>
                                                <asp:ListItem Value="6">6</asp:ListItem>
                                                <asp:ListItem Value="7">7</asp:ListItem>
                                                <asp:ListItem Value="8">8</asp:ListItem>
                                                <asp:ListItem Value="9">9</asp:ListItem>
                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                <asp:ListItem Value="11">11</asp:ListItem>
                                                <asp:ListItem Value="12">12</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="自行輸入金額">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txt_KDP_AMT" Text='<%# Bind("BOUNS_KDP_AMT") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="維護">
                                        <ItemTemplate>
                                            <asp:Button ID="Button1" runat="server" Text="維護" OnClick="Button1_Click" />
                                            <asp:Button ID="Button2" runat="server" Text="刪除" OnClientClick="javascript:if(!confirm('是否確定要刪除？')) return false;"
                                                OnClick="doDelete" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" />
                                <RowStyle CssClass="Row" />
                                <AlternatingRowStyle CssClass="AlternatingRow" />
                                <PagerSettings Position="TopAndBottom" />
                                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                            </asp:GridView>                         
                        </td>
                    </tr>
                    <tr>
                    <td align="right" >
                       <uc1:Ucpager ID="Ucpager1" runat="server" GridName="gvResult" PSize="30" 
                                PNow="1" />
                    </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <!-- 查詢使用者 ---------------------------------------------------------------->
    <asp:Panel ID="pQueryUSer" runat="server" Width="100%" Visible="false">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="Button_Commit"></asp:PostBackTrigger>
            </Triggers>
            <ContentTemplate>
                <table class="tableStyle99" width="100%">
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="Button_ShowSearch" runat="server" Text="開啟人員搜尋器" CommandArgument="Y"
                                OnClick="Button_ShowSearch_Click" />
                        </td>
                        <td colspan="2" align="right">
                            ***如要勾選非在職人員，請開啟人員搜尋器勾選***
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="div_search" runat="server" Width="100%" Visible="False">
                    <table class="tableStyle99" width="100%">
                        <tr>
                            <td colspan="4" class="htmltable_Title">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/intra_image/image_chinese/chinese_style1/share/s_inquiry.gif" />
                                人員搜尋器
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                依姓名或是身分證號
                            </td>
                            <td colspan="3" class="htmltable_Right">
                                <asp:TextBox ID="TextBox_Search_str" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="15%" class="htmltable_Left">
                                職類
                            </td>
                            <td width="35%" class="htmltable_Right">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <uc3:ucSaCode ID="UcSaCode1" runat="server" Code_sys="002" Code_type="001" Mode="query"
                                            Code_Kind="P" ControlType="2" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td width="15%" class="htmltable_Left">
                                人員類別
                            </td>
                            <td width="35%" class="htmltable_Right">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <uc3:ucSaCode ID="UcSaCode2" runat="server" Code_sys="002" Code_type="017" Mode="query"
                                            Code_Kind="P" ControlType="2" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                科室
                            </td>
                            <td class="htmltable_Right">
                                <uc7:UcDDLDepart ID="UcDDLDepart1" runat="server" />
                            </td>
                            <td class="htmltable_Left">
                                在職狀態
                            </td>
                            <td class="htmltable_Right">
                                <asp:DropDownList ID="DropDownList_edate" runat="server">
                                    <asp:ListItem Value="1" Text="在職"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="己離職"></asp:ListItem>
                                    <%--<asp:ListItem Value="3" Text="非本府員工"></asp:ListItem>--%>
                                    <asp:ListItem Value="ALL" Text="--全部--"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="htmltable_Bottom">
                                <asp:Button ID="Button3" runat="server" Text="執行查詢" OnClick="Button3_Click" />
                                <asp:Button ID="Button_Rest" runat="server" Text="清除查詢條件" OnClick="Button_Rest_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <table class="tableStyle99" width="100%">
                   <tr>
                        <td class="htmltable_Title2" >
                            查詢結果
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView_Base" runat="server" AutoGenerateColumns="False" Width="100%"
                                CssClass="Grid" CellPadding="1" CellSpacing="1" BorderWidth="0px" 
                                AllowPaging="True" onpageindexchanging="GridView_Base_PageIndexChanging">
                                <EmptyDataTemplate>
                                    查無資料
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="CheckBox_ALL" runat="server" AutoPostBack="true" OnCheckedChanged="ALLChecked" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox_Seqno" runat="server" />
                                            <asp:TextBox ID="TextBox_Seqno" runat="server" Text='<%# Eval("Base_Seqno") %>' Visible="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="員工身份證號">
                                        <ItemTemplate>
                                            <asp:Label ID="Label_IDNO" runat="server" Text='<%# Eval("Base_Idno") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="姓名">
                                        <ItemTemplate>
                                            <asp:Label ID="Label_NAME" runat="server" Text='<%# Eval("Base_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="職稱">
                                        <ItemTemplate>
                                            <asp:Label ID="Label_JOB" runat="server" Text='<%# Eval("Job") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="職等">
                                        <ItemTemplate>
                                            <asp:Label ID="Label_CLASS" runat="server" Text='<%# Eval("Class") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" />
                                <RowStyle CssClass="Row" />
                                <AlternatingRowStyle CssClass="AlternatingRow" />
                                <PagerSettings Position="TopAndBottom" />
                                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                    <td align="right">
                        <uc1:Ucpager ID="Ucpager2" runat="server" GridName="GridView_Base" PNow="1" 
                                PSize="30" />
                    </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Bottom" align="center">
                            
                            <asp:Button ID="Button_Commit" runat="server" Text="勾選確定" OnClick="Button_Commit_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
