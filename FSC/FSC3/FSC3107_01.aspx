<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC3107_01.aspx.vb" Inherits="FSC3107_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%" class="tableStyle99">        
        <tr>
            <td class="htmltable_Title" colspan="2">
                年度結轉作業
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                轉檔項目</td>                        
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlitem" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlitem_SelectedIndexChanged">
                    <asp:ListItem Text="未休假加班費強制申請之查詢作業" Value="1"></asp:ListItem>
                    <asp:ListItem Text="新增員工新年度保留休假轉檔作業" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                年度</td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlYear" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                員工種類</td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlEmpType" runat="server">
                </asp:DropDownList>
            </td>
        </tr>                
    </table>

    <div style="text-align:center;">
        <asp:Button ID="btnTrans" runat="server" Text="執行/查詢" OnClientClick="blockUI()" />
    </div>

    <table id="TABLE2" runat="server" width="100%" class="tableStyle99" visible="false">
        <tr>
            <td class="htmltable_Right">
                <asp:Button ID="cbConfirm" runat="server" Text="確認" OnClick="cbConfirm_Click" />
                <asp:Button ID="cbSendNotice" runat="server" Text="未休假加班費通知" OnClick="cbSendNotice_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Borderwidth="0px"
                    CssClass="Grid" PagerStyle-HorizontalAlign="Right"
                    ShowFooter="false" width="100%" AllowPaging="false">
                    <FooterStyle CssClass="Foot" />
                    <RowStyle CssClass="Row" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <HeaderTemplate>
                                <asp:CheckBox ID="cbxAll" runat="server" OnCheckedChanged="cbxAll_CheckedChanged" AutoPostBack="true" />                                
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="cbx" runat="server" />  
                                <asp:HiddenField ID="hfDepart_id" runat="server" value='<%# Bind("Depart_id")%>'/>                                                                                           
                                <asp:HiddenField ID="hfUser_name" runat="server" value='<%# Bind("User_name")%>'/> 
                                <asp:HiddenField ID="hfId_card" runat="server" value='<%# Bind("Id_card")%>'/> 
                                <asp:HiddenField ID="hfHolidays" runat="server" value='<%# Bind("Holidays")%>'/> 
                                <asp:HiddenField ID="hfLeave_days" runat="server" value='<%# Bind("Leave_days")%>'/> 
                                <asp:HiddenField ID="hfCan_pay_days" runat="server" value='<%# Bind("Can_pay_days")%>'/> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Depart_name" HeaderText="單位" />
                        <asp:BoundField DataField="User_name" HeaderText="人員姓名" />
                        <asp:BoundField DataField="yyy" HeaderText="申請年度" />
                        <asp:BoundField DataField="Holidays" HeaderText="可休天數" />
                        <asp:BoundField DataField="Leave_days" HeaderText="已休天數" />
                        <asp:BoundField DataField="Can_pay_days" HeaderText="可請天數" />
                        <asp:TemplateField HeaderText="申請天數">
                            <ItemTemplate>
                                <asp:TextBox ID="tbApplyDays" runat="server" Width="50" Text="0"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
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

</asp:Content>
