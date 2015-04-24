
Partial Class uc_ucGridViewPager
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Me._GridViewObject = CType(Me.Parent.FindControl(Me._GridViewObject_ControlID), GridView)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    'Dim Log As New Logz()
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Me.Initial_GridViewPager()

        'Me.info.Text = Me.Log.ToString()
    End Sub

    Public Sub Initial_GridViewPager()
        Try
            Me.GridViewPagerPanel.Visible = Me._GridViewObject.AllowPaging
            Me.v_PageCount.Text = Me._GridViewObject.PageCount.ToString()
            Me.v_PageIndex.Text = (Me._GridViewObject.PageIndex + 1).ToString()
            ''Me.v_DataRowsCount.Text = "-2"

            ' 換頁按鈕 
            If (Me._GridViewObject.PageIndex.Equals(0)) Then ' 現在是第一頁 
                Me.b_pageFirst.Enabled = False ' 第一頁 
                Me.b_pagePrev.Enabled = False ' 上一頁
            Else
                Me.b_pageFirst.Enabled = True
                Me.b_pagePrev.Enabled = True
            End If
            If (Me._GridViewObject.PageIndex.Equals(Me._GridViewObject.PageCount - 1)) Then ' 現在是最後一頁
                Me.b_pageNext.Enabled = False ' 下一頁 
                Me.b_pageLast.Enabled = False ' 最後一頁 
            Else
                Me.b_pageNext.Enabled = True ' 下一頁 
                Me.b_pageLast.Enabled = True ' 最後一頁 
            End If

        Catch ex As NullReferenceException
        Catch ex As Exception
        End Try
    End Sub

    Private _GridViewObject_ControlID As String = ""
    Public Property GridViewObject_ControlID() As String
        Get
            Return Me._GridViewObject_ControlID
        End Get
        Set(ByVal value As String)
            Me._GridViewObject_ControlID = value
            Me._GridViewObject = CType(Me.Page.FindControl(Me._GridViewObject_ControlID), GridView)
        End Set
    End Property

    Private _GridViewObject As GridView = Nothing
    Public Property GridViewObject() As GridView
        Get
            Return Me._GridViewObject
        End Get
        Set(ByVal value As GridView)
            Me._GridViewObject = value
            Me.Initial_GridViewPager()
        End Set
    End Property

    Private _PageCount As Integer = -1
    Private _PageIndex As Integer = -1
    Private _RowsCount As Integer = -1

    Public Property vPageCount() As String
        Get
            Return Me.v_PageCount.Text
        End Get
        Set(ByVal value As String)
            Me.v_PageCount.Text = value
        End Set
    End Property

    Public Property vPageIndex() As String
        Get
            Return Me.v_PageIndex.Text
        End Get
        Set(ByVal value As String)
            Me.v_PageIndex.Text = value
        End Set
    End Property

    Public Property vDataRowsCount() As String
        Get
            Return Me.v_DataRowsCount.Text
        End Get
        Set(ByVal value As String)
            Me.v_DataRowsCount.Text = value
        End Set
    End Property

    ' 第一頁 
    Protected Sub b_pageFirst_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_pageFirst.Click
        Try
            Me._GridViewObject.PageIndex = 0
        Catch ex As NullReferenceException
        Catch ex As Exception
        End Try
    End Sub
    ' 上一頁 
    Protected Sub b_pagePrev_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_pagePrev.Click
        Try
            Me._GridViewObject.PageIndex = Me._GridViewObject.PageIndex - 1
        Catch ex As NullReferenceException
        Catch ex As Exception
        End Try
    End Sub
    ' 下一頁 
    Protected Sub b_pageNext_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_pageNext.Click
        Try
            Me._GridViewObject.PageIndex = Me._GridViewObject.PageIndex + 1
        Catch ex As NullReferenceException
        Catch ex As Exception
        End Try
    End Sub
    ' 最後一頁 
    Protected Sub b_pageLast_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles b_pageLast.Click
        Try
            Me._GridViewObject.PageIndex = Me._GridViewObject.PageCount - 1
        Catch ex As NullReferenceException
        Catch ex As Exception
        End Try
    End Sub

End Class
