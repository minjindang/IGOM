<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC3112_01.aspx.vb" Inherits="FSC3112_01" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register src="~/UControl/UcShowDate.ascx" tagname="UcShowDate" tagprefix="uc3" %>
<%@ Register src="~/UControl/FSC/UcMember.ascx" tagname="UcMember" tagprefix="uc4" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc2" TagName="UcDDLMember" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
                排班資料維護
            </td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="4">
                查詢條件
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color:Red">*</span>年月</td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="DD_Year" runat="server">
                </asp:DropDownList>年
                <asp:DropDownList ID="DD_Month" runat="server">
                </asp:DropDownList>月            
            </td>            
            <td class="htmltable_Left" >
                班別
            </td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlSchedule" runat="server" DataTextField="Name" DataValueField="Schedule_id"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
               <span style="color:Red">*</span>單位名稱
            </td>
            <td class="TdHeightLight">
                <uc2:UcDDLDepart runat="server" ID="UcDDLDepart" OnSelectedIndexChanged="ddlDepart_name_SelectedIndexChanged" />
            </td>
            <td class="htmltable_Left" style="width:100px">
                人員姓名</td>
            <td class="TdHeightLight">
                <uc2:UcDDLMember runat="server" ID="UcDDLMember" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">在職狀態</td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlJobStatus" runat="server" DataTextField="code_desc1" DataValueField="code_no"></asp:DropDownList>
            </td>
            <td class="htmltable_Left">人員類別</td>
            <td class="TdHeightLight">                
                <asp:DropDownList ID="ddlEmployeeType" runat="server" DataTextField="code_desc1" DataValueField="code_no"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                員工編號</td>
            <td class="TdHeightLight">
                <uc4:UcMember ID="UcPersonal_id" runat="server" />
            </td>
            <td class="htmltable_Left" style="width:100px">
                初始班表</td>
            <td class="TdHeightLight">
                <asp:RadioButtonList ID="rblTarget" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" >
                    <asp:ListItem Value="0" Text="是"></asp:ListItem>
                    <asp:ListItem Value="1" Text="否" Selected="True"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" class="TdHeightLight">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" />
                <input id="Reset2" type="button" value="重填" onclick="clearForm(this.form)" />
                <asp:Button ID="btnPrint" runat="server" Text="匯出" />
                <asp:Button ID="cbAuto" runat="server" Text="自動排班" OnClick="cbAuto_Click" />
                <asp:Button ID="btnNotice" runat="server" Text="值班通知" Enabled="false" OnClientClick="javascript:if(!confirm('您確定要通知值班人員嗎?')) return false;" /> 
            </td>
        </tr>
    </table>
        
    <br />
    <table id="tbQ" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" visible="false">
        <tr>
            <td class="htmltable_Title2">
                查詢結果</td>
        </tr>
        <tr>
            <td align="right" class="TdHeightLight">
                <asp:GridView ID="gvList" runat="server" width="100%" AutoGenerateColumns="False" AllowPaging="True" CssClass="Grid" 
                    BorderWidth="0px" PagerStyle-HorizontalAlign="Right" HeaderStyle-Font-Size="Medium"   PageSize="30" 
                    EmptyDataText="查無資料!" EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1%> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lbDepart_name" runat="server" Text='<%# Bind("Depart_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="姓名">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lbOrgcode" runat="server" Text='<%# Bind("Orgcode") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbDepart_id" runat="server" Text='<%# Bind("Depart_id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbUser_name" runat="server" Text='<%# Bind("User_name") %>'></asp:Label>
                                <asp:Label ID="lbid" runat="server" Text='<%# Bind("id")%>' Visible="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="員工代號">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lbId_card" runat="server" Text='<%# Bind("Id_card") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="日期">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lbSche_date" runat="server" Text='<%# Bind("Sche_date")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="星期">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lbWeek" runat="server" Text='<%# Bind("Week")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="班別">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lbSchedule_id" runat="server" Text='<%# Bind("name") %>'></asp:Label>                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Button ID="cbUpdate" runat="server" Text="修改" OnClick="cbUpdate_Click" />                    
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        查無資料!!
                    </EmptyDataTemplate>
                    <PagerSettings Position="TopAndBottom" />
                    <PagerStyle HorizontalAlign="Right" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <RowStyle CssClass="Row" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right" class="TdHeightLight">
                <uc1:ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvList" 
                    PNow="1" PSize="30" />
            </td>
        </tr>

    </table>
    
    
</asp:Content>
