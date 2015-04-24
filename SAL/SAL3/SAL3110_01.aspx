<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="SAL3110_01.aspx.vb" Inherits="SAL3110_01" %>

<%@ Register Src="~/UControl/UcROCMonth.ascx" TagName="UcROCRocMonth" TagPrefix="uc2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        function Check(parentChk, ChildId) {
            var oElements = document.getElementsByTagName("INPUT");

            for (i = 0; i < oElements.length; i++) {
                if (IsCheckBox(oElements[i]) && IsMatch(oElements[i].id, ChildId)) {
                    oElements[i].checked = parentChk;
                }
            }
        }
        function IsMatch(id, ChildId) {
            var sPattern = '^ctl00_ContentPlaceHolder1_gv_.*' + ChildId + '$';
            var oRegExp = new RegExp(sPattern);
            if (oRegExp.exec(id))
                return true;
            else
                return false;
        }
        function IsCheckBox(chk) {
            if (chk.type == 'checkbox') return true;
            else return false;
        }
    </script>

    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">生日禮券發放作業</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">請選擇起迄日</td>
            <td class="htmltable_Right" style="width: 300px">
                <uc2:UcROCRocMonth ID="UcDate1" runat="server" />～<uc2:UcROCRocMonth ID="UcDate2" runat="server" />
            </td>
            <td class="htmltable_Left" style="width: 120px">快速填入金額</td>
            <td class="htmltable_Right" style="width: 350px">
                <asp:TextBox ID="txtamt" runat="server"></asp:TextBox>
<%--                <asp:DropDownList runat="server" ID="ddlInputAmt">
                    <asp:ListItem Text="1600" Value="1600"></asp:ListItem>
                    <asp:ListItem Text="2600" Value="2600"></asp:ListItem>
                </asp:DropDownList>--%>
                <asp:Button ID="btn_set" runat="server" Text=" 一次填入金額 " />
            </td>
                
        </tr>
        <%--   <tr>
            <td class="htmltable_Left">請選擇列印項目</td>
            <td class="htmltable_Right" colspan="3">
                <asp:UpdatePanel ID="panel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:CheckBox ID="cbselectAll" runat="server" Text="全選" onclick="javascript:SelectAllCheckboxes(this);" />
                        <asp:DropDownList runat="server" ID="ddlPrint" AutoPostBack="true">
                            <asp:ListItem Text="生日禮券發放清單一" Value="001"></asp:ListItem>
                            <asp:ListItem Text="生日禮券發放清單二" Value="002"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button runat="server" Text=" 列印 " />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>--%>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                <asp:Button ID="btn_search" runat="server" Text="查詢" />
                <asp:Button ID="btn_submit" runat="server" Text="成批送出" />
            </td>
        </tr>
    </table>
    <div id="div1" runat="server">
        <input id="Button1" onclick="Check(true, 'gv_cbx')" type="button" value="全選" />
        <input id="Button2" onclick="Check(false, 'gv_cbx')" type="button" value="全不選" />
        <asp:Button ID="btn_Excel" runat="server" Text="列印" />
        <asp:GridView ID="gv" runat="server" CssClass="Grid"
            AutoGenerateColumns="False" DataKeyNames="id_card"
            AllowPaging="True" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:TemplateField HeaderText="選取">
                    <ItemTemplate>
                        <asp:CheckBox ID="gv_cbx" runat="server" />
                    </ItemTemplate>
                    <HeaderStyle></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" ></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="單位">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle  />
                    <ItemTemplate>
                        <asp:Label ID="lbDepart_name" runat="server" Text='<%# Eval("Depart_name")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="科室">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle  />
                    <ItemTemplate>
                        <asp:Label ID="lbSub_depart_name" runat="server" Text='<%# Eval("Sub_depart_name")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="姓名">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle  />
                    <ItemTemplate>
                        <asp:Label ID="lbUser_name" runat="server" Text='<%# Eval("User_name")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="員工編號">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle  />
                    <ItemTemplate>
                        <asp:Label ID="lbPersonnel_id" runat="server" Text='<%# Eval("id_card")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="生日">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle  />
                    <ItemTemplate>
                        <asp:Label ID="lbbirth_date" runat="server" Text='<%# Eval("birth_date")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="發放金額">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle  />
                    <ItemTemplate>
                        <asp:TextBox ID="txtamt" Style="text-align: right" runat="server" Text='<%# Eval("pay_amt")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="維護">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle  />
                    <ItemTemplate>
                        <asp:Button ID="bntPrint" runat="server" Text="列印" OnClick="bntPrint_Click" />
                    </ItemTemplate>
                </asp:TemplateField>

                <%-- <asp:TemplateField HeaderText="維護" Visible="true">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle  Width="25%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Button ID="Button_set_P" runat="server" Text="維護" CausesValidation="false"
                                    CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" CommandName="EditX" />
                                <asp:Button ID="Button2" runat="server" Text="刪除" CausesValidation="false" Visible="true" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" CommandName="ClearX" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
    </div>
</asp:Content>
