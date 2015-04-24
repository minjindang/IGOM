<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAI1103_01.aspx.vb" Inherits="MAI_MAI1_MAI1103_01" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">軟硬體報修紀錄查詢</td>
            </tr>
            <tr>
                <td class="htmltable_Left">報修類別</td>
                <td class="htmltable_Right" colspan="3">
                    <uc1:ucSaCode runat="server" ID="ucMtClass_type" ControlType="CheckBoxList" Code_sys="020" Code_type="**" RepeatColumns="4" />
                    <asp:TextBox ID="txtOTHMtClass_type" runat="server" Width="200px"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnCheckAll" runat="server" Text="全選" />
                    <asp:Button ID="btnUnCheckAll" runat="server" Text="取消全選" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">報修日期</td>
                <td class="htmltable_Right">
                    <uc1:UcDate runat="server" ID="ucApplyTimeS" />
                    ~　
                   <uc1:UcDate runat="server" ID="ucApplyTimeE" />
                </td>
                <td class="htmltable_Left">聯絡分機</td>
                <td style="width: 326px">
                    <asp:TextBox ID="txtPhone_nos" runat="server" Width="40px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">報修單位別</td>
                <td style="width: 326px">
                    <asp:DropDownList ID="ddlUnit_code" runat="server">
                    </asp:DropDownList>
                </td>

                <td class="htmltable_Left">報修人</td>
                <td style="width: 326px">
                    <asp:TextBox ID="txtUser_id" runat="server" Width="50px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">處理情形</td>
                <td class="htmltable_Right">
                    <uc1:ucSaCode runat="server" ID="ucMtStatus_type" ControlType="CheckBoxList" Code_sys="019" Code_type="003" RepeatColumns="4" />
                </td>
                <td class="htmltable_Left">服務類型</td>
                <td>
                    <uc1:ucSaCode runat="server" ID="ucServApply_type" ControlType="DropDownList" Code_sys="019" Code_type="002" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="DoneButton" runat="server" Text="查詢" />
                    <asp:Button ID="ClrButton" runat="server" Text="清空重填" />
                </td>
            </tr>
        </table>
        <div id="div1" runat="server" visible="false"   >
            <asp:GridView ID="GridViewA" runat="server"
                AutoGenerateColumns="False"  
                AllowPaging="True" PagerSettings-Visible="false"
                CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
                <PagerSettings Visible="false" />
                <Columns>
                    <asp:BoundField DataField="Index" HeaderText="序號" /> 
                    <asp:TemplateField HeaderText="報修單號">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/MAI/MAI1/MAI1103_02.aspx?code=" + Eval("SwMaintain_code").ToString()%>'><%# Eval("SwMaintain_code").ToString() %></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:BoundField DataField="Unit_code" HeaderText="單位別" />
                    <asp:BoundField DataField="User_id" HeaderText="報修人" />
                    <asp:BoundField DataField="Phone_nos" HeaderText="分機" />
                    <asp:BoundField DataField="ApplyTimeString" HeaderText="報修時間" />
                    <asp:BoundField DataField="MtClass_type" HeaderText="報修類別" />
                    <asp:BoundField DataField="ServApply_type" HeaderText="服務類型" />
                    <asp:BoundField DataField="Problem_desc" HeaderText="問題描述" />
                    <asp:BoundField DataField="MaintainerPhone_nos" HeaderText="處理人員及分機" />
                    <asp:BoundField DataField="MtStatus_type" HeaderText="處理情形" /> 
                    <asp:TemplateField HeaderText="維護">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:HiddenField ID="hfRepeatApply_type" runat="server" Value='<%# Eval("RepeatApply_type")%>' />
                            <asp:HiddenField ID="hfServConfirm_type" runat="server" Value='<%# Eval("ServConfirm_type")%>' />
                            <asp:Button ID="btn1" runat="server" Text="重複報修" CommandName="RepeatApply" CommandArgument='<%# Eval("SwMaintain_code")%>' />
                            <asp:Button ID="btn2" CommandName="ServConfirm_type" CommandArgument='<%# Eval("SwMaintain_code")%>'
                                runat="server" Text="轉問題單"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="Row" />
                <HeaderStyle CssClass="Grid" />
                <AlternatingRowStyle CssClass="AlternatingRow" />
                <PagerSettings Position="TopAndBottom" />
                <EmptyDataRowStyle CssClass="EmptyRow" />
            </asp:GridView>
             <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
                        PNow="1" PSize="10" Visible="true" />
        </div>
    </div>

</asp:Content>

