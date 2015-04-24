<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PRO3101_02.aspx.cs" Inherits="PRO_PRO3_PRO3101_02" %>

<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc2" %>
<%@ Register src="~/UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc2" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc2" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">軟體保管單明細表
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">公文文號
            </td>
            <td style="width: 326px">
                <asp:HiddenField ID="hfFlow_id" runat="server" />
                <asp:TextBox ID="txtOfficialNumber_id" runat="server" ></asp:TextBox> 
            </td>
            <td class="htmltable_Left">
                <span style="color:red">*</span>軟體編號
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtSoftware_id" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                <span style="color:red">*</span>軟體別
            </td>
            <td style="width: 326px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <uc2:ucSaCode ID="ucSoftware_type" runat="server" Code_sys="016" Code_type="004" ControlType="RadioButtonList" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="htmltable_Left">軟體名稱(含廠牌)
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtSoftware_name" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">軟體版本
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtVersion" runat="server"></asp:TextBox>
                (若無,請填N/A)
            </td>
            <td class="htmltable_Left">序號
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtKeyNumber_nos" runat="server"></asp:TextBox>
                (若無,請填N/A)
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                <span style="color:red">*</span>使用版別
            </td>
            <td style="width: 326px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <uc2:ucSaCode ID="ucSoftwareKind_type" runat="server" Code_sys="016" Code_type="001" ControlType="RadioButtonList" />
                        <asp:TextBox ID="txtNetPLimit_cnt" runat="server"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="htmltable_Left">數量
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtSofeware_cnt" runat="server" ></asp:TextBox>套
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                <span style="color:red">*</span>取得方式
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <uc2:ucSaCode ID="ucObtain_type" runat="server" Code_sys="016" Code_type="002" ControlType="RadioButtonList" />
                        <asp:TextBox ID="txtObtainOt_desc" runat="server"></asp:TextBox>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="htmltable_Left">
                <span style="color:red">*</span>來源單位
            </td>
            <td>
                <asp:TextBox ID="txtSoftwareUnit_name" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">存放媒體
            </td>
            <td style="width: 326px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <uc2:ucSaCode ID="ucStorageMedia_type" runat="server" Code_sys="016" Code_type="003" ControlType="RadioButtonList" />
                        <asp:TextBox ID="txtStorageMediaOt_desc" runat="server"></asp:TextBox>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="htmltable_Left">存放媒體數量
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtStorageMedia_cnt" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"> 
                相關文件手冊名稱
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtRelatedPapers_name" runat="server" TextMode="MultiLine" Height="76px" Width="80%"></asp:TextBox>
            </td>
            <td class="htmltable_Left"> 
                年限
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtLifeTime" runat="server" ></asp:TextBox>年
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"> 
                <span style="color:red">*</span>費用或月租金
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtFee_amt" runat="server" ></asp:TextBox>元 或<asp:TextBox ID="txtMRent_amt" runat="server" ></asp:TextBox>元/月
            </td>
            <td class="htmltable_Left"> 
                <span style="color:red">*</span>啟用日期
            </td>
            <td style="width: 326px">
                <uc2:UcDate ID="ucStart_date" runat="server" /> 
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"> 
                備註
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtMemo" runat="server" TextMode="MultiLine" Height="76px" Width="100%"></asp:TextBox>
            </td> 
        </tr>
        <tr>
            <td class="htmltable_Left"> 
                保管單位
            </td>
            <td style="width: 326px">
                <uc2:UcDDLDepart runat="server" ID="ucUnit_code" OnSelectedIndexChanged="ucUnit_code_SelectedIndexChanged" />
            </td>
            <td class="htmltable_Left"> 
                保管人
            </td>
            <td style="width: 326px">
                <uc2:UcDDLMember runat="server" ID="ucUser_id" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"> 
                登記日期
            </td>
            <td colspan="3"> 
                <uc2:UcDate runat="server" ID="ucRegister_date" />
            </td> 
        </tr>
    </table>
    <div align="center">
        <asp:Button ID="DoneBtn" runat="server" Text="確認" OnClick="DoneBtn_Click" />
        <asp:Button ID="ResetBtn" runat="server" Text="清空重填" OnClick="ResetBtn_Click" />
    </div>
</asp:Content>

