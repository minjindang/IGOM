<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/MasterPage/Mobile.master" AutoEventWireup="true" CodeFile="MOB2203_01.aspx.cs" Inherits="Mobile_MOB2_MOB22013_01" EnableEventValidation="false" %>

<%@ Register Src="../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/UcShowDate.ascx" TagName="UcShowDate" TagPrefix="uc3" %>
<%@ Register Src="../../UControl/UcShowTime.ascx" TagName="UcShowTime" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlQuery" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">         
            <tr>
                <td class="htmltable_Right">單位 </td>
                <td class="htmltable_Right">
                    <asp:DropDownList ID="ddlDepart_01" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlDepart_01_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlDepart_02" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlDepart_02_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Right">員工姓名
                </td>

                <td class="htmltable_Right">
                    <asp:DropDownList ID="ddlUserName" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id = "tr1" runat ="server">
                <td class="htmltable_Right">員工編號
                </td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="htmltable_Right">加班日期
                </td>
                <td class="TdHeightLight" style="width: 250px" id="OvertimeValue" runat="server">
                    <uc2:UcDate ID="UcDate1" runat="server"></uc2:UcDate>
                    <uc2:UcDate ID="UcDate2" runat="server"></uc2:UcDate>
                    <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Right">狀態</td>
                <td class="htmltable_Right">
                    <asp:CheckBoxList ID="cblStatus" runat="server" DataTextField="code_desc1" DataValueField="code_no" RepeatColumns="2" RepeatDirection="Horizontal" />

                </td>

            </tr>
            <tr>
                <td align="center" colspan="4" class="TdHeightLight">
                        <table width="100%">
                            <tr><td><asp:Button ID="Button2" runat="server" Text="回上頁" UseSubmitBehavior="false" OnClick="Button2_Click"/></td>
                                <td><asp:Button ID="btnQuery" runat="server" Text="查詢" UseSubmitBehavior="false"
                        OnClick="btnQuery_Click" /></td></tr>
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
                    <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="False" BorderWidth="0px" PageSize="30"
                        AllowPaging="True" PagerStyle-HorizontalAlign="right" Width="100%"
                           CellPadding="5" BorderStyle="None" GridLines="None"
                        EmptyDataText="查無資料!!" EnableModelValidation="True" OnPageIndexChanging="gvlist_PageIndexChanging" OnRowDataBound="gvlist_RowDataBound" OnSelectedIndexChanged="gvlist_SelectedIndexChanged" OnSelectedIndexChanging="gvlist_SelectedIndexChanging" ShowHeader="False">
                        <Columns>  
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table style="width: 100%;" bgcolor="White" frame="box">
                                        <tr>
                                        <td rowspan ="7" align="center" valign="top">
                                          <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (Container.DataItemIndex+1).ToString() %>'></asp:Label>                         
                                        </td>
                                            <td colspan="2">
                                                <asp:Label ID="lbStatus" runat="server" Text='<%# Eval("Case_status")%>' ForeColor="Red"></asp:Label></td>
                                        </tr>
                                          <tr>                                        
                                        <td colspan="2">
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
                                                <asp:Label ID="lbPRATYPE" runat="server" Text='<%# Eval("PRATYPE")%>' ForeColor="#0000CC"></asp:Label></td>
                                            <td>
                                                請示時數：<asp:Label ID="lbLeave_hours" runat="server" Text='<%# Eval("Leave_hours")%>' ForeColor="#0000CC"></asp:Label></td>
                                        </tr>
                                          <tr>                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                    </tr>
                                        <tr>
                                            <td colspan="2">
                                                加班起迄時間<br />
                                                <font color="#0000CC"><uc3:UcShowDate ID="UcShowDate1" runat="server" Text='<%# Eval("Start_date")%>' /></font>
                                                <font color="#0000CC"><uc4:UcShowTime ID="UcShowTime1" runat="server" Text='<%# Eval("Start_time")%>' /></font>
                                                <br />
                                                <font color="#0000CC"><uc3:UcShowDate ID="UcShowDate2" runat="server" Text='<%# Eval("End_date")%>' /></font>
                                                <font color="#0000CC"><uc4:UcShowTime ID="UcShowTime2" runat="server" Text='<%# Eval("End_time")%>' /></font>
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="display: none">
                                        科長<br />主管<asp:Label ID="lbBossname" runat="server" Text='<%# Eval("Bossname")%>'></asp:Label>
                                        加班事由<br />實際時數<asp:Label ID="lbReason" runat="server" Text='<%# Eval("Reason")%>'></asp:Label><br />
                                        <asp:Label ID="lbPRADDH" runat="server" Text='<%# Eval("PRADDH")%>'></asp:Label>
                                        請領時數<asp:Label ID="lbPRMNYH" runat="server" Text='<%# Eval("PRMNYH") %>'></asp:Label>
                                        補休時數<asp:Label ID="lbPRPAYH" runat="server" Text='<%# Eval("PRPAYH")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" />
                        <EmptyDataTemplate>
                            查無資料!!
                        </EmptyDataTemplate>                    
                        <PagerSettings Position="TopAndBottom" />
                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                    </asp:GridView>
                </td>
            </tr>
                        <tr>
                <td class="TdHeightLight" colspan="2">
                    <asp:Button ID="Button3" runat="server" Text="回上頁" UseSubmitBehavior="false" OnClick="Button3_Click"/>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlDetail" runat="server" Visible="false">
        <table id="Table1" runat="server" border="0" cellpadding="3" cellspacing="0" width="100%"
             bgcolor="White" frame="box">
            <tr>
                <td class="style1" align="center" colspan="2">詳細資料
                </td>
            </tr>
              <tr>                                       
            <td colspan="2">
                <div style="background: black; width: 100%; height: 1px"></div>
            </td>
           </tr>
            <tr>
                <td width="30%">項次</td>
                <td >
                    <asp:Label ID="lblSerNo" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                       
            <td colspan="2">
                <div style="background: black; width: 100%; height: 1px"></div>
            </td>
           </tr>
            <tr>
                <td>狀態</td>
                <td>
                    <asp:Label ID="Case_status" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                       
            <td colspan="2">
                <div style="background: black; width: 100%; height: 1px"></div>
            </td>
           </tr>
            <tr>
                <td>員工編號</td>
                <td>
                    <asp:Label ID="Id_card" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                       
            <td colspan="2">
                <div style="background: black; width: 100%; height: 1px"></div>
            </td>
           </tr>
            <tr>
                <td>員工姓名</td>
                <td>
                    <asp:Label ID="User_name" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                       
            <td colspan="2">
                <div style="background: black; width: 100%; height: 1px"></div>
            </td>
           </tr>
            <tr>
                <td>一般/專案</td>
                <td>
                    <asp:Label ID="PRATYPE" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                       
            <td colspan="2">
                <div style="background: black; width: 100%; height: 1px"></div>
            </td>
           </tr>
            <tr>
                <td>請示時數</td>
                <td>
                    <asp:Label ID="Leave_hours" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                       
            <td colspan="2">
                <div style="background: black; width: 100%; height: 1px"></div>
            </td>
           </tr>
            <tr>
                <td>加班開始時間</td>
                <td>
                    <asp:Label ID="Start_date" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label><br />
                    <asp:Label ID="Start_time" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                       
            <td colspan="2">
                <div style="background: black; width: 100%; height: 1px"></div>
            </td>
           </tr>
            <tr>
                <td>加班結束時間</td>
                <td>
                    <asp:Label ID="End_date" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label><br />
                    <asp:Label ID="End_time" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                       
            <td colspan="2">
                <div style="background: black; width: 100%; height: 1px"></div>
            </td>
           </tr>
            <tr>
                <td>科長<br />
                    主管</td>
                <td>
                    <asp:Label ID="Bossname" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                       
            <td colspan="2">
                <div style="background: black; width: 100%; height: 1px"></div>
            </td>
           </tr>
            <tr>
                <td>加班事由</td>
                <td>
                    <asp:Label ID="Reason" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                       
            <td colspan="2">
                <div style="background: black; width: 100%; height: 1px"></div>
            </td>
           </tr>
            <tr>
                <td>實際時數</td>
                <td>
                    <asp:Label ID="PRADDH" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                       
            <td colspan="2">
                <div style="background: black; width: 100%; height: 1px"></div>
            </td>
           </tr>
            <tr>
                <td>請領時數</td>
                <td>
                    <asp:Label ID="PRMNYH" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                       
            <td colspan="2">
                <div style="background: black; width: 100%; height: 1px"></div>
            </td>
           </tr>
            <tr>
                <td>補休時數</td>
                <td>
                    <asp:Label ID="PRPAYH" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                       
            <td colspan="2">
                <div style="background: black; width: 100%; height: 1px"></div>
            </td>
           </tr>
            <tr>
                <td class="TdHeightLight" colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="回上頁" OnClick="Button1_Click" UseSubmitBehavior="false"/>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

