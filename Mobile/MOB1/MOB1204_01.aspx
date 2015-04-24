<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/MasterPage/Mobile.master" AutoEventWireup="true" CodeFile="MOB1204_01.aspx.cs" Inherits="Mobile_MOB1_MOB1204_01" enableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        window.onload = function () {
            var tb = document.getElementById('<%=gvList.ClientID %>');
            var inputs = tb.getElementsByTagName('Input');
            var total_1 = 0;
            var total_2 = 0;
            var total_3 = 0;
            for (var i = 0; i < inputs.length; i++) {
                if (IsMatch(inputs[i].id, "tbApplyHour1")) {
                    total_1 += parseInt((inputs[i].value == '' ? 0 : inputs[i].value));
                }
                if (IsMatch(inputs[i].id, "tbApplyHour2")) {
                    total_2 += parseInt((inputs[i].value == '' ? 0 : inputs[i].value));
                }
                if (IsMatch(inputs[i].id, "tbApplyHour3")) {
                    total_3 += parseInt((inputs[i].value == '' ? 0 : inputs[i].value));
                }
            }
            if (tb.rows.length > 0) {
                if (tb.rows[0].cells.length > 1) {
                    tb.rows[tb.rows.length - 1].cells[4].innerText = total_1;
                    tb.rows[tb.rows.length - 1].cells[5].innerText = total_2;
                    tb.rows[tb.rows.length - 1].cells[6].innerText = total_3;
                }
            }
        }

        function AutoCount(cid) {
            var tb = document.getElementById('<%=gvList.ClientID %>');
                var inputs = tb.getElementsByTagName('Input');
                var total = 0;

                for (var i = 0 ; i < inputs.length ; i++) {

                    if (IsMatch(inputs[i].id, cid)) {
                        total += parseInt((inputs[i].value == '' ? 0 : inputs[i].value));
                    }
                }

                var index = parseInt(cid.substr(cid.length - 1, 1)) + 3;
                tb.rows[tb.rows.length - 1].cells[index].innerText = total;
            }

            function getInt(value) {
                if ("" != value) {
                    return parseInt(value);
                }
                return 0;
            }

            function chgApplyHours(tbApplyHour1Id, tbApplyHour2Id, tbApplyHour3Id) {
                var tbApplyHour1 = document.getElementById(tbApplyHour1Id);
                var tbApplyHour2 = document.getElementById(tbApplyHour2Id);
                var tbApplyHour3 = document.getElementById(tbApplyHour3Id);
                var applyHour3 = tbApplyHour3.value;
                if (applyHour3 > 8) {
                    alert("假日8小時以下部分,不可超過8小時");
                    tbApplyHour3.value = 8;
                    applyHour3 = 8;
                }

                var total = getInt(tbApplyHour1.value) + getInt(tbApplyHour2.value);
                if (0 < applyHour3 && applyHour3 < 9) {
                    tbApplyHour3.parentNode.parentNode.cells[7].innerText = getInt(total) + 8;
                } else {
                    tbApplyHour3.parentNode.parentNode.cells[7].innerText = total;
                }

                var sumApplyHours3 = 0;
                var tb = document.getElementById('<%=gvList.ClientID %>');
            var rowLength = tb.rows.length;
            for (var i = 2; i < rowLength - 1; i++) {
                sumApplyHours3 += getInt(tb.rows[i].cells[7].innerText);
            }
            //總計己領時數
            tb.rows[rowLength - 1].cells[3].innerText = sumApplyHours3;
        }

        function IsMatch(id, ChildId) {
            var sPattern = '^ctl00_ContentPlaceHolder1_gvList_.*_' + ChildId + '$';
            var oRegExp = new RegExp(sPattern);
            if (oRegExp.exec(id))
                return true;
            else
                return false;
        }
    </script>

    <table id="tbq" runat="server" cellpadding="0" cellspacing="0" width="99%" align="center">
        <tr>
            <td align="left" class="htmltable_Title2" colspan="2">條件畫面
            </td>
        </tr>
        <tr>
            <td class="htmltable_Right" width="25%">查詢年月</td>
            <td class="htmltable_Right" width="75%">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table width="100%"><tr>
                            <td><asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                            <td>年</td>
                            <td><asp:DropDownList ID="ddlMonth" runat="server"></asp:DropDownList></td>
                            <td>月</td>
                               </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td width="50%">
                            <asp:Button ID="Button2" runat="server" Text="回上頁" UseSubmitBehavior="false" OnClick="Button2_Click" /></td>
                        <td>
                            <asp:Button ID="cbQuery" runat="server" Text="查詢" UseSubmitBehavior="false" OnClick="cbQuery_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <table id="tbS" width="95%" runat="server" visible="false" align="center">
        <tr>
            <td width="40%">姓名</td>
            <td>
                <asp:Label ID="lbUserName" runat="server" ForeColor="#0000CC"></asp:Label></td>
        </tr>
        <tr>
            <td>每小時時薪</td>
            <td>
                <asp:Label ID="lbHourPay" runat="server" ForeColor="#0000CC"></asp:Label></td>
        </tr>
        <tr>
            <td>請領上限</td>
            <td>
                <asp:Label ID="lbLimit" runat="server" ForeColor="#0000CC"></asp:Label>小時</td>
        </tr>
        <tr>
            <td class="htmltable_Right" style="display: none; width: 180px">含假日請領上限</td>
            <td class="TdHeightLight" style="display: none; width: 150px">
                <asp:Label ID="lbLimit_H" runat="server"></asp:Label><asp:Label ID="lb1" runat="server"
                    Text="小時"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" valign="top" class="TdHeightLight">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                    PagerStyle-HorizontalAlign="Right" 
                    Width="100%" OnRowDataBound="gvList_RowDataBound" EnableModelValidation="True" 
                    CellPadding="3" onrowcreated="gvList_RowCreated" ShowHeader="False" 
                    ondatabound="gvList_DataBound" ShowFooter="True">                    
                    <Columns>
                        <asp:TemplateField>                    
                            <ItemTemplate>
                                <table width="100%" bgcolor="White" frame="box">
                                    <tr>                                  
                                        <td colspan="3">日期 : 
                                            <asp:Label ID="lblPRADDD" runat="server" Text='<%# Bind("PRADDD") %>' ForeColor="#0000CC"></asp:Label>
                                            ~
                                            <asp:Label ID="lblPRADDE" runat="server" Text='<%# Bind("PRADDE") %>' ForeColor="#0000CC"></asp:Label></td>
                                    </tr>
                                      <tr>                                        
                                        <td colspan="3">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                        </tr>
                                    <tr>
                                        <td colspan="3">事由 : 
                                            <asp:Label ID="lblPRREASON" runat="server" Text='<%# Bind("PRREASON") %>' ForeColor="#0000CC"></asp:Label></td>
                                    </tr>
                                      <tr>                                        
                                        <td colspan="3">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                        </tr>
                                    <tr>
                                        <td colspan="3"> 時間 : 
                                            <asp:Label ID="lblPRSTIME" runat="server" Text='<%# Bind("PRSTIME") %>' ForeColor="#0000CC"></asp:Label>
                                            ~
                                            <asp:Label ID="lblPRETIME" runat="server" Text='<%# Bind("PRETIME") %>' ForeColor="#0000CC"></asp:Label></td>
                                    </tr>
                                      <tr>                                        
                                        <td colspan="3">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                        </tr>
                                    <tr>
                                        <td>加班時數 :
                                            <asp:Label ID="lblPRADDH" runat="server" Text='<%# Bind("PRADDH") %>' ForeColor="#0000CC"></asp:Label></td>
                                        <td>已休時數 :
                                            <asp:Label ID="lblPRPAYH" runat="server" Text='<%# Bind("PRPAYH") %>' ForeColor="#0000CC"></asp:Label></td>
                                        <td>已領時數 :
                                            <asp:Label ID="lblPRMNYH" runat="server" Text='<%# Bind("PRMNYH") %>' ForeColor="#0000CC"></asp:Label></td>
                                    </tr>
                                      <tr>                                        
                                        <td colspan="3">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                        </tr>
                                    <tr>
                                        <td>延長工時1-2小時(1)<br />
                                            <asp:TextBox ID="tbApplyHour1" runat="server" Text='<%# Bind("Apply_Hour_1") %>'
                                                Width="50px"></asp:TextBox>
                                            <asp:HiddenField ID="hdApplyHour1" runat="server" Value='<%# Bind("Apply_Hour_1") %>' />
                                            <asp:HiddenField ID="hdOvertimeStart" runat="server" Value='<%# Bind("PRSTIME") %>' />
                                            <asp:HiddenField ID="hdOvertimeEnd" runat="server" Value='<%# Bind("PRETIME") %>' />
                                            <asp:HiddenField ID="hdPRATYPE" runat="server" Value='<%# Bind("PRATYPE") %>' />
                                        </td>
                                        <td>延長工時3-4小時(2)<br />
                                            <asp:TextBox ID="tbApplyHour2" runat="server" Text='<%# Bind("Apply_Hour_2") %>'
                                                Width="50px"></asp:TextBox><asp:HiddenField ID="hdApplyHour2" runat="server" Value='<%# Bind("Apply_Hour_2") %>' />
                                        </td>
                                        <td>假日加班1-8小時(3)<br />
                                            <asp:TextBox ID="tbApplyHour3" runat="server" Text='<%# Bind("Apply_Hour_3") %>'
                                                Width="50px"></asp:TextBox><asp:HiddenField ID="hdApplyHour3" runat="server" Value='<%# Bind("Apply_Hour_3") %>' />
                                        </td>
                                        
                                    </tr>
                                      <tr>                                        
                                        <td colspan="3">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                        </tr>
                                    <tr><td colspan="3">
                                        加班費<asp:Label ID="Overtime_Pay_Head" runat="server" Text=""></asp:Label> : 
                                        <asp:Label ID="lblOvertime_Pay" runat="server" Text='<%# Bind("Overtime_Pay") %>'></asp:Label></td></tr>
                                </table>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Apply_Hour_1") %>'></asp:TextBox>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Apply_Hour_2") %>'></asp:TextBox>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Apply_Hour_3") %>'></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                             <table width="100%" bgcolor="White" frame="box">
                             <tr>
                             <td colspan="3">
                             總計
                             </td>
                             </tr>
                               <tr>                                        
                                <td colspan="3">
                                    <div style="background: black; width: 100%; height: 1px"></div>
                                </td>
                                </tr>
                             <tr>
                             <td>加班時數 : 
                                <asp:Label ID="footPRADDH" runat="server" Text=""></asp:Label></td>
                             <td>已休時數 : 
                                <asp:Label ID="footPRPAYH" runat="server" Text=""></asp:Label></td>
                             <td>已領時數 : 
                                <asp:Label ID="footPRMNYH" runat="server" Text=""></asp:Label></td>
                              </tr>
                                <tr>                                        
                                <td colspan="3">
                                    <div style="background: black; width: 100%; height: 1px"></div>
                                </td>
                                </tr>
                                <tr>
                                <td>延長工時1-2小時(1) :
                                    <asp:Label ID="foot1" runat="server" Text=""></asp:Label>                               
                                </td>
                                <td>延長工時3-4小時(2) :
                                    <asp:Label ID="foot2" runat="server" Text=""></asp:Label>
                                </td>
                                <td>假日加班1-8小時(3) :
                                    <asp:Label ID="foor3" runat="server" Text=""></asp:Label>
                                </td>                                       
                                </tr>
                                <tr>                                        
                                <td colspan="3">
                                    <div style="background: black; width: 100%; height: 1px"></div>
                                </td>
                                </tr>
                                <tr>
                                <td colspan="3">
                                加班費 : 
                                    <asp:Label ID="foot4" runat="server" Text=""></asp:Label>
                                </td>
                                </tr>
                             </table>
                            </FooterTemplate>                           
                        </asp:TemplateField> 
                    </Columns>                    
                    <PagerStyle HorizontalAlign="Right" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        查無資料!
                    </EmptyDataTemplate>                   
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td width="50%">
                            <asp:Button ID="Button1" runat="server" Text="回上頁" UseSubmitBehavior="false" OnClick="Button1_Click1"/></td>
                        <td>
                            <asp:Button ID="toUpdate" runat="server" UseSubmitBehavior="False"
                    Text="確認" OnClick="toUpdate_Click" />
                        </td>
                    </tr>
                </table>
                <asp:Button ID="toCount" runat="server" Text="自動計算" Visible="false" OnClick="toCount_Click" />
                <input id="toReset" type="button" runat="server" value="重填"  Visible="false"/>
                <asp:Button ID="toPrint" runat="server"
                        Text="請領清冊" Visible="false" /><asp:Button ID="cbRTP2" runat="server"
                            Text="加班單明細" Visible="False" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdOrgcode" runat="server" />
    <asp:HiddenField ID="hdDepart_id" runat="server" />
    <asp:HiddenField ID="hdPerId" runat="server" />
    <asp:HiddenField ID="hdYear" runat="server" />
    <asp:HiddenField ID="hdMonth" runat="server" />
    <asp:HiddenField ID="hdPESEX" runat="server" EnableViewState="true" />
    <asp:HiddenField ID="hdPEKIND" runat="server" EnableViewState="true" />
</asp:Content>

