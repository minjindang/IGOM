<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC3112_02.aspx.vb" Inherits="FSC3112_03" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc1" %>
<%@ Register Src="~/UControl/SYS/UcUserDialog.ascx" TagPrefix="uc2" TagName="UcUserDialog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
                排班資料維護
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color:Red">*</span>排班日期</td>
            <td class="TdHeightLight">
                <uc1:UcDate runat="server" ID="UcDate" />
            </td>  
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
               <span style="color:Red">*</span>值班人員
            </td>
            <td class="TdHeightLight">
                <uc2:UcUserDialog runat="server" id="UcUserDialog" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
               <span style="color:Red">*</span>班別
            </td>
            <td class="TdHeightLight">
               <asp:DropDownList ID="ddlSchedule" runat="server" DataTextField="Name" DataValueField="Schedule_id"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
               值班時數
            </td>
            <td class="TdHeightLight">
                <asp:TextBox ID="tbScheduleHours" runat="server" Width="80"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
               已領時數
            </td>
            <td class="TdHeightLight">
                <asp:TextBox ID="tbPayHours" runat="server" Width="80"></asp:TextBox>               
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
               已休時數
            </td>
            <td class="TdHeightLight">
                <asp:TextBox ID="tbRestHours" runat="server" Width="80"></asp:TextBox>                
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" class="TdHeightLight">
                <asp:Button ID="cbConfirm" runat="server" Text="確定" OnClick="cbConfirm_Click" />
                <asp:Button ID="cbCancel" runat="server" Text="取消" OnClick="cbCancel_Click" />
            </td>
        </tr>
    </table>
        
    
    
</asp:Content>
