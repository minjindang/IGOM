<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PAY4101_03.aspx.cs" Inherits="PAY_PAY4_PAY4101_03" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">維護審查收入類別</td>
            </tr>
            <tr>
                <td class="htmltable_Left"><span style="color: red;">*</span>審查收入類別</td>
                <td style="width: 326px" >
                    <asp:TextBox ID="txtExamineIncome_type" runat="server" Width="40px" Enabled="false" ></asp:TextBox> 
                </td>
                <td class="htmltable_Left"><span style="color: red;">*</span>審查收入名稱</td>
                <td style="width: 326px">
                    <asp:TextBox ID="txtExamineIncome_name" runat="server" Width="150px" ></asp:TextBox>				
                </td>
            </tr>
             <tr>
                <td class="htmltable_Left" style="width: 194px"><span style="color: red;">*</span>計費單位</td>
                <td style="width: 326px"  >
                    <asp:TextBox ID="txtUnit" runat="server" Width="40px"></asp:TextBox>
                </td>
                 <td class="htmltable_Left" style="width: 133px"><span style="color: red;">*</span>計費單價</td>
                <td >
                    <asp:TextBox ID="txtUnitPrice_amt" runat="server" Width="100px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 194px"><span style="color: red;">*</span>收據字號</td>
                <td style="width: 326px"  >
                    <asp:TextBox ID="txtPaymentCode" runat="server"></asp:TextBox>
                </td>
                 <td class="htmltable_Left" style="width: 133px"><span style="color: red;">*</span>目前使用收據編號</td>
                <td >
                    <asp:TextBox ID="txtLatestReceipt_nos" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="btnDone" runat="server" Text="確認" OnClick="DoneBtn_Click" /> 		
                    <asp:Button ID="ClrBtn" runat="server" Text="放棄修改" OnClick="ClrBtn_Click" />
                    <asp:Button ID="btnGoBack" runat="server" Text="回查詢" PostBackUrl="~/PAY/PAY4/PAY4101_01.aspx"/> 
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

