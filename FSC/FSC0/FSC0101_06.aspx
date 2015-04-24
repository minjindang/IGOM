<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0101_06.aspx.vb" Inherits="FSC0101_06" %>
<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc2" TagName="UcFlowDetail" %>
<%@ Register Src="~/UControl/SYS/UcComment.ascx" TagPrefix="uc1" TagName="UcComment" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<div>
<table width="100%">
    <tr>
        <td class="htmltable_Title" colspan="2">
            派車審核</td>
    </tr>
    <tr>
        <td class="htmltable_Left">預約者</td>
        <td class="htmltable_Right">
            <asp:Label ID="lbApplyName" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left">資源種類</td>
        <td class="htmltable_Right">
            <asp:Label ID="lbCardName" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left">用車時間</td>
        <td class="htmltable_Right">
            <asp:Label ID="lbDatetime" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left">用車事由</td>
        <td class="htmltable_Right">
            <asp:Label ID="lbReasonDesc" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left">說明</td>
        <td class="htmltable_Right">
            <asp:Label ID="lbDesc" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left">用車申請人</td>
        <td class="htmltable_Right">
            <asp:Label ID="lbUserId" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="htmltable_Left">用車人數</td>
        <td class="htmltable_Right">
            <asp:Label ID="lbPassengerCnt" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left">到逹地點</td>
        <td class="htmltable_Right">
            <asp:Label ID="lbDestinationDesc" runat="server"></asp:Label>                
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left" style="border-bottom:none;">單位主管用車</td>
        <td class="htmltable_Right" style="border-bottom:none;">
            <asp:RadioButtonList ID="rbxUseType" runat="server" Enabled="false">
                <asp:ListItem Text="是" Value="Y"></asp:ListItem> 
                <asp:ListItem Text="否" Value="N"></asp:ListItem> 
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
<table width="100%" runat="server" id="tbEdit" visible="false">
    <tr>
        <td class="htmltable_Left">是否同意</td>
        <td class="htmltable_Right">
            <asp:RadioButtonList ID="rbxCaseStatus" runat="server">
                <asp:ListItem Value="1" Text="通過"></asp:ListItem>
                <asp:ListItem Value="2" Text="無車可派"></asp:ListItem>
              <%--  <asp:ListItem Value="2" Text="退回"></asp:ListItem>--%>
            </asp:RadioButtonList>
        </td>
    </tr>
    
    <tr>
        <td class="htmltable_Left">接回服務</td>
        <td class="htmltable_Right">
            <asp:RadioButtonList ID="rbxIsReturn" runat="server">
                <asp:ListItem Value="0" Text="無車接回" Selected="True"></asp:ListItem>
                <asp:ListItem Value="1" Text="有車接回"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left">車牌號碼</td>
        <td class="htmltable_Right">
            <asp:DropDownList ID="ddlCarId" runat="server" DataTextField="car_id" DataValueField="car_id">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left" style="border-bottom:none;">駕駛</td>
        <td class="htmltable_Right" style="border-bottom:none;">
            <asp:DropDownList ID="ddlDriverUserid" runat="server">
            </asp:DropDownList>                
        </td>
    </tr>
     <tr>
        <td class="htmltable_Left" style="border-bottom:none;">批核意見</td>
        <td class="htmltable_Right" style="border-bottom:none;">
            <uc1:UcComment runat="server" ID="UcComment" />               
        </td>
    </tr>
   <%-- <tr>
        <td class="htmltable_Left" style="border-bottom:none;">無車可派</td>
        <td class="htmltable_Right" style="border-bottom:none;">
            <asp:CheckBox ID="cbNoCar" runat="server" />是             
        </td>
    </tr>--%>
</table>
<table width="100%" runat="server" id="Table2">
    <tr>
        <td colspan="2"  class="htmltable_Bottom">
            <asp:Button ID="cbConfirm" runat="server" Text="確認" OnClick="cbConfirm_Click" Visible="false" />
            <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" />
        </td>
    </tr>
</table>
<uc2:UcFlowDetail runat="server" ID="UcFlowDetail" />
</div>

</asp:Content>
