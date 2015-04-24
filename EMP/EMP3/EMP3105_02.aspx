<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="EMP3105_02.aspx.cs" Inherits="EMP_EMP3_EMP3105_02" %>
<%@ Register src="~/UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc2" %>
<%@ Register src="~/UControl/UcTextBox.ascx" tagname="UcTextBox" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../CSS/css.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/syntegra3.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" media="all" href="../../css/aqua.css" />    
    <link type="text/css" href="../../CSS/smoothness/jquery-ui-1.8.18.custom.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/jquery-1.4.2.min.js"></script> 
    <script type="text/javascript" src="../../js/jquery.blockUI.js"></script>
    <script type="text/javascript" src="../../js/jquery.maxlength.js"></script> 
    <script type="text/javascript" src="../../js/jquery-ui-1.8.18.custom.min.js"></script>
	<script type="text/javascript" src="../../js/DgJScript.js"></script>
    <script type="text/javascript" src="../../js/utils.js"></script>
    <script type="text/javascript" src="../../js/roc.js"></script>   
    <script type="text/javascript" src="../../js/CalendarPopup.js"></script>    
    <script type="text/javascript" language="javascript">
        document.write(getCalendarStyles());
        var cal1xx = new CalendarPopup("CalendarDiv");
        cal1xx.showNavigationDropdowns();

        function displayDatePicker(txtid, timeid, target) {
            cal1xx.select(document.getElementById(txtid), txtid, 'yyy/MM/dd', document.getElementById(timeid), target);
        }
        function chgValue() { }
        function checkDate(did) {
            var d = $('#' + did).val();
            if (d == '')
                return;

            var err = false;

            regex = /\S{9}/;
            if (!regex.test(d))
                err = true;

            regex = /\d{3}\/\d{2}\/\d{2}/;
            if (!regex.test(d))
                err = true;

            //        regex = /\d{3}([0][13578][0][1-9]|[0][13578][1-2][0-9]|[0][13578][3][0-1])|([0][469][0][1-9]|[0][469][1-2][0-9]|[0][469][3][0])|([1][11][0][1-9]|[1][11][1-2][0-9]|[1][11][3][0])|([1][12][0][1-9]|[1][12][1-2][0-9]|[1][12][3][0-1])|([0][2][0][1-9]|[0][2][1-2][0-9])/;
            //        if(!regex.test(d))
            //            err = true;

            if (err) {
                alert("日期格式錯誤!");
                $('#' + did).val("");
                $('#' + did).focus();
            }

        }

        function checkTime(tid) {
            var t = $('#' + tid).val();
            var err = false;

            regex = /\d{4}/;
            if (!regex.test(t))
                err = true;

            regex = /([0-1][0-9]|[2][0-3])[0-5][0-9]/;
            if (!regex.test(t))
                err = true;

            if (err) {
                alert("時間格式錯誤!");
                $('#' + tid).val("");
                $('#' + tid).focus();
            }
        }
    </script>  
    <div id="CalendarDiv" style="position:absolute;visibility:hidden;background-color:white;background-color:white;"></div>
    <div>
    <table id="tbLeaveEmailNoticeSetting" border = "1" cellpadding = "0" cellspacing = "0" width="100%"   class="tableStyle99">        
        <tr>
            <td class="htmltable_Title"  colspan="2">
                年資異動明細</td>
        </tr>
        <tr>
            <td class="htmltable_Title2"  colspan="2">
                維護</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:150px">
                異動原因</td>
            <td class="htmltable_Right" style="width:200px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlReason" runat="server" AutoPostBack="true">
                        </asp:DropDownList>    
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:150px">
                <span style="color: #ff0000">*</span>年資起迄</td>
            <td class="htmltable_Right">                
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rb1" runat="server" Text="" Checked="true" 
                                        AutoPostBack="true" oncheckedchanged="rb1_CheckedChanged"/></td>
                                <td>
                                    <uc2:UcDate ID="UcDate1" runat="server" /> ~              
                                    <uc2:UcDate ID="UcDate2" runat="server" /></td>
                            </tr>                        
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rb2" runat="server" Text="" AutoPostBack="true" 
                                        oncheckedchanged="rb2_CheckedChanged"/></td>
                                <td>
                                    <asp:TextBox ID="tbYears" runat="server" Width="25"></asp:TextBox>年 
                                    <asp:TextBox ID="tbMonths" runat="server" Width="25"></asp:TextBox>月</td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server" Visible="false">
                        <asp:TextBox ID="tbdays" runat="server" Width="50"></asp:TextBox>天
                    </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:150px">
                <span style="color: #ff0000">*</span>年資加減註記</td>
            <td class="htmltable_Right" style="width:200px">
                <asp:DropDownList ID="ddlYearFlag" runat="server">
                    <asp:ListItem Text="1:加年資" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2:減年資" Value="2"></asp:ListItem>
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:150px">
                <span style="color: #ff0000">*</span>備註</td>
            <td class="htmltable_Right" style="width:200px">
                <uc3:UcTextBox ID="UcNote" runat="server" MaxLength="100" />
                </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lbId" runat="server" Visible="false"></asp:Label>
                <asp:Button ID="cbConfirm" runat="server" Text="確認" onclick="cbConfirm_Click" />
                <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" />
                <asp:Button ID="cbCancelUpdate" runat="server" Text="取消" Visible="false" 
                    onclick="cbCancelUpdate_Click" />
                <asp:Button ID="cbCancel" runat="server" Text="取消" Visible="false" 
                    onclick="cbCancelUpdate_Click" />
            </td>
        </tr>
    </table>
    <br />
     <table id="Table1" border="1" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">        
        <tr>
            <td  colspan="4" class="htmltable_Title2">
                查詢結果</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Borderwidth="0px" AllowPaging="True" PageSize="30" ShowFooter="true"
                        CssClass="Grid" PagerStyle-HorizontalAlign="Right" width="100%" EmptyDataText="查無資料!" EmptyDataRowStyle-ForeColor="Red"
                        OnRowDataBound="gvList_RowDataBound" OnRowCreated="gvList_RowCreated" >                       
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemTemplate>
                                <asp:Label ID="lbId" runat="server" Text='<%# Bind("Id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbNo" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="年資起迄">
                            <ItemTemplate>
                                <asp:Label ID="lbYear_sdate2" runat="server" Text='<%# Bind("Year_sdate") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbYear_edate2" runat="server" Text='<%# Bind("Year_edate") %>' Visible="false"></asp:Label>

                                <asp:Label ID="lbYears" runat="server" Text='<%# Bind("Years") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbMonths" runat="server" Text='<%# Bind("Months") %>' Visible="false"></asp:Label>
                                
                                <asp:Panel ID="Panel1" runat="server">
                                    <asp:Label ID="lbYear_sdate" runat="server" Text='<%# Bind("Year_sdate") %>'></asp:Label> ~
                                    <asp:Label ID="lbYear_edate" runat="server" Text='<%# Bind("Year_edate") %>'></asp:Label>
                                </asp:Panel>
                                <asp:Panel ID="Panel2" runat="server" Visible="false">
                                    <asp:Label ID="lbYear_days" runat="server" Text='<%# Bind("Year_days") %>'></asp:Label>天
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="休假年資">
                            <ItemTemplate>
                                <asp:Label ID="lbYear" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="加減年資">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdYearFlag" runat="server" Value='<%# Bind("Year_flag") %>' />
                                <asp:Label ID="lbYearFlag" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="異動原因">
                            <ItemTemplate>
                                <asp:Label ID="lbReasonName" runat="server"></asp:Label>
                                <asp:Label ID="lbReason" runat="server" Text='<%# Bind("Reason") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Note" HeaderText="備註" />
                        <asp:TemplateField HeaderText="功能">
                            <ItemTemplate>
                                <asp:Button ID="cbUpdate" runat="server" Text="修改" onclick="cbUpdate_Click"/>
                                <asp:Button ID="cbDelete" runat="server" Text="刪除" 
                                    OnClientClick="javascript:if(!confirm('是否確定要刪除？')) return false;" onclick="cbDelete_Click" 
                                    />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
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
    </table>
    </div>
</asp:Content>
