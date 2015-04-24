<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS2105_01.aspx.vb" Inherits="SYS2105_01" %>

<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border = "0" cellpadding = "0" cellspacing = "0" width = "100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
                E-mail寄送失敗紀錄
            </td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="4">
                查詢條件
            </td>
        </tr>        
        <tr>
            <td class="htmltable_Left" style="width:100px">
                寄件者
            </td>
            <td class="htmltable_Right"  style="width:250px">
                <asp:TextBox ID="txtFromName" runat="server" MaxLength="50" Width="100px"></asp:TextBox>
            </td>
            <td class="htmltable_Left" style="width:100px">
                寄件者Mail
            </td>
            <td class="htmltable_Right" style="width:250px" >
                <asp:TextBox ID="txtFromMail" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                收件者
            </td>
            <td class="htmltable_Right"  style="width:250px">
                <asp:TextBox ID="txtToName" runat="server" MaxLength="50" Width="100px"></asp:TextBox>
            </td>
            <td class="htmltable_Left" style="width:100px">
                收件者Mail
            </td>
            <td class="htmltable_Right"  style="width:250px">
                <asp:TextBox ID="txtToMail" runat="server" MaxLength="50"  Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                錯誤訊息
            </td>
            <td class="htmltable_Right" style="width:250px">
                <asp:DropDownList ID="ddlErrorMsg" runat="server">
                    <asp:ListItem Value="">全部</asp:ListItem>
                    <asp:ListItem Value="1">電子郵件地址未填寫</asp:ListItem>
                    <asp:ListItem Value="2">電子郵件退件</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="htmltable_Left" style="width:100px">
                日期區間
            </td>
            <td class="htmltable_Right" style="width:250px">
                <uc2:UcDate ID="UcDate1" runat="server" />&nbsp;~<uc2:UcDate ID="UcDate2" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4">
                <asp:Button ID="btnQuery" runat="server" CausesValidation="False" Text="查詢" /><input id="cbRest" type="button" value="重填" />
            </td>
        </tr>
    </table>
    <br />
    <table id="TABLE1" runat="server" border = "0" cellpadding = "0" cellspacing = "0" width = "100%" class="tableStyle99">
        <tr>
            <td align="center" class="htmltable_Title2" colspan="3">
                查詢結果
            </td>
        </tr>    
        <tr>
            <td align="center" colspan="3" class="TdHeightLight">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                    BorderWidth="0px" PagerStyle-HorizontalAlign="Right" AllowPaging="True" PageSize="30" Width="100%">              
                    <Columns>
                        <asp:BoundField DataField="FromName" HeaderText="寄件者"/>
                        <asp:BoundField DataField="ToName" HeaderText="收件者" />
                        <asp:BoundField DataField="Subject" HeaderText="郵件主旨" />
                        <asp:BoundField DataField="SendDate" HeaderText="寄件日期" />
                    </Columns>
                    <EmptyDataTemplate>
                        查無資料
                    </EmptyDataTemplate>    
                    <PagerStyle HorizontalAlign="Right" />                
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                </asp:GridView>
            </td>
        </tr>
        <tr runat="server" id="tr2">
            <td align="right" class="TdHeightLight" colspan="2">
                <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvList" Other1="Ucpager2" PNow="1" PSize="30" Visible="true" />
            </td>
        </tr>
    </table>
    <table border = "0" cellpadding = "0" cellspacing = "0" width = "100%" class="tableStyle99" id="EmptyTable" runat="server" visible="false">
        <tr>
            <td align="center" class="htmltable_Title2" colspan="2" style="height: 22px">
                查詢結果
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="height: 21px" class="EmptyRow">
                查無資料!!</td>
        </tr>
    </table>    
</asp:Content>
