<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0101_01.aspx.vb" Inherits="FSC0101_01" %>
<%@ Register src="~/UControl/UcShowTime.ascx" tagname="UcShowTime" tagprefix="uc2" %>
<%@ Register src="~/UControl/UcShowDate.ascx" tagname="UcShowDate" tagprefix="uc3" %>
<%@ Register Src="~/UControl/SYS/UcFormType.ascx" TagPrefix="uc4" TagName="UcFormType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border = "0" cellpadding = "0" cellspacing = "0" width = "100%" class="tableStyle99">
        <tr>
            <td class="indexTitle01" colspan="1">
                收件匣
            </td>
        </tr>
        <tr>
            <td valign="top" align="center">
                <table width="100%">
                    <tr>
                        <td class="htmltable_Left" style="width:150px;">待批/辦件數
                        </td>
                        <td class="htmltable_Middle_White">
                            <asp:HyperLink ID="hlNextCount" runat="server"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr id="levelTr" runat="server" visible="false">
                        <td class="htmltable_Left">三層主管待批件數
                        </td>
                        <td class="htmltable_Middle_White">
                            <asp:HyperLink ID="hlLevelCount" runat="server"></asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>    
    <table border = "0" cellpadding = "0" cellspacing = "0" width = "100%" class="tableStyle99">
        <tr>
            <td class="indexTitle02" colspan="1">
                個人訊息通知
            </td>
        </tr>
        <tr>
            <td class="htmltable_Right" colspan="1">
                <asp:GridView ID="gvCPAPK_ERROR" runat="server" AutoGenerateColumns="False" Borderwidth="0px" AllowPaging="True" PageSize="30"
                        CssClass="Grid" PagerStyle-HorizontalAlign="Right" width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="本月出勤異常資料">
                                <ItemTemplate>
                                    <asp:Label ID="lbErrorData" runat="server" Text='<%# Bind("ErrorData")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="Row" />
                        <AlternatingRowStyle CssClass="AlternatingRow" />
                        <PagerSettings Position="TopAndBottom" />
                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />   
                    </asp:GridView>
            </td>
        </tr>
    </table>
    <table border = "0" cellpadding = "0" cellspacing = "0" width = "100%" class="tableStyle99" id="tb_Back" runat="server" visible="false" >
        <tr>
            <td class="indexTitle03" colspan="1">
                退件訊息通知
            </td>
        </tr>
        <tr>
            <td class="htmltable_Right" colspan="1">
                <asp:GridView ID="gv_Back" runat="server" AutoGenerateColumns="False" Borderwidth="0px" AllowPaging="True" PageSize="30"
                        CssClass="Grid" PagerStyle-HorizontalAlign="Right" width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="項次">
                                <ItemStyle Width="20px" HorizontalAlign="Center"/>
                                <HeaderStyle Width="20px" />
                                <ItemTemplate>
                                    <asp:Label ID="gvlbNo" runat="server" Text='<%# Container.DataItemIndex+1 %>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="表單編號">
                                  <ItemStyle Width="20px" HorizontalAlign="Center"/>
                                <HeaderStyle Width="20px" />
                                <ItemTemplate>
                                    <asp:Label ID="gvlbFlowId" runat="server"  Text='<%# Bind("Flow_id") %>' ></asp:Label>
                                    <asp:Label ID="gvlbMergeFlag" runat="server"  Text='<%# IIf(Eval("Merge_flag").ToString() = "1", "*", "")%>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="填單日期">
                                <ItemStyle Width="35px" HorizontalAlign="Center"/>
                                <HeaderStyle Width="35px" />
                                <ItemTemplate>
                                    <asp:Label ID="gvlbwrite_time" runat="server" Text='<%# Bind("write_time","{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="表單名稱">
                                <ItemStyle Width="60px" HorizontalAlign="Center"/>
                                <HeaderStyle Width="60px" />
                                <ItemTemplate>                                
                                    <uc4:UcFormType runat="server" ID="UcFormType" Orgcode='<%# Bind("Orgcode") %>' FlowId='<%# Bind("Flow_id") %>' FormId='<%# Bind("Form_id") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="Row" />
                        <AlternatingRowStyle CssClass="AlternatingRow" />
                        <PagerSettings Position="TopAndBottom" />
                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />   
                    </asp:GridView>
            </td>
        </tr>
    </table>
    <table border = "0" cellpadding = "0" cellspacing = "0" width = "100%" class="tableStyle99" runat="server" id="tbDuty" visible="false" >
        <tr>
            <td class="indexTitle04" colspan="1">
                個人排班訊息
            </td>
        </tr>
        <tr>
            <td class="htmltable_Right" colspan="1">
                <asp:GridView ID="gvSchedule" runat="server" AutoGenerateColumns="False" Borderwidth="0px" AllowPaging="True" PageSize="30"
                        CssClass="Grid" PagerStyle-HorizontalAlign="Right" width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="本月排班資料">
                                <ItemTemplate>
                                    <asp:Label ID="lbScheduleData" runat="server" Text='<%# Bind("ScheduleData")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="Row" />
                        <AlternatingRowStyle CssClass="AlternatingRow" />
                        <PagerSettings Position="TopAndBottom" />
                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />   
                    </asp:GridView>
            </td>
        </tr>
    </table>

      <table border = "0" cellpadding = "0" cellspacing = "0" width = "100%" class="tableStyle99" runat="server" id="TackleArea" visible="false" >
        <tr>
            <td class="indexTitle04" colspan="1">
                領物盤點通知
            </td>
        </tr>
         <tr>
              <td class="htmltable_Middle" colspan="1">
                  <asp:Label ID="lbInventory" runat="server" visible="false" Text="{0}至{1}日執行庫房盤點，請於盤點日期前完成目前待領之物品領用"></asp:Label>

              </td>
          </tr>
          <tr id="TackleAreatr2" runat="server">
            <td class="htmltable_Middle_White">
                  <asp:HyperLink ID="hylsafe" runat="server" Text="低於安全庫存量物品報表"></asp:HyperLink>
            </td>
          </tr>
          <tr id="TackleAreatr3" runat="server">
              <td class="htmltable_Middle" colspan="1">
                  <asp:Label ID="lbwarn" runat="server" visible="false" Text="[警示]目前低於安全庫存量之物品計有{0}項"></asp:Label>

              </td>

          </tr>
    </table>
    <table>
        <tr>
            <td>
                <div><asp:Image ID="img" runat="server" ImageUrl="~/Mobile/images/igss.png"></asp:Image></div>
                <div>Android版 新總務系統</div>
            </td>
        </tr>
    </table>
</asp:Content>