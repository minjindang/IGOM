<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    EnableEventValidation="false"
    CodeFile="MAI2201_01.aspx.vb" Inherits="MAI_MAI2201" %>
    <%@ Register src="~/UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc3" %>
<%@ Register src="~/UControl/SAL/UcReset.ascx" tagname="UcReset" tagprefix="uc4" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <div id="Div_Approve_Query" runat="server">
            <table class="tableStyle99" width="100%">
                <tr>
                    <td class="htmltable_Title" colspan="4">水電報修統計</td>
                </tr>
                <tr>
                    <td class="htmltable_Right" colspan="4">
                        <asp:Label ID="Label1" runat="server" Text="欲作水電報修統計，請先選妥統計類別與報修日期區間後，按「查詢」鈕。" />
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">統計類別</td>
                    <td class="htmltable_Right" colspan="3">
                        <asp:RadioButtonList ID="StatisticalCategories" runat="server" RepeatColumns="9" RepeatLayout="Flow">
                            <asp:ListItem Value="01" Selected="True">報修類別</asp:ListItem>
                            <asp:ListItem Value="02">處室報修次數</asp:ListItem>
                            <asp:ListItem Value="03">個人報修次數</asp:ListItem>
                            <asp:ListItem Value="04">依時限完成率</asp:ListItem>
                            <asp:ListItem Value="05">待料狀態</asp:ListItem>
                            <asp:ListItem Value="06">排修人員處理次數</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Left">報修日期</td>
                    <td class="htmltable_Right" colspan="3">
                        <uc3:UcDate ID="ApplyTimeS" runat="server" Text=""/>
					     ~ 
                        <uc3:UcDate ID="ApplyTimeE" runat="server" Text=""/>
                    </td>
                </tr>
                <tr>
                    <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                        <asp:Button ID="SelectBtn" runat="server" Text="查詢"/>		
                        <asp:Button ID="ResetBtn" runat="server" Text="清空重填"/>		
                    </td>
                </tr>
            </table>
        </div>
    <div id="DivDate" runat="server" visible="false">
        <table class="tableStyle99" width="100%">
               
               <tr>
                   <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                        <asp:Label ID="GridView1Label" runat="server" Text=""/>		
                    </td>
               </tr>
           </table>
    </div>
           <div id="div01" runat="server" visible="false">
               <table class="tableStyle99" width="100%">
                   <tr>
                    <td class="htmltable_Title" colspan="4">報修類別統計結果</td>
                </tr>
               </table>
                <asp:GridView ID="GridView01" runat="server"
                    AutoGenerateColumns="False"
                    AllowPaging="True" PagerSettings-Visible="false"
                    CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!" 
                    >
                    <PagerSettings Visible="False" />
                    <Columns>
                        <asp:TemplateField HeaderText="報修類別">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="CODE_DESC1" runat="server" Text='<%# Eval("CODE_DESC1")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="筆數">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Num" runat="server" Enabled="false" Text='<%# Eval("Num")+"筆"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Proportion" runat="server" Enabled="false" Text='<%# Eval("Proportion")+"%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="Row" />
                    <HeaderStyle CssClass="Grid" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                </asp:GridView>
           </div>
           <div id="div02" runat="server" visible="false">
               <table class="tableStyle99" width="100%">
                   <tr>
                    <td class="htmltable_Title" colspan="4" runat="server" >各處室報修次數統計結果</td>
                </tr>
               </table>
           <asp:GridView ID="GridView02_01" runat="server"
                    AutoGenerateColumns="False"
                    AllowPaging="True" PagerSettings-Visible="false"
                    CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!" 
                    >
                    <PagerSettings Visible="False" />
                    <Columns>
                        <asp:TemplateField HeaderText="單位別">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Unit_code" runat="server" Text='<%# Eval("Unit_code")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="完成筆數">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete" runat="server" Enabled="false" Text='<%# Eval("Complete") & "筆"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="CompleteProportion" runat="server" Enabled="false" Text='<%# Eval("CompleteProportion") & "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="未完成筆數">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="NonCompleteNum" runat="server" Enabled="false" Text='<%# Eval("NonCompleteNum") & "筆"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="NonCompleteProportion" runat="server" Enabled="false" Text='<%# Eval("NonCompleteProportion") & "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="報修總數"> 
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Total" runat="server" Enabled="false" Text='<%# Eval("Total")& "筆"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="Row" />
                    <HeaderStyle CssClass="Grid" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                </asp:GridView>
               <table class="tableStyle99" width="100%">
                   <tr>
                    <td id="Td1" class="htmltable_Title" colspan="4" runat="server" >完成案件處室滿意度統計表</td>
                </tr>
                   <asp:GridView ID="GridView02_02" runat="server"
                    AutoGenerateColumns="False"
                    AllowPaging="True" PagerSettings-Visible="false"
                    CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!" 
                    >
                    <PagerSettings Visible="False" />
                    <Columns>
                        <asp:TemplateField HeaderText="單位別">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Unit_code" runat="server" Text='<%# Eval("Unit_code")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="非常滿意">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete001" runat="server" Enabled="false" Text='<%# Eval("Complete001")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete001Proportion" runat="server" Enabled="false" Text='<%# Eval("Complete001Proportion") & "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="滿意">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete002" runat="server" Enabled="false" Text='<%# Eval("Complete002")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete002Proportion" runat="server" Enabled="false" Text='<%# Eval("Complete002Proportion") & "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="普通">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete003" runat="server" Enabled="false" Text='<%# Eval("Complete003")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete003Proportion" runat="server" Enabled="false" Text='<%# Eval("Complete003Proportion") & "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="不滿意">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete004" runat="server" Enabled="false" Text='<%# Eval("Complete004")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete004Proportion" runat="server" Enabled="false" Text='<%# Eval("Complete004Proportion") & "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="非常不滿意"> 
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete005" runat="server" Enabled="false" Text='<%# Eval("Complete005")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete005Proportion" runat="server" Enabled="false" Text='<%# Eval("Complete005Proportion") & "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="未填寫"> 
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete000" runat="server" Enabled="false" Text='<%# Eval("Complete000")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete000Proportion" runat="server" Enabled="false" Text='<%# Eval("Complete000Proportion") & "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="Row" />
                    <HeaderStyle CssClass="Grid" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                </asp:GridView>
               </table>
            </div>
           <div id="div03" runat="server" visible="false">
               <table class="tableStyle99" width="100%">
                   <tr>
                    <td id="Td2" class="htmltable_Title" colspan="4" runat="server" >個人報修次數統計結果</td>
                </tr>
               </table>
               <asp:GridView ID="GridView03" runat="server"
                    AutoGenerateColumns="False"
                    AllowPaging="True" PagerSettings-Visible="false"
                    CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!" 
                    >
                    <PagerSettings Visible="False" />
                    <Columns>
                        <asp:TemplateField HeaderText="單位別">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Unit_code" runat="server" Text='<%# Eval("Unit_code")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="報修者名稱">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="User_name" runat="server" Text='<%# Eval("User_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="完成筆數">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete" runat="server" Enabled="false" Text='<%# Eval("Complete") & "筆"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="CompleteProportion" runat="server" Enabled="false" Text='<%# Eval("CompleteProportion") & "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="未完成筆數">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="NonCompleteNum" runat="server" Enabled="false" Text='<%# Eval("NonCompleteNum") & "筆"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="NonCompleteProportion" runat="server" Enabled="false" Text='<%# Eval("NonCompleteProportion") & "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="報修總數"> 
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Total" runat="server" Enabled="false" Text='<%# Eval("Total")& "筆"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="Row" />
                    <HeaderStyle CssClass="Grid" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                </asp:GridView>
            </div>
           <div id="div04" runat="server" visible="false">
               <table class="tableStyle99" width="100%">
                   <tr>
                    <td id="Td3" class="htmltable_Title" colspan="4" runat="server" >依時限完成率統計結果</td>
                </tr>
               </table>
               <asp:GridView ID="GridView04" runat="server"
                    AutoGenerateColumns="False"
                    AllowPaging="True" PagerSettings-Visible="false"
                    CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!" 
                    >
                    <PagerSettings Visible="False" />
                    <Columns>
                        <asp:TemplateField HeaderText="項目">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Day" runat="server" Text='<%# Eval("Day")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="筆數">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="MaintainDayNum" runat="server" Enabled="false" Text='<%# Eval("MaintainDayNum")& "筆"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Proportion" runat="server" Enabled="false" Text='<%# Eval("Proportion")+"%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="Row" />
                    <HeaderStyle CssClass="Grid" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                </asp:GridView>
               <table class="tableStyle99" width="100%">
                   <tr>
                    <td id="Td4" class="htmltable_Title" colspan="4" runat="server" >水電報修至完成之平均時數統計結果</td>
                </tr>
               </table>
               <asp:GridView ID="GridView04_01" runat="server"
                    AutoGenerateColumns="False"
                    AllowPaging="True" PagerSettings-Visible="false"
                    CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!" 
                    >
                    <PagerSettings Visible="False" />
                    <Columns>
                        <asp:TemplateField HeaderText="項目">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Item" runat="server" Text='<%# Eval("Item")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="總筆數">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="MaintainDayNum" runat="server" Enabled="false" Text='<%# Eval("MaintainDayNum")& "筆"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="總時數">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="MtTime" runat="server" Enabled="false" Text='<%# Eval("MtTime") & "小時"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="平均時數">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Average" runat="server" Enabled="false" Text='<%# Eval("Average") & "小時"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="Row" />
                    <HeaderStyle CssClass="Grid" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                </asp:GridView>
            </div>
           <div id="div05" runat="server" visible="false">
               <table class="tableStyle99" width="100%">
                   <tr>
                    <td id="Td5" class="htmltable_Title" colspan="4" runat="server" >待料狀況統計結果</td>
                </tr>
               </table>
               <asp:GridView ID="GridView05" runat="server"
                    AutoGenerateColumns="False"
                    AllowPaging="True" PagerSettings-Visible="false"
                    CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!" 
                    >
                    <PagerSettings Visible="False" />
                    <Columns>
                        <asp:TemplateField HeaderText="序號">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="ROWID" runat="server" Text='<%# Eval("ROWID")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="報修單號">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Flow_id" runat="server" Enabled="false" Text='<%# Eval("Flow_id")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="報修人">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="User_name" runat="server" Enabled="false" Text='<%# Eval("User_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="報修日期">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="ApplyTime" runat="server" Enabled="false" Text='<%# Eval("ApplyTime")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="報修類別">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="CODE_DESC1" runat="server" Enabled="false" Text='<%# Eval("CODE_DESC1")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="報修描述">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Problem_desc" runat="server" Enabled="false" Text='<%# Eval("Problem_desc")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="排修人員及分機">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Maintainer_name" runat="server" Enabled="false" Text='<%# Eval("Maintainer_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="處理情形">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="MtStatus_type" runat="server" Enabled="false" Text='<%# Eval("MtStatus_type")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="是否結案">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="CaseClose_type" runat="server" Enabled="false" Text='<%# Eval("CaseClose_type")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="Row" />
                    <HeaderStyle CssClass="Grid" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                </asp:GridView>
            </div>
           <div id="div06" runat="server" visible="false">
               <table class="tableStyle99" width="100%">
                   <tr>
                    <td id="Td6" class="htmltable_Title" colspan="4" runat="server" >排修人員處理次數統計結果</td>
                </tr>
               </table>
               <asp:GridView ID="GridView06" runat="server"
                    AutoGenerateColumns="False"
                    AllowPaging="True" PagerSettings-Visible="false"
                    CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!" 
                    >
                    <PagerSettings Visible="False" />
                    <Columns>
                        <asp:TemplateField HeaderText="單位別">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Depart_name" runat="server" Text='<%# Eval("Depart_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="排修人員名稱">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Maintainer_name" runat="server" Enabled="false" Text='<%# Eval("Maintainer_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="完成筆數">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete" runat="server" Enabled="false" Text='<%# Eval("Complete") & "筆"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="CompleteProportion" runat="server" Enabled="false" Text='<%# Eval("CompleteProportion") & "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="未完成筆數">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="NonCompleteNum" runat="server" Enabled="false" Text='<%# Eval("NonCompleteNum") & "筆"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="NonCompleteProportion" runat="server" Enabled="false" Text='<%# Eval("NonCompleteProportion") & "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="報修總數">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Total" runat="server" Enabled="false" Text='<%# Eval("Total")& "筆"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="排修比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="TotalPercentage" runat="server" Enabled="false" Text='<%# Eval("TotalPercentage") + "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="Row" />
                    <HeaderStyle CssClass="Grid" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                </asp:GridView>
               <table class="tableStyle99" width="100%">
                   <tr>
                    <td id="Td7" class="htmltable_Title" colspan="4" runat="server" >完成案件排修人員處理滿意度統計表</td>
                </tr>
               </table>
               <asp:GridView ID="GridView06_01" runat="server"
                    AutoGenerateColumns="False"
                    AllowPaging="True" PagerSettings-Visible="false"
                    CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!" 
                    >
                    <PagerSettings Visible="False" />
                    <Columns>
                        <asp:TemplateField HeaderText="排修人員名稱">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Maintainer_name" runat="server" Text='<%# Eval("Maintainer_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="非常滿意">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete001" runat="server" Enabled="false" Text='<%# Eval("Complete001")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete001Proportion" runat="server" Enabled="false" Text='<%# Eval("Complete001Proportion") & "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="滿意">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete002" runat="server" Enabled="false" Text='<%# Eval("Complete002")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete002Proportion" runat="server" Enabled="false" Text='<%# Eval("Complete002Proportion") & "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="普通">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete003" runat="server" Enabled="false" Text='<%# Eval("Complete003")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete003Proportion" runat="server" Enabled="false" Text='<%# Eval("Complete003Proportion") & "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="不滿意">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete004" runat="server" Enabled="false" Text='<%# Eval("Complete004")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete004Proportion" runat="server" Enabled="false" Text='<%# Eval("Complete004Proportion") & "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="非常不滿意">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete005" runat="server" Enabled="false" Text='<%# Eval("Complete005")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete005Proportion" runat="server" Enabled="false" Text='<%# Eval("Complete005Proportion") & "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="未填寫">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete000" runat="server" Enabled="false" Text='<%# Eval("Complete000")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="比例">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:Label ID="Complete000Proportion" runat="server" Enabled="false" Text='<%# Eval("Complete000Proportion") & "%"%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="Row" />
                    <HeaderStyle CssClass="Grid" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                </asp:GridView>
                </div>
</asp:Content>
