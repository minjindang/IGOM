<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC3101_02.aspx.vb" Inherits="FSC3101_02"  %>

<%@ Register Src="~/UControl/SYS/UcUserDialog.ascx" TagPrefix="uc1" TagName="UcUserDialog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
      function chkFrm() {
            if ($("input[name='rdoDeputType']:checked").val() == 'undefine') {
                alert('請勾選代理類別');
                return;
            }
            else {
                $('#ctl00_ContentPlaceHolder1_hdDeputType').val($("input[name='rdoDeputType']:checked").val());
            }
        }

        $().ready(function () {
            $("input[name=rdoDeputType][value=" + $('#ctl00_ContentPlaceHolder1_hdDeputType').val() + "]").prop('checked', true);
            if ($('#ctl00_ContentPlaceHolder1_cbxDeputy_flag').val() != "on") {
                $('#ctl00_ContentPlaceHolder1_cbxDeputy_flag').click(this, function () {

                    if ($(this).val() == "on") {
                        $('#ctl00_ContentPlaceHolder1_txtDeputSeq').val(1);
                    }
                    else {
                        $('#ctl00_ContentPlaceHolder1_txtDeputSeq').val('');
                    }
                });
            }
            else {
                $('#ctl00_ContentPlaceHolder1_txtDeputSeq').val('');
            }
        });
    </script>    
    <table id="tbLeaveEmailNoticeSetting" border = "1" cellpadding = "0" cellspacing = "0" width="100%"   class="tableStyle99">                
        <tr>
            <td align="left" class="htmltable_Title" colspan="5">
                設定職務代理人</td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="2">
                <asp:Label ID="lbAddModify" runat="server" Text="新增"></asp:Label>代理人</td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                職稱代碼</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbPosid" runat="server"></asp:Label>
                <asp:Label ID="lbPosname" runat="server"></asp:Label></td>
        </tr>
<%--        <tr>
            <td class="htmltable_Left">
                職務代理人職稱代碼</td>
            <td class="htmltable_Right">
                </td>
        </tr>
--%>        <tr>
            <td class="htmltable_Left">
                職務代理人姓名</td>
            <td class="htmltable_Right">
                <%--<asp:Label ID="lbDeputy_name" runat="server" Width="80px"></asp:Label><asp:HiddenField ID="hfDeputy_id_card" runat="server" />
                <asp:HiddenField ID="tbDeputy_title_no" runat="server" ></asp:HiddenField>
                <img id="img" runat="server" alt="選擇指定人員" src="../../images/icon/icon_select.gif" onclick="ShowDialogGetUnitINUser();return false;" />--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate> 
                        <uc1:UcUserDialog runat="server" ID="UcUserDialog" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
<%--         <tr>
            <td class="htmltable_Left">
                代理類別</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rdolstDeputType" runat="server" RepeatDirection="Horizontal" >
                    <asp:ListItem Value="1">行政代理</asp:ListItem>
                    <asp:ListItem Value="2">教學代理</asp:ListItem>
                </asp:RadioButtonList>
                <input type="radio" id="rdoDeputType1" name="rdoDeputType" value="1"/>行政代理<input type="radio" id="rdoDeputType2" name="rdoDeputType" value="2" />教學代理
                <asp:HiddenField ID="hdDeputType" runat="server" />
                </td>
        </tr>--%>
        <tr>
            <td class="htmltable_Left">
                預設代理</td>
            <td class="htmltable_Right">
                        <asp:CheckBox ID="cbxDeputy_flag" runat="server" Text="預設職務代理人" AutoPostBack="True"/>
                </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                順序</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="txtDeputSeq2" runat="server" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="cbConfirm" runat="server"  Text="確認" OnClientClick="chkFrm();" />
                <asp:Button ID="cbCancel" runat="server"  Text="取消" /></td>
        </tr>
    </table>
</asp:Content>

