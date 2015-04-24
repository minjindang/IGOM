<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="FSC1106_01.aspx.vb" Inherits="FSC1106_01" %>

<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/UcShowDate.ascx" TagPrefix="uc1" TagName="UcShowDate" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLAuthorityDepart" %>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function chgUcDate() {
            __doPostBack('<%=UpdatePanel3.ClientID%>', '');
        }
    </script>
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="2">值日(夜)代(換)值申請</td>
        </tr>
        <tr>
            <td class="htmltable_Left"><font size="3" color="red">*</font>申請代(換)類別</td>
            <td>
                <asp:DropDownList ID="ddlDuty_type" runat="server" AutoPostBack="True" colspan="3">
                    <asp:ListItem Value="1">代值</asp:ListItem>
                    <asp:ListItem Value="2">換值</asp:ListItem>
                </asp:DropDownList>
                <asp:HiddenField ID="hfid" runat="server" />
            </td>
            </tr>
       <tr>
            <td class="htmltable_Left" style="width: 150px"><font size="3" color="red">*</font>申請代(換)值人員</td>
            <td style="width: 326px">
                <uc1:UcDDLAuthorityDepart runat="server" ID="UcApply_Depart" Sub_Visible="false" />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlApply_Username" runat="server" AutoPostBack="true" DataTextField="User_name" DataValueField="Id_card" >
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px"><font size="3" color="red">*</font>指定代(換)值人員</td>
            <td style="width: 326px">
                <uc1:UcDDLDepart runat="server" ID="UcShift_Depart" Sub_Visible="false" />
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlShift_Username" runat="server" AutoPostBack="true" DataTextField="User_name" DataValueField="Id_card" >
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr runat="server" id="tr1" visible="false">
            <td class="htmltable_Left"><font size="3" color="red">*</font>原值班日期</td>
            <td style="width: 326px">
                <uc1:UcDate runat="server" ID="UcOriginal_Dutydate" />
            </td>
        </tr>       
        <tr runat="server" id="tr2">
            <td class="htmltable_Left"><font size="3" color="red">*</font>代(換)值班日期</td>
            <td style="width: 326px">
                <uc1:UcDate runat="server" ID="UcShift_Dutydate" />
            </td>
        </tr>
        <tr runat="server" id="tr3" visible="false">
            <td class="htmltable_Left">原班別</td>
            <td style="width: 326px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbSchedule_id" runat="server" Visible="false" />
                        <asp:Label ID="lbSchedule_Name" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">代(換)換班別</td>
            <td style="width: 326px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbShift_Schedule_id" runat="server" Visible="false" />
                        <asp:Label ID="lbShift_Schedule_Name" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><font size="3" color="red">*</font>事由</td>
            <td>
                <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※輸入事由請勿超出50字"></asp:Label><br />
                <asp:TextBox ID="tbDuty_reason" runat="server" Text="" TextMode="MultiLine" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">備註</td>
            <td>
                <asp:Label ID="label2" runat="server" AutoPostBack="True" > ☆假日/農曆年假期間白間：8:30~17:30<br/> ☆平日/假日/農曆年假期間夜間：17:30至隔日早上8:30 </asp:Label>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                <asp:Button ID="cbInsert" runat="server" Text="新增一筆資料" />
                <asp:Button ID="cbSubmit" runat="server" Text="送出申請" style="width: 78px" />
                <asp:Button ID="cbUpdate" runat="server" Text="確定" Visible="false" />
                <asp:Button ID="cbCancel" runat="server" Text="取消" Visible="false" OnClick="initData" />
                <asp:Button ID="cbQuery" runat="server" Text="值班表查詢" PostBackUrl="~/FSC/FSC2/FSC2121_01.aspx" />
            </td>
        </tr>

    </table>

    <div id="div1" runat="server">
        <asp:GridView ID="gv" runat="server"
            AutoGenerateColumns="False" DataKeyNames="id"
            AllowPaging="True" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:BoundField HeaderText="項次" DataField="Num" />
                <asp:TemplateField HeaderText="申請人姓名">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lbid" runat="server" Text='<%# Eval("id")%>' Visible="false"></asp:Label>
                        <asp:Label ID="lbApply_Username" runat="server" Text='<%# Eval("Apply_Username")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="申請日期">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <uc1:UcShowDate runat="server" ID="lbApply_Date" Text='<%# Eval("Apply_Date")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="代(換)值類別">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Duty_typeName")%>'></asp:Label>
                        <asp:Label ID="lbDuty_type" runat="server" Text='<%# Eval("Duty_type")%>' Visible="false" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="原班別">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lbSchedule_Name" runat="server" Text='<%# Eval("Schedule_Name")%>'></asp:Label>
                        <asp:Label ID="lbSchedule_id" runat="server" Text='<%# Eval("Schedule_id")%>' Visible="false" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="原值班日期">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <uc1:UcShowDate runat="server" ID="lbOriginal_Dutydate" Text='<%# Eval("Original_Dutydate")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="代(換)班別">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lbShift_Schedule_Name" runat="server" Text='<%# Eval("Shift_Schedule_Name")%>'></asp:Label>
                        <asp:Label ID="lbShift_Schedule_id" runat="server" Text='<%# Eval("Shift_Schedule_id")%>' Visible="false" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="代(換)值日期">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <uc1:UcShowDate runat="server" ID="lbShift_Dutydate" Text='<%# Eval("Shift_Dutydate")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="代(換)值人員">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lbShift_Username" runat="server" Text='<%# Eval("Shift_Username")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="事由">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lbDuty_reason" runat="server" Text='<%# Eval("Duty_reason")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="維護">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" Width="25%" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Button ID="gvUpdate" runat="server" Text="維護" CausesValidation="false"
                            CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" CommandName="upd" />
                        <asp:Button ID="gvDelete" runat="server" Text="刪除" CausesValidation="false" Visible="true" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" CommandName="del" OnClientClick="javascript:if(!confirm('確定要刪除資料?')) return false;" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
    </div>
</asp:Content>
