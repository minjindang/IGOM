<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL1110_01.aspx.cs" Inherits="SAL_SAL1_SAL1110_01" %>

<%@ Register Src="~/UControl/UcROCYear.ascx" TagPrefix="uc1" TagName="UcROCYear" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        function checkData() {
            if ('<%= lbNotice.Text.Trim() %>' != "") {
                if (!confirm('<%= lbNotice.Text.Trim() %>'))
                    return false;
                else
                    return true;
            } else
                return true;
        }
    </script>
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">勞/健、公/健保繳納證明申請</td>
        </tr>
        <tr>
            <td class="htmltable_Left">申請年度</td>
            <td style="width: 326px" colspan="3">
                <uc1:UcROCYear runat="server" ID="ucApply_yyy" OnSelectedIndexChanged="ucApply_yyy_SelectedIndexChanged" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;"> 
                <asp:Button ID="btn_submit" runat="server" Text=" 送出申請 " OnClick="btn_submit_Click" OnClientClick="if(!checkData()) return false;blockUI();" />
                <asp:Button ID="btn_back" runat="server" Text="回上頁" OnClick="BackBtn_Click" Visible="false" />
                <asp:Label ID="lbNotice" runat="server" Visible="false" />
            </td>
        </tr>
    </table>
    <div  >
        <asp:GridView ID="GridViewA" runat="server"
            AutoGenerateColumns="False"
            AllowPaging="True" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:BoundField DataField="User_name" HeaderText="申請人姓名" />
                <asp:BoundField DataField="Apply_yy" HeaderText="申請年度" />
                <asp:BoundField DataField="Apply_date" HeaderText="申請日期" /> 
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
    </div>
</asp:Content>

