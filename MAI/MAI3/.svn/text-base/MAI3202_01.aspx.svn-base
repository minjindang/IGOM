<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAI3202_01.aspx.vb" Inherits="MAI_MAI3_MAI3202_01" %>

<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">滿意度調查表
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">報修單號
                </td>
                <td style="width: 326px">
                    <asp:Label ID="lblFlow_id" runat="server"></asp:Label>
                </td>
                <td class="htmltable_Left">報修人分機
                </td>
                <td style="width: 326px">
                    <asp:Label ID="lblPhone_nos" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">報修單位別
                </td>
                <td style="width: 326px">
                    <asp:Label ID="lblUnit_code" runat="server"></asp:Label>
                </td>
                <td class="htmltable_Left">報修人名稱
                </td>
                <td style="width: 326px">
                    <asp:Label ID="lblUser_name" runat="server"></asp:Label>
                </td>
            </tr> 
            <tr>
                <td class="htmltable_Left">報修時間
                </td>
                <td colspan="3">
                    <asp:Label ID="lblApplyTime" runat="server"></asp:Label>
                </td> 
            </tr> 
        </table>
        <div id="div1" runat="server" visible="true">
            <asp:GridView ID="GridViewA" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px"
                Width="100%">
                <PagerSettings Visible="False" />
                <Columns>
                    <asp:BoundField DataField="Index" HeaderText="序號" />
                    <asp:BoundField DataField="MtClass_typeName" HeaderText="報修類別" />
                    <asp:BoundField DataField="Problem_desc" HeaderText="問題描述" />
                    <asp:BoundField DataField="MtStatus_desc" HeaderText="處理說明" />  
                    <asp:BoundField DataField="MtStatus_type" HeaderText="處理情形" />
                    <asp:BoundField DataField="MtStartTime" HeaderText="前往維修時間" />
                    <asp:BoundField DataField="Maintainer_name" HeaderText="維修人名稱" />
                    <asp:TemplateField HeaderText="滿意度">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:HiddenField runat="server" ID="hfMtClass_type" Value='<%# Eval("MtClass_type")%>' />
                            <uc1:ucSaCode runat="server" ID="ucSatisfaction_type" Code_sys="019" Code_type="012" ControlType="DropDownList"  />
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
        <div align="center" >
            <asp:Button ID="DoneBtn" runat="server" Text="確認" />
        </div>
    </div>

</asp:Content>

