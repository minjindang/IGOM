<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/MasterPage/Mobile.master" AutoEventWireup="true" CodeFile="MOB2202_01.aspx.cs" Inherits="Mobile_MOB2_MOB2202_01" EnableEventValidation="false" %>

<%@ Register Src="../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/UcShowDate.ascx" TagName="UcShowDate" TagPrefix="uc3" %>
<%@ Register Src="../../UControl/UcShowTime.ascx" TagName="UcShowTime" TagPrefix="uc4" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Panel ID="pnlQuery" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">         
            <tr id="tr01" runat="server">
                <td class="htmltable_Right">單位別
                </td>
                <td class="TdHeightLight">
                    <asp:DropDownList ID="ddlDepart_01" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlDepart_01_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlDepart_02" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlDepart_02_SelectedIndexChanged">
                    </asp:DropDownList></td>

            </tr>
            <tr id="tr02" runat="server"> 
                <td class="htmltable_Right" style="width: 100px">員工姓名</td>
                <td class="htmltable_Right">
                    <asp:DropDownList ID="ddlUserName" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr id="tr03" runat="server">
                <td class="htmltable_Right" style="width: 100px">員工編號</td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox></td>
            </tr>
            <tr id="tr04" runat="server">
                <td class="htmltable_Right" style="width: 120px; height: 26px;">職稱</td>
                <td class="htmltable_Right">
                    <asp:DropDownList ID="ddlJobtype" runat="server" AppendDataBoundItems="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="tr05" runat="server">
                <td class="htmltable_Right">在職狀態</td>
                <td class="htmltable_Right">
                    <asp:DropDownList ID="ddlQuit_Job" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="N" Text="現職員工"></asp:ListItem>
                        <asp:ListItem Value="Y" Text="離職員工"></asp:ListItem>
                        <asp:ListItem Value="1" Text="留職停薪"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="tr06" runat="server">
                <td class="htmltable_Right" style="width: 100px">性別
                </td>
                <td class="htmltable_Right" style="height: 26px">
                    <asp:DropDownList ID="ddlsextype" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="" Text="請選擇"></asp:ListItem>
                        <asp:ListItem Value="1" Text="男"></asp:ListItem>
                        <asp:ListItem Value="0" Text="女"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td class="htmltable_Right" style="width: 100px"><span style="color: Red">*</span>請假日期
                </td>
                <td class="TdHeightLight">
                    <uc2:UcDate ID="UcDate1" runat="server"></uc2:UcDate>
                    <uc2:UcDate ID="UcDate2" runat="server"></uc2:UcDate>
                    <asp:Label ID="lbTip" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Right" style="width: 100px">假別
                </td>
                <td class="htmltable_Right">
                    <asp:CheckBoxList ID="cblLeavetype" runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr id="tr07" runat="server">
                <td class="htmltable_Right" style="width: 100px">人員類別
                </td>
                <td class="htmltable_Right">
                    <asp:DropDownList ID="ddlEmployeetype" runat="server" AppendDataBoundItems="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Right" style="width: 100px">狀態</td>
                <td class="htmltable_Right">
                    <asp:CheckBoxList ID="cblStatus" runat="server" DataTextField="code_desc1" DataValueField="code_no" RepeatColumns="2" RepeatDirection="Horizontal" />
                </td>

            </tr>

            <tr>
                <td align="center" colspan="4" class="TdHeightLight">
                    <table width="100%">
                        <tr>
                            <td width="50%">
                                <asp:Button ID="Button2" runat="server" Text="回上頁" OnClick="Button2_Click" UseSubmitBehavior="false"/></td>
                            <td>
                                <asp:Button ID="btnQuery" runat="server" Text="查詢" UseSubmitBehavior="false"
                                    OnClick="btnQuery_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlResult" runat="server" Visible="false">
        <table id="tbq" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
            >          
            <tr>
                <td class="htmltable_Title2" style="width: 100%" align="center">查詢結果
                </td>
            </tr>
            <tr>
                <td style="width: 100%" class="TdHeightLight" valign="top">
                    <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="False" 
                        BorderWidth="0px" PageSize="30"
                        AllowPaging="True" PagerStyle-HorizontalAlign="right" Width="100%"
                        CellPadding="5" BorderStyle="None" GridLines="None"
                        EmptyDataText="查無資料!!" EnableModelValidation="True" 
                        OnPageIndexChanging="gvlist_PageIndexChanging" 
                        OnRowDataBound="gvlist_RowDataBound" 
                        OnSelectedIndexChanging="gvlist_SelectedIndexChanging" ShowHeader="False">
                        <Columns> 
                            <asp:TemplateField >
                                <ItemTemplate>
                                    <table style="width: 100%;" bgcolor="White" frame="box">                                    
                                        <tr>
                                        <td rowspan="11" align="center" valign="top" width="6%">
                                         <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (Container.DataItemIndex+1).ToString() %>' ForeColor="#0000CC"></asp:Label>
                            
                                        </td>
                                            <td colspan="2" width="47%">
                                                <asp:Label ID="lbStatus" runat="server" Text='<%# Eval("Case_status")%>' ForeColor="Red"></asp:Label>
                                                </td>
                                        </tr>
                                               <tr>                                        
                                        <td colspan="2" width="47%">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                    </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbId_card" runat="server" Text='<%# Eval("Id_card")%>' ForeColor="#0000CC"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbUser_name" runat="server" Text='<%# Eval("User_name")%>' ForeColor="#0000CC"></asp:Label></td>
                                        </tr>
                                           <tr>                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                    </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbLeave_type" runat="server" Text='<%# Eval("Leave_name")%>' ForeColor="#0000CC"></asp:Label></td>
                                            <td>
                                                請假日時：<asp:Label ID="lbLeave_hours" runat="server" Text='<%# Eval("Leave_hours")%>' ForeColor="#0000CC"></asp:Label></td>
                                        </tr>
                                           <tr>                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                    </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table><tr><td>請假開始日期：<font color="#0000CC"><uc3:UcShowDate ID="UcShowDate1" runat="server" Text='<%# Eval("Start_date")%>' /></font></td>
                                                    <td>&nbsp;<font color="#0000CC"><uc4:UcShowTime ID="UcShowTime1" runat="server" Text='<%# Eval("Start_time")%>' /></font></td></tr> </table>
                                            </td>
                                        </tr>
                                           <tr>                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                    </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table><tr><td>請假結束日期：<font color="#0000CC"><uc3:UcShowDate ID="UcShowDate2" runat="server" Text='<%# Eval("End_date")%>' /></font></td>
                                                    <td>&nbsp;<font color="#0000CC"><uc4:UcShowTime ID="UcShowTime2" runat="server" Text='<%# Eval("End_time")%>' /></font></td></tr> </table>
                                                
                                                
                                                
                                            </td>
                                        </tr>
                                           <tr>                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                    </tr>
                                        <tr>
                                            <td colspan="2">代理人:<asp:Label ID="lbDeputy" runat="server" Text='<%# Eval("Deputy")%>' ForeColor="#0000CC"></asp:Label></td>
                                        </tr>
                                    </table>
                                    <div style="display: none">
                                        簽核流程<asp:Label ID="lbLast_name" runat="server" Text='<%# Bind("Process")%>'></asp:Label>
                                        請假事由<asp:Label ID="lbReason" runat="server" Text='<%# Eval("Reason")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" />
                        <EmptyDataTemplate>
                            查無資料!!
                        </EmptyDataTemplate>
                    
                        <PagerSettings Position="TopAndBottom" />
                        <EmptyDataRowStyle CssClass="EmptyRow" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center" class="TdHeightLight">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Button ID="Button3" runat="server" Text="回上頁" UseSubmitBehavior="false"
                                 OnClick="Button3_Click" /></td>
                           
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlDetail" runat="server" Visible="false">
        <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" align="center"
            bgcolor="White" frame="box">          
            <tr>
                <td class="htmltable_Title2" style="width: 100%" align="center" colspan="2">詳細資料
                </td>
            </tr>
            </table>
        <table id="Table3" runat="server" border="0" cellpadding="3" cellspacing="0" width="95%" align="center" bgcolor="White" frame="box">  

            <tr>
                <td width="40%">項次</td>
                <td >
                    <asp:Label ID="lblSerNo" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
              <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >狀態</td>
                <td >
                    <asp:Label ID="Case_status" runat="server" Text="Label" ForeColor="Red"></asp:Label></td>
            </tr>
              <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >員工卡號</td>
                <td >
                    <asp:Label ID="Id_card" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
              <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >員工姓名</td>
                <td >
                    <asp:Label ID="User_name" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
              <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >假別</td>
                <td >
                    <asp:Label ID="Leave_name" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
              <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >請假日時</td>
                <td >
                    <asp:Label ID="Leave_hours" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
              <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >請假開始日期</td>
                <td >
                    <asp:Label ID="Start_date" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label><br />
                    <asp:Label ID="Start_time" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label>
                </td>
            </tr>
              <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >請假結束日期</td>
                <td >
                    <asp:Label ID="End_date" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label><br />
                    <asp:Label ID="End_time" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
              <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >代理人</td>
                <td >
                    <asp:Label ID="Deputy" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label>
                </td>
            </tr>
              <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >簽核流程</td>
                <td >
                    <asp:Label ID="Process" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label>
                </td>
            </tr>
              <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >請假事由</td>
                <td >
                    <asp:Label ID="Reason" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>   

            </table>
            <table width="95%" align="center">    
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="回上頁" OnClick="Button1_Click" UseSubmitBehavior="false" />
                </td>
            </tr>

        </table>
    </asp:Panel>
</asp:Content>

