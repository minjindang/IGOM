<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PAY2201_01.aspx.cs" Inherits="PAY_PAY2_PAY2201_01" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">歲入彙計表</td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    <font size="3" color="red" >*</font>收費日期(起~迄)
                </td>
                <td colspan="3">
                    <uc1:UcDate runat="server" ID="ucReceipt_dateS" />
                    ~
                    <uc1:UcDate runat="server" ID="ucReceipt_dateE" />
                </td>
            </tr>
             <tr>
                <td class="htmltable_Left">付款方式</td>
                <td style="width:326px">
                    <uc1:ucSaCode runat="server" ID="ucPayMode_type" Code_sys="018" Code_type="003" ControlType="DropDownList"  />
                </td>
                <td class="htmltable_Left">排序方式</td>
                <td style="width:326px">
                    <asp:DropDownList ID="ddlOrder" runat="server">
                        <asp:ListItem Value="PaymentCode">收據字號</asp:ListItem>
                        <asp:ListItem Value="ExamineIncome_name">收入類別名稱</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr> 
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="PrintBtn" runat="server" Text="列印" OnClick="PrintBtn_Click" />
                    <asp:Button ID="ClrBtn" runat="server" Text="清空重填" OnClick="ClrBtn_Click"/>  
                </td>
            </tr>
        </table> 
    </div>


</asp:Content>

