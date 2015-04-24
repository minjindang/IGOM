<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC3109_01.aspx.vb" Inherits="FSC3109_01" %>

<%@ Register src="../../UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc2" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
           var sPattern = '^ctl00_ContentPlaceHolder1_.*' + ChildId + '$';
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
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">大批請假</td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="4">查詢條件</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">單位名稱</td>
            <td class="htmltable_Right" style="width: 230px">
                <uc2:UcDDLDepart runat="server" ID="UcDDLDepart" />
            </td>
            <td class="htmltable_Left" style="width: 120px">人員姓名
            </td>
            <td class="htmltable_Right" style="width: 230px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlName" runat="server" DataTextField="User_name" DataValueField="id_Card">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">人員類別</td>
            <td class="htmltable_Right" style="width: 230px" colspan="3" >
                <asp:DropDownList ID="ddlEmployee_type" runat="server" DataTextField="CODE_DESC1" DataValueField="CODE_NO" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">假別</td>
            <td class="htmltable_Right" colspan="3">
                <asp:CheckBoxList ID="cblleave_types" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
                    <asp:ListItem Value="15">公傷假</asp:ListItem>
                    <asp:ListItem Value="16">延長病假</asp:ListItem>
                    <asp:ListItem Value="18">防災假</asp:ListItem>
                    <asp:ListItem Value="23">器官捐贈假</asp:ListItem>
                    <asp:ListItem Value="06">公假/公出</asp:ListItem>
                    <asp:ListItem Value="01">事假</asp:ListItem>
                    <asp:ListItem Value="02">病假</asp:ListItem>
                    <asp:ListItem Value="03">休假</asp:ListItem>
                    <asp:ListItem Value="04">加班假</asp:ListItem>
                    <asp:ListItem Value="08">婚假</asp:ListItem>
                    <asp:ListItem Value="09">娩假</asp:ListItem>
                    <asp:ListItem Value="10">喪假</asp:ListItem>
                    <asp:ListItem Value="13">流產假</asp:ListItem>
                    <asp:ListItem Value="20">出差補休</asp:ListItem>
                    <asp:ListItem Value="32">值班補休</asp:ListItem>
                    <asp:ListItem Value="34">五一勞動節</asp:ListItem>
                    <asp:ListItem Value="25">家庭照顧假</asp:ListItem>
                    <asp:ListItem Value="21">產前假</asp:ListItem>
                    <asp:ListItem Value="22">陪產假</asp:ListItem>
                    <asp:ListItem Value="24">生理假</asp:ListItem>
                </asp:CheckBoxList>
            </td>

        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">請假期間</td>
            <td class="htmltable_Right">
                <uc2:UcDate ID="UcDate1" runat="server" />
                &nbsp;~
                <uc2:UcDate ID="UcDate2" runat="server" />
                <br />
                <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
            </td>
            <td class="htmltable_Left" style="width: 150px">是否撤單</td>
            <td class="htmltable_Right">
                <asp:CheckBox ID="cbxCancel" runat="server" Text="是" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4">
                <asp:Button ID="btnFind" runat="server" CausesValidation="False" Text="查詢" />
                <input type="button" value="重填" />
                <asp:Button ID="cbAdd" runat="server" CausesValidation="False" Text="新增" />
            </td>
        </tr>
    </table>
    <br />
    <table id="tbQ" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" visible="false">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">查詢結果</td>
        </tr>
        <tr>
            <td>
                <input id="Button1" type="button" value="全選" onclick="Check(true, 'cbx')" />
                <input id="Button2" type="button" value="全不選" onclick="Check(false, 'cbx')" />
                <asp:Button ID="cbBatchCancel" runat="server" CausesValidation="False" Text="撤單" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%;" class="htmltable_Right" colspan="2">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" BorderWidth="0px" AllowPaging="True" PageSize="30"
                    CssClass="Grid" PagerStyle-HorizontalAlign="Right" Width="100%" EmptyDataText="查無資料!" EmptyDataRowStyle-ForeColor="Red">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="cbx" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label ID="lbNo" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Depart_name" HeaderText="單位名稱" />
                        <asp:BoundField DataField="User_name" HeaderText="人員姓名" />
                        <asp:BoundField DataField="Leave_name" HeaderText="假別" />
                        <asp:TemplateField HeaderText="期間">
                            <ItemTemplate>
                                <asp:Label ID="lbCase_status" runat="server" Text='<%# Bind("Case_status") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbFlow_id" runat="server" Text='<%# Bind("Flow_id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbOrgcode" runat="server" Text='<%# Bind("Orgcode") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbID_card" runat="server" Text='<%# Bind("ID_card") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbdateb" runat="server" Text='<%# FSCPLM.Logic.DateTimeInfo.ToDisplay(Eval("Start_date")) %>'></asp:Label>
                                <asp:Label ID="lbtimeb" runat="server" Text='<%# FSCPLM.Logic.DateTimeInfo.ToDisplayTime(Eval("Start_time")) %>'></asp:Label>
                                ~ 
                                <asp:Label ID="lbdatee" runat="server" Text='<%# FSCPLM.Logic.DateTimeInfo.ToDisplay(Eval("End_date")) %>'></asp:Label>
                                <asp:Label ID="lbtimee" runat="server" Text='<%# FSCPLM.Logic.DateTimeInfo.ToDisplayTime(Eval("End_time")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Reason" HeaderText="事由" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Button ID="cbCancel" runat="server" CausesValidation="False" Text="撤單" OnClick="cbCancel_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <EmptyDataTemplate>
                        查無資料!!
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
                <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvList"
                    PNow="1" PSize="30" Visible="true" />
            </td>
        </tr>
    </table>
</asp:Content>
