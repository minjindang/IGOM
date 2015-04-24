<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC1103_01.aspx.vb" Inherits="FSC1103_01" %>

<%@ Register Src="~/UControl/UcTextBox.ascx" TagName="UcTextBox" TagPrefix="uc5" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="~/UControl/FSC/UcAttachment.ascx" TagPrefix="uc6" TagName="UcAttachment" %>
<%@ Register Src="~/UControl/UcShowDate.ascx" TagPrefix="uc2" TagName="UcShowDate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $().ready(function () {
            document.getElementById('<%=ddlProject.ClientID%>').style.display = "none";
            showProject();
        });
        function showProject() {
            var type = document.getElementsByName('ctl00$ContentPlaceHolder1$rblType')
            var s = document.getElementById('<%=ddlProject.ClientID%>')
            var t = document.getElementById('table1')

            if (type[0].checked) {
                s.style.display = "none";
                t.style.display = "none";
            }
            if (type.length > 1) {
                if (type[1].checked) {
                    s.style.display = "";
                    t.style.display = "";
                }
            }
        }
    </script>
    <table border = "1" cellpadding = "0" cellspacing = "0" width="100%"   class="tableStyle99">  
        <tr>
            <td class="htmltable_Title" colspan="2">
                申請加班</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color: #ff0000">*</span>申請類別</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rblType" runat="server" RepeatDirection="Horizontal" ForeColor="#555555">
                    <asp:ListItem Value="80" Text="加班" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="82" Text="專案加班"></asp:ListItem>
                </asp:RadioButtonList>

                <asp:DropDownList ID="ddlProject" runat="server"
                    DataTextField="Project_name" DataValueField="project_code" AutoPostBack="true" ></asp:DropDownList>
                <table id="table1" style="display:none" >
                    <tr>
                        <td>專案說明：</td>
                        <td><asp:Label ID="lbPProjectDesc" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>專案加班種類：</td>
                        <td><asp:Label ID="lbProjectKind" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>專案加班期間：</td>
                        <td>
                            <uc2:UcShowDate runat="server" ID="UcShowDateS" />~<uc2:UcShowDate runat="server" ID="UcShowDateE" />
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hfisCard" runat="server" />
                <asp:HiddenField ID="hfisOnlyLeave" runat="server" />
                <asp:HiddenField ID="hfLeaveHours" runat="server" />
                <asp:HiddenField ID="hfCheckType" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color: #ff0000">*</span>加班人員</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbApplyName" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color: #ff0000">*</span>加班日期</td>
            <td class="htmltable_Right">
                <uc2:UcDate ID="UcDate" runat="server" />
                &nbsp;時間<asp:TextBox ID="tbTimeb" runat="server" width="40px" MaxLength="4"></asp:TextBox>
                至
                <asp:TextBox ID="tbTimee" runat="server" width="40px" MaxLength="4"></asp:TextBox>
                <asp:Label ID="lbTip2" runat="server" ForeColor="Blue" Text="(註：時間為24小時制) "></asp:Label></td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color: #ff0000">*</span>事由</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbTip3" runat="server" ForeColor="Blue" Text="※輸入事由請勿超出30字"></asp:Label><br />
                <uc5:uctextbox id="tbReason" runat="server" enableviewstate="true" maxlength="35" textmode="MultiLine"
                    width="300"></uc5:uctextbox></td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                附件</td>
            <td class="htmltable_Right">
                <uc6:UcAttachment runat="server" ID="UcAttachment" />                    
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                備註</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbMemo" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2"  class="htmltable_Bottom">
                <asp:Button ID="cbSubmit" runat="server" Text="送出申請"  />
                <input id="cbReset" onclick="clearForm(this.form);" type="button" value="重填" />
                <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" Visible="false" />                
            </td>
        </tr>
    </table>
</asp:Content>
