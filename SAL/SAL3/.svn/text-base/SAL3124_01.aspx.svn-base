<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SAL3124_01.aspx.vb" Inherits="SAL3124_01" %>

<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc1" %>
<%@ Register Src="~/UControl/SAL/ucGridViewPager.ascx" TagName="ucGridViewPager" TagPrefix="UserCon" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">補充保費申報媒體檔作業</td>
        </tr>
        <tr>
            <td class="htmltable_Left">給付年月</td>
            <td style="width: 500px">民國
                <asp:DropDownList ID="DropDownList_year" runat="server" ></asp:DropDownList>
                <asp:DropDownList ID="DropDownList_month" runat="server" >
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="01">01</asp:ListItem>
                    <asp:ListItem Value="02">02</asp:ListItem>
                    <asp:ListItem Value="03">03</asp:ListItem>
                    <asp:ListItem Value="04">04</asp:ListItem>
                    <asp:ListItem Value="05">05</asp:ListItem>
                    <asp:ListItem Value="06">06</asp:ListItem>
                    <asp:ListItem Value="07">07</asp:ListItem>
                    <asp:ListItem Value="08">08</asp:ListItem>
                    <asp:ListItem Value="09">09</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                </asp:DropDownList>月
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 170px">
                <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>申報單位電子郵件信箱帳號</td>
            <td>
                 <asp:TextBox ID="txtEmail" runat="server" MaxLength="30" Width="400px"></asp:TextBox>
                 (最多30字)
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server"
                  ControlToValidate="txtEmail" ErrorMessage="電子郵件信箱必要欄位">
                 </asp:RequiredFieldValidator>&nbsp;
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                   ErrorMessage="電子郵件信箱輸入格式不正確" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic">
                 </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" style="border-top: none;" colspan="2">
                <asp:Button ID="btnGen" runat="server" Text="產生媒體檔" />
                <asp:Label ID="labelFilename" runat="server" Visible="false" />
                <asp:Panel ID="plExport1" runat="server" Visible="false">
                    <asp:Label ID="Label_download" runat="server" Text=""></asp:Label>
                </asp:Panel>      
                <asp:Button ID="btnList" runat="server" Text="轉檔明細" />
            </td>
        </tr>
    </table>
    <div>
        <asp:GridView ID="gvList63" runat="server" Visible="true" AutoGenerateColumns="false" AllowPaging="false" AllowSorting="false">
            <Columns>
                <asp:BoundField DataField="budget_code" HeaderText="預算來源" />
                <asp:BoundField DataField="inco_no" HeaderText="流水號" />
                <asp:BoundField DataField="icode_name" HeaderText="所得種類" />
                <asp:BoundField DataField="inco_date" HeaderText="所得給付日期" />
                <asp:BoundField DataField="base_name" HeaderText="所得人姓名" />
                <asp:BoundField DataField="base_idno" HeaderText="所得人統編" />
                <asp:BoundField DataField="inco_amt" HeaderText="所得(收入)給付金額" />
                <asp:BoundField DataField="inco_health_ext" HeaderText="扣繳補充保險費金額" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gvList65" runat="server" Visible="true" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="budget_code" HeaderText="預算來源" />
                <asp:BoundField DataField="inco_no" HeaderText="流水號" />
                <asp:BoundField DataField="icode_name" HeaderText="所得種類" />
                <asp:BoundField DataField="inco_date" HeaderText="所得給付日期" />
                <asp:BoundField DataField="base_name" HeaderText="所得人姓名" />
                <asp:BoundField DataField="base_idno" HeaderText="所得人統編" />
                <asp:BoundField DataField="inco_amt" HeaderText="所得(收入)給付金額" />
                <asp:BoundField DataField="inco_health_ext" HeaderText="扣繳補充保險費金額" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gvList67" runat="server" Visible="true" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="budget_code" HeaderText="預算來源" />
                <asp:BoundField DataField="inco_no" HeaderText="流水號" />
                <asp:BoundField DataField="icode_name" HeaderText="所得種類" />
                <asp:BoundField DataField="inco_date" HeaderText="所得給付日期" />
                <asp:BoundField DataField="base_name" HeaderText="所得人姓名" />
                <asp:BoundField DataField="base_idno" HeaderText="所得人統編" />
                <asp:BoundField DataField="inco_amt" HeaderText="所得(收入)給付金額" />
                <asp:BoundField DataField="inco_health_ext" HeaderText="扣繳補充保險費金額" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gvList68" runat="server" Visible="true" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="budget_code" HeaderText="預算來源" />
                <asp:BoundField DataField="inco_no" HeaderText="流水號" />
                <asp:BoundField DataField="icode_name" HeaderText="所得種類" />
                <asp:BoundField DataField="inco_date" HeaderText="所得給付日期" />
                <asp:BoundField DataField="base_name" HeaderText="所得人姓名" />
                <asp:BoundField DataField="base_idno" HeaderText="所得人統編" />
                <asp:BoundField DataField="inco_amt" HeaderText="所得(收入)給付金額" />
                <asp:BoundField DataField="inco_health_ext" HeaderText="扣繳補充保險費金額" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
