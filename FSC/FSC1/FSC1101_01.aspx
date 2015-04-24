<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC1101_01.aspx.vb" Inherits="FSC1101_01" %>

<%@ Register Src="~/UControl/UcTextBox.ascx" TagName="UcTextBox" TagPrefix="uc5" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc4" %>
<%@ Register Src="~/UControl/FSC/UcLeaveMember.ascx" TagName="UcLeaveMember" TagPrefix="uc3" %>
<%@ Register Src="~/UControl/UcLeaveDate.ascx" TagName="UcLeaveDate" TagPrefix="uc7" %>
<%@ Register Src="~/UControl/UcLeaveDate2.ascx" TagName="UcLeaveDate2" TagPrefix="uc7" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/FSC/UcAttachment.ascx" TagPrefix="uc6" TagName="UcAttachment" %>
<%@ Register Src="~/UControl/UcLeaveType.ascx" TagName="UcLeaveType" TagPrefix="uc4" %>
<%@ Register Src="~/UControl/FSC/UcLeaveDeputy.ascx" TagPrefix="uc2" TagName="UcLeaveDeputy" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        //$().ready(function () {
            //chgTableMode($('#ctl00_ContentPlaceHolder1_ddlLeave_type option:selected').val());
            //showCbToChina();
            //chgDateTable();
        //});
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
            
            if (ngroup.length>1 && ngroup[1].checked) {
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
            //$('#tr3').hide();
            //$('#tr4').hide();
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

        function chgUcDate(id) {
            __doPostBack(id, '');
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

            //if (locations[0].checked && retainFlag[1].checked && ddlLeave_type.value == "03" && cbl.value == "0")
            //    if (!confirm('您申請的是國內休假，是否要勾選國民旅遊卡？'))
            //        return false;

            var hfConfrimMsg = document.getElementById('<%= hfConfrimMsg.ClientID%>');
            if (hfConfrimMsg.value != "")
                if (!confirm(hfConfrimMsg.value))
                    return false;

            return true;
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
    <table id="tb" border="1" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">申請一般請假</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>假別</td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div style="float: left">
                            <asp:DropDownList ID="ddlLeave_type" runat="server" AutoPostBack="true"
                                DataTextField="Leave_name" DataValueField="Leave_type" OnSelectedIndexChanged="ddlLeave_type_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hfConfrimMsg" runat="server" />
                        </div>
                        <div style="float: left; margin-left: 10px;">
                            <asp:RadioButtonList ID="rbl" runat="server"
                                DataTextField="Text" DataValueField="Value" RepeatDirection="Horizontal" Visible="False">
                            </asp:RadioButtonList>
                            <span id="Travel" runat="server" visible="false">
                                <%--<asp:CheckBoxList runat="server" ID="cbl" AutoPostBack="True"
                                    DataTextField="Text" DataValueField="Value" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>--%>
                                <asp:RadioButtonList ID="rblTravel" runat="server" RepeatColumns="2" >
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否 使用國民旅遊卡</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:HiddenField ID="hfcbl" runat="server" />
                                <asp:Label ID="lbInter_travel" runat="server" Visible="false" />
                            </span>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr id="tr1" runat="server">
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>一般請假類別</td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="rblLeave_ngroup" runat="server" RepeatDirection="Horizontal" DataSourceID="odsLeave_ngroup" 
                            DataTextField="Text" DataValueField="Value" AutoPostBack="true" OnSelectedIndexChanged="rblLeave_ngroup_SelectedIndexChanged">
                        </asp:RadioButtonList>
                        <asp:ObjectDataSource ID="odsLeave_ngroup" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="GetLeaveNGroup" TypeName="SYS.Logic.LeaveNGroup">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlLeave_type" Name="Leave_type" PropertyName="SelectedValue"
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr id="tr2" runat="server" visible="false">
            <td class="htmltable_Left">
                <span style="color: #ff0000">*</span>請休假別
            </td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="up1" runat="server">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="rblretainFlag" runat="server" RepeatColumns="2" 
                            OnSelectedIndexChanged="rblretainFlag_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0" Text="保留" ></asp:ListItem>
                            <asp:ListItem Value="1" Text="今年" Selected="True"></asp:ListItem>
                        </asp:RadioButtonList>
                    </ContentTemplate>
                </asp:UpdatePanel>                
            </td>
        </tr>
        <tr id="tr3" runat="server">
            <td class="htmltable_Left">
                <span style="color: #ff0000">*</span><span id="sp1LocationFlag1" runat="server" visible="false">休假地點</span><span id="sp1LocationFlag2" runat="server">種類</span>
            </td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rblLocationFlag" runat="server" RepeatColumns="2" AutoPostBack="true" OnSelectedIndexChanged="rblLocationFlag_SelectedIndexChanged" >
                    <asp:ListItem Value="0" Text="國內" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="1" Text="國外"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr id="tr4" runat="server">
            <td class="htmltable_Left"><span id="spplace1" runat="server" visible="false">旅遊地點</span><span id="spplace2" runat="server">地點</span>
            </td>
            <td class="htmltable_Right">
                <div style="float: left"><asp:TextBox ID="tbplace" runat="server" MaxLength="50" /></div>
                <div style="float: left; margin-left: 10px;">
                    <span id="sp1" runat="server" visible="false">
                    <%--<asp:CheckBox ID="cbxChinaFlag" runat="server" Text="是否赴大陸地區旅遊" />--%>
                        <asp:RadioButtonList ID="rblChinaFlag" runat="server" RepeatColumns="2" AutoPostBack="true" OnSelectedIndexChanged="rblChinaFlag_SelectedIndexChanged" >
                            <asp:ListItem Value="1">是</asp:ListItem>
                            <asp:ListItem Value="0">否 赴大陸地區</asp:ListItem>
                        </asp:RadioButtonList>
                    </span>
                </div>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>請假申請人</td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <uc3:UcLeaveMember ID="UcLeaveMember" runat="server" />

                        <asp:HiddenField ID="hfApplyEmployeeType" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr id="trDeputy" runat="server" visible="false">
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>職務代理人</td>
            <td class="htmltable_Right">
                <uc2:UcLeaveDeputy runat="server" ID="UcLeaveDeputy" />
            </td>
        </tr>
        <tr id="tr6" runat="server" visible="false">
            <td class="htmltable_Left" id="Td1" style="width: 120px">
                <span style="color: #ff0000">*</span>喪假對象</td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlTarget" runat="server" DataTextField="CODE_DESC1" DataValueField="CODE_NO" AutoPostBack="true">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr id="tr7" runat="server" visible="false">
            <td class="htmltable_Left" id="r1" style="width: 120px">
                <span style="color: #ff0000">*</span>事實發生日</td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <uc4:UcDate ID="UcDate" runat="server" />
                        <asp:CheckBox ID="cbBossAgree_flag" runat="server" Text="已經長官核准可超過30日方請畢" Visible="false" />
                        <asp:Button ID="cbCount" runat="server" Text="計算期限" Width="70px" UseSubmitBehavior="false" Visible="false" />
                        &nbsp;<asp:Label ID="lbLimit" runat="server" ForeColor="Red"></asp:Label>
                        <asp:Label ID="Label1" runat="server" ForeColor="Blue" Text="※日期填寫範例:101/01/01"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr id="tr8" runat="server" visible="false">
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>懷孕日數</td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlBabyDays" runat="server" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">時間快速設定</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rblTimeType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                    OnSelectedIndexChanged="rblTimeType_SelectedIndexChanged">
                    <asp:ListItem Text="不使用快速設定" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="單日上午遲到請假" Value="1"></asp:ListItem>
                    <asp:ListItem Text="單日上午半天請假" Value="2"></asp:ListItem>
                    <asp:ListItem Text="單日下午半天請假" Value="3"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr id="sigleDateTr" runat="server">
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>請假日期</td>
            <td class="htmltable_Right" valign="top">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server" >
                    <ContentTemplate>
                        <uc7:UcLeaveDate2 ID="UcLeaveDate" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Button ID="cbCount2" runat="server" Text="計算期限" Width="70px" UseSubmitBehavior="false" />
                &nbsp;<asp:Label ID="lbLimit2" runat="server" ForeColor="Red"></asp:Label>
                <asp:Label ID="Label2" runat="server" ForeColor="Blue" Text="※日期填寫範例:101/01/01、時間為24小時制"></asp:Label>
            </td>
        </tr>
        <tr id="multiDateTr1" runat="server" visible="false">
            <td class="htmltable_Left" colspan="2">
                <span style="color: #ff0000">*</span>請假日期</td>
        </tr>
        <tr id="multiDateTr2" runat="server" visible="false">
            <td class="htmltable_Right" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CssClass="Grid" ShowHeader="False" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="gv_lbno" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="35px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <uc7:UcLeaveDate ID="gv_UcLeaveDate" runat="server" IsDefault="false"
                                            Start_date='<%# Bind("Start_date") %>' Start_time='<%# Bind("Start_time") %>'
                                            End_date='<%# Bind("End_date") %>' End_time='<%# Bind("End_time") %>' />
                                        <asp:Label ID="Label2" runat="server" ForeColor="Blue" Text="※日期填寫範例:101/01/01、時間為24小時制"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="gv_cbInsert" runat="server" Text="插入" OnClick="gv_cbInsert_Click" />
                                        <asp:Button ID="gv_cbRemove" runat="server" OnClick="gv_cbRemove_Click" Text="刪除" />
                                    </ItemTemplate>
                                    <ItemStyle Width="35px" />
                                </asp:TemplateField>
                            </Columns>
                            <AlternatingRowStyle CssClass="AlternatingRow" />
                            <RowStyle CssClass="Row" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>事由</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※輸入事由請勿超出30字"></asp:Label><br />
                <asp:UpdatePanel ID="UpdatePanel14" runat="server" >
                    <ContentTemplate>
                        <uc5:UcTextBox ID="tbReason" runat="server" EnableViewState="true" MaxLength="30"
                        TextMode="MultiLine" Width="300" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">附件</td>
            <td class="htmltable_Right">
                <uc6:UcAttachment runat="server" ID="UcAttachment" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">假別說明</td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbDesc" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">備註</td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbMemo" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>        
    </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    
    <div style="text-align:center">
        <asp:Button ID="cbSubmit" runat="server" Text=" 送出申請 " OnClientClick="if(!checkConfirm()) return false;blockUI();" />
        <input id="cbReset" type="button" value="重填" onclick="clearForm(this.form)" />
        <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" Visible="false" />
    </div>

    <asp:UpdatePanel ID="UpdatePanel99" runat="server" >
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr id="overtimeTr1" runat="server" visible="false">
            <td class="htmltable_Left" colspan="2">
                <span style="color: #ff0000">*</span>加班資料明細
                <%--<asp:Label ID="lbDay" runat="server" />止六個月內加班資料明細--%>
            </td>
        </tr>
        <tr id="overtimeTr2" runat="server" visible="false">
            <td class="TdHeightLight" colspan="2">             
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvOvertime" runat="server" AutoGenerateColumns="False"
                            width="100%" CssClass="Grid" Borderwidth="0px" PagerStyle-HorizontalAlign="Right">
                            <Columns>
                                <asp:TemplateField HeaderText="加班日期">
                                    <ItemTemplate>
                                        <asp:Label ID="gv_lbPRADDD" runat="server" Text='<%# Bind("PRADDD") %>'></asp:Label>
                                        <asp:Label ID="gv_lbPRSTIME" runat="server" Text='<%# Bind("PRSTIME") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="gv_lbPRETIME" runat="server" Text='<%# Bind("PRETIME") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="加班類別">
                                    <ItemTemplate>
                                        <asp:Label ID="gv_lbPRATYPE" runat="server" Text='<%# Bind("PRATYPE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="加班時數">
                                    <ItemTemplate>
                                        <asp:Label ID="gv_lbPRADDH" runat="server" Text='<%# Bind("PRADDH") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="已休時數">
                                    <ItemTemplate>
                                        <asp:Label ID="gv_lbPRPAYH" runat="server" Text='<%# Bind("PRPAYH") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="已領時數">
                                    <ItemTemplate>
                                        <asp:Label ID="gv_lbPRMNYH" runat="server" Text='<%# Bind("PRMNYH") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="已休日期">
                                    <ItemTemplate>
                                        <asp:Label ID="gv_lbPSBREAKD" runat="server" Text='<%# Bind("PSBREAKD") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="可申請時數">
                                    <ItemTemplate>
                                        <asp:Label ID="gv_lbNotApplyHours" runat="server" Text='<%# Bind("NotApplyHours")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="時數分配">
                                    <ItemTemplate>
                                        <asp:TextBox ID="gv_tbPSBREAKH" runat="server" ReadOnly="true" width="40px" MaxLength="2" CssClass="NumAlignRight"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>                        
                                <asp:TemplateField HeaderText="補休期限" Visible="false">
                                    <ItemTemplate>                                
                                        <asp:Label ID="gv_lbLIMIT" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="加班單號" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbPOGRID" runat="server" Text='<%# Bind("PRGUID") %>'></asp:Label>
                                        <%-- 
                                        <uc4:UcLeaveType ID="UcLeaveType1" runat="server" Orgcode='<%# Bind("Orgcode")%>' Flow_id='<%# Bind("PRGUID") %>' Leave_name='<%# Bind("PRGUID") %>' />                                        
                                        --%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                無加班資料
                            </EmptyDataTemplate>
                            <PagerStyle HorizontalAlign="Right" />
                            <RowStyle CssClass="Row" />
                            <AlternatingRowStyle CssClass="AlternatingRow" />
                            <EmptyDataRowStyle CssClass="EmptyRow" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>                
            </td>
        </tr>        
        <tr id="businessTr1" runat="server" visible="false">
            <td class="htmltable_Left" colspan="2">
                <span style="color: #ff0000">*</span>公差資料</td>
        </tr>
        <tr id="businessTr2" runat="server" visible="false">
            <td class="TdHeightLight" colspan="2">                           
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>                        
                        <asp:GridView ID="gvBusiness" runat="server" AutoGenerateColumns="False"
                            Borderwidth="0px" CssClass="Grid" PagerStyle-HorizontalAlign="Right" width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="公差日期">
                                    <ItemTemplate>
                                        <asp:Label ID="gv_lbPPBUSPLACE" runat="server" Text='<%# Bind("PPBUSPLACE") %>' Visible="False"></asp:Label>
                                        <asp:Label ID="gv_lbPPBUSDATEB" runat="server" Text='<%# Bind("PPBUSDATEB") %>'></asp:Label>
                                        <asp:Label ID="gv_lbPPBUSDATEE" runat="server" Text='<%# Bind("PPBUSDATEE") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="gv_lbPPTIMEB" runat="server" Text='<%# Bind("PPTIMEB") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="gv_lbPPTIMEE" runat="server" Text='<%# Bind("PPTIMEE") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PPTIMEB" HeaderText="公差時間" HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:TemplateField HeaderText="合計時數">
                                    <ItemTemplate>
                                        <asp:Label ID="gv_lbPPBUSDH" runat="server" Text='<%# Bind("PPBUSDH") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="可休時數">
                                    <ItemTemplate>
                                        <asp:Label ID="gv_lbPPHDAY" runat="server" Text='<%# Bind("PPHDAY") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="已休時數">
                                    <ItemTemplate>
                                        <asp:Label ID="gv_lbPPPAYH" runat="server" Text='<%# Bind("PPPAYH") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="PXBREAKD" HeaderText="已休日期"></asp:BoundField>
                                <asp:TemplateField HeaderText="時數分配">
                                    <ItemTemplate>
                                        <asp:TextBox ID="gv_tbPXBREAKH" runat="server" ReadOnly="true" width="40px" MaxLength="2" CssClass="NumAlignRight"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle  width="85px" />
                                </asp:TemplateField>                                             
                                <asp:TemplateField HeaderText="補休期限" Visible="false">
                                    <ItemTemplate>                                
                                        <asp:Label ID="gv_lbLIMIT" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="公差單號" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbPOGRID" runat="server" Text='<%# Bind("PPGUID") %>'></asp:Label>
                                        <%--
                                        <uc4:UcLeaveType ID="UcLeaveType1" runat="server" Orgcode='<%# Bind("Orgcode")%>' Flow_id='<%# Bind("PPGUID")%>' Leave_name='<%# Bind("PPGUID")%>' />                                        
                                        --%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle HorizontalAlign="Right" />
                            <PagerStyle HorizontalAlign="Right" />
                            <EmptyDataTemplate>
                                無公差資料
                            </EmptyDataTemplate>
                            <PagerStyle HorizontalAlign="Right" />
                            <RowStyle CssClass="Row" />
                            <AlternatingRowStyle CssClass="AlternatingRow" />
                            <EmptyDataRowStyle CssClass="EmptyRow" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>

          
        <tr id="scheduleTr1" runat="server" visible="false">
            <td class="htmltable_Left" colspan="2">
                <span style="color: #ff0000">*</span>值班資料</td>
        </tr>
        <tr id="scheduleTr2" runat="server" visible="false">
            <td class="TdHeightLight" colspan="2">                           
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>                        
                        <asp:GridView ID="gvSchedule" runat="server" AutoGenerateColumns="False"
                            Borderwidth="0px" CssClass="Grid" PagerStyle-HorizontalAlign="Right" width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="值班日期">
                                    <ItemTemplate>
                                        <asp:Label ID="gv_lbScheDate" runat="server" Text='<%# Bind("Sche_date")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="可休時數">
                                    <ItemTemplate>
                                        <asp:Label ID="gv_lbScheduleHours" runat="server" Text='<%# Bind("schedule_hours")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="已休時數">
                                    <ItemTemplate>
                                        <asp:Label ID="gv_lbRestHours" runat="server" Text='<%# Bind("rest_hours")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="break_date" HeaderText="已休日期"></asp:BoundField>
                                <asp:TemplateField HeaderText="時數分配">
                                    <ItemTemplate>
                                        <asp:TextBox ID="gv_tbBreakHours" runat="server" ReadOnly="true" width="40px" MaxLength="2" CssClass="NumAlignRight"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle  width="85px" />
                                </asp:TemplateField>                                             
                                <asp:TemplateField HeaderText="補休期限" Visible="false">
                                    <ItemTemplate>                                
                                        <asp:Label ID="gv_lbLIMIT" runat="server" Text=""></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle HorizontalAlign="Right" />
                            <PagerStyle HorizontalAlign="Right" />
                            <EmptyDataTemplate>
                                無值班資料
                            </EmptyDataTemplate>
                            <PagerStyle HorizontalAlign="Right" />
                            <RowStyle CssClass="Row" />
                            <AlternatingRowStyle CssClass="AlternatingRow" />
                            <EmptyDataRowStyle CssClass="EmptyRow" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>

