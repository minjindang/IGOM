<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC3119_01.aspx.vb" Inherits="FSC3119_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register src="~/UControl/UcShowDate.ascx" tagname="UcShowDate" tagprefix="uc3" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc6" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/SYS/UcReword.ascx" TagPrefix="uc1" TagName="UcReword" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      <script type="text/javascript">
          function Check(parentChk, ChildId) {
              var oElements = document.getElementsByTagName("INPUT");

              for (i = 0; i < oElements.length; i++) {
                  if (IsCheckBox(oElements[i]) && IsMatch(oElements[i].id, ChildId)) {
                      oElements[i].checked = parentChk;
                  }
              }
          }
          function IsMatch(id, ChildId) {
              var sPattern = '^ctl00_ContentPlaceHolder1_.*' + ChildId + '$';
              var oRegExp = new RegExp(sPattern);
              if (oRegExp.exec(id))
                  return true;
              else
                  return false;
          }
          function IsCheckBox(chk) {
              if (chk.type == 'checkbox') return true;
              else return false;
          }
    </script> 
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
                獎懲令發佈作業
            </td>
        </tr>
        <tr>                    
            <td class="htmltable_Left" style="width:100px; height: 19px;">
                提報單位
            </td>
            <td class="TdHeightLight" style="width:250px; height: 19px;">
                <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
            </td>
                        
        </tr>
        <tr>
                <td class="htmltable_Left" style="width: 100px">提報員工</td>
                <td class="htmltable_Right" style="width:250px">
                <uc6:UcDDLMember runat="server" ID="UcDDLMember" /></td>
        </tr>
            <tr>
            <td class="htmltable_Left" style="width:100px">
                提報日期
            </td>
            <td class="htmltable_Right">
                <uc2:UcDate ID="UcDate1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 100px">
                是否已發佈獎勵令
            </td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlisReword" runat="server" >
                    <asp:ListItem Value="">全部</asp:ListItem>
                    <asp:ListItem Value="1">未發佈</asp:ListItem>
                    <asp:ListItem Value="2">已發佈</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" class="TdHeightLight">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" />
                <input id="Reset" type="button" value="重填" />
            </td>
        </tr>
                    
    </table>
           
    <table id="tbq" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
        visible="false" class="tableStyle99">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                查詢結果
            </td>
        </tr>
       <tr>
            <td>
                <input id="Button1" type="button" value="全選" onclick="Check(true, 'cbx')" />
                <input id="Button2" type="button" value="全不選" onclick="Check(false, 'cbx')" />
                <uc1:UcReword runat="server" ID="UcReword" OnClick="UcReword_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="false" BorderWidth="0px" PageSize="30"
                    AllowPaging="true" CssClass="Grid" PagerStyle-HorizontalAlign="right" Width="100%"
                    EmptyDataText="查無資料!!">
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemStyle HorizontalAlign="Center" Width="15px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
                            <ItemTemplate>
                                <asp:CheckBox ID="cbx" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="表單編號">
                            <ItemStyle HorizontalAlign="Center" Width="15px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
                            <ItemTemplate>
                                <asp:Label ID="lbFlow_id" runat="server" Text='<%# Eval("Flow_id")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="提報單位">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <ItemTemplate>
                                <asp:Label ID="lbDepart_name" runat="server" Text='<%# Eval("Depart_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="提報員工編號">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <Itemtemplate>
                                <asp:Label ID="lbId_card" runat="server" Text='<%# Eval("Id_card")%>'></asp:Label><br />
                            </Itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="提報員工姓名">
                            <itemstyle horizontalalign="Center" width="75px" />
                            <headerstyle horizontalalign="Center" verticalalign="Middle" width="60px" />
                            <itemtemplate>
                                <asp:Label ID="lbApply_name" runat="server"  Text='<%# Eval("Apply_name")%>'></asp:Label><br/>                    
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="提報日期">
                            <itemstyle horizontalalign="Center" width="145px" />
                            <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                            <itemtemplate>
                                <uc3:UcShowDate ID="UcShowDate" runat="server" Text='<%# Eval("Apply_date")%>'/>
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="考績會名稱">
                            <itemstyle horizontalalign="Center" width="145px" />
                            <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                            <itemtemplate>
                                <asp:Label ID="lbCouncil_name" runat="server"  Text='<%# Eval("Council_name")%>' ></asp:Label>
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="考績會日期">
                            <itemstyle horizontalalign="Center" width="145px" />
                            <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                            <itemtemplate>
                                <uc3:UcShowDate ID="UcCouncil_date" runat="server" Text='<%# Eval("Council_date")%>'/>
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="考績會考評結果">
                            <itemstyle horizontalalign="Center" width="145px" />
                            <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                            <itemtemplate>
                                <asp:Label ID="lbCouncil_approve" runat="server"  Text='<%# Eval("Council_approve")%>' ></asp:Label>
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="獎勵令日期">
                            <itemstyle horizontalalign="Center" width="145px" />
                            <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                            <itemtemplate>
                                <uc3:UcShowDate ID="UcReword_date" runat="server" Text='<%# Eval("Reword_date")%>'/>
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="獎勵令文號">
                            <itemstyle horizontalalign="Center" width="145px" />
                            <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                            <itemtemplate>
                                <asp:Label ID="lbReword_Doc" runat="server"  Text='<%# Eval("Reword_Doc")%>' ></asp:Label>
                            </itemtemplate>
                        </asp:TemplateField>
                    </Columns>
                    <pagerstyle horizontalalign="Right" />
                    <emptydatatemplate>
                        查無資料!!
                    </emptydatatemplate>
                                <rowstyle cssclass="Row" />
                                <headerstyle cssclass="Grid" />
                                <alternatingrowstyle cssclass="AlternatingRow" />
                                <pagersettings position="TopAndBottom" />
                                <emptydatarowstyle cssclass="EmptyRow" />
                                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right" class="TdHeightLight" style="width: 100%">
                <uc1:Ucpager ID="Ucpager" runat="server" GridName="gvlist" PNow="1" PSize="30" />
            </td>
        </tr>       
    </table>

</asp:Content>
