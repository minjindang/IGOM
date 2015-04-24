<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL1103_01.aspx.cs" Inherits="SAL_SAL1_SAL1103_01" %>

<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc3" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc3" TagName="UcDate" %>
<%@ Register Src="~/UControl/FSC/UcAttachment.ascx" TagPrefix="uc3" TagName="UcAttachment" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc3" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc3" TagName="UcDDLMember" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">子女教育補助費申請</td>
                <asp:HiddenField ID="hfFlow_id" runat="server" />
                <asp:HiddenField ID="hfGuid" runat="server" />
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 100px">單位</td>
                <td align="left" style="width: 300px">
                    <uc3:UcDDLDepart runat="server" ID="UcDDLDepart" OnSelectedIndexChanged="UcDDLDepart_SelectedIndexChanged" />
                </td>
                <td class="htmltable_Left" style="width: 100px">人員</td>
                <td style="width: 350px">
                    <uc3:UcDDLMember runat="server" ID="UcDDLMember" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 100px">申請學年度/學期</td>
                <td align="left" style="width: 300px">民國<asp:Label ID="lblAcademicYear" runat="server" />年
                    第<asp:Label ID="lblSemester" runat="server" />學期
                </td>
                <td class="htmltable_Left" style="width: 100px"><font size="3" color="red">*</font>子女姓名</td>
                <td style="width: 350px">
                    <asp:TextBox ID="txtChild_name" runat="server" MaxLength="10"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 100px"><font size="3" color="red">*</font>子女學歷</td>
                <td align="left" style="width: 300px">
                    <uc3:ucSaCode runat="server" ID="ucSchool_type" Code_sys="006" Code_type="011" Code_Kind="P" ControlType="DropDownList" ReturnEvent="true" OnCodeChanged="ucSchool_type_CodeChanged" />
                    <asp:Panel ID="pnAttach" runat="server" Visible="false">
                        <%--<uc3:UcAttachment runat="server" id="UcAttachment" />--%>
                        <asp:FileUpload runat="server" id="fuAttachment"/><br />
                        <asp:Label ID="lbdesc" ForeColor="blue" runat="server" Text="國中以上申請補助費需檢附證明" />
                        <asp:HiddenField runat="server" ID="hfAttachmentId" />
                        <br />
                        <asp:Label ID="lbFile_name" runat="server"></asp:Label>
                    </asp:Panel>
                </td>

                <td class="htmltable_Left"><font size="3" color="red">*</font>身分證字號</td>
                <td>
                    <asp:TextBox ID="txtChild_id" runat="server" MaxLength="10"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 100px"><font size="3" color="red">*</font>子女出生日期</td>
                <td align="left" style="width: 300px">
                    <uc3:UcDate runat="server" ID="ucChildBirth_date" />
                </td>

                <td class="htmltable_Left"><font size="3" color="red">*</font>學校名稱科系</td>
                <td>
                    <asp:TextBox ID="txtSchool_name" runat="server" MaxLength="20"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left"><font size="3" color="red">*</font>修業年限</td>
                <td>
                    <asp:TextBox ID="txtStudyLimit_nos" runat="server" MaxLength="3"></asp:TextBox>年
                </td>

                <td class="htmltable_Left"><font size="3" color="red">*</font>就讀年級</td>
                <td>
                    <asp:TextBox ID="txtStudy_nos" runat="server" MaxLength="1"></asp:TextBox>年級
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">申請金額</td>
                <td colspan="3">
                    <asp:TextBox ID="txtApply_amt" runat="server" Text="0" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" />
                    <asp:HiddenField ID="hfModifyIndex" runat="server" />
                    <asp:Button ID="btnLast" runat="server" Text="帶入上期申請資料" OnClick="btnLast_Click" />
                    <asp:Button ID="btnSubmit" runat="server" Text="送出申請" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnBack" runat="server" Text="回上頁" OnClick="btnBack_Click" Visible="false" />
                </td>
            </tr>
        </table>
    </div>
    <div id="div1" runat="server">
        <asp:GridView ID="GridViewA" runat="server"
            AutoGenerateColumns="False" 
            AllowPaging="True" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:BoundField DataField="User_name" HeaderText="申請人姓名" />
                <asp:BoundField DataField="Child_name" HeaderText="子女姓名" />
                <asp:BoundField DataField="ChildBirth_date" HeaderText="子女生日" />
                <asp:BoundField DataField="Apply_date" HeaderText="申請日期" />
                <asp:BoundField DataField="Apply_yy" HeaderText="學年度" />
                <asp:BoundField DataField="Period_type" HeaderText="學期" />
                <asp:BoundField DataField="School_name" HeaderText="學校名稱科系" />
                <asp:BoundField DataField="School_type_name" HeaderText="學歷" />
                <asp:BoundField DataField="StudyLimit_nos" HeaderText="修業年限" />
                <asp:BoundField DataField="Study_nos" HeaderText="就讀年級" />
                <asp:BoundField DataField="Apply_amt" HeaderText="申請金額" />
                <asp:TemplateField HeaderText="維護">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:HiddenField ID="hfGuid" runat="server" Value='<%# Bind("Guid") %>' /> 
                        <asp:HiddenField ID="hfFile_name" runat="server" Value='<%# Bind("File_name") %>' />                        
                        <asp:HiddenField ID="hfFile_size" runat="server" Value='<%# Bind("File_size") %>' />
                        <asp:HiddenField ID="hfFile_type" runat="server" Value='<%# Bind("File_type") %>' />     
                        <asp:HiddenField ID="hfAttach_id" runat="server" Value='<%# Bind("Attach_id") %>' />      
                        <asp:Button ID="btnMain" runat="server" Text="維護" CommandName="Maintain" OnClick="btnMain_Click" />
                        <asp:Button ID="btnDelete" CommandName="GoDelete" runat="server" Text="刪除" OnClick="btnDelete_Click" OnClientClick="return confirm('是否確定要刪除?');" />
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
     <div id="div2" runat="server" visible="false" >
         <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title">查詢結果</td>
            </tr>
             <tr>
                 <td>
        <asp:GridView ID="GridViewB" runat="server"
            AutoGenerateColumns="False" 
            AllowPaging="True" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" OnRowCommand="GridViewB_RowCommand">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:BoundField DataField="User_name" HeaderText="申請人姓名" />
                <asp:BoundField DataField="Child_name" HeaderText="子女姓名" />
                <asp:BoundField DataField="ChildBirth_date" HeaderText="子女生日" />
                <asp:BoundField DataField="child_id" HeaderText="身分證字號"  />
                <asp:BoundField DataField="Apply_date" HeaderText="申請日期" />
                <asp:BoundField DataField="Apply_yy" HeaderText="學年度" />
                <asp:BoundField DataField="Period_type" HeaderText="學期" />
                <asp:BoundField DataField="School_name" HeaderText="學校名稱科系" />
                <asp:TemplateField HeaderText="學歷">
                    <ItemTemplate>
                        <asp:Label ID="lb" runat="server" Text='<%# Eval("School_type_name") %>'></asp:Label>
                        <asp:HiddenField ID="hfSchool_type" runat="server" Value='<%# Eval("School_type") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="StudyLimit_nos" HeaderText="修業年限" />
                <asp:BoundField DataField="Study_nos" HeaderText="就讀年級" />
                <asp:BoundField DataField="Apply_amt" HeaderText="申請金額" />
                <asp:TemplateField HeaderText="維護">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Button ID="btnMain" runat="server" Text="編輯" CommandName="DataView" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
                </td>
                </tr>
             </table>
    </div>
</asp:Content>

