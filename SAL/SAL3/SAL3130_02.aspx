<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL3130_02.aspx.cs" Inherits="SAL3130_01" %>
<%@ Register src="../../UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc4" %>
<%@ Register src="../../UControl/SAL/ucSaCode.ascx" tagname="ucSaCode" tagprefix="uc2" %>
<%@ Register src="../../UControl/SAL/UcSelectOrg.ascx" tagname="UcSelectOrg" tagprefix="uc2" %>
<%@ Register src="../../UControl/SAL/ucDateDropDownList.ascx" tagname="ucDateDropDownList" tagprefix="uc2" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc2" TagName="UcDate" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" >
        $().ready(function () {
            if ('<%= Request.QueryString["id"] %>' != "") {
                var arrObj = document.forms[0].elements;
                var arrLen = arrObj.length;
                for (var i = 0; i < arrLen; i++) {
                    var obj = arrObj[i];
                    if ((obj.type == "text") || (obj.type == "textarea") || (obj.type == "password")) {
                        obj.disabled = true;
                    } else if ((obj.type == "select") || (obj.type == "select-one") || (obj.type == "select-multiple") || (obj.type == "checkbox") || (obj.type == "radio")) {
                        obj.disabled = true;
                    } else if ((obj.type == "button") || (obj.type == "submit")) {
                        if (obj.getAttribute("value") != "回上頁")
                            obj.style.display = "none";
                    }
                }
            }
        });
    </script>     
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">
                <asp:Label ID="lbTitle" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="4">
                就職人員
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                員工編號
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbId_card" runat="server"/> <asp:Button ID="cbQuery" runat="server" Text="查詢" OnClick="cbQuery_Click"/>
            </td>
            <td class="htmltable_Left">
                員工姓名
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbUser_name" runat="server"/>
            </td>
        </tr>      
        <tr>
            <td class="htmltable_Left">
                核派職稱
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList runat="server" ID="ddlTitle_code"
                    DataTextField="code_desc1" DataValueField="code_no"></asp:DropDownList>
            </td>
            <td class="htmltable_Left">
                指定服務單位
            </td>
            <td class="htmltable_Right">
                <uc2:UcDDLDepart runat="server" ID="UcDDLDepart" />
            </td>          
        </tr>    
        <tr>
            <td class="htmltable_Left">
                核派日期
            </td>
            <td class="htmltable_Right">
                <uc2:UcDate runat="server" ID="UcAssign_date" />                
            </td>
            <td class="htmltable_Left">
                核派文號
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbAssign_no" runat="server"/>
            </td>          
        </tr>
        <tr>
            <td class="htmltable_Left">
                到職日期
            </td>
            <td class="htmltable_Right" colspan="4">
                <uc2:UcDate runat="server" ID="UcJoin_date" />
            </td>       
        </tr>
    </table>
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title2" colspan="5">
                人事人員填核
            </td>
        </tr>
        <tr>
            <td class="htmltable_Title3" colspan="5">
                暫支俸額
             
                <asp:RadioButtonList ID="rblEmployeeType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" 
                    AutoPostBack="true" OnSelectedIndexChanged="rblEmployeeType_SelectedIndexChanged">
                    <asp:ListItem Text="職員" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="聘(約)雇人員" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    <table class="tableStyle99" width="100%" id="tb1" runat="server">
        <tr>
            <td class="htmltable_Title3" rowspan="8" style="width:100px;">
                職員
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                官等代碼
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList runat="server" ID="ddlL3_code" 
                    DataTextField="code_desc1" DataValueField="code_no"></asp:DropDownList>
            </td>
            <td class="htmltable_Left">
                職等代碼
            </td>
            <td class="htmltable_Right">                
                <asp:DropDownList runat="server" ID="ddlL1_code" 
                    DataTextField="code_desc1" DataValueField="code_no"></asp:DropDownList>
            </td>     
        </tr>
        <tr>
            <td class="htmltable_Left">
                俸階代碼
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList runat="server" ID="ddlL2_code" 
                    DataTextField="code_desc1" DataValueField="code_no"></asp:DropDownList>
            </td>
            <td class="htmltable_Left">
                俸(薪)
            </td>    
            <td class="htmltable_Right">
                <asp:TextBox ID="tbPtbPoint_nos" runat="server"/>點<asp:TextBox ID="tbPtb_amt" runat="server"/>元
            </td> 
        </tr>
        <tr>
            <td class="htmltable_Left">
                全民健保</td>
            <td class="htmltable_Right" colspan="3">
                <asp:TextBox ID="tbFin_month" runat="server"/>月<asp:TextBox ID="tbFin_amt" runat="server"/>元
                <br />
                <asp:TextBox ID="tbFin_people" runat="server"/>眷屬<asp:TextBox ID="tbFin_people_amt" runat="server"/>元
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                退撫基金</td>
            <td class="htmltable_Right" colspan="3">
                <asp:TextBox ID="tbFund_month" runat="server"/>月<asp:TextBox runat="server" ID="tbFund_day"/>日<asp:TextBox ID="tbFund_amt" runat="server"/>元
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                公保
            </td>
            <td class="htmltable_Right" colspan="3">
                <asp:TextBox ID="tbSafety_month" runat="server"/>月<asp:TextBox runat="server" ID="tbSafety_day"/>日<asp:TextBox ID="tbSafety_amt" runat="server"/>元                
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                福利互助
            </td>
            <td class="htmltable_Right" colspan="3">
                <asp:TextBox ID="tbMutual_month" runat="server"/>月<asp:TextBox ID="tbMutual_amt" runat="server"/>元
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                房屋貸款
            </td>
            <td class="htmltable_Right">
                <asp:CheckBoxList ID="cbxlHouse_type" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Text="有"></asp:ListItem>
                    <asp:ListItem Value="2" Text="無"></asp:ListItem>
                </asp:CheckBoxList>
            </td>
            <td class="htmltable_Left">
                &nbsp;</td>    
            <td class="htmltable_Right">
                &nbsp;</td> 
        </tr>
    </table>
    <table class="tableStyle99" width="100%" id="tb2" runat="server" visible="false">
        <tr>
            <td class="htmltable_Title3" rowspan="6">
                聘(約)雇人員
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                薪點
            </td>
            <td class="htmltable_Right" colspan="3">
                <asp:TextBox ID="tbSalary_point" runat="server"/>點<asp:TextBox ID="tbSalary_amt" runat="server"/>元
            </td>    
        </tr>
        <tr>
            <td class="htmltable_Left">
                折合率
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbRate_nos" runat="server"></asp:TextBox>                
            </td>
            <td class="htmltable_Left">
                每月報酬(元)
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbMonth_pay" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                全民健保</td>
            <td class="htmltable_Right" colspan="3">
                <asp:TextBox ID="tbFin_month0" runat="server"/>月<asp:TextBox ID="tbFin_amt0" runat="server"/>元
                <br />
                <asp:TextBox ID="tbFin_people0" runat="server"/>眷屬<asp:TextBox ID="tbFin_people_amt0" runat="server"/>元
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                離職儲金</td>
            <td class="htmltable_Right" colspan="3">
                <asp:TextBox ID="tbFund_month0" runat="server"/>月<asp:TextBox runat="server" ID="tbFund_day0"/>日<asp:TextBox ID="tbFund_amt0" runat="server"/>元
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                勞保</td>
            <td class="htmltable_Right" colspan="3">
                <asp:TextBox ID="tbSafety_month0" runat="server"/>月<asp:TextBox runat="server" ID="tbSafety_day0"/>日<asp:TextBox ID="tbSafety_amt0" runat="server"/>元                
            </td>
        </tr>
    </table>
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Left">
                主管或專業技術加給
            </td>
            <td class="htmltable_Right">
            <div>
                <table>
                <tr><td>
                    <asp:CheckBox ID="cbxHead_post_plus" runat="server" Text="主管職務加給" />
                </td></tr>
                <tr><td>
                    <asp:CheckBox ID="cbxLaw_prof_plus" runat="server" Text="法制人員專業加給" />
                </td></tr>
                <tr><td>
                    <asp:CheckBox ID="cbxGeneral_prof_plus" runat="server" Text="一般公務人員專業加給" />
                </td></tr>
                <tr><td>
                    <asp:CheckBox ID="cbxEnviprotec_prof_plus" runat="server" Text="環保人員專業加給" />
                </td></tr>
                <tr><td>
                    <asp:CheckBox ID="cbxOperator_prof_plus" runat="server" Text="電子作業人員專業加給" />
                </td></tr>
                <tr><td>
                    <asp:CheckBox ID="cbxEast_taiwan_plus" runat="server" Text="東台加給" />
                </td></tr>
                <tr><td>
                    <asp:CheckBoxList ID="cbxlNatimajproj_post_plus" runat="server">
                        <asp:ListItem Text="簡" Value="1"></asp:ListItem>
                        <asp:ListItem Text="薦" Value="2"></asp:ListItem>
                        <asp:ListItem Text="委" Value="3"></asp:ListItem>
                    </asp:CheckBoxList>
                </td><td>
                    國家重大工程職務加給                    
                </td><td>
                    <asp:CheckBoxList ID="cbxlTechnical_staff" runat="server">
                        <asp:ListItem Text="技術人員" Value="1"></asp:ListItem>
                        <asp:ListItem Text="行政人員" Value="2"></asp:ListItem>
                    </asp:CheckBoxList>
                </td></tr>
                </table>
            </div>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                備註(敍薪異動通知)
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbPromo_desc" runat="server" TextMode="MultiLine" Width="350"></asp:TextBox>
            </td>       
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <asp:Button ID="btnInsert" runat="server" Text="確認" OnClick="btnInsert_Click" />
                <asp:Button ID="btnBack" runat="server" Text="回上頁" OnClick="btnBack_Click"  />
            </td>
        </tr>      
    </table>


</asp:Content>
