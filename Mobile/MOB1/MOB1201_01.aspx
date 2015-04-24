<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/MasterPage/Mobile.master" AutoEventWireup="true" CodeFile="MOB1201_01.aspx.cs" Inherits="Mobile_MOB1_MOB1201_01" EnableEventValidation="false" %>

<%@ Register Src="../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>

<%@ Register Src="../../UControl/UcShowDate.ascx" TagName="UcShowDate" TagPrefix="uc3" %>

<%@ Register Src="../../UControl/UcShowTime.ascx" TagName="UcShowTime" TagPrefix="uc4" %>

<%@ Register Src="../UControl/UcMOBLeaveDate.ascx" TagName="UcLeaveDate" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $().ready(function () {
            chgTableMode($('#ctl00_ContentPlaceHolder1_ddlLeave_type option:selected').val());
            showCbToChina();
            //          chgDateTable();
        });
        function showCbToChina() {
            var locations = document.getElementsByName('ctl00$ContentPlaceHolder1$rblLocationFlag');
            var s = document.getElementById('sp1');
            var Travel = document.getElementById('Travel');
            var retainFlag = document.getElementsByName('ctl00$ContentPlaceHolder1$rblretainFlag');
            var ddlLeave_type = document.getElementById('ctl00_ContentPlaceHolder1_ddlLeave_type');

            if (locations[0].checked) {
                s.style.visibility = "hidden";
                if (retainFlag[1].checked && ddlLeave_type.value == "03") {
                    Travel.style.display = "";
                }
            }
            if (locations[1].checked) {
                Travel.style.display = "none";
                s.style.visibility = "visible";
            }
        }
        function chgDateTable() {
            var ngroup = document.getElementsByName('ctl00$ContentPlaceHolder1$rblLeave_ngroup')

            if (ngroup.length > 1 && ngroup[1].checked) {
                $('#multiDateTr1').show();
                $('#multiDateTr2').show();
                $('#sigleDateTr').hide();
            } else {
                $('#multiDateTr1').hide();
                $('#multiDateTr2').hide();
                $('#sigleDateTr').show();
            }
        }
        function chgTableMode(leave_type) {
            $('#tr8').hide();
            $('#tr2').hide();
            $('#tr6').hide();
            $('#tr7').hide();
            $('#Travel').hide();
            $('#overtimeTr1').hide()
            $('#overtimeTr2').hide()
            $('#businessTr1').hide()
            $('#businessTr2').hide()
            $('#scheduleTr1').hide()
            $('#scheduleTr2').hide()
            $('#sp1LocationFlag1').hide();
            $('#sp1LocationFlag2').show();
            $('#spplace1').hide();
            $('#spplace2').show();

            if (leave_type == '10') {
                $('#tr6').show();
                $('#tr7').show();
            } else if (leave_type == '08' || leave_type == '09' || leave_type == '13' || leave_type == '22') {
                $('#tr6').hide();
                $('#tr7').show();
                if (leave_type == '13') {
                    $('#tr8').show();
                }
            } else if (leave_type == "03") {
                $('#tr2').show();
                $('#tr3').show();
                $('#tr4').show();
                $('#Travel').show();
                $('#sp1LocationFlag2').hide();
                $('#sp1LocationFlag1').show();
                $('#spplace2').hide();
                $('#spplace1').show();
            } else if (leave_type == "04") {
                $('#overtimeTr1').show()
                $('#overtimeTr2').show()
            } else if (leave_type == "20") {
                $('#businessTr1').show()
                $('#businessTr2').show()
                $('#tr7').hide();
            } else if (leave_type == "32") {
                $('#scheduleTr1').show()
                $('#scheduleTr2').show()
            } else {
                $('#tr6').hide();
                $('#tr7').hide();
            }


            var employeeType = document.getElementById('<%=hfApplyEmployeeType.ClientID%>').value;

            if (employeeType == "13") {
                $('#tr1').hide();
                $('#tr2').hide();
                $('#tr3').hide();
                $('#tr4').hide();
                $('#<%=trDeputy.ClientID%>').hide();
              } else {
                  $('#tr1').show();
                  $('#<%=trDeputy.ClientID%>').show();
              }
          }



          function changeBreakh(praddh, prpayh, prmnyh, breakh) {
              var left = $('#' + praddh).html() - $('#' + prpayh).html() - $('#' + prmnyh).html();
              if ($('#' + breakh).val() > left) {
                  alert('欲補休時數不可大於加班時數減去已休已領時數!');
                  $('#' + breakh).val('');
              }
          }

          function checkConfirm() {

              var ddlLeave_type = document.getElementById('ctl00_ContentPlaceHolder1_ddlLeave_type');
              var locations = document.getElementsByName('ctl00$ContentPlaceHolder1$rblLocationFlag');
              var retainFlag = document.getElementsByName('ctl00$ContentPlaceHolder1$rblretainFlag');
              var cbl = document.getElementById('ctl00_ContentPlaceHolder1_hfcbl');

              if (locations[0].checked && retainFlag[1].checked && ddlLeave_type.value == "03" && cbl.value == "0")
                  if (confirm('您申請的是國內休假，是否要勾選國民旅遊卡？')) {
                      document.getElementById('ctl00_ContentPlaceHolder1_btn_submit').click();
                  }
                  else {
                      return false;
                  }

              var hfConfrimMsg = document.getElementById('<%= hfConfrimMsg.ClientID%>');
              if (hfConfrimMsg.value != "")
                  if (confirm(hfConfrimMsg.value)) {
                      document.getElementById('ctl00_ContentPlaceHolder1_btn_submit').click();
                  }
                  else {
                      return false;
                  }

              document.getElementById('ctl00_ContentPlaceHolder1_btn_submit').click();
          }
    </script>
    <asp:Panel ID="pnlQuery" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" >
            <tr>
                <td class="htmltable_Right"><span style="color: Red">*</span>假別</td>
                <td class="htmltable_Right">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlLeave_type" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlLeave_type_SelectedIndexChanged"
                                    OnDataBound="ddlLeave_type_DataBound">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hfConfrimMsg" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButtonList ID="rbl" runat="server"
                                    DataTextField="Text" DataValueField="Value" RepeatDirection="Horizontal" Visible="False">
                                </asp:RadioButtonList>
                                <span id="Travel">
                                    <asp:RadioButtonList ID="rblTravel" runat="server" RepeatColumns="2"
                                        OnSelectedIndexChanged="rblTravel_SelectedIndexChanged"
                                        AutoPostBack="True">
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                        <asp:ListItem Value="0">否 使用國民旅遊卡</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:HiddenField ID="hfcbl" runat="server" />
                                    <asp:Label ID="lbInter_travel" runat="server" Visible="false" />
                                </span>
                            </td>

                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="tr2">
                <td class="htmltable_Right"><span style="color: Red">*</span>請休假別</td>
                <td class="htmltable_Right">
                    <asp:RadioButtonList ID="rblretainFlag" runat="server" RepeatColumns="2"
                        AutoPostBack="True"
                        OnSelectedIndexChanged="rblretainFlag_SelectedIndexChanged">
                        <asp:ListItem Value="0" Text="保留"></asp:ListItem>
                        <asp:ListItem Value="1" Text="今年" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr id="tr3">
                <td class="htmltable_Right">
                    <span style="color: #ff0000">*</span><span id="sp1LocationFlag1" style="display: none">休假地點</span><span id="sp1LocationFlag2">種類</span>
                </td>
                <td class="htmltable_Right">
                    <asp:RadioButtonList ID="rblLocationFlag" runat="server" RepeatColumns="2"
                        OnSelectedIndexChanged="rblLocationFlag_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="0" Text="國內" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="1" Text="國外"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr id="tr4">
                <td class="htmltable_Right">
                    <span id="spplace1" style="display: none">旅遊地點</span><span id="spplace2">地點</span>
                </td>
                <td class="htmltable_Right">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:TextBox ID="tbplace" runat="server" />
                                <span id="sp1">
                                    <asp:RadioButtonList ID="rblChinaFlag" runat="server" RepeatColumns="2"
                                        AutoPostBack="True">
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                        <asp:ListItem Value="0">否 赴大陸地區</asp:ListItem>
                                    </asp:RadioButtonList>
                                </span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Right"><span style="color: Red">*</span>請假申請人</td>
                <td>
                    <asp:DropDownList ID="ddlleaveName" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlleaveName_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:HiddenField ID="hfApplyEmployeeType" runat="server" />
                </td>
            </tr>
            <tr id="trDeputy" runat="server">
                <td class="htmltable_Right"><span style="color: Red">*</span>職務代理人</td>
                <td class="htmltable_Right">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:RadioButton ID="rb1" runat="server" AutoPostBack="true" OnCheckedChanged="rb1_CheckedChanged" Text="　" />
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
                                <asp:RadioButton ID="rb2" runat="server" AutoPostBack="true" OnCheckedChanged="rb2_CheckedChanged" Text="　" />
                            </td>
                        </tr>
                        <tr>
                            <td>
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
            <tr id="tr6">
                <td class="htmltable_Right">
                    <span style="color: #ff0000">*</span>喪假對象
                </td>
                <td class="htmltable_Right">
                    <asp:DropDownList ID="ddlTarget" runat="server" AutoPostBack="true"
                        DataTextField="CODE_DESC1" DataValueField="CODE_NO"
                        OnSelectedIndexChanged="ddlTarget_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="tr7">
                <td class="htmltable_Right">
                    <span style="color: #ff0000">*</span>事實發生日
                </td>
                <td class="htmltable_Right">
                    <uc2:UcDate ID="UcDate" runat="server" />
                    <asp:Button ID="cbCount" runat="server" Text="計算期限"
                        UseSubmitBehavior="false" Visible="false" OnClick="cbCount_Click" />
                    &nbsp;<asp:Label ID="lbLimit" runat="server" ForeColor="Red"></asp:Label>
                    <asp:Label ID="Label1" runat="server" ForeColor="Blue" Text="※日期填寫範例:101/01/01"></asp:Label>
                </td>
            </tr>
            <tr id="tr8">
                <td class="htmltable_Right">
                    <span style="color: #ff0000">*</span>懷孕日數
                </td>
                <td class="htmltable_Right">
                    <asp:DropDownList ID="ddlBabyDays" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlBabyDays_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="sigleDateTr">
                <td class="htmltable_Right"><span style="color: Red">*</span>請假日期</td>
                <td class="htmltable_Right">
                    <uc2:UcLeaveDate ID="UcLeaveDate" runat="server" />
                    <asp:Button ID="cbCount2" runat="server" Text="計算期限" UseSubmitBehavior="false" OnClick="cbCount_Click" />
                    &nbsp;<asp:Label ID="lbLimit2" runat="server" ForeColor="Red"></asp:Label>
                    <asp:Label ID="Label2" runat="server" ForeColor="Blue" Text="※日期填寫範例:101/01/01、時間為24小時制"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Right"><span style="color: Red">*</span>事由</td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※輸入事由請勿超出30字"></asp:Label>
                    <asp:TextBox ID="tbReason" runat="server" TextMode="MultiLine"
                        AutoPostBack="True" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Right">假別說明</td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbDesc" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Right">備註
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbMemo" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Button ID="Button2" runat="server" Text="回上頁" UseSubmitBehavior="false" OnClick="Button2_Click" /></td>
                            <td>
                                <asp:Button ID="btnQuery" runat="server" Text="送出申請" UseSubmitBehavior="false"
                                    OnClientClick="if(!checkConfirm()) return false;blockUI();" />

                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
        </table>
    </asp:Panel>
    <div style="visibility: hidden">
        <asp:TextBox ID="hfOrgcode" runat="server"></asp:TextBox>
        <asp:TextBox ID="hfDepartId" runat="server"></asp:TextBox>
        <asp:TextBox ID="hfDeputyPosid" runat="server"></asp:TextBox>
        <asp:TextBox ID="hfApplyIdcard" runat="server"></asp:TextBox>

        <asp:TextBox ID="hfApply_name" runat="server"></asp:TextBox>
        <asp:TextBox ID="hfApply_id" runat="server"></asp:TextBox>
        <asp:TextBox ID="hfApply_posid" runat="server"></asp:TextBox>
        <asp:TextBox ID="hfApply_stype" runat="server"></asp:TextBox>
        <asp:Button ID="btn_submit" runat="server" Text="submit" UseSubmitBehavior="false"
            OnClick="btnQuery_Click" />

    </div>
</asp:Content>

