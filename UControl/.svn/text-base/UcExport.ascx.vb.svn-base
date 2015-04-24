Imports System.Data
Imports CommonLib
Partial Class UControl_UcExport
    Inherits System.Web.UI.UserControl

    Public btWordName As String = "匯出"
    Public btExcelName As String = "匯出"
    Public btWordVisible As Boolean = False
    Public btExcelVisible As Boolean = False
    Public sGridName As String
    Public wordFileName As String = "Word.doc"
    Public excelFileName As String = "Excel.xls"

    Public titleStr As String = ""
    Public headStr As String = ""
    Public footStr As String = ""

    Public DtOrGv As Boolean = False '資料來源 True 為 GridView 的DataTable , False 為 GridView
    Public isAllGv As Boolean = True '是否為全部的GridView的資料

    Public btnType As String = "1" '1 DataTable ,2 GridView


#Region "Property"

    Property ExportType() As String
        Get
            Dim s As String = btnType
            If s Is Nothing Then
                Return String.Empty
            Else
                Return s
            End If
        End Get

        Set(ByVal Value As String)
            btnType = Value
        End Set
    End Property


    Property TitleControl() As String
        Get
            Dim s As String = titleStr
            If s Is Nothing Then
                Return String.Empty
            Else
                Return s
            End If
        End Get

        Set(ByVal Value As String)
            titleStr = Value
        End Set
    End Property

    Property HeadControl() As String
        Get
            Dim s As String = headStr
            If s Is Nothing Then
                Return String.Empty
            Else
                Return s
            End If
        End Get

        Set(ByVal Value As String)
            headStr = Value
        End Set
    End Property

    Property FootControl() As String
        Get
            Dim s As String = footStr
            If s Is Nothing Then
                Return String.Empty
            Else
                Return s
            End If
        End Get

        Set(ByVal Value As String)
            footStr = Value
        End Set
    End Property

    Property dsByDataTable() As Boolean
        Get
            Return DtOrGv
        End Get

        Set(ByVal Value As Boolean)
            DtOrGv = Value
        End Set
    End Property

    Property isAllGridView() As Boolean
        Get
            Return isAllGv
        End Get

        Set(ByVal Value As Boolean)
            isAllGv = Value
        End Set
    End Property

    Property WordVisible() As Boolean
        Get
            Return btWordVisible
        End Get

        Set(ByVal Value As Boolean)
            btWordVisible = Value
        End Set
    End Property

    Property ExcelVisible() As Boolean
        Get
            Return btExcelVisible
        End Get

        Set(ByVal Value As Boolean)
            btExcelVisible = Value
        End Set
    End Property

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

    Property WordBtName() As String
        Get
            Dim s As String = btWordName
            If s Is Nothing Then
                Return String.Empty
            Else
                Return s
            End If
        End Get

        Set(ByVal Value As String)
            btWordName = Value
        End Set
    End Property

    Property ExcelBtName() As String
        Get
            Dim s As String = btExcelName
            If s Is Nothing Then
                Return String.Empty
            Else
                Return s
            End If
        End Get

        Set(ByVal Value As String)
            btExcelName = Value
        End Set
    End Property

    Property WordName() As String
        Get
            Dim s As String = wordFileName
            If s Is Nothing Then
                Return String.Empty
            Else
                Return s
            End If
        End Get

        Set(ByVal Value As String)
            wordFileName = Value
        End Set
    End Property

    Property ExcelName() As String
        Get
            Dim s As String = excelFileName
            If s Is Nothing Then
                Return String.Empty
            Else
                Return s
            End If
        End Get

        Set(ByVal Value As String)
            excelFileName = Value
        End Set
    End Property

#End Region

    Protected Sub btWord_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btWord.Click
        GetOtherText()
        If DtOrGv Then
            Dim dt As DataTable = CType(ViewState(sGridName), DataTable)
            DTReport.PrintReport(dt, DTReport.ExportFileType.MS_Word, wordFileName, titleStr, headStr, footStr)
        Else
            Dim myGridView As GridView = CType(GetObject(Page, sGridName), GridView)
            If Not myGridView Is Nothing Then

                If isAllGv Then
                    Dim tmpGridView As GridView = New GridView()
                    Dim dt As DataTable = CType(ViewState(sGridName), DataTable)
                    tmpGridView.CopyBaseAttributes(myGridView)
                    For Each col As DataControlField In myGridView.Columns.CloneFields
                        tmpGridView.Columns.Add(col)
                    Next
                    tmpGridView.AutoGenerateColumns = False
                    tmpGridView.AllowPaging = False
                    tmpGridView.DataSource = dt
                    tmpGridView.DataBind()
                    DTReport.PrintGridView(tmpGridView, DTReport.ExportFileType.MS_Word, wordFileName, titleStr, headStr, footStr)
                Else
                    DTReport.PrintGridView(myGridView, DTReport.ExportFileType.MS_Word, wordFileName, titleStr, headStr, footStr)
                End If

            End If
        End If
    End Sub

    Protected Sub btExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btExcel.Click
        GetOtherText()
        If DtOrGv Then
            Dim dt As DataTable = CType(ViewState(sGridName), DataTable)
            DTReport.PrintReport(dt, DTReport.ExportFileType.MS_Excel, excelFileName, titleStr, headStr, footStr)
        Else
            Dim myGridView As GridView = CType(GetObject(Page, sGridName), GridView)
            If Not myGridView Is Nothing Then

                If isAllGv Then
                    Dim tmpGridView As GridView = New GridView()
                    Dim dt As DataTable = CType(ViewState(sGridName), DataTable)
                    tmpGridView.CopyBaseAttributes(myGridView)
                    For Each col As DataControlField In myGridView.Columns.CloneFields
                        tmpGridView.Columns.Add(col)
                    Next
                    tmpGridView.AutoGenerateColumns = False
                    tmpGridView.AllowPaging = False
                    tmpGridView.DataSource = dt
                    tmpGridView.DataBind()
                    DTReport.PrintGridView(tmpGridView, DTReport.ExportFileType.MS_Excel, excelFileName, titleStr, headStr, footStr)
                Else
                    DTReport.PrintGridView(myGridView, DTReport.ExportFileType.MS_Excel, excelFileName, titleStr, headStr, footStr)
                End If

            End If
        End If
    End Sub

    Protected Sub GetOtherText()
        If titleStr <> "" Then
            Dim hd As HiddenField = CType(GetObject(Page, titleStr), HiddenField)
            If Not hd Is Nothing Then
                titleStr = hd.Value
            End If
        End If

        If headStr <> "" Then
            Dim hd As HiddenField = CType(GetObject(Page, headStr), HiddenField)
            If Not hd Is Nothing Then
                headStr = hd.Value
            End If
        End If

        If footStr <> "" Then
            Dim hd As HiddenField = CType(GetObject(Page, footStr), HiddenField)
            If Not hd Is Nothing Then
                footStr = hd.Value
            End If
        End If
    End Sub

    Protected Function GetData() As DataTable
        Dim reValue As DataTable = Nothing
        If "" <> sGridName Then
            Dim myGridView As GridView = CType(GetObject(Page, sGridName), GridView)
            If Not myGridView Is Nothing Then
                Dim rCount As Integer = 0

                If Not myGridView.DataSource Is Nothing Then
                    Select Case myGridView.DataSource.GetType().ToString
                        Case "System.Data.DataTable"
                            reValue = CType(myGridView.DataSource, DataTable)
                        Case "System.Data.DataSet"
                            reValue = CType(myGridView.DataSource, DataSet).Tables(0)
                    End Select
                ElseIf Not myGridView.DataSourceID Is Nothing And "" <> myGridView.DataSourceID Then
                    Dim obj As Object = GetObject(Page, myGridView.DataSourceID)
                    If Not obj Is Nothing Then
                        Select Case obj.ToString()
                            Case "System.Web.UI.WebControls.SqlDataSource"
                                reValue = CType(CType(obj, SqlDataSource).Select(New DataSourceSelectArguments()), DataView).Table
                            Case "System.Web.UI.WebControls.ObjDataSource"
                                reValue = CType(myGridView.DataSource, DataSet).Tables(0)
                        End Select
                    End If
                End If
            End If
        End If
        Return reValue
    End Function

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            Me.btExcel.Text = btExcelName
            Me.btWord.Text = btWordName
            Me.btnExcel.Text = btExcelName
            Me.btnWord.Text = btWordName

            Select Case btnType
                Case "1"
                    Me.btWord.Visible = btWordVisible
                    Me.btExcel.Visible = btExcelVisible
                Case "2"
                    Me.btnWord.Visible = btWordVisible
                    Me.btnExcel.Visible = btExcelVisible
            End Select

        End If
    End Sub

    Protected Sub GridViewInfo()

        If "" <> sGridName Then
            Dim myGridView As GridView = CType(GetObject(Page, sGridName), GridView)
            If Not myGridView Is Nothing Then
                If Not myGridView.DataSource Is Nothing Then
                    Select Case myGridView.DataSource.GetType().ToString
                        Case "System.Data.DataTable"
                            ViewState(sGridName) = CType(myGridView.DataSource, DataTable)
                        Case "System.Data.DataSet"
                            ViewState(sGridName) = CType(myGridView.DataSource, DataSet).Tables(0)
                        Case Else
                            ViewState(sGridName) = Nothing
                    End Select
                ElseIf Not myGridView.DataSourceID Is Nothing And "" <> myGridView.DataSourceID Then
                    Dim obj As Object = GetObject(Page, myGridView.DataSourceID)
                    If Not obj Is Nothing Then
                        Select Case obj.ToString()
                            Case "System.Web.UI.WebControls.SqlDataSource"
                                ViewState(sGridName) = CType(CType(obj, SqlDataSource).Select(New DataSourceSelectArguments()), DataView).Table
                            Case "System.Web.UI.WebControls.ObjDataSource"
                                ViewState(sGridName) = CType(myGridView.DataSource, DataSet).Tables(0)
                            Case Else
                                ViewState(sGridName) = Nothing
                        End Select
                    Else
                        ViewState(sGridName) = Nothing
                    End If
                Else
                    ViewState(sGridName) = Nothing
                End If
            Else
                ViewState(sGridName) = Nothing
            End If
        End If


    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        GridViewInfo()
    End Sub

    Protected Sub btnWord_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnWord.Click
        Dim myGridView As GridView = CType(GetObject(Page, sGridName), GridView)
        'myGridView.AllowPaging = False
        'myGridView.AllowSorting = False
        'myGridView.DataSource = ViewState(sGridName)
        'myGridView.DataBind()
        Session.Add(sGridName, myGridView)
        Me.Response.Redirect("../../Common/Report.aspx?GridView=" + sGridName + "&FileType=doc&FileName=" + wordFileName)
    End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim myGridView As GridView = CType(GetObject(Page, sGridName), GridView)
        'myGridView.AllowPaging = False
        'myGridView.AllowSorting = False
        'myGridView.DataSource = ViewState(sGridName)
        'myGridView.DataBind()
        Session.Add(sGridName, myGridView)
        Me.Response.Redirect("../../Common/Report.aspx?GridView=" + sGridName + "&FileType=xls&FileName=" + excelFileName)
    End Sub

    'Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As System.Web.UI.Control)
    '    '必須有此方法，否則RenderControl()方法會出錯
    'End Sub

End Class
