<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PAY2202_01.aspx.cs" Inherits="PAY_PAY2_PAY2202_01" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>
<%@ Register Src="~/UControl/UcPayer.ascx" TagPrefix="uc1" TagName="UcPayer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">審查收入列印</td>
            </tr>
            <tr>
                <td class="htmltable_Left">列印類別</td>
                <td colspan="3">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:RadioButtonList ID="rblPrintType" Width="100%" runat="server" AutoPostBack="true" RepeatLayout="Flow" OnSelectedIndexChanged="rblPrintType_SelectedIndexChanged"
                                RepeatDirection="Horizontal">
                                <asp:ListItem Text="收據列印" Value="1"></asp:ListItem>
                                <asp:ListItem Text="審查/證照收入明細表" Value="2"></asp:ListItem>
                                <asp:ListItem Text="付款人明細表" Value="3"></asp:ListItem>
                            </asp:RadioButtonList>
                        </ContentTemplate>
                    </asp:UpdatePanel>                    
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">收費日期(起~迄)</td>
                <td style="width: 326px">
                    <uc1:UcDate runat="server" ID="ucReceipt_dateS" />
                    ~　
                     <uc1:UcDate runat="server" ID="ucReceipt_dateE" />
                </td>
                <td class="htmltable_Left">付款方式</td>
                <td style="width: 326px">
                    <uc1:ucSaCode runat="server" ID="ucPayMode_type" Code_sys="018" Code_type="003" ControlType="DropDownList" OnCodeChanged="ucPayMode_type_CodeChanged" ReturnEvent="true" />

                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">審查收入類別</td>
                <td style="width: 400px" colspan="3">

                    <asp:RadioButton ID="rbIncome_type1" GroupName="Income_type" runat="server"></asp:RadioButton>
                    <asp:TextBox Enabled="False" ID="txtExamineIncome_type" runat="server" Width="20px" Text=""></asp:TextBox>
                    <asp:DropDownList ID="ddlExamineIncome_type" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlExamineIncome_type_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <asp:RadioButton ID="rbIncome_type2" GroupName="Income_type" runat="server"></asp:RadioButton>
                    <asp:Label ID="Label33" runat="server" Text="新引擎、延用、延伸或修改及耐久性審查費(12~20類)"></asp:Label>

                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">付款人</td>
                <td colspan="3">

                    <uc1:UcPayer runat="server" ID="UcPayer" />

                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnPrint" runat="server" Text="列印" OnClick="btnPrint_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="清空重填" OnClick="btnClear_Click" />
                            <asp:Button ID="btnExport" runat="server" Text="產製Excel檔" OnClick="btnExport_Click" Enabled="false" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

