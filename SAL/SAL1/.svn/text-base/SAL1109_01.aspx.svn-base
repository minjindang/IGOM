<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL1109_01.aspx.cs" Inherits="SAL_SAL1_SAL1109_01" %>

<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <script type="text/javascript">
            function checkData() {
                if ('<%= lbNotice.Text.Trim() %>' != "") {
                if (!confirm('<%= lbNotice.Text.Trim() %>'))
                    return false;
                else
                    return true;
            } else
                return true;
        }
    </script>
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">結婚生育及喪葬補助費申請</td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 100px">申請事由</td>
                <td class="htmltable_Right" style="width: 300px" colspan="3">
                    <uc1:ucSaCode runat="server" ID="ucApply_type" Code_sys="006" Code_type="015" ControlType="DropDownList" ReturnEvent="true" OnCodeChanged="ucApply_type_CodeChanged" />
                </td>
              
            </tr>
            <tr runat="server" id="Marry" visible="true">
                <td class="htmltable_Left" style="width: 100px">結緍日期
                </td>
                <td class="TdHeightLight" style="width: 850px" colspan="3">
                    <uc2:UcDate ID="UcDateMarry1" runat="server"></uc2:UcDate>
                    <asp:Label ID="MarryDate" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
                </td>
            </tr>
            <tr runat="server" id="Birth" visible="false">
                <td class="htmltable_Left" style="width: 100px">生育日期
                </td>
                <td class="TdHeightLight" style="width: 850px" colspan="3">
                    <uc2:UcDate ID="UcDateBirth1" runat="server"></uc2:UcDate>
                    <asp:Label ID="BirthDate" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
                </td>
            </tr>
            <tr runat="server" id="Death" visible="false">
                <td class="htmltable_Left" style="width: 100px">喪葬日期
                </td>
                <td class="TdHeightLight" style="width: 850px" colspan="3">
                    <uc2:UcDate ID="UcDateDeath1" runat="server"></uc2:UcDate>
                    <asp:Label ID="DeathDate" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 100px">檢附文件說明</td>
                <td class="htmltable_Right" colspan="3">
                    <asp:Label ID="label3" runat="server">
                             一、公務人員喪葬補助：檢附證明文件（以下資料可檢附正或影本，如為影本，請書寫姓名及與正本相符）：<br/>
                            （一）	死亡證明書。<br/>
                            （二）	死者死亡登記戶籍謄本。<br/>
                            （三）	請領人戶籍謄本。<br/>
                            二、公保現金給付請領－眷屬喪葬津貼：檢附證明文件：<br/>
                            （一）	公教人員保險現金給付請領書<font color="red">(空白表格請洽人事單位索取)。</font><br/>
                            （二）	領取公教人員保險現金給付收據(直撥入帳辦理給付得免填本收據聯)或	匯入款項之存摺封面影本（不得為「靜止戶」、「結清戶」、「非綜合存摺之公教優惠存款帳戶」）。<br/>
                            （三）  公教人員保險被保險人請領眷屬喪葬津貼切結書<font color="red">（一式3份，空白表格請洽人事單位索取)。</font><br/>
                            （四）	死亡證明書或其他合法死亡證明文件正本。<br/>
                            （五）	死者死亡登記戶籍謄本正本。<br/>
                            （六）	被保險人戶籍謄本正本。
                    </asp:Label>
                    <asp:Label ID="label1" runat="server">
                        一、檢附證明文件（以下資料可檢附正或影本，如為影本，請書寫姓名及與正本相符）：<br/>
                        （一）	結婚證明書。<br/>
                        （二）	請領人戶籍謄本或戶口名簿（需有配偶入戶資料）。<br/>
                        二、人事單位將於收受上述文件後，至生活津貼系統列印申請表，請請領人簽章。
                    </asp:Label>
                    <asp:Label ID="label2" runat="server">
                        一、檢附證明文件（以下資料可檢附正或影本，如為影本，請書寫姓名及與正本相符）：<br/>
                        （一）	出生證明書。<br/>
                        （二）	請領人戶籍謄本或戶口名簿（需有出生兒入戶資料）。<br/>
                        （三）	公教人員保險生育給付請領書<font color="red">(空白表格請洽人事單位索取)。</font><br/>
                        二、人事單位將於收受上述文件後，至生活津貼系統列印申請表，請請領人簽章。
                    </asp:Label>
                </td>
            </tr>
            <tr runat="server" id="trRelation_type" visible="false">
                <td class="htmltable_Left">補助對象</td>
                <td class="htmltable_Right" colspan="3">
                    <uc1:ucSaCode runat="server" ID="ucRelation_type" Code_sys="006" Code_type="016" ControlType="DropDownList" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">申請金額</td>
                <td class="htmltable_Right" colspan="3">
                    <asp:TextBox ID="txtboxAmt" runat="server" Enabled="false" Text="0"></asp:TextBox></td>
            </tr>

            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;"> 
                    <asp:Button ID="btn_submit" runat="server" Text=" 送出申請 " OnClick="btn_submit_Click" OnClientClick="if(!checkData()) return false;blockUI();" />
                    <asp:Button ID="btn_back" runat="server" Text="回上頁" OnClick="BackBtn_Click" Visible="false" />
                    <asp:Label ID="lbNotice" runat="server" Visible="false" />
                </td>
            </tr>

        </table>
    </div>
    <div >
        <asp:GridView ID="GridViewA" runat="server"
            AutoGenerateColumns="False" DataKeyNames=""
            AllowPaging="True" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:BoundField DataField="User_name" HeaderText="姓名" />
                <asp:BoundField DataField="Org_name" HeaderText="單位名稱" />
                <asp:BoundField DataField="Emp_type" HeaderText="人員類別" />
                <asp:BoundField DataField="Apply_date" HeaderText="申請日期" />
                <asp:BoundField DataField="Applytype_name" HeaderText="申請事由" /> 
                <asp:BoundField DataField="Apply_amt" HeaderText="申請金額" /> 
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
    </div>

</asp:Content>

