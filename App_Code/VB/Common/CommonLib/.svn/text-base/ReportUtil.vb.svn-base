Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace CommonLib
    Public Class ReportUtil
        Private dt As DataTable
        Private currentPageColumnName As String = "CurrentPage"
        'Private serialNosColumnName As String = "SerialNumber"
        Private groupList As ArrayList

        Public Sub New(dt As DataTable)
            Me.dt = dt
            InitDataTable()
            InitGroupList()
        End Sub

        Public Property Group() As String()
            Get
                Return groupList.ToArray(GetType(String))
            End Get
            Set(ByVal value As String())
                InitGroupList()
                For i As Integer = 0 To value.Length - 1
                    groupList.Add(value(i))
                Next
            End Set
        End Property

        Private Sub InitDataTable()
            Me.dt.Columns.Add(currentPageColumnName, GetType(String))
            'Me.dt.Columns.Add(serialNosColumnName, GetType(String))
            'For i As Integer = 0 To Me.dt.Rows.Count - 1
            '    Me.dt.Rows(i)(serialNosColumnName) = i
            'Next
        End Sub

        Private Sub InitGroupList()
            groupList = New ArrayList()
            groupList.Add(currentPageColumnName)
        End Sub


        ''' <summary>
        ''' 取總頁數
        ''' </summary>
        ''' <param name="pageSize">每頁筆數</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetTotalPage(pageSize As Integer) As Integer
            Dim totalRecord As Integer = dt.Rows.Count
            Dim totalPage As Integer = 0


            Dim d As DataTable = dt.DefaultView.ToTable(True, Group)
            If d IsNot Nothing Then
                totalPage += d.Rows.Count
            End If


            'If (totalRecord Mod pageSize) <> 0 Then
            '    totalPage += (Integer.Parse(totalRecord \ pageSize) + 1).ToString()
            'Else
            '    totalPage += (Integer.Parse(totalRecord \ pageSize)).ToString()
            'End If
            Return totalPage
        End Function


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="pageSize">每頁筆數</param>
        ''' <remarks></remarks>
        Public Sub SetCurrentPage(pageSize As Integer)

            Dim isOtherGroup As Boolean = False
            For Each g As String In Group
                If g <> currentPageColumnName Then
                    isOtherGroup = True
                End If
            Next

            If isOtherGroup Then
                Dim d As DataTable = dt.DefaultView.ToTable(True, Group)
                Dim rlist As New List(Of DataRow())
                'Dim cs As New ArrayList()

                For Each r As DataRow In d.Rows
                    For Each c As DataColumn In d.Columns
                        If c.ColumnName <> currentPageColumnName Then
                            rlist.Add(dt.Select(c.ColumnName & "='" & r(c.ColumnName).ToString() & "'"))
                        End If
                    Next
                Next

                Dim ndt As New DataTable()
                ndt = dt.Clone()

                Dim i As Integer = 0
                Dim j As Integer = 1
                For Each rs() As DataRow In rlist
                    For Each r As DataRow In rs
                        r(currentPageColumnName) = (i \ pageSize) + j
                        ndt.ImportRow(r)
                        i += 1
                    Next
                    j += 1
                Next

                Me.dt = ndt
            Else
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i).Item(currentPageColumnName) = (i \ pageSize) + 1
                Next
            End If

        End Sub

    End Class
End Namespace
