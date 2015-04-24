<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC2123_01.aspx.vb" Inherits="FSC2123_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register src="~/UControl/UcShowDate.ascx" tagname="UcShowDate" tagprefix="uc3" %>
<%@ Register src="~/UControl/UcShowTime.ascx" tagname="UcShowTime" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        function checkCheckBox(cbxid, tbid) {
            var cbx = document.getElementById(cbxid);
            var tb = document.getElementById(tbid);
            var checkBoxs = tb.getElementsByTagName('INPUT');
            for (var i = 0; i < checkBoxs.length; i++) {
                if (checkBoxs[i].type == 'checkbox')
                    checkBoxs[i].checked = cbx.checked;
            }
        }
    </script>
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">
                            ���d�Գ�
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">
                            <asp:UpdatePanel ID="UpdatePanel0" runat="server">
                                <ContentTemplate>
                                    ���W��(<asp:CheckBox ID="cbxDepALL" runat="server" Text="����"></asp:CheckBox>) 
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </td>
                        <td class="htmltable_Right" colspan="3">
                          <asp:CheckBoxList id="cblDeparts" runat="server" RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="5" DataValueField="Depart_id" DataTextField="Depart_name">
                           </asp:CheckBoxList>
                        </td>
                    </tr>

             
                    <tr>
                        <td class="htmltable_Left" style="width: 100px"><span style="color:Red">*</span>�d�Ԥ��</td>
                            <td class="TdHeightLight">
                            <uc2:UcDate ID="UcDate1" runat="server" />
                            <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="����g�d��:101/01/01"></asp:Label>
                        </td>
                    </tr>
                               

                    <tr>
                        <td align="center" colspan="4" class="TdHeightLight">
                            <asp:Button ID="btnQuery" runat="server" Text="�d��" UseSubmitBehavior="false" />
                            <asp:Button ID="btnExport" runat="server" Enabled="false" Text="�ץX" />
                        </td>
                    </tr>
                    
                </table>
           </td>
        </tr>
        <tr>
            <td style="height: 358px" valign="top">
                <table id="tbq" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
                    visible="false" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title2" style="width: 100%" align="center">
                            �d�ߵ��G
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%" class="TdHeightLight" valign="top">
                            <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="false" BorderWidth="0px" PageSize="30"
                                AllowPaging="true" CssClass="Grid" PagerStyle-HorizontalAlign="right" Width="100%"
                                EmptyDataText="�d�L���!!">
                                <Columns>
                                    <asp:TemplateField HeaderText="����">
                                        <ItemStyle HorizontalAlign="Center" Width="15px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (container.dataitemindex+1).tostring() %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���W��">
                                        <ItemStyle HorizontalAlign="Center" Width="160px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbDepart_name" runat="server" Text='<%# Eval("Depart_name")%>'></asp:Label>
                                            <asp:HiddenField ID="lbDepart_id" runat="server" value='<%# Eval("Depart_id")%>'></asp:HiddenField>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�d�Ԥ��">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbStart_date" runat="server" Text='<%# Eval("Start_date")%>'></asp:Label><br />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���{���H��">
                                        <ItemStyle HorizontalAlign="Center" Width="175px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbtotal" runat="server" Text='<%# Eval("total")%>'></asp:Label><br />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="�а��H��">
                                        <ItemStyle HorizontalAlign="Center" Width="145px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="45px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbleave" runat="server" Text='<%# Bind("leave")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�X�t�H��">
                                        <ItemStyle HorizontalAlign="Center" Width="145px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="45px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbbusiness" runat="server" Text='<%# Bind("business")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�[�Z�H��">
                                        <ItemStyle HorizontalAlign="Center" Width="145px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="45px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbwork" runat="server" Text='<%# Bind("work")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�ɥ�H��">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbrest" runat="server" Text='<%# Bind("rest")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�\��">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Button ID="btnLook" runat="server" Text="�˵�" OnClick="btnLook_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                             
                                
                                            </Columns>
                                <pagerstyle horizontalalign="Right" />
                                            <emptydatatemplate>
                                    �d�L���!!
                                </emptydatatemplate>
                                            <rowstyle cssclass="Row" />
                                            <headerstyle cssclass="Grid" />
                                            <alternatingrowstyle cssclass="AlternatingRow" />
                                <PagerSettings Position="TopAndBottom" />
                                <EmptyDataRowStyle CssClass="EmptyRow" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TdHeightLight" style="width: 100%">
                            <uc1:Ucpager ID="Ucpager" runat="server" EnableViewState="true" GridName="gvlist"
                                PNow="1" PSize="30" Visible="true" />
                        </td>
                    </tr>       
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
