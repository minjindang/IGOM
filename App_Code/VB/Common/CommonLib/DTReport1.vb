'==========================================================================================================
'#建立日期：2007/7/19

'#類別功能：
'CommonLib下的DTReport:轉換DataTable,以供匯出

'#與其它類別關聯：
' 無

'#修正記錄：
' 無


'分大組(PageGroup)
'使用DataTable：Tables(0)
'特殊參數 'PageGroupSerialNum：1~N  PageGroupSerialChiNum：一~N
'   Tables(1)~Tables(N)各做一次
'       Table的3種變化
'       一般
'           Table合計 / Table內部分小組合計 
'       合併(成一列-單欄)
'           Table合計 / Table內部分小組合計
'       轉向(成一列-多欄)
'           Table合計 / Table內部分小組合計
'       RowSpan(不影響列)
'           Table合計 / Table內部分小組合計
'
'Table合計:          每個Table底部加上小計(TableSumFields)，最後一個Table底部加上總計(ShowTablesTotal)
'Table內部分小組合計:每個小組的後一列加上小計(TableGroupSumFields)，Table底部加上總計(ShowTableTotal)
'
'
'Table內部分小組合計:
'TableSumKeys：在一個Table內，可依據區分成多組小計的Keys
'TableSumFields()：'可以隨便填，若有Match再顯示


'===========================================================================================================
Imports Microsoft.VisualBasic
Imports System.Web
Imports System.Web.HttpServerUtility
Imports System.Data
Imports CommonLib.StringFunc
Imports CommonLib.DataTableFunc
Imports System
Imports System.Configuration
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports System.Diagnostics
Imports System.Web.HttpContext
Imports Microsoft.Office.Interop
Imports System.Collections
Imports System.Text

Namespace CommonLib

#Region " DTReport類別"

    Public Class DTReport1

        Public Enum TableChangeMode
            NoChangeTable
            CombineTable
            RedirTable
            RowSpanTable
        End Enum

        Public Enum ExportFileType
            MS_Word = 1
            MS_Excel = 2
            MS_Txt = 3
        End Enum

#Region " Field "


        Private _FilePath As String      '樣板檔路徑
        Private _theDataTable As DataTable
        Private _ContextString As String    '組好的HTML文字
        '
        Private _IsOneRowOnePage As Boolean
        Private _IsDoPageGroup As Boolean
        'DataTable做改變
        Private _TableChangeMode As TableChangeMode

        Public _GroupPageArys As String()
        Public Property GroupPageArys() As String()
            Get
                Return _GroupPageArys
            End Get
            Set(ByVal Value As String())
                _GroupPageArys = Value
            End Set
        End Property

#End Region

#Region " Property "

        '樣板檔編碼
        Private _ExportFileCode As System.Text.Encoding
        Public Property ExportFileCode() As System.Text.Encoding
            Get
                Return _ExportFileCode
            End Get
            Set(ByVal Value As System.Text.Encoding)
                _ExportFileCode = Value
            End Set
        End Property

        '輸出後的檔名
        Private _ExportFileName As String
        Public Property ExportFileName() As String
            Get
                Return _ExportFileName
            End Get
            Set(ByVal Value As String)
                _ExportFileName = Value
            End Set
        End Property

        '結果改成多行顯示
        Private _MultiColumnCount As Integer
        Public Property MultiColumnCount() As Integer
            Get
                Return _MultiColumnCount
            End Get
            Set(ByVal Value As Integer)
                _MultiColumnCount = Value
            End Set
        End Property

        '不重複的參數陣列 
        Private _Param() As String

        Public Property Param() As String()
            Get
                Return _Param
            End Get
            Set(ByVal Value As String())
                _Param = Value
            End Set
        End Property

        '依據哪一個db欄位，來決定分頁
        Private _breakPage As String

        Public Property breakPage() As String
            Get
                Return _breakPage
            End Get
            Set(ByVal Value As String)
                _breakPage = Value
            End Set
        End Property

        '由哪些欄位組成PageGroupKey欄位
        Private _PageGroupKeyColumns() As String
        Public Property PageGroupKeyColumns() As String()
            Get
                Return _PageGroupKeyColumns
            End Get

            Set(ByVal Value As String())
                '_theDataTable在初使化時就會有
                Dim intAryFlag As Integer
                For intAryFlag = 0 To Value.Length - 1
                    If (_theDataTable.Columns.IndexOf(Value(intAryFlag)) = -1) Then
                        Throw New Exception(Value(intAryFlag) & "不存在於目前table")
                    End If
                Next

                _PageGroupKeyColumns = Value

            End Set
        End Property

        '由哪些欄位組成PageGroup欄位
        Private _PageGroupColumns() As String
        Public Property PageGroupColumns() As String()
            Get
                Return _PageGroupColumns
            End Get

            Set(ByVal Value As String())
                '_theDataTable在初使化時就會有
                Dim intAryFlag As Integer
                For intAryFlag = 0 To Value.Length - 1
                    If (_theDataTable.Columns.IndexOf(Value(intAryFlag)) = -1) Then
                        Throw New Exception(Value(intAryFlag) & "不存在於目前table")
                    End If
                Next

                _PageGroupColumns = Value

            End Set
        End Property

        '由哪些欄位組成Key欄位
        Private _KeyColumns() As String
        Public Property KeyColumns() As String()
            Get
                Return _KeyColumns
            End Get

            Set(ByVal Value As String())
                '_theDataTable在初使化時就會有
                Dim intAryFlag As Integer
                For intAryFlag = 0 To Value.Length - 1
                    If (_theDataTable.Columns.IndexOf(Value(intAryFlag)) = -1) Then
                        Throw New Exception(Value(intAryFlag) & "不存在於目前table")
                    End If
                Next

                _KeyColumns = Value

            End Set
        End Property

        '由哪些欄位組成Combine欄位
        Private _CombinColumns() As String
        Public Property CombinColumns() As String()
            Get
                Return _CombinColumns
            End Get

            Set(ByVal Value As String())
                '_theDataTable在初使化時就會有
                Dim intAryFlag As Integer
                For intAryFlag = 0 To Value.Length - 1
                    If (_theDataTable.Columns.IndexOf(Value(intAryFlag)) = -1) Then
                        Throw New Exception(Value(intAryFlag) & "不存在於目前table")
                    End If
                Next

                _CombinColumns = Value

            End Set
        End Property

        'Combine的符號
        Private _CombinSymbol As Char
        Public Property CombinSymbol() As Char
            Get
                Return _CombinSymbol
            End Get

            Set(ByVal Value As Char)
                _CombinSymbol = Value
            End Set
        End Property

        '由哪些欄位組成Redirect欄位
        Private _RedirColumn As String
        Public Property RedirColumn() As String
            Get
                Return _RedirColumn
            End Get

            Set(ByVal Value As String)
                '_theDataTable在初使化時就會有
                If (_theDataTable.Columns.IndexOf(Value) = -1) Then
                    Throw New Exception(Value & "不存在於目前table")
                End If

                _RedirColumn = Value

            End Set
        End Property

        'Redirect後各新欄位的值
        Private _RedirNewColValue() As String
        Public Property RedirNewColValue() As String()
            Get
                Return _RedirNewColValue
            End Get

            Set(ByVal Value As String())
                _RedirNewColValue = Value
            End Set
        End Property


        'Redir的符號
        Private _RedirSymbol As Char
        Public Property RedirSymbol() As Char
            Get
                Return _RedirSymbol
            End Get

            Set(ByVal Value As Char)
                _RedirSymbol = Value
            End Set
        End Property

        '由哪些欄位組成RowSpan欄位
        Private _RowSpanColumns() As String
        Public Property RowSpanColumns() As String()
            Get
                Return _RowSpanColumns
            End Get
            Set(ByVal Value As String())
                '_theDataTable在初使化時就會有
                Dim intAryFlag As Integer
                For intAryFlag = 0 To Value.Length - 1
                    If (_theDataTable.Columns.IndexOf(Value(intAryFlag)) = -1) Then
                        Throw New Exception(Value(intAryFlag) & "不存在於目前table")
                    End If
                Next

                _RowSpanColumns = Value

            End Set
        End Property

#End Region

#Region " Constructor "

        Public Sub New(ByVal theFilePath As String, ByVal theDataTable As DataTable)
            '帶預設值
            _ExportFileCode = System.Text.Encoding.Default
            _ExportFileName = "ExportToFile"
            _MultiColumnCount = 1
            '傳入值
            _FilePath = theFilePath
            _theDataTable = theDataTable
        End Sub

#End Region

#Region " Methods "

        Private Sub Initial()

            If _MultiColumnCount < 2 Then '若大於2則只有"參數"有效
                '做分組
                If (_PageGroupKeyColumns IsNot Nothing) AndAlso (_PageGroupKeyColumns.Length > 0) AndAlso (_PageGroupColumns IsNot Nothing) AndAlso (_PageGroupColumns.Length > 0) Then
                    _IsDoPageGroup = True
                Else
                    _PageGroupKeyColumns = Nothing
                    _PageGroupColumns = Nothing
                End If

                '最前面優先權是最後
                If (_KeyColumns IsNot Nothing) AndAlso (_KeyColumns.Length > 0) Then

                    '做RowSpan
                    If (_RowSpanColumns IsNot Nothing) AndAlso (_RowSpanColumns.Length > 0) Then
                        _TableChangeMode = TableChangeMode.RowSpanTable
                    End If

                    '做轉向
                    If (_RedirColumn IsNot Nothing) AndAlso (_RedirColumn <> String.Empty) Then
                        If (_RedirNewColValue IsNot Nothing) AndAlso (_RedirNewColValue.Length > 0) Then
                            If (_RedirSymbol <> String.Empty) Then
                                _TableChangeMode = TableChangeMode.RedirTable
                            End If
                        End If

                    End If

                    '做合併
                    If (_CombinColumns IsNot Nothing) AndAlso (_CombinColumns.Length > 0) Then
                        If (_CombinSymbol <> String.Empty) Then
                            _TableChangeMode = TableChangeMode.CombineTable
                        End If
                    End If

                End If

            End If

        End Sub

        Protected Sub ConsistHTMLCode()

            Initial()

            If _theDataTable.Rows.Count = 0 Then
                _ContextString = ""
                Exit Sub
            End If
            '
            Dim strPageRepeatSCode As String = "<PageRepeatArea>"
            Dim strPageRepeatECode As String = "</PageRepeatArea>"
            Dim strRepeatSCode As String = "<RepeatArea>"
            Dim strRepeatECode As String = "</RepeatArea>"
            '
            Dim strTempHeadFoot As String
            Dim strTempPageRepeatArea As String
            Dim strTempPageRepeatArea_byBreakPage As New StringBuilder()
            Dim strTempRepeatArea As String
            Dim strPageSep As String = "<br clear=3Dall style=3D'page-break-before:always'>" '分頁碼(有分頁時才用得到)

            ' 把文件導至正確的位置，而不使用系統預設的路徑
            Dim oSR As New System.IO.StreamReader(_FilePath, _ExportFileCode)
            'Dim oSR As New System.IO.StreamReader(Current.Server.MapPath(Current.Request.ApplicationPath & "/" & _FilePath), _ExportFileCode)
            Dim strTMP As String = oSR.ReadToEnd()
            oSR.Close()
            oSR.Dispose()
            Dim headerSampleStr As String = ""
            '--------------------------------------------------------------------------
            '先置換不重複的參數,
            '目的在於:
            '1.有些參數被包含在RepeatArea內(EM3010信的內容)
            '2.mht檔中,PageRepeatArea沒涵蓋到 ##P##
            '--------------------------------------------------------------------------
            If (_Param IsNot Nothing) AndAlso (_Param.Length > 0) Then
                Dim intParamFlag As Integer
                For intParamFlag = 0 To _Param.Length - 1
                    If (intParamFlag <> 2) Then 'P3為頁碼，本處需保留先不替換 post by kensin wu 20140116
                        strTMP = strTMP.Replace("##P" & intParamFlag + 1 & "##", (GetCharCodes(_Param(intParamFlag))))

                    End If
                Next
            End If

            Try
                '含<PageRepeatArea></PageRepeatArea>
                strTempHeadFoot = strTMP.Remove(strTMP.IndexOf(strPageRepeatSCode) + (strPageRepeatSCode).Length, (strTMP.IndexOf(strPageRepeatECode) - strTMP.IndexOf(strPageRepeatSCode) - (strPageRepeatSCode).Length))

                '不含<PageRepeatArea></PageRepeatArea>,但含<RepeatArea></RepeatArea>
              
                strTempPageRepeatArea = strTMP.Substring(strTMP.IndexOf(strPageRepeatSCode) + (strPageRepeatSCode).Length, (strTMP.IndexOf(strPageRepeatECode) - strTMP.IndexOf(strPageRepeatSCode) - (strPageRepeatSCode).Length))
                strTempPageRepeatArea = strTempPageRepeatArea.Remove(strTempPageRepeatArea.IndexOf(strRepeatSCode) + (strRepeatSCode).Length, (strTempPageRepeatArea.IndexOf(strRepeatECode) - strTempPageRepeatArea.IndexOf(strRepeatSCode) - (strRepeatSCode).Length))

               
                If strTempPageRepeatArea.Trim = strRepeatSCode & strRepeatECode Then
                    '當strTempPageRepeatArea等於<RepeatArea></RepeatArea>
                    '表示是信件式,所以每個Row就要分頁一次
                    _IsOneRowOnePage = True
                End If

                '不含<RepeatArea></RepeatArea>
                strTempRepeatArea = strTMP.Substring(strTMP.IndexOf(strRepeatSCode) + (strRepeatSCode).Length, (strTMP.IndexOf(strRepeatECode) - strTMP.IndexOf(strRepeatSCode) - (strRepeatSCode).Length))


            Catch ex As Exception
                Throw New Exception("樣版檔的標記讀取出錯")
            End Try

            If _FilePath.EndsWith(".mht") Then
                strPageSep = "<br clear=3Dall style=3D'page-break-before:always'>"
            End If

            '先宣告好陣列,等一下依序存放
            Dim theReplacedPageRepeatArea As New ArrayList '每一個項目代表一份PageRepeatArea
            Dim theReplacedRepeatArea As New ArrayList '每一個項目代表一份RepeatArea

            Dim intAryFlag As Integer
            '----------------------------------------------以上是前置工作--------------------------------------------------

            '回傳一個ArrayList(多個項目 or 一個空字串的項目)
            Dim thePageGroupFilterItems As ArrayList = ConsistFilterItems(_theDataTable, _PageGroupColumns)

            'Dim thePageRepeatArea As String
            'Dim theRepeatArea As String
            Dim thePageRepeatArea As New StringBuilder
            Dim theRepeatArea As New StringBuilder
            Dim theRepeatArea_byBreakPage As New StringBuilder
            'Dim strbuf As New StringBuilder
            '一次迴圈一份PageRepeatArea (幾組就會跑幾次迴圈,不分組就跑一次)
            Dim strBreakPage As String = ""


            For intAryFlag = 0 To thePageGroupFilterItems.Count - 1



                Dim intRowFlag As Integer
                Dim intColFlag As Integer
                'thePageRepeatArea=strTempPageRepeatArea  '新筆數要從新取一次
                thePageRepeatArea.Remove(0, thePageRepeatArea.Length)

                thePageRepeatArea.AppendLine(strTempPageRepeatArea) '新筆數要從新取一次
                Dim theRows() As DataRow = _theDataTable.Select(thePageGroupFilterItems.Item(intAryFlag))

                If theRows.Length <= 0 Then
                    Exit For
                End If

                Select Case _TableChangeMode

                    Case TableChangeMode.CombineTable '合併
                        Dim theNewTable As DataTable = _theDataTable.Clone

                        For i As Integer = 0 To theRows.Length - 1
                            theNewTable.Rows.Add(theRows(i).ItemArray)
                        Next

                        theNewTable = DataTableComBinCols(theNewTable, _KeyColumns, _CombinColumns, _CombinSymbol)
                        theRows = theNewTable.Select

                    Case TableChangeMode.RedirTable '轉向
                        Dim theNewTable As DataTable = _theDataTable.Clone

                        For i As Integer = 0 To theRows.Length - 1
                            theNewTable.Rows.Add(theRows(i).ItemArray)
                        Next

                        theNewTable = DataTableRedirCol(theNewTable, _KeyColumns, _RedirColumn, _RedirNewColValue, _RedirSymbol)
                        theRows = theNewTable.Select

                End Select

                If _TableChangeMode <> TableChangeMode.RowSpanTable Then

                    '沒有RowSpan時

                    
                    For intRowFlag = 0 To theRows.Length - 1 '一筆Rows就做一份RepeatArea
                        'theRepeatArea=strTempRepeatArea '新筆數要從新取一次
                        theRepeatArea = theRepeatArea.Remove(0, theRepeatArea.Length)

                        theRepeatArea.AppendLine(strTempRepeatArea) '新筆數要從新取一次
                        '==============================================
                        '若有分組且是第一列,則置換PageRepeatArea的變數
                        '----------------------------------------------
                        If (_IsDoPageGroup = True) And (intRowFlag = 0) Then
                            For intColFlag = 0 To _PageGroupColumns.Length - 1
                                '若要輸出的表單中有這樣的欄位則替換
                                Try
                                    If theRows(intRowFlag).Item(_PageGroupColumns(intColFlag)) IsNot Nothing Then

                                        If IsDBNull(theRows(intRowFlag).Item(_PageGroupColumns(intColFlag))) Then
                                            thePageRepeatArea = thePageRepeatArea.Replace("##" & _PageGroupColumns(intColFlag) & "##", "")

                                        Else
                                            thePageRepeatArea = thePageRepeatArea.Replace("##" & _PageGroupColumns(intColFlag) & "##", GetCharCodes(theRows(intRowFlag).Item(_PageGroupColumns(intColFlag))))
                                        End If
                                    End If

                                Catch ex As Exception

                                End Try
                            Next
                        End If


                        '=============================================
                        '每一列,都要置換RepeatArea的變數
                        '---------------------------------------------

                        '因為若使用轉向,則欄位名稱會變
                        For intColFlag = 0 To theRows(intRowFlag).Table.Columns.Count - 1 'For Each theColumn As DataColumn In _theDataTable.Columns
                            '若要輸出的表單中有這樣的欄位則替換
                            If theRows(intRowFlag).Item(intColFlag) IsNot Nothing Then
                                Try

                                    If IsDBNull(theRows(intRowFlag).Item(intColFlag)) Then
                                        theRepeatArea = theRepeatArea.Replace("##" & theRows(intRowFlag).Table.Columns(intColFlag).ColumnName & "##", "")
                                    Else
                                        theRepeatArea = theRepeatArea.Replace("##" & theRows(intRowFlag).Table.Columns(intColFlag).ColumnName & "##", GetCharCodes(theRows(intRowFlag).Item(intColFlag)))
                                    End If
                                Catch ex As Exception

                                End Try
                            End If

                        Next

                        '一筆一筆加進去
                        '當是信件式時,一個Row代表一頁
                        If _IsOneRowOnePage Then
                            If intRowFlag < (theRows.Length - 1) Then '不是最後一筆要加上分頁符號
                                'theRepeatArea = theRepeatArea & strPageSep
                                theRepeatArea.AppendLine(strPageSep)
                            End If
                        End If
                        If _breakPage <> "" Then '有設定依哪一個欄位做分頁的設定

                            If (strBreakPage <> "" And strBreakPage <> theRows(intRowFlag).Item(_breakPage).ToString) Then

                                'thePageRepeatArea為暫存 => <PageRepeatArea>資料<RepeatArea></RepeatArea>資料</PageRepeatArea>

                                strTempPageRepeatArea_byBreakPage.AppendLine(thePageRepeatArea.ToString)
                                strTempPageRepeatArea_byBreakPage.Replace(strRepeatSCode & strRepeatECode, theRepeatArea_byBreakPage.ToString) '將<RepeatArea></RepeatArea>的註記取代成內容

                                If intRowFlag < (theRows.Length - 1) Then '不是最後一筆要加上分頁符號
                                    strTempPageRepeatArea_byBreakPage = strTempPageRepeatArea_byBreakPage.Replace("##P3##", (theRows(intRowFlag).Item(_breakPage) - 1).ToString)
                                    theReplacedRepeatArea.Add(strTempPageRepeatArea_byBreakPage.ToString & strPageSep) '將資料加入至theReplacedRepeatArea + 插入分頁符號
                                Else

                                    theReplacedRepeatArea.Add(strTempPageRepeatArea_byBreakPage.ToString) '將資料加入至theReplacedRepeatArea 
                                End If

                                strBreakPage = theRows(intRowFlag).Item(_breakPage).ToString '記錄目前的欄位資料

                                theRepeatArea_byBreakPage.Remove(0, theRepeatArea_byBreakPage.Length)
                                theRepeatArea_byBreakPage.AppendLine(theRepeatArea.ToString)

                                strTempPageRepeatArea_byBreakPage.Remove(0, strTempPageRepeatArea_byBreakPage.Length)
                                theRepeatArea.Remove(0, theRepeatArea.Length)

                            ElseIf (intRowFlag = theRows.Length - 1) Then
                                If strBreakPage = theRows(intRowFlag).Item(_breakPage).ToString Then
                                    theRepeatArea_byBreakPage.AppendLine(theRepeatArea.ToString)  '將一列的類料整合至群組資料裡
                                    theRepeatArea.Remove(0, theRepeatArea.Length)
                                End If
                                If theRepeatArea_byBreakPage.Length > 0 Then
                                    'thePageRepeatArea為暫存 => <PageRepeatArea>資料<RepeatArea></RepeatArea>資料</PageRepeatArea>

                                    strTempPageRepeatArea_byBreakPage.AppendLine(thePageRepeatArea.ToString)
                                    strTempPageRepeatArea_byBreakPage.Replace(strRepeatSCode & strRepeatECode, theRepeatArea_byBreakPage.ToString) '將<RepeatArea></RepeatArea>的註記取代成內容

                                    theReplacedRepeatArea.Add(strTempPageRepeatArea_byBreakPage.ToString) '將資料加入至theReplacedRepeatArea  
                                    theRepeatArea_byBreakPage.Remove(0, theRepeatArea_byBreakPage.Length)
                                End If
                                If theRepeatArea.Length > 0 Then
                                    'thePageRepeatArea為暫存 => <PageRepeatArea>資料<RepeatArea></RepeatArea>資料</PageRepeatArea>
                                    strTempPageRepeatArea_byBreakPage.Replace(strRepeatSCode & strRepeatECode, theRepeatArea.ToString) '將<RepeatArea></RepeatArea>的註記取代成內容

                                    theReplacedRepeatArea.Add(strTempPageRepeatArea_byBreakPage.ToString) '將資料加入至theReplacedRepeatArea 

                                    theRepeatArea.Remove(0, theRepeatArea.Length)
                                End If

                            ElseIf strBreakPage = "" Then
                                theReplacedRepeatArea.Add(strTempPageRepeatArea_byBreakPage.ToString)
                                strBreakPage = theRows(intRowFlag).Item(_breakPage).ToString
                                theRepeatArea_byBreakPage.AppendLine(theRepeatArea.ToString)
                            Else
                                theRepeatArea_byBreakPage.AppendLine(theRepeatArea.ToString)
                            End If
                        Else

                            theReplacedRepeatArea.Add(theRepeatArea.ToString)

                        End If


                        If Not _GroupPageArys Is Nothing Then
                            If _GroupPageArys.Length > 0 Then
                                If Convert.ToString(intRowFlag) = _GroupPageArys(1) Then
                                    thePageRepeatArea.Replace("##" + _GroupPageArys(0) + "##", GetCharCodes(theRows(intRowFlag).Item(_GroupPageArys(2)) + _GroupPageArys(3)))
                                End If
                            End If
                        End If
                    Next

                    '-----------------------------------------------------------------
                    '(已經置換過PageRepeatArea變數)的thePageRepeatArea再置換其RepeatArea變數
                    '-----------------------------------------------------------------
                    If _breakPage <> "" Then '有設定依哪一個欄位做分頁的設定
                        Dim tmp As New StringBuilder
                        thePageRepeatArea.Remove(0, thePageRepeatArea.ToString.Length)
                        '' 資料<PageRepeatArea><RepeatArea></RepeatArea></PageRepeatArea>資料
                        '' 資料<RepeatArea></RepeatArea>資料


                        thePageRepeatArea.AppendLine(strTMP.Substring(0, strTMP.IndexOf(strPageRepeatSCode) - 1) & strRepeatSCode & strRepeatECode & strTMP.Substring(strTMP.IndexOf(strPageRepeatECode) + strPageRepeatECode.Length))

                       
                    End If
                    thePageRepeatArea = thePageRepeatArea.Replace(strRepeatSCode & strRepeatECode, String.Concat(theReplacedRepeatArea.ToArray))

                    theReplacedRepeatArea.Clear() '用完要清,避免換到下一群組的時候有殘留
                Else

                    '做RowSpan時

                    '==============================================
                    '置換PageRepeatArea的變數
                    '----------------------------------------------
                    If (_IsDoPageGroup = True) Then
                        For intColFlag = 0 To _PageGroupColumns.Length - 1
                            If IsDBNull(theRows(0).Item(_PageGroupColumns(intColFlag))) Then
                                thePageRepeatArea = thePageRepeatArea.Replace("##" & _PageGroupColumns(intColFlag) & "##", "")
                            Else
                                thePageRepeatArea = thePageRepeatArea.Replace("##" & _PageGroupColumns(intColFlag) & "##", GetCharCodes(theRows(0).Item(_PageGroupColumns(intColFlag))))
                            End If
                        Next
                    End If

                    '把theRows轉成一個Table(資料列只有theRows)
                    Dim theNewTable As DataTable = _theDataTable.Clone
                    For i As Integer = 0 To theRows.Length - 1
                        theNewTable.Rows.Add(theRows(i).ItemArray)
                    Next
                    theRepeatArea.Remove(0, theRepeatArea.Length)
                    Dim temptheRepeatArea = strTempRepeatArea
                    'theRepeatArea=strTempRepeatArea 
                    'theRepeatArea = DataTableRowSpanCols(theNewTable, _KeyColumns, _RowSpanColumns, theRepeatArea)

                    theRepeatArea.AppendLine(DataTableRowSpanCols(theNewTable, _KeyColumns, _RowSpanColumns, temptheRepeatArea))
                    thePageRepeatArea = thePageRepeatArea.Replace(strRepeatSCode & strRepeatECode, theRepeatArea.ToString)
                End If

                '-------------------------------------
                '處理分頁:有PageGroup時在這裡處理分頁
                '表格式原則上不分頁,分頁時機:有PageGroup時
                '信件式每個Row就要分頁一次
                '-------------------------------------
                If (_IsDoPageGroup = True) And intAryFlag <> (thePageGroupFilterItems.Count - 1) Then
                    '有分組並且不是最後一筆:加上分頁符號

                    theReplacedPageRepeatArea.Add(thePageRepeatArea.ToString & strPageSep)
                Else
                    theReplacedPageRepeatArea.Add(thePageRepeatArea.ToString)
                End If


                'If _MultiColumnCount > 1 Then
                '    '放進Table
                '    If ((intAryFlag + 1) Mod _MultiColumnCount = 0) Then
                '        '該列最後一個TD
                '        strTempPageRepeatArea = "<TD>" & strTempPageRepeatArea & "</TD></TR>"
                '    ElseIf ((intAryFlag + 1) Mod _MultiColumnCount = 1) Then
                '        '該列第一個TD
                '        strTempPageRepeatArea = "<TR><TD>" & strTempPageRepeatArea & "</TD>"
                '    ElseIf ((intAryFlag + 1) Mod _MultiColumnCount > 1) Then
                '        strTempPageRepeatArea = "<TD>" & strTempPageRepeatArea & "</TD>"
                '    End If
                'End If

            Next
            Try

                If _breakPage <> "" Then
                    strTMP = String.Concat(theReplacedPageRepeatArea.ToArray)
                Else
                    strTMP = strTempHeadFoot.Replace(strPageRepeatSCode & strPageRepeatECode, String.Concat(theReplacedPageRepeatArea.ToArray))
                End If
                '  strTMP = strTempHeadFoot.Replace(strPageRepeatSCode & strPageRepeatECode, String.Concat(theReplacedPageRepeatArea.ToArray))

            Catch ex As Exception

            End Try
            theReplacedPageRepeatArea.Clear()



            ''''''''''''''''''''''''''''''''''''''''''''若MultiColumnCount>1則下一份放隔壁
            ''---------------------------------------------------------------------------------
            ''_MultiColumnCount = 1時,IntPlus是0,否則算出需補上多少(intPlus)才能組成完整Table
            ''---------------------------------------------------------------------------------
            'Dim intPlus As Integer = 0

            'If _MultiColumnCount > 1 Then
            '    While (_theDataTable.Rows.Count + intPlus) Mod _MultiColumnCount <> 0
            '        intPlus += 1
            '    End While
            'End If

            'If _MultiColumnCount = 1 Then
            '    strTempPageRepeatArea = strTempPageRepeatArea '不放進Table
            'Else
            '    '放進Table
            '    strTempPageRepeatArea = "<TABLE border=0 cellspacing=0 cellpadding=0>" & strTempPageRepeatArea & "</TABLE>"
            'End If
            'Dim theRows2() As DataRow = _theDataTable.Select(thePageGroupFilterItems.Item(0))
            'strTMP = strTMP.Replace("##P3##", theRows2(theRows2.Length - 1).Item(_breakPage).ToString)
            _ContextString = strTMP


        End Sub

        Protected Sub ConsistHTMLCode(ByVal theFileType As ExportFileType)

            Initial()

            If _theDataTable.Rows.Count = 0 Then
                _ContextString = ""
                Exit Sub
            End If
            '
            Dim strPageRepeatSCode As String = "<PageRepeatArea>"
            Dim strPageRepeatECode As String = "</PageRepeatArea>"
            Dim strRepeatSCode As String = "<RepeatArea>"
            Dim strRepeatECode As String = "</RepeatArea>"
            '
            Dim strTempHeadFoot As String
            Dim strTempPageRepeatArea As String
            Dim strTempPageRepeatArea_byBreakPage As New StringBuilder
            Dim strTempRepeatArea As String
            Dim strPageSep As String = "<br clear=3Dall style=3D'page-break-before:always'>" '分頁碼(有分頁時才用得到)
            If theFileType = ExportFileType.MS_Excel Then strPageSep = ""

            ' 把文件導至正確的位置，而不使用系統預設的路徑
            Dim oSR As New System.IO.StreamReader(_FilePath, _ExportFileCode)
            'Dim oSR As New System.IO.StreamReader(Current.Server.MapPath(Current.Request.ApplicationPath & "/" & _FilePath), _ExportFileCode)
            Dim strTMP As String = oSR.ReadToEnd()
            oSR.Close()
            oSR.Dispose()

            '--------------------------------------------------------------------------
            '先置換不重複的參數,
            '目的在於:
            '1.有些參數被包含在RepeatArea內(EM3010信的內容)
            '2.mht檔中,PageRepeatArea沒涵蓋到 ##P##
            '--------------------------------------------------------------------------
            If (_Param IsNot Nothing) AndAlso (_Param.Length > 0) Then
                Dim intParamFlag As Integer
                For intParamFlag = 0 To _Param.Length - 1
                    strTMP = strTMP.Replace("##P" & intParamFlag + 1 & "##", (GetCharCodes(_Param(intParamFlag))))
                Next
            End If

            Try
                '含<PageRepeatArea></PageRepeatArea>
                strTempHeadFoot = strTMP.Remove(strTMP.IndexOf(strPageRepeatSCode) + (strPageRepeatSCode).Length, (strTMP.IndexOf(strPageRepeatECode) - strTMP.IndexOf(strPageRepeatSCode) - (strPageRepeatSCode).Length))

                '不含<PageRepeatArea></PageRepeatArea>,但含<RepeatArea></RepeatArea>
                strTempPageRepeatArea = strTMP.Substring(strTMP.IndexOf(strPageRepeatSCode) + (strPageRepeatSCode).Length, (strTMP.IndexOf(strPageRepeatECode) - strTMP.IndexOf(strPageRepeatSCode) - (strPageRepeatSCode).Length))
                strTempPageRepeatArea = strTempPageRepeatArea.Remove(strTempPageRepeatArea.IndexOf(strRepeatSCode) + (strRepeatSCode).Length, (strTempPageRepeatArea.IndexOf(strRepeatECode) - strTempPageRepeatArea.IndexOf(strRepeatSCode) - (strRepeatSCode).Length))

                If strTempPageRepeatArea.Trim = strRepeatSCode & strRepeatECode Then
                    '當strTempPageRepeatArea等於<RepeatArea></RepeatArea>
                    '表示是信件式,所以每個Row就要分頁一次
                    _IsOneRowOnePage = True
                End If

                '不含<RepeatArea></RepeatArea>
                strTempRepeatArea = strTMP.Substring(strTMP.IndexOf(strRepeatSCode) + (strRepeatSCode).Length, (strTMP.IndexOf(strRepeatECode) - strTMP.IndexOf(strRepeatSCode) - (strRepeatSCode).Length))


            Catch ex As Exception
                Throw New Exception("樣版檔的標記讀取出錯")
            End Try

            If _FilePath.EndsWith(".mht") Then
                strPageSep = "<br clear=3Dall style=3D'page-break-before:always'>"
            End If

            '先宣告好陣列,等一下依序存放
            Dim theReplacedPageRepeatArea As New ArrayList '每一個項目代表一份PageRepeatArea
            Dim theReplacedRepeatArea As New ArrayList '每一個項目代表一份RepeatArea

            Dim intAryFlag As Integer
            '----------------------------------------------以上是前置工作--------------------------------------------------

            '回傳一個ArrayList(多個項目 or 一個空字串的項目)
            Dim thePageGroupFilterItems As ArrayList = ConsistFilterItems(_theDataTable, _PageGroupColumns)

            'Dim thePageRepeatArea As String
            'Dim theRepeatArea As String
            Dim thePageRepeatArea As New StringBuilder
            Dim theRepeatArea As New StringBuilder
            Dim theRepeatArea_byBreakPage As New StringBuilder
            'Dim strbuf As New StringBuilder
            '一次迴圈一份PageRepeatArea (幾組就會跑幾次迴圈,不分組就跑一次)
            Dim strBreakPage As String = ""
            For intAryFlag = 0 To thePageGroupFilterItems.Count - 1

                Dim intRowFlag As Integer
                Dim intColFlag As Integer
                'thePageRepeatArea=strTempPageRepeatArea  '新筆數要從新取一次
                thePageRepeatArea.Remove(0, thePageRepeatArea.Length)




                If intAryFlag = 0 Then
                    thePageRepeatArea.AppendLine(strTempPageRepeatArea) '新筆數要從新取一次
                Else
                    Dim str As String = Mid(strTempPageRepeatArea.ToString, strTempPageRepeatArea.ToString.IndexOf(">") + 2, strTempPageRepeatArea.ToString.Length)
                    thePageRepeatArea.AppendLine(Mid(strTempPageRepeatArea.ToString, strTempPageRepeatArea.ToString.IndexOf(">") + 2, strTempPageRepeatArea.ToString.Length)) '新筆數要從新取一次
                End If


                Dim theRows() As DataRow = _theDataTable.Select(thePageGroupFilterItems.Item(intAryFlag))

                If theRows.Length <= 0 Then
                    Exit For
                End If

                Select Case _TableChangeMode

                    Case TableChangeMode.CombineTable '合併
                        Dim theNewTable As DataTable = _theDataTable.Clone

                        For i As Integer = 0 To theRows.Length - 1
                            theNewTable.Rows.Add(theRows(i).ItemArray)
                        Next

                        theNewTable = DataTableComBinCols(theNewTable, _KeyColumns, _CombinColumns, _CombinSymbol)
                        theRows = theNewTable.Select

                    Case TableChangeMode.RedirTable '轉向
                        Dim theNewTable As DataTable = _theDataTable.Clone

                        For i As Integer = 0 To theRows.Length - 1
                            theNewTable.Rows.Add(theRows(i).ItemArray)
                        Next

                        theNewTable = DataTableRedirCol(theNewTable, _KeyColumns, _RedirColumn, _RedirNewColValue, _RedirSymbol)
                        theRows = theNewTable.Select

                End Select

                If _TableChangeMode <> TableChangeMode.RowSpanTable Then

                    '沒有RowSpan時

                    For intRowFlag = 0 To theRows.Length - 1 '一筆Rows就做一份RepeatArea
                        'theRepeatArea=strTempRepeatArea '新筆數要從新取一次
                        theRepeatArea = theRepeatArea.Remove(0, theRepeatArea.Length)

                        theRepeatArea.AppendLine(strTempRepeatArea) '新筆數要從新取一次
                        '==============================================
                        '若有分組且是第一列,則置換PageRepeatArea的變數
                        '----------------------------------------------
                        If (_IsDoPageGroup = True) And (intRowFlag = 0) Then
                            For intColFlag = 0 To _PageGroupColumns.Length - 1
                                '若要輸出的表單中有這樣的欄位則替換
                                Try

                                    If theRows(intRowFlag).Item(_PageGroupColumns(intColFlag)) IsNot Nothing Then
                                        If IsDBNull(theRows(intRowFlag).Item(_PageGroupColumns(intColFlag))) Then
                                            thePageRepeatArea = thePageRepeatArea.Replace("##" & _PageGroupColumns(intColFlag) & "##", "")
                                        Else
                                            thePageRepeatArea = thePageRepeatArea.Replace("##" & _PageGroupColumns(intColFlag) & "##", GetCharCodes(theRows(intRowFlag).Item(_PageGroupColumns(intColFlag))))


                                        End If

                                    End If
                                Catch ex As Exception

                                End Try
                            Next
                        End If
                        '=============================================
                        '每一列,都要置換RepeatArea的變數
                        '---------------------------------------------

                        '因為若使用轉向,則欄位名稱會變
                        For intColFlag = 0 To theRows(intRowFlag).Table.Columns.Count - 1 'For Each theColumn As DataColumn In _theDataTable.Columns
                            '若要輸出的表單中有這樣的欄位則替換
                            If theRows(intRowFlag).Item(intColFlag) IsNot Nothing Then
                                Try

                                    If IsDBNull(theRows(intRowFlag).Item(intColFlag)) Then
                                        theRepeatArea = theRepeatArea.Replace("##" & theRows(intRowFlag).Table.Columns(intColFlag).ColumnName & "##", "")
                                    Else
                                        theRepeatArea = theRepeatArea.Replace("##" & theRows(intRowFlag).Table.Columns(intColFlag).ColumnName & "##", GetCharCodes(theRows(intRowFlag).Item(intColFlag)))
                                    End If
                                Catch ex As Exception

                                End Try
                            End If

                        Next
                        '一筆一筆加進去
                        '當是信件式時,一個Row代表一頁
                        If _IsOneRowOnePage Then
                            If intRowFlag < (theRows.Length - 1) Then '不是最後一筆要加上分頁符號
                                'theRepeatArea = theRepeatArea & strPageSep
                                theRepeatArea.AppendLine(strPageSep)
                            End If
                        End If

                        If _breakPage <> "" Then '有設定依哪一個欄位做分頁的設定

                            If (strBreakPage <> "" And strBreakPage <> theRows(intRowFlag).Item(_breakPage).ToString) Then

                                'thePageRepeatArea為暫存 => <PageRepeatArea>資料<RepeatArea></RepeatArea>資料</PageRepeatArea>
                                strTempPageRepeatArea_byBreakPage.AppendLine(thePageRepeatArea.ToString)
                                strTempPageRepeatArea_byBreakPage.Replace(strRepeatSCode & strRepeatECode, theRepeatArea_byBreakPage.ToString) '將<RepeatArea></RepeatArea>的註記取代成內容

                                If intRowFlag < (theRows.Length - 1) Then '不是最後一筆要加上分頁符號
                                    theReplacedRepeatArea.Add(strTempPageRepeatArea_byBreakPage.ToString & strPageSep) '將資料加入至theReplacedRepeatArea + 插入分頁符號
                                Else
                                    theReplacedRepeatArea.Add(strTempPageRepeatArea_byBreakPage.ToString) '將資料加入至theReplacedRepeatArea 
                                End If

                                strBreakPage = theRows(intRowFlag).Item(_breakPage).ToString '記錄目前的欄位資料

                                theRepeatArea_byBreakPage.Remove(0, theRepeatArea_byBreakPage.Length)
                                theRepeatArea_byBreakPage.AppendLine(theRepeatArea.ToString)

                                strTempPageRepeatArea_byBreakPage.Remove(0, strTempPageRepeatArea_byBreakPage.Length)
                                theRepeatArea.Remove(0, theRepeatArea.Length)

                            ElseIf (intRowFlag = theRows.Length - 1) Then
                                If strBreakPage = theRows(intRowFlag).Item(_breakPage).ToString Then
                                    theRepeatArea_byBreakPage.AppendLine(theRepeatArea.ToString)  '將一列的類料整合至群組資料裡
                                    theRepeatArea.Remove(0, theRepeatArea.Length)
                                End If
                                If theRepeatArea_byBreakPage.Length > 0 Then
                                    'thePageRepeatArea為暫存 => <PageRepeatArea>資料<RepeatArea></RepeatArea>資料</PageRepeatArea>
                                    strTempPageRepeatArea_byBreakPage.AppendLine(thePageRepeatArea.ToString)
                                    strTempPageRepeatArea_byBreakPage.Replace(strRepeatSCode & strRepeatECode, theRepeatArea_byBreakPage.ToString) '將<RepeatArea></RepeatArea>的註記取代成內容

                                    theReplacedRepeatArea.Add(strTempPageRepeatArea_byBreakPage.ToString) '將資料加入至theReplacedRepeatArea  
                                    theRepeatArea_byBreakPage.Remove(0, theRepeatArea_byBreakPage.Length)
                                End If
                                If theRepeatArea.Length > 0 Then
                                    'thePageRepeatArea為暫存 => <PageRepeatArea>資料<RepeatArea></RepeatArea>資料</PageRepeatArea>
                                    strTempPageRepeatArea_byBreakPage.AppendLine(thePageRepeatArea.ToString)
                                    strTempPageRepeatArea_byBreakPage.Replace(strRepeatSCode & strRepeatECode, theRepeatArea.ToString) '將<RepeatArea></RepeatArea>的註記取代成內容

                                    theReplacedRepeatArea.Add(strTempPageRepeatArea_byBreakPage.ToString) '將資料加入至theReplacedRepeatArea 

                                    theRepeatArea.Remove(0, theRepeatArea.Length)
                                End If

                            ElseIf strBreakPage = "" Then
                                strBreakPage = theRows(intRowFlag).Item(_breakPage).ToString
                                theRepeatArea_byBreakPage.AppendLine(theRepeatArea.ToString)
                            Else
                                theRepeatArea_byBreakPage.AppendLine(theRepeatArea.ToString)
                            End If
                        Else

                            theReplacedRepeatArea.Add(theRepeatArea.ToString)

                        End If


                        If Not _GroupPageArys Is Nothing Then
                            If _GroupPageArys.Length > 0 Then
                                If Convert.ToString(intRowFlag) = _GroupPageArys(1) Then
                                    thePageRepeatArea.Replace("##" + _GroupPageArys(0) + "##", GetCharCodes(theRows(intRowFlag).Item(_GroupPageArys(2)) + _GroupPageArys(3)))
                                End If
                            End If
                        End If

                    Next

                    '-----------------------------------------------------------------
                    '(已經置換過PageRepeatArea變數)的thePageRepeatArea再置換其RepeatArea變數
                    '-----------------------------------------------------------------
                    If _breakPage <> "" Then '有設定依哪一個欄位做分頁的設定
                        Dim tmp As New StringBuilder
                        thePageRepeatArea.Remove(0, thePageRepeatArea.ToString.Length)
                        ' 資料<PageRepeatArea><RepeatArea></RepeatArea></PageRepeatArea>資料
                        ' 資料<RepeatArea></RepeatArea>資料
                        thePageRepeatArea.AppendLine(strTMP.Substring(0, strTMP.IndexOf(strPageRepeatSCode) - 1) & strRepeatSCode & strRepeatECode & strTMP.Substring(strTMP.IndexOf(strPageRepeatECode) + strPageRepeatECode.Length))
                    End If
                    thePageRepeatArea = thePageRepeatArea.Replace(strRepeatSCode & strRepeatECode, String.Concat(theReplacedRepeatArea.ToArray))
                    theReplacedRepeatArea.Clear() '用完要清,避免換到下一群組的時候有殘留
                Else

                    '做RowSpan時

                    '==============================================
                    '置換PageRepeatArea的變數
                    '----------------------------------------------
                    If (_IsDoPageGroup = True) Then
                        For intColFlag = 0 To _PageGroupColumns.Length - 1
                            If IsDBNull(theRows(0).Item(_PageGroupColumns(intColFlag))) Then
                                thePageRepeatArea = thePageRepeatArea.Replace("##" & _PageGroupColumns(intColFlag) & "##", "")
                            Else
                                thePageRepeatArea = thePageRepeatArea.Replace("##" & _PageGroupColumns(intColFlag) & "##", GetCharCodes(theRows(0).Item(_PageGroupColumns(intColFlag))))
                            End If
                        Next
                    End If

                    '把theRows轉成一個Table(資料列只有theRows)
                    Dim theNewTable As DataTable = _theDataTable.Clone
                    For i As Integer = 0 To theRows.Length - 1
                        theNewTable.Rows.Add(theRows(i).ItemArray)
                    Next
                    theRepeatArea.Remove(0, theRepeatArea.Length)
                    Dim temptheRepeatArea = strTempRepeatArea
                    'theRepeatArea=strTempRepeatArea 
                    'theRepeatArea = DataTableRowSpanCols(theNewTable, _KeyColumns, _RowSpanColumns, theRepeatArea)

                    theRepeatArea.AppendLine(DataTableRowSpanCols(theNewTable, _KeyColumns, _RowSpanColumns, temptheRepeatArea))
                    thePageRepeatArea = thePageRepeatArea.Replace(strRepeatSCode & strRepeatECode, theRepeatArea.ToString)

                End If

                '-------------------------------------
                '處理分頁:有PageGroup時在這裡處理分頁
                '表格式原則上不分頁,分頁時機:有PageGroup時
                '信件式每個Row就要分頁一次
                '-------------------------------------
                If (_IsDoPageGroup = True) And intAryFlag <> (thePageGroupFilterItems.Count - 1) Then
                    '有分組並且不是最後一筆:加上分頁符號
                    theReplacedPageRepeatArea.Add(thePageRepeatArea.ToString & strPageSep)
                Else
                    theReplacedPageRepeatArea.Add(thePageRepeatArea.ToString)
                End If


                'If _MultiColumnCount > 1 Then
                '    '放進Table
                '    If ((intAryFlag + 1) Mod _MultiColumnCount = 0) Then
                '        '該列最後一個TD
                '        strTempPageRepeatArea = "<TD>" & strTempPageRepeatArea & "</TD></TR>"
                '    ElseIf ((intAryFlag + 1) Mod _MultiColumnCount = 1) Then
                '        '該列第一個TD
                '        strTempPageRepeatArea = "<TR><TD>" & strTempPageRepeatArea & "</TD>"
                '    ElseIf ((intAryFlag + 1) Mod _MultiColumnCount > 1) Then
                '        strTempPageRepeatArea = "<TD>" & strTempPageRepeatArea & "</TD>"
                '    End If
                'End If

            Next
            Try

                If _breakPage <> "" Then
                    strTMP = String.Concat(theReplacedPageRepeatArea.ToArray)
                Else
                    strTMP = strTempHeadFoot.Replace(strPageRepeatSCode & strPageRepeatECode, String.Concat(theReplacedPageRepeatArea.ToArray))
                End If
                '  strTMP = strTempHeadFoot.Replace(strPageRepeatSCode & strPageRepeatECode, String.Concat(theReplacedPageRepeatArea.ToArray))

            Catch ex As Exception

            End Try
            theReplacedPageRepeatArea.Clear()



            ''''''''''''''''''''''''''''''''''''''''''''若MultiColumnCount>1則下一份放隔壁
            ''---------------------------------------------------------------------------------
            ''_MultiColumnCount = 1時,IntPlus是0,否則算出需補上多少(intPlus)才能組成完整Table
            ''---------------------------------------------------------------------------------
            'Dim intPlus As Integer = 0

            'If _MultiColumnCount > 1 Then
            '    While (_theDataTable.Rows.Count + intPlus) Mod _MultiColumnCount <> 0
            '        intPlus += 1
            '    End While
            'End If

            'If _MultiColumnCount = 1 Then
            '    strTempPageRepeatArea = strTempPageRepeatArea '不放進Table
            'Else
            '    '放進Table
            '    strTempPageRepeatArea = "<TABLE border=0 cellspacing=0 cellpadding=0>" & strTempPageRepeatArea & "</TABLE>"
            'End If


            _ContextString = strTMP


        End Sub

#Region "DataTableRowSpanCols將DataTable某些欄位做Rowspan"
        Private Function DataTableRowSpanCols(ByVal theDataTable As DataTable, ByVal theKeyColumns() As String, ByVal theRowSpanColumns() As String, ByVal theRepeatArea As String) As String
            '=============================================================================================
            '傳入參數:
            '1.theDataTable:要調整的DataTable
            '2.theKeyColumns():在傳入的DataTable中,要當Key的欄位.例如org與no欄位(是陣列所以可接受多個欄位)
            '3.theRowSpanColumns:要做RowSpan的數個欄位
            '回傳值:
            '整個DataTable變成已經具有RowSpan的HTML字串
            '=============================================================================================

            '因為是 Private Function 所以不用做防呆,因為先前已經有防
            Dim intAryFlag As Integer

            '組成arylistRowSpanFilterItem---------------------------------------------------
            Dim arylistRowSpanFilterItem As ArrayList
            arylistRowSpanFilterItem = ConsistFilterItems(theDataTable, theKeyColumns)
            '-------------------------------------------------------------------------------

            Dim arylistAllRecords As New ArrayList '裝各列資料的總集合

            For intAryFlag = 0 To arylistRowSpanFilterItem.Count - 1

                '一組Key篩選一個群組(多筆)資料列
                Dim theRows() As DataRow = theDataTable.Select(arylistRowSpanFilterItem.Item(intAryFlag))

                Dim theRowSpanColumnsHash As New Hashtable '準備RowSpanColumnsHash

                Dim intGroupColumnsFlag As Integer
                For intGroupColumnsFlag = 0 To theRowSpanColumns.Length - 1
                    theRowSpanColumnsHash.Add(theRowSpanColumns(intGroupColumnsFlag), New Hashtable)
                Next

                '-------------------------------------------------------------------------------
                '填好RowSpanColumnsHash
                '-------------------------------------------------------------------------------
                If theRows.Length > 0 Then '為theRows做 RowSpan

                    Dim intI As Integer
                    Dim intJ As Integer
                    Dim intFlag(theRowSpanColumns.Length - 1) As Integer '因為ColumnsHash的項目會亂跳,所以用intFlag紀錄ColumnsHash最近增加的那個項目的RowIndex

                    'ColumnsHash說明---------------------------
                    '(RowIndex,RowSpan) 
                    '例(0, 1) 索引0的Row設RowSpan=1
                    '例(1, 1) 索引1的Row設RowSpan=1
                    '例(2, 1) 索引2的Row設RowSpan=1
                    '例(3, 3) 索引3的Row設RowSpan=3
                    '例(4, 0) 索引4的Row設RowSpan=0
                    '例(5, 0) 索引5的Row設RowSpan=0
                    '例(6, 2) 索引6的Row設RowSpan=2
                    '例(7, 0) 索引7的Row設RowSpan=0
                    '因為ColumnsHash的項目會亂跳,所以用intFlag紀錄ColumnsHash最近增加的那個項目的RowIndex
                    '------------------------------------------
                    For intI = 0 To theRows.Length - 1
                        For intJ = 0 To theRowSpanColumns.Length - 1
                            '把 HashTMP 當成 ColumnsHash 的縮寫
                            Dim HashTMP As Hashtable = theRowSpanColumnsHash.Item(theRowSpanColumns(intJ))

                            If intI = 0 Then
                                '若此列是第一筆Row時,幫 ColumnsHash 增加一筆資料 (0,1)
                                HashTMP.Add(intI.ToString, 1)
                                intFlag(intJ) = intI
                            Else
                                '寶琳說有null時會有Bug所以加 EmptyDBNull()

                                If EmptyDBNull(theRows(intI).Item(theRowSpanColumns(intJ))) = EmptyDBNull(theRows(intFlag(intJ)).Item(theRowSpanColumns(intJ))) Then
                                    '若此列的值等於ColumnsHash最近增加的那個項目的RowIndex的值
                                    HashTMP.Add(intI.ToString, 0) 'RowSpan=0表示要消掉的
                                    HashTMP.Item(intFlag(intJ).ToString) += 1 '累加RowSpan值
                                Else
                                    '若此列的值不等於ColumnsHash最近增加的那個項目的RowIndex的值
                                    HashTMP.Add(intI.ToString, 1) 'RowSpan=1
                                    intFlag(intJ) = intI '累加intFlag的值
                                End If

                            End If
                        Next
                    Next

                    '宣告來裝一個列的各欄"樣板"資料
                    '有時候樣板有欄位,但是Datatable沒有此欄位(例如備註,備註1),沒有這個欄位也要放對應的HTML
                    '所以用ArrayList不用Hash
                    Dim arylistTheRecordTempCells As New ArrayList

                    Dim theTMPRepeatArea As String = theRepeatArea

                    While theTMPRepeatArea.IndexOf("<td") >= 0

                        Dim strHTML As String = theTMPRepeatArea.Substring(theTMPRepeatArea.IndexOf("<td"), theTMPRepeatArea.IndexOf("</td>") - theTMPRepeatArea.IndexOf("<td") + ("</td>").Length)

                        theTMPRepeatArea = theTMPRepeatArea.Remove(theTMPRepeatArea.IndexOf("<td"), theTMPRepeatArea.IndexOf("</td>") - theTMPRepeatArea.IndexOf("<td") + ("</td>").Length)

                        '將重複的區塊依每一組<td>分割到arylistTheRecordTempCells
                        arylistTheRecordTempCells.Add(strHTML)
                    End While

                    '---------------------------------------------------------------
                    '開始逐列Replace變數,把該列所組成的HTML碼放到陣列
                    '---------------------------------------------------------------
                    Dim intRowFlag As Integer
                    Dim intColFlag As Integer

                    For intRowFlag = 0 To theRows.Length - 1
                        Dim strTheRecordCell As String
                        Dim arylistTheRecordCells As New ArrayList
                        Dim strTheRecd As String

                        '因為跑迴圈所以清空再來裝
                        strTheRecordCell = ""
                        arylistTheRecordCells.Clear()
                        strTheRecd = ""



                        For intColFlag = 0 To arylistTheRecordTempCells.Count - 1

                            Dim tmpHTML As String = arylistTheRecordTempCells(intColFlag)
                            Dim tmpColName As String

                            Try
                                tmpColName = tmpHTML.Substring(tmpHTML.IndexOf("##") + 2, tmpHTML.LastIndexOf("##") - (tmpHTML.IndexOf("##") + 2))
                            Catch ex As Exception
                                tmpColName = String.Empty
                            End Try

                            strTheRecordCell = arylistTheRecordTempCells(intColFlag)

                            '若樣版檔有##XXXX##
                            If tmpColName <> String.Empty Then

                                '若現在這一個欄位是要RowSpan的欄位,則指定RowSpan
                                If Array.IndexOf(theRowSpanColumns, tmpColName) >= 0 Then
                                    Dim HasgTMP As Hashtable = theRowSpanColumnsHash.Item(tmpColName)
                                    If HasgTMP.Item(intRowFlag.ToString) = 0 Then
                                        strTheRecordCell = ""
                                    Else
                                        strTheRecordCell = strTheRecordCell.Replace("<td", "<td rowspan=3D" & HasgTMP.Item(intRowFlag.ToString))
                                    End If
                                End If

                                '置換變數
                                If IsDBNull(theRows(intRowFlag).Item(tmpColName)) Then
                                    strTheRecordCell = strTheRecordCell.Replace("##" & theRows(intRowFlag).Table.Columns(tmpColName).ColumnName & "##", "")
                                Else
                                    strTheRecordCell = strTheRecordCell.Replace("##" & theRows(intRowFlag).Table.Columns(tmpColName).ColumnName & "##", GetCharCodes(theRows(intRowFlag).Item(tmpColName)))
                                End If

                            End If

                            arylistTheRecordCells.Add(strTheRecordCell)

                        Next

                        strTheRecd = "<tr>" & String.Concat(arylistTheRecordCells.ToArray) & "</tr>"

                        arylistAllRecords.Add(strTheRecd)

                    Next

                End If

            Next

            Return String.Concat(arylistAllRecords.ToArray)

        End Function

#End Region

        Public Sub ExportToWord()
            ExportToFile(ExportFileType.MS_Word)
        End Sub

        Public Sub ExportToExcel()
            ExportToFile(ExportFileType.MS_Excel)
        End Sub

        Public Sub ExportToWord(ByVal path As String)
            ExportToFile(ExportFileType.MS_Word, path)
        End Sub

        Public Sub ExportToExcel(ByVal path As String)
            ExportToFile(ExportFileType.MS_Excel, path)
        End Sub
        Public Sub ExportToHTML(ByVal path As String)
            ConsistHTMLCode()
            If _ContextString <> "" Then
                HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.GetEncoding("Big5")
                HttpContext.Current.Response.AddHeader("content-disposition", "inline; filename=" & path)
                HttpContext.Current.Response.ClearContent()
                HttpContext.Current.Response.ContentType = "message/rfc822"
                HttpContext.Current.Response.Write(_ContextString)
                HttpContext.Current.Response.End()
            End If
        End Sub

        Private Sub ExportToFile(ByVal theFileType As ExportFileType)
            If Not (_PageGroupColumns Is Nothing) And theFileType = ExportFileType.MS_Excel Then
                If _PageGroupColumns.Length > 0 Then
                    ConsistHTMLCode(ExportFileType.MS_Excel)
                Else
                    ConsistHTMLCode()
                End If
            Else
                ConsistHTMLCode()
            End If

            If _ContextString <> "" Then

                '暫存檔之檔名
                Dim fileName As String = Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second & Now.Millisecond
                Dim theFileInfo As System.IO.FileInfo


                If theFileType = ExportFileType.MS_Word Then
                    theFileInfo = New System.IO.FileInfo(HttpContext.Current.Server.MapPath("~/Report/WordTemp/") & fileName & ".doc")
                    '建立輸出串流
                    Dim theStreamWriter As New System.IO.StreamWriter(theFileInfo.FullName, False, System.Text.Encoding.UTF8) '注意UTF8才OK，用 Default會出錯
                    theStreamWriter.Write(_ContextString)
                    theStreamWriter.Flush()
                    theStreamWriter.Close()
                    theStreamWriter.Dispose()

                    ''建立WORD檔物件:
                    'Dim theWord As New Word.Application
                    'Dim theWordDoc As Word.Document
                    'Try
                    '    '開啟WORD文件
                    '    theWordDoc = theWord.Documents.Open(theFileInfo.FullName)
                    '    '儲存並取代原本WORD檔，讓WORD檔轉為原始編碼
                    '    theWordDoc.SaveAs(HttpContext.Current.Server.MapPath("~/Report/WordTemp/") & fileName & ".doc", Word.WdSaveFormat.wdFormatDocument, , , , , , , , , , )
                    '    theWordDoc.Close(Word.WdSaveOptions.wdSaveChanges)

                    'Catch ex As Exception
                    '    theWord.Documents.Save()  ' 錯誤中斷時要關掉，這樣暫存Excel檔才不會被Hold住 

                    'Finally

                    '    theWord.Quit()
                    '    theWordDoc = Nothing
                    '    theWord = Nothing

                    'End Try
                    '建立檔案輸入串流物件
                    Dim theReader As New System.IO.FileStream(HttpContext.Current.Server.MapPath("~/Report/WordTemp/") & fileName & ".doc", FileMode.Open)
                    '建立BYTES ARRAY 準備讀取檔案輸入串流物件資料
                    Dim buf(theReader.Length) As Byte
                    '將檔案輸入串流物件資料讀至BYTES ARRAY 
                    theReader.Read(buf, 0, theReader.Length)
                    theReader.Close()
                    theReader.Dispose()
                    '刪除暫存檔
                    '  theFileInfo.Delete() ' 錯誤中斷時有關掉Excel或Word，這裡才刪得掉。   
                    My.Computer.FileSystem.DeleteFile(HttpContext.Current.Server.MapPath("~/Report/WordTemp/") & fileName & ".doc", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

                    'HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & Chr(34) & System.Web.HttpUtility.UrlEncode(_ExportFileName, System.Text.Encoding.UTF8) & ".doc" & Chr(34))
                    HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.UTF8
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & fileName & ".doc")
                    HttpContext.Current.Response.ContentType = "Application/octet-stream" '"application/vnd.ms-word"
                    HttpContext.Current.Response.ClearContent()
                    HttpContext.Current.Response.BinaryWrite(buf)
                    HttpContext.Current.Response.End()


                ElseIf theFileType = ExportFileType.MS_Excel Then
                    '建立輸出串流
                    theFileInfo = New System.IO.FileInfo(HttpContext.Current.Server.MapPath("~/Report/ExcelTemp/") & fileName & ".xls")
                    Dim theStreamWriter As New System.IO.StreamWriter(theFileInfo.FullName, False, System.Text.Encoding.UTF8) '注意UTF8才OK，用 Default會出錯
                    theStreamWriter.Write(_ContextString)
                    theStreamWriter.Flush()
                    theStreamWriter.Close()
                    theStreamWriter.Dispose()

                    ' ''建立EXCEL檔物件 
                    'Dim theExcel As New Excel.Application
                    'Dim theWorkbook As Excel.Workbook
                    'Try
                    '    theExcel.DisplayAlerts = False
                    '    '開啟EXCEL文件
                    '    theWorkbook = theExcel.Workbooks.Open(theFileInfo.FullName)
                    '    '儲存並取代原本EXCEL檔，讓EXCEL檔轉為原始編碼
                    '    theWorkbook.SaveAs(HttpContext.Current.Server.MapPath("~/Report/ExcelTemp/") & fileName & "temp.xls", Excel.XlFileFormat.xlWorkbookNormal, , , , , , , , , , ) ' Excel.XlSaveAsAccessMode.xlShared
                    '    theWorkbook.Close()
                    '    theExcel.Quit()

                    'Catch ex As Exception
                    '    theExcel.SaveWorkspace() ' 錯誤中斷時要關掉，這樣暫存Excel檔才不會被Hold住

                    'Finally

                    '    System.Runtime.InteropServices.Marshal.ReleaseComObject(theWorkbook)
                    '    System.Runtime.InteropServices.Marshal.ReleaseComObject(theExcel)
                    '    theWorkbook = Nothing
                    '    theExcel = Nothing
                    '    GC.Collect()
                    '    GC.WaitForPendingFinalizers()
                    'End Try

                    '建立檔案輸入串流物件 
                    Dim buf() As Byte = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Report/ExcelTemp/") & fileName & ".xls")

                    '刪除暫存檔
                    ' theFileInfo.Delete() ' 錯誤中斷時有關掉Excel或Word，這裡才刪得掉。 
                    File.Delete(HttpContext.Current.Server.MapPath("~/Report/ExcelTemp/") & fileName & ".xls")

                    'HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & Chr(34) & System.Web.HttpUtility.UrlEncode(_ExportFileName, System.Text.Encoding.UTF8) & ".xls" & Chr(34))
                    HttpContext.Current.Response.Clear()
                    HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.UTF8
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & HttpUtility.UrlEncode(Me.ExportFileName, Encoding.UTF8) & ".xls")
                    HttpContext.Current.Response.ContentType = "Application/octet-stream" ' "application/vnd.ms-excel"
                    HttpContext.Current.Response.ClearContent()
                    HttpContext.Current.Response.BinaryWrite(buf)
                    HttpContext.Current.Response.End()

                Else
                    Dim buf() As Byte = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Report/ExcelTemp/") & fileName & "temp.xls")

                    'HttpContext.Current.Response.ContentType = "Application/octet-stream"
                    HttpContext.Current.Response.Clear()
                    HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.UTF8
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & HttpUtility.UrlEncode(Me.ExportFileName, Encoding.UTF8) & ".xls")
                    HttpContext.Current.Response.ContentType = "Application/octet-stream" ' "application/vnd.ms-excel"
                    HttpContext.Current.Response.ClearContent()
                    HttpContext.Current.Response.BinaryWrite(buf)
                    HttpContext.Current.Response.End()
                End If


            End If

        End Sub

        Public Sub ExportToFile(ByVal theFileType As ExportFileType, ByVal fileName As String, Optional ByVal isResponseWrite As Boolean = True)
            ConsistHTMLCode()
            If _ContextString <> "" Then
                If isResponseWrite Then
                    HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.GetEncoding("Big5")
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & fileName)
                    HttpContext.Current.Response.ClearContent()
                    If theFileType = ExportFileType.MS_Word Then
                        HttpContext.Current.Response.ContentType = "Application/vnd.ms-word" '"application/vnd.ms-word"
                    ElseIf theFileType = ExportFileType.MS_Excel Then
                        HttpContext.Current.Response.ContentType = "Application/vnd.ms-excel" '"application/vnd.ms-excel"
                    ElseIf theFileType = ExportFileType.MS_Txt Then
                        HttpContext.Current.Response.ContentType = "application/txt"
                    Else
                        HttpContext.Current.Response.ContentType = "Application/octet-stream"
                    End If
                    HttpContext.Current.Response.Write(_ContextString)
                    HttpContext.Current.Response.End()
                Else '存檔至目錄
                    '建立輸出串流
                    Dim theFileInfo As System.IO.FileInfo = New System.IO.FileInfo(fileName)
                    Dim theStreamWriter As New System.IO.StreamWriter(theFileInfo.FullName, False, System.Text.Encoding.UTF8) '注意UTF8才OK，用 Default會出錯
                    theStreamWriter.Write(_ContextString)
                    theStreamWriter.Flush()
                    theStreamWriter.Close()
                    theStreamWriter.Dispose()
                End If
            End If
        End Sub

        Public Sub ExportToExcelToPDF()
            ExportToPDFFile(ExportFileType.MS_Excel)
        End Sub

        Private Sub ExportToPDFFile(ByVal theFileType As ExportFileType)
            If Not (_PageGroupColumns Is Nothing) And theFileType = ExportFileType.MS_Excel Then
                If _PageGroupColumns.Length > 0 Then
                    ConsistHTMLCode(ExportFileType.MS_Excel)
                Else
                    ConsistHTMLCode()
                End If
            Else
                ConsistHTMLCode()
            End If

            If _ContextString <> "" Then

                '暫存檔之檔名
                Dim fileName As String = Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second & Now.Millisecond
                Dim theFileInfo As System.IO.FileInfo

                If theFileType = ExportFileType.MS_Excel Then

                    Dim exlpath As String = HttpContext.Current.Server.MapPath("~/Report/ExcelTemp/")
                    Dim exlfname As String = fileName & ".xls"

                    '建立 Temp Excel檔案
                    theFileInfo = New System.IO.FileInfo(exlpath & exlfname)

                    '寫入組合過的excel 內容
                    Dim sw As New System.IO.StreamWriter(theFileInfo.FullName, False, System.Text.Encoding.UTF8) '注意UTF8才OK，用 Default會出錯
                    sw.Write(_ContextString)
                    sw.Flush()
                    sw.Close()
                    sw.Dispose()

                    Dim pdfpath As String = HttpContext.Current.Server.MapPath("~/Report/PdfTemp/")
                    Dim pdffname As String = fileName & ".pdf"

                    '轉成PDF
                    ExcelToPdf(exlpath & exlfname, pdfpath, fileName)

                    '刪除Excel
                    'File.Delete(exlpath & exlfname)
                    My.Computer.FileSystem.DeleteFile(exlpath & exlfname, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

                    '寫入Binary
                    Dim fs As FileStream = File.OpenRead(pdfpath & pdffname)
                    Dim br As BinaryReader = New BinaryReader(fs)
                    Dim bw As BinaryWriter = New BinaryWriter(HttpContext.Current.Response.OutputStream)
                    Dim buffer(1024) As Byte
                    Dim count As Integer = br.Read(buffer, 0, buffer.Length)
                    Do While count > 0
                        bw.Write(buffer, 0, count)
                        count = br.Read(buffer, 0, buffer.Length)
                    Loop
                    br.Close()
                    bw.Close()

                    '刪除PDF
                    'File.Delete(pdfpath & pdffname)
                    My.Computer.FileSystem.DeleteFile(pdfpath & pdffname, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

                    '將 Binary 利用 Http header 匯出 PDF 檔
                    HttpContext.Current.Response.ContentType = "Application/pdf"
                    HttpContext.Current.Response.AddHeader("Content-disposition", "attachment; filename=" & HttpUtility.UrlEncode(Me.ExportFileName, Encoding.UTF8) & ".pdf")
                    HttpContext.Current.Response.End()

                End If

            End If

        End Sub

        Public Shared Sub ExcelToPdf(ByVal excelFile, ByVal outputFolder, ByVal outputFileName)

            Dim docToConvert As String = excelFile
            Dim DC As New docCreator.docCreatorClass

            Dim tempFile As String = DC.GetTempDirectory & DC.NewGUID & ".ps"
            DC.DocumentOutputFormat = "PDF"
            DC.DocumentOutputName = outputFileName
            DC.DocumentOutputFolder = outputFolder

            Dim MSExcel As New Excel.Application

            MSExcel.DisplayAlerts = False
            Dim XLDoc As Excel.Workbook = MSExcel.Workbooks.Open(docToConvert, 0, True)

            XLDoc.Activate()
            XLDoc.PrintOut(, , , False, "Neevia docCreator", True, 0, tempFile)
            XLDoc.Saved = True
            XLDoc.Close()
            MSExcel.Quit()
            'MSExcel = Nothing
            DC.SetInputDocument(tempFile)
            Dim RVal As Integer = DC.Create ' Create output document
            If (RVal <> 0) Then
                MsgBox("Error while creating document!!!")
            End If
            DC.FileDelete(tempFile)
            DC = Nothing

            'CommonFun.KillProcess("EXCEL")
            'GC.Collect()

            System.Runtime.InteropServices.Marshal.ReleaseComObject(MSExcel)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(XLDoc)
            MSExcel = Nothing
            XLDoc = Nothing
            GC.Collect()
        End Sub

        Public Shared Sub WordToPdf(ByVal wordFile, ByVal outputFolder, ByVal outputFileName)
            Dim docToConvert As String = wordFile
            Dim DC As New docCreator.docCreatorClass

            Dim tempFile As String = DC.GetTempDirectory & DC.NewGUID & ".ps"
            DC.DocumentOutputFormat = "PDF"
            DC.DocumentOutputName = outputFileName
            DC.DocumentOutputFolder = outputFolder

            Dim MSWord As New Word.Application

            MSWord.DisplayAlerts = False
            Dim XLDoc As Word.Document = MSWord.Documents.Open(docToConvert, 0, True)

            XLDoc.Activate()
            XLDoc.PrintOut(, , , False, "Neevia docCreator", True, 0, tempFile)
            XLDoc.Saved = True
            XLDoc.Close()
            MSWord.Quit()
            'MSWord = Nothing
            DC.SetInputDocument(tempFile)
            Dim RVal As Integer = DC.Create ' Create output document
            If (RVal <> 0) Then
                MsgBox("Error while creating document!!!")
            End If
            DC.FileDelete(tempFile)
            DC = Nothing

            'CommonFun.KillProcess("WORD")
            'GC.Collect()

            System.Runtime.InteropServices.Marshal.ReleaseComObject(MSWord)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(XLDoc)
            MSWord = Nothing
            XLDoc = Nothing
            GC.Collect()
        End Sub


#Region "將DataTable的資料匯出"

        Public Shared Function PrintReport(ByVal dt As DataTable, ByVal title As String, ByVal head As String, ByVal foot As String)

            Dim intCount As Integer = 0
            Dim sbBody As New System.Text.StringBuilder() '報表樣版的全文
            Dim sbData As New System.Text.StringBuilder()
            Dim sbTitle As New System.Text.StringBuilder()
            '-----讀取產生報表所需的各樣版區塊-----

            sbBody.Append("<table border=0 cellpadding=0 cellspacing=0>")

            If "" <> title Then
                Dim titles() As String = title.Split("|")
                If Not titles Is Nothing And 0 < titles.Length Then
                    For i As Integer = 0 To titles.Length - 1
                        sbBody.Append("<tr>")
                        sbBody.Append("<td colspan='" & dt.Columns.Count & "'>" & titles(i) & "</td>")
                        sbBody.Append("</tr>")
                    Next
                Else
                    sbBody.Append("<tr>")
                    sbBody.Append("<td colspan='" & dt.Columns.Count & "'>" & title & "</td>")
                    sbBody.Append("</tr>")
                End If
            End If


            If "" <> head Then
                sbTitle.Append("<tr>")
                sbTitle.Append("<td colspan='" & dt.Columns.Count & "' class=xl24>" & head & "</td>")
                sbTitle.Append("</tr>")
            Else
                '-----------------------------------------------------------------------------------------------------------------------
                '-報表的標題列---------------------------------------------------------------------------------------------------------- 
                sbTitle.Append("<tr>")
                For i As Integer = 0 To dt.Columns.Count - 1
                    sbTitle.Append("<td>" & dt.Columns(i).ColumnName & "</td>")
                Next
                sbTitle.Append("</tr>")
                '-----------------------------------------------------------------------------------------------------------------------
            End If

            '-----------------------------------------------------------------------------------------------------------------------
            '-報表的資料列---------------------------------------------------------------------------------------------------------- 
            For Each row As DataRow In dt.Rows
                sbData.AppendLine("<tr>")
                For Each col As Object In row.ItemArray
                    sbData.Append("<td style='mso-style-parent:style0;mso-number-format:""\@"";white-space:normal;'>" & Convert.ToString(col.ToString) & "</td>")
                Next
                sbData.AppendLine("</tr>")
            Next
            '-----------------------------------------------------------------------------------------------------------------------
            sbBody.Append(sbTitle.ToString & sbData.ToString)

            If "" <> foot Then
                sbBody.Append("<tr>")
                Dim foots() As String = foot.Split("|")
                If Not foots Is Nothing And 0 < foots.Length Then
                    For i As Integer = 0 To foots.Length - 1
                        sbBody.Append("<td>" & foots(i) & "</td>")
                    Next
                Else
                    sbBody.Append("<td colspan='" & dt.Columns.Count & "'>" & foot & "</td>")
                End If
                sbBody.Append("</tr>")
            End If

            '-----------------查無資料-------------------------------------
            If dt Is Nothing Then
                sbBody.AppendLine("<tr>")
                sbBody.Append("<td style='mso-style-parent:style0;mso-number-format:""\@"";white-space:normal;'>查無資料</td>")
                sbBody.AppendLine("</tr>")
            ElseIf Not dt Is Nothing And dt.Rows.Count < 1 Then
                sbBody.AppendLine("<tr>")
                sbBody.Append("<td style='mso-style-parent:style0;mso-number-format:""\@"";white-space:normal;'>查無資料</td>")
                sbBody.AppendLine("</tr>")
            End If

            sbBody.Append("</table>")
            Return sbBody.ToString()
        End Function

        Public Shared Sub PrintReport(ByVal dt As DataTable, ByVal theFileType As ExportFileType, ByVal fileName As String)
            PrintReport(dt, theFileType, fileName, "", "", "")
        End Sub

        Public Shared Sub PrintReport(ByVal dt As DataTable, ByVal theFileType As ExportFileType, ByVal fileName As String, ByVal title As String, ByVal head As String, ByVal foot As String)
            Dim reValue As String = PrintReport(dt, title, head, foot)
            Dim htmlHead As StringBuilder = New StringBuilder()
            If reValue <> "" Then
                HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.GetEncoding("Big5")
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & fileName)
                HttpContext.Current.Response.ClearContent()

                htmlHead.Append("<html xmlns:o=""urn:schemas-microsoft-com:office:office"" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns=""http://www.w3.org/TR/REC-html40"">")
                htmlHead.Append("<meta http-equiv=Content-Type content=""text/html; charset=big5"">")
                htmlHead.Append("<head>")

                If theFileType = ExportFileType.MS_Word Then
                    HttpContext.Current.Response.ContentType = "Application/vnd.ms-word"
                    htmlHead.Append("<meta name=ProgId content=Word.Document>")
                    htmlHead.Append("<meta name=Generator content=""Microsoft Word 11"">")
                ElseIf theFileType = ExportFileType.MS_Excel Then
                    HttpContext.Current.Response.ContentType = "Application/vnd.ms-excel"
                    htmlHead.Append("<meta name=ProgId content=Excel.Sheet>")
                    htmlHead.Append("<meta name=Generator content=""Microsoft Excel 11"">")
                Else
                    HttpContext.Current.Response.ContentType = "Application/octet-stream"
                End If

                htmlHead.Append("</head>")
                HttpContext.Current.Response.Write(reValue)
                HttpContext.Current.Response.End()
            End If
        End Sub

        Public Shared Sub PrintReport(ByVal content As String, ByVal theFileType As ExportFileType, ByVal fileName As String)
            Dim htmlHead As StringBuilder = New StringBuilder()
            If content <> "" Then
                HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.GetEncoding("Big5")
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & fileName)
                HttpContext.Current.Response.ClearContent()

                htmlHead.Append("<html xmlns:o=""urn:schemas-microsoft-com:office:office"" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns=""http://www.w3.org/TR/REC-html40"">")
                htmlHead.Append("<meta http-equiv=Content-Type content=""text/html; charset=big5"">")
                htmlHead.Append("<head>")

                If theFileType = ExportFileType.MS_Word Then
                    HttpContext.Current.Response.ContentType = "Application/vnd.ms-word"
                    htmlHead.Append("<meta name=ProgId content=Word.Document>")
                    htmlHead.Append("<meta name=Generator content=""Microsoft Word 11"">")
                ElseIf theFileType = ExportFileType.MS_Excel Then
                    HttpContext.Current.Response.ContentType = "Application/vnd.ms-excel"
                    htmlHead.Append("<meta name=ProgId content=Excel.Sheet>")
                    htmlHead.Append("<meta name=Generator content=""Microsoft Excel 11"">")
                Else
                    HttpContext.Current.Response.ContentType = "Application/octet-stream"
                End If

                htmlHead.Append("</head>")
                HttpContext.Current.Response.Write(content)
                HttpContext.Current.Response.End()
            End If
        End Sub

#End Region

#Region "將GridView的資料匯出"

        Public Shared Function PrintGridView(ByVal dv As GridView, ByVal title As String, ByVal head As String, ByVal foot As String)

            Dim intCount As Integer = 0
            Dim sbBody As New System.Text.StringBuilder() '報表樣版的全文
            Dim sbData As New System.Text.StringBuilder()
            Dim sbTitle As New System.Text.StringBuilder()
            '-----讀取產生報表所需的各樣版區塊-----

            sbBody.Append("<table border=0 cellpadding=0 cellspacing=0>")

            If "" <> title Then
                Dim titles() As String = title.Split("|")
                If Not titles Is Nothing And 0 < titles.Length Then
                    For i As Integer = 0 To titles.Length - 1
                        sbBody.Append("<tr>")
                        sbBody.Append("<td colspan='" & dv.Columns.Count & "'>" & titles(i) & "</td>")
                        sbBody.Append("</tr>")
                    Next
                Else
                    sbBody.Append("<tr>")
                    sbBody.Append("<td colspan='" & dv.Columns.Count & "'>" & title & "</td>")
                    sbBody.Append("</tr>")
                End If
            End If

            If "" <> head Then
                sbTitle.Append("<tr>")
                sbTitle.Append("<td colspan='" & dv.Columns.Count & "' class=xl24>" & head & "</td>")
                sbTitle.Append("</tr>")
            Else
                '-----------------------------------------------------------------------------------------------------------------------
                '-報表的標題列---------------------------------------------------------------------------------------------------------- 
                sbTitle.Append("<tr>")
                For i As Integer = 0 To dv.Columns.Count - 1
                    sbTitle.Append("<td>" & dv.Columns(i).HeaderText & "</td>")
                Next
                sbTitle.Append("</tr>")
                '-----------------------------------------------------------------------------------------------------------------------
            End If

            '-----------------------------------------------------------------------------------------------------------------------
            '-報表的資料列----------------------------------------------------------------------------------------------------------
            For Each row As GridViewRow In dv.Rows
                sbData.AppendLine("<tr>")
                For Each cell As TableCell In row.Cells
                    sbData.Append("<td style='mso-style-parent:style0;mso-number-format:""\@"";white-space:normal;'>" & Convert.ToString(cell.Text) & "</td>")
                Next
                sbData.AppendLine("</tr>")
            Next
            '-----------------------------------------------------------------------------------------------------------------------
            sbBody.Append(sbTitle.ToString & sbData.ToString)

            If Not dv.FooterRow Is Nothing Then
                sbData.AppendLine("<tr>")
                For Each cell As TableCell In dv.FooterRow.Cells
                    sbData.Append("<td style='mso-style-parent:style0;mso-number-format:""\@"";white-space:normal;'>" & Convert.ToString(cell.Text) & "</td>")
                Next
                sbData.AppendLine("</tr>")
            End If

            If "" <> foot Then
                sbBody.Append("<tr>")
                Dim foots() As String = foot.Split("|")
                If Not foots Is Nothing And 0 < foots.Length Then
                    For i As Integer = 0 To foots.Length - 1
                        sbBody.Append("<td>" & foots(i) & "</td>")
                    Next
                Else
                    sbBody.Append("<td colspan='" & dv.Columns.Count & "'>" & foot & "</td>")
                End If
                sbBody.Append("</tr>")
            End If

            '-----------------查無資料-------------------------------------
            If dv Is Nothing Then
                sbBody.AppendLine("<tr>")
                sbBody.Append("<td style='mso-style-parent:style0;mso-number-format:""\@"";white-space:normal;'>查無資料</td>")
                sbBody.AppendLine("</tr>")
            ElseIf Not dv Is Nothing And dv.Rows.Count < 1 Then
                sbBody.AppendLine("<tr>")
                sbBody.Append("<td style='mso-style-parent:style0;mso-number-format:""\@"";white-space:normal;'>查無資料</td>")
                sbBody.AppendLine("</tr>")
            End If

            sbBody.Append("</table>")
            Return sbBody.ToString()
        End Function

        Public Shared Sub PrintGridView(ByVal dv As GridView, ByVal theFileType As ExportFileType, ByVal fileName As String)
            PrintGridView(dv, theFileType, fileName, "", "", "")
        End Sub

        Public Shared Sub PrintGridView(ByVal dv As GridView, ByVal theFileType As ExportFileType, ByVal fileName As String, ByVal title As String, ByVal head As String, ByVal foot As String)
            Dim reValue As String = PrintGridView(dv, title, head, foot)
            Dim htmlHead As StringBuilder = New StringBuilder()
            If reValue <> "" Then
                HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.GetEncoding("Big5")
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & fileName)
                HttpContext.Current.Response.ClearContent()

                htmlHead.Append("<html xmlns:o=""urn:schemas-microsoft-com:office:office"" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns=""http://www.w3.org/TR/REC-html40"">")
                htmlHead.Append("<meta http-equiv=Content-Type content=""text/html; charset=big5"">")
                htmlHead.Append("<head>")

                If theFileType = ExportFileType.MS_Word Then
                    HttpContext.Current.Response.ContentType = "Application/vnd.ms-word"
                    htmlHead.Append("<meta name=ProgId content=Word.Document>")
                    htmlHead.Append("<meta name=Generator content=""Microsoft Word 11"">")
                ElseIf theFileType = ExportFileType.MS_Excel Then
                    HttpContext.Current.Response.ContentType = "Application/vnd.ms-excel"
                    htmlHead.Append("<meta name=ProgId content=Excel.Sheet>")
                    htmlHead.Append("<meta name=Generator content=""Microsoft Excel 11"">")
                Else
                    HttpContext.Current.Response.ContentType = "Application/octet-stream"
                End If

                htmlHead.Append("</head>")
                HttpContext.Current.Response.Write(reValue)
                HttpContext.Current.Response.End()
            End If
        End Sub

        Public Shared Sub PrintGridView(ByVal content As String, ByVal theFileType As ExportFileType, ByVal fileName As String)
            Dim htmlHead As StringBuilder = New StringBuilder()
            If content <> "" Then
                HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.GetEncoding("Big5")
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & fileName)
                HttpContext.Current.Response.ClearContent()

                htmlHead.Append("<html xmlns:o=""urn:schemas-microsoft-com:office:office"" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns=""http://www.w3.org/TR/REC-html40"">")
                htmlHead.Append("<meta http-equiv=Content-Type content=""text/html; charset=big5"">")
                htmlHead.Append("<head>")

                If theFileType = ExportFileType.MS_Word Then
                    HttpContext.Current.Response.ContentType = "Application/vnd.ms-word"
                    htmlHead.Append("<meta name=ProgId content=Word.Document>")
                    htmlHead.Append("<meta name=Generator content=""Microsoft Word 11"">")
                ElseIf theFileType = ExportFileType.MS_Excel Then
                    HttpContext.Current.Response.ContentType = "Application/vnd.ms-excel"
                    htmlHead.Append("<meta name=ProgId content=Excel.Sheet>")
                    htmlHead.Append("<meta name=Generator content=""Microsoft Excel 11"">")
                Else
                    HttpContext.Current.Response.ContentType = "Application/octet-stream"
                End If

                htmlHead.Append("</head>")
                HttpContext.Current.Response.Write(content)
                HttpContext.Current.Response.End()
            End If
        End Sub

#End Region

#Region "靜態方法"

#Region "DataTableComBinCols將DataTable某些欄位合併多列成為一列"

        Shared Function DataTableComBinCols(ByVal theDataTable As DataTable, ByVal theKeyColumns() As String, ByVal theCombinColumns() As String, Optional ByVal SepString As String = ",") As DataTable
            '=============================================================================================
            '傳入參數:
            '1.theDataTable:要調整的DataTable
            '2.theKeyColumns():由哪些欄位組成Key欄位
            '3.theCombinColumns():哪些欄位要合併多列的值
            '4.SepString:合併多列的值,所使用的分隔符號
            '回傳值:
            '一個調整過後的DataTable
            '=============================================================================================
            Dim intAryFlag As Integer

            '防呆-------------------------------------------------
            If (theDataTable Is Nothing) Then
                Throw New Exception("輸入了無效的DataTable")
            End If
            '
            For intAryFlag = 0 To theKeyColumns.Length - 1
                If (theDataTable.Columns.IndexOf(theKeyColumns(intAryFlag)) = -1) Then
                    Throw New Exception("輸入了不存在的KeyColumn")
                End If
            Next
            '
            For intAryFlag = 0 To theCombinColumns.Length - 1
                If (theDataTable.Columns.IndexOf(theCombinColumns(intAryFlag)) = -1) Then
                    Throw New Exception("輸入了不存在的theCombinColumns")
                End If
            Next
            '-----------------------------------------------------

            Dim NewdataTable As DataTable = theDataTable.Clone

            NewdataTable.Rows.Clear()

            If theDataTable.Rows.Count > 0 Then
                '組成arylistFilterItem----------------------------------------------------------
                Dim arylistFilterItem As ArrayList
                arylistFilterItem = ConsistFilterItems(theDataTable, theKeyColumns)
                '-------------------------------------------------------------------------------
                For intAryFlag = 0 To arylistFilterItem.Count - 1
                    '一組Key篩選一個群組(多筆)資料列
                    Dim theRows() As DataRow = theDataTable.Select(arylistFilterItem.Item(intAryFlag))

                    If theRows.Length > 0 Then
                        '第一列拿來做加工
                        Dim theNewRow As DataRow = NewdataTable.NewRow
                        theNewRow.ItemArray = theRows(0).ItemArray

                        '組好一個CombinSet--------------------------------------------
                        Dim aryCombinSet(theCombinColumns.Length - 1) As ArrayList

                        Dim intJ As Integer
                        For intJ = 0 To theCombinColumns.Length - 1
                            aryCombinSet(intJ) = New ArrayList
                        Next

                        For Each theRow As DataRow In theRows
                            Dim intCol As Integer
                            For intCol = 0 To theCombinColumns.Length - 1
                                '用Trim的原因:有一次從資料庫撈資料回來後，後面都有很多空白字元
                                If IsDBNull(theRow.Item(theCombinColumns(intCol))) Then
                                    theRow.Item(theCombinColumns(intCol)) = String.Empty
                                End If
                                Dim theValue As String = Trim(theRow.Item(theCombinColumns(intCol)))

                                If aryCombinSet(intCol).IndexOf(theValue & SepString) = -1 Then
                                    aryCombinSet(intCol).Add(theValue & SepString)
                                End If
                            Next
                        Next
                        '-------------------------------------------------------------

                        '利用NewRow與組好的CombinSet,產生一個OK的資料列---------------
                        Dim intColumnFlag As Integer
                        '將 aryCombinSet裡的每一個Array組成字串,替換舊的.
                        For intColumnFlag = 0 To theCombinColumns.Length - 1
                            Dim strTMP As String = String.Concat(aryCombinSet(intColumnFlag).ToArray)
                            theNewRow.Item(theCombinColumns(intColumnFlag)) = strTMP.Remove(strTMP.LastIndexOf(SepString))
                        Next
                        '-------------------------------------------------------------
                        NewdataTable.Rows.Add(theNewRow)
                    End If

                Next


            End If
            NewdataTable.AcceptChanges()
            Return NewdataTable

            Return Nothing

        End Function

#End Region

#Region "DataTableRedirCol將DataTable某一欄位多列的資料轉為多欄"
        Shared Function DataTableRedirCol(ByVal theDataTable As DataTable, ByVal theKeyColumns() As String, ByVal RedirColumn As String, ByVal aryNewColValue() As String, Optional ByVal OutSymbol As String = "") As DataTable
            '=============================================================================================
            '傳入參數:
            '1.theDataTable:要調整的DataTable
            '2.theKeyColumns():在傳入的DataTable中,要當Key的欄位.例如org與no欄位(是陣列所以可接受多個欄位)
            '3.RedirColumn:要轉向(由1變成多欄)的欄位
            '4.aryNewColValue():變成多欄後,這些新增欄位所對應的值
            '5.OutSymbol:(替代字串),變成多欄後,這些新增欄位的值可以使用(替代字串),例如變成"*",或"V"
            '回傳值:
            '一個調整過後的DataTable
            '=============================================================================================

            Dim intAryFlag As Integer
            '防呆-------------------------------------------------
            If (theDataTable Is Nothing) Then
                Throw New Exception("輸入了無效的DataTable")
            End If
            '
            For intAryFlag = 0 To theKeyColumns.Length - 1
                If (theDataTable.Columns.IndexOf(theKeyColumns(intAryFlag)) = -1) Then
                    Throw New Exception("輸入了不存在的KeyColumn")
                End If
            Next
            '
            If (theDataTable.Columns.IndexOf(RedirColumn) = -1) Then
                Throw New Exception("輸入了不存在的RedirColumn")
            End If
            '
            If aryNewColValue.Length <= 0 Then
                Throw New Exception("要轉成的新欄位沒有指定值!")
            End If
            '-----------------------------------------------------

            Dim NewdataTable As DataTable = theDataTable.Clone
            'NewdataTable.Rows.Clear()

            Dim Hash As New Hashtable

            '為NewdataTable加上新欄位
            For intAryFlag = 0 To aryNewColValue.Length - 1
                Dim theNewCol As New DataColumn(RedirColumn & "_" & intAryFlag + 1)
                NewdataTable.Columns.Add(theNewCol)
                Hash.Add(aryNewColValue(intAryFlag), RedirColumn & "_" & intAryFlag + 1)
            Next

            If theDataTable.Rows.Count > 0 Then
                '組成arylistFilterItem----------------------------------------------------------
                Dim arylistFilterItem As ArrayList
                arylistFilterItem = ConsistFilterItems(theDataTable, theKeyColumns)
                '-------------------------------------------------------------------------------
                For intAryFlag = 0 To arylistFilterItem.Count - 1
                    '一組Key篩選一個群組(多筆)資料列
                    Dim theRows() As DataRow = theDataTable.Select(arylistFilterItem.Item(intAryFlag))

                    If theRows.Length > 0 Then
                        '第一列拿來做加工
                        Dim theNewRow As DataRow = NewdataTable.NewRow
                        theNewRow.ItemArray = theRows(0).ItemArray

                        '組成Redir陣列--------------------------------------------
                        Dim aryRedir As New ArrayList

                        For Each theRow As DataRow In theRows
                            If aryRedir.IndexOf(theRow.Item(RedirColumn)) = -1 Then
                                aryRedir.Add(theRow.Item(RedirColumn))
                            End If
                        Next
                        '-------------------------------------------------------------

                        '將 aryRedir內的元素逐一塞到(theNewRow)對應的欄位-------------
                        Dim inrRedirFlag As Integer
                        For inrRedirFlag = 0 To aryRedir.Count - 1
                            Dim theColName As String = Hash.Item(aryRedir.Item(inrRedirFlag).ToString())
                            If Not theColName Is Nothing Then
                                If OutSymbol = "" Then
                                    theNewRow.Item(theColName) = aryRedir.Item(inrRedirFlag)
                                Else
                                    theNewRow.Item(theColName) = OutSymbol
                                End If
                            End If
                        Next
                        '-------------------------------------------------------------
                        NewdataTable.Rows.Add(theNewRow)
                    End If

                Next

            End If

            '為NewdataTable調整新欄位
            For intAryFlag = aryNewColValue.Length - 1 To 0 Step -1
                Dim theColName As String = Hash.Item(aryNewColValue(intAryFlag).ToString())
                NewdataTable.Columns.Item(theColName).SetOrdinal(NewdataTable.Columns.IndexOf(RedirColumn) + 1)
            Next
            '刪舊的
            Dim theIndex As Integer = NewdataTable.Columns.IndexOf(RedirColumn)
            NewdataTable.Columns.RemoveAt(theIndex)

            NewdataTable.AcceptChanges()
            Return NewdataTable

        End Function

#End Region

#Region " 組成arylistFilterItems "
        Shared Function ConsistFilterItems(ByVal theDataTable As DataTable, ByVal theColumns() As String) As ArrayList

            Dim theArraylist As New ArrayList

            If (theColumns Is Nothing) OrElse theColumns.Length = 0 Then
                theArraylist.Add("")
            Else
                For Each theRow As DataRow In theDataTable.Rows
                    Dim intAryFlag As Integer
                    Dim strFilterItem As String = ""
                    Dim strAnd As String = " and "
                    '
                    For intAryFlag = 0 To theColumns.Length - 1
                        strFilterItem &= theColumns(intAryFlag) & "='" & EmptyDBNull(theRow.Item(theColumns(intAryFlag))) & "'" & strAnd
                    Next
                    '
                    If strFilterItem.Length > 1 Then
                        strFilterItem = strFilterItem.Remove(strFilterItem.LastIndexOf(strAnd))
                    End If
                    '
                    If theArraylist.IndexOf(strFilterItem) = -1 Then
                        theArraylist.Add(strFilterItem)
                    End If
                Next
            End If

            Return theArraylist
        End Function

#End Region

#Region "將DBnull的DataRow變成空字串"

        Shared Function EmptyDBNull(ByVal theObject As Object) As String

            If IsDBNull(theObject) Then
                theObject = String.Empty
            Else
                theObject = theObject.ToString
            End If

            Return theObject

        End Function

#End Region

        Shared Sub ControlExportToWord(ByRef theControl As Object, ByVal theFileName As String)
            ControlExportToFile(theControl, theFileName, ExportFileType.MS_Word)
        End Sub

        Shared Sub ControlExportToExcel(ByRef theControl As Object, ByVal theFileName As String)
            ControlExportToFile(theControl, theFileName, ExportFileType.MS_Excel)
        End Sub

        Shared Sub ControlExportToFile(ByRef theControl As Object, ByVal theFileName As String, ByVal theFileType As ExportFileType)

            HttpContext.Current.Response.Clear()

            If theFileType = ExportFileType.MS_Word Then
                HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.GetEncoding("Big5")
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & theFileName & ".doc")
                HttpContext.Current.Response.ContentType = "application/vnd.ms-word"
            ElseIf theFileType = ExportFileType.MS_Excel Then
                HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.GetEncoding("Big5")
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & theFileName & ".xls")
                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
            Else
                'HttpContext.Current.Response.ContentType = "Application/octet-stream"
            End If

            HttpContext.Current.Response.ContentType = "application/vnd.xls"
            Dim stringWrite As System.IO.StringWriter = New System.IO.StringWriter
            Dim htmlWrite As System.Web.UI.HtmlTextWriter = New HtmlTextWriter(stringWrite)
            theControl.RenderControl(htmlWrite)
            HttpContext.Current.Response.Write(stringWrite.ToString)
            HttpContext.Current.Response.End()

        End Sub


#End Region

#End Region

    End Class

#End Region

#Region " {TemplateContext} "
    Public Class TemplateContext1

        Public Enum MhtStyle
            Word
            Excel
        End Enum

#Region " {TemplateContext}-Field "

        Private _theContext As String 'Method中也會用到

#End Region

#Region " {TemplateContext}-Property "

        '取得樣板是哪種mht
        Private _MhtStyle As MhtStyle
        Public ReadOnly Property GetMhtStyle() As MhtStyle
            Get
                Return _MhtStyle
            End Get
        End Property

        Private _PageRepeatSCode As String = "<PageRepeatArea>"
        Public ReadOnly Property PageRepeatSCode() As String
            Get
                Return _PageRepeatSCode
            End Get
        End Property

        Private _PageRepeatECode As String = "</PageRepeatArea>"
        Public ReadOnly Property PageRepeatECode() As String
            Get
                Return _PageRepeatECode
            End Get
        End Property

        Private _RepeatSCode As String = "<RepeatArea>"
        Public ReadOnly Property RepeatSCode() As String
            Get
                Return _RepeatSCode
            End Get
        End Property

        Private _RepeatECode As String = "</RepeatArea>"
        Public ReadOnly Property RepeatECode() As String
            Get
                Return _RepeatECode
            End Get
        End Property

        Private _SumSCode As String = "<SumArea>"
        Public ReadOnly Property SumSCode() As String
            Get
                Return _SumSCode
            End Get
        End Property

        Private _SumECode As String = "</SumArea>"
        Public ReadOnly Property SumECode() As String
            Get
                Return _SumECode
            End Get
        End Property

        Private _TotalSCode As String = "<TotalArea>"
        Public ReadOnly Property TotalSCode() As String
            Get
                Return _TotalSCode
            End Get
        End Property

        Private _TotalECode As String = "</TotalArea>"
        Public ReadOnly Property TotalECode() As String
            Get
                Return _TotalECode
            End Get
        End Property

        '是否為一資料列顯示一頁(信件式)
        Private _IsOneRowOnePage As Boolean
        Public ReadOnly Property IsOneRowOnePage() As Boolean
            Get
                Return _IsOneRowOnePage
            End Get
        End Property

        Private _HeadFootArea As String
        Public ReadOnly Property HeadFootArea() As String
            Get
                Return _HeadFootArea
            End Get
        End Property

        Private _PageRepeatArea As String
        Public ReadOnly Property PageRepeatArea() As String
            Get
                Return _PageRepeatArea
            End Get
        End Property

        Private _RepeatArea As ArrayList
        Public ReadOnly Property RepeatArea() As ArrayList
            Get
                Return _RepeatArea
            End Get
        End Property

        Private _SumArea As ArrayList
        Public ReadOnly Property SumArea() As ArrayList
            Get
                Return _SumArea
            End Get
        End Property

        Private _TotalArea As ArrayList
        Public ReadOnly Property TotalArea() As ArrayList
            Get
                Return _TotalArea
            End Get
        End Property

#End Region

#Region " {TemplateContext}-Constructor "
        Public Sub New(ByVal theFilePath As String, ByVal theEncoding As System.Text.Encoding, ByVal thaParam() As String)

            Dim oSR As New System.IO.StreamReader(theFilePath, theEncoding)
            'Dim oSR As New System.IO.StreamReader(Current.Server.MapPath(Current.Request.ApplicationPath & "/" & _FilePath), _ExportFileCode)
            _theContext = oSR.ReadToEnd()


            '-------------------------------------------------
            '先置換不重複的參數,
            '目的在於:
            '1.有些參數被包含在RepeatArea內(EM3010信的內容)
            '2.mht檔中,PageRepeatArea沒涵蓋到 ##P##
            '-------------------------------------------------
            If (thaParam IsNot Nothing) AndAlso (thaParam.Length > 0) Then
                For i As Integer = 0 To thaParam.Length - 1
                    _theContext = _theContext.Replace("##P" & i + 1 & "##", (GetCharCodes(thaParam(i))))
                Next
            End If

            '設好每一個樣板
            GetHeadFootArea()
            GetPageRepeatArea()
            GetRepeatArea()
            GetSumArea()
            GetTotalArea()
            '
            If Me.PageRepeatArea.Trim = _RepeatSCode & _RepeatECode Then
                '當PageRepeatArea的內容為<RepeatArea></RepeatArea>時表示是信件式
                _IsOneRowOnePage = True
            End If

            If Me.HeadFootArea.IndexOf("schemas-microsoft-com:office:word") > 0 Then
                _MhtStyle = MhtStyle.Word
            ElseIf Me.HeadFootArea.IndexOf("schemas-microsoft-com:office:excel") > 0 Then
                _MhtStyle = MhtStyle.Excel
            End If

        End Sub
#End Region

#Region " {TemplateContext}-Methods "

        Private Sub GetHeadFootArea() '含<PageRepeatArea></PageRepeatArea>

            Try
                '挖空心
                _HeadFootArea = _theContext.Remove(_theContext.IndexOf(_PageRepeatSCode) + (_PageRepeatSCode).Length, (_theContext.IndexOf(_PageRepeatECode) - _theContext.IndexOf(_PageRepeatSCode) - (_PageRepeatSCode).Length))
            Catch ex As Exception
                Throw New Exception("PageRepeatArea的標記讀取出錯")
            End Try

        End Sub

        Private Sub GetPageRepeatArea() '不含<PageRepeatArea></PageRepeatArea>,但含數組<RepeatArea></RepeatArea>

            Try
                '去頭尾
                Dim thePageRepeatArea As String = _theContext.Substring(_theContext.IndexOf(_PageRepeatSCode) + (_PageRepeatSCode).Length, (_theContext.IndexOf(_PageRepeatECode) - _theContext.IndexOf(_PageRepeatSCode) - (_PageRepeatSCode).Length))

                '挖空心
                Dim indexS As Integer
                Dim indexE As Integer
                Dim indexStart As Integer = 0

                While thePageRepeatArea.IndexOf(_RepeatSCode, indexStart) >= 0

                    indexS = thePageRepeatArea.IndexOf(_RepeatSCode, indexStart)
                    indexE = thePageRepeatArea.IndexOf(_RepeatECode, indexStart)

                    thePageRepeatArea = thePageRepeatArea.Remove(indexS + _RepeatSCode.Length, indexE - indexS - _RepeatSCode.Length)

                    indexStart = indexS + _RepeatSCode.Length + _RepeatECode.Length - 1 '減1是避免_RepeatECode剛好是最後一字

                End While

                _PageRepeatArea = thePageRepeatArea

            Catch ex As Exception
                Throw New Exception("PageRepeatArea的標記讀取出錯")
            End Try

        End Sub

        '注意!!RepeatArea是一個 ArrayList 因為多個 Table 時，會有多種<RepeatArea></RepeatArea>的組合
        Private Sub GetRepeatArea() '不含<RepeatArea></RepeatArea>

            Try
                Dim theArrayList As New ArrayList

                Dim indexS As Integer
                Dim indexE As Integer
                Dim indexStart As Integer = 0

                While _theContext.IndexOf(_RepeatSCode, indexStart) >= 0

                    indexS = _theContext.IndexOf(_RepeatSCode, indexStart)
                    indexE = _theContext.IndexOf(_RepeatECode, indexStart)
                    indexStart = indexE + _RepeatECode.Length

                    Dim theRepeatArea As String = _theContext.Substring(indexS + _RepeatSCode.Length, indexE - indexS - _RepeatSCode.Length)
                    theArrayList.Add(theRepeatArea)

                End While

                _RepeatArea = theArrayList

            Catch ex As Exception
                Throw New Exception("RepeatArea的標記讀取出錯")
            End Try

        End Sub

        '注意!!SumArea是一個 ArrayList 因為多個 Table 時，會有多種<SumArea></SumArea>的組合
        Private Sub GetSumArea()

            Try
                Dim theArrayList As New ArrayList

                Dim indexS As Integer
                Dim indexE As Integer
                Dim indexStart As Integer = 0

                While _theContext.IndexOf(_SumSCode, indexStart) >= 0

                    indexS = _theContext.IndexOf(_SumSCode, indexStart)
                    indexE = _theContext.IndexOf(_SumECode, indexStart)
                    indexStart = indexE + _SumECode.Length

                    Dim theSumArea As String = _theContext.Substring(indexS + _SumSCode.Length, indexE - indexS - _SumSCode.Length)
                    theArrayList.Add(theSumArea)

                End While

                _SumArea = theArrayList

            Catch ex As Exception
                Throw New Exception("SumArea的標記讀取出錯")
            End Try

        End Sub

        '注意!!TotalArea是一個 ArrayList 因為多個 Table 時，會有多種<TotalArea></TotalArea>的組合
        Private Sub GetTotalArea()

            Try
                Dim theArrayList As New ArrayList

                Dim indexS As Integer
                Dim indexE As Integer
                Dim indexStart As Integer = 0

                While _theContext.IndexOf(_TotalSCode, indexStart) >= 0

                    indexS = _theContext.IndexOf(_TotalSCode, indexStart)
                    indexE = _theContext.IndexOf(_TotalECode, indexStart)
                    indexStart = indexE + _TotalECode.Length

                    Dim theTotalArea As String = _theContext.Substring(indexS + _TotalSCode.Length, indexE - indexS - _TotalSCode.Length)
                    theArrayList.Add(theTotalArea)

                End While

                _TotalArea = theArrayList

            Catch ex As Exception
                Throw New Exception("TotalArea的標記讀取出錯")
            End Try

        End Sub

#End Region

    End Class
#End Region

#Region " {TMPTable} "

    Public Class TMPTable1

        Public Enum TableStyle
            NoChangeTable
            CombineTable
            RedirTable
            RowSpanTable
        End Enum

#Region " {TMPTable}-Field "


#End Region

#Region " {TMPTable}-Property "

        'TableStyle
        Private _TableStyle As TableStyle
        Public ReadOnly Property GetTableStyle() As TableStyle
            Get
                Return _TableStyle
            End Get
        End Property

        'TablesArylist
        Private _TablesArylist As ArrayList
        Public ReadOnly Property TablesArylist() As ArrayList
            Get
                Return _TablesArylist
            End Get
        End Property

        '由哪些欄位組成Key欄位
        Private _KeyColumns() As String
        Public Property KeyColumns() As String()
            Get
                Return _KeyColumns
            End Get
            Set(ByVal Value As String())
                _KeyColumns = Value
            End Set
        End Property

        '由哪些欄位組成Combine欄位
        Private _CombinColumns() As String
        Public Property CombinColumns() As String()
            Get
                Return _CombinColumns
            End Get

            Set(ByVal Value As String())
                _CombinColumns = Value
            End Set
        End Property

        'Combine的符號
        Private _SepChar As Char
        Public Property SepChar() As Char
            Get
                Return _SepChar
            End Get

            Set(ByVal Value As Char)
                If Value = String.Empty Then
                    Value = ","
                End If
                _SepChar = Value
            End Set
        End Property

        '由哪些欄位組成Redirect欄位
        Private _RedirColumn As String
        Public Property RedirColumn() As String
            Get
                Return _RedirColumn
            End Get

            Set(ByVal Value As String)
                _RedirColumn = Value
            End Set
        End Property

        'Redirect後各新欄位的值
        Private _RedirNewColValue() As String
        Public Property RedirNewColValue() As String()
            Get
                Return _RedirNewColValue
            End Get

            Set(ByVal Value As String())
                _RedirNewColValue = Value
            End Set
        End Property

        'Redir的符號
        Private _MarkChar As Char
        Public Property MarkChar() As Char
            Get
                Return _MarkChar
            End Get

            Set(ByVal Value As Char)
                If Value = String.Empty Then
                    Value = "*"
                End If
                _MarkChar = Value
            End Set
        End Property

        '由哪些欄位組成RowSpan欄位
        Private _RowSpanColumns() As String
        Public Property RowSpanColumns() As String()
            Get
                Return _RowSpanColumns
            End Get

            Set(ByVal Value As String())
                _RowSpanColumns = Value
            End Set
        End Property

        '是否顯示表格尾合計
        Private _ShowSumArea As Boolean
        Public Property ShowSumArea() As Boolean
            Get
                Return _ShowSumArea
            End Get
            Set(ByVal Value As Boolean)
                _ShowSumArea = Value
            End Set
        End Property

        '是否顯示表格尾總計
        Private _ShowTotalArea As Boolean
        Public Property ShowTotalArea() As Boolean
            Get
                Return _ShowTotalArea
            End Get
            Set(ByVal Value As Boolean)
                _ShowTotalArea = Value
            End Set
        End Property

        '表格總計
        Private _TableTotalValue As Decimal
        Public Property TableTotalValue() As Decimal
            Get
                Return _TableTotalValue
            End Get
            Set(ByVal Value As Decimal)
                _TableTotalValue = Value
            End Set
        End Property

#End Region

#Region " {TMPTable}-Constructor "

        Public Sub New()
            _TablesArylist = New ArrayList
        End Sub

#End Region

#Region " {TMPTable}-Methods "

        Public Sub InitTableStyle()

            '最前面優先權是最後
            If (_KeyColumns IsNot Nothing) AndAlso (_KeyColumns.Length > 0) Then

                '做RowSpan
                If (_RowSpanColumns IsNot Nothing) AndAlso (_RowSpanColumns.Length > 0) Then
                    _TableStyle = TableStyle.RowSpanTable
                End If

                '做轉向
                If (_RedirColumn IsNot Nothing) AndAlso (_RedirColumn <> String.Empty) Then
                    If (_RedirNewColValue IsNot Nothing) AndAlso (_RedirNewColValue.Length > 0) Then
                        _TableStyle = TableStyle.RedirTable
                    End If

                End If

                '做合併
                If (_CombinColumns IsNot Nothing) AndAlso (_CombinColumns.Length > 0) Then
                    If (_SepChar <> String.Empty) Then
                        _TableStyle = TableStyle.CombineTable
                    End If
                End If

            End If

        End Sub

        Public Function GetNoChangeTableHtml(ByRef theDataTable As DataTable, ByVal theTemRepeatArea As String, ByVal IsOneRowOnePage As Boolean, ByVal strPageSep As String) As String
            Return MergeDataTableAndRepeatArea(theDataTable, theTemRepeatArea, IsOneRowOnePage, strPageSep)
        End Function

        Public Function GetCombinedTableHtml(ByRef theDataTable As DataTable, ByVal theTemRepeatArea As String) As String
            theDataTable = DataTableFunc.DataTableComBinCols(theDataTable, _KeyColumns, _CombinColumns, _SepChar)
            Return MergeDataTableAndRepeatArea(theDataTable, theTemRepeatArea)
        End Function

        Public Function GetRediredTableHtml(ByRef theDataTable As DataTable, ByVal theRepeatArea As String) As String
            theDataTable = DataTableFunc.DataTableRedirCol(theDataTable, _KeyColumns, _RedirColumn, _RedirNewColValue, _MarkChar)
            Return MergeDataTableAndRepeatArea(theDataTable, theRepeatArea)
        End Function

        Public Function GetRowSpanedHtml(ByRef theDataTable As DataTable, ByVal theRepeatArea As String) As String
            Return DataTableRowSpanCols(theDataTable, _KeyColumns, _RowSpanColumns, theRepeatArea)
        End Function

        Private Function MergeDataTableAndRepeatArea(ByRef theDataTable As DataTable, ByVal theTemRepeatArea As String, Optional ByVal IsOneRowOnePage As Boolean = False, Optional ByVal strPageSep As String = "") As String

            Dim theArrayList As New ArrayList

            For i As Integer = 0 To theDataTable.Rows.Count - 1
                '==================================================
                '一筆Row就做一份RepeatArea(表格式或信件式都一樣)
                '每一列,都要置換RepeatArea的變數
                '若使用轉向,則欄位名稱會變
                '--------------------------------------------------
                Dim theRepeatArea As String = theTemRepeatArea

                For Each theDataColumn As DataColumn In theDataTable.Columns
                    '若要輸出的表單中有這樣的欄位則替換
                    If IsDBNull(theDataTable.Rows(i).Item(theDataColumn.ColumnName)) Then
                        theRepeatArea = theRepeatArea.Replace("##" & theDataColumn.ColumnName & "##", "")
                    Else
                        theRepeatArea = theRepeatArea.Replace("##" & theDataColumn.ColumnName & "##", GetCharCodes(theDataTable.Rows(i).Item(theDataColumn.ColumnName)))
                    End If
                Next


                If IsOneRowOnePage = True Then
                    '==============================================
                    '            處理信件式報表的分頁碼
                    '----------------------------------------------
                    '因為一個 DataRow 就產出一頁所以在此加分頁碼
                    If i < theDataTable.Rows.Count - 1 Then '非最後一筆要加上分頁符號
                        theRepeatArea = theRepeatArea & strPageSep
                    End If
                    'Else
                    '    '表格式:處理是否顯示合計欄位
                    '    '最後一筆才做
                    '    If i = theDataTable.Rows.Count - 1 Then

                    '        If Me._ShowTailSum = True Then
                    '            theRepeatArea &= AddTheRow("sum", theTemRepeatArea, Me._TailSumColumns, theJ)
                    '        End If

                    '        If Me._ShowTailTotal = True And IsFinal = True Then
                    '            theRepeatArea &= AddTheRow("total", theTemRepeatArea, Me._TailSumColumns, theJ)
                    '        End If

                    '    End If

                End If

                theArrayList.Add(theRepeatArea)
            Next


            Return String.Concat(theArrayList.ToArray)

        End Function

        '做Rowspan
        Private Function DataTableRowSpanCols(ByRef theDataTable As DataTable, ByVal theKeyColumns() As String, ByVal theRowSpanColumns() As String, ByVal theRepeatArea As String) As String
            '=============================================================================================
            '傳入參數:
            '1.theDataTable:要調整的DataTable
            '2.theKeyColumns():在傳入的DataTable中,要當Key的欄位.例如org與no欄位(是陣列所以可接受多個欄位)
            '3.theRowSpanColumns:要做RowSpan的數個欄位
            '回傳值:
            '整個DataTable變成已經具有RowSpan的HTML字串
            '=============================================================================================

            '因為是 Private Function 所以不用做防呆,因為先前已經有防

            '組成arylistRowSpanFilterItem---------------------------------------------------
            Dim arylistRowSpanFilterItem As ArrayList
            arylistRowSpanFilterItem = FilterItems(theDataTable, theKeyColumns)
            '-------------------------------------------------------------------------------

            Dim arylistAllRecords As New ArrayList '裝各列資料的總集合

            For intAryFlag As Integer = 0 To arylistRowSpanFilterItem.Count - 1

                '一組Key篩選一個群組(多筆)資料列
                Dim theRows() As DataRow = theDataTable.Select(arylistRowSpanFilterItem.Item(intAryFlag))

                Dim theRowSpanColumnsHash As New Hashtable '準備RowSpanColumnsHash

                For intColumnFlag As Integer = 0 To theRowSpanColumns.Length - 1
                    theRowSpanColumnsHash.Add(theRowSpanColumns(intColumnFlag), New Hashtable)
                Next

                '-------------------------------------------------------------------------------
                '填好RowSpanColumnsHash
                '-------------------------------------------------------------------------------
                If theRows.Length > 0 Then '為theRows做 RowSpan

                    Dim intFlag(theRowSpanColumns.Length - 1) As Integer '因為ColumnsHash的項目會亂跳,所以用intFlag紀錄ColumnsHash最近增加的那個項目的RowIndex

                    'ColumnsHash說明---------------------------
                    '(RowIndex,RowSpan) 
                    '例(0, 1) 索引0的Row設RowSpan=1
                    '例(1, 1) 索引1的Row設RowSpan=1
                    '例(2, 1) 索引2的Row設RowSpan=1
                    '例(3, 3) 索引3的Row設RowSpan=3
                    '例(4, 0) 索引4的Row設RowSpan=0
                    '例(5, 0) 索引5的Row設RowSpan=0
                    '例(6, 2) 索引6的Row設RowSpan=2
                    '例(7, 0) 索引7的Row設RowSpan=0
                    '因為ColumnsHash的項目會亂跳,所以用intFlag紀錄ColumnsHash最近增加的那個項目的RowIndex
                    '------------------------------------------
                    For theRowsFlag As Integer = 0 To theRows.Length - 1
                        For theColumnsFlag As Integer = 0 To theRowSpanColumns.Length - 1
                            '把 HashTMP 當成 ColumnsHash 的縮寫
                            Dim HashTMP As Hashtable = theRowSpanColumnsHash.Item(theRowSpanColumns(theColumnsFlag))

                            If theRowsFlag = 0 Then
                                '若此列是第一筆Row時,幫 ColumnsHash 增加一筆資料 (0,1)
                                HashTMP.Add(theRowsFlag.ToString, 1)
                                intFlag(theColumnsFlag) = theRowsFlag
                            Else
                                '寶琳說有null時會有Bug所以加 EmptyDBNull()
                                If EmptyDBNull(theRows(theRowsFlag).Item(theRowSpanColumns(theColumnsFlag))) = EmptyDBNull(theRows(intFlag(theColumnsFlag)).Item(theRowSpanColumns(theColumnsFlag))) Then
                                    '若此列的值等於ColumnsHash最近增加的那個項目的RowIndex的值
                                    HashTMP.Add(theRowsFlag.ToString, 0) 'RowSpan=0表示要消掉的
                                    HashTMP.Item(intFlag(theColumnsFlag).ToString) += 1 '累加RowSpan值
                                Else
                                    '若此列的值不等於ColumnsHash最近增加的那個項目的RowIndex的值
                                    HashTMP.Add(theRowsFlag.ToString, 1) 'RowSpan=1
                                    intFlag(theColumnsFlag) = theRowsFlag '累加intFlag的值
                                End If

                            End If
                        Next
                    Next

                    '宣告來裝一個列的各欄"樣板"資料
                    '有時候樣板有欄位,但是Datatable沒有此欄位(例如備註,備註1),沒有這個欄位也要放對應的HTML
                    '所以用ArrayList不用Hash
                    Dim arylistRepeatAreaCells As New ArrayList

                    Dim theTMPRepeatArea As String = theRepeatArea

                    While theTMPRepeatArea.IndexOf("<td") >= 0

                        Dim strHTML As String = theTMPRepeatArea.Substring(theTMPRepeatArea.IndexOf("<td"), theTMPRepeatArea.IndexOf("</td>") - theTMPRepeatArea.IndexOf("<td") + ("</td>").Length)

                        theTMPRepeatArea = theTMPRepeatArea.Remove(theTMPRepeatArea.IndexOf("<td"), theTMPRepeatArea.IndexOf("</td>") - theTMPRepeatArea.IndexOf("<td") + ("</td>").Length)

                        '將重複的區塊依每一組<td>分割到arylistRepeatAreaCells
                        arylistRepeatAreaCells.Add(strHTML)
                    End While

                    '---------------------------------------------------------------
                    '開始逐列Replace變數,把該列所組成的HTML碼放到陣列
                    '---------------------------------------------------------------
                    Dim intRowFlag As Integer
                    Dim intColFlag As Integer

                    For intRowFlag = 0 To theRows.Length - 1

                        '因為跑迴圈所以清空再來裝
                        Dim arylistTheRecordCells As New ArrayList
                        Dim strTheRecd As String = String.Empty
                        '因為跑迴圈所以清空再來裝
                        arylistTheRecordCells.Clear()

                        For intColFlag = 0 To arylistRepeatAreaCells.Count - 1

                            Dim strRepeatAreaCell As String = arylistRepeatAreaCells(intColFlag)
                            Dim tmpColName As String

                            Try
                                tmpColName = strRepeatAreaCell.Substring(strRepeatAreaCell.IndexOf("##") + 2, strRepeatAreaCell.LastIndexOf("##") - (strRepeatAreaCell.IndexOf("##") + 2))
                            Catch ex As Exception
                                tmpColName = String.Empty
                            End Try

                            '若樣版檔有##XXXX##
                            If tmpColName <> String.Empty Then

                                Dim HasgTMP As Hashtable = theRowSpanColumnsHash.Item(tmpColName)

                                '若現在這一個欄位是要RowSpan的欄位,則指定RowSpan
                                If Array.IndexOf(theRowSpanColumns, tmpColName) >= 0 Then

                                    If HasgTMP.Item(intRowFlag.ToString) = 0 Then
                                        strRepeatAreaCell = ""
                                    Else
                                        strRepeatAreaCell = strRepeatAreaCell.Replace("<td", "<td rowspan=3D" & HasgTMP.Item(intRowFlag.ToString))
                                    End If
                                End If

                                '置換變數
                                If IsDBNull(theRows(intRowFlag).Item(tmpColName)) Then
                                    strRepeatAreaCell = strRepeatAreaCell.Replace("##" & theRows(intRowFlag).Table.Columns(tmpColName).ColumnName & "##", "")
                                Else
                                    strRepeatAreaCell = strRepeatAreaCell.Replace("##" & theRows(intRowFlag).Table.Columns(tmpColName).ColumnName & "##", GetCharCodes(theRows(intRowFlag).Item(tmpColName)))
                                End If

                                If strRepeatAreaCell.IndexOf("@@RowSpanCount@@") > 0 Then
                                    strRepeatAreaCell = strRepeatAreaCell.Replace("@@RowSpanCount@@", HasgTMP.Item(intRowFlag.ToString))
                                End If


                            End If

                            arylistTheRecordCells.Add(strRepeatAreaCell)

                        Next

                        strTheRecd = "<tr>" & String.Concat(arylistTheRecordCells.ToArray) & "</tr>"

                        arylistAllRecords.Add(strTheRecd)

                    Next

                End If

            Next

            Return String.Concat(arylistAllRecords.ToArray)

        End Function

#End Region

    End Class

#End Region

    '===============================================
    '有的沒有的Function
    '===============================================

#Region " FileUpDownIOFunc "
    Public Class FileUpDownIOFunc1

#Region " 靜態方法-ResponseWrite大檔案 "
        Shared Sub DoResponseWriteBigFile(ByVal theFilePathName As String) 'Response.BinaryWrite()'大於20MB會失敗

            Dim iStream As System.IO.Stream

            ' Buffer to read 10K bytes in chunk:
            Dim buffer(10000) As Byte

            ' Length of the file:
            Dim length As Integer

            ' Total bytes to read:
            Dim dataToRead As Long

            ' Identify the file name.
            Dim filename As String = System.IO.Path.GetFileName(theFilePathName)

            Try
                ' Open the file.
                iStream = New System.IO.FileStream(theFilePathName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read)

                ' Total bytes to read:
                dataToRead = iStream.Length

                HttpContext.Current.Response.ContentType = "application/octet-stream"
                HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.GetEncoding("Big5")
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & filename)
                'HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" & Chr(34) & System.Web.HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8) & Chr(34))

                ' Read the bytes.
                While dataToRead > 0
                    ' Verify that the client is connected.
                    If HttpContext.Current.Response.IsClientConnected Then
                        ' Read the data in buffer
                        length = iStream.Read(buffer, 0, 10000)

                        ' Write the data to the current output stream.
                        HttpContext.Current.Response.OutputStream.Write(buffer, 0, length)

                        ' Flush the data to the HTML output.
                        HttpContext.Current.Response.Flush()

                        ReDim buffer(10000) ' Clear the buffer
                        dataToRead = dataToRead - length
                    Else
                        'prevent infinite loop if user disconnects
                        dataToRead = -1
                    End If
                End While

            Catch ex As Exception
                ' Trap the error, if any.
                HttpContext.Current.Response.Write("Error : " & ex.Message)
            Finally
                If IsNothing(iStream) = False Then
                    ' Close the file.
                    iStream.Close()
                End If
            End Try

        End Sub
#End Region

    End Class
#End Region

#Region " StringFunc "

    Public Class StringFunc1

#Region " 靜態方法-若是中文轉換成內碼否則不變 "
        Shared Function GetCharCodes(ByVal strTMP As String) As String
            Dim strResult As String = ""
            If strTMP Is Nothing Then Return String.Empty

            Dim aryChar = strTMP.ToCharArray

            Dim i As Integer

            For i = 0 To aryChar.Length - 1
                Dim theCharCode As String
                If (Asc(aryChar(i)) >= 0) And (Asc(aryChar(i)) <= 127) Then
                    theCharCode = aryChar(i)
                Else
                    theCharCode = "&#" & Char.ConvertToUtf32(aryChar(i), 0) & ";"
                End If
                strResult = strResult & theCharCode
            Next

            Return strResult
        End Function
#End Region

#Region " 靜態方法-將一般字串轉成SQL字串 "
        '  A→'A'
        '  A,B,C→'A','B','C'
        'Input:
        '       strTMP:輸入的字串
        '       strSep:分隔符號(預設 ",")
        Shared Function SQLStr(ByVal strTMP As String, Optional ByVal strSep As String = ",") As String
            Dim aryTMP() As String = strTMP.Split(strSep)
            Dim i As Integer
            SQLStr = ""

            For i = 0 To aryTMP.Length - 1
                SQLStr = SQLStr & "'" & aryTMP(i) & "'" & strSep
            Next

            If SQLStr.IndexOf(strSep) >= 0 Then
                SQLStr = SQLStr.Remove(SQLStr.LastIndexOf(strSep), 1)
            End If
        End Function
#End Region

#Region " 靜態方法-將阿拉伯數字轉成中文格式 "
        '有輸出單位時   "100500600023"→"一千零五億零六十萬零二十三"
        '有無出單位時   "100500600023"→"一零零五零零六零零零二三"
        'Input:
        'intTMP:輸入的字串
        'bolUseUnit:是否輸出單位(預設True)

        Enum WordCase
            Upper
            Lower
            Ara
        End Enum

        Shared Function ConvertToChiNum(ByVal intTMP As Long, Optional ByVal WordCase As WordCase = WordCase.Lower, Optional ByVal bolUseUnit As Boolean = True) As String
            Dim aryNum() As String = {"0", "一", "二", "三", "四", "五", "六", "七", "八", "九"}
            Dim aryUnit() As String = {"", "十", "百", "千", "萬", "十", "百", "千", "億", "十", "百", "千", "兆"}

            If WordCase = StringFunc.WordCase.Upper Then
                aryNum(1) = "壹"
                aryNum(2) = "貳"
                aryNum(3) = "參"
                aryNum(4) = "肆"
                aryNum(5) = "伍"
                aryNum(6) = "陸"
                aryNum(7) = "柒"
                aryNum(8) = "捌"
                aryNum(9) = "玖"
            ElseIf WordCase = StringFunc.WordCase.Ara Then
                aryNum(1) = "1"
                aryNum(2) = "2"
                aryNum(3) = "3"
                aryNum(4) = "4"
                aryNum(5) = "5"
                aryNum(6) = "6"
                aryNum(7) = "7"
                aryNum(8) = "8"
                aryNum(9) = "9"

            End If

            Dim strTMP As String = intTMP.ToString
            Dim strResult As String = ""
            Dim intI As Integer '原始字串的Index
            Dim intUnitFlag As Integer = 0 'aryUnit()的Index
            Dim intFlag As Integer = 1

            If bolUseUnit Then
                For intI = strTMP.Length - 1 To 0 Step -1
                    If (aryNum(strTMP.Substring(intI, 1)) = aryNum(0)) Then
                        '數字為零時不取單位 : 一萬零千零百五十改成一萬零零五十
                        strResult = aryNum(strTMP.Substring(intI, 1)) + strResult
                    Else
                        '一般情況下要取單位
                        Dim strNew As String
                        strNew = aryNum(strTMP.Substring(intI, 1)) + aryUnit(intUnitFlag)
                        If (intUnitFlag <= 7) And (intUnitFlag >= 5) Then
                            '若十萬或百萬或千萬有數字,但結果字串中無'萬'字則補萬字
                            If strResult.IndexOf(aryUnit(4)) = -1 Then
                                strNew = aryNum(strTMP.Substring(intI, 1)) + aryUnit(intUnitFlag) + aryUnit(4)
                            End If
                        ElseIf (intUnitFlag <= 11) And (intUnitFlag >= 9) Then
                            '若十億或百億或千億有數字,但結果字串中無'億'字則補億字
                            If strResult.IndexOf(aryUnit(8)) = -1 Then
                                strNew = aryNum(strTMP.Substring(intI, 1)) + aryUnit(intUnitFlag) + aryUnit(8)
                            End If
                        End If

                        strResult = strNew + strResult

                    End If

                    intUnitFlag += 1
                Next

                '將零零...改成零
                While intFlag <= strResult.Length - 1
                    If strResult.Substring(intFlag - 1, 1) = strResult.Substring(intFlag, 1) Then
                        strResult = strResult.Remove(intFlag, 1)
                    Else
                        intFlag += 1
                    End If
                End While

            Else
                '沒單位時:接受'零零'
                For intI = strTMP.Length - 1 To 0 Step -1
                    strResult = aryNum(strTMP.Substring(intI, 1)) + strResult
                Next
            End If

            '習慣規則 : 最後一字若是零要清除
            If strResult.EndsWith(aryNum(0)) Then
                strResult = strResult.Substring(0, strResult.Length - 1)
            End If

            '習慣規則 : 一十二月改成十二月,一十八題改成十八題
            If strResult.StartsWith(aryNum(1) & aryUnit(1)) Then
                strResult = strResult.Remove(0, 1)
            End If

            Return strResult

        End Function

#End Region

    End Class

#End Region

#Region " MathFunc "

    Public Class MathFunc1
#Region " 靜態方法-四蛇五鹿 "
        Public Enum OutInType
            OutIn45
            InAll
            OutAll
        End Enum

        Shared Function GetSingleNum(ByVal sngTMP As Single, ByVal level As Integer, ByVal theOutInType As OutInType) As String
            '入:1.進位 2.捨己(含尾數)
            '捨:捨己(含尾數)
            If sngTMP > 0 Then

                sngTMP = sngTMP * (10 ^ (level - 1))

                Select Case theOutInType

                    Case OutInType.OutIn45

                        If (sngTMP Mod 1) >= 0.5 Then '>= 0.5為了要避免0.40000000000000000000000000000009
                            sngTMP = (sngTMP + 1)
                        End If

                    Case OutInType.InAll

                        If (sngTMP Mod 1) > 0 Then '> 0為了要包含 0.000000000000000000000000000000000001
                            sngTMP = (sngTMP + 1)
                        End If

                    Case OutInType.OutAll

                End Select

                sngTMP = System.Convert.ToSingle(sngTMP.ToString.Split(".")(0))
                sngTMP = (sngTMP / (10 ^ (level - 1)))
            End If

            Return sngTMP

        End Function
#End Region

    End Class

#End Region

#Region " DataTableFunc "

    Public Class DataTableFunc1

#Region " 靜態方法-將某DataColumn做加總 "
        Shared Function SumColumn(ByVal theDataColumn As DataColumn) As Decimal
            Dim SumValue As Decimal = 0

            For Each theDataRow As DataRow In theDataColumn.Table.Rows
                Try
                    SumValue += theDataRow.Item(theDataColumn.ColumnName)
                Catch ex As Exception
                End Try
            Next

            Return SumValue

        End Function
#End Region

#Region " 靜態方法-合併 "

        Shared Function DataTableComBinCols(ByVal theDataTable As DataTable, ByVal theKeyColumns() As String, ByVal theCombinColumns() As String, Optional ByVal theSepChar As String = ",") As DataTable
            '=============================================================================================
            '傳入參數:
            '1.theDataTable:要調整的DataTable
            '2.theKeyColumns():由哪些欄位組成Key欄位
            '3.theCombinColumns():哪些欄位要合併多列的值
            '4.SepString:合併多列的值,所使用的分隔符號
            '回傳值:
            '一個調整過後的DataTable
            '=============================================================================================
            Dim intAryFlag As Integer

            '防呆-------------------------------------------------
            If (theDataTable Is Nothing) Then
                Throw New Exception("輸入了無效的DataTable")
            End If
            '
            For intAryFlag = 0 To theKeyColumns.Length - 1
                If (theDataTable.Columns.IndexOf(theKeyColumns(intAryFlag)) = -1) Then
                    Throw New Exception("輸入了不存在的KeyColumn")
                End If
            Next
            '
            For intAryFlag = 0 To theCombinColumns.Length - 1
                If (theDataTable.Columns.IndexOf(theCombinColumns(intAryFlag)) = -1) Then
                    Throw New Exception("輸入了不存在的theCombinColumns")
                End If
            Next
            '-----------------------------------------------------

            Dim NewdataTable As DataTable = theDataTable.Clone

            NewdataTable.Rows.Clear()

            If theDataTable.Rows.Count > 0 Then
                '組成arylistFilterItem----------------------------------------------------------
                Dim arylistFilterItem As ArrayList
                arylistFilterItem = FilterItems(theDataTable, theKeyColumns)
                '-------------------------------------------------------------------------------
                For intAryFlag = 0 To arylistFilterItem.Count - 1
                    '一組Key篩選一個群組(多筆)資料列
                    Dim theRows() As DataRow = theDataTable.Select(arylistFilterItem.Item(intAryFlag))

                    If theRows.Length > 0 Then
                        '第一列拿來做加工
                        Dim theNewRow As DataRow = NewdataTable.NewRow
                        theNewRow.ItemArray = theRows(0).ItemArray

                        '組好一個CombinSet--------------------------------------------
                        Dim aryCombinSet(theCombinColumns.Length - 1) As ArrayList

                        Dim intJ As Integer
                        For intJ = 0 To theCombinColumns.Length - 1
                            aryCombinSet(intJ) = New ArrayList
                        Next

                        For Each theRow As DataRow In theRows
                            Dim intCol As Integer
                            For intCol = 0 To theCombinColumns.Length - 1
                                '用Trim的原因:有一次從資料庫撈資料回來後，後面都有很多空白字元
                                If IsDBNull(theRow.Item(theCombinColumns(intCol))) Then
                                    theRow.Item(theCombinColumns(intCol)) = String.Empty
                                End If
                                Dim theValue As String = Trim(theRow.Item(theCombinColumns(intCol)))

                                If aryCombinSet(intCol).IndexOf(theValue & theSepChar) = -1 Then
                                    aryCombinSet(intCol).Add(theValue & theSepChar)
                                End If
                            Next
                        Next
                        '-------------------------------------------------------------

                        '利用NewRow與組好的CombinSet,產生一個OK的資料列---------------
                        Dim intColumnFlag As Integer
                        '將 aryCombinSet裡的每一個Array組成字串,替換舊的.
                        For intColumnFlag = 0 To theCombinColumns.Length - 1
                            Dim strTMP As String = String.Concat(aryCombinSet(intColumnFlag).ToArray)
                            theNewRow.Item(theCombinColumns(intColumnFlag)) = strTMP.Remove(strTMP.LastIndexOf(theSepChar))
                        Next
                        '-------------------------------------------------------------
                        NewdataTable.Rows.Add(theNewRow)
                    End If

                Next


            End If
            NewdataTable.AcceptChanges()
            Return NewdataTable

            Return Nothing

        End Function

#End Region

#Region " 靜態方法-轉向 "
        Shared Function DataTableRedirCol(ByVal theDataTable As DataTable, ByVal theKeyColumns() As String, ByVal theRedirColumn As String, ByVal aryNewColValue() As String, Optional ByVal MarkChar As Char = "") As DataTable
            '=============================================================================================
            '傳入參數:
            '1.theDataTable:要調整的DataTable
            '2.theKeyColumns():在傳入的DataTable中,要當Key的欄位.例如org與no欄位(是陣列所以可接受多個欄位)
            '3.RedirColumn:要轉向(由1變成多欄)的欄位
            '4.aryNewColValue():變成多欄後,這些新增欄位所對應的值
            '5.OutSymbol:(替代字串),變成多欄後,這些新增欄位的值可以使用(替代字串),例如變成"*",或"V"
            '回傳值:
            '一個調整過後的DataTable
            '=============================================================================================

            Dim intAryFlag As Integer
            '防呆-------------------------------------------------
            If (theDataTable Is Nothing) Then
                Throw New Exception("輸入了無效的DataTable")
            End If
            '
            For intAryFlag = 0 To theKeyColumns.Length - 1
                If (theDataTable.Columns.IndexOf(theKeyColumns(intAryFlag)) = -1) Then
                    Throw New Exception("輸入了不存在的KeyColumn")
                End If
            Next
            '
            If (theDataTable.Columns.IndexOf(theRedirColumn) = -1) Then
                Throw New Exception("輸入了不存在的RedirColumn")
            End If
            '
            If aryNewColValue.Length <= 0 Then
                Throw New Exception("要轉成的新欄位沒有指定值!")
            End If
            '-----------------------------------------------------

            Dim NewdataTable As DataTable = theDataTable.Clone
            'NewdataTable.Rows.Clear()

            Dim Hash As New Hashtable

            '為NewdataTable加上新欄位
            For intAryFlag = 0 To aryNewColValue.Length - 1
                Dim theNewCol As New DataColumn(theRedirColumn & "_" & intAryFlag + 1)
                NewdataTable.Columns.Add(theNewCol)
                Hash.Add(aryNewColValue(intAryFlag), theRedirColumn & "_" & intAryFlag + 1)
            Next

            If theDataTable.Rows.Count > 0 Then
                '組成arylistFilterItem----------------------------------------------------------
                Dim arylistFilterItem As ArrayList
                arylistFilterItem = FilterItems(theDataTable, theKeyColumns)
                '-------------------------------------------------------------------------------
                For intAryFlag = 0 To arylistFilterItem.Count - 1
                    '一組Key篩選一個群組(多筆)資料列
                    Dim theRows() As DataRow = theDataTable.Select(arylistFilterItem.Item(intAryFlag))

                    If theRows.Length > 0 Then
                        '第一列拿來做加工
                        Dim theNewRow As DataRow = NewdataTable.NewRow
                        theNewRow.ItemArray = theRows(0).ItemArray

                        '組成Redir陣列--------------------------------------------
                        Dim aryRedir As New ArrayList

                        For Each theRow As DataRow In theRows
                            If aryRedir.IndexOf(theRow.Item(theRedirColumn)) = -1 Then
                                aryRedir.Add(theRow.Item(theRedirColumn))
                            End If
                        Next
                        '-------------------------------------------------------------

                        '將 aryRedir內的元素逐一塞到(theNewRow)對應的欄位-------------
                        Dim inrRedirFlag As Integer
                        For inrRedirFlag = 0 To aryRedir.Count - 1
                            Dim theColName As String = Hash.Item(aryRedir.Item(inrRedirFlag).ToString())
                            If Not theColName Is Nothing Then
                                If MarkChar = "" Then
                                    theNewRow.Item(theColName) = aryRedir.Item(inrRedirFlag)
                                Else
                                    theNewRow.Item(theColName) = MarkChar
                                End If
                            End If
                        Next
                        '-------------------------------------------------------------
                        NewdataTable.Rows.Add(theNewRow)
                    End If

                Next

            End If

            '為NewdataTable調整新欄位
            For intAryFlag = aryNewColValue.Length - 1 To 0 Step -1
                Dim theColName As String = Hash.Item(aryNewColValue(intAryFlag).ToString())
                NewdataTable.Columns.Item(theColName).SetOrdinal(NewdataTable.Columns.IndexOf(theRedirColumn) + 1)
            Next
            '刪舊的
            Dim theIndex As Integer = NewdataTable.Columns.IndexOf(theRedirColumn)
            NewdataTable.Columns.RemoveAt(theIndex)

            NewdataTable.AcceptChanges()
            Return NewdataTable

        End Function

#End Region

#Region " 靜態方法-FilterItems "
        '回傳一個ArrayList(多個項目 or 一個空字串的項目)
        Shared Function FilterItems(ByVal theDataTable As DataTable, ByVal theColumns() As String) As ArrayList

            Dim theArraylist As New ArrayList

            If (theColumns Is Nothing) OrElse theColumns.Length = 0 Then
                theArraylist.Add("")
            Else
                For Each theRow As DataRow In theDataTable.Rows
                    Dim intAryFlag As Integer
                    Dim strFilterItem As String = ""
                    Dim strAnd As String = " and "
                    '
                    For intAryFlag = 0 To theColumns.Length - 1
                        strFilterItem &= theColumns(intAryFlag) & "='" & EmptyDBNull(theRow.Item(theColumns(intAryFlag))) & "'" & strAnd
                    Next
                    '
                    If strFilterItem.Length > 1 Then
                        strFilterItem = strFilterItem.Remove(strFilterItem.LastIndexOf(strAnd))
                    End If
                    '
                    If theArraylist.IndexOf(strFilterItem) = -1 Then
                        theArraylist.Add(strFilterItem)
                    End If
                Next
            End If

            Return theArraylist
        End Function

#End Region

#Region " 靜態方法-將DBnull的DataRow變成空字串 "

        Shared Function EmptyDBNull(ByVal theObject As Object) As String

            If IsDBNull(theObject) Then
                theObject = String.Empty
            Else
                theObject = theObject.ToString
            End If

            Return theObject

        End Function

#End Region

    End Class

#End Region

End Namespace