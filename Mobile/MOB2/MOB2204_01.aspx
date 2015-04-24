<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/MasterPage/Mobile.master" AutoEventWireup="true" CodeFile="MOB2204_01.aspx.cs" Inherits="Mobile_MOB2_MOB2204_01" EnableEventValidation="false" %>

<%@ Register Src="../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/UcShowDate.ascx" TagName="UcShowDate" TagPrefix="uc3" %>
<%@ Register Src="../../UControl/UcShowTime.ascx" TagName="UcShowTime" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlQuery" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">          
            <tr id="tr1" runat="server">
                <td class="htmltable_Right">單位別
                </td>
                <td class="htmltable_Right">
                    <!--UcDDLDepart-->
                    <asp:DropDownList ID="ddlDepart_01" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlDepart_01_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlDepart_02" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlDepart_02_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>

            </tr>
            <tr id="tr2" runat="server">
                <td class="htmltable_Right">員工姓名</td>
                <td class="htmltable_Right">
                    <!--UcDDLMember-->
                    <asp:DropDownList ID="ddlUserName" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr id="tr3" runat="server">
                <td class="htmltable_Right">員工編號</td>
                <td class="htmltable_Right">
                    <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox></td>
            </tr>
            <tr id="tr4" runat="server">
                <td class="htmltable_Right">在職狀態</td>
                <td class="htmltable_Right">
                    <asp:DropDownList ID="ddQuit_Job" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="N" Text="現職員工"></asp:ListItem>
                        <asp:ListItem Value="Y" Text="離職員工"></asp:ListItem>
                        <asp:ListItem Value="1" Text="留職停薪"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="tr5" runat="server">
                <td class="htmltable_Right">性別
                </td>
                <td class="htmltable_Right">
                    <asp:DropDownList ID="ddlsextype" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="" Text="請選擇"></asp:ListItem>
                        <asp:ListItem Value="1" Text="男"></asp:ListItem>
                        <asp:ListItem Value="0" Text="女"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Right" ><span style="color: Red">*</span>
                    公差日期
                </td>
                <td class="htmltable_Right">
                    <uc2:UcDate ID="UcDate1" runat="server"></uc2:UcDate>
                    <uc2:UcDate ID="UcDate2" runat="server"></uc2:UcDate>
                    <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Right">公差類別
                </td>
                <td class="htmltable_Right">
                    <asp:DropDownList ID="ddlLocationFlag" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="" Text="--請選擇--"></asp:ListItem>
                        <asp:ListItem Value="0" Text="國內"></asp:ListItem>
                        <asp:ListItem Value="1" Text="國外"></asp:ListItem>
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
                <td align="center" colspan="2" class="TdHeightLight">

                        <table width="100%">
                            <tr><td><asp:Button ID="Button2" runat="server" Text="回上頁" UseSubmitBehavior="false" OnClick="Button2_Click"/></td>
                                <td><asp:Button ID="btnQuery" runat="server" Text="查詢" UseSubmitBehavior="false"
                        OnClick="btnQuery_Click" /></td></tr>
                        </table>

                </td>
            </tr>
            <tr><td></td></tr>
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
                        EmptyDataText="查無資料!!" EnableModelValidation="True"
                        CellPadding="5" BorderStyle="None" GridLines="None"
                        OnPageIndexChanging="gvlist_PageIndexChanging" OnSelectedIndexChanging="gvlist_SelectedIndexChanging" OnRowDataBound="gvlist_RowDataBound" OnSelectedIndexChanged="gvlist_SelectedIndexChanged" ShowHeader="False">
                        <Columns>                                                            
                            <asp:TemplateField >
                                <ItemTemplate>
                                    <table style="width: 100%;" bgcolor="White" frame="box">
                                        <tr>
                                        <td rowspan="9" width="15%" align="center" valign="top">
                                          <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (Container.DataItemIndex+1).ToString() %>'></asp:Label>   
                                        </td>
                                            <td colspan="3">
                                                <asp:Label ID="lbdepart_id" runat="server" Text='<%# Eval("Case_status") %>' ForeColor="Red"></asp:Label></td>
                                        </tr>
                                          <tr>                                        
                                        <td colspan="3">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                    </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbApply_idcard" runat="server" Text='<%# Eval("Id_card")%>' ForeColor="#0000CC"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbApply_name" runat="server" Text='<%# Eval("User_name")%>' ForeColor="#0000CC"></asp:Label></td>
                                            <td>
                                                公差日期：<font color="#0000CC"><uc3:UcShowDate ID="UcShowDate1" runat="server" Text='<%# Eval("Start_date")%>' /></font>
                                            </td>
                                        </tr>
                                          <tr>                                        
                                        <td colspan="3">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                    </tr>
                                        <tr>
                                            <td>
                                                地點：<asp:Label ID="lbPlace" runat="server" Text='<%# Eval("Place")%>' ForeColor="#0000CC"></asp:Label></td>
                                            <td>
                                               日時： <asp:Label ID="Label2" runat="server" Text='<%# Eval("Leave_hours")%>' ForeColor="#0000CC"></asp:Label></td>
                                            <td>
                                                類別：<asp:Label ID="lbLeave_name" runat="server" Text='<%# Eval("Leave_name")%>' ForeColor="#0000CC"></asp:Label></td>
                                        </tr>
                                          <tr>                                        
                                        <td colspan="3">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                    </tr>
                                        <tr>
                                            <td colspan="3">
                                                公差起迄時間<br /><font color="#0000CC"> <uc3:UcShowDate ID="UcShowDate2" runat="server" Text='<%# Eval("Start_date")%>' /></font>
                                                <font color="#0000CC"><uc4:UcShowTime ID="UcShowTime1" runat="server" Text='<%# Eval("Start_time")%>' /></font>
                                                <br />
                                                <font color="#0000CC"><uc3:UcShowDate ID="UcShowDate3" runat="server" Text='<%# Eval("End_date")%>' /></font>
                                                <font color="#0000CC"><uc4:UcShowTime ID="UcShowTime2" runat="server" Text='<%# Eval("End_time")%>' /></font>
                                            </td>
                                        </tr>
                                          <tr>                                        
                                        <td colspan="3">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                    </tr>
                                        <tr>
                                            <td colspan="3">代理人:<asp:Label ID="lbDeputy_idcard" runat="server" Text='<%# Eval("Deputy")%>' ForeColor="#0000CC"></asp:Label></td>
                                        </tr>
                                    </table>
                                    <div style="display: none">
                                        官等<asp:Label ID="lbDegree_code" runat="server" Text='<%# Eval("Degree_code")%>'></asp:Label><br />
                                        職等<asp:Label ID="lbLevel" runat="server" Text='<%# Eval("Level")%>'></asp:Label><br />
                                        工作內容<asp:Label ID="lbReason" runat="server" Text='<%# Eval("Reason")%>'></asp:Label>
                                        簽核流程<asp:Label ID="lbLast_name" runat="server" Text='<%# Eval("Last_name")%>'></asp:Label>
                                        公差事由<asp:Label ID="lbReason2" runat="server" Text='<%# Eval("Reason")%>'></asp:Label><br />
                                        搭機理由<asp:Label ID="lbFlightReason" runat="server" Text='<%# Eval("Leave_name")%>'></asp:Label><br />
                                        補修紀錄<asp:Label ID="lbRecord" runat="server" Text='<%# Eval("Leave_name")%>'></asp:Label>
                                        往返<asp:Label ID="Label1" runat="server" Text='<%# Eval("Leave_name")%>'></asp:Label>
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
            <tr><td><asp:Button ID="Button3" runat="server" Text="回上頁"
                        UseSubmitBehavior="False" OnClick="Button3_Click" /></td></tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlDetail" runat="server" Visible="false">
        <table id="Table1" runat="server" border="0" cellpadding="3" cellspacing="0" width="95%"
            bgcolor="White" frame="box" align="center">
              <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Title2" style="width: 100%" align="center" colspan="2">詳細資料
                </td>
            </tr>
               <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td  width="30%">項次</td>
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
                <td>
                    <asp:Label ID="Case_status" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >員工編號</td>
                <td >
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
                <td>公差日期</td>
                <td>
                    <asp:Label ID="Start_date" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td>類別</td>
                <td>
                    <asp:Label ID="Leave_name" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td>日時</td>
                <td>
                    <asp:Label ID="Leave_hours" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td>地點</td>
                <td>
                    <asp:Label ID="Place" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td>公差開始日期</td>
                <td>
                    <asp:Label ID="Start_date2" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label><br />
                    <asp:Label ID="Start_time" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label>
                </td>
            </tr>
               <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td>公差結束日期</td>
                <td>
                    <asp:Label ID="End_date" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label><br />
                    <asp:Label ID="End_time" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label>
                </td>
            </tr>
               <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td>官等</td>
                <td>
                    <asp:Label ID="Degree_code" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td>職等</td>
                <td>
                    <asp:Label ID="Level" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td>工作內容</td>
                <td>
                    <asp:Label ID="Reason" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td>代理人</td>
                <td>
                    <asp:Label ID="Deputy" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td>簽核流程</td>
                <td>
                    <asp:Label ID="Last_name" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td>公差事由</td>
                <td>
                    <asp:Label ID="Reason2" runat="server" Text="Reason" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td>搭機理由</td>
                <td>
                    <asp:Label ID="Leave_name2" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td>修補記錄</td>
                <td>
                    <asp:Label ID="Leave_name3" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
               <tr>                                        
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td>往返</td>
                <td>
                    <asp:Label ID="Leave_name4" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
        </table>
        <table width="95%" align="center">
            <tr>
                <td class="TdHeightLight" colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="回上頁" OnClick="Button1_Click" 
                        UseSubmitBehavior="False" />
                </td>
            </tr>

        </table>
    </asp:Panel>

</asp:Content>

