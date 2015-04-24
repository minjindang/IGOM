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
                ���g�O�o�G�@�~
            </td>
        </tr>
        <tr>                    
            <td class="htmltable_Left" style="width:100px; height: 19px;">
                �������
            </td>
            <td class="TdHeightLight" style="width:250px; height: 19px;">
                <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
            </td>
                        
        </tr>
        <tr>
                <td class="htmltable_Left" style="width: 100px">�������u</td>
                <td class="htmltable_Right" style="width:250px">
                <uc6:UcDDLMember runat="server" ID="UcDDLMember" /></td>
        </tr>
            <tr>
            <td class="htmltable_Left" style="width:100px">
                �������
            </td>
            <td class="htmltable_Right">
                <uc2:UcDate ID="UcDate1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 100px">
                �O�_�w�o�G���y�O
            </td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlisReword" runat="server" >
                    <asp:ListItem Value="">����</asp:ListItem>
                    <asp:ListItem Value="1">���o�G</asp:ListItem>
                    <asp:ListItem Value="2">�w�o�G</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" class="TdHeightLight">
                <asp:Button ID="btnQuery" runat="server" Text="�d��" />
                <input id="Reset" type="button" value="����" />
            </td>
        </tr>
                    
    </table>
           
    <table id="tbq" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
        visible="false" class="tableStyle99">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                �d�ߵ��G
            </td>
        </tr>
       <tr>
            <td>
                <input id="Button1" type="button" value="����" onclick="Check(true, 'cbx')" />
                <input id="Button2" type="button" value="������" onclick="Check(false, 'cbx')" />
                <uc1:UcReword runat="server" ID="UcReword" OnClick="UcReword_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="false" BorderWidth="0px" PageSize="30"
                    AllowPaging="true" CssClass="Grid" PagerStyle-HorizontalAlign="right" Width="100%"
                    EmptyDataText="�d�L���!!">
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemStyle HorizontalAlign="Center" Width="15px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
                            <ItemTemplate>
                                <asp:CheckBox ID="cbx" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���s��">
                            <ItemStyle HorizontalAlign="Center" Width="15px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
                            <ItemTemplate>
                                <asp:Label ID="lbFlow_id" runat="server" Text='<%# Eval("Flow_id")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�������">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <ItemTemplate>
                                <asp:Label ID="lbDepart_name" runat="server" Text='<%# Eval("Depart_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�������u�s��">
                            <ItemStyle HorizontalAlign="Center" Width="75px" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                            <Itemtemplate>
                                <asp:Label ID="lbId_card" runat="server" Text='<%# Eval("Id_card")%>'></asp:Label><br />
                            </Itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�������u�m�W">
                            <itemstyle horizontalalign="Center" width="75px" />
                            <headerstyle horizontalalign="Center" verticalalign="Middle" width="60px" />
                            <itemtemplate>
                                <asp:Label ID="lbApply_name" runat="server"  Text='<%# Eval("Apply_name")%>'></asp:Label><br/>                    
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�������">
                            <itemstyle horizontalalign="Center" width="145px" />
                            <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                            <itemtemplate>
                                <uc3:UcShowDate ID="UcShowDate" runat="server" Text='<%# Eval("Apply_date")%>'/>
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���Z�|�W��">
                            <itemstyle horizontalalign="Center" width="145px" />
                            <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                            <itemtemplate>
                                <asp:Label ID="lbCouncil_name" runat="server"  Text='<%# Eval("Council_name")%>' ></asp:Label>
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���Z�|���">
                            <itemstyle horizontalalign="Center" width="145px" />
                            <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                            <itemtemplate>
                                <uc3:UcShowDate ID="UcCouncil_date" runat="server" Text='<%# Eval("Council_date")%>'/>
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���Z�|�ҵ����G">
                            <itemstyle horizontalalign="Center" width="145px" />
                            <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                            <itemtemplate>
                                <asp:Label ID="lbCouncil_approve" runat="server"  Text='<%# Eval("Council_approve")%>' ></asp:Label>
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���y�O���">
                            <itemstyle horizontalalign="Center" width="145px" />
                            <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                            <itemtemplate>
                                <uc3:UcShowDate ID="UcReword_date" runat="server" Text='<%# Eval("Reword_date")%>'/>
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���y�O�帹">
                            <itemstyle horizontalalign="Center" width="145px" />
                            <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                            <itemtemplate>
                                <asp:Label ID="lbReword_Doc" runat="server"  Text='<%# Eval("Reword_Doc")%>' ></asp:Label>
                            </itemtemplate>
                        </asp:TemplateField>
                    </Columns>
                    <pagerstyle horizontalalign="Right" />
                    <emptydatatemplate>
                        �d�L���!!
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
