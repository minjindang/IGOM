<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC3121_01.aspx.vb" Inherits="FSC3121_01"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td align="left" class="htmltable_Title" colspan="4">
                休假補助費</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                查詢年度</td>
            <td colspan="3" class="htmltable_Right">                
                <asp:DropDownList ID="ddlYear" runat="server">
                </asp:DropDownList>年
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                單位</td>
            <td colspan="3" class="htmltable_Right">                
                <asp:DropDownList ID="ddlDepart" runat="server"
                     DataTextField="depart_name" DataValueField="depart_id">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                人員類別</td>
            <td colspan="3" class="htmltable_Right">                
                <asp:DropDownList ID="ddlEmployee_type" runat="server" />
            </td>
        </tr>
    </table>
    <div style="text-align:center">
        <asp:Button ID="cbQuery" runat="server"  Text="查詢" />
        <asp:Button ID="cbUpdate" runat="server" Text="確認" Enabled="false" />
        <asp:Button ID="cbPrint" runat="server" Text="列印" Enabled="false" OnClick="btnPrint_Click" />
    </div>

    <table width="100%" class="tableStyle99" id="Table1" runat="server" visible="false" >
        <tr>
            <td colspan="8" valign="top" class="TdHeightLight">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Borderwidth="0px"
                    CssClass="Grid" PagerStyle-HorizontalAlign="Right"
                    ShowFooter="false" width="100%" AllowPaging="false">
                    <FooterStyle CssClass="Foot" />
                    <RowStyle CssClass="Row" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label ID="lbNo" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                
                                <asp:HiddenField ID="hfInter_days" runat="server" value='<%# Bind("Inter_days")%>'/> 
                                <asp:HiddenField ID="hfInter_days_card" runat="server" value='<%# Bind("Inter_days_card")%>'/> 
                                <asp:HiddenField ID="hfOuter_days" runat="server" value='<%# Bind("Outer_days")%>'/> 
                                <asp:HiddenField ID="hfPay_days" runat="server" value='<%# Bind("Pay_days")%>'/> 
                                <asp:HiddenField ID="hfTotal_fee" runat="server" value='<%# Bind("Total_fee")%>'/> 
                                <asp:HiddenField ID="hfUser_name" runat="server" value='<%# Bind("User_name")%>'/> 
                                <asp:HiddenField ID="hfId_card" runat="server" value='<%# Bind("Id_card")%>'/> 
                                <asp:HiddenField ID="hfHolidays" runat="server" value='<%# Bind("Holidays")%>'/> 
                                <asp:HiddenField ID="hfLeave_days" runat="server" value='<%# Bind("Leave_days")%>'/> 
                                <asp:HiddenField ID="hfLeft_days" runat="server" value='<%# Bind("Left_days")%>'/> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Depart_name" HeaderText="單位" />
                        <asp:BoundField DataField="User_name" HeaderText="人員姓名" />
                        <asp:BoundField DataField="yyy" HeaderText="申請年度" />
                        <asp:BoundField DataField="Holidays" HeaderText="可休天數" />
                        <asp:BoundField DataField="Must_days" HeaderText="強制休假天數" />
                        <asp:BoundField DataField="Leave_days" HeaderText="已休天數" />
                        <asp:BoundField DataField="Left_days" HeaderText="未休天數" />
                        <asp:BoundField DataField="Total_fee" HeaderText="申請金額" />
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <EmptyDataTemplate>
                        查無資料
                    </EmptyDataTemplate>
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hfOrgcode" runat="server" />
    <asp:HiddenField ID="hfDepart_id" runat="server" />
    <asp:HiddenField ID="hfPerId" runat="server" />
    <asp:HiddenField ID="hfYear" runat="server" />
    <asp:HiddenField ID="hfIsApply" runat="server" Value="false" />
</asp:Content>

