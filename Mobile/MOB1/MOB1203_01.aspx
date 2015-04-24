<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/MasterPage/Mobile.master" AutoEventWireup="true" CodeFile="MOB1203_01.aspx.cs" Inherits="Mobile_MOB1_MOB1203_01" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <script type="text/javascript">
     function checkApplyHour(PRADDH, PRPAYH, PRMNYH, aid, type) {
         var Apply_hour = document.getElementById(aid).value;
         Apply_hour = parseInt(Apply_hour == "" ? 0 : Apply_hour);

         PRADDH = parseInt(PRADDH == "" ? 0 : PRADDH);
         PRPAYH = parseInt(PRPAYH == "" ? 0 : PRPAYH);
         PRMNYH = parseInt(PRMNYH == "" ? 0 : PRMNYH);

         //每日可請領加班上限
         var A = document.getElementById('<%=hfA.ClientID %>').value;
         A = parseInt(A == "" ? 0 : A);

         if (Apply_hour > PRADDH - PRPAYH - (PRMNYH - Apply_hour)) {
             alert("請領時數超過當日可請領數");
             document.getElementById(aid).value = "0";
             return;
         }
         /*
         if (type == "1" && Apply_hour > A){
         alert("每日可請領一般加班上限為"+A+"小時");
         document.getElementById(aid).value = "0";
         return;
         }*/

         var selects = document.getElementById('<%=gv.ClientID %>').getElementsByTagName("select");
         var inputs = document.getElementById('<%=gv.ClientID %>').getElementsByTagName("input");
         var Normal_total = 0;
         var Project_total = 0;

         for (var i = 0; i <= selects.length - 1; i++) {
             if (inputs[i].value == '1')
                 Normal_total += parseInt(selects[i].value);
             else if (inputs[i].value == '2')
                 Project_total += parseInt(selects[i].value);
         }
         /*                                        
         if(type == "1"){
         //一般加班可領餘額
         var C = document.getElementById('<%=hfC.ClientID %>').value;
         C = parseInt(C==""?0:C);
                        
         if (Normal_total > C + PRMNYH){
         alert("一般加班請領時數超過當月可請領數!");
         document.getElementById(aid).value = "0";
         return;
         }
         }
         else if(type == "2"){
         //專案加班可領餘額
         var D = document.getElementById('<%=hfD.ClientID %>').value;
         D = parseInt(D==""?0:D);
            
         if (Project_total > D + PRMNYH){
         alert("專案加班請領時數超過當月可請領數!");
         document.getElementById(aid).value = "0";
         return;
         }
         }
        
        
         //每月可請領加班上限
         var B = document.getElementById('<%=hfB.ClientID %>').value;
         B = parseInt(B==""?0:B);
        
         //已請領加班時數
         var total_prmnyh = document.getElementById('<%=hftotal_prmnyh.ClientID %>').value;
         total_prmnyh = parseInt(total_prmnyh==""?0:total_prmnyh);
        
         var total = 0;
         total = Normal_total + Project_total + total_prmnyh;
                
         if (total > B){
         alert("請領時數超過每月請領加班上限!");
         //document.getElementById(aid).value = "0";
         for (var i=0 ; i<=selects.length-1 ; i++){
         selects[i].value = "0";
         }
         return;
         }*/

     }

    </script>
    <table id="tbq" runat="server" cellpadding="0" cellspacing="0" width="99%">
        <tr>
            <td align="left" class="htmltable_Title2" colspan="2">條件畫面
            </td>
        </tr>
        <tr>
            <td class="htmltable_Right" width="25%">查詢年月</td>
            <td class="htmltable_Right" width="75%">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table width="100%"><tr>
                            <td><asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                            <td>年</td>
                            <td><asp:DropDownList ID="ddlMonth" runat="server"></asp:DropDownList></td>
                            <td>月</td>
                               </tr> </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td width="50%">
                            <asp:Button ID="Button2" runat="server" Text="回上頁" UseSubmitBehavior="false" OnClick="Button2_Click" /></td>
                        <td>
                            <asp:Button ID="cbQuery" runat="server" Text="查詢" UseSubmitBehavior="false" OnClick="cbQuery_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <table id="tbS" runat="server" cellpadding="0" cellspacing="0"
        width="100%" visible="false">
        <tr>
            <td align="left" class="htmltable_Title2">申請畫面</td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                   CellPadding="5" BorderStyle="None" GridLines="None"
                    PagerStyle-HorizontalAlign="Right" Width="100%" OnRowDataBound="gv_RowDataBound" EnableModelValidation="True" ShowHeader="False">
                    <Columns>                     
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table width="100%" align="left"  bgcolor="White" frame="box">
                                    <tr align="left">
                                     <td rowspan = "21" width="10%"> 
                                          <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (Container.DataItemIndex+1).ToString() %>'></asp:Label> 
                                        </td>
                                        <td colspan="2">加班日期 :</td>
                                    </tr>
                                      <tr>                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                        </tr>
                                    <tr align="left">
                                        <td>
                                            <asp:Label ID="gv_lbPRADDD_name" runat="server" Text='<%# Bind("PRADDD_name") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="gv_lbPRADDE_name" runat="server" Text='<%# Bind("PRADDE_name") %>'></asp:Label></td>
                                    </tr>
                                      <tr>                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                        </tr>
                                    <tr align="left">
                                        <td>加班類別 :
                                            <asp:Label ID="gv_lbPRATYPE_name" runat="server" Text='<%# Bind("PRATYPE_name") %>'></asp:Label>
                                            <asp:Label ID="gv_lbPRATYPE" runat="server" Text='<%# Bind("PRATYPE") %>' Visible="false"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="hftype" runat="server" Value='<%# Bind("PRATYPE") %>'></asp:HiddenField>
                                        </td>
                                    </tr>
                                      <tr>                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                        </tr>
                                    <tr align="left">
                                        <td colspan="2">申請時間 :</td>
                                    </tr>
                                      <tr>                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                        </tr>
                                    <tr align="left">
                                        <td>
                                            <asp:Label ID="gv_lbStart_time" runat="server" Text='<%# Bind("Start_time") %>'></asp:Label></td>
                                       <td> <asp:Label ID="gv_lbEnd_time" runat="server" Text='<%# Bind("End_time") %>'></asp:Label></td>
                                    </tr>
                                      <tr>                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                        </tr>
                                    <tr align="left">
                                        <td colspan="2">加班時間 :</td>
                                    </tr>
                                      <tr>                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                        </tr>
                                    <tr align="left">
                                        <td>
                                            <asp:Label ID="gv_lbPRSTIME_name" runat="server" Text='<%# Bind("PRSTIME_name") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="gv_lbPRETIME_name" runat="server" Text='<%# Bind("PRETIME_name") %>'></asp:Label></td>
                                    </tr>
                                      <tr>                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                        </tr>
                                    <tr align="left">
                                        <td>加班時數 :
                                            <asp:Label ID="gv_lbPRADDH" runat="server" Text='<%# Bind("PRADDH") %>'></asp:Label></td>
                                        <td>已休時數 :
                                            <asp:Label ID="gv_lbPRPAYH" runat="server" Text='<%# Bind("PRPAYH") %>'></asp:Label></td>
                                    </tr>
                                      <tr>                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                        </tr>
                                    <tr align="left">
                                        <td colspan="2">已領時數 :
                                            <asp:Label ID="gv_lbPRMNYH" runat="server" Text='<%# Bind("PRMNYH") %>'></asp:Label></td>
                                    </tr>
                                      <tr>                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                        </tr>
                                    <tr align="left">
                                        <td>請領時數 :</td>
                                        <td>
                                      <asp:TextBox ID="gv_txtApply_hour" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                      <tr>                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                        </tr>
                                    <tr align="left">
                                        <td colspan="2">
                                        事由 :
                                            <asp:Label ID="gv_lbPRREASON" runat="server" Text='<%# Bind("PRREASON") %>'></asp:Label></td>
                                    </tr>
                                </table>
                                <asp:Label ID="gv_lbPRADDD" runat="server" Text='<%# Bind("PRADDD") %>' Visible="false"></asp:Label>
                                <asp:Label ID="gv_lbPRADDE" runat="server" Text='<%# Bind("PRADDE") %>' Visible="false"></asp:Label>
                                <asp:Label ID="gv_lbPRSTIME" runat="server" Text='<%# Bind("PRSTIME") %>' Visible="false"></asp:Label>
                                <asp:Label ID="gv_lbPRETIME" runat="server" Text='<%# Bind("PRETIME") %>' Visible="false"></asp:Label>
                                <asp:Label ID="gv_lbApply_hour" runat="server" Visible="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />                
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                    <EmptyDataTemplate>查無資料</EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="100%">
                    <tr>
                        <td width="50%">
                            <asp:Button ID="cbBack" runat="server" Text="回上頁" UseSubmitBehavior="false" OnClick="cbBack_Click" /></td>
                        <td>
                            <asp:Button ID="cbConfirm" runat="server" Text="送出申請" UseSubmitBehavior="false" OnClick="cbConfirm_Click" /></td>
                    </tr>
                </table>
                
                <input id="cbReset" type="button" value="重填" runat="server" Visible="false"/><asp:Button
                    ID="cbRTP1" runat="server" Text="支領單" Visible="False" /><asp:Button ID="cbRTP2" runat="server"
                        Text="加班單明細" Visible="False" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbApplySep2" runat="server" Visible="false" ForeColor="red">※年度剩餘預算補申請</asp:Label></td>
        </tr>
    </table>
    <asp:Label ID="lbTip" runat="server"></asp:Label>
    <asp:HiddenField ID="hftotal_prmnyh" runat="Server" />
    <asp:HiddenField ID="hfA" runat="server" />
    <asp:HiddenField ID="hfB" runat="server" />
    <asp:HiddenField ID="hfX" runat="server" />
    <asp:HiddenField ID="hfC" runat="server" />
    <asp:HiddenField ID="hfD" runat="server" />
    <asp:HiddenField ID="hfC_prmnyh" runat="server" />
    <asp:HiddenField ID="hfD_prmnyh" runat="server" />
</asp:Content>

