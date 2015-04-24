<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC2113_01.aspx.vb" Inherits="FSC2213_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/FSC/UcAuthorityMember.ascx" TagPrefix="uc2" TagName="UcMember" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc2" TagName="UcDDLAuthorityMember" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
                年度資料查詢作業
            </td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="2">
                查詢條件
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px ">
                查詢項目
            </td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlQuery" runat="server" >
                    <asp:listitem Value="Y">已作不休假加班費申請</asp:listitem>
                    <asp:listitem Value="N">未作不休假加班費催辦</asp:listitem>
                    <asp:listitem Value="01">事假超過申請上限者</asp:listitem>
                    <asp:listitem Value="02">病假超過申請上限者</asp:listitem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px ">
                年度
            </td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlYear" runat="server" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
               單位別
            </td>
            <td class="TdHeightLight" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <uc2:UcDDLDepart runat="server" ID="UcDDLDepart" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>            
            <td class="htmltable_Left" style="width:100px">
                員工姓名</td>
            <td class="TdHeightLight">
                <uc2:UcDDLAuthorityMember runat="server" ID="UcDDLAuthorityMember" />
            </td>
        </tr>
        <tr>   
            <td class="htmltable_Left" style="width:100px">
                員工編號</td>
            <td class="TdHeightLight">
                <uc2:UcMember runat="server" ID="UcMember" />
            </td>            
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px ">
                在職狀態
            </td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlQuit" runat="server" >
                    <asp:listitem Value="N">現職人員</asp:listitem>
                    <asp:listitem Value="Y">離職人員</asp:listitem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px ">
                性別
            </td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlSex" runat="server" >
                    <asp:ListItem Value="">請選擇</asp:ListItem>
                    <asp:listitem Value="1">男</asp:listitem>
                    <asp:listitem Value="0">女</asp:listitem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr id="tr1" runat="server">
            <td class="htmltable_Left" style="width:100px" id="tdPememcod" runat="server" >
                人員類別
            </td>
            <td class="TdHeightLight" style="width:250px" id="tdPememcodValue" runat="server"  >
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlEmployee_Type" runat="server" AutoPostBack="True"
                    DataTextField="CODE_DESC1" DataValueField="CODE_NO">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>

        </tr>
        <tr>
            <td align="center" colspan="4" class="TdHeightLight">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" />
                    <input id="Reset" type="button" value="重填" runat="server"  Visible="false"/>
                    <asp:Button ID="btnPrint" runat="server" Text="匯出" Enabled="False" />
            </td>
        </tr>
    </table>
        
    <br />
    <table id="dataList" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" visible="false" >
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                查詢結果
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gv" runat="server" width="100%" AutoGenerateColumns="False" AllowPaging="True" CssClass="Grid"  BorderWidth="0px" PagerStyle-HorizontalAlign="Right" HeaderStyle-Font-Size="small" PageSize="30">
                    <Columns>
                        <asp:BoundField HeaderText="單位名稱" DataField="Depart_Name" />
                        <asp:BoundField HeaderText="員工編號" DataField="Id_card" />
                        <asp:BoundField HeaderText="員工姓名" DataField="User_Name" />
                        <asp:BoundField HeaderText="年度" DataField="YYY" />
                        <asp:BoundField HeaderText="假別" DataField="Leave_name" />
                        <asp:TemplateField HeaderText="可請天數<br />(天.時)">
                            <ItemTemplate>
                                <asp:Label ID="lblimit" runat="server" Text='<%# Bind("limitday")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="實際天數<br />(天.時)">
                            <ItemTemplate>
                                <asp:Label ID="lbreal" runat="server" Text='<%# Bind("realday")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="逾請天數<br />(天.時)">
                            <ItemTemplate>
                                <asp:Label ID="lbover" runat="server" Text='<%# Bind("overday")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings Position="TopAndBottom" />
                    <PagerStyle HorizontalAlign="Right" />
                    <HeaderStyle Font-Size="Small"></HeaderStyle>
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <RowStyle CssClass="Row" />
                </asp:GridView>
             </td>
        </tr>
        <tr>
            <td align="right" class="TdHeightLight" style="width: 100%">
                <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gv"
                    PNow="1" PSize="30" Visible="true" />
            </td>
        </tr>        
    </table>
    <table id="dataList2" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" visible="false"  >
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                查詢結果
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gv2" runat="server" width="100%" AutoGenerateColumns="False" AllowPaging="True" CssClass="Grid"  BorderWidth="0px" PagerStyle-HorizontalAlign="Right" HeaderStyle-Font-Size="small" PageSize="30">
                    <Columns>
                        <asp:BoundField HeaderText="單位名稱" DataField="Depart_Name" />
                        <asp:BoundField HeaderText="員工編號" DataField="Id_card" />
                        <asp:BoundField HeaderText="員工姓名" DataField="User_Name" />
                        <asp:BoundField HeaderText="年度" DataField="Annual_year" />
                        <asp:TemplateField HeaderText="可休天數">
                            <ItemTemplate>
                                <asp:Label ID="lblimit" runat="server" Text='<%# Bind("Annual_days")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="已休天數">
                            <ItemTemplate>
                                <asp:Label ID="lbreal" runat="server" Text='<%# Bind("Vacation_days")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="可申請天數">
                            <ItemTemplate>
                                <asp:Label ID="lbover" runat="server" Text='<%# Bind("Usable_days")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="申請天數">
                            <ItemTemplate>
                                <asp:Label ID="lbover" runat="server" Text='<%# Bind("Pay_days")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="處理狀態" DataField="Ch_Case_status" />
                    </Columns>
                    <PagerSettings Position="TopAndBottom" />
                    <PagerStyle HorizontalAlign="Right" />
                    <HeaderStyle Font-Size="Small"></HeaderStyle>
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <RowStyle CssClass="Row" />
                </asp:GridView>
             </td>
        </tr>
        <tr>
            <td align="right" class="TdHeightLight" style="width: 100%">
                <uc1:Ucpager ID="Ucpager2" runat="server" EnableViewState="true" GridName="gv2"
                    PNow="1" PSize="30" Visible="true" />
            </td>
        </tr>        
    </table>
</asp:Content>
