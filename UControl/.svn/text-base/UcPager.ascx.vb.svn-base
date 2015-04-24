Imports System.Web
Imports System.Web.UI
Imports System.ComponentModel
Imports System.Data
Partial Class UControl_Pager
    Inherits System.Web.UI.UserControl

    Public sGridName As String
    Public sPageSize As Integer = 10
    Public sPageNow As Integer = 1
    Public sOther1 As String
    Public sOther2 As String
    Public sOther3 As String

    Protected Sub btnReShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReShow.Click
        If Me.tbRowOfPage.Text <> "" Then
            sPageSize = Convert.ToInt16(Me.tbRowOfPage.Text)
            If sPageSize < 1 Then
                sPageSize = 1
            End If
        End If
        If "" <> sGridName Then
            Dim myGridView As GridView = CType(GetObject(Page, sGridName), GridView)
            If Not myGridView Is Nothing Then
                myGridView.PageSize = sPageSize
                If myGridView.DataSourceID Is Nothing OrElse "" = myGridView.DataSourceID Then
                    myGridView.DataSource = ViewState(sGridName)
                End If
                myGridView.DataBind()
            End If
        End If
    End Sub

    Protected Sub btnToPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnToPage.Click
        If Me.tbNowPage.Text <> "" Then
            sPageNow = Convert.ToInt16(Me.tbNowPage.Text)
            If sPageNow < 1 Then
                sPageNow = 1
            End If
        End If
        If "" <> sGridName Then
            Dim myGridView As GridView = CType(GetObject(Page, sGridName), GridView)
            If Not myGridView Is Nothing Then
                myGridView.PageIndex = sPageNow - 1
                If myGridView.DataSourceID Is Nothing OrElse "" = myGridView.DataSourceID Then
                    myGridView.DataSource = ViewState(sGridName)
                End If
                myGridView.DataBind()
            End If
        End If
    End Sub

    Function GetObject(ByVal obj As Control, ByVal cName As String) As Object
        If (obj.HasControls) Then
            If Not obj.FindControl(cName) Is Nothing Then
                Return obj.FindControl(cName)
            Else
                Dim vObj As Control
                For Each c As Control In obj.Controls
                    vObj = GetObject(c, cName)
                    If Not vObj Is Nothing Then
                        Return vObj
                    End If
                Next
            End If
        End If
        Return Nothing
    End Function

    Protected Sub GridViewInfo()

        If "" <> sGridName Then
            Dim myGridView As GridView = CType(GetObject(Page, sGridName), GridView)
            If Not myGridView Is Nothing Then
                Dim rCount As Integer = 0

                If Not myGridView.DataSource Is Nothing Then
                    Select Case myGridView.DataSource.GetType().ToString
                        Case "System.Data.DataTable"
                            ViewState(sGridName) = CType(myGridView.DataSource, DataTable)
                            rCount = CType(myGridView.DataSource, DataTable).Rows.Count
                        Case "System.Data.DataSet"
                            ViewState(sGridName) = CType(myGridView.DataSource, DataSet).Tables(0)
                            rCount = CType(myGridView.DataSource, DataSet).Tables(0).Rows.Count
                        Case Else
                            ViewState(sGridName) = Nothing
                    End Select
                ElseIf Not myGridView.DataSourceID Is Nothing And "" <> myGridView.DataSourceID Then
                    Dim obj As Object = GetObject(Page, myGridView.DataSourceID)
                    If Not obj Is Nothing Then
                        Select Case obj.ToString()
                            Case "System.Web.UI.WebControls.SqlDataSource"
                                ViewState(sGridName) = CType(CType(obj, SqlDataSource).Select(New DataSourceSelectArguments()), DataView).Table
                                rCount = CType(CType(obj, SqlDataSource).Select(New DataSourceSelectArguments()), DataView).Count
                            Case "System.Web.UI.WebControls.ObjectDataSource"
                                ViewState(sGridName) = CType(CType(obj, ObjectDataSource).Select(), DataView).Table
                                rCount = CType(CType(obj, ObjectDataSource).Select(), DataView).Count
                            Case Else
                                ViewState(sGridName) = Nothing
                        End Select
                    Else
                        ViewState(sGridName) = Nothing
                    End If
                Else
                    If ViewState(sGridName) IsNot Nothing Then
                        rCount = CType(ViewState(sGridName), DataTable).Rows.Count
                    Else
                        ViewState(sGridName) = Nothing
                    End If
                End If
                Me.lbRowCount.Text = rCount
                Me.lbPageCount.Text = myGridView.PageCount
                tbNowPage.Text = (myGridView.PageIndex + 1).ToString
                If rCount = 0 Then
                    Pager.Visible = False
                Else
                    Pager.Visible = True
                End If
            Else
                ViewState(sGridName) = Nothing
                Pager.Visible = False
            End If
        End If

        If "" <> sOther1 Then
            Dim uc As UControl_Pager = CType(GetObject(Page, sOther1), UControl_Pager)
            If Not uc Is Nothing Then
                uc.tbNowPage.Text = Me.tbNowPage.Text
                uc.tbRowOfPage.Text = Me.tbRowOfPage.Text
            End If
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tbNowPage.Attributes.Add("onchange", "checkPage(this.id,this.value,'2');")
        tbRowOfPage.Attributes.Add("onchange", "checkPage(this.id,this.value,'1');")
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        GridViewInfo()
    End Sub

#Region "Property"
    Property GridName() As String
        Get
            Dim s As String = sGridName
            If s Is Nothing Then
                Return String.Empty
            Else
                Return s
            End If
        End Get

        Set(ByVal Value As String)
            sGridName = Value
        End Set
    End Property

    Property PSize() As String
        Get
            Dim s As String = sPageSize
            If s Is Nothing Then
                Return String.Empty
            Else
                Return s
            End If
        End Get

        Set(ByVal Value As String)
            sPageSize = Value
            Me.tbRowOfPage.Text = Value
        End Set
    End Property

    Property PNow() As Integer
        Get
            Return sPageNow
        End Get
        Set(ByVal Value As Integer)
            sPageNow = Value
            Me.tbNowPage.Text = Value
        End Set
    End Property

    Property Other1() As String
        Get
            Dim s As String = sOther1
            If s Is Nothing Then
                Return String.Empty
            Else
                Return s
            End If
        End Get

        Set(ByVal Value As String)
            sOther1 = Value
        End Set
    End Property

    Property Other2() As String
        Get
            Dim s As String = sOther2
            If s Is Nothing Then
                Return String.Empty
            Else
                Return s
            End If
        End Get

        Set(ByVal Value As String)
            sOther2 = Value
        End Set
    End Property

    Property Other3() As String
        Get
            Dim s As String = sOther3
            If s Is Nothing Then
                Return String.Empty
            Else
                Return s
            End If
        End Get

        Set(ByVal Value As String)
            sOther3 = Value
        End Set
    End Property
#End Region

End Class
