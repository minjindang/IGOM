<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC1110_01.aspx.vb" Inherits="FSC1110_01"  %>

<%@ Register Src="~/UControl/FSC/UcLeaveMember.ascx" TagPrefix="uc1" TagName="UcLeaveMember" %>
<%@ Register Src="~/UControl/UcLeaveDate.ascx" TagPrefix="uc1" TagName="UcLeaveDate" %>
<%@ Register Src="~/UControl/UcTextBox.ascx" TagPrefix="uc1" TagName="UcTextBox" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/FSC/UcAttachment.ascx" TagPrefix="uc1" TagName="UcAttachment" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
    function chgValue(curdate, timeobj, target) {
        if (typeof curdate == 'undefined' || curdate == null) return;
        if (typeof timeobj == 'undefined' || timeobj == null) return;
        var idcard = "<%=UcLeaveMember.Apply_id %>";
                $.ajax({
                    url: '../../ajax/getWorkTime.ashx',
                    type: 'GET',
                    data: {
                        curdate: curdate, idcard: idcard
                    },
                    error: function (xhr) {
                        alert('Ajax request 發生錯誤');
                    },
                    success: function (response) {
                        var arrtimes = response.split(",");
                        if (target == "S")
                            timeobj.value = arrtimes[0];
                        else
                            timeobj.value = arrtimes[1];
                    }
                });
            }
            function chgUcDate() {
                __doPostBack('<%=UpdatePanel8.ClientID %>', '');
        }
        $().ready(function () {
            chgTableMode($('#ctl00_ContentPlaceHolder1_ddlLeave_type option:selected').val());
        });
    </script>
    <table id="tb" border = "1" cellpadding = "0" cellspacing = "0" width="100%"   class="tableStyle99">        
        <tr>
            <td class="htmltable_Title" colspan="2">
                申請自訂表單</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>假別類型</td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlleaveGroup" runat="server" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>假別</td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlLeaveType" runat="server" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr id="trApply">
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>表單申請人</td>
            <td class="htmltable_Right">            
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                    <uc1:UcLeaveMember runat="server" ID="UcLeaveMember" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr id="trApllyDate">
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>申請日期</td>
            <td class="htmltable_Right" valign="top">
                <uc1:UcDate runat="server" ID="UcDate" />              
                <asp:Label ID="Label1" runat="server" ForeColor="Blue" Text="※日期填寫範例:101/01/01、時間為24小時制"></asp:Label>
                </td>
        </tr>
        <tr id="trApllyDateSE">
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>請假日期</td>
            <td class="htmltable_Right" valign="top">
                <uc1:UcLeaveDate runat="server" ID="UcLeaveDate" />               
                <asp:Label ID="Label2" runat="server" ForeColor="Blue" Text="※日期填寫範例:101/01/01、時間為24小時制"></asp:Label>
                </td>
        </tr>
        <tr id="trReason">
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>事由</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※輸入事由請勿超出30字"></asp:Label><br />
                <uc1:UcTextBox ID="tbReason" runat="server" EnableViewState="true" MaxLength="30"
                    TextMode="MultiLine" Width="300" />
            </td>
        </tr>
        <%--<tr id="trDetail">
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>摘要說明</td>
            <td class="htmltable_Right">
                <uc1:UcTextBox ID="tbDetail" runat="server" EnableViewState="true" MaxLength="30"
                    TextMode="MultiLine" Width="300" />
            </td>
        </tr>--%>
        <tr id="trAttach">
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>附件</td>
            <td class="htmltable_Right">
                <uc1:UcAttachment runat="server" ID="UcAttachment" />
            </td>
        </tr>
        <%--<tr>
            <td class="htmltable_Left" style="width:120px">
                假別說明</td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                    <asp:Label ID="lbDesc" runat="server" />   
                    </ContentTemplate>
                </asp:UpdatePanel></td>
        </tr>--%>
        <tr>
            <td class="htmltable_Left" style="width:120px">
                備註</td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                    <asp:Label ID="lbMemo" runat="server" />    
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="3" style="border-top:none;">
                <asp:Button ID="cbSubmit" runat="server" Text="送出申請" /><input id="cbReset" type="button" value="重填" onclick="clearForm(this.form)"  /></td>
        </tr>
    </table>
</asp:Content>