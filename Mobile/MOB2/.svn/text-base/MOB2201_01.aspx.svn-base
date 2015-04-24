<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/MasterPage/Mobile.master" AutoEventWireup="true" CodeFile="MOB2201_01.aspx.cs" Inherits="Mobile_MOB2_MOB2201_01" EnableEventValidation="false" %>

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
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:DropDownList ID="ddlUserName" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="tr3" runat="server">
                <td class="htmltable_Right">員工編號</td>
                <td class="htmltable_Right">

                    <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="htmltable_Right"><span style="color: Red">*</span>出勤日期</td>
                <td class="TdHeightLight">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>


                            <uc2:UcDate ID="UcDate1" runat="server" />
                            ~
                    <uc2:UcDate ID="UcDate2" runat="server" />
                            <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>

            <tr id="tr4" runat="server">
                <td class="htmltable_Right">在職狀態</td>
                <td class="htmltable_Right">
                    <asp:DropDownList ID="ddlQuit_Job" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="" Text="請選擇"></asp:ListItem>
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
            <tr id="tr6" runat="server">
                <td class="htmltable_Right">人員類別
                </td>
                <td class="htmltable_Right">
                    <asp:DropDownList ID="ddlEmployeetype" runat="server" AppendDataBoundItems="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Right">報表類別</td>
                <td class="htmltable_Right">
                    <asp:RadioButtonList ID="rblReporttype" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" RepeatColumns="2">
                        <asp:ListItem Value="0" Text="出勤紀錄" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="1" Text="出勤異常紀錄"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Button ID="Button2" runat="server" Text="回上頁" UseSubmitBehavior="false" OnClick="Button2_Click" /></td>
                            <td>
                                <asp:Button ID="btnQuery" runat="server" Text="查詢" UseSubmitBehavior="false"
                                    OnClick="btnQuery_Click" />
                            </td>
                        </tr>
                    </table>

                </td>
            </tr>

        </table>
    </asp:Panel>
    <asp:Panel ID="pnlResult" runat="server" Visible="false">
        <table id="tbq" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="htmltable_Title2" style="width: 100%" align="center">查詢結果
                </td>
            </tr>
            <tr>
                <td style="width: 100%" class="TdHeightLight" valign="top">
                    <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="False" BorderWidth="0px" PageSize="30"
                        AllowPaging="True" PagerStyle-HorizontalAlign="right" Width="100%"
                        CellPadding="5" BorderStyle="None" GridLines="None"
                        EmptyDataText="查無資料!!" OnPageIndexChanging="gvlist_PageIndexChanging" EnableModelValidation="True" OnSelectedIndexChanging="gvlist_SelectedIndexChanging" OnRowDataBound="gvlist_RowDataBound" OnSelectedIndexChanged="gvlist_SelectedIndexChanged" ShowHeader="False">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table style="width: 100%;" bgcolor="White" frame="box">
                                        <tr>
                                            <td rowspan="7" width="15%" align="center" valign="top">
                                                <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (Container.DataItemIndex+1).ToString() %>'></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lbDepart_name" runat="server" Text='<%# Eval("Depart_name")%>' ForeColor="#0000CC"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div style="background: black; width: 100%; height: 1px"></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbPKCARD" runat="server" Text='<%# Eval("PKCARD")%>' ForeColor="#0000CC"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lbPKNAME" runat="server" Text='<%# Eval("PKNAME")%>' ForeColor="#0000CC"></asp:Label></td>

                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div style="background: black; width: 100%; height: 1px"></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">上班日期：<font color="#0000CC"><uc3:UcShowDate ID="UcShowDate" runat="server" Text='<%# Eval("PKWDATE")%>' />
                                            </font>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div style="background: black; width: 100%; height: 1px"></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table>
                                                    <tr>
                                                        <td>上下班時間</td>
                                                        <td>
                                                            <font color="#0000CC">
                                                                <uc4:UcShowTime ID="UcShowTimestart" runat="server" Text='<%# Eval("PKSTIME")%>' />
                                                            </font></td>
                                                        <td>~</td>
                                                        <td>
                                                            <font color="#0000CC">
                                                                <uc4:UcShowTime ID="UcShowTimeend" runat="server" Text='<%# Eval("PKETIME")%>' />
                                                            </font></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="display: none">
                                        <asp:Label ID="lbPKWORKH" runat="server" Text='<%# Eval("PKWORKH")%>'></asp:Label>
                                        <asp:Label ID="lbPKWKTPE" runat="server" Text='<%# Eval("PKWKTPE")%>'></asp:Label>
                                        <asp:Label ID="lbLeave_type" runat="server" Text='<%# Eval("Leavetype") %>'></asp:Label>
                                        <asp:Label ID="lbleave_hours" runat="server" Text='<%# Eval("Leavehours")%>'></asp:Label>
                                        <asp:Label ID="lbabsenthours" runat="server" Text='<%# Eval("Absenthours")%>'></asp:Label>
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
                <td>
                    <asp:Button ID="Button3" runat="server" Text="回上頁" OnClick="Button3_Click" UseSubmitBehavior="false" /></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlDetail" runat="server" Visible="false">
        <table id="Table1" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
            bgcolor="White" frame="box">
            <tr>
                <td class="htmltable_Title2" style="width: 100%" align="center" colspan="2">詳細資料
                </td>
            </tr>
        </table><br />
        <table id="Table2" runat="server" border="0" cellpadding="3" cellspacing="0" width="95%"
            bgcolor="White" frame="box" align="center">

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
                <td >單位名稱</td>
                <td >
                    <asp:Label ID="Depart_name" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >員工姓名</td>
                <td >
                    <asp:Label ID="PKNAME" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >上班日期</td>
                <td >
                    <asp:Label ID="PKWDATE" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >上班時間</td>
                <td >
                    <asp:Label ID="PKSTIME" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >下班時間</td>
                <td >
                    <asp:Label ID="PKETIME" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >刷卡時數</td>
                <td >
                    <asp:Label ID="PKWORKH" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >出勤狀況</td>
                <td> 
                    <asp:Label ID="PKWKTPE" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >差假別</td>
                <td >
                    <asp:Label ID="Leavetype" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >差假時數</td>
                <td >
                    <asp:Label ID="Leavehours" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="background: black; width: 100%; height: 1px"></div>
                </td>
            </tr>
            <tr>
                <td >曠職時數</td>
                <td>
                    <asp:Label ID="Absenthours" runat="server" Text="Label" ForeColor="#0000CC"></asp:Label></td>
            </tr>

            </table>
        <table width="95%" align="center">
            <tr>
                <td class="TdHeightLight" colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="回上頁" OnClick="Button1_Click" UseSubmitBehavior="false" />
                </td>
            </tr>

        </table>
    </asp:Panel>

</asp:Content>

