<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="PAY3105_02.aspx.vb" Inherits="PAY_PAY3_PAY3105_02" %>

<%@ Register Src="~/UControl/UcBank.ascx" TagPrefix="uc1" TagName="UcBank" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc1" TagName="UcDDLMember" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">受款人帳號維護
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:RadioButtonList ID="rblEmp" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"  >
                    <asp:ListItem Value="Y" Selected="True"  >員工</asp:ListItem>
                    <asp:ListItem Value="N">非員工</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr runat="server" id="trEmpY"> 
            <td class="htmltable_Left">受款人
            </td>
            <td colspan="3">             
                <table style="border:0px none;">
                    <tr>
                        <td style="border:0px none;"><uc1:UcDDLDepart runat="server" ID="UcDDLDepart" /></td>
                        <td style="border:0px none;"><uc1:UcDDLMember runat="server" ID="UcDDLMember" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr runat="server" id="trEmpN" visible="false" >
            <td class="htmltable_Left">受款人姓名
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtBeneficiary_name" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>銀行代碼/名稱
            </td>
            <td>
                <uc1:UcBank runat="server" ID="ucBank" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>受款人帳號
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtBankAccount_nos" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">受款人Email
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtEmail" runat="server" Width="350px" MaxLength="60" ></asp:TextBox>
                                    <asp:RegularExpressionValidator 
	                    ID="RegularExpressionValidator1" runat="server"  
	                    ErrorMessage="請輸入正確的電子郵件位址!" ControlToValidate="txtEmail" Display="Dynamic"  
	                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator> 
            </td>
        </tr>
    </table>
    <div align="center"> 
        <asp:Button ID="DoneBtn" runat="server" Text="確認" />
        <asp:Button ID="ClrBtn" runat="server" Text="清空重填" /> 
        <asp:Button ID="BackBtn" runat="server" Text ="回上頁" OnClick="BackBtn_Click1" />
    </div>

</asp:Content>

