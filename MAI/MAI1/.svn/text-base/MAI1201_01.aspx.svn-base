<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAI1201_01.aspx.vb" Inherits="MAI_MAI1_MAI1201_01" %>

<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">水電報修申請
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left"><span style="color: red">*</span>報修人聯絡分機
                </td>
                <td style="width: 326px">
                    <asp:TextBox ID="txtPhone_nos" runat="server"></asp:TextBox>
                </td>
                <td class="htmltable_Left">報修人
                </td>
                <td style="width: 326px">
                    <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">報修單位別
                </td>
                <td colspan="3">
                    <asp:Label ID="lblDeptName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left"><span style="color: red">*</span>報修類別
                </td>
                <td colspan="3">
                    <uc1:ucSaCode runat="server" ID="ucMtClass_type" Code_sys="019" Code_type="008" ControlType="RadioButtonList"    />
                    <asp:TextBox ID="txtMtItemOther_desc" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="htmltable_Left"><span style="color: red">*</span>問題描述
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtProblem_desc" runat="server" TextMode="MultiLine" ></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="htmltable_Left">前往維修時間
                </td>
                <td style="width: 326px">
                    <uc1:ucSaCode runat="server" ID="ucElecExpect_type" Code_sys="019" Code_type="005" ControlType="RadioButtonList"    />
                </td>
                <td class="htmltable_Left">上傳附件
                </td>
                <td style="width: 326px">
                    <asp:FileUpload ID="fuAttachment" runat="server" />
                </td>
            </tr>

            <tr>
                <td class="htmltable_Left">備註
                </td>
                <td colspan="3">
                    <span style="color: red">
                        1.若報修類別選擇"電話"或"電燈"時，須註明"分機號碼"或"報修數量"，餘請註明"樓層"
                        及可能位置。
                    </span>
                    <br />
                    <span style="color: black">
                        2.資料鍵入之校正工作由申請單位自行負責。
                    </span>
                    <br />
                    <span style="color: black">
                        3.報修類別請分類勾選。
                    </span>
                    <br />
                    <span style="color: black">
                        4.報修類別若有多項，可點選[新增一筆資料]並依序報修。
                    </span>
                    <br />
                    <span style="color: black">
                        5.報修描述依報修類別條列說明，並請力求詳細，如有問題時請洽秘書室洪鉅發2459。
                    </span>
                    <br />
                </td>
            </tr>

            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="AddBtn" runat="server" Text="新增一筆資料" />
                    <asp:Button ID="DoneBtn" runat="server" Text="送出申請" />
                </td>
            </tr>
        </table>
        <div id="div1" runat="server" visible="true">
            <asp:GridView ID="GridViewA" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px"
                Width="100%">
                <PagerSettings Visible="True" />
                <Columns>
                    <asp:BoundField DataField="MtClass_typeName" HeaderText="報修類別" />
                    <asp:BoundField DataField="Problem_desc" HeaderText="問題描述" />
                    <asp:BoundField DataField="ElecExpect_typeName" HeaderText="前往維修時間" /> 
                    <asp:TemplateField HeaderText="維護">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:HiddenField runat="server" ID="hfElecExpect_type" Value='<%# Eval("ElecExpect_type")%>' />
                            <asp:HiddenField runat="server" ID="hfMtClass_type" Value='<%# Eval("MtClass_type")%>' /> 
                            <asp:Button ID="btnMain" runat="server" Text="維護" CommandName="Maintain" onclick="btnMaintain_Click" />
                            <asp:Button ID="btnDelete" CommandName="GoDelete" runat="server" Text="刪除"  onclick="btnDelete_Click" OnClientClick="return confirm('是否確定要刪除?');" />
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
    </div>

</asp:Content>

