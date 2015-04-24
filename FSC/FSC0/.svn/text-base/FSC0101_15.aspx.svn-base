<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0101_15.aspx.vb" Inherits="FSC0101_15" %>

<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc1" TagName="UcFlowDetail" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td class="htmltable_Title" colspan="2">表單明細</td>
        </tr>
        <tr>
            <td class="htmltable_Left">表單編號</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbFlow_id" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="border-bottom: none;">表單申請人</td>
            <td class="htmltable_Right" style="border-bottom: none;">
                <asp:Label ID="lbApply_name" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">表單填寫人</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbWrite_name" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">申請項目</td>
            <td class="htmltable_Right">敘獎申請
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">填單日期</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbWrite_time" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">批核日期</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbAgree_time" runat="server" />
            </td>
        </tr>
        <%--敘獎資料明細區--%>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <table id="tb" border="1" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="htmltable_Left" style="width: 120px">提報單位
                        </td>
                        <td class="htmltable_Right">
                            <asp:Label ID="lbDepart_name" runat="server" />
                        </td>
                        <td class="htmltable_Left" style="width: 120px">提報日期
                        </td>
                        <td class="htmltable_Right">
                            <asp:Label ID="lbApply_date" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 120px">敘獎事由
                        </td>
                        <td class="htmltable_Right">
                            <asp:Label ID="lbReason" runat="server" />
                        </td>
                        <td class="htmltable_Left" style="width: 120px">適用事由類別
                        </td>
                        <td class="htmltable_Right" colspan="5">
                            <asp:Label ID="lbReason_type" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 120px">自評點數
                        </td>
                        <td class="htmltable_Right" colspan="3">
                            <asp:Label ID="lbSelf_ssessment_point" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 120px">最近一次相關案例<br />
                            敘獎點數
                        </td>
                        <td class="htmltable_Right">
                            <asp:Label ID="lbLast_point" runat="server" />
                        </td>
                        <td class="htmltable_Left" style="width: 120px">最近一次<br />
                            相關案例<br />
                            辦理日期<br />
                            及事由
                        </td>
                        <td class="htmltable_Right">
                            <asp:Label ID="lbLast_datereason" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" colspan="6">考量因素</td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 120px">投入人力</td>
                        <td class="htmltable_Right" colspan="5">一、人數：<asp:Label ID="lbInput_manpower" runat="server" /><br />
                            二、辦理情形：<br />
                            <asp:Label ID="lbInput_manpower_type" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 120px">投入時間
                        </td>
                        <td class="htmltable_Right" colspan="5">一、投入期間：<asp:Label ID="lbInput_sdate" runat="server" />至<asp:Label ID="lbInput_edate" runat="server" /><br />
                            二、是否符合提報敘獎期限：<asp:Label ID="lbinput_conform" runat="server" /><br />
                            <asp:Label ID="lbinput_notconform" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 120px">創新性
                        </td>
                        <td class="htmltable_Right" colspan="5">
                            <asp:Label ID="lbInnovative_desc" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 120px">困難度
                        </td>
                        <td class="htmltable_Right" colspan="5">
                            <asp:Label ID="lbDifficulty_desc" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 120px">貢獻度(成效)
                        </td>
                        <td class="htmltable_Right" colspan="5">
                            <asp:Label ID="lbContribution_desc" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 120px" colspan="6">獎懲建議
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="Grid" BorderWidth="0px" PagerStyle-HorizontalAlign="Right">
                                <Columns>
                                    <asp:TemplateField HeaderText="項次">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_lbNum" runat="server" Text='<%# Bind("RowNum")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="單位">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_lbDepart" runat="server" Text='<%# Bind("Depart_name")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="姓名">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_ddlName" runat="server" Text='<%# Bind("Reword_username")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="職稱">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_lbTitleName" runat="server" Text='<%# Bind("Title_no")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="人員類別">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_lbEmployee_type" runat="server" Text='<%# Bind("Employee_type")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="官職等">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_lblevel" runat="server" Text='<%# Bind("LevelS")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="獎懲種類">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_lbReword_type" runat="server" Text='<%# Bind("Ntype")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="依據條款">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_tbAccording_Clause" runat="server" Text='<%# Bind("According_Clause") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="具體事蹟">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_tbSpecific_facts" runat="server" Text='<%# Bind("Specific_facts") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="備註">
                                        <ItemTemplate>
                                            <asp:Label ID="gv_tbReword_note" runat="server" Text='<%# Bind("Reword_note") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
    </table>
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
