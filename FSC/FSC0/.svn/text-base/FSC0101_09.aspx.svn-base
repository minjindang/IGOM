<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0101_09.aspx.vb" Inherits="FSC0101_09" %>
<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc2" TagName="UcFlowDetail" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div>
<table width="100%">
    <tr>
        <td class="htmltable_Title" colspan="4">
            表單明細<!--軟體保管申請--></td>
    </tr>
    <tr>
        <td class="htmltable_Left">公文文號
        </td>
        <td class="htmltable_Right" style="width: 326px">
            <asp:Label ID="lbOfficialNumber_id" runat="server" ></asp:Label> 
        </td>
        <td class="htmltable_Left">
            <span style="color:red">*</span>軟體編號
        </td>
        <td class="htmltable_Right" style="width: 326px">
            <asp:Label ID="lbSoftware_id" runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left">
            <span style="color:red">*</span>軟體別
        </td>
        <td class="htmltable_Right" style="width: 326px">
            <uc2:ucSaCode ID="ucSoftware_type" runat="server" Code_sys="016" Code_type="004" ControlType="RadioButtonList" />
        </td>
        <td class="htmltable_Left">軟體名稱(含廠牌)
        </td>
        <td class="htmltable_Right" style="width: 326px">
            <asp:Label ID="lbSoftware_name" runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left">軟體版本
        </td>
        <td class="htmltable_Right" style="width: 326px">
            <asp:Label ID="lbVersion" runat="server"></asp:Label>
        </td>
        <td class="htmltable_Left">序號
        </td>
        <td class="htmltable_Right" style="width: 326px">
            <asp:Label ID="lbKeyNumber_nos" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left">
            <span style="color:red">*</span>使用版別
        </td>
        <td class="htmltable_Right" style="width: 326px">
            <uc2:ucSaCode ID="ucSoftwareKind_type" runat="server" Code_sys="016" Code_type="001" ControlType="RadioButtonList" />
            <asp:Label ID="lbNetPLimit_cnt" runat="server"></asp:Label>
        </td>
        <td class="htmltable_Left">數量
        </td>
        <td class="htmltable_Right" style="width: 326px">
            <asp:Label ID="lbSofeware_cnt" runat="server" ></asp:Label>套
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left">
            <span style="color:red">*</span>取得方式
        </td>
        <td class="htmltable_Right" >
            <uc2:ucSaCode ID="ucObtain_type" runat="server" Code_sys="016" Code_type="002" ControlType="RadioButtonList" />
            <asp:Label ID="lbObtainOt_desc" runat="server"></asp:Label>                        
        </td>
        <td class="htmltable_Left">
            <span style="color:red">*</span>軟體廠商
        </td>
        <td class="htmltable_Right" >
            <asp:Label ID="lbSoftwareCom_name" runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left">存放媒體
        </td>
        <td class="htmltable_Right" style="width: 326px">
            <uc2:ucSaCode ID="ucStorageMedia_type" runat="server" Code_sys="016" Code_type="003" ControlType="RadioButtonList" />
            <asp:Label ID="lbStorageMediaOt_desc" runat="server"></asp:Label>                        
        </td>
        <td class="htmltable_Left">存放媒體數量
        </td>
        <td class="htmltable_Right" style="width: 326px">
            <asp:Label ID="lbStorageMedia_cnt" runat="server" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left"> 
            相關文件手冊名稱
        </td>
        <td class="htmltable_Right" style="width: 326px">
            <asp:Label ID="lbRelatedPapers_name" runat="server" TextMode="MultiLine" Height="76px" Width="80%"></asp:Label>
        </td>
        <td class="htmltable_Left"> 
            年限
        </td>
        <td class="htmltable_Right" style="width: 326px">
            <asp:Label ID="lbLifeTime" runat="server" ></asp:Label>年
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left"> 
            <span style="color:red">*</span>費用或月租金
        </td>
        <td class="htmltable_Right" style="width: 326px">
            <asp:Label ID="lbFee_amt" runat="server" ></asp:Label>元 或<asp:Label ID="lbMRent_amt" runat="server" ></asp:Label>元/月
        </td>
        <td class="htmltable_Left"> 
            <span style="color:red">*</span>啟用日期
        </td>
        <td class="htmltable_Right" style="width: 326px">
            <asp:Label ID="lbStart_date" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left"> 
            備註
        </td>
        <td class="htmltable_Right" colspan="3">
            <asp:Label ID="lbMemo" runat="server" TextMode="MultiLine" Height="76px" Width="100%"></asp:Label>
        </td> 
    </tr>
    <tr>
        <td class="htmltable_Left"> 
            保管單位
        </td>
        <td class="htmltable_Right" style="width: 326px">
            <asp:Label ID="lbUnit_code" runat="server" />
        </td>
        <td class="htmltable_Left"> 
            保管人
        </td>
        <td class="htmltable_Right" style="width: 326px">
            <asp:Label ID="lbUser_id" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left"> 
            登記日期
        </td>
        <td class="htmltable_Right" colspan="3">
            <asp:Label ID="lbRegister_date" runat="server" />
        </td> 
    </tr>
    <tr>
        <td colspan="4" class="htmltable_Bottom">
            <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" />
        </td>
    </tr>
</table>
<uc2:UcFlowDetail runat="server" ID="UcFlowDetail" /> 
</div>

</asp:Content>