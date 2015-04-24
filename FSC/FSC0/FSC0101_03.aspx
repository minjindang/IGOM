<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0101_03.aspx.vb" Inherits="FSC0101_03" %>

<%@ Register Src="../../UControl/UcShowDayHours.ascx" TagName="UcShowDayHours" TagPrefix="uc3" %>
<%@ Register Src="../../UControl/UcLeaveType.ascx" TagName="UcLeaveType" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/UcShowLeaveDate.ascx" TagName="UcShowLeaveDate" TagPrefix="uc6" %>
<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc2" TagName="UcFlowDetail" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <table width="100%">
        <tr>
            <td class="htmltable_Title" colspan="2">
               表單明細</td>
        </tr>
        <tr>
            <td class="htmltable_Left">表單編號</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbFlow_id" runat="server"></asp:Label>
                <asp:LinkButton ID="lbCancel_flowid" runat="server" Visible="false"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="border-bottom:none;">表單申請人</td>
            <td class="htmltable_Right"  style="border-bottom:none;">
                <asp:Label ID="lbApply_name" runat="server"></asp:Label>
                <asp:HiddenField ID="hfApply_id" runat="server" />
            </td>
        </tr>
    </table>
    <table width="100%" runat="server" id="tbGrade" visible="false">
        <tr>
            <td class="htmltable_Left" style="border-bottom:none;">申請人官職等</td>
            <td class="htmltable_Right" style="border-bottom:none;">
                <asp:Label ID="lbGrade" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td class="htmltable_Left">表單填寫人</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbWrite_name" runat="server"></asp:Label>
                <asp:HiddenField ID="hfWrite_id" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">假別</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbLeave_name" runat="server"></asp:Label>
                <uc2:UcLeaveType ID="UcLeaveType" runat="server" Visible="false" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">填單日期</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbWrite_time" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="htmltable_Left">批核日期</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbAgree_time" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="border-bottom:none;"><asp:label runat="server" ID="lbdatename" Text="差假(或加班)期間"></asp:label></td>
            <td class="htmltable_Right" style="border-bottom:none;">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbLeaveDate" runat="server"></asp:Label>
                        </td>
                        <td><asp:Label runat="server" ID="lb" Text="，共計："></asp:Label><uc3:UcShowDayHours ID="UcShowDayHours" runat="server" /></td>
                        <td>
                            <asp:GridView ID="gvCard" runat="server" AutoGenerateColumns="False" CssClass="Grid" width="100%" Visible="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="日期">
                                        <ItemTemplate>
                                            <asp:Label ID="gvlbdate" runat="server" Text='<%# FSCPLM.Logic.DateTimeInfo.ToDisplay(Eval("tdate")) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="刷卡資料">
                                        <ItemTemplate>
                                            <asp:Label ID="gvlbcard" runat="server" Text='<%# Bind("tcard") %>'></asp:Label>    
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>        
                        </td>                
                    </tr>
                </table>
            </td>
        </tr>
    </table>    
    <table width="100%" runat="server" id="tbLevelDeputy" visible="false">
        <tr>
        <td class="htmltable_Left" style="border-bottom:none;">職務代理人</td>
        <td class="htmltable_Right" style="border-bottom:none;">
            <asp:Label ID="lbLevel_Deputy" runat="server"></asp:Label>
        </td>
        </tr>
    </table> 
    <table width="100%" runat="server" id="tbTdate" visible="false">
        <tr>
            <td class="htmltable_Left" style="border-bottom:none;"><asp:label ID="lbDate_type" runat="server" />事實發生日</td>
            <td class="htmltable_Right" style="border-bottom:none;">
                <asp:Label ID="lbTDATE" runat="server"></asp:Label></td>
        </tr>
    </table>
    <table width="100%" runat="server" id="tbOtherLT" visible="false">
        <tr>
            <td class="htmltable_Left" style="border-bottom:none;">核銷<asp:label ID="lbLeave_text" runat="server" />日期時間</td>
            <td class="htmltable_Right" style="border-bottom:none;">
                <asp:Label ID="lbLeave_text2" runat="server"></asp:Label></td>
        </tr>
    </table>
    <table width="100%" style="border:none;">
        <tr>
            <td class="htmltable_Left" style="border-bottom:none;">事由</td>
            <td class="htmltable_Right" style="border-bottom:none;">
                <asp:Label ID="lbReason" runat="server"></asp:Label></td>
        </tr>
    </table>  
    <table width="100%" runat="server" id="tbPlace" visible="false">
        <tr>
            <td class="htmltable_Left" style="border-bottom:none;">
                <asp:Label ID="lbPlaceType" runat="server"></asp:Label>地點</td>
            <td class="htmltable_Right" style="border-bottom:none;">
                <asp:Label ID="lbPlace" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%" runat="server" id="tbDetailPlace" visible="false"> 
        <tr>
            <td class="htmltable_Left" style="border-bottom:none;">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>明細地點</td>
            <td class="htmltable_Right" style="border-bottom:none;">
                <asp:Label ID="lbDetailPlace" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%" runat="server" id="tbTransport" visible="false"> 
        <tr>
            <td class="htmltable_Left" style="border-bottom:none;">
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>交通工具</td>
            <td class="htmltable_Right" style="border-bottom:none;">
                <asp:Label ID="lbTransport" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%"> 
        <tr>
            <td colspan="2"  class="htmltable_Bottom">
                <input id="cbPrint" type="button" value="列印" onclick="javascript:window.print();" class="nonPrinted" />                
                <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" />
            </td>
        </tr>
    </table>

    <uc2:UcFlowDetail runat="server" ID="UcFlowDetail" />
</asp:Content>