<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false" 
    CodeFile="SAL1113_03.aspx.vb" Inherits="FSC1_FSC13_FSC1306_03" %>

<%@ Register Src="../../UControl/UcTextBox.ascx" TagName="UcTextBox" TagPrefix="uc2" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register src="../../UControl/UcShowDate.ascx" tagname="UcShowDate" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" language="javascript">
        function check() {
            if (document.all("ctl00$ContentPlaceHolder1$ddlOfficialout_date").value == "" || document.all("ctl00$ContentPlaceHolder1$ddlOfficialout_date").value == null) {
                alert("請選擇[日期]");
                return false;
            }
        }
    </script>
     <script type="text/javascript" src="../../js/json2.js"></script>
    <script type="text/javascript"  src="../../js/Nuk_Budget.js"></script>
    <table width="100%" class="tableStyle99" id="ApplyForm" runat="server">
        <tr>
            <td class="htmltable_Title">
                國外差旅費申請
            </td>
        </tr>
        <tr>
            <td class="TdHeightLight">
                <table class="Grid" style="width:100%">
                    <tr>
                        <th rowspan="2">
                            表單編號</th>
                        <th rowspan="2">
                            日期</th>
                        <th rowspan="2">
                            公差地點(起訖)</th>
                        <th rowspan="2">
                            工作內容</th>
                        <th colspan="3">
                            交通費</th>
                        <th rowspan="2">
                            生活費</th>
                        <th colspan="5">
                            辦公費</th>
                        <th rowspan="2">
                            單據<br/>號數</th>
                        <th rowspan="2">
                            備註</th>
                    </tr>
                    <tr>
                        <th>飛機</th>
                        <th>船舶</th>
                        <th>長途大眾<br />陸運工具</th>
                        <th>
                           手續費</th>
                        <th>
                            保險費</th>
                        <th>
                            行政費</th>
                        <th>
                           禮品及<br />交際費</th>
                        <th>
                            雜費</th>
                    </tr>
                    <tr>
                        <td>               
                            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                                    <asp:DropDownList runat="server" ID= "ddlGuid" AutoPostBack="true" />
                                    <asp:HiddenField ID="hfSerial_nos" runat="server"/>
                                    <asp:HiddenField ID="hfOfficialout_dateb" runat="server"/>
                                    <asp:HiddenField ID="hfOfficialout_timeb" runat="server"/>
                                    <asp:HiddenField ID="hfOfficialout_type" runat="server"/>
                                <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </td>
                        <td>
                            <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>--%>
                                    <asp:DropDownList runat="server" ID= "ddlOfficialout_date" />
                                <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>                 
                        </td>
                        <td>                        
                            <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>--%>
                                    <asp:TextBox runat="server" ID = "tbPlace_start" width="70" MaxLength="10"/>
                                    至
                                    <asp:TextBox runat="server" ID = "tbPlace_end" width="70" MaxLength="10"/>
                                <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </td>
                        <td>                        
                            <%--<asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>--%>
                                    <uc2:UcTextBox ID="tbIntroduction" runat="server" MaxLength="120" TextMode="MultiLine" Width="80" />
                                <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </td>
                        <td><asp:TextBox runat="server" ID = "tbPlane" width="40"/></td>
                        <td><asp:TextBox runat="server" ID = "tbBoat" width="40"/></td>
                        <td><asp:TextBox runat="server" ID = "tbLong_traffic" width="40"/></td>
                        <td><asp:TextBox runat="server" ID = "tbLife_fee" width="40"/></td>
                        <td><asp:TextBox runat="server" ID = "tbFee" width="40" /></td>
                        <td><asp:TextBox runat="server" ID = "tbInsurance" width="40"/></td>
                        <td><asp:TextBox runat="server" ID = "tbAdministrative_costs" width="40"/></td>
                        <td><asp:TextBox runat="server" ID = "tbGift_entertainment_expenses" width="30px"/></td>
                        <td><asp:TextBox runat="server" ID = "tbIncidentals" width="30px"/></td>
                        <td><asp:TextBox runat="server" ID = "tbRecipnumber" width="40"/></td>
                        <td><uc2:uctextbox ID="tbNote" runat="server" MaxLength="60" TextMode="MultiLine" Width="80" /></td>
                    </tr>        
                </table>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" style="background-color:#FFFFFF">
                <asp:Button ID="btnSave" runat="server" Text="新增" OnClientClick="return check();"/>
                <asp:Button ID="cbCancel" runat="server" Text="取消" Visible="false" />
                <input id="cbReset" type="button" value="重填" runat="server" />
                <asp:Button ID="cbCopy" runat="server" Text="複製前筆" Visible="false" />
                <asp:Button ID="cbBack2" runat="server" Text="回上頁"/> 
            </td>
        </tr>
    </table>
    <br />
    <table width="100%" border="0" cellpadding="0" cellspacing="0" id="tbList" runat="server" class="tableStyle99">
        <tr>
            <td class="htmltable_Title">
                國外差旅費申請明細
            </td>
        </tr>
        <tr>
            <td class="TdHeightLight">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" PageSize="30"
                    CssClass="Grid" Width="100%" Borderwidth="0px" PagerStyle-HorizontalAlign="Right" AllowPaging="True">
                    <Columns>
                        <asp:TemplateField HeaderText="日期">
                            <ItemTemplate>
                                <uc3:UcShowDate ID="UcShowDate1" runat="server" Text='<%# Eval("Officialout_date") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="公差地點(起訖)">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbPlace_start" Text='<%# Eval("Place_start")%>'></asp:Label>
                                至
                                <asp:Label runat="server" ID="lbPlace_end" Text='<%# Eval("Place_end")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Introduction" HeaderText="工作內容" 
                            HeaderStyle-Width="110px" ItemStyle-Width="110px" >                  
                            <HeaderStyle Width="110px"></HeaderStyle>
                            <ItemStyle Width="110px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Plane" HeaderText="飛機" />
                        <asp:BoundField DataField="Boat" HeaderText="船舶" />
                        <asp:BoundField DataField="Long_traffic" HeaderText="長途大眾陸運工具" />
                        <asp:BoundField DataField="Life_fee" HeaderText="生活費" />
                        <asp:BoundField DataField="Fee" HeaderText="手續費" />
                        <asp:BoundField DataField="Insurance" HeaderText="保險費" />
                        <asp:BoundField DataField="Administrative_costs" HeaderText="行政費" />
                        <asp:BoundField DataField="Gift_entertainment_expenses" HeaderText="禮品及交際費" />
                        <asp:BoundField DataField="Incidentals" HeaderText="雜費" />
                        <asp:BoundField DataField="Recipnumber" HeaderText="單據號數" />
                        <asp:BoundField DataField="Total" HeaderText="總計" />
                        <asp:BoundField DataField="Note" HeaderText="備註" />
                        <asp:TemplateField HeaderText="功能">
                            <ItemTemplate>
                                <asp:Button ID="cbUpdate" runat="server" OnClick="cbUpdate_Click" Text="修改" /><br />
                                <asp:Button ID="btnDelete" runat="server" Text="刪除" CommandName= "delete"/>
                                <asp:HiddenField ID="hfOrgcode" runat="server" Value='<%# Eval("Orgcode") %>'/>
                                <asp:HiddenField ID="hfDepartId" runat="server" Value='<%# Eval("Depart_id") %>'/>
                                <asp:HiddenField ID="hfIdCard" runat="server" Value='<%# Eval("Id_card") %>'/>
                                <asp:HiddenField ID="hfSerial_nos" runat="server" Value='<%# Eval("Serial_nos") %>'/>
                                <asp:HiddenField ID="hfStatus" runat="server" Value='<%# Eval("Status")%>'/>
                                <asp:HiddenField ID="hfppguid" runat="server" Value='<%# Eval("ppguid")%>'/>
                                <asp:HiddenField ID="hfOfficialout_type" runat="server" Value='<%# Eval("Officialout_type")%>'/>
                                <asp:HiddenField ID="hfOfficialout_dateb" runat="server" Value='<%# Eval("Officialout_dateb")%>'/>
                                <asp:HiddenField ID="hfOfficialout_timeb" runat="server" Value='<%# Eval("Officialout_timeb")%>'/>
                                <asp:HiddenField ID="hOfficialoutfee_type" runat="server" Value='<%# Eval("Officialoutfee_type")%>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />                                
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Page" align="right">
                <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvList"
                        Other1="Ucpager2" PNow="1" PSize="30" Visible="true" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom">
                <asp:Button ID="cbConfirm" runat="server" Text="送出申請" />
                <asp:Button ID="cbPrint" runat="server" Text="列印" Visible="false" />
                <asp:Button ID="cbPrint2" runat="server" Text="公差資料" Visible="false" />
                <asp:Button ID="btnBack" runat="server" Text="回上頁"/>   
                </td> 
        </tr>
    </table>
    <div style="color: Blue; line-height:20px; margin-top:5px;">
    <ol>
        <li>【送出申請】後，務必【列印】差旅費申請表、公差批示情形表！</li>
        <li>【送出申請】後，畫面將鎖定，不可重新修改送出，若要修改或列印資料，請人事/庶務人員退回。</li>
        <li>「備註」欄可填寫６０個文字。</li>
        <li>【說明一：】本畫面分為上、下兩部分，請先於下方點選日期，並分別填入欲請領金額後，再點選下方之【新增】鍵，該筆資料將轉入上方之差旅費申請明細。</li>
        <li>【說明二：】若某筆資料填寫錯誤需修改，請至上方該筆明細最末端，點選【修改】鍵；若欲刪除該筆明細，則至最末端點選【刪除】鍵。</li>
        <li>【說明三：】待所有出差日期之資料皆新增並轉入上方之差旅費申請明細後，再點選【送出申請】鍵後，送出前請仔細確認金額，因點選該鍵後即無法重新送出。</li>
        <li>【說明四：】主計處要求申請差旅費，差旅費及公差批示情形表必須雙面列印，設定方式點選<a href="FSC1306.doc">下載</a>。</li>
    </ol></div>
    <asp:HiddenField ID="hfAction" runat="server"/>
        <asp:HiddenField ID="hdPID" runat="server"/>
    <asp:HiddenField ID="hdDepID" runat="server" />
        <asp:HiddenField ID="hdFormID" runat="server" />
    <asp:hiddenField ID="hdFlow_ID" runat="server" />
    <asp:hiddenField id="hdbudget_type" runat="server" />
    <asp:HiddenField ID="hfGuidList" runat="server" />
</asp:Content>

