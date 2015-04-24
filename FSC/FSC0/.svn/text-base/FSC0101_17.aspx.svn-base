<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC0101_17.aspx.vb" Inherits="FSC0101_17" %>

<%@ Register src="~/UControl/UcDate.ascx" tagprefix="uc2" tagname="UcDate" %>
<%@ Register src="~/UControl/UcTextBox.ascx" tagprefix="uc3" tagname="UcTextBox" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc1" TagName="UcFlowDetail" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                專簽加班簽核</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                專案代號</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbProjectCode" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                <span style="color: #ff0000">*</span>專案名稱</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbProjectName" runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                專案說明</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbProjectDesc" runat="server" TextMode="MultiLine"></asp:Label>
            </td>
        </tr>   
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 <span style="color: #ff0000">*</span>專案類別</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rblProjectKind" runat="server" RepeatDirection="Horizontal"
                    DataTextField="code_desc1" DataValueField="code_no" >                    
                </asp:RadioButtonList>
            </td>         
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                加班性質</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbCheckType" runat="server" TextMode="MultiLine"></asp:Label>
            </td>
        </tr> 
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                加班地點</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbLocation" runat="server" TextMode="MultiLine"></asp:Label>
            </td>
        </tr> 
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 <span style="color: #ff0000">*</span>專案加班起</td>
            <td class="htmltable_Right">
                <asp:Label ID="UcDate1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 <span style="color: #ff0000">*</span>專案加班迄</td>
            <td class="htmltable_Right">
                <asp:Label ID="UcDate2" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 是否刷卡</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbisCard" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 是否僅限補休</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbisOnlyLeave" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                <span style="color: #ff0000">*</span>員工姓名</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbMember" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 每日加班時數上限</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbDailyOTHr" runat="server" Width="80"></asp:Label>
            </td>         
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 每日加班費時數上限</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbDailyOTPayHr" runat="server" Width="80"></asp:Label>
            </td>         
        </tr>        
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 每月加班時數上限</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbMonOTHr" runat="server" Width="80"></asp:Label>
            </td>         
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 每月加班費時數上限</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbMonOTPayHr" runat="server" Width="80"></asp:Label>
            </td>         
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <input id="cbPrint" type="button" value="列印" onclick="javascript: window.print();" class="nonPrinted" />                
                <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" />
            </td>
        </tr>
    </table>
    <uc1:UcFlowDetail runat="server" ID="UcFlowDetail" />
</asp:Content>
