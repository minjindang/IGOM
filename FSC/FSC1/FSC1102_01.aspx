<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC1102_01.aspx.vb" Inherits="FSC_FSC1102_01" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UControl/UcTextBox.ascx" TagName="UcTextBox" TagPrefix="uc5" %>
<%@ Register Src="~/UControl/UcLeaveDate.ascx" TagName="UcLeaveDate" TagPrefix="uc7" %>
<%@ Register Src="~/UControl/FSC/UcAttachment.ascx" TagPrefix="uc6" TagName="UcAttachment" %>
<%@ Register Src="~/UControl/FSC/UcLeaveMember.ascx" TagName="UcLeaveMember" TagPrefix="uc3" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/FSC/UcLeaveDeputy.ascx" TagPrefix="uc2" TagName="UcLeaveDeputy" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        function showCityDDL() {
            var locations = document.getElementsByName('ctl00$ContentPlaceHolder1$rblLocationFlag')
            var s = document.getElementById('<%=ddlCity.ClientID%>')

            if (locations[0].checked) s.style.visibility = "visible";
            if (locations[1].checked) s.style.visibility = "hidden";
        }
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
        });
    </script>
    <table border = "1" cellpadding = "0" cellspacing = "0" width="100%" class="tableStyle99">    
        <tr>
            <td colspan="2" class="htmltable_Title">
                申請公差
            </td>
        </tr>
        <tr >
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>申請類別</td>
            <td class="htmltable_Right">            
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlLeave_type" runat="server" DataTextField="LeaveName" DataValueField="LeaveType">
                            <asp:ListItem Text="公差" Value="05"></asp:ListItem>
                            <%--<asp:ListItem Text="公出" Value="07"></asp:ListItem>--%>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>                    
        <tr>
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>公差類別</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rblLeave_ngroup" runat="server" RepeatDirection="Horizontal" DataSourceID="odsLeave_ngroup" DataTextField="Text" DataValueField="Value">
                </asp:RadioButtonList>
                <asp:ObjectDataSource ID="odsLeave_ngroup" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetLeaveNGroup" TypeName="SYS.Logic.LeaveNGroup">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlLeave_type" Name="Leave_type" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr >
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>申請人員</td>
            <td class="htmltable_Right">                
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <uc3:UcLeaveMember ID="UcLeaveMember" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>職務代理人</td>
            <td class="htmltable_Right"> 
                <uc2:UcLeaveDeputy runat="server" ID="UcLeaveDeputy" />
            </td>
        </tr>   
        <tr id="sigleDateTr1">
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>公差日期</td>
            <td class="htmltable_Right">
                <uc7:UcLeaveDate ID="UcLeaveDate" runat="server" />                    
            </td>                          
        </tr>
        <tr id="sigleDateTr2" >
            <td class="htmltable_Left" style="width:120px">
                假日執行<br />
                公務時間</td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <uc7:UcLeaveDate ID="UcHolidayDate" runat="server" IsDefault="false" />
                        <asp:CheckBox ID="hcbx" runat="server" Text="假日執行公務" AutoPostBack="True" OnCheckedChanged="hcbx_CheckedChanged" />
                        (請填入洽公或開會時間。)
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr id="multiDateTr1" style="display: none">
            <td class="htmltable_Left" colspan="2">
                <span style="color: #ff0000">*</span>公差日期</td>
        </tr>
        <tr id="multiDateTr2" style="display: none">
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
                                        <table>
                                            <tr>
                                                <td>公差日期</td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                            <uc7:UcLeaveDate ID="gv_UcLeaveDate" runat="server" IsDefault="false"
                                                                Start_date='<%# Bind("Start_date") %>' Start_time='<%# Bind("Start_time") %>'
                                                                End_date='<%# Bind("End_date") %>' End_time='<%# Bind("End_time") %>'  />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>假日執行公務時間</td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <uc7:UcLeaveDate ID="gv_UcHolidayDate" runat="server" IsDefault="false" 
                                                                Start_date='<%# Bind("Holiday_dateb")%>' Start_time='<%# Bind("Holiday_timeb")%>'
                                                                End_date='<%# Bind("Holiday_datee")%>' End_time='<%# Bind("Holiday_timee")%>'  />
                                                            <asp:CheckBox ID="gv_cbxholiday" runat="server" Text="假日執行公務" AutoPostBack="True" OnCheckedChanged="gv_cbxholiday_CheckedChanged" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
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
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>公差地點</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rblLocationFlag" runat="server" RepeatColumns="2">
                    <asp:ListItem Value="0" Text="國內" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="1" Text="國外"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:DropDownList ID="ddlCity" runat="server" DataTextField="code_desc1" DataValueField="code_no"></asp:DropDownList>
            </td>
        </tr>                                             
        <tr>
            <td class="htmltable_Left" style="width:120px">
                出差明細地點</td>
            <td class="htmltable_Right">
                <uc5:UcTextBox ID="UcDetailPlace" runat="server" MaxLength="100" TextMode="MultiLine" />
            </td>
        </tr>                                             
        <tr>
            <td class="htmltable_Left" style="width:120px">
                交通工具</td>
            <td class="htmltable_Right">
                <asp:CheckBoxList runat="server" ID="cbxlTransport" 
                    RepeatDirection="Horizontal"
                    DataTextField="code_desc1" DataValueField="code_no">
                </asp:CheckBoxList>
            </td>
        </tr>                                             
        <tr>
            <td class="htmltable_Left" style="width:120px">
                搭乘高鐵或飛機之理由說明</td>
            <td class="htmltable_Right">
                <uc5:uctextbox id="ucTransportDesc" runat="server" enableviewstate="true" maxlength="30" textmode="MultiLine" width="300"></uc5:uctextbox>
            </td>
        </tr>                                             
        <tr >
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>事由</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※輸入事由請勿超出30字"></asp:Label><br />
                <uc5:uctextbox id="tbReason" runat="server" enableviewstate="true" maxlength="30" textmode="MultiLine" width="300"></uc5:uctextbox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:120px">
                附件</td>
            <td class="htmltable_Right">
                <uc6:UcAttachment runat="server" ID="UcAttachment" />                 
            </td>
        </tr>                                                
        <tr>
            <td class="htmltable_Left" style="width:120px">
                假別說明</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbDesc" runat="server" /></td>
        </tr>
        <tr>
           <td colspan="2" class="htmltable_Bottom" >
               <asp:Button ID="cbSubmit" runat="server" Text="送出申請"/>
               <input id="cbReset" onclick="clearForm(this.form)" type="button" value="重填" />
                <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" Visible="false" />
           </td>
        </tr>                          
    </table>
    <asp:Label ID="lbErr" runat="server" Text="" ForeColor="red"></asp:Label>
</asp:Content>