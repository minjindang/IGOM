Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class Role
        Private DAO As RoleDAO

#Region "Property"
        Private _orgcode As String
        Public Property Orgcode() As String
            Get
                Return _orgcode
            End Get
            Set(ByVal value As String)
                _orgcode = value
            End Set
        End Property
        Private _roleId As String
        Public Property RoleId() As String
            Get
                Return _roleId
            End Get
            Set(ByVal value As String)
                _roleId = value
            End Set
        End Property
        Private _roleName As String
        Public Property RoleName() As String
            Get
                Return _roleName
            End Get
            Set(ByVal value As String)
                _roleName = value
            End Set
        End Property
        Private _roleStatus As String
        Public Property RoleStatus() As String
            Get
                Return _roleStatus
            End Get
            Set(ByVal value As String)
                _roleStatus = value
            End Set
        End Property
        Private _boss_roleid As String
        Public Property BossRoleid() As String
            Get
                Return _boss_roleid
            End Get
            Set(ByVal value As String)
                _boss_roleid = value
            End Set
        End Property
        Private _managerFlag As String
        Public Property ManagerFlag() As String
            Get
                Return _managerFlag
            End Get
            Set(ByVal value As String)
                _managerFlag = value
            End Set
        End Property
        Private _changeUserid As String
        Public Property ChangeUserid() As String
            Get
                Return _changeUserid
            End Get
            Set(ByVal value As String)
                _changeUserid = value
            End Set
        End Property
        Private _changeDate As Date = Now
        Public Property ChangeDate() As Date
            Get
                Return _changeDate
            End Get
            Set(ByVal value As Date)
                _changeDate = value
            End Set
        End Property


#End Region

        Public Sub New()
            DAO = New RoleDAO()
        End Sub


        Public Function GetData(ByVal Orgcode As String) As DataTable
            Return DAO.GetData(Orgcode)
        End Function

        Public Function GetDataByOrgRid(ByVal Orgcode As String, ByVal roleId As String) As DataTable
            Return DAO.GetDataByOrgRid(Orgcode, roleId)
        End Function

        Public Function GetDataByOrgDep(ByVal orgcode As String) As DataTable
            Return DAO.GetDataByOrgDep(orgcode)
        End Function

        Public Function GetRole(ByVal orgcode As String, ByVal roleId As String) As DataTable
            Return DAO.GetRole(orgcode, roleId)
        End Function

        Public Function InsertData() As Boolean
            Return DAO.InsertData(Me) = 1
        End Function

        Public Function UpdateData() As Boolean
            Return DAO.UpdateData(Me) = 1
        End Function

        Public Function GetObjects(ByVal Orgcode As String, ByVal roleId As String) As List(Of Role)
            Dim dt As DataTable = GetDataByOrgRid(Orgcode, roleId)
            Return CommonFun.ConvertToList(Of Role)(dt)
        End Function

        Public Function GetRolefunction(ByVal Orgcode As String, ByVal roleId As String) As String
            Return DAO.GetRolefunction(Orgcode, roleId)
        End Function

        Public Function DeleteRoleModules(ByVal Orgcode As String, ByVal Role_id As String) As Boolean
            Return DAO.DeleteRoleModules(Orgcode, Role_id) >= 1
        End Function

        Public Function DeleteRoleForms(ByVal Orgcode As String, ByVal Role_id As String) As Boolean
            Return DAO.DeleteRoleForms(Orgcode, Role_id) >= 1
        End Function

        Public Function AddRoleModule(ByVal Orgcode As String, ByVal Role_id As String, ByVal Func_id As String, ByVal Change_userid As String) As Boolean
            Return DAO.AddRoleModule(Orgcode, Role_id, Func_id, Change_userid) >= 1
        End Function

        Public Function AddRoleForm(ByVal Orgcode As String, ByVal Role_id As String, ByVal Form_id As String, ByVal Change_userid As String) As Boolean
            Return DAO.AddRoleForm(Orgcode, Role_id, Form_id, Change_userid) >= 1
        End Function

        Public Function GetRoleForm(ByVal Orgcode As String, ByVal Role_id As String) As String
            Return DAO.GetRoleForm(Orgcode, Role_id)
        End Function

        Public Function GetRoleButton(ByVal Orgcode As String, ByVal Role_id As String) As String
            Return DAO.GetRoleButton(Orgcode, Role_id)
        End Function

        Public Function GetFormButton(ByVal Orgcode As String, ByVal Role_id As String, ByVal Button_id As String) As String
            Return DAO.GetFormButton(Orgcode, Role_id, Button_id)
        End Function

    End Class
End Namespace