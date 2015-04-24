Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class Schedule

#Region "property"
        Private _id As Integer
        Private _schedule_id As String
        Private _Orgcode As String
        Private _Name As String
        Private _Start_time As String
        Private _End_time As String
        Private _Noon_stime As String
        Private _Nonn_etime As String
        Private _Nooncard_stime As String
        Private _Nooncard_etime As String
        Private _Change_userid As String
        Private _Change_date As Date
        Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property
        Public Property Schedule_id() As String
            Get
                Return _schedule_id
            End Get
            Set(ByVal value As String)
                _schedule_id = value
            End Set
        End Property

        Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property
        Property Start_time() As String
            Get
                Return _Start_time
            End Get
            Set(ByVal value As String)
                _Start_time = value
            End Set
        End Property
        Property End_time() As String
            Get
                Return _End_time
            End Get
            Set(ByVal value As String)
                _End_time = value
            End Set
        End Property
        Property Noon_stime() As String
            Get
                Return _Noon_stime
            End Get
            Set(ByVal value As String)
                _Noon_stime = value
            End Set
        End Property
        Property Noon_etime() As String
            Get
                Return _Nonn_etime
            End Get
            Set(ByVal value As String)
                _Nonn_etime = value
            End Set
        End Property
        Property Nooncard_stime() As String
            Get
                Return _Nooncard_stime
            End Get
            Set(ByVal value As String)
                _Nooncard_stime = value
            End Set
        End Property
        Property Nooncard_etime() As String
            Get
                Return _Nooncard_etime
            End Get
            Set(ByVal value As String)
                _Nooncard_etime = value
            End Set
        End Property
        Property Change_userid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property
        Property Change_date() As Date
            Get
                Return _Change_date
            End Get
            Set(ByVal value As Date)
                _Change_date = value
            End Set
        End Property
#End Region

        Private DAO As ScheduleDAO

        Public Sub New()
            DAO = New ScheduleDAO()
        End Sub

        Public Function GetMaxScheduleId(ByVal orgcode As String) As String
            Dim obj As Object = DAO.GetMaxScheduleId(orgcode)
            If obj IsNot Nothing Then
                Dim i As Integer = CommonFun.getInt(obj.ToString().Substring(1)) + 1
                Return "A" & i.ToString().PadLeft(5, "0")
            Else
                Return "A00001"
            End If
        End Function

        Public Function GetData(ByVal orgcode As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            Return DAO.GetDataByExample("FSC_Schedule", d)
        End Function

        Public Function getData(ByVal orgcode As String, ByVal Schedule_id As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            d.Add("Schedule_id", Schedule_id)
            Return DAO.GetDataByExample("FSC_Schedule", d)
        End Function

        Public Function GetDataById(ByVal id As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("id", id)
            Return DAO.GetDataByExample("FSC_Schedule", d)
        End Function

        Public Function insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Me.Orgcode)
            d.Add("Name", Me.Name)
            d.Add("Schedule_id", Me.Schedule_id)
            d.Add("Start_time", Me.Start_time)
            d.Add("End_time", Me.End_time)
            d.Add("Noon_stime", Me.Noon_stime)
            d.Add("Noon_etime", Me.Noon_etime)
            d.Add("Nooncard_stime", Me.Nooncard_stime)
            d.Add("Nooncard_etime", Me.Nooncard_etime)
            d.Add("Change_userid", Me.Change_userid)
            d.Add("Change_date", Me.Change_date)
            Return DAO.InsertByExample("FSC_Schedule", d) > 0
        End Function

        Public Function update() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Name", Me.Name)
            d.Add("Start_time", Me.Start_time)
            d.Add("End_time", Me.End_time)
            d.Add("Noon_stime", Me.Noon_stime)
            d.Add("Noon_etime", Me.Noon_etime)
            d.Add("Nooncard_stime", Me.Nooncard_stime)
            d.Add("Nooncard_etime", Me.Nooncard_etime)
            d.Add("Change_userid", Me.Change_userid)
            d.Add("Change_date", Me.Change_date)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("id", Me.id)
            Return DAO.UpdateByExample("FSC_Schedule", d, cd) > 0
        End Function

        Public Function delete(ByVal id As Integer) As Boolean
            Dim cd As New Dictionary(Of String, Object)
            cd.Add("id", id)
            Return DAO.DeleteByExample("FSC_Schedule", cd) > 0
        End Function

        'Public Function InsertToSchedule_setting() As Boolean
        '    Dim sSQL As StringBuilder = New StringBuilder()
        '    sSQL.AppendLine("insert into Schedule_setting ")
        '    sSQL.AppendLine("select ")
        '    sSQL.AppendLine("   tmpS.OrgCode,")
        '    sSQL.AppendLine("   m.Depart_id, ")
        '    sSQL.AppendLine("   m.Sub_depart_id,")
        '    sSQL.AppendLine("   m.Id_card ,")
        '    sSQL.AppendLine("   tmpS.personnel_id,")
        '    sSQL.AppendLine("   tmpS.User_name,")
        '    sSQL.AppendLine("   tmpS.Sche_date,")
        '    sSQL.AppendLine("   tmpS.Sche_type,")
        '    sSQL.AppendLine("   tmpS.Schedule_id,")
        '    sSQL.AppendLine("   tmpS.Change_userid,")
        '    sSQL.AppendLine("   tmpS.Change_date")
        '    sSQL.AppendLine("from Member m")
        '    sSQL.AppendLine("join dbo.Tmp_Schedule_setting tmpS on m.Personnel_id = tmpS.Personnel_id")
        '    sSQL.AppendLine("delete")
        '    sSQL.AppendLine("   Tmp_Schedule_setting")
        '    sSQL.AppendLine("where id in (")
        '    sSQL.AppendLine("   select ")
        '    sSQL.AppendLine("       tmpS.id")
        '    sSQL.AppendLine("   from Member m")
        '    sSQL.AppendLine("   join dbo.Tmp_Schedule_setting tmpS on m.Personnel_id = tmpS.Personnel_id")
        '    sSQL.AppendLine(")")

        '    Return DAO.InsertToSchedule_setting(sSQL.ToString())
        'End Function

        'Public Function DelTmpSchedule() As Boolean
        '    Dim sSQL As StringBuilder = New StringBuilder()
        '    sSQL.AppendLine("delete")
        '    sSQL.AppendLine("   Tmp_Schedule_setting")

        '    Return DAO.DelTmpSchedule(sSQL.ToString())
        'End Function

        'Public Function getTmpSchedule() As DataTable
        '    Dim sSQL As StringBuilder = New StringBuilder()
        '    sSQL.AppendLine("select ")
        '    sSQL.AppendLine("   tmpS.OrgCode,")
        '    sSQL.AppendLine("   m.Depart_id, ")
        '    sSQL.AppendLine("   m.Sub_depart_id,")
        '    sSQL.AppendLine("   m.Id_card ,")
        '    sSQL.AppendLine("   tmpS.personnel_id,")
        '    sSQL.AppendLine("   tmpS.User_name,")
        '    sSQL.AppendLine("   tmpS.Sche_date,")
        '    sSQL.AppendLine("   tmpS.Sche_type,")
        '    sSQL.AppendLine("   tmpS.Schedule_id,")
        '    sSQL.AppendLine("   tmpS.Change_userid,")
        '    sSQL.AppendLine("   tmpS.Change_date")
        '    sSQL.AppendLine("from Member m")
        '    sSQL.AppendLine("join dbo.Tmp_Schedule_setting tmpS on m.Personnel_id = tmpS.Personnel_id")

        '    Return DAO.Query(sSQL.ToString)
        'End Function
        ' ''' <summary>
        ' ''' for匯入排班資料，做批次更新
        ' ''' </summary>
        ' ''' <param name="dt"></param>
        ' ''' <remarks></remarks>
        'Public Sub Batch_Insert(dt As DataTable)

        '    Dim sSQL As StringBuilder = New StringBuilder()
        '    'sSQL.AppendLine("DECLARE @RtnCode int ")
        '    'sSQL.AppendLine("set @RtnCode = 0")
        '    sSQL.AppendLine("INSERT INTO [dbo].[Tmp_Schedule_setting]")
        '    sSQL.AppendLine("   ([Orgcode]")
        '    sSQL.AppendLine("   ,[Personnel_id]")
        '    sSQL.AppendLine("   ,[User_name]")
        '    sSQL.AppendLine("   ,[Sche_date]")
        '    sSQL.AppendLine("   ,[Sche_type]")
        '    sSQL.AppendLine("   ,[Schedule_id]")
        '    sSQL.AppendLine("   ,[Change_userid]")
        '    sSQL.AppendLine("   ,[Change_date])")
        '    sSQL.AppendLine("VALUES")
        '    sSQL.AppendLine("   (@OrgCode")
        '    sSQL.AppendLine("   ,@Personnel_id")
        '    sSQL.AppendLine("   ,@User_name")
        '    sSQL.AppendLine("   ,@Sche_date")
        '    sSQL.AppendLine("   ,@Sche_type")
        '    sSQL.AppendLine("   ,@Schedule_id")
        '    sSQL.AppendLine("   ,@Change_userid")
        '    sSQL.AppendLine("   ,getdate())")

        '    sSQL.AppendLine("if @@ERROR = 0")
        '    sSQL.AppendLine("   BEGIN")
        '    sSQL.AppendLine("      SET @RtnCode = 1")
        '    sSQL.AppendLine("   End")
        '    sSQL.AppendLine("Else")
        '    sSQL.AppendLine("   BEGIN")
        '    sSQL.AppendLine("      SET @RtnCode = 101")
        '    sSQL.AppendLine("   END")

        '    'dt.Columns.Add("OrgCode", GetType(String))
        '    'dt.Columns.Add("Personnel_id", GetType(String))
        '    'dt.Columns.Add("User_name", GetType(String))
        '    'dt.Columns.Add("Sche_date", GetType(String))
        '    'dt.Columns.Add("Sche_type", GetType(String))
        '    'dt.Columns.Add("Schedule_id", GetType(Integer))
        '    'dt.Columns.Add("Change_userid", GetType(String))
        '    'dt.Columns.Add("RtnCode", GetType(Integer))

        '    Dim ps() As SqlParameter = { _
        '            New SqlParameter("@OrgCode", SqlDbType.VarChar, 10), _
        '            New SqlParameter("@Personnel_id", SqlDbType.VarChar, 10), _
        '            New SqlParameter("@User_name", SqlDbType.VarChar, 20), _
        '            New SqlParameter("@Sche_date", SqlDbType.VarChar, 7), _
        '            New SqlParameter("@Sche_type", SqlDbType.VarChar, 1), _
        '            New SqlParameter("@Schedule_id", SqlDbType.Int, 4), _
        '            New SqlParameter("@Change_userid", SqlDbType.VarChar, 10), _
        '            New SqlParameter("@RtnCode", SqlDbType.Int, 4) _
        '        }

        '    ps(7).Direction = ParameterDirection.Output


        '    DAO.SqlBatch(dt, UpdateRowSource.OutputParameters, sSQL.ToString, ps)
        'End Sub
    End Class
End Namespace