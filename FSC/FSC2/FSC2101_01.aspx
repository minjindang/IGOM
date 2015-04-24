<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC2101_01.aspx.vb" Inherits="FSC2_FSC2101_01" %>

<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx"  TagName="UcDDLDepart" TagPrefix="uc1" %>
<%@ Register Src="~/UControl/FSC/UcAuthorityMember.ascx" TagPrefix="uc1" TagName="UcMember" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc1" TagName="UcDDLAuthorityMember" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" id="tQuery" runat="server" visible="false">
        <tr>
            <td class="htmltable_Title" colspan="4">
                �H���򥻸�Ƭd��
            </td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="4">
                �d�߱���
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                ���W��
            </td>
            <td class="htmltable_Right" style="width: 230px" colspan="3">
                <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                �H���m�W
            </td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <uc1:UcDDLAuthorityMember runat="server" ID="UcDDLAuthorityMember" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="htmltable_Left" style="width: 120px">
                ¾�����O
            </td>
            <td class="htmltable_Right" style="width: 230px">
                <asp:DropDownList ID="ddlTitle" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                ���u�s��
            </td>
            <td class="htmltable_Right" style="width: 230px">
                <uc1:UcMember runat="server" ID="UcMember" />
            </td>
            <td class="htmltable_Left" style="width: 120px">
                �b¾���A
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlWork" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4">
                <asp:Button ID="btnFind" runat="server" CausesValidation="False" Text="�d��" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Panel ID="pnlEdit" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
            <tr>
                <td class="htmltable_Title" colspan="5">
                    �H�����
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" width="15%">
                    �����Ҹ�
                </td>
                <td class="htmltable_Right" width="35%">
                    <asp:Label ID="lbId_number" runat="server" />
                </td>
                <td class="htmltable_Left" width="15%">
                    ���u�s��
                </td>
                <td class="htmltable_Right" width="35%">
                    <asp:Label ID="lbId_card" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">
                    �H���m�W
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbUser_Name" runat="server" />
                </td>
                <td class="htmltable_Left" style="width: 150px">
                    �D�޼h��
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbBossLevelID" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    �y�C�d��
                </td>
                <td class="htmltable_Right" colspan="3">
                    <asp:Label ID="lbYoyoCard" runat="server" />
                </td>
            </tr>
            <tr>
                    <td class="htmltable_Left" style="width: 150px">
                        AD�b��
                    </td>
                    <td class="htmltable_Right" style="width: 250px">
                        <asp:Label ID="lbADID" runat="server" />
                    </td>
                    <td class="htmltable_Left" style="width: 150px">
                        AD�K�X
                    </td>
                    <td class="htmltable_Right">
                        <asp:Label ID="lbUser_password" runat="server" />
                    </td>
                </tr>
                <tr id="tr8" runat="server">
                    <td class="htmltable_Left" style="width: 150px">
                        �q�l�l��
                    </td>
                    <td class="htmltable_Right">
                        <asp:Label ID="lbEmail" runat="server" />
                    </td>
                    <td class="htmltable_Left" style="width: 150px">
                        �ثe¾��
                    </td>
                    <td class="htmltable_Right">
                        <asp:Label ID="lbTitleNo" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left" style="width: 150px">
                        �����q��
                    </td>
                    <td class="htmltable_Right">
                        <asp:Label ID="lbLivePhone" runat="server" />
                    </td>
                    <td class="htmltable_Left" style="width: 150px">
                        �줽�ǹq��
                    </td>
                    <td class="htmltable_Right">
                        <asp:Label ID="lbOfficeTel" runat="server" />
                        ����
                        <asp:Label ID="lbOfficeExt" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left" style="width: 150px">
                        �t�ԲէO
                    </td>
                    <td class="htmltable_Right">
                        <asp:Label ID="lbPEKIND" runat="server" />
                    </td>
                    <td class="htmltable_Left" style="width: 150px">
                        �W�Z�O
                    </td>
                    <td class="htmltable_Right">
                        <asp:Label ID="lbPEWKTYPE" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left" style="width: 150px">
                        �ʧO
                    </td>
                    <td class="htmltable_Right">
                        <asp:Label ID="lbPESEX" runat="server" />
                    </td>
                    <td class="htmltable_Left" style="width: 150px">
                        �X�ͦ~���
                    </td>
                    <td class="htmltable_Right">
                        <asp:Label ID="lbPEBIRTHD" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left" style="width: 150px">
                        �x¾��
                    </td>
                    <td class="htmltable_Right">
                        <asp:Label ID="lbPECRKCOD" runat="server" />
                    </td>
                    <td class="htmltable_Left" style="width: 150px">
                        ¾�����O
                    </td>
                    <td class="htmltable_Right">
                        <asp:Label ID="lbPEMEMCOD" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left" style="width: 150px">
                        ���I
                    </td>
                    <td class="htmltable_Right">
                        <asp:Label ID="lbPEPOINT" runat="server" />
                    </td>
                    <td class="htmltable_Left" style="width: 150px">
                        �M�~�[��
                    </td>
                    <td class="htmltable_Right">
                        <asp:Label ID="lbPEPROFESS" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left" style="width: 150px">
                        �D��¾�ȥ[��
                    </td>
                    <td class="htmltable_Right">
                        <asp:Label ID="lbPECHIEF" runat="server" />
                    </td>
                    <td class="htmltable_Left" style="width: 150px">
                        �~��O
                    </td>
                    <td class="htmltable_Right">
                        <asp:Label ID="lbPEYKIND" runat="server" />
                    </td>
                </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">
                    ��¾��
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbPEACTDATE" runat="server" />
                </td>
                <td class="htmltable_Left" style="width: 150px">
                    �����¾��
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbJoinDate" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">
                    ��¾���
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbPELEVDATE" runat="server" />
                </td>
                <td class="htmltable_Left" style="width: 150px">
                    �n�J����
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbLoginType" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">
                    �𰲦~��p��_��
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbYearStartDate" runat="server" Width="100px" />
                </td>
                <td class="htmltable_Left" style="width: 150px">
                    �ư��Ѽ�
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbPEHDAY2" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">
                    �𰲦~��
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbYear" runat="server" Width="100px" />
                </td>
                <td class="htmltable_Left" style="width: 150px">
                    ���~�𰲤Ѽ�
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="txtPEHDAY" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 160px">
                    �d¾���~�~��
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbChgCntYear2" runat="server" />
                </td>
                <td class="htmltable_Left" style="width: 160px">
                    ���ʦ~��
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbChgYear" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">
                    ���`�~��
                </td>
                <td class="htmltable_Right" colspan="3">
                    <asp:Label ID="lbTotalYear" runat="server" />
                </td>
            </tr>
            <tr class="">
                <td class="htmltable_Left" style="width: 150px">
                    �e�@�~�O�d�Ѽ�
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbPerday1" runat="server" />
                </td>
                <td class="htmltable_Left" style="width: 150px">
                    �e��~�O�d�Ѽ�
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbPerday2" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 150px">
                    �O�_�i�ϥΤH������
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbSyslogin" runat="server" />
                </td>
                <td class="htmltable_Left" style="width: 150px">
                    �O�_���ȯZ�H��
                </td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbOnDuty" runat="server" />
                </td>
            </tr>
        </table>
        <br />
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
            <tr>
                <td colspan="4">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                        <tr>
                            <td class="htmltable_Title" colspan="4">
                                ���u�ӤH²��
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left" style="width: 120px">
                                �ۭz
                            </td>
                            <td class="htmltable_Right" style="width: 230px">
                                <asp:TextBox ID="txtIntro_desc" runat="server" Rows="5" TextMode="MultiLine" Width="90%" ReadOnly="true" />
                            </td>
                            <td class="htmltable_Left" style="width: 120px">
                                �M��
                            </td>
                            <td class="htmltable_Right" style="width: 230px">
                                <asp:TextBox ID="txtSkill_desc" runat="server" Rows="5" TextMode="MultiLine" Width="90%" ReadOnly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left" style="width: 120px">
                                ����
                            </td>
                            <td class="htmltable_Right" style="width: 230px">
                                <asp:TextBox ID="txtSpecialty_desc" runat="server" Rows="5" TextMode="MultiLine" Width="90%" ReadOnly="true" />
                            </td>
                            <td class="htmltable_Left" style="width: 120px">
                                �߱��P��
                            </td>
                            <td class="htmltable_Right" style="width: 230px">
                                <asp:TextBox ID="txtMood_desc" runat="server" Rows="5" TextMode="MultiLine" Width="90%" ReadOnly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left" style="width: 120px">
                                �Ӥ�
                            </td>
                            <td class="htmltable_Right" style="width: 230px" colspan="3">
                                <asp:Image ID="imgPic" runat="server" Width="80px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlQuery" runat="server" Visible="False">
        <table id="tbQ" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
            <tr>
                <td class="htmltable_Title2" style="width: 100%" align="center">
                    �d�ߵ��G
                </td>
            </tr>
            <tr>
                <td style="width: 100%;" class="TdHeightLight" colspan="2">
                    <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                        AllowPaging="True" PageSize="30" CssClass="Grid" PagerStyle-HorizontalAlign="Right"
                        Width="100%" EmptyDataText="�d�L���!" EmptyDataRowStyle-ForeColor="Red" EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField HeaderText="����" DataField="RowNO" />
                            <asp:TemplateField HeaderText="���W��">
                                <ItemTemplate>
                                    <asp:Label ID="QDepart_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Depart_name")%>'></asp:Label>
                                    <asp:HiddenField ID="QDepart_ID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Depart_ID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="�H���m�W">
                                <ItemTemplate>
                                    <asp:Label ID="QUser_name" runat="server" Text='<%# Bind("User_name") %>'></asp:Label>,
                                    <asp:Label ID="Qid_card" runat="server" Text='<%# Bind("id_card") %>'></asp:Label>,
                                    <asp:Label ID="Qad_id" runat="server" Text='<%# Bind("ADID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="�H�����O">
                                <ItemTemplate>
                                    <asp:Label ID="QPEMEMCOD" runat="server" Text='<%# Bind("PEMEMCOD")%>'></asp:Label>
                                    <asp:HiddenField ID="QEmployee_type" runat="server" Value='<%# Bind("Employee_type")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="�\��" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Button ID="btnPrint" runat="server" Text="�˵�" OnClick="btnPrint_Click" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" />
                        <EmptyDataTemplate>
                            �d�L���!!
                        </EmptyDataTemplate>
                        <RowStyle CssClass="Row" />
                        <AlternatingRowStyle CssClass="AlternatingRow" />
                        <PagerSettings Position="TopAndBottom" />
                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="right" class="TdHeightLight">
                    <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvResult" PNow="1" PSize="30" Visible="true" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
