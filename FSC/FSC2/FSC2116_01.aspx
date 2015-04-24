<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC2116_01.aspx.vb" Inherits="FSC2116_01"  %>

<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register src="~/UControl/UcShowDate.ascx" tagname="UcShowDate" tagprefix="uc3" %>
<%@ Register src="~/UControl/UcShowTime.ascx" tagname="UcShowTime" tagprefix="uc4" %>
<%@ Register src="~/UControl/UcMember.ascx" tagname="UcMember" tagprefix="uc5" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc1" TagName="UcDDLAuthorityMember" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table  border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                國民旅遊卡申報作業</td>
        </tr>

         <tr id="tr1" runat="server">    
            <td class="htmltable_Left" style="width:100px; height: 19px;">
                單位別 </td>
            <td class="TdHeightLight" style="width:250px; height: 19px;">
              <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" /></td>
         </tr>
         <tr>    
            <td class="htmltable_Left" style="width:100px; height: 19px;">
                人員姓名 </td>
            <td class="TdHeightLight" style="width:250px; height: 19px;">
                <uc1:UcDDLAuthorityMember runat="server" ID="UcDDLAuthorityMember" />
            </td>
         </tr>
        <tr>
            <td class="htmltable_Left"  style="width: 100px">
            起迄日期</td>
            <td class="TdHeightLight">
                <uc2:UcDate ID="UcDate1" runat="server"></uc2:UcDate>
                <uc2:UcDate ID="UcDate2" runat="server"></uc2:UcDate>
                <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
            </td>
        </tr>
   
            
        <tr>
            <td align="center" style="height: 17px" class="TdHeightLight"  colspan="2" >
                <asp:Button ID="btnQuery" runat="server" Text="查詢" />
                <asp:Button ID="btnBackupReport" runat="server" Text="匯出備份用報表" Enabled="True" />
                <asp:Button ID="btnBankReport" runat="server" Text="匯出銀行用報表" Enabled="True" />
            </td>
        </tr>
    </table>
    <br />
    <table id="dataList" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" visible="False">
        <tr>
             <td align="center" class="htmltable_Title2">
                查詢結果</td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30"
                    BorderWidth="0px" CssClass="Grid" PagerStyle-HorizontalAlign="Right" Width="100%"
                    EmptyDataText="查無資料!!">   
                    <Columns>
                        <asp:TemplateField HeaderText="編號">
                           <ItemStyle HorizontalAlign="Center" Width="25px" />
                           <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="25px" />
                           <ItemTemplate>
                           <asp:Label ID="lbNumber" runat="server" Text='<%# (container.dataitemindex+1).tostring() %>'></asp:Label>
                           </ItemTemplate>
                           </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位名稱">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                            <ItemTemplate>
                                <asp:Label ID="lbDepartid" runat="server" Text='<%# Eval("Depart_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="員工編號">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lbId_card" runat="server" Text='<%# Eval("Id_card")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="姓名" >
                            <ItemStyle HorizontalAlign="Center"  />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lbUser_name" runat="server" Text='<%# Eval("User_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="身分證字號">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lbUser_name" runat="server" Text='<%# Eval("Id_number")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="休假起訖日" >
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                               <uc3:UcShowDate ID="UcShowDate1" runat="server" Text='<%# Eval("Start_date")%>'/>
                                ~
                               <uc3:UcShowDate ID="UcShowDate2" runat="server" Text='<%# Eval("End_date")%>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="時數">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lbLeavehours" runat="server" Text='<%# Eval("Leave_hours")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="異動者">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lbChangeuserid" runat="server" Text='<%# Eval("Change_userid")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                   </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <EmptyDataTemplate>
                        查無資料
                    </EmptyDataTemplate>
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right" class="TdHeightLight" style="width: 100%">
                <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvList" PNow="1" PSize="30" Visible="False" />
            </td>
        </tr>                    
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" id="EmptyTable" runat="server" visible="false">
        <tr>
            <td align="center" class="htmltable_Title2" colspan="2">
                查詢結果
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="height: 21px" class="EmptyRow">
                查無資料!!</td>
        </tr>
    </table>                    
    <asp:HiddenField ID="ReportTitle" runat="server" Visible="true" />
    </asp:Content>
