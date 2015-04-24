<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="OTH1101_01.aspx.cs" Inherits="OTH_OTH1_OTH1101_01" %>

<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>
<%@ Register Src="~/UControl/UcDateTime.ascx" TagPrefix="uc1" TagName="UcDateTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">廣播申請
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">第一次廣播時間 :
                </td>
                <td style="width: 326px">
                    <uc1:UcDateTime runat="server" ID="ucbroadcast_date1" />
                </td>
                <td class="htmltable_Left">第二次廣播時間 :<br />  (不須者免填)
                </td>
                <td style="width: 326px">
                    <uc1:UcDateTime runat="server" ID="ucbroadcast_date2" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">廣播系統開放樓層:
                </td>
                <td colspan="3">
                    <uc1:ucSaCode runat="server" ID="ucbroadcast_floors" Code_sys="022" Code_type="001" ControlType="CheckBoxList" />
                </td> 
            </tr>
             <tr>
                <td class="htmltable_Left">廣播內容:
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtbroadcast_content" runat="server" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox>
                </td> 
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;"> 
                    <asp:Button ID="DoneBtn" runat="server" Text="送出申請" OnClick="DoneBtn_Click" />
                    <asp:Button ID="ResetBtn" runat="server" Text="清空重填" OnClick="ResetBtn_Click" />
                </td>
            </tr>
        </table>
        <div id="div1" runat="server" visible="false">
            <asp:GridView ID="GridViewA" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px"
                Width="100%">
                <Columns>
                    <asp:BoundField DataField="broadcast_dt" HeaderText="廣播時間 " />
                    <asp:BoundField DataField="broadcast_floors" HeaderText="廣播系統開放樓層" />
                    <asp:BoundField DataField="broadcast_content" HeaderText="廣播內容" /> 
                </Columns>
                <RowStyle CssClass="Row" />
                <HeaderStyle CssClass="Grid" />
                <AlternatingRowStyle CssClass="AlternatingRow" />
                <PagerSettings Position="TopAndBottom" />
                <EmptyDataRowStyle CssClass="EmptyRow" />
            </asp:GridView>
        </div>
    </div>

</asp:Content>

