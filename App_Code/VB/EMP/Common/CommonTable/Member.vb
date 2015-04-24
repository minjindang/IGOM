Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace EMP.Logic
    <System.ComponentModel.DataObject()> _
    Public Class Member
        Public DAO As MemberDAO

        Public Sub New()
            DAO = New MemberDAO()
        End Sub

#Region "Property"
        Private _Personnel_id As String
        Private _Id_card As String
        Private _AD_id As String
        Private _User_name As String
        Private _Email As String
        Private _Employee_type As String
        Private _Boss_level_id As String
        Private _Act_date As String
        Private _First_gov_date As String
        Private _Left_date As String
        Private _Live_phone As String
        Private _Phone As String
        Private _Ext As String
        Private _Delete_flag As String
        Private _Quit_job_flag As String
        Private _Change_userid As String
        Private _Change_date As System.Nullable(Of Date)

        Public Property Personnel_id() As String
            Get
                Return Me._Personnel_id
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Personnel_id, value) = False) Then
                    Me._Personnel_id = value
                End If
            End Set
        End Property
        Public Property Id_card() As String
            Get
                Return Me._Id_card
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Id_card, value) = False) Then
                    Me._Id_card = value
                End If
            End Set
        End Property
        Public Property AD_id() As String
            Get
                Return Me._AD_id
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._AD_id, value) = False) Then
                    Me._AD_id = value
                End If
            End Set
        End Property
        Public Property User_name() As String
            Get
                Return Me._User_name
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._User_name, value) = False) Then
                    Me._User_name = value
                End If
            End Set
        End Property
        Public Property Email() As String
            Get
                Return Me._Email
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Email, value) = False) Then
                    Me._Email = value
                End If
            End Set
        End Property
        Public Property Employee_type() As String
            Get
                Return Me._Employee_type
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Employee_type, value) = False) Then
                    Me._Employee_type = value
                End If
            End Set
        End Property
        Public Property Boss_level_id() As String
            Get
                Return Me._Boss_level_id
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Boss_level_id, value) = False) Then
                    Me._Boss_level_id = value
                End If
            End Set
        End Property
        Public Property Act_date() As String
            Get
                Return Me._Act_date
            End Get
            Set(ByVal value As String)
                Me._Act_date = value
            End Set
        End Property
        Public Property First_gov_date() As String
            Get
                Return Me._First_gov_date
            End Get
            Set(ByVal value As String)
                Me._First_gov_date = value
            End Set
        End Property
        Public Property Left_date() As String
            Get
                Return Me._Left_date
            End Get
            Set(ByVal value As String)
                Me._Left_date = value
            End Set
        End Property
        Public Property Live_phone() As String
            Get
                Return Me._Live_phone
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Live_phone, value) = False) Then
                    Me._Live_phone = value
                End If
            End Set
        End Property
        Public Property Phone() As String
            Get
                Return Me._Phone
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Phone, value) = False) Then
                    Me._Phone = value
                End If
            End Set
        End Property
        Public Property Ext() As String
            Get
                Return Me._Ext
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Ext, value) = False) Then
                    Me._Ext = value
                End If
            End Set
        End Property
        Public Property Delete_flag() As String
            Get
                Return Me._Delete_flag
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Delete_flag, value) = False) Then
                    Me._Delete_flag = value
                End If
            End Set
        End Property
        Public Property Quit_job_flag() As String
            Get
                Return Me._Quit_job_flag
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Quit_job_flag, value) = False) Then
                    Me._Quit_job_flag = value
                End If
            End Set
        End Property
        Public Property Change_userid() As String
            Get
                Return Me._Change_userid
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Change_userid, value) = False) Then
                    Me._Change_userid = value
                End If
            End Set
        End Property
        Public Property Change_date() As System.Nullable(Of Date)
            Get
                Return Me._Change_date
            End Get
            Set(ByVal value As System.Nullable(Of Date))
                If (Me._Change_date.Equals(value) = False) Then
                    Me._Change_date = value
                End If
            End Set
        End Property
#End Region

        Public Function insert() As Boolean
            Return DAO.insert(Me) > 0
        End Function

        Public Function update() As Boolean
            Return DAO.update(Me) > 0
        End Function

        Public Function update(ByVal d As Dictionary(Of String, Object), ByVal cd As Dictionary(Of String, Object)) As Boolean
            Return DAO.updateByExample("member", d, cd) > 0
        End Function

        Public Function GetDataByIdCard(ByVal idCard As String) As DataTable
            Return DAO.GetDataByIdCard(idCard)
        End Function

        ''' <summary>
        ''' �̾����B�����o�H�����
        ''' </summary>
        ''' <param name="orgcode"></param>
        ''' <param name="departId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataByOrgDep(ByVal orgcode As String, ByVal departId As String) As DataTable
            Return DAO.GetDataByOrgDep(orgcode, departId, 0)
        End Function

        ''' <summary>
        ''' �̾����B�����o�H�����
        ''' </summary>
        ''' <param name="orgcode"></param>
        ''' <param name="departId"></param>
        ''' <param name="level">0:�����,1:�U�@�h, 2:�U�G�h</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataByOrgDep(ByVal orgcode As String, ByVal departId As String, ByVal level As Integer) As DataTable
            Return DAO.GetDataByOrgDep(orgcode, departId, level)
        End Function

        Public Function GetColumnValue(columnName As String, idcard As String) As String
            Dim dt As DataTable = GetDataByIdCard(idcard)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)(columnName).ToString()
            End If
            Return ""
        End Function

        Public Sub UpdateExt(ByVal id_card As String, ByVal ext As String)
            DAO.UpdateExt(id_card, ext)
        End Sub
    End Class
End Namespace