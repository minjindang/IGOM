Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports Pemis2009.SQLAdapter

Namespace FSC.Logic
    Public Class FSC3115DAO
        Inherits BaseDAO

        Dim dtData As DataTable
        Dim sbSQL As New StringBuilder()
        Dim szSQL As String = String.Empty

#Region "資料庫作業"
        Function Query01(ByVal szConn As String, ByVal sSQL As String) As DataTable
            Dim szAppSettings = String.Empty

            If szConn = "DBString" Then
                szAppSettings = ConfigurationManager.AppSettings("DBString").ToString()
            End If
            If szConn = "Synchronous01" Then
                szAppSettings = ConfigurationManager.AppSettings("DBString_Synchronous01").ToString()
            End If
            If szConn = "Synchronous02" Then
                szAppSettings = ConfigurationManager.AppSettings("DBString_Synchronous02").ToString()
            End If
            If szConn = "DBString_Synchronous03" Then
                szAppSettings = ConfigurationManager.AppSettings("DBString_Synchronous03").ToString()
            End If

            Try
                Return SqlAccessHelper.ExecuteDataset(szAppSettings, CommandType.Text, sSQL).Tables(0)
            Catch ex As Exception
                Throw
            End Try
        End Function

        Function Query02(ByVal szConn As String, ByVal sSQL As String, ByVal ParamArray parms As SqlParameter()) As DataTable
            Dim szAppSettings = String.Empty

            If szConn = "DBString" Then
                szAppSettings = ConfigurationManager.AppSettings("DBString").ToString()
            End If
            If szConn = "Synchronous01" Then
                szAppSettings = ConfigurationManager.AppSettings("DBString_Synchronous01").ToString()
            End If
            If szConn = "Synchronous02" Then
                szAppSettings = ConfigurationManager.AppSettings("DBString_Synchronous02").ToString()
            End If
            If szConn = "DBString_Synchronous03" Then
                szAppSettings = ConfigurationManager.AppSettings("DBString_Synchronous03").ToString()
            End If

            Try
                DBUtil.SetParamsNull(parms)
                Return SqlAccessHelper.ExecuteDataset(szAppSettings, CommandType.Text, sSQL, parms).Tables(0)
            Catch ex As Exception
                Throw
            End Try
        End Function

        Function FSC_Execute(ByVal sSQL As String, ByVal ParamArray parms As SqlParameter()) As Integer
            Dim szAppSettings = String.Empty
            szAppSettings = ConfigurationManager.AppSettings("DBString").ToString()

            Try
                DBUtil.SetParamsNull(parms)
                Return SqlAccessHelper.ExecuteNonQuery(szAppSettings, CommandType.Text, sSQL, parms)
            Catch ex As Exception
                Throw
            End Try
        End Function

#End Region

        ''' <summary>
        ''' 取出P2K資料->將P2K資料，寫入差勤系統
        ''' </summary>
        ''' <param name="dbName">P2K的連線名稱</param>
        ''' <param name="PECARD">員工代號</param>
        ''' <param name="PENAME">姓名</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetData_InsertData_ToIGOMDB(ByVal dbName As String, ByVal PECARD As String, ByVal PENAME As String) As DataTable
            ' STEP01.取出P2K資料
            szSQL = ""
            szSQL &= " SELECT PEACTDATE,PELEVDATE,PEPOINT,PEPROFESS,PECHIEF,PEIDNO,PECARD,PENAME "
            szSQL &= " FROM CPAPE05M WHERE 1=1 "

            If PECARD <> "" Then
                szSQL &= " AND PECARD='" + PECARD + "' "
            End If

            If PENAME <> "" Then
                szSQL &= " AND PENAME='" + PENAME + "' "
            End If
            dtData = Query01(dbName, szSQL.ToString())

            If IsDBNull(dtData) = False And dtData.Rows.Count > 0 Then
                ' STEP02.將P2K資料，寫入差勤系統
                For r As Integer = 0 To dtData.Rows.Count - 1
                    Dim PEACTDATE As String = Convert.ToString(dtData.Rows(r).Item(0).ToString.Trim)
                    Dim PELEVDATE As String = Convert.ToString(dtData.Rows(r).Item(1).ToString.Trim)
                    Dim PEPOINT As String = Convert.ToString(dtData.Rows(r).Item(2).ToString.Trim)
                    Dim PEPROFESS As String = Convert.ToString(dtData.Rows(r).Item(3).ToString.Trim)
                    Dim PECHIEF As String = Convert.ToString(dtData.Rows(r).Item(4).ToString.Trim)
                    Dim PEIDNO As String = Convert.ToString(dtData.Rows(r).Item(5).ToString.Trim)
                    Dim PECARD2 As String = Convert.ToString(dtData.Rows(r).Item(6).ToString.Trim)
                    Dim PENAME2 As String = Convert.ToString(dtData.Rows(r).Item(7).ToString.Trim)

                    ' 第一次寫入前，先清除temp資料
                    If r = 0 Then
                        TruncateTmpTable()
                    End If

                    InsertToTmpTable(PEACTDATE, PELEVDATE, PEPOINT, PEPROFESS, PECHIEF, PEIDNO, PECARD2, PENAME2)
                Next
            End If
            Return dtData
        End Function

        ''' <summary>
        ''' 清除tmp資料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function TruncateTmpTable() As Integer
            sbSQL.AppendLine(" TRUNCATE TABLE CPAPE05M_TMP ")

            Return FSC_Execute(sbSQL.ToString())
        End Function

        ''' <summary>
        ''' 將P2K資料，寫入差勤系統
        ''' </summary>
        ''' <param name="PEACTDATE">到職日期</param>
        ''' <param name="PELEVDATE">離職日期</param>
        ''' <param name="PEPOINT">俸點</param>
        ''' <param name="PEPROFESS">專業加給</param>
        ''' <param name="PECHIEF">主管職務加給</param>
        ''' <param name="PEIDNO">身分證字號</param>
        ''' <param name="PECARD">員工代號</param>
        ''' <param name="PENAME">姓名</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertToTmpTable(PEACTDATE As String, ByVal PELEVDATE As String, ByVal PEPOINT As String, ByVal PEPROFESS As String, ByVal PECHIEF As String, ByVal PEIDNO As String, ByVal PECARD As String, ByVal PENAME As String) As Integer
            sbSQL.Length = 0
            sbSQL.AppendLine(" INSERT INTO CPAPE05M_TMP (PEACTDATE,PELEVDATE,PEPOINT,PEPROFESS,PECHIEF,PEIDNO,PECARD,PENAME) ")
            sbSQL.AppendLine(" VALUES  ")
            sbSQL.AppendLine(" (@PEACTDATE,@PELEVDATE,@PEPOINT,@PEPROFESS,@PECHIEF,@PEIDNO,@PECARD,@PENAME) ")

            Dim params() As SqlParameter = { _
              New SqlParameter("@PEACTDATE", PEACTDATE), _
              New SqlParameter("@PELEVDATE", PELEVDATE), _
              New SqlParameter("@PEPOINT", PEPOINT), _
              New SqlParameter("@PEPROFESS", PEPROFESS), _
              New SqlParameter("@PECHIEF", PECHIEF), _
              New SqlParameter("@PEIDNO", PEIDNO), _
              New SqlParameter("@PECARD", PECARD), _
              New SqlParameter("@PENAME", PENAME)}

            Return FSC_Execute(sbSQL.ToString(), params)
        End Function

        ''' <summary>
        ''' 取出差異資料
        ''' </summary>
        ''' <param name="PECARD">員工代號</param>
        ''' <param name="PENAME">姓名</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDifferenceData(ByVal PECARD As String, ByVal PENAME As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT CT.PECARD,CT.PENAME,'**********'  PEIDNO,CT.PEIDNO PEIDNO2, ")
            sbSQL.AppendLine(" CASE WHEN CT.PEACTDATE<>FSC.ACT_Date THEN '差異' ")
            sbSQL.AppendLine(" WHEN CT.PEACTDATE<>SAL.BASE_BDATE THEN '差異' ")
            sbSQL.AppendLine(" WHEN CT.PEACTDATE<>FP.Act_date THEN '差異' ELSE '無差異' END PEACTDATE, ")

            sbSQL.AppendLine(" CASE WHEN CT.PELEVDATE<>FSC.Left_date THEN '差異' ")
            sbSQL.AppendLine(" WHEN CT.PELEVDATE<>SAL.BASE_EDATE THEN '差異' ")
            sbSQL.AppendLine(" WHEN CT.PELEVDATE<>FP.Left_date THEN '差異' ")
            sbSQL.AppendLine(" ELSE '無差異' END PELEVDATE, ")

            sbSQL.AppendLine(" CASE WHEN CT.PEPOINT<>SAL.BASE_PTB THEN '差異' ")
            sbSQL.AppendLine(" ELSE '無差異' END PEPOINT, ")

            sbSQL.AppendLine(" CASE WHEN CT.PEPROFESS<>FSC.PEPROFESS THEN '差異' ")
            sbSQL.AppendLine(" ELSE '無差異' END PEPROFESS, ")

            sbSQL.AppendLine(" CASE WHEN CT.PECHIEF<>FSC.PECHIEF THEN '差異' ")
            sbSQL.AppendLine(" ELSE '無差異' END PECHIEF ")

            sbSQL.AppendLine(" FROM CPAPE05M_TMP CT ")
            sbSQL.AppendLine(" LEFT JOIN FSC_Personnel FSC ON FSC.Id_card=CT.PECARD AND FSC.Id_number=CT.PEIDNO ")
            sbSQL.AppendLine(" LEFT JOIN SAL_SABASE SAL ON SAL.BASE_SEQNO=CT.PECARD AND SAL.BASE_IDNO=CT.PEIDNO ")
            sbSQL.AppendLine(" LEFT JOIN FSC_Personnel FP ON FP.ID_CARD=CT.PECARD AND FP.Id_number=CT.PEIDNO ")
            sbSQL.AppendLine(" WHERE 1 = 1 ")

            If PECARD <> "" Then
                sbSQL.AppendLine(" AND CT.PECARD=@PECARD ")
            End If

            If PENAME <> "" Then
                sbSQL.AppendLine(" AND CT.PENAME=@PENAME ")
            End If

            Dim params() As SqlParameter = { _
                  New SqlParameter("@PECARD", PECARD), _
                  New SqlParameter("@PENAME", PENAME)}

            Return Query02("DBString", sbSQL.ToString(), params)
        End Function

        ''' <summary>
        ''' 取出差異明細資料(P2K.FSC.SAL.EMP)
        ''' </summary>
        ''' <param name="PECARD">員工代號</param>
        ''' <param name="PEIDNO">身份證字號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDifferenceDetailsData(ByVal PECARD As String, ByVal PEIDNO As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT 1 AS PKEY,'P2K' TABLENAME,PEACTDATE,PELEVDATE,PEPOINT,PEPROFESS,PECHIEF,PECARD,PENAME,'**********' PEIDNO,PEIDNO PEIDNO2 ")
            sbSQL.AppendLine(" FROM CPAPE05M_TMP ")
            sbSQL.AppendLine(" WHERE 1=1 ")

            If PECARD <> "" Then
                sbSQL.AppendLine(" AND PECARD=@PECARD ")
            End If

            If PEIDNO <> "" Then
                sbSQL.AppendLine(" AND PEIDNO=@PEIDNO ")
            End If

            sbSQL.AppendLine(" UNION ")

            sbSQL.AppendLine(" SELECT 2 AS PKEY,'FSC',ACT_Date,Left_date,'','','',Id_card,User_name,'',ID_NUMBER ")
            sbSQL.AppendLine(" FROM FSC_Personnel ")
            sbSQL.AppendLine(" WHERE  1=1 ")

            If PECARD <> "" Then
                sbSQL.AppendLine(" AND ID_CARD=@PECARD ")
            End If

            If PEIDNO <> "" Then
                sbSQL.AppendLine(" AND Id_number=@PEIDNO ")
            End If

            sbSQL.AppendLine(" UNION ")

            sbSQL.AppendLine(" SELECT 3 AS PKEY,'SAL',BASE_BDATE,BASE_EDATE,BASE_PTB,'','',BASE_SEQNO,BASE_NAME,'',BASE_IDNO ")
            sbSQL.AppendLine(" FROM SAL_SABASE ")
            sbSQL.AppendLine(" WHERE 1=1 ")

            If PECARD <> "" Then
                sbSQL.AppendLine(" AND BASE_SEQNO=@PECARD ")
            End If

            If PEIDNO <> "" Then
                sbSQL.AppendLine(" AND BASE_IDNO=@PEIDNO ")
            End If


            sbSQL.AppendLine(" UNION ")

            sbSQL.AppendLine(" SELECT 4 AS PKEY,'EMP',Act_date,Left_date,'','','',Id_card,User_name,'',ID_NUMBER ")
            sbSQL.AppendLine("FROM EMP_Member ")
            sbSQL.AppendLine(" WHERE 1=1 ")

            If PECARD <> "" Then
                sbSQL.AppendLine(" AND ID_CARD=@PECARD ")
            End If

            If PEIDNO <> "" Then
                sbSQL.AppendLine(" AND Id_number=@PEIDNO ")
            End If

            sbSQL.AppendLine(" ORDER BY PKEY ")

            Dim params() As SqlParameter = { _
                 New SqlParameter("@PECARD", PECARD), _
                 New SqlParameter("@PEIDNO", PEIDNO)}

            Return Query02("DBString", sbSQL.ToString(), params)
        End Function

        ''' <summary>
        ''' 更新員工差勤基本資料檔(FSC_Personnel)
        ''' </summary>
        ''' <param name="PECARD">員工代號</param>
        ''' <param name="PEIDNO">身分證字號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateFSC(ByVal PECARD As String, ByVal PEIDNO As String) As Integer
            sbSQL.Length = 0
            sbSQL.AppendLine(" UPDATE FSC_Personnel ")
            sbSQL.AppendLine(" SET ")
            sbSQL.AppendLine(" ACT_Date=(SELECT PEACTDATE FROM CPAPE05M_TMP WHERE PECARD=@PECARD AND PEIDNO=@PEIDNO), ")
            sbSQL.AppendLine(" Left_date=(SELECT PELEVDATE FROM CPAPE05M_TMP WHERE PECARD=@PECARD AND PEIDNO=@PEIDNO), ")
            sbSQL.AppendLine(" PEPOINT=(SELECT PEPOINT FROM CPAPE05M_TMP WHERE PECARD=@PECARD AND PEIDNO=@PEIDNO), ")
            sbSQL.AppendLine(" PEPROFESS=(SELECT PEPROFESS FROM CPAPE05M_TMP WHERE PECARD=@PECARD AND PEIDNO=@PEIDNO), ")
            sbSQL.AppendLine(" PECHIEF=(SELECT PECHIEF FROM CPAPE05M_TMP WHERE PECARD=@PECARD AND PEIDNO=@PEIDNO) ")
            sbSQL.AppendLine(" WHERE ID_CARD=@PECARD AND Id_number=@PEIDNO ")

            Dim params() As SqlParameter = { _
                  New SqlParameter("@PEIDNO", PEIDNO), _
                  New SqlParameter("@PECARD", PECARD)}

            Return FSC_Execute(sbSQL.ToString(), params)
        End Function

        ''' <summary>
        ''' 更新人員薪資資料檔(SAL_SABASE)
        ''' </summary>
        ''' <param name="PECARD">員工代號</param>
        ''' <param name="PEIDNO">身分證字號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateSAL(ByVal PECARD As String, ByVal PEIDNO As String) As Integer
            sbSQL.Length = 0
            sbSQL.AppendLine(" UPDATE SAL_SABASE ")
            sbSQL.AppendLine(" SET ")
            sbSQL.AppendLine(" BASE_BDATE=(SELECT PEACTDATE FROM CPAPE05M_TMP WHERE PECARD=@PECARD AND PEIDNO=@PEIDNO), ")
            sbSQL.AppendLine(" BASE_EDATE=(SELECT PELEVDATE FROM CPAPE05M_TMP WHERE PECARD=@PECARD AND PEIDNO=@PEIDNO), ")
            sbSQL.AppendLine(" BASE_PTB=(SELECT PEPOINT FROM CPAPE05M_TMP WHERE PECARD=@PECARD AND PEIDNO=@PEIDNO) ")
            sbSQL.AppendLine(" WHERE BASE_SEQNO=@PECARD AND BASE_IDNO=@PEIDNO ")

            Dim params() As SqlParameter = { _
                          New SqlParameter("@PEIDNO", PEIDNO), _
                          New SqlParameter("@PECARD", PECARD)}

            Return FSC_Execute(sbSQL.ToString(), params)
        End Function

        ''' <summary>
        ''' 更新員工基本資料檔(EMP_Member)
        ''' </summary>
        ''' <param name="PECARD">員工代號</param>
        ''' <param name="PEIDNO">身分證字號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateEMP(ByVal PECARD As String, ByVal PEIDNO As String) As Integer
            sbSQL.Length = 0
            sbSQL.AppendLine(" UPDATE EMP_Member ")
            sbSQL.AppendLine(" SET ")
            sbSQL.AppendLine(" Act_date=(SELECT PEACTDATE FROM CPAPE05M_TMP WHERE PECARD=@PECARD AND PEIDNO=@PEIDNO), ")
            sbSQL.AppendLine(" Left_date=(SELECT PELEVDATE FROM CPAPE05M_TMP WHERE PECARD=@PECARD AND PEIDNO=@PEIDNO) ")
            sbSQL.AppendLine(" WHERE ID_CARD=@PECARD AND Id_number=@PEIDNO ")

            Dim params() As SqlParameter = { _
              New SqlParameter("@PEIDNO", PEIDNO), _
              New SqlParameter("@PECARD", PECARD)}

            Return FSC_Execute(sbSQL.ToString(), params)
        End Function

    End Class
End Namespace
