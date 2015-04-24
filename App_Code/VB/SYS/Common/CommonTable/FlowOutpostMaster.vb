Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SYS.Logic
    <System.ComponentModel.DataObject()> _
    Public Class FlowOutpostMaster
        Private DAO As FlowOutpostMasterDAO

        Public Sub New()
            DAO = New FlowOutpostMasterDAO()
        End Sub

#Region "Property"
        Private _Orgcode As String
        Private _Flow_outpost_id As String
        Private _Outpost_id As String
        Private _Outpost_orgcode As String
        Private _Outpost_departid As String
        Private _Outpost_posid As String
        Private _Relate_flag As String
        Private _Outpost_seq As Integer
        Private _Hoursetting_id As String
        Private _Group_id As String
        Private _Group_seq As String
        Private _Group_type As String
        Private _mail_flag As String
        Private _Change_userid As String
        Private _Change_date As Date = Now

        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(value As String)
                _Orgcode = value
            End Set
        End Property

        Public Property Flow_outpost_id() As String
            Get
                Return _Flow_outpost_id
            End Get
            Set(ByVal value As String)
                _Flow_outpost_id = value
            End Set
        End Property

        Public Property Outpost_id() As String
            Get
                Return _Outpost_id
            End Get
            Set(ByVal value As String)
                _Outpost_id = value
            End Set
        End Property

        Public Property Outpost_orgcode() As String
            Get
                Return _Outpost_orgcode
            End Get
            Set(ByVal value As String)
                _Outpost_orgcode = value
            End Set
        End Property

        Public Property Outpost_departid() As String
            Get
                Return _Outpost_departid
            End Get
            Set(ByVal value As String)
                _Outpost_departid = value
            End Set
        End Property

        Public Property Outpost_posid() As String
            Get
                Return _Outpost_posid
            End Get
            Set(ByVal value As String)
                _Outpost_posid = value
            End Set
        End Property

        Public Property Relate_flag() As String
            Get
                Return _Relate_flag
            End Get
            Set(ByVal value As String)
                _Relate_flag = value
            End Set
        End Property

        Public Property Outpost_seq() As Integer
            Get
                Return _Outpost_seq
            End Get
            Set(ByVal value As Integer)
                _Outpost_seq = value
            End Set
        End Property

        Public Property Hoursetting_id() As String
            Get
                Return _Hoursetting_id
            End Get
            Set(ByVal value As String)
                _Hoursetting_id = value
            End Set
        End Property

        Public Property Group_id() As Integer
            Get
                Return _Group_id
            End Get
            Set(ByVal value As Integer)
                _Group_id = value
            End Set
        End Property

        Public Property Group_seq() As Integer
            Get
                Return _Group_seq
            End Get
            Set(ByVal value As Integer)
                _Group_seq = value
            End Set
        End Property

        Public Property Group_type() As Integer
            Get
                Return _Group_type
            End Get
            Set(ByVal value As Integer)
                _Group_type = value
            End Set
        End Property

        Public Property Mail_flag() As String
            Get
                Return _mail_flag
            End Get
            Set(ByVal value As String)
                _mail_flag = value
            End Set
        End Property

        Public Property Change_userid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property

        Public Property Change_date() As Date
            Get
                Return _Change_date
            End Get
            Set(ByVal value As Date)
                _Change_date = value
            End Set
        End Property

        Private _Unit_flag As String
        Public Property Unit_flag() As String
            Get
                Return _Unit_flag
            End Get
            Set(ByVal value As String)
                _Unit_flag = value
            End Set
        End Property

#End Region

        Public Function GetFlowOutpostId() As String
            Dim saCode As New FSCPLM.Logic.SACode()
            Dim codedr As DataRow = saCode.GetRow("023", "**", "001")
            Dim flowOutpostId As String = ""
            If codedr IsNot Nothing Then
                flowOutpostId = codedr("code_desc2")
                Dim id As Integer = CommonFun.getInt(flowOutpostId.Substring(3)) + 1
                If Not saCode.updateCodeDesc2(codedr("code_sys"), codedr("code_kind"), codedr("code_type"), codedr("code_no"), "FOP" & id.ToString().PadLeft(7, "0")) Then
                    Throw New Exception("設定流程編號失敗")
                End If
            End If
            Return flowOutpostId
        End Function

        Public Function UpdateDataById(id As String, outpostId As String, outpostOrgcode As String, outpostDepartid As String, outpostPosid As String) As Boolean
            Return DAO.UpdateDataById(id, outpostId, outpostOrgcode, outpostDepartid, outpostPosid) > 0
        End Function


        Public Function GetDataByFlowOutpostID(ByVal Orgcode As String, ByVal FlowOutpostID As String) As DataTable
            Return DAO.GetDataByFlowOutpostID(FlowOutpostID)
        End Function


        Public Function GetFlowOutpostIdList(ByVal orgcode As String, ByVal joinOutpostId As String) As List(Of FlowOutpostMaster)
            Dim list As New List(Of FlowOutpostMaster)
            Dim rowaffact As Integer = 0
            Dim OutpostId() As String = joinOutpostId.Split(";")
            Dim psn As New FSC.Logic.Personnel()

            Dim i As Integer = 1
            Dim groupId As Integer = 0
            Dim groupSeq As Integer = 0     '尚未使用(會辦流程內順序)
            Dim groupType As Integer = 1    '1:併會, 2:順會
            Dim departId As String = ""

            For Each id As String In OutpostId
                Dim val() As String = id.Split(",")

                Dim fom As New FlowOutpostMaster()
                fom.Orgcode = orgcode


                If "0".Equals(val(0)) Then  '主管別

                    fom.Outpost_id = val(1)
                    fom.Outpost_orgcode = ""
                    fom.Outpost_departid = ""
                    fom.Outpost_posid = ""
                    fom.Relate_flag = val(0)
                    fom.Outpost_seq = i
                    i += 1

                ElseIf "1".Equals(val(0)) Then      '關卡

                    fom.Outpost_id = val(1)
                    fom.Outpost_orgcode = ""
                    fom.Outpost_departid = ""
                    fom.Outpost_posid = ""
                    fom.Relate_flag = val(0)
                    fom.Outpost_seq = i
                    i += 1

                ElseIf "2".Equals(val(0)) Then  '職稱

                    fom.Outpost_id = val(1)
                    fom.Outpost_orgcode = val(2)
                    fom.Outpost_departid = val(3)
                    fom.Outpost_posid = ""
                    fom.Relate_flag = val(0)
                    fom.Outpost_seq = i
                    i += 1

                ElseIf "3".Equals(val(0)) Then  '人員

                    fom.Outpost_id = val(1)
                    fom.Outpost_orgcode = val(2)
                    fom.Outpost_departid = val(3)
                    fom.Outpost_posid = psn.GetColumnValue("Title_no", val(1))
                    fom.Relate_flag = val(0)
                    fom.Outpost_seq = i
                    i += 1

                ElseIf "4".Equals(val(0)) Then  '角色

                    fom.Outpost_id = val(1)
                    fom.Outpost_orgcode = val(2)
                    fom.Outpost_departid = ""
                    fom.Outpost_posid = ""
                    fom.Relate_flag = val(0)
                    fom.Outpost_seq = i
                    fom.Unit_flag = val(4)
                    i += 1


                ElseIf "5".Equals(val(0)) Then  '會辦職稱

                    fom.Outpost_id = val(1)
                    fom.Outpost_orgcode = val(2)
                    fom.Outpost_departid = val(3)
                    fom.Outpost_posid = ""
                    fom.Relate_flag = val(0)

                    groupId += 1
                    fom.Group_id = groupId
                    'fom.Group_seq = groupSeq
                    fom.Group_type = groupType
                    fom.Outpost_seq = i

                ElseIf "6".Equals(val(0)) Then  '會辦人員

                    fom.Outpost_id = val(1)
                    fom.Outpost_orgcode = val(2)
                    fom.Outpost_departid = val(3)
                    fom.Outpost_posid = psn.GetColumnValue("Title_no", val(1))
                    fom.Relate_flag = val(0)

                    groupId += 1
                    fom.Group_id = groupId
                    'fom.Group_seq = groupSeq
                    fom.Group_type = groupType
                    fom.Outpost_seq = i

                ElseIf "7".Equals(val(0)) Then  '會辦角色

                    fom.Outpost_id = val(1)
                    fom.Outpost_orgcode = val(2)
                    fom.Outpost_departid = ""
                    fom.Outpost_posid = ""
                    fom.Relate_flag = val(0)
                    fom.Unit_flag = val(4)

                    groupId += 1
                    fom.Group_id = groupId
                    'fom.Group_seq = groupSeq
                    fom.Group_type = groupType
                    fom.Outpost_seq = i

                End If


                list.Add(fom)
            Next

            Return list
        End Function

        Public Function InsertFlowOutpostMaster() As Boolean
            Return DAO.InsertData(Me) = 1
        End Function

        Public Function DeleteFlowOutpostMaster(ByVal Flow_outpost_id As String) As Boolean
            Dim rowaffact As Integer = DAO.DeleteDataByfopID(Flow_outpost_id)
            Return rowaffact >= 1
        End Function


        Public Function GetData(ByVal orgcode As String, ByVal departId As String, ByVal target As String, ByVal targetType As String, ByVal formId As String) As DataTable
            Return DAO.GetData(orgcode, departId, target, targetType, formId)
        End Function
    End Class
End Namespace