<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL3128_02.aspx.cs" Inherits="SAL3128_02" %>
<%@ Register src="../../UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc4" %>
<%@ Register src="../../UControl/SAL/ucSaCode.ascx" tagname="ucSaCode" tagprefix="uc2" %>
<%@ Register src="../../UControl/SAL/UcSelectOrg.ascx" tagname="UcSelectOrg" tagprefix="uc2" %>
<%@ Register src="../../UControl/SAL/ucDateDropDownList.ascx" tagname="ucDateDropDownList" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="6">
                非員工所得扣繳資料檔維護
            </td>
        </tr> 
     <tr>
         <td class="htmltable_Left"  >
            身分證字號:
         </td>
         <td class="htmltable_Right"  colspan="3" >
            <asp:TextBox ID="tbidno" runat="server" MaxLength="10" AutoPostBack="true" OnTextChanged="tbidno_TextChanged" />
            <asp:Label ID="lbStatus" runat="server" Visible="false" />
         </td>
         <td class="htmltable_Left" >
            身分別:
         </td>
         <td class="htmltable_Right">
                <asp:DropDownList ID="ddl_base_type" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_base_type_Selected_Changed">               
                    <asp:ListItem Value="1" Text="個人" Selected="True" />
                    <asp:ListItem Value="2" Text="外僑" />
                    <asp:ListItem Value="3" Text="事業機關" />            
                </asp:DropDownList>
         </td>
     </tr>
     <tr>
         <td class="htmltable_Left"  colspan="1" >
            人員姓名:
         </td>
         <td class="htmltable_Right"  colspan="3" >
            <asp:TextBox ID="tbName" runat="server" MaxLength="50" />
         </td>
         <td class="htmltable_Left" >
            預算來源:
         </td>
         <td class="htmltable_Right"  >
           <uc2:ucSaCode ID="UcSaCode3" runat="server"  Code_Kind="P" Code_sys="002"
                            Code_type="018" ControlType="2" EnableTheming="True" 
                    Visible="True" Mode="selectone" /> 
         </td>
     </tr>
     <tr>
         <td class="htmltable_Left"  colspan="1">
            地址:
         </td>
         <td class="htmltable_Right"  colspan="5" >
            <asp:TextBox ID="tbAddress" runat="server" MaxLength="100" Width="400px" />
         </td>
     </tr>
     <tr runat="server" id="tr_1" visible="true">
         <td class="htmltable_Left"  colspan="1">
            服務單位:
         </td>
         <td class="htmltable_Right"  colspan="3" >
            <asp:TextBox ID="tbServicePlace" runat="server" MaxLength="10"  />
         </td>
         <td class="htmltable_Left"  colspan="1">
            職稱:
         </td>
         <td class="htmltable_Right"  colspan="1" >
            <asp:TextBox ID="tbDcodeName" runat="server" MaxLength="25" />
         </td>
     </tr>
     <tr>
     <td class="htmltable_Left">
     所得年月:
     </td>
     <td class="htmltable_Right">
         <asp:DropDownList ID="ddlYear" runat="server"  />
         <asp:DropDownList ID="ddlMonth" runat="server" />
     </td>
      <td class="htmltable_Left">
      給付日期:
     </td>
     <td class="htmltable_Right">
         <uc4:UcDate ID="UcDate3" runat="server" />
     </td>
     <td class="htmltable_Left">
      補充保費:
     </td>
     <td class="htmltable_Right">
         <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
             <asp:ListItem Selected="True">Y</asp:ListItem>
             <asp:ListItem>N</asp:ListItem>
         </asp:DropDownList>
     </td>
     </tr>
     <tr>
     <td class="htmltable_Left">
       所得格式:
     </td>
     <td class="htmltable_Right" >
         <uc2:ucSaCode ID="UcSaCode2" runat="server"  Code_Kind="P" Code_sys="003"
                            Code_type="004" ControlType="2" Mode="selectone" />
     </td>
     <td class="htmltable_Left">
       所得明細代號:
     </td>
     <td class="htmltable_Right" >
         <asp:DropDownList ID="Doc_Type" runat="server" AutoPostBack="True" 
             Visible="False">
         </asp:DropDownList>
     </td>
      <td class="htmltable_Left">
       稅率:
     </td>
     <td class="htmltable_Right" >
      <asp:TextBox ID="TextBox2" runat="server" Style="text-align:right" MaxLength="8" ></asp:TextBox>%
     </td>
     </tr>
     <tr>
        <td class="htmltable_Left">所得額:
        </td>
        <td class="htmltable_Right" >
         <asp:TextBox ID="TextBox1" runat="server" Style="text-align:right" MaxLength="8" 
                ontextchanged="TextBox1_TextChanged" AutoPostBack="True"></asp:TextBox>
        </td>
        <td class="htmltable_Left">所得稅:
        </td>
        <td class="htmltable_Right" > 
        <asp:TextBox ID="TextBox3" runat="server" Style="text-align:right" MaxLength="8" ></asp:TextBox> 
        </td>
        <td class="htmltable_Left">補充保費:
        </td>
        <td class="htmltable_Right" >
            <asp:TextBox ID="INCO_HEALTH_EXT" runat="server"></asp:TextBox>
        </td>
     </tr>
     <tr>
        <td class="htmltable_Left"  colspan="1">房屋地址:
        </td>
        <td class="htmltable_Right"  colspan="3" >
            <asp:TextBox ID="INCO_RENT_ADDR" runat="server" Width="400px"></asp:TextBox>
        </td>
        <td class="htmltable_Left">付款憑單:
        </td>
        <td class="htmltable_Right" >
            <asp:TextBox ID="INCO_VOUCHERS" runat="server"></asp:TextBox>
        </td>
     </tr>
     <tr>
        <td class="htmltable_Left" colspan="1" >房屋稅籍編號/所得註記:
        </td>
        <td class="htmltable_Right"  colspan="3" >
             <asp:TextBox ID="INCO_RENT_NO" runat="server" Width="400px"></asp:TextBox>
        </td>
        <td class="htmltable_Left" >收入傳票:
        </td>
        <td class="htmltable_Right" >
             <asp:TextBox ID="INCO_SUMMONS" runat="server"></asp:TextBox>
        </td>
     </tr>
                     <tr>
                     <td class="htmltable_Bottom" colspan="6" style="border-top: none;" width="50%">
                        <asp:Button ID="btn_ok" runat="server" Text="新增" onclick="btn_ok_Click" />
                        <asp:Button ID="btn_ok_back" runat="server" Text="新增後回上頁" OnClick="btn_ok_back_Click" />
                        <asp:Button ID="btn_cancel" runat="server" Text="回上頁" 
                            onclick="btn_cancel_Click" />
                    </td>
                    </tr>
     </table>

</asp:Content>
