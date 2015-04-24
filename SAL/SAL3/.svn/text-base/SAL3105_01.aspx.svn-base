<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" 
AutoEventWireup="false" CodeFile="SAL3105_01.aspx.vb" Inherits="SAL3105_01" %>

<%@ Register Src="../../UControl/UcPager.ascx" TagName="UcPager" TagPrefix="uc1" %>
<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/SAL/ucDateTextBox.ascx" TagName="ucDateTextBox" TagPrefix="uc3" %>
<%@ Register Src="~/UControl/FSC/UcMember.ascx" TagPrefix="uc1" TagName="UcMember" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc1" TagName="UcDDLMember" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <table class="tableStyle99" width="100%" id="tbm" runat="server" >    
            <tr>
                <td class="htmltable_Title" colspan="4">
                    考績獎金維護
                </td>
            </tr>        
            <tr>
                <td class="htmltable_Left">
                    考績年度
                </td>
                <td>  
                    <asp:DropDownList ID="ddlYear" runat="server" />
                </td>
			    <td class="htmltable_Left">
				    人員類別
                </td>
                <td>
                    <%--<uc2:ucSaCode ID="ucSaCode_base_job" runat="server" 
                    Code_sys="002" Code_Kind="P" Code_type="001" 
                    ControlType="DropDownList" Mode="query" />--%>
                    <asp:DropDownList ID="ddlBase_prono" runat="server" DataTextField="CODE_DESC1" DataValueField="CODE_NO" />
			    </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    單位別
                </td>
                <td>  
                    <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" Sub_Visible="false" />
                </td>
			    <td class="htmltable_Left">
				    人員姓名
                </td>
                <td>
                    <uc1:UcDDLMember runat="server" ID="UcDDLMember" />
			    </td>
            </tr>
            <tr>
			    <td class="htmltable_Left">
				    在職狀態
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList_base_edate" runat="server" >
                        <asp:ListItem Value="1" text="在職" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="2" Text="已離職" ></asp:ListItem>
                    </asp:DropDownList>
                </td>
			    <td class="htmltable_Left">
				    員工編號
                </td>
                <td>
                    <uc1:UcMember runat="server" ID="UcMember" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="Button_Search" runat="server" Text="查詢"  />
                </td>
            </tr>
        </table>
        <table class="tableStyle99" width="100%" runat="server" id="table_batch" visible="false" > 
            <tr>
                <td class="htmltable_Title" colspan="4">
                    整批設定考績資料
                </td>
            </tr>    
            <tr>
                <td class="htmltable_Left">
                    考績年度
                </td>
                <td>
                    <asp:DropDownList ID="ddlBatchYear" runat="server" />
                </td>
                <td class="htmltable_Left">
                    人員類別
                </td>
                <td>
                    <%--<uc2:ucSaCode ID="ucSaCode_batch_base_job" runat="server" 
                    Code_sys="002" Code_Kind="P" Code_type="001" 
                    ControlType="DropDownList" Mode="query" />--%>
                    <asp:DropDownList ID="ddlbatch_Base_prono" runat="server" DataTextField="CODE_DESC1" DataValueField="CODE_NO" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    單位別
                </td>
                <td>  
                    <uc1:UcDDLDepart runat="server" ID="UcDDLDepart_batch" Sub_Visible="false" />
                </td>
			    <td class="htmltable_Left">
				    人員姓名
                </td>
                <td>
                    <uc1:UcDDLMember runat="server" ID="UcDDLMember_batch" />
			    </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    預借考績月數
                </td>
                <td>
                    <asp:TextBox ID="TextBox_batch_grad_brot" runat="server" Width="40" MaxLength="4"></asp:TextBox>
                </td>
                <td class="htmltable_Left">
                    核定考績月數
                </td>
                <td>
                    <asp:TextBox ID="TextBox_batch_grad_prot" runat="server" Width="40" MaxLength="4"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Button ID="Button_Batch" runat="server" Text="確定" />
                    <asp:Button ID="Button_Cancel" runat="server" Text="取消"  />
                </td>
            </tr>
        </table>
        <br />
    <table id="tbq" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
                     class="tableStyle99" visible="false" >
                    <tr>
                        <td class="htmltable_Title2" style="width: 100%" align="center">查詢結果
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="Button_Update" runat="server" Text="新增儲存" Visible="false" />
                            <asp:Button ID="Button_Copy" runat="server" Text="複製預借至核定月數" Visible="false" />                 
                            <asp:Button ID="Button_ShowBatch" runat="server" Text="整批考績資料處理" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%" class="TdHeightLight" valign="top">
                        <asp:GridView ID="GridView_Grad" runat="server" AutoGenerateColumns="false" BorderWidth="0px" PageSize="30"
                        AllowPaging="true" CssClass="Grid" PagerStyle-HorizontalAlign="right" Width="100%"
                        EmptyDataText="查無資料!!" >
                <Columns>
                    <asp:TemplateField HeaderText="單位">
                        <HeaderStyle  />
                        <ItemStyle HorizontalAlign="Center" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="Label_dept" runat="server" Text='<%# New FSC.Logic.Org().GetDepartNameWithoutSubDepart(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), Eval("base_dep").ToString)%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="員工姓名">
                        <HeaderStyle  />
                        <ItemStyle HorizontalAlign="Center" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="Label_name" runat="server" Text='<%# Eval("Base_Name") %>' ></asp:Label>
                            <asp:TextBox ID="TextBox_Grad_Seqno" runat="server" Text='<%# Eval("Base_Seqno") %>' Visible="false" ></asp:TextBox>
                            <asp:TextBox ID="TextBox_Grad_Year" runat="server" Text='<%# Eval("Grad_Year") %>' Visible="false" ></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="身分證字號">
                        <HeaderStyle  />
                        <ItemStyle HorizontalAlign="Center" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="Label_idno" runat="server" Text='<%# Eval("Base_Idno") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="職業類別">
                        <HeaderStyle  />
                        <ItemStyle HorizontalAlign="Center" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="Label_job" runat="server" Text='<%# Eval("base_job_name") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="人員類別">
                        <HeaderStyle  />
                        <ItemStyle HorizontalAlign="Center" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="Label_prono" runat="server" Text='<%# Eval("base_prono_name")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="職稱">
                        <HeaderStyle  />
                        <ItemStyle HorizontalAlign="Center" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="Label_DCODE" runat="server" Text='<%# Eval("base_DCODE_name")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="預借考績" >
                        <HeaderStyle  />
                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox_Grad_Brot" runat="server" 
                            Text='<%# Cstr(CDBL(Eval("Grad_Brot"))) %>' Width="80" MaxLength="4">
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="核定考績">
                        <HeaderStyle  />
                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox_Grad_Prot" runat="server" 
                            Text='<%# Cstr(CDBL(Eval("Grad_Prot"))) %>' Width="80" MaxLength="4">
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="list_tr" />
                  <RowStyle CssClass="list_tr" />
                                <EmptyDataTemplate>
                                    查無資料!!
                                </EmptyDataTemplate>
                                <RowStyle CssClass="Row" />
                                <AlternatingRowStyle CssClass="AlternatingRow" />
                                <PagerSettings Position="TopAndBottom" />
                                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
        </asp:GridView>
                            </td>
                    </tr>
                    <tr>
                        <td align="right" class="TdHeightLight" style="width: 100%">
        <uc1:UcPager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridView_Grad"
            PNow="1" PSize="30" Visible="false" />
                            </td>
                    </tr>
                </table>
</asp:Content>

