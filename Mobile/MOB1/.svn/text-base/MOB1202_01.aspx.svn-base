<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/MasterPage/Mobile.master" AutoEventWireup="true" CodeFile="MOB1202_01.aspx.cs" Inherits="Mobile_MOB1_MOB1202_01" %>
<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register src="../UControl/UcMOBLeaveDate.ascx" tagname="UcLeaveDate" tagprefix="uc3" %>
<%@ Register src="../../UControl/UcTextBox.ascx" tagname="UcTextBox" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <script type="text/javascript">

        function chgDateTable() {
            var ngroup = document.getElementsByName('ctl00$ContentPlaceHolder1$rblLeave_ngroup')
            if (ngroup[1].checked) {
                $('#multiDateTr1').show();
                $('#multiDateTr2').show();
                $('#sigleDateTr1').hide();
                $('#sigleDateTr2').hide();
            } else {
                $('#multiDateTr1').hide();
                $('#multiDateTr2').hide();
                $('#sigleDateTr1').show();
                $('#sigleDateTr2').show();
            }
        }
        $().ready(function () {
            showCityDDL();
            chgDateTable();
        });*/
    </script>
    <table border="1" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Right">
                <span style="color: #ff0000">*</span>申請類別</td>
            <td class="htmltable_Right">公差<!--05-->
            </td>
        </tr>
        <tr>
            <td class="htmltable_Right">
                <span style="color: #ff0000">*</span>申請人員</td>
            <td class="htmltable_Right">

                        <asp:DropDownList ID="UcLeaveMember" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlleaveName_SelectedIndexChanged">
                        </asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td class="htmltable_Right">
                <span style="color: #ff0000">*</span>職務代理人</td>
            <td class="htmltable_Right">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:RadioButton ID="rb1" runat="server" AutoPostBack="true" OnCheckedChanged="rb1_CheckedChanged" Text="　"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlDefaultDeputy"
                                    runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlDefaultDeputy_SelectedIndexChanged" /></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:RadioButton ID="rb2" runat="server" AutoPostBack="true" OnCheckedChanged="rb2_CheckedChanged" Text="　"/>
                            </td>
                                                </tr>
                        <tr>
                            <td >
                                <asp:DropDownList ID="ddlDepart_01" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlDepart_01_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlDepart_02" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlDepart_02_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlUserName" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlUserName_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        
                    </table>


            </td>
        </tr>
        <tr id="sigleDateTr1">
            <td class="htmltable_Right">
                <span style="color: #ff0000">*</span>公差日期</td>
            <td class="htmltable_Right">
                <uc3:UcLeaveDate id="UcLeaveDate" runat="server" />
            </td>
        </tr>
        <tr id="sigleDateTr2">
            <td class="htmltable_Right">假日執行<br />
                公務時間</td>
            <td class="htmltable_Right">

                        <uc3:UcLeaveDate id="UcHolidayDate" runat="server" isdefault="false" />
                        <asp:CheckBox ID="hcbx" runat="server" Text="假日執行公務" AutoPostBack="True" OnCheckedChanged="hcbx_CheckedChanged" />
                        (請填入洽公或開會時間。)

            </td>
        </tr>
        <tr>
            <td class="htmltable_Right">
                <span style="color: #ff0000">*</span>公差地點</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rblLocationFlag" runat="server" RepeatColumns="2" 
                    AutoPostBack="True" 
                    onselectedindexchanged="rblLocationFlag_SelectedIndexChanged">
                    <asp:ListItem Value="0" Text="國內" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="1" Text="國外"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:DropDownList ID="ddlCity" runat="server" DataTextField="code_desc1" DataValueField="code_no"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Right">出差明細地點</td>
            <td class="htmltable_Right">
                <uc4:UcTextBox id="UcDetailPlace" runat="server" maxlength="100" textmode="MultiLine" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Right">交通工具</td>
            <td class="htmltable_Right">
                <asp:CheckBoxList runat="server" ID="cbxlTransport"
                    RepeatDirection="Horizontal"
                    DataTextField="code_desc1" DataValueField="code_no" RepeatColumns="3">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Right">搭乘高鐵或飛機之理由說明</td>
            <td class="htmltable_Right">
                <uc4:UcTextBox id="ucTransportDesc" runat="server" enableviewstate="true" maxlength="30" textmode="MultiLine"></uc4:UcTextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Right">
                <span style="color: #ff0000">*</span>事由</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※輸入事由請勿超出30字"></asp:Label><br />
                <uc4:UcTextBox id="tbReason" runat="server" enableviewstate="true" maxlength="30" textmode="MultiLine"></uc4:UcTextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Right">假別說明</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbDesc" runat="server" /></td>
        </tr>
        <tr>
            <td colspan="2" class="htmltable_Bottom">
                
                                    <table width="100%">
                        <tr><td><asp:Button ID="Button2" runat="server" Text="回上頁" UseSubmitBehavior="false" OnClick="Button2_Click"/></td>
                            <td><asp:Button ID="cbSubmit" runat="server" Text="送出申請" UseSubmitBehavior="false" OnClick="cbSubmit_Click" /></td></tr>
                    </table>

            </td>
        </tr>
    </table>

    <div style="visibility: hidden">
        <asp:TextBox ID="hfOrgcode" runat="server"></asp:TextBox>
        <asp:TextBox ID="hfDepartId" runat="server"></asp:TextBox>
        <asp:TextBox ID="hfDeputyPosid" runat="server"></asp:TextBox>
        <asp:TextBox ID="hfApplyIdcard" runat="server"></asp:TextBox>

        <asp:TextBox ID="hfApply_name" runat="server"></asp:TextBox>
        <asp:TextBox ID="hfApply_id" runat="server"></asp:TextBox>
        <asp:TextBox ID="hfApply_posid" runat="server"></asp:TextBox>
        <asp:TextBox ID="hfApply_stype" runat="server"></asp:TextBox>
    </div>
</asp:Content>

