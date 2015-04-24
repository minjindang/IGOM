<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SAL1111_01.aspx.vb" Inherits="SAL1111_01"  %>

<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLAuthorityDepart" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc1" TagName="UcDDLAuthorityMember" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
    function checkApplyHour(PRADDH, PRPAYH, PRMNYH, aid, type){
        var Apply_hour = document.getElementById(aid).value;
        Apply_hour = parseInt(Apply_hour==""?0:Apply_hour);
                
        PRADDH = parseInt(PRADDH==""?0:PRADDH);
        PRPAYH = parseInt(PRPAYH==""?0:PRPAYH);
        PRMNYH = parseInt(PRMNYH==""?0:PRMNYH);
        
        //每日可請領加班上限
        var A = document.getElementById('<%=hfA.ClientID %>').value;
        A = parseInt(A==""?0:A);
       
        if (Apply_hour > PRADDH - PRPAYH - (PRMNYH - Apply_hour)){
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
                    
        for (var i=0 ; i<=selects.length-1 ; i++){
            if (inputs[i].value=='1')
                Normal_total += parseInt(selects[i].value);
            else if (inputs[i].value=='2')
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
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" class="htmltable_Title" colspan="4">
                加班費請領</td>
        </tr>
        <tr>
            <td align="left" class="htmltable_Title2" colspan="4">
                條件畫面
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                申請年月</td>
            <td colspan="3" class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True">
                </asp:DropDownList>年<asp:DropDownList ID="ddlMonth" runat="server">
                </asp:DropDownList>月
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr id="tr1" runat="server" visible="false" >
            <td class="htmltable_Left" style="width: 120px">單位名稱
            </td>
            <td class="htmltable_Right" style="width: 230px" colspan="3">
                <uc1:UcDDLAuthorityDepart runat="server" ID="UcDDLDepart" OnSelectedIndexChanged="UcDDLDepart_SelectedIndexChanged" />
            </td>
        </tr>            
        <tr id="tr2" runat="server" visible="false">
            <td class="htmltable_Left">人員姓名</td>
            <td colspan="3">
                <uc1:UcDDLAuthorityMember runat="server" ID="UcDDLMember" />
            </td>
        </tr>
        <tr>
            <td  class="htmltable_Bottom" colspan="4">
                <asp:Button ID="cbQuery" runat="server"  Text="查詢" />
                <%--<asp:Button ID="cbConfirm" runat="server"  Text="確認" OnClientClick="javascript:if(!confirm('若按「確定」，系統會將加班資料註記為已領，並且不可反悔;\n若按「取消」，則可再次修改時數。')) return false;" />--%>
                <asp:Button ID="cbConfirm" runat="server"  Text="送出申請" />
                <input id="cbReset" type="button" value="重填" runat="server" />
                <asp:Button ID="cbRTP1" runat="server" Text="支領單" Visible="False" />
                <asp:Button ID="cbRTP2" runat="server" Text="加班單明細" Visible="False" />
                <asp:Button ID="cbBack" runat="server"  Text="回上頁" Visible="false" />
            </td>
        </tr>
    </table>
    
    <table cellpadding="0" cellspacing="0" class="tableStyle99" width="100%">
        <tr>
            <td align="center">
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Borderwidth="0px"
                    CssClass="Grid" PagerStyle-HorizontalAlign="Right" width="100%">
                    <Columns >
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label ID="lbNo" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PRNAME" HeaderText="人員姓名" />
                        <asp:TemplateField HeaderText="加班日期起">
                            <ItemTemplate>
                                <asp:Label ID="lbPRADDD_name" runat="server" Text='<%# Bind("PRADDD_name") %>'></asp:Label>
                                <asp:Label ID="lbPRADDD" runat="server" Text='<%# Bind("PRADDD") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="加班日期迄">
                            <ItemTemplate>
                                <asp:Label ID="lbPRADDE_name" runat="server" Text='<%# Bind("PRADDE_name") %>'></asp:Label>
                                <asp:Label ID="lbPRADDE" runat="server" Text='<%# Bind("PRADDE") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="加班類別">
                            <ItemTemplate>
                                <asp:Label ID="lbPRATYPE_name" runat="server" Text='<%# IIf(Eval("PRATYPE")="1","一般","專案") %>'></asp:Label>
                                <asp:Label ID="lbPRATYPE" runat="server" Text='<%# Bind("PRATYPE") %>' Visible="false"></asp:Label>
                                <asp:hiddenfield ID="hftype" runat="server" value='<%# Bind("PRATYPE") %>'></asp:hiddenfield>
                                <asp:HiddenField ID="hfCheckType" runat="server" value='<%# Bind("CheckType")%>'></asp:HiddenField>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="申請時間" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lbStart_time" runat="server" Text='<%# Bind("Start_time") %>'></asp:Label>~<asp:Label ID="lbEnd_time" runat="server" Text='<%# Bind("End_time") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="加班時間">
                            <ItemTemplate>
                                <asp:Label ID="lbPRSTIME_name" runat="server" Text='<%# Bind("PRSTIME_name") %>'></asp:Label>~<asp:Label ID="lbPRETIME_name" runat="server" Text='<%# Bind("PRETIME_name") %>'></asp:Label>
                                <asp:Label ID="lbPRSTIME" runat="server" Text='<%# Bind("PRSTIME") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbPRETIME" runat="server" Text='<%# Bind("PRETIME") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="加班時數">
                            <ItemTemplate>
                                <asp:Label ID="lbPRADDH" runat="server" Text='<%# Bind("PRADDH") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="已休時數">
                            <ItemTemplate>
                                <asp:Label ID="lbPRPAYH" runat="server" Text='<%# Bind("PRPAYH") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="已領時數">
                            <ItemTemplate>
                                <asp:Label ID="lbPRMNYH" runat="server" Text='<%# Bind("PRMNYH") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="請領時數">
                            <ItemTemplate>
                                <asp:TextBox ID="tbApply_hour" runat="server" Width="40" MaxLength="3" />
                                <asp:HiddenField ID="hfApply_hour" runat="server" Value='<%# Bind("apply_hour")%>'></asp:HiddenField>
                                <asp:HiddenField ID="hfOldApply_hour" runat="server" ></asp:HiddenField>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="事由">
                            <ItemTemplate>
                                <asp:Label ID="lbPRREASON" runat="server" Text='<%# Bind("PRREASON") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:Label ID="lbApplySep2" runat="server" Visible="false" ForeColor="red">※年度剩餘預算補申請</asp:Label>
    <asp:Label ID="lbTip" runat="server"></asp:Label>
    <asp:HiddenField ID="hftotal_prmnyh" runat="Server" />
    <asp:HiddenField ID="hfA" runat="server" />
    <asp:HiddenField ID="hfB" runat="server" />
    <asp:HiddenField ID="hfX" runat="server" />
    <asp:HiddenField ID="hfC" runat="server" />
    <asp:HiddenField ID="hfD" runat="server" />
    <asp:HiddenField ID="hfC_prmnyh" runat="server" />
    <asp:HiddenField ID="hfD_prmnyh" runat="server" />
    
    <asp:HiddenField ID="hfEmployeeType" runat="server" />
    <asp:HiddenField ID="hfDepart_id" runat="server" />
    <asp:HiddenField ID="hfId_card" runat="server" />

</asp:Content>

