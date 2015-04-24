Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSCPLM.Logic
    Public Class OfficialoutFeeDAO
        Inherits BaseDAO

        Public Function UpdateData(ByVal outfee As OfficialoutFee) As Integer

            Dim sql As New StringBuilder

            sql.Append(" UPDATE Officialout_Fee ")
            sql.Append(" SET ")
            sql.Append("      Apply_Date = @Apply_Date, ")
            sql.Append("      Title_no = @Title_no, ")
            sql.Append("      Job_Level = @Job_Level, ")
            sql.Append("      Officialout_Date = @Officialout_Date, ")
            sql.Append("      Place_start = @Place_start, ")
            sql.Append("      Place_end = @Place_end, ")
            sql.Append("      Introduction = @Introduction, ")
            sql.Append("      Plane = @Plane, ")
            sql.Append("      Self_car = @Self_car, ")
            sql.Append("      Car = @Car, ")
            sql.Append("      Train = @Train, ")
            sql.Append("      Boat = @Boat, ")
            sql.Append("      Live = @Live, ")
            sql.Append("      Food = @Food, ")
            sql.Append("      Sudden = @Sudden, ")
            sql.Append("      Recipnumber = @Recipnumber, ")
            sql.Append("      Note = @Note, ")
            sql.Append("      Special_note = @Special_note, ")
            sql.Append("      Special_fee = @Special_fee, ")
            sql.Append("      Others = @Others, ")
            sql.Append("      Status = @Status, ")
            sql.Append("      Prguid = @Prguid, ")
            sql.Append("      Pay_Mark = @Pay_Mark, ")
            sql.Append("      Approve_Date = @Approve_Date, ")
            sql.Append("      update_date = @update_date, ")
            sql.Append("      update_userid = @update_userid ")
            sql.Append(" WHERE  ")
            sql.Append("      Serial_nos = @Serial_nos  ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Apply_Date", outfee.Apply_date), _
            New SqlParameter("@Title_no", outfee.Title_no), _
            New SqlParameter("@Job_Level", outfee.Job_Level), _
            New SqlParameter("@Officialout_Date", outfee.Officialout_Date), _
            New SqlParameter("@Place_start", outfee.Place_start), _
            New SqlParameter("@Place_end", outfee.Place_end), _
            New SqlParameter("@Introduction", outfee.Introduction), _
            New SqlParameter("@Plane", outfee.Plane), _
            New SqlParameter("@Self_car", outfee.Self_car), _
            New SqlParameter("@Car", outfee.Car), _
            New SqlParameter("@Train", outfee.Train), _
            New SqlParameter("@Boat", outfee.Boat), _
            New SqlParameter("@Live", outfee.Live), _
            New SqlParameter("@Food", outfee.Food), _
            New SqlParameter("@Sudden", outfee.Sudden), _
            New SqlParameter("@Recipnumber", outfee.Recipnumber), _
            New SqlParameter("@Note", outfee.Note), _
            New SqlParameter("@Special_note", outfee.Special_note), _
            New SqlParameter("@Special_fee", outfee.Special_fee), _
            New SqlParameter("@Others", outfee.Others), _
            New SqlParameter("@Status", outfee.Status), _
            New SqlParameter("@Prguid", outfee.Prguid), _
            New SqlParameter("@Pay_Mark", outfee.Pay_Mark), _
            New SqlParameter("@Approve_Date", outfee.Approve_Date), _
            New SqlParameter("@update_date", Now.Date), _
            New SqlParameter("@update_userid", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)), _
            New SqlParameter("@Serial_nos", outfee.Serial_nos)}

            Return Execute(sql.ToString, params)
        End Function

        Public Function UpdateData(ByVal Place_start As String, _
                                   ByVal Place_end As String, _
                                   ByVal Introduction As String, _
                                   ByVal Plane As Integer, _
                                   ByVal Self_car As Integer, _
                                   ByVal Car As Integer, _
                                   ByVal Train As Integer, _
                                   ByVal Boat As Integer, _
                                   ByVal Live As Integer, _
                                   ByVal Food As Integer, _
                                   ByVal Sudden As Integer, _
                                   ByVal Special_note As String, _
                                   ByVal Special_fee As String, _
                                   ByVal update_date As Date, _
                                   ByVal update_username As String, _
                                   ByVal Serial_nos As Integer) As Integer

            Dim sql As New StringBuilder()
            sql.Append(" UPDATE Officialout_Fee ")
            sql.Append(" SET ")
            sql.Append("      Place_start = @Place_start, ")
            sql.Append("      Place_end = @Place_end, ")
            sql.Append("      Introduction = @Introduction, ")
            sql.Append("      Plane = @Plane, ")
            sql.Append("      Self_car = @Self_car, ")
            sql.Append("      Car = @Car, ")
            sql.Append("      Train = @Train, ")
            sql.Append("      Boat = @Boat, ")
            sql.Append("      Live = @Live, ")
            sql.Append("      Food = @Food, ")
            sql.Append("      Sudden = @Sudden, ")
            sql.Append("      Special_note = @Special_note, ")
            sql.Append("      Special_fee = @Special_fee, ")
            sql.Append("      update_date = @update_date, ")
            sql.Append("      update_userid = @update_userid ")
            sql.Append(" WHERE  ")
            sql.Append("      Serial_nos = @Serial_nos  ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Place_start", Place_start), _
            New SqlParameter("@Place_end", Place_end), _
            New SqlParameter("@Introduction", Introduction), _
            New SqlParameter("@Plane", Plane), _
            New SqlParameter("@Self_car", Self_car), _
            New SqlParameter("@Car", Car), _
            New SqlParameter("@Train", Train), _
            New SqlParameter("@Boat", Boat), _
            New SqlParameter("@Live", Live), _
            New SqlParameter("@Food", Food), _
            New SqlParameter("@Sudden", Sudden), _
            New SqlParameter("@Special_note", Special_note), _
            New SqlParameter("@Special_fee", Special_fee), _
            New SqlParameter("@update_date", update_date), _
            New SqlParameter("@update_userid", update_username), _
            New SqlParameter("@Serial_nos", Serial_nos)}

            Return Execute(sql.ToString, params)
        End Function


        Public Function InsertData(ByVal outfee As OfficialoutFee) As Integer
            Dim sql As New StringBuilder()
            sql.Append(" INSERT INTO Officialout_Fee ")
            sql.Append(" ( ")
            sql.Append("   Orgcode, Depart_id, Id_card, Officialout_date, Officialout_dateb, Officialout_timeb, Officialout_type, Apply_Date, ")
            sql.Append("   Title_no, Job_Level, Place_start, Place_end, Introduction, Plane, Self_car, Car, Train, Boat, Bus, MRT, OtherTraffic, Live, Food, ")
            sql.Append("   Sudden, Recipnumber, Note, Special_note, Special_fee, Others, Status, Ppguid, Pay_Mark, Approve_Date, ")
            sql.Append("   create_date, create_userid ")
            sql.Append(" ) ")
            sql.Append(" VALUES ")
            sql.Append(" ( ")
            sql.Append("   @Orgcode, @Depart_id, @Id_card, @Officialout_date, @Officialout_dateb, @Officialout_timeb, @Officialout_type,  @Apply_Date, ")
            sql.Append("   @Title_no, @Job_Level, @Place_start, @Place_end, @Introduction, @Plane, @Self_car, @Car, @Train, @Boat, @Bus, @MRT, @OtherTraffic, @Live, @Food, ")
            sql.Append("   @Sudden, @Recipnumber, @Note, @Special_note, @Special_fee, @Others, @Status, @Ppguid, @Pay_Mark, @Approve_Date, ")
            sql.Append("   @create_date, @create_userid ")
            sql.Append(" ) ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", outfee.Orgcode), _
            New SqlParameter("@Depart_id", outfee.Depart_id), _
            New SqlParameter("@Id_card", outfee.Id_card), _
            New SqlParameter("@Officialout_date", outfee.Officialout_Date), _
            New SqlParameter("@Officialout_dateb", outfee.Officialout_dateb), _
            New SqlParameter("@Officialout_timeb", outfee.Officialout_timeb), _
            New SqlParameter("@Officialout_type", outfee.Officialout_type), _
            New SqlParameter("@Apply_Date", outfee.Apply_date), _
            New SqlParameter("@Title_no", outfee.Title_no), _
            New SqlParameter("@Job_Level", outfee.Job_Level), _
            New SqlParameter("@Place_start", outfee.Place_start), _
            New SqlParameter("@Place_end", outfee.Place_end), _
            New SqlParameter("@Introduction", outfee.Introduction), _
            New SqlParameter("@Plane", outfee.Plane), _
            New SqlParameter("@Self_car", outfee.Self_car), _
            New SqlParameter("@Car", outfee.Car), _
            New SqlParameter("@Train", outfee.Train), _
            New SqlParameter("@Boat", outfee.Boat), _
            New SqlParameter("@Bus", outfee.Bus), _
            New SqlParameter("@MRT", outfee.MRT), _
            New SqlParameter("@OtherTraffic", outfee.OtherTraffic), _
            New SqlParameter("@Live", outfee.Live), _
            New SqlParameter("@Food", outfee.Food), _
            New SqlParameter("@Sudden", outfee.Sudden), _
            New SqlParameter("@Recipnumber", outfee.Recipnumber), _
            New SqlParameter("@Note", outfee.Note), _
            New SqlParameter("@Special_note", outfee.Special_note), _
            New SqlParameter("@Special_fee", outfee.Special_fee), _
            New SqlParameter("@Others", outfee.Others), _
            New SqlParameter("@Status", outfee.Status), _
            New SqlParameter("@Ppguid", outfee.ppguid), _
            New SqlParameter("@Pay_Mark", outfee.Pay_Mark), _
            New SqlParameter("@Approve_Date", outfee.Approve_Date), _
            New SqlParameter("@create_date", Now.Date), _
            New SqlParameter("@create_userid", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))}

            Return Execute(sql.ToString, params)
        End Function


        Public Function GetDataByFlowId(ByVal Flow_id As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select * from Officialout_Fee ")
            sql.AppendLine(" where ")
            sql.AppendLine("    ppguid=@ppguid ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@ppguid", SqlDbType.VarChar)}
            params(0).Value = Flow_id

            Return Query(sql.ToString, params)
        End Function


        Public Function GetDataByKeys(ByVal Serial_nos As Integer) As DataTable
            Dim sql As New StringBuilder()

            sql.Append(" SELECT  ")
            sql.Append("        * ")
            sql.Append(" FROM ")
            sql.Append("        Officialout_Fee ")
            sql.Append(" WHERE ")
            sql.Append("        Serial_nos = @Serial_nos ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Serial_nos", SqlDbType.Int)}
            params(0).Value = Serial_nos

            Return Query(sql.ToString, params)
        End Function

        Public Function GetDataByQuery(ByVal Orgcode As String, _
                                       ByVal Id_card As String, _
                                       ByVal Officialout_type As String, _
                                       ByVal Officialout_dateb As String, _
                                       ByVal Officialout_timeb As String) As DataTable
            Dim sql As New StringBuilder()

            sql.AppendLine(" select * from Officialout_Fee ")
            sql.AppendLine(" where ")
            sql.AppendLine("    Orgcode=@Orgcode ")
            sql.AppendLine("    and Id_card=@Id_card ")
            sql.AppendLine("    and Officialout_type=@Officialout_type ")
            sql.AppendLine("    and Officialout_dateb=@Officialout_dateb ")
            sql.AppendLine("    and Officialout_timeb=@Officialout_timeb ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Officialout_type", SqlDbType.VarChar), _
            New SqlParameter("@Officialout_dateb", SqlDbType.VarChar), _
            New SqlParameter("@Officialout_timeb", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Id_card
            params(2).Value = Officialout_type
            params(3).Value = Officialout_dateb
            params(4).Value = Officialout_timeb

            Return Query(sql.ToString, params)
        End Function



        Public Function DeleteData(ByVal Serial_nos As Integer) As Integer
            Dim sql As New StringBuilder()

            sql.Append(" DELETE ")
            sql.Append(" FROM ")
            sql.Append("     Officialout_Fee ")
            sql.Append(" WHERE ")
            sql.Append("     Serial_nos = @Serial_nos ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Serial_nos", SqlDbType.Int)}
            params(0).Value = Serial_nos

            Return Execute(sql.ToString(), params)
        End Function

        Public Function deleteDataByFlowId(ByVal Orgcode As String, ByVal Flow_id As String) As Integer
            Dim sql As New StringBuilder()

            sql.Append(" DELETE ")
            sql.Append(" FROM ")
            sql.Append("     Officialout_Fee ")
            sql.Append(" WHERE ")
            sql.Append("     Orgcode = @Orgcode ")
            sql.Append("     and ppguid = @Flow_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Flow_id", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Flow_id

            Return Execute(sql.ToString(), params)
        End Function


        Public Function UpdateStatus(ByVal Orgcode As String, _
                                     ByVal DepartId As String, _
                                     ByVal IdCard As String, _
                                     ByVal Officialout_type As String, _
                                     ByVal Officialout_dateb As String, _
                                     ByVal Officialout_timeb As String, _
                                     ByVal Status As String, _
                                     ByVal Pay_mark As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" UPDATE ")
            sql.AppendLine("     Officialout_Fee ")
            sql.AppendLine(" SET ")
            sql.AppendLine("    Status=@Status ")
            sql.AppendLine("    ,Pay_mark=@Pay_Mark ")
            sql.AppendLine("    ,Print_mark='' ")
            sql.AppendLine(" WHERE ")
            sql.AppendLine("     Orgcode = @Orgcode ")
            sql.AppendLine("     AND Depart_id = @Depart_id ")
            sql.AppendLine("     AND Id_card = @Id_card ")
            sql.AppendLine("     AND Officialout_type = @Officialout_type ")
            sql.AppendLine("     AND Officialout_dateb = @Officialout_dateb ")
            sql.AppendLine("     AND Officialout_timeb = @Officialout_timeb ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Status", SqlDbType.VarChar), _
            New SqlParameter("@Pay_Mark", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Officialout_type", SqlDbType.VarChar), _
            New SqlParameter("@Officialout_dateb", SqlDbType.VarChar), _
            New SqlParameter("@Officialout_timeb", SqlDbType.VarChar)}
            params(0).Value = Status
            params(1).Value = Pay_mark
            params(2).Value = Orgcode
            params(3).Value = DepartId
            params(4).Value = IdCard
            params(5).Value = Officialout_type
            params(6).Value = Officialout_dateb
            params(7).Value = Officialout_timeb
            Return Execute(sql.ToString, params)
        End Function


        Public Function UpdatePrintMark(ByVal Orgcode As String, _
                                        ByVal DepartId As String, _
                                        ByVal IdCard As String, _
                                        ByVal Officialout_type As String, _
                                        ByVal Officialout_dateb As String, _
                                        ByVal Officialout_timeb As String, _
                                        ByVal Print_mark As String) As Integer

            Dim sql As New StringBuilder
            sql.AppendLine(" UPDATE ")
            sql.AppendLine("     Officialout_Fee ")
            sql.AppendLine(" SET ")
            sql.AppendLine("    Print_mark=@Pay_Mark ")
            sql.AppendLine(" WHERE ")
            sql.AppendLine("     Orgcode = @Orgcode ")
            sql.AppendLine("     AND Depart_id = @Depart_id ")
            sql.AppendLine("     AND Id_card = @Id_card ")
            sql.AppendLine("     AND Officialout_type = @Officialout_type ")
            sql.AppendLine("     AND Officialout_dateb = @Officialout_dateb ")
            sql.AppendLine("     AND Officialout_timeb = @Officialout_timeb ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Pay_mark", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Officialout_type", SqlDbType.VarChar), _
            New SqlParameter("@Officialout_dateb", SqlDbType.VarChar), _
            New SqlParameter("@Officialout_timeb", SqlDbType.VarChar)}
            params(0).Value = Print_mark
            params(1).Value = Orgcode
            params(2).Value = DepartId
            params(3).Value = IdCard
            params(4).Value = Officialout_type
            params(5).Value = Officialout_dateb
            params(6).Value = Officialout_timeb
            Return Execute(sql.ToString, params)
        End Function

    End Class
End Namespace