<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC1108_01.aspx.vb" Inherits="FSC1108_01" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <script type="text/javascript">
            function showDiv(divid) {
                document.getElementById(divid).style.display = "";
            }
        </script>
        <div id="div1" style="display:none;position:absolute;top: 40%; left: 40%;">
             <table id="table" style="background-color:gray" border = '1' cellpadding="0" cellspacing ="0" width="50%">
                 <tr><td align="right"><asp:Button ID="closeDiv" runat="server" Text="X" /></td></tr>
                 <tr>
                     <td><asp:label ID="lbMsg" runat="server" Text="測試用2" /></td>
                 </tr>
             </table>
        </div>
        <div id="div2" style="display:none;position:absolute;top: 40%; left: 40%;">
             <table id="table1" style="background-color:gray" border = '1' cellpadding="0" cellspacing ="0" width="50%">
                 <tr><td align="right"><asp:Button ID="closeDiv2" runat="server" Text="X" /></td></tr>
                 <tr>
                     <td><asp:label ID="lbMsg2" runat="server" Text="xx" /></td>
                 </tr>
             </table>
        </div>

    <table id="tb" border="1" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="6">敘獎申請作業</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>提報單位</td>
            <td class="htmltable_Right" colspan="3">
                <asp:DropDownList ID="ddlDept" runat="server" />
            </td>
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>提報日期</td>
            <td class="htmltable_Right">
                <uc1:UcDate runat="server" ID="UcApplyDate" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>敘獎事由</td>
            <td class="htmltable_Right" colspan="5">
                <asp:TextBox ID="tbReason" runat="server" Rows="5" TextMode="MultiLine" Width="600" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>適用事由類別</td>
            <td class="htmltable_Right" colspan="5">
                <asp:RadioButton ID="rbReason_type1" GroupName="Reason_type" runat="server" Checked="true" />
                依「行政院環境保護署所屬人員提報敘獎原則」
                第<asp:TextBox ID="tbReason_point" runat="server" Width="60" MaxLength="3" />點
                第<asp:TextBox ID="tbReason_section" runat="server" Width="60" MaxLength="3" />項
                第<asp:TextBox ID="tbReason_item" runat="server" Width="60" MaxLength="3" />款
                第<asp:TextBox ID="tbReason_list" runat="server" Width="60" MaxLength="3" />目
                規定辦理。
                <input type="button" id="btn1" onclick="javascript: location.href = '../../OnlineHelp/FSC/FSC1/提報敘獎原則.doc'" value="敘獎原則" /><br />
                <asp:RadioButton ID="rbReason_type2" GroupName="Reason_type" runat="server" />
                其他〈相關法令、計畫或評比定有明確獎勵標準者，請檢附相關規定並敘明〉。
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>自評點數</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbSelfpoint" runat="server" Text="0"  Width="60" MaxLength="3" />點
            </td>
            <td class="htmltable_Left" style="width: 120px">
                &nbsp 最近一次<br /><span style="color: #ff0000">*</span>相關案例<br />&nbsp 敘獎點數</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbLastpoint" runat="server" Text="0"  Width="60" MaxLength="3" />點
            </td>
            <td class="htmltable_Left" style="width: 120px">
                &nbsp 最近一次<br /><span style="color: #ff0000">*</span>相關案例<br />&nbsp 辦理日期<br />&nbsp 及事由</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbLastdatereason" runat="server" Rows="5" TextMode="MultiLine" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" colspan="6">考量因素</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>投入人力</td>
            <td class="htmltable_Right" colspan="5">
                一、人數：<asp:TextBox ID="tbInput_manpower" runat="server" Width="60" MaxLength="3" />人<br />
                二、辦理情形：<br />
                <asp:RadioButton ID="rbInput_manpower_type1" GroupName="Input_manpower_type" runat="server" Checked="true" />自辦<br />
                <asp:RadioButton ID="rbInput_manpower_type2" GroupName="Input_manpower_type" runat="server" />
                委辦〈請說明分工項目，例：場地佈置委由廠商辦理，餘自辦〉備註說明：
                <asp:TextBox ID="tbInput_manpower_note" runat="server" Width="400px" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>投入時間</td>
            <td class="htmltable_Right" colspan="5">
                一、投入期間：<uc1:UcDate runat="server" ID="UcInput_sdate" />至<uc1:UcDate runat="server" ID="UcInput_edate" /><br />
                二、是否符合提報敘獎期限：<br />
                <asp:RadioButton ID="rbinput_conform1" GroupName="input_conform" runat="server" Checked="true" />符合〈敘獎原則第五點〉<br />
                <asp:RadioButton ID="rbinput_conform2" GroupName="input_conform" runat="server" />
                未符合〈請敘明理由〉理由：
                <asp:TextBox ID="tbinput_notconform_reason" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>創新性</td>
            <td class="htmltable_Right" colspan="5">
                <asp:TextBox ID="tbInnovative_desc" runat="server" Rows="5" TextMode="MultiLine"  Width="600" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>困難度</td>
            <td class="htmltable_Right" colspan="5">
                <asp:TextBox ID="tbDifficulty_desc" runat="server" Rows="5" TextMode="MultiLine"  Width="600" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>貢獻度(成效)</td>
            <td class="htmltable_Right" colspan="5">
                <asp:TextBox ID="tbContribution_desc" runat="server" Rows="5" TextMode="MultiLine"  Width="600" />
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False"
                            width="100%" CssClass="Grid" Borderwidth="0px" PagerStyle-HorizontalAlign="Right">
                            <Columns>
                                <asp:TemplateField HeaderText="項次">
                                    <ItemTemplate>
                                        <asp:Label ID="gv_lbNum" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="獎懲建議">
                                    <ItemTemplate>
                                        <table border="1" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                                            <tr>
                                                <td class="htmltable_Left">
                                                    單位</td>
                                                <td class="htmltable_Right">
                                                    <uc1:UcDDLDepart runat="server" ID="gv_UcDDLDepart" OnSelectedIndexChanged="gvddlDepart_id_SelectedIndexChanged" AutoPostBack="true" />
                                                    <asp:Label ID="gv_lbDepart" runat="server" Text='<%# Bind("Depart_id")%>' Visible="false" />
                                                </td>
                                                <td class="htmltable_Left">
                                                    姓名</td>
                                                <td class="htmltable_Right">
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="gv_ddlName" runat="server" OnSelectedIndexChanged="gvddlName_SelectedIndexChanged" AutoPostBack="true" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <asp:Label ID="gv_lbIdcard" runat="server" Text='<%# Bind("id_card")%>' Visible="false" />
                                                </td>
                                                <td class="htmltable_Left">
                                                    職稱</td>
                                                <td class="htmltable_Right">
                                                    <asp:Label ID="gv_lbTitleName" runat="server" Text='<%# Bind("TitleName") %>' />
                                                </td>
                                                <td class="htmltable_Left">
                                                    人員類別</td>
                                                <td class="htmltable_Right">
                                                    <asp:Label ID="gv_lbEmployee_type" runat="server" Text='<%# Bind("Employee_type_name") %>' />
                                                </td>
                                                <td class="htmltable_Left">
                                                    官職等</td>
                                                <td class="htmltable_Right">
                                                    <asp:Label ID="gv_lblevel" runat="server" Text='<%# Bind("Level") %>' Visible="false" />
                                                    <asp:Label ID="gv_lblevel_name" runat="server" Text='<%# Bind("Level_name") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="htmltable_Left">
                                                    獎懲種類</td>
                                                <td class="htmltable_Right" colspan="3">
                                                    <asp:DropDownList ID="gv_ddlReword_type" runat="server" OnSelectedIndexChanged="gvddlReword_type_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                    <asp:Label ID="gv_lbReword_type" runat="server" Text='<%# Bind("Reword_type")%>' Visible="false" />
                                                </td>
                                                <td class="htmltable_Left">
                                                    依據條款</td>
                                                <td class="htmltable_Right" colspan="5">
                                                    <asp:TextBox ID="gv_tbAccording_Clause" runat="server" Text='<%# Bind("According_Clause") %>' Rows="2" TextMode="MultiLine" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="htmltable_Left">
                                                    具體事蹟</td>
                                                <td class="htmltable_Right" colspan="3">
                                                    <asp:TextBox ID="gv_tbSpecific_facts" runat="server" Text='<%# Bind("Specific_facts") %>' Rows="2" TextMode="MultiLine" Width="300px" MaxLength="100" />
                                                </td>
                                                <td class="htmltable_Left">
                                                    備註</td>
                                                <td class="htmltable_Right" colspan="5">
                                                    <asp:TextBox ID="gv_tbReword_note" runat="server" Text='<%# Bind("Reword_note") %>' MaxLength="100" Rows="2" TextMode="MultiLine" />
                                                </td>
                                            </tr>
                                        </table> 
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="功能">
                                    <ItemTemplate>
                                        <asp:Button ID="gv_btnInsert" runat="server" Text="插入" OnClick="doJoin" />
                                        <asp:Button ID="gv_btnDelete" runat="server" Text="刪除" OnClick="doDelete" /><br />
                                        <input type="button" id="gv_btn" onclick="javascript: location.href = '../../OnlineHelp/FSC/FSC1/敍獎相關規定.docx'" value="相關規定" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="6" style="border-top: none;">
                <asp:Button ID="cbSubmit" runat="server" Text=" 送出申請 " OnClientClick="if(!confirm('是否已請列印自評表!')) return false;" />
                <input id="cbReset" type="button" value="重填" onclick="clearForm(this.form)" />
                <asp:Button ID="cbExcel" runat="server" Text="匯出" />
                <asp:Button ID="cbSaave" runat="server" Text="暫存" OnClick="cbSaave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

