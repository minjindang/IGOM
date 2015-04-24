Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSCPLM.Logic
    Public Class Car_mainDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub

        Public Function GetData(ByVal OrgCode As String) As DataTable
            Dim sql As String = " SELECT * FROM CAR_Car_main WHERE 1=1 "
            If Not String.IsNullOrEmpty(OrgCode) Then
                sql &= "  and OrgCode =@OrgCode "
            End If

            Dim ps() As SqlParameter = {New SqlParameter("@OrgCode", OrgCode)}

            Return Query(sql, ps)
        End Function




        Public Function GetCarData(ByVal ddlyy1 As String, ByVal ddlyy2 As String, ByVal BrandName As String, _
                                   ByVal ScrapDate As String, ByVal CarID As String) As DataTable
            Dim sqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim strSQL As String = String.Empty
            strSQL = "select Car_id , Buy_date , CylinderCapacity_cnt , Brand_name , Manufacture_date , ComInsurance_date , "
            strSQL &= " Insurance_date , Scrap_date from CAR_Car_main where 1=1 "
            If Not String.IsNullOrEmpty(ddlyy1) AndAlso ddlyy1 <> "0" Then
                strSQL &= " and substring(Buy_date,1,3)   >= @ddlyy1  "
            End If
            If Not String.IsNullOrEmpty(ddlyy2) AndAlso ddlyy2 <> "0" Then
                strSQL &= " and substring(Buy_date,1,3)  <= @ddlyy2  "
            End If
            If Not String.IsNullOrEmpty(BrandName) Then
                strSQL &= " and Brand_name = @BrandName  "
            End If
            If Not String.IsNullOrEmpty(ScrapDate) Then
                strSQL &= " and  Scrap_date= @ScrapDate "
            End If
            If Not String.IsNullOrEmpty(CarID) Then
                strSQL &= " and Car_id = @CarID  "
            End If
            Dim ps() As SqlParameter = { _
            New SqlParameter("@ddlyy1", ddlyy1.PadLeft(3, "0")), _
            New SqlParameter("@ddlyy2", ddlyy2.PadLeft(3, "0")), _
            New SqlParameter("@BrandName", BrandName), _
            New SqlParameter("@ScrapDate", ScrapDate), _
            New SqlParameter("@CarID", CarID)}
            Return Query(strSQL, ps)
        End Function

        Public Function getDeleteData(ByVal Index As String, ByVal ddlyy1 As String, ByVal ddlyy2 As String, ByVal BrandName As String, _
                                   ByVal ScrapDate As String, ByVal CarID As String) As DataTable

            Dim dt As DataTable
            Dim sqlDA As SqlDataAdapter = New SqlDataAdapter
            Dim strSQL As String = String.Empty
            strSQL = " delete from CAR_Car_main where Car_id =@Index "
            Dim ps() As SqlParameter = {New SqlParameter("@Index", Index)}
            Execute(strSQL, ps)
            dt = GetCarData(ddlyy1, ddlyy2, BrandName, ScrapDate, CarID)
            Return dt

        End Function

        'Public Function CAR0301_insert(ByVal carid As String, ByVal madate As String, ByVal buydate As String, ByVal CCcnt As String, _
        '                              ByVal brandname As String, ByVal comInsurance As String, ByVal insurance As String, ByVal scrapdate As String, _
        '                               ByVal moduserid As String, ByVal moddate As Date, ByVal modorg As String) As Integer
        '    Dim sqlDa As SqlDataAdapter = New SqlDataAdapter
        '    Dim strSql As String = String.Empty
        '    strSql = " insert into CAR_Car_main (Car_id, Manufacture_date, Buy_date, CylinderCapacity_cnt, Brand_name, "
        '    strSql &= "ComInsurance_date, Insurance_date, Scrap_date, ModUser_id, Mod_date, OrgCode)"
        '    strSql &= "values(@carid, @madate, @buydate, @CCcnt, @brandname, @comInsurance, @insurance, "
        '    strSql &= "@scrapdate, @moduserid, @moddate, @modorg)"
        '    Dim ps() As SqlParameter = { _
        '             New SqlParameter("@carid", carid), _
        '             New SqlParameter("@madate", madate), _
        '             New SqlParameter("@buydate", buydate), _
        '             New SqlParameter("@CCcnt", CCcnt), _
        '             New SqlParameter("@brandname", brandname), _
        '             New SqlParameter("@comInsurance", comInsurance), _
        '             New SqlParameter("@insurance", insurance), _
        '             New SqlParameter("@scrapdate", scrapdate), _
        '             New SqlParameter("@moduserid", moduserid), _
        '             New SqlParameter("@moddate", moddate), _
        '             New SqlParameter("@modorg", modorg)}
        '    Return Execute(strSql, ps)

        'End Function

        Public Function CAR0301_update(ByVal carid As String, ByVal madate As String, ByVal buydate As String, ByVal CCcnt As String, _
                                     ByVal brandname As String, ByVal comInsurance As String, ByVal insurance As String, ByVal scrapdate As String, _
                                      ByVal moduserid As String, ByVal moddate As Date, ByVal modorg As String) As Integer
            Dim sqlDa As SqlDataAdapter = New SqlDataAdapter
            Dim strSql As String = String.Empty
            ' strSql.AppendLine("update Flow set Next_id=@Next_id,Next_posid=@Next_posid,Next_step=Next_step+1 where Flow_id = @Flow_id")
            strSql = " update CAR_Car_main set  Manufacture_date=@madate, Buy_date=@buydate, CylinderCapacity_cnt=@CCcnt, "
            strSql &= " Brand_name=@brandname,  ComInsurance_date=@comInsurance, Insurance_date=@insurance,  "
            strSql &= "Scrap_date=@scrapdate, ModUser_id=@moduserid, Mod_date=@moddate, OrgCode=@modorg "
            strSql &= "where Car_id=@carid"
            Dim ps() As SqlParameter = { _
                     New SqlParameter("@carid", carid), _
                     New SqlParameter("@madate", madate), _
                     New SqlParameter("@buydate", buydate), _
                     New SqlParameter("@CCcnt", CCcnt), _
                     New SqlParameter("@brandname", brandname), _
                     New SqlParameter("@comInsurance", comInsurance), _
                     New SqlParameter("@insurance", insurance), _
                     New SqlParameter("@scrapdate", scrapdate), _
                     New SqlParameter("@moduserid", moduserid), _
                     New SqlParameter("@moddate", moddate), _
                     New SqlParameter("@modorg", modorg)}
            Return Execute(strSql, ps)

        End Function


        Public Function CAR0301_GetCarData(ByVal CarID As String) As DataTable
            Dim sqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim strSQL As String = String.Empty
            strSQL = "select Car_id , Buy_date , CylinderCapacity_cnt , Brand_name , Manufacture_date , ComInsurance_date , "
            strSQL &= " Insurance_date , Scrap_date from CAR_Car_main where 1=1"
            If Not String.IsNullOrEmpty(CarID) Then
                strSQL &= "and Car_id  = @CarID  "
            End If
            Dim ps() As SqlParameter = {New SqlParameter("@CarID", CarID)}
            Return Query(strSQL, ps)

        End Function

        'Public Function checkCaridData(ByVal carid As String) As Integer
        '    Dim dt As DataTable
        '    Dim sqlDA As SqlDataAdapter = New SqlDataAdapter()
        '    Dim strSQL As String = String.Empty
        '    strSQL = "select Car_id from CAR_Car_main where Car_id=@CarID "
        '    ' strSQL = "insert into  CAR_Car_main  (Car_id)  values (@CarID)"
        '    Dim ps() As SqlParameter = {New SqlParameter("@CarID", carid)}
        '    Return Execute(strSQL, ps)
        'End Function

        Public Function checkCarid(ByVal carid As String) As DataTable
            Dim dt As DataTable
            Dim sqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim strSQL As String = String.Empty
            strSQL = "select Car_id from CAR_Car_main where Car_id=@CarID "
            ' strSQL = "insert into  CAR_Car_main  (Car_id)  values (@CarID)"
            Dim ps() As SqlParameter = {New SqlParameter("@CarID", carid)}
            Return Query(strSQL, ps)

        End Function

        Public Function CAR0301_insertData(ByVal carid As String, ByVal madate As String, ByVal buydate As String, ByVal CCcnt As String, _
                                     ByVal brandname As String, ByVal comInsurance As String, ByVal insurance As String, ByVal scrapdate As String, _
                                      ByVal moduserid As String, ByVal moddate As Date, ByVal modorg As String) As String
            Dim memo As String
            Dim sqlDa As SqlDataAdapter = New SqlDataAdapter
            Dim strSql As String = String.Empty
            strSql = " insert into CAR_Car_main (Car_id, Manufacture_date, Buy_date, CylinderCapacity_cnt, Brand_name, "
            strSql &= "ComInsurance_date, Insurance_date, Scrap_date, ModUser_id, Mod_date, OrgCode,Status_type)"
            strSql &= "values(@carid, @madate, @buydate, @CCcnt, @brandname, @comInsurance, @insurance, "
            strSql &= "@scrapdate, @moduserid, @moddate, @modorg,'001')"
            Dim ps() As SqlParameter = { _
                     New SqlParameter("@carid", carid), _
                     New SqlParameter("@madate", madate), _
                     New SqlParameter("@buydate", buydate), _
                     New SqlParameter("@CCcnt", CCcnt), _
                     New SqlParameter("@brandname", brandname), _
                     New SqlParameter("@comInsurance", comInsurance), _
                     New SqlParameter("@insurance", insurance), _
                     New SqlParameter("@scrapdate", scrapdate), _
                     New SqlParameter("@moduserid", moduserid), _
                     New SqlParameter("@moddate", moddate), _
                     New SqlParameter("@modorg", modorg)}
            Execute(strSql, ps)
            memo = "新增成功"
            Return memo
        End Function


        Public Function GetcarName(OrgCode As String, Optional Car_type As String = "") As DataTable
            Dim sql As String = " SELECT DISTINCT [Car_name] FROM [CAR_Car_main]  WHERE 1=1 "
            If Not String.IsNullOrEmpty(OrgCode) Then
                sql &= "  and OrgCode =@OrgCode "
            End If

            If Not String.IsNullOrEmpty(OrgCode) Then
                sql &= "  and Car_type =@Car_type "
            End If

            Dim ps() As SqlParameter = { _
                New SqlParameter("@OrgCode", OrgCode), _
                New SqlParameter("@Car_type", Car_type) _
            }

            Return Query(sql, ps)
        End Function

        Public Function GetcarId(ByVal Carname As String) As DataTable
            Dim sql As String = " SELECT  Car_id  FROM [CAR_Car_main]  WHERE 1=1 "
            If Not String.IsNullOrEmpty(Carname) Then
                sql &= "  and Car_name =@Carname "
            End If

            Dim ps() As SqlParameter = {New SqlParameter("@Carname", Carname)}

            Return Query(sql, ps)
        End Function

        Public Function CAR1103_SELECT(ByVal ucCar_Type As String, ByVal ddlCar_Name As String, ByVal ddlCar_Id As String, _
                                       ByVal rdo_Status As String) As DataTable
            Dim sql As String = " Select  Car_name, Car_id, UsedUnit_code,   "
            sql &= " dbo.SYS_CodeDesc('015','002',a.Car_type) AS Car_type,  "
            sql &= " dbo.SYS_CodeDesc('015','005',a.Status_type) AS Status_type,  "
            sql &= " dbo.SYS_CodeDesc('015','008',a.NeedVerify_type) AS NeedVerify_type "
            sql &= " from  CAR_Car_main a "
          
            sql &= " WHERE 1=1  "
            If Not String.IsNullOrEmpty(ucCar_Type) AndAlso ucCar_Type <> "-1" Then
                sql &= "  and Car_type =@ucCar_Type  "
            End If
            If Not String.IsNullOrEmpty(ddlCar_Name) AndAlso ddlCar_Name <> "0" Then
                sql &= "  and Car_name =@ddlCar_Name  "
            End If
            If Not String.IsNullOrEmpty(ddlCar_Id) AndAlso ddlCar_Id <> "0" Then
                sql &= "  and Car_id =@ddlCar_Id  "
            End If
            If Not String.IsNullOrEmpty(rdo_Status) Then
                sql &= "  and Status_type =@rdo_Status  order by Car_id"
            End If

            Dim ps() As SqlParameter = { _
                     New SqlParameter("@ucCar_Type", ucCar_Type), _
                     New SqlParameter("@ddlCar_Name", ddlCar_Name), _
                     New SqlParameter("@ddlCar_Id", ddlCar_Id), _
                     New SqlParameter("@rdo_Status", rdo_Status)}

            Return Query(sql, ps)
        End Function


        Public Function newlist(ByVal Orgcode As String) As DataTable
            Dim sql As String = "select DISTINCT Depart_name , Depart_id from FSCorg order by Depart_id  "
            If Not String.IsNullOrEmpty(Orgcode) Then
                sql &= "  and OrgCode =@Orgcode  "
            End If
            Dim ps() As SqlParameter = {New SqlParameter("@Orgcode", Orgcode)}
            Return Query(sql, ps)
        End Function

        Public Function getAll(ByVal Carid As String) As DataTable
            Dim sql As String = "Select Car_type, Car_name, Car_id, NeedVerify_type, UsedUnit_code, Status_type from CAR_Car_main  where 1=1 "
            If Not String.IsNullOrEmpty(Carid) Then
                sql &= "and Car_id=@Carid"
            End If
            Dim ps() As SqlParameter = {New SqlParameter("@Carid", Carid)}
            Return Query(sql, ps)
        End Function

        Public Function CAR1103_update(ByVal ucCar_Type As String, ByVal ddlCar_Name As String, ByVal Car_Id As String, _
                                            ByVal rdo_Status As String, ByVal rdo_Verify As String, ByVal used_Unit As String(), ByVal moduserid As String, ByVal moddate As String, ByVal modorg As String) As Integer
            Dim Unit As String = ""
            For i As Int16 = 0 To used_Unit.Length - 1
                If i = 0 Then
                    Unit += used_Unit(i)
                Else
                    Unit += "," & used_Unit(i)
                End If
            Next

            Dim sqlDa As SqlDataAdapter = New SqlDataAdapter
            Dim strSql As String = String.Empty
            strSql = " update CAR_Car_main set  Car_type=@ucCar_Type, Car_name=@ddlCar_Name, Status_type=@rdo_Status, "
            strSql &= " NeedVerify_type=@rdo_Verify, UsedUnit_code=@used_Unit , "
            strSql &= "ModUser_id=@moduserid, Mod_date=@moddate, OrgCode=@modorg "
            strSql &= "where Car_id=@Car_Id "
            Dim ps() As SqlParameter = { _
                     New SqlParameter("@ucCar_Type", ucCar_Type), _
                     New SqlParameter("@ddlCar_Name", ddlCar_Name), _
                     New SqlParameter("@rdo_Status", rdo_Status), _
                     New SqlParameter("@rdo_Verify", rdo_Verify), _
                     New SqlParameter("@used_Unit", Unit), _
                     New SqlParameter("@moduserid", moduserid), _
                    New SqlParameter("@moddate", moddate), _
                    New SqlParameter("@modorg", modorg), _
                    New SqlParameter("@Car_Id", Car_Id)}
            Return Execute(strSql, ps)
        End Function

        Public Function Car_1104Select(ByVal Start_date As String, ByVal End_date As String, ByVal Car_name As String, ByVal Car_id As String, ByVal Sort_style1 As String, ByVal Sort_style2 As String) As DataTable
            Dim strSql As New System.Text.StringBuilder

            strSql.Append(" SELECT ")
            strSql.Append(" C1.CODE_DESC1 Car_name, ")
            strSql.Append(" CM.Car_id, ")
            strSql.Append(" CDM.Start_date + '~' + CDM.End_date  AS Car_date, ")
            strSql.Append(" C2.CODE_DESC1 + '~' + C3.CODE_DESC1 AS Car_time, ")
            strSql.Append(" CDM.Passenger_cnt, ")
            strSql.Append(" (SELECT TOP 1 USER_NAME FROM EMP_Member WHERE  id_card = CDD.DriverUser_id) AS DriverUser_id, ")
            strSql.Append(" CDM.Phone_nos, ")
            strSql.Append(" (SELECT TOP 1 USER_NAME FROM EMP_Member WHERE  id_card = CDM.User_id) AS User_id, ")
            strSql.Append(" CDM.Destination_desc, ")
            strSql.Append(" CDM.Reason_desc ")
            strSql.Append(" FROM CAR_CarDispatch_main CDM ")
            strSql.Append(" LEFT JOIN CAR_CarDispatch_det CDD  ON CDD.Flow_id=CDM.Flow_id AND CDM.OrgCode = CDD.OrgCode ")
            strSql.Append(" LEFT JOIN CAR_Car_main CM ON CDD.Car_id=CM.Car_id ")
            strSql.Append(" LEFT JOIN sys_code C1 ON C1.CODE_NO=CDM.Car_type AND C1.code_sys='015' AND C1.CODE_TYPE='011' ")
            strSql.Append(" LEFT JOIN sys_code C2 ON C2.CODE_NO=CDM.Start_time AND C2.code_sys = '015' AND C2.CODE_TYPE = '006' ")
            strSql.Append(" LEFT JOIN sys_code C3 ON C3.CODE_NO=CDM.Start_time AND C3.code_sys = '015' AND C3.CODE_TYPE = '006' ")
            strSql.Append(" WHERE 1=1 ")

            If Not String.IsNullOrEmpty(Start_date) Then
                strSql.Append(" AND CDM.Start_date>= @Start_date ")
            End If
            If Not String.IsNullOrEmpty(End_date) Then
                strSql.Append(" AND CDM.End_date<= @End_date ")
            End If
            If Not String.IsNullOrEmpty(Car_name) Then
                strSql.Append(" AND CDM.Car_name =@Car_name ")
            Else
                strSql.Append(" AND CDM.CAR_NAME IS NOT NULL ")
            End If
            If Not String.IsNullOrEmpty(Car_id) Then
                strSql.Append(" AND CDD.Car_id =@Car_id ")
            Else
                strSql.Append(" AND CDD.Car_id IS NOT NULL ")
            End If
            If Not String.IsNullOrEmpty(Sort_style1) AndAlso Not String.IsNullOrEmpty(Sort_style2) Then
                strSql.Append(" ORDER BY ")
                If Not String.IsNullOrEmpty(Sort_style1) Then
                    If Sort_style1 = "001" Then '用車日期
                        strSql.Append(" CDM.Start_date ")
                    ElseIf Sort_style1 = "002" Then '用車時間
                        strSql.Append(" CDM.Start_time ")
                    ElseIf Sort_style1 = "003" Then '資源種類
                        strSql.Append(" CDM.Use_type ")
                    ElseIf Sort_style1 = "004" Then '車牌
                        strSql.Append(" CDD.Car_id ")
                    End If
                End If

                If Not String.IsNullOrEmpty(Sort_style2) Then
                    If Sort_style2 = "001" Then
                        If Not Sort_style1.Equals(Sort_style2) Then
                            strSql.Append(" ,CDM.Start_date ")
                        End If
                    ElseIf Sort_style2 = "002" Then
                        If Not Sort_style1.Equals(Sort_style2) Then

                            strSql.Append(" ,CDM.Start_time ")
                        End If
                    ElseIf Sort_style2 = "003" Then
                        If Not Sort_style1.Equals(Sort_style2) Then
                            strSql.Append(" ,CDM.Use_type ")
                        End If
                    ElseIf Sort_style2 = "004" Then
                        If Not Sort_style1.Equals(Sort_style2) Then
                            strSql.Append(" ,CDD.Car_id ")
                        End If
                    End If
                End If
            End If

            Dim ps() As SqlParameter = { _
                    New SqlParameter("@Start_date", Start_date), _
                    New SqlParameter("@End_date", End_date), _
                    New SqlParameter("@Car_name", Car_name), _
                    New SqlParameter("@Car_id", Car_id), _
                    New SqlParameter("@Sort_style1", Sort_style1), _
                    New SqlParameter("@Sort_style2", Sort_style2)}
            Return Query(strSql.ToString(), ps)
        End Function

    End Class
End Namespace


