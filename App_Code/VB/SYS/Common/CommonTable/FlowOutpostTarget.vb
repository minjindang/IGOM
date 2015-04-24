Imports Microsoft.VisualBasic
Imports System.Data

Namespace SYS.Logic
    <System.ComponentModel.DataObject()> _
    Public Class FlowOutpostTarget
        Public DAO As FlowOutpostTargetDAO

#Region "Property"
        Private _Flow_outpost_id As String
        Public Property Flow_outpost_id() As String
            Get
                Return _Flow_outpost_id
            End Get
            Set(ByVal value As String)
                _Flow_outpost_id = value
            End Set
        End Property
        Private _Orgcode As String
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Private _Depart_id As String
        Public Property Depart_id() As String
            Get
                Return _Depart_id
            End Get
            Set(ByVal value As String)
                _Depart_id = value
            End Set
        End Property
        Private _Target As String
        Public Property Target() As String
            Get
                Return _Target
            End Get
            Set(ByVal value As String)
                _Target = value
            End Set
        End Property
        Private _Target_type As String
        Public Property Target_type() As String
            Get
                Return _Target_type
            End Get
            Set(ByVal value As String)
                _Target_type = value
            End Set
        End Property
        Private _Change_userid As String
        Public Property Change_userid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property
        Private _Change_date As Date = Now
        Public Property Change_date() As Date
            Get
                Return _Change_date
            End Get
            Set(ByVal value As Date)
                _Change_date = value
            End Set
        End Property
#End Region

        Public Sub New()
            DAO = New FlowOutpostTargetDAO()
        End Sub

        Public Function InsertFlowOutpostTarget(ByVal flowOutpostId As String, ByVal orgcode As String, ByVal departId As String, ByVal target As String, ByVal targetType As String, ByVal changeUserid As String) As Boolean
            If DAO.InsertData(flowOutpostId, orgcode, departId, target, targetType, changeUserid) <> 1 Then
                Return False
            End If
            Return True
        End Function

        Public Function GetTargetByQuery(ByVal Flow_outpost_id As String, ByVal orgcode As String, ByVal Depart_id As String) As DataTable
            Dim dt As DataTable = DAO.GetTargetByQuery(Flow_outpost_id, orgcode, Depart_id)
            Return dt
        End Function

        Public Function GetDataByFlowOutpostID(ByVal FlowOutpostID As String) As DataTable
            Return DAO.GetTargetByQuery(FlowOutpostID, "", "")
        End Function


        Public Function GetTargetByFOId(ByVal orgcode As String, ByVal Flow_outpost_id As String) As DataTable
            Dim fodt_dt As DataTable = DAO.GetTargetByQuery(Flow_outpost_id, "", "")
            If fodt_dt Is Nothing OrElse fodt_dt.Rows.Count <= 0 Then
                Return Nothing
            End If


            Dim dt As DataTable = New DataTable()
            dt.Columns.Add("Depart_id", GetType(String))
            dt.Columns.Add("Depart_name", GetType(String))
            dt.Columns.Add("Target", GetType(String))
            dt.Columns.Add("Target_name", GetType(String))

            Dim dr As DataRow = Nothing
            Dim depart_id As String = String.Empty

            Dim first As Boolean = True
            For Each fodt_dr As DataRow In fodt_dt.Rows
                Dim departName As String = New FSC.Logic.Org().GetDepartName(orgcode, fodt_dr("Depart_id").ToString())
                If String.IsNullOrEmpty(depart_id) Or depart_id <> fodt_dr("Depart_id").ToString() Then
                    If Not first Then dt.Rows.Add(dr)
                    dr = dt.NewRow
                    dr("Depart_id") = fodt_dr("Depart_id").ToString()
                    dr("Depart_name") = departName

                    dr("Target") = fodt_dr("Target").ToString() & "," & fodt_dr("Target_type").ToString()
                    dr("Target_name") = Outpost.GetTargetName(fodt_dr("Target").ToString(), fodt_dr("Target_type").ToString())

                Else
                    If Not "".Equals(dr("Target").ToString()) Then
                        dr("Target") &= ";"
                    End If
                    If Not "".Equals(dr("Target_name").ToString()) Then
                        dr("Target_name") &= "、"
                    End If

                    dr("Target") &= fodt_dr("Target").ToString() & "," & fodt_dr("Target_type").ToString()
                    dr("Target_name") &= Outpost.GetTargetName(fodt_dr("Target").ToString(), fodt_dr("Target_type").ToString())
                End If
                depart_id = fodt_dr("Depart_id")
                first = False
            Next
            dt.Rows.Add(dr)
            Return dt
        End Function

        Public Function DeleteFlowOutpostTarget(ByVal Flow_outpost_id As String) As Boolean
            Return DAO.DeleteData(Flow_outpost_id) >= 1
        End Function


        Public Function DeleteFlowOutpostTarget(ByVal orgcode As String, ByVal departId As String, ByVal Flow_outpost_id As String) As Boolean
            Return DAO.DeleteData(orgcode, departId, Flow_outpost_id) >= 1
        End Function
    End Class
End Namespace