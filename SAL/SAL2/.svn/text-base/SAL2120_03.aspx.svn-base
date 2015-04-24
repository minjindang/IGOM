<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SAL2120_03.aspx.vb" Inherits="SAL2120_03" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">補充保費扣繳證明書列印(年度)
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">姓名或身分證字號 </td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                            <asp:TextBox ID="txtNameStr" runat="server"></asp:TextBox>
                        </td>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">選擇所得年月 </td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                                    <asp:DropDownList ID="ddlYY" runat="server">
                                    </asp:DropDownList>&nbsp;年&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">工作計畫 </td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                             <asp:DropDownList ID="ddlProj" runat="server">
                             </asp:DropDownList>
                        </td>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">職業類別 </td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                                    <asp:DropDownList ID="ddlJob" runat="server">
                                    </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">在職狀態 </td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                                    <asp:DropDownList ID="ddlBdate" runat="server">
                                        <asp:ListItem Value="0" Text="---全部---" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="在職"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="已離職"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="非員工"></asp:ListItem>
                                    </asp:DropDownList>
                        </td>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">所得類別 </td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                                <asp:DropDownList ID="ddlNhiKind" runat="server">
                                    <asp:ListItem Value="all" Text="---全部---"></asp:ListItem>
                                    <asp:ListItem Value="62" Text="逾當月投保金額四倍部分之獎金(62)"></asp:ListItem>
                                    <asp:ListItem Value="63" Text="非所屬投保單位給付之薪資所得(63)"></asp:ListItem>
                                    <asp:ListItem Value="65" Text="執行業務收入(65)"></asp:ListItem>
                                    <asp:ListItem Value="67" Text="利息所得(67)"></asp:ListItem>
                                    <asp:ListItem Value="68" Text="租金收入(68)"></asp:ListItem>
                                </asp:DropDownList>
                        </td>
                    </tr>
            <tr>
                <td class="TdHeightLight" colspan="4" align="center">
                <div id="div_btn" runat="server" visible="false" align="center" >
                    <table border="0"><tr><td>  
                    <asp:CheckBoxList ID="cblType" runat="server" RepeatDirection="Horizontal" >
                        <asp:ListItem Text="列印存根聯" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="列印備查聯" Value="2" Selected="True"></asp:ListItem>
                    </asp:CheckBoxList>            
                    </td><td>
                    </td></tr></table>     
                </div>             
                </td>
            </tr>
            <tr>
                <td class="TdHeightLight" colspan="4" align="center" >
                    <asp:Button ID="btnQuery" runat="server" Text="查詢" />
                    <asp:Button ID="btnPrint" runat="server" Text="列印" />
                </td>
            </tr>
        </table>
        <br />    
        <table width="100%" border="0" cellpadding="0" cellspacing="0"><tr><td align="center">  
        <asp:Label ID="lbSum" runat="server" Text="" font-size="Small"></asp:Label>
        </td></tr></table>
                        <table id="tbq" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
                    visible="true" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title2" style="width: 100%" align="center">查詢結果
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%" class="TdHeightLight" valign="top">
                            <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="false" BorderWidth="0px" PageSize="30"
                                AllowPaging="true" CssClass="Grid" PagerStyle-HorizontalAlign="right" Width="100%"
                                EmptyDataText="查無資料!!">
            <EmptyDataTemplate>
                目前無任何資料!!
            </EmptyDataTemplate>
            <Columns>
                <asp:TemplateField HeaderText="勾選">
                    <ItemTemplate>
                        <asp:CheckBox ID="chk" runat="server" />
                    </ItemTemplate>
                    <HeaderStyle />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="姓名">
                    <ItemTemplate>
                        <asp:Label ID="PAYO_NAME" runat="server" Text='<%# Eval("PAYO_NAME")%>'></asp:Label>
                        <asp:Label ID="PAYO_SEQNO" runat="server" Text='<%# Eval("PAYO_SEQNO")%>' Visible="false"></asp:Label>
                        <asp:Label ID="NHIKIND" runat="server" Text='<%# Eval("NHIKIND")%>' Visible="false" />
                    </ItemTemplate>
                    <HeaderStyle />
                    <ItemStyle />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="給付總額">
                    <ItemTemplate>
                        <asp:Label ID="AMT" runat="server" Text='<%# Eval("AMT")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle />
                    <ItemStyle />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="補充保費金額">
                    <ItemTemplate>
                        <asp:Label ID="EXT" runat="server" Text='<%# Eval("EXT")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle />
                    <ItemStyle />
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="Row" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" /> 
        </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TdHeightLight" style="width: 100%">
                            <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvList"
                                PNow="1" PSize="30" Visible="true" />
                        </td>
                    </tr>
                </table>
    </div>
</asp:Content>