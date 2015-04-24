Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class SAL_SABASE
        Public DAO As SAL_SABASEDAO

        Public Sub New()
            DAO = New SAL_SABASEDAO()
        End Sub
        Public Function GetIDNO(BASE_IDNO As String) As DataRow
            Dim dt As DataTable = DAO.SelectIDNO(BASE_IDNO)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetOne(BASE_SEQNO As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(BASE_SEQNO)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll() As DataTable
            Dim dt As DataTable = DAO.SelectAll()
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(BASE_SEQNO As String, BASE_IDNO As String, BASE_STATUS As String, BASE_TYPE As String, BASE_ORGID As String, _
BASE_NAME As String, BASE_SEX As String, BASE_JOB_DATE As String, BASE_DEP As String, BASE_BDATE As String, _
BASE_EDATE As String, BASE_JOB As String, BASE_DCODE As String, BASE_ORG_L1 As String, BASE_ORG_L2 As String, _
BASE_ORG_L3 As String, BASE_AGEN As String, BASE_IN_L1 As String, BASE_IN_L3 As String, BASE_PTB As String, _
BASE_PROV As String, BASE_ADDR As String, BASE_QUIT_DATE As String, BASE_QUIT_REZN As String, BASE_ERMK As String, _
BASE_PRONO As String, BASE_KDB As String, BASE_KDC As String, BASE_KDP As String, BASE_KDO As String, _
BASE_POL As String, BASE_HOUS As String, BASE_WELG As String, BASE_WELO As String, BASE_PRE As String, _
BASE_OTHER_SAL As String, BASE_PRED As String, BASE_PRIZ As String, BASE_TAX As String, BASE_FINS_KIND As String, _
BASE_PN_Y30 As String, BASE_FINS_NOQ As Double, BASE_FINS_NOH As Double, BASE_FINS_NOF As Double, BASE_FINS_NOL As Double, _
BASE_FINS_SELF As Double, BASE_FINS_NO As Double, BASE_DAY_SAL As Double, BASE_HOUR_SAL As Double, BASE_DCT_A As Double, _
BASE_DCT_B As Double, BASE_DCT_C As Double, BASE_COUNT_REMARK As String, BASE_MEMO As String, BASE_MUSER As String, _
BASE_MDATE As String, BASE_KDC_SERIES As String, BASE_KDP_SERIES As String, BASE_LABOR_SERIES As String, BASE_PRTS As Double, _
BASE_FIN_AMT As Double, BASE_TAX_DCT As Double, BASE_LABOR_STATUS As String, BASE_SENTMAIL As String, BASE_EMAIL As String, _
BASE_FIN_SUP_AMT As Double, BASE_REPLACE_AMT As Double, BASE_GOVADOF As String, BASE_LAB_JIF As String, base_fins_noq_nol As Double, _
base_fins_noh_nol As Double, BASE_FINS_Y65 As Double, BASE_FINS_SERIES As String, Base_IsMarked As String, BASE_PEN_RATE As Double, _
BASE_PEN_TYPE As String, BASE_PROF As String, BASE_PEN_SERIES As String, BASE_NUMERATOR As Double, BASE_DENOMINATOR As Double, _
BASE_PTB_TYPE As String, BASE_ALT_AMT As Double, BASE_MEMO1 As String, BASE_MEMO2 As String, BASE_MEMO3 As String, _
BASE_DCODE_NAME As String, BASE_SENTMSG As String, BASE_FINS_HEALTH_SELF As Double, BASE_PROJ_BDATE As String, BASE_PROJ_EDATE As String, _
BASE_LAB1 As String, BASE_LAB2 As String, BASE_LAB3 As String, BASE_PARTTIME As String, BASE_FINS_SELF_DESC As String, BASE_FINS_PAR_DESC As String, BASE_SERVICE_PLACE_DESC As String)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(BASE_SEQNO) Then
                psList.Add(New SqlParameter("@BASE_SEQNO", BASE_SEQNO))
            Else
                psList.Add(New SqlParameter("@BASE_SEQNO", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_IDNO) Then
                psList.Add(New SqlParameter("@BASE_IDNO", BASE_IDNO))
            Else
                psList.Add(New SqlParameter("@BASE_IDNO", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_STATUS) Then
                psList.Add(New SqlParameter("@BASE_STATUS", BASE_STATUS))
            Else
                psList.Add(New SqlParameter("@BASE_STATUS", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_TYPE) Then
                psList.Add(New SqlParameter("@BASE_TYPE", BASE_TYPE))
            Else
                psList.Add(New SqlParameter("@BASE_TYPE", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_ORGID) Then
                psList.Add(New SqlParameter("@BASE_ORGID", BASE_ORGID))
            Else
                psList.Add(New SqlParameter("@BASE_ORGID", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_NAME) Then
                psList.Add(New SqlParameter("@BASE_NAME", BASE_NAME))
            Else
                psList.Add(New SqlParameter("@BASE_NAME", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_SEX) Then
                psList.Add(New SqlParameter("@BASE_SEX", BASE_SEX))
            Else
                psList.Add(New SqlParameter("@BASE_SEX", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_JOB_DATE) Then
                psList.Add(New SqlParameter("@BASE_JOB_DATE", BASE_JOB_DATE))
            Else
                psList.Add(New SqlParameter("@BASE_JOB_DATE", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_DEP) Then
                psList.Add(New SqlParameter("@BASE_DEP", BASE_DEP))
            Else
                psList.Add(New SqlParameter("@BASE_DEP", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_BDATE) Then
                psList.Add(New SqlParameter("@BASE_BDATE", BASE_BDATE))
            Else
                psList.Add(New SqlParameter("@BASE_BDATE", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_EDATE) Then
                psList.Add(New SqlParameter("@BASE_EDATE", BASE_EDATE))
            Else
                psList.Add(New SqlParameter("@BASE_EDATE", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_JOB) Then
                psList.Add(New SqlParameter("@BASE_JOB", BASE_JOB))
            Else
                psList.Add(New SqlParameter("@BASE_JOB", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_DCODE) Then
                psList.Add(New SqlParameter("@BASE_DCODE", BASE_DCODE))
            Else
                psList.Add(New SqlParameter("@BASE_DCODE", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_ORG_L1) Then
                psList.Add(New SqlParameter("@BASE_ORG_L1", BASE_ORG_L1))
            Else
                psList.Add(New SqlParameter("@BASE_ORG_L1", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_ORG_L2) Then
                psList.Add(New SqlParameter("@BASE_ORG_L2", BASE_ORG_L2))
            Else
                psList.Add(New SqlParameter("@BASE_ORG_L2", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_ORG_L3) Then
                psList.Add(New SqlParameter("@BASE_ORG_L3", BASE_ORG_L3))
            Else
                psList.Add(New SqlParameter("@BASE_ORG_L3", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_AGEN) Then
                psList.Add(New SqlParameter("@BASE_AGEN", BASE_AGEN))
            Else
                psList.Add(New SqlParameter("@BASE_AGEN", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_IN_L1) Then
                psList.Add(New SqlParameter("@BASE_IN_L1", BASE_IN_L1))
            Else
                psList.Add(New SqlParameter("@BASE_IN_L1", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_IN_L3) Then
                psList.Add(New SqlParameter("@BASE_IN_L3", BASE_IN_L3))
            Else
                psList.Add(New SqlParameter("@BASE_IN_L3", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_PTB) Then
                psList.Add(New SqlParameter("@BASE_PTB", BASE_PTB))
            Else
                psList.Add(New SqlParameter("@BASE_PTB", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_PROV) Then
                psList.Add(New SqlParameter("@BASE_PROV", BASE_PROV))
            Else
                psList.Add(New SqlParameter("@BASE_PROV", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_ADDR) Then
                psList.Add(New SqlParameter("@BASE_ADDR", BASE_ADDR))
            Else
                psList.Add(New SqlParameter("@BASE_ADDR", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_QUIT_DATE) Then
                psList.Add(New SqlParameter("@BASE_QUIT_DATE", BASE_QUIT_DATE))
            Else
                psList.Add(New SqlParameter("@BASE_QUIT_DATE", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_QUIT_REZN) Then
                psList.Add(New SqlParameter("@BASE_QUIT_REZN", BASE_QUIT_REZN))
            Else
                psList.Add(New SqlParameter("@BASE_QUIT_REZN", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_ERMK) Then
                psList.Add(New SqlParameter("@BASE_ERMK", BASE_ERMK))
            Else
                psList.Add(New SqlParameter("@BASE_ERMK", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_PRONO) Then
                psList.Add(New SqlParameter("@BASE_PRONO", BASE_PRONO))
            Else
                psList.Add(New SqlParameter("@BASE_PRONO", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_KDB) Then
                psList.Add(New SqlParameter("@BASE_KDB", BASE_KDB))
            Else
                psList.Add(New SqlParameter("@BASE_KDB", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_KDC) Then
                psList.Add(New SqlParameter("@BASE_KDC", BASE_KDC))
            Else
                psList.Add(New SqlParameter("@BASE_KDC", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_KDP) Then
                psList.Add(New SqlParameter("@BASE_KDP", BASE_KDP))
            Else
                psList.Add(New SqlParameter("@BASE_KDP", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_KDO) Then
                psList.Add(New SqlParameter("@BASE_KDO", BASE_KDO))
            Else
                psList.Add(New SqlParameter("@BASE_KDO", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_POL) Then
                psList.Add(New SqlParameter("@BASE_POL", BASE_POL))
            Else
                psList.Add(New SqlParameter("@BASE_POL", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_HOUS) Then
                psList.Add(New SqlParameter("@BASE_HOUS", BASE_HOUS))
            Else
                psList.Add(New SqlParameter("@BASE_HOUS", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_WELG) Then
                psList.Add(New SqlParameter("@BASE_WELG", BASE_WELG))
            Else
                psList.Add(New SqlParameter("@BASE_WELG", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_WELO) Then
                psList.Add(New SqlParameter("@BASE_WELO", BASE_WELO))
            Else
                psList.Add(New SqlParameter("@BASE_WELO", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_PRE) Then
                psList.Add(New SqlParameter("@BASE_PRE", BASE_PRE))
            Else
                psList.Add(New SqlParameter("@BASE_PRE", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_OTHER_SAL) Then
                psList.Add(New SqlParameter("@BASE_OTHER_SAL", BASE_OTHER_SAL))
            Else
                psList.Add(New SqlParameter("@BASE_OTHER_SAL", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_PRED) Then
                psList.Add(New SqlParameter("@BASE_PRED", BASE_PRED))
            Else
                psList.Add(New SqlParameter("@BASE_PRED", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_PRIZ) Then
                psList.Add(New SqlParameter("@BASE_PRIZ", BASE_PRIZ))
            Else
                psList.Add(New SqlParameter("@BASE_PRIZ", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_TAX) Then
                psList.Add(New SqlParameter("@BASE_TAX", BASE_TAX))
            Else
                psList.Add(New SqlParameter("@BASE_TAX", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_FINS_KIND) Then
                psList.Add(New SqlParameter("@BASE_FINS_KIND", BASE_FINS_KIND))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_KIND", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_PN_Y30) Then
                psList.Add(New SqlParameter("@BASE_PN_Y30", BASE_PN_Y30))
            Else
                psList.Add(New SqlParameter("@BASE_PN_Y30", DBNull.Value))
            End If
            If Not BASE_FINS_NOQ = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FINS_NOQ", BASE_FINS_NOQ))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_NOQ", DBNull.Value))
            End If
            If Not BASE_FINS_NOH = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FINS_NOH", BASE_FINS_NOH))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_NOH", DBNull.Value))
            End If
            If Not BASE_FINS_NOF = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FINS_NOF", BASE_FINS_NOF))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_NOF", DBNull.Value))
            End If
            If Not BASE_FINS_NOL = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FINS_NOL", BASE_FINS_NOL))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_NOL", DBNull.Value))
            End If
            If Not BASE_FINS_SELF = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FINS_SELF", BASE_FINS_SELF))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_SELF", DBNull.Value))
            End If
            If Not BASE_FINS_NO = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FINS_NO", BASE_FINS_NO))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_NO", DBNull.Value))
            End If
            If Not BASE_DAY_SAL = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_DAY_SAL", BASE_DAY_SAL))
            Else
                psList.Add(New SqlParameter("@BASE_DAY_SAL", DBNull.Value))
            End If
            If Not BASE_HOUR_SAL = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_HOUR_SAL", BASE_HOUR_SAL))
            Else
                psList.Add(New SqlParameter("@BASE_HOUR_SAL", DBNull.Value))
            End If
            If Not BASE_DCT_A = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_DCT_A", BASE_DCT_A))
            Else
                psList.Add(New SqlParameter("@BASE_DCT_A", DBNull.Value))
            End If
            If Not BASE_DCT_B = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_DCT_B", BASE_DCT_B))
            Else
                psList.Add(New SqlParameter("@BASE_DCT_B", DBNull.Value))
            End If
            If Not BASE_DCT_C = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_DCT_C", BASE_DCT_C))
            Else
                psList.Add(New SqlParameter("@BASE_DCT_C", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_COUNT_REMARK) Then
                psList.Add(New SqlParameter("@BASE_COUNT_REMARK", BASE_COUNT_REMARK))
            Else
                psList.Add(New SqlParameter("@BASE_COUNT_REMARK", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_MEMO) Then
                psList.Add(New SqlParameter("@BASE_MEMO", BASE_MEMO))
            Else
                psList.Add(New SqlParameter("@BASE_MEMO", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_MUSER) Then
                psList.Add(New SqlParameter("@BASE_MUSER", BASE_MUSER))
            Else
                psList.Add(New SqlParameter("@BASE_MUSER", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_MDATE) Then
                psList.Add(New SqlParameter("@BASE_MDATE", BASE_MDATE))
            Else
                psList.Add(New SqlParameter("@BASE_MDATE", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_KDC_SERIES) Then
                psList.Add(New SqlParameter("@BASE_KDC_SERIES", BASE_KDC_SERIES))
            Else
                psList.Add(New SqlParameter("@BASE_KDC_SERIES", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_KDP_SERIES) Then
                psList.Add(New SqlParameter("@BASE_KDP_SERIES", BASE_KDP_SERIES))
            Else
                psList.Add(New SqlParameter("@BASE_KDP_SERIES", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_LABOR_SERIES) Then
                psList.Add(New SqlParameter("@BASE_LABOR_SERIES", BASE_LABOR_SERIES))
            Else
                psList.Add(New SqlParameter("@BASE_LABOR_SERIES", DBNull.Value))
            End If
            If Not BASE_PRTS = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_PRTS", BASE_PRTS))
            Else
                psList.Add(New SqlParameter("@BASE_PRTS", DBNull.Value))
            End If
            If Not BASE_FIN_AMT = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FIN_AMT", BASE_FIN_AMT))
            Else
                psList.Add(New SqlParameter("@BASE_FIN_AMT", DBNull.Value))
            End If
            If Not BASE_TAX_DCT = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_TAX_DCT", BASE_TAX_DCT))
            Else
                psList.Add(New SqlParameter("@BASE_TAX_DCT", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_LABOR_STATUS) Then
                psList.Add(New SqlParameter("@BASE_LABOR_STATUS", BASE_LABOR_STATUS))
            Else
                psList.Add(New SqlParameter("@BASE_LABOR_STATUS", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_SENTMAIL) Then
                psList.Add(New SqlParameter("@BASE_SENTMAIL", BASE_SENTMAIL))
            Else
                psList.Add(New SqlParameter("@BASE_SENTMAIL", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_EMAIL) Then
                psList.Add(New SqlParameter("@BASE_EMAIL", BASE_EMAIL))
            Else
                psList.Add(New SqlParameter("@BASE_EMAIL", DBNull.Value))
            End If
            If Not BASE_FIN_SUP_AMT = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FIN_SUP_AMT", BASE_FIN_SUP_AMT))
            Else
                psList.Add(New SqlParameter("@BASE_FIN_SUP_AMT", DBNull.Value))
            End If
            If Not BASE_REPLACE_AMT = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_REPLACE_AMT", BASE_REPLACE_AMT))
            Else
                psList.Add(New SqlParameter("@BASE_REPLACE_AMT", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_GOVADOF) Then
                psList.Add(New SqlParameter("@BASE_GOVADOF", BASE_GOVADOF))
            Else
                psList.Add(New SqlParameter("@BASE_GOVADOF", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_LAB_JIF) Then
                psList.Add(New SqlParameter("@BASE_LAB_JIF", BASE_LAB_JIF))
            Else
                psList.Add(New SqlParameter("@BASE_LAB_JIF", DBNull.Value))
            End If
            If Not base_fins_noq_nol = Double.MinValue Then
                psList.Add(New SqlParameter("@base_fins_noq_nol", base_fins_noq_nol))
            Else
                psList.Add(New SqlParameter("@base_fins_noq_nol", DBNull.Value))
            End If
            If Not base_fins_noh_nol = Double.MinValue Then
                psList.Add(New SqlParameter("@base_fins_noh_nol", base_fins_noh_nol))
            Else
                psList.Add(New SqlParameter("@base_fins_noh_nol", DBNull.Value))
            End If
            If Not BASE_FINS_Y65 = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FINS_Y65", BASE_FINS_Y65))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_Y65", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_FINS_SERIES) Then
                psList.Add(New SqlParameter("@BASE_FINS_SERIES", BASE_FINS_SERIES))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_SERIES", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Base_IsMarked) Then
                psList.Add(New SqlParameter("@Base_IsMarked", Base_IsMarked))
            Else
                psList.Add(New SqlParameter("@Base_IsMarked", DBNull.Value))
            End If
            If Not BASE_PEN_RATE = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_PEN_RATE", BASE_PEN_RATE))
            Else
                psList.Add(New SqlParameter("@BASE_PEN_RATE", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_PEN_TYPE) Then
                psList.Add(New SqlParameter("@BASE_PEN_TYPE", BASE_PEN_TYPE))
            Else
                psList.Add(New SqlParameter("@BASE_PEN_TYPE", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_PROF) Then
                psList.Add(New SqlParameter("@BASE_PROF", BASE_PROF))
            Else
                psList.Add(New SqlParameter("@BASE_PROF", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_PEN_SERIES) Then
                psList.Add(New SqlParameter("@BASE_PEN_SERIES", BASE_PEN_SERIES))
            Else
                psList.Add(New SqlParameter("@BASE_PEN_SERIES", DBNull.Value))
            End If
            If Not BASE_NUMERATOR = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_NUMERATOR", BASE_NUMERATOR))
            Else
                psList.Add(New SqlParameter("@BASE_NUMERATOR", DBNull.Value))
            End If
            If Not BASE_DENOMINATOR = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_DENOMINATOR", BASE_DENOMINATOR))
            Else
                psList.Add(New SqlParameter("@BASE_DENOMINATOR", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_PTB_TYPE) Then
                psList.Add(New SqlParameter("@BASE_PTB_TYPE", BASE_PTB_TYPE))
            Else
                psList.Add(New SqlParameter("@BASE_PTB_TYPE", DBNull.Value))
            End If
            If Not BASE_ALT_AMT = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_ALT_AMT", BASE_ALT_AMT))
            Else
                psList.Add(New SqlParameter("@BASE_ALT_AMT", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_MEMO1) Then
                psList.Add(New SqlParameter("@BASE_MEMO1", BASE_MEMO1))
            Else
                psList.Add(New SqlParameter("@BASE_MEMO1", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_MEMO2) Then
                psList.Add(New SqlParameter("@BASE_MEMO2", BASE_MEMO2))
            Else
                psList.Add(New SqlParameter("@BASE_MEMO2", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_MEMO3) Then
                psList.Add(New SqlParameter("@BASE_MEMO3", BASE_MEMO3))
            Else
                psList.Add(New SqlParameter("@BASE_MEMO3", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_DCODE_NAME) Then
                psList.Add(New SqlParameter("@BASE_DCODE_NAME", BASE_DCODE_NAME))
            Else
                psList.Add(New SqlParameter("@BASE_DCODE_NAME", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_SENTMSG) Then
                psList.Add(New SqlParameter("@BASE_SENTMSG", BASE_SENTMSG))
            Else
                psList.Add(New SqlParameter("@BASE_SENTMSG", DBNull.Value))
            End If
            If Not BASE_FINS_HEALTH_SELF = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FINS_HEALTH_SELF", BASE_FINS_HEALTH_SELF))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_HEALTH_SELF", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_PROJ_BDATE) Then
                psList.Add(New SqlParameter("@BASE_PROJ_BDATE", BASE_PROJ_BDATE))
            Else
                psList.Add(New SqlParameter("@BASE_PROJ_BDATE", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_PROJ_EDATE) Then
                psList.Add(New SqlParameter("@BASE_PROJ_EDATE", BASE_PROJ_EDATE))
            Else
                psList.Add(New SqlParameter("@BASE_PROJ_EDATE", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_LAB1) Then
                psList.Add(New SqlParameter("@BASE_LAB1", BASE_LAB1))
            Else
                psList.Add(New SqlParameter("@BASE_LAB1", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_LAB2) Then
                psList.Add(New SqlParameter("@BASE_LAB2", BASE_LAB2))
            Else
                psList.Add(New SqlParameter("@BASE_LAB2", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_LAB3) Then
                psList.Add(New SqlParameter("@BASE_LAB3", BASE_LAB3))
            Else
                psList.Add(New SqlParameter("@BASE_LAB3", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_PARTTIME) Then
                psList.Add(New SqlParameter("@BASE_PARTTIME", BASE_PARTTIME))
            Else
                psList.Add(New SqlParameter("@BASE_PARTTIME", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_FINS_SELF_DESC) Then
                psList.Add(New SqlParameter("@BASE_FINS_SELF_DESC", BASE_FINS_SELF_DESC))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_SELF_DESC", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_FINS_PAR_DESC) Then
                psList.Add(New SqlParameter("@BASE_FINS_PAR_DESC", BASE_FINS_PAR_DESC))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_PAR_DESC", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(BASE_SERVICE_PLACE_DESC) Then
                psList.Add(New SqlParameter("@BASE_SERVICE_PLACE_DESC", BASE_SERVICE_PLACE_DESC))
            Else
                psList.Add(New SqlParameter("@BASE_SERVICE_PLACE_DESC", DBNull.Value))
            End If


            DAO.Insert(psList.ToArray())
        End Sub

        Public Sub Modify(BASE_SEQNO As String, BASE_IDNO As String, BASE_STATUS As String, BASE_TYPE As String, BASE_ORGID As String, _
BASE_NAME As String, BASE_SEX As String, BASE_JOB_DATE As String, BASE_DEP As String, BASE_BDATE As String, _
BASE_EDATE As String, BASE_JOB As String, BASE_DCODE As String, BASE_ORG_L1 As String, BASE_ORG_L2 As String, _
BASE_ORG_L3 As String, BASE_AGEN As String, BASE_IN_L1 As String, BASE_IN_L3 As String, BASE_PTB As String, _
BASE_PROV As String, BASE_ADDR As String, BASE_QUIT_DATE As String, BASE_QUIT_REZN As String, BASE_ERMK As String, _
BASE_PRONO As String, BASE_KDB As String, BASE_KDC As String, BASE_KDP As String, BASE_KDO As String, _
BASE_POL As String, BASE_HOUS As String, BASE_WELG As String, BASE_WELO As String, BASE_PRE As String, _
BASE_OTHER_SAL As String, BASE_PRED As String, BASE_PRIZ As String, BASE_TAX As String, BASE_FINS_KIND As String, _
BASE_PN_Y30 As String, BASE_FINS_NOQ As Double, BASE_FINS_NOH As Double, BASE_FINS_NOF As Double, BASE_FINS_NOL As Double, _
BASE_FINS_SELF As Double, BASE_FINS_NO As Double, BASE_DAY_SAL As Double, BASE_HOUR_SAL As Double, BASE_DCT_A As Double, _
BASE_DCT_B As Double, BASE_DCT_C As Double, BASE_COUNT_REMARK As String, BASE_MEMO As String, BASE_MUSER As String, _
BASE_MDATE As String, BASE_KDC_SERIES As String, BASE_KDP_SERIES As String, BASE_LABOR_SERIES As String, BASE_PRTS As Double, _
BASE_FIN_AMT As Double, BASE_TAX_DCT As Double, BASE_LABOR_STATUS As String, BASE_SENTMAIL As String, BASE_EMAIL As String, _
BASE_FIN_SUP_AMT As Double, BASE_REPLACE_AMT As Double, BASE_GOVADOF As String, BASE_LAB_JIF As String, base_fins_noq_nol As Double, _
base_fins_noh_nol As Double, BASE_FINS_Y65 As Double, BASE_FINS_SERIES As String, Base_IsMarked As String, BASE_PEN_RATE As Double, _
BASE_PEN_TYPE As String, BASE_PROF As String, BASE_PEN_SERIES As String, BASE_NUMERATOR As Double, BASE_DENOMINATOR As Double, _
BASE_PTB_TYPE As String, BASE_ALT_AMT As Double, BASE_MEMO1 As String, BASE_MEMO2 As String, BASE_MEMO3 As String, _
BASE_DCODE_NAME As String, BASE_SENTMSG As String, BASE_FINS_HEALTH_SELF As Double, BASE_PROJ_BDATE As String, BASE_PROJ_EDATE As String, _
BASE_LAB1 As String, BASE_LAB2 As String, BASE_LAB3 As String, BASE_PARTTIME As String, BASE_FINS_SELF_DESC As String, BASE_FINS_PAR_DESC As String, BASE_SERVICE_PLACE_DESC As String)


            Dim dr As DataRow = GetOne(BASE_SEQNO)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@BASE_SEQNO", BASE_SEQNO))

            If Not String.IsNullOrEmpty(BASE_IDNO) Then
                psList.Add(New SqlParameter("@BASE_IDNO", BASE_IDNO))
            Else
                psList.Add(New SqlParameter("@BASE_IDNO", dr("BASE_IDNO")))
            End If
            If Not String.IsNullOrEmpty(BASE_STATUS) Then
                psList.Add(New SqlParameter("@BASE_STATUS", BASE_STATUS))
            Else
                psList.Add(New SqlParameter("@BASE_STATUS", dr("BASE_STATUS")))
            End If
            If Not String.IsNullOrEmpty(BASE_TYPE) Then
                psList.Add(New SqlParameter("@BASE_TYPE", BASE_TYPE))
            Else
                psList.Add(New SqlParameter("@BASE_TYPE", dr("BASE_TYPE")))
            End If
            If Not String.IsNullOrEmpty(BASE_ORGID) Then
                psList.Add(New SqlParameter("@BASE_ORGID", BASE_ORGID))
            Else
                psList.Add(New SqlParameter("@BASE_ORGID", dr("BASE_ORGID")))
            End If
            If Not String.IsNullOrEmpty(BASE_NAME) Then
                psList.Add(New SqlParameter("@BASE_NAME", BASE_NAME))
            Else
                psList.Add(New SqlParameter("@BASE_NAME", dr("BASE_NAME")))
            End If
            If Not String.IsNullOrEmpty(BASE_SEX) Then
                psList.Add(New SqlParameter("@BASE_SEX", BASE_SEX))
            Else
                psList.Add(New SqlParameter("@BASE_SEX", dr("BASE_SEX")))
            End If
            If Not String.IsNullOrEmpty(BASE_JOB_DATE) Then
                psList.Add(New SqlParameter("@BASE_JOB_DATE", BASE_JOB_DATE))
            Else
                psList.Add(New SqlParameter("@BASE_JOB_DATE", dr("BASE_JOB_DATE")))
            End If
            If Not String.IsNullOrEmpty(BASE_DEP) Then
                psList.Add(New SqlParameter("@BASE_DEP", BASE_DEP))
            Else
                psList.Add(New SqlParameter("@BASE_DEP", dr("BASE_DEP")))
            End If
            If Not String.IsNullOrEmpty(BASE_BDATE) Then
                psList.Add(New SqlParameter("@BASE_BDATE", BASE_BDATE))
            Else
                psList.Add(New SqlParameter("@BASE_BDATE", dr("BASE_BDATE")))
            End If
            If Not String.IsNullOrEmpty(BASE_EDATE) Then
                psList.Add(New SqlParameter("@BASE_EDATE", BASE_EDATE))
            Else
                psList.Add(New SqlParameter("@BASE_EDATE", dr("BASE_EDATE")))
            End If
            If Not String.IsNullOrEmpty(BASE_JOB) Then
                psList.Add(New SqlParameter("@BASE_JOB", BASE_JOB))
            Else
                psList.Add(New SqlParameter("@BASE_JOB", dr("BASE_JOB")))
            End If
            If Not String.IsNullOrEmpty(BASE_DCODE) Then
                psList.Add(New SqlParameter("@BASE_DCODE", BASE_DCODE))
            Else
                psList.Add(New SqlParameter("@BASE_DCODE", dr("BASE_DCODE")))
            End If
            If Not String.IsNullOrEmpty(BASE_ORG_L1) Then
                psList.Add(New SqlParameter("@BASE_ORG_L1", BASE_ORG_L1))
            Else
                psList.Add(New SqlParameter("@BASE_ORG_L1", dr("BASE_ORG_L1")))
            End If
            If Not String.IsNullOrEmpty(BASE_ORG_L2) Then
                psList.Add(New SqlParameter("@BASE_ORG_L2", BASE_ORG_L2))
            Else
                psList.Add(New SqlParameter("@BASE_ORG_L2", dr("BASE_ORG_L2")))
            End If
            If Not String.IsNullOrEmpty(BASE_ORG_L3) Then
                psList.Add(New SqlParameter("@BASE_ORG_L3", BASE_ORG_L3))
            Else
                psList.Add(New SqlParameter("@BASE_ORG_L3", dr("BASE_ORG_L3")))
            End If
            If Not String.IsNullOrEmpty(BASE_AGEN) Then
                psList.Add(New SqlParameter("@BASE_AGEN", BASE_AGEN))
            Else
                psList.Add(New SqlParameter("@BASE_AGEN", dr("BASE_AGEN")))
            End If
            If Not String.IsNullOrEmpty(BASE_IN_L1) Then
                psList.Add(New SqlParameter("@BASE_IN_L1", BASE_IN_L1))
            Else
                psList.Add(New SqlParameter("@BASE_IN_L1", dr("BASE_IN_L1")))
            End If
            If Not String.IsNullOrEmpty(BASE_IN_L3) Then
                psList.Add(New SqlParameter("@BASE_IN_L3", BASE_IN_L3))
            Else
                psList.Add(New SqlParameter("@BASE_IN_L3", dr("BASE_IN_L3")))
            End If
            If Not String.IsNullOrEmpty(BASE_PTB) Then
                psList.Add(New SqlParameter("@BASE_PTB", BASE_PTB))
            Else
                psList.Add(New SqlParameter("@BASE_PTB", dr("BASE_PTB")))
            End If
            If Not String.IsNullOrEmpty(BASE_PROV) Then
                psList.Add(New SqlParameter("@BASE_PROV", BASE_PROV))
            Else
                psList.Add(New SqlParameter("@BASE_PROV", dr("BASE_PROV")))
            End If
            If Not String.IsNullOrEmpty(BASE_ADDR) Then
                psList.Add(New SqlParameter("@BASE_ADDR", BASE_ADDR))
            Else
                psList.Add(New SqlParameter("@BASE_ADDR", dr("BASE_ADDR")))
            End If
            If Not String.IsNullOrEmpty(BASE_QUIT_DATE) Then
                psList.Add(New SqlParameter("@BASE_QUIT_DATE", BASE_QUIT_DATE))
            Else
                psList.Add(New SqlParameter("@BASE_QUIT_DATE", dr("BASE_QUIT_DATE")))
            End If
            If Not String.IsNullOrEmpty(BASE_QUIT_REZN) Then
                psList.Add(New SqlParameter("@BASE_QUIT_REZN", BASE_QUIT_REZN))
            Else
                psList.Add(New SqlParameter("@BASE_QUIT_REZN", dr("BASE_QUIT_REZN")))
            End If
            If Not String.IsNullOrEmpty(BASE_ERMK) Then
                psList.Add(New SqlParameter("@BASE_ERMK", BASE_ERMK))
            Else
                psList.Add(New SqlParameter("@BASE_ERMK", dr("BASE_ERMK")))
            End If
            If Not String.IsNullOrEmpty(BASE_PRONO) Then
                psList.Add(New SqlParameter("@BASE_PRONO", BASE_PRONO))
            Else
                psList.Add(New SqlParameter("@BASE_PRONO", dr("BASE_PRONO")))
            End If
            If Not String.IsNullOrEmpty(BASE_KDB) Then
                psList.Add(New SqlParameter("@BASE_KDB", BASE_KDB))
            Else
                psList.Add(New SqlParameter("@BASE_KDB", dr("BASE_KDB")))
            End If
            If Not String.IsNullOrEmpty(BASE_KDC) Then
                psList.Add(New SqlParameter("@BASE_KDC", BASE_KDC))
            Else
                psList.Add(New SqlParameter("@BASE_KDC", dr("BASE_KDC")))
            End If
            If Not String.IsNullOrEmpty(BASE_KDP) Then
                psList.Add(New SqlParameter("@BASE_KDP", BASE_KDP))
            Else
                psList.Add(New SqlParameter("@BASE_KDP", dr("BASE_KDP")))
            End If
            If Not String.IsNullOrEmpty(BASE_KDO) Then
                psList.Add(New SqlParameter("@BASE_KDO", BASE_KDO))
            Else
                psList.Add(New SqlParameter("@BASE_KDO", dr("BASE_KDO")))
            End If
            If Not String.IsNullOrEmpty(BASE_POL) Then
                psList.Add(New SqlParameter("@BASE_POL", BASE_POL))
            Else
                psList.Add(New SqlParameter("@BASE_POL", dr("BASE_POL")))
            End If
            If Not String.IsNullOrEmpty(BASE_HOUS) Then
                psList.Add(New SqlParameter("@BASE_HOUS", BASE_HOUS))
            Else
                psList.Add(New SqlParameter("@BASE_HOUS", dr("BASE_HOUS")))
            End If
            If Not String.IsNullOrEmpty(BASE_WELG) Then
                psList.Add(New SqlParameter("@BASE_WELG", BASE_WELG))
            Else
                psList.Add(New SqlParameter("@BASE_WELG", dr("BASE_WELG")))
            End If
            If Not String.IsNullOrEmpty(BASE_WELO) Then
                psList.Add(New SqlParameter("@BASE_WELO", BASE_WELO))
            Else
                psList.Add(New SqlParameter("@BASE_WELO", dr("BASE_WELO")))
            End If
            If Not String.IsNullOrEmpty(BASE_PRE) Then
                psList.Add(New SqlParameter("@BASE_PRE", BASE_PRE))
            Else
                psList.Add(New SqlParameter("@BASE_PRE", dr("BASE_PRE")))
            End If
            If Not String.IsNullOrEmpty(BASE_OTHER_SAL) Then
                psList.Add(New SqlParameter("@BASE_OTHER_SAL", BASE_OTHER_SAL))
            Else
                psList.Add(New SqlParameter("@BASE_OTHER_SAL", dr("BASE_OTHER_SAL")))
            End If
            If Not String.IsNullOrEmpty(BASE_PRED) Then
                psList.Add(New SqlParameter("@BASE_PRED", BASE_PRED))
            Else
                psList.Add(New SqlParameter("@BASE_PRED", dr("BASE_PRED")))
            End If
            If Not String.IsNullOrEmpty(BASE_PRIZ) Then
                psList.Add(New SqlParameter("@BASE_PRIZ", BASE_PRIZ))
            Else
                psList.Add(New SqlParameter("@BASE_PRIZ", dr("BASE_PRIZ")))
            End If
            If Not String.IsNullOrEmpty(BASE_TAX) Then
                psList.Add(New SqlParameter("@BASE_TAX", BASE_TAX))
            Else
                psList.Add(New SqlParameter("@BASE_TAX", dr("BASE_TAX")))
            End If
            If Not String.IsNullOrEmpty(BASE_FINS_KIND) Then
                psList.Add(New SqlParameter("@BASE_FINS_KIND", BASE_FINS_KIND))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_KIND", dr("BASE_FINS_KIND")))
            End If
            If Not String.IsNullOrEmpty(BASE_PN_Y30) Then
                psList.Add(New SqlParameter("@BASE_PN_Y30", BASE_PN_Y30))
            Else
                psList.Add(New SqlParameter("@BASE_PN_Y30", dr("BASE_PN_Y30")))
            End If
            If Not BASE_FINS_NOQ = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FINS_NOQ", BASE_FINS_NOQ))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_NOQ", dr("BASE_FINS_NOQ")))
            End If
            If Not BASE_FINS_NOH = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FINS_NOH", BASE_FINS_NOH))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_NOH", dr("BASE_FINS_NOH")))
            End If
            If Not BASE_FINS_NOF = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FINS_NOF", BASE_FINS_NOF))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_NOF", dr("BASE_FINS_NOF")))
            End If
            If Not BASE_FINS_NOL = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FINS_NOL", BASE_FINS_NOL))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_NOL", dr("BASE_FINS_NOL")))
            End If
            If Not BASE_FINS_SELF = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FINS_SELF", BASE_FINS_SELF))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_SELF", dr("BASE_FINS_SELF")))
            End If
            If Not BASE_FINS_NO = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FINS_NO", BASE_FINS_NO))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_NO", dr("BASE_FINS_NO")))
            End If
            If Not BASE_DAY_SAL = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_DAY_SAL", BASE_DAY_SAL))
            Else
                psList.Add(New SqlParameter("@BASE_DAY_SAL", dr("BASE_DAY_SAL")))
            End If
            If Not BASE_HOUR_SAL = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_HOUR_SAL", BASE_HOUR_SAL))
            Else
                psList.Add(New SqlParameter("@BASE_HOUR_SAL", dr("BASE_HOUR_SAL")))
            End If
            If Not BASE_DCT_A = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_DCT_A", BASE_DCT_A))
            Else
                psList.Add(New SqlParameter("@BASE_DCT_A", dr("BASE_DCT_A")))
            End If
            If Not BASE_DCT_B = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_DCT_B", BASE_DCT_B))
            Else
                psList.Add(New SqlParameter("@BASE_DCT_B", dr("BASE_DCT_B")))
            End If
            If Not BASE_DCT_C = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_DCT_C", BASE_DCT_C))
            Else
                psList.Add(New SqlParameter("@BASE_DCT_C", dr("BASE_DCT_C")))
            End If
            If Not String.IsNullOrEmpty(BASE_COUNT_REMARK) Then
                psList.Add(New SqlParameter("@BASE_COUNT_REMARK", BASE_COUNT_REMARK))
            Else
                psList.Add(New SqlParameter("@BASE_COUNT_REMARK", dr("BASE_COUNT_REMARK")))
            End If
            If Not String.IsNullOrEmpty(BASE_MEMO) Then
                psList.Add(New SqlParameter("@BASE_MEMO", BASE_MEMO))
            Else
                psList.Add(New SqlParameter("@BASE_MEMO", dr("BASE_MEMO")))
            End If
            If Not String.IsNullOrEmpty(BASE_MUSER) Then
                psList.Add(New SqlParameter("@BASE_MUSER", BASE_MUSER))
            Else
                psList.Add(New SqlParameter("@BASE_MUSER", dr("BASE_MUSER")))
            End If
            If Not String.IsNullOrEmpty(BASE_MDATE) Then
                psList.Add(New SqlParameter("@BASE_MDATE", BASE_MDATE))
            Else
                psList.Add(New SqlParameter("@BASE_MDATE", dr("BASE_MDATE")))
            End If
            If Not String.IsNullOrEmpty(BASE_KDC_SERIES) Then
                psList.Add(New SqlParameter("@BASE_KDC_SERIES", BASE_KDC_SERIES))
            Else
                psList.Add(New SqlParameter("@BASE_KDC_SERIES", dr("BASE_KDC_SERIES")))
            End If
            If Not String.IsNullOrEmpty(BASE_KDP_SERIES) Then
                psList.Add(New SqlParameter("@BASE_KDP_SERIES", BASE_KDP_SERIES))
            Else
                psList.Add(New SqlParameter("@BASE_KDP_SERIES", dr("BASE_KDP_SERIES")))
            End If
            If Not String.IsNullOrEmpty(BASE_LABOR_SERIES) Then
                psList.Add(New SqlParameter("@BASE_LABOR_SERIES", BASE_LABOR_SERIES))
            Else
                psList.Add(New SqlParameter("@BASE_LABOR_SERIES", dr("BASE_LABOR_SERIES")))
            End If
            If Not BASE_PRTS = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_PRTS", BASE_PRTS))
            Else
                psList.Add(New SqlParameter("@BASE_PRTS", dr("BASE_PRTS")))
            End If
            If Not BASE_FIN_AMT = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FIN_AMT", BASE_FIN_AMT))
            Else
                psList.Add(New SqlParameter("@BASE_FIN_AMT", dr("BASE_FIN_AMT")))
            End If
            If Not BASE_TAX_DCT = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_TAX_DCT", BASE_TAX_DCT))
            Else
                psList.Add(New SqlParameter("@BASE_TAX_DCT", dr("BASE_TAX_DCT")))
            End If
            If Not String.IsNullOrEmpty(BASE_LABOR_STATUS) Then
                psList.Add(New SqlParameter("@BASE_LABOR_STATUS", BASE_LABOR_STATUS))
            Else
                psList.Add(New SqlParameter("@BASE_LABOR_STATUS", dr("BASE_LABOR_STATUS")))
            End If
            If Not String.IsNullOrEmpty(BASE_SENTMAIL) Then
                psList.Add(New SqlParameter("@BASE_SENTMAIL", BASE_SENTMAIL))
            Else
                psList.Add(New SqlParameter("@BASE_SENTMAIL", dr("BASE_SENTMAIL")))
            End If
            If Not String.IsNullOrEmpty(BASE_EMAIL) Then
                psList.Add(New SqlParameter("@BASE_EMAIL", BASE_EMAIL))
            Else
                psList.Add(New SqlParameter("@BASE_EMAIL", dr("BASE_EMAIL")))
            End If
            If Not BASE_FIN_SUP_AMT = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FIN_SUP_AMT", BASE_FIN_SUP_AMT))
            Else
                psList.Add(New SqlParameter("@BASE_FIN_SUP_AMT", dr("BASE_FIN_SUP_AMT")))
            End If
            If Not BASE_REPLACE_AMT = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_REPLACE_AMT", BASE_REPLACE_AMT))
            Else
                psList.Add(New SqlParameter("@BASE_REPLACE_AMT", dr("BASE_REPLACE_AMT")))
            End If
            If Not String.IsNullOrEmpty(BASE_GOVADOF) Then
                psList.Add(New SqlParameter("@BASE_GOVADOF", BASE_GOVADOF))
            Else
                psList.Add(New SqlParameter("@BASE_GOVADOF", dr("BASE_GOVADOF")))
            End If
            If Not String.IsNullOrEmpty(BASE_LAB_JIF) Then
                psList.Add(New SqlParameter("@BASE_LAB_JIF", BASE_LAB_JIF))
            Else
                psList.Add(New SqlParameter("@BASE_LAB_JIF", dr("BASE_LAB_JIF")))
            End If
            If Not base_fins_noq_nol = Double.MinValue Then
                psList.Add(New SqlParameter("@base_fins_noq_nol", base_fins_noq_nol))
            Else
                psList.Add(New SqlParameter("@base_fins_noq_nol", dr("base_fins_noq_nol")))
            End If
            If Not base_fins_noh_nol = Double.MinValue Then
                psList.Add(New SqlParameter("@base_fins_noh_nol", base_fins_noh_nol))
            Else
                psList.Add(New SqlParameter("@base_fins_noh_nol", dr("base_fins_noh_nol")))
            End If
            If Not BASE_FINS_Y65 = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FINS_Y65", BASE_FINS_Y65))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_Y65", dr("BASE_FINS_Y65")))
            End If
            If Not String.IsNullOrEmpty(BASE_FINS_SERIES) Then
                psList.Add(New SqlParameter("@BASE_FINS_SERIES", BASE_FINS_SERIES))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_SERIES", dr("BASE_FINS_SERIES")))
            End If
            If Not String.IsNullOrEmpty(Base_IsMarked) Then
                psList.Add(New SqlParameter("@Base_IsMarked", Base_IsMarked))
            Else
                psList.Add(New SqlParameter("@Base_IsMarked", dr("Base_IsMarked")))
            End If
            If Not BASE_PEN_RATE = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_PEN_RATE", BASE_PEN_RATE))
            Else
                psList.Add(New SqlParameter("@BASE_PEN_RATE", dr("BASE_PEN_RATE")))
            End If
            If Not String.IsNullOrEmpty(BASE_PEN_TYPE) Then
                psList.Add(New SqlParameter("@BASE_PEN_TYPE", BASE_PEN_TYPE))
            Else
                psList.Add(New SqlParameter("@BASE_PEN_TYPE", dr("BASE_PEN_TYPE")))
            End If
            If Not String.IsNullOrEmpty(BASE_PROF) Then
                psList.Add(New SqlParameter("@BASE_PROF", BASE_PROF))
            Else
                psList.Add(New SqlParameter("@BASE_PROF", dr("BASE_PROF")))
            End If
            If Not String.IsNullOrEmpty(BASE_PEN_SERIES) Then
                psList.Add(New SqlParameter("@BASE_PEN_SERIES", BASE_PEN_SERIES))
            Else
                psList.Add(New SqlParameter("@BASE_PEN_SERIES", dr("BASE_PEN_SERIES")))
            End If
            If Not BASE_NUMERATOR = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_NUMERATOR", BASE_NUMERATOR))
            Else
                psList.Add(New SqlParameter("@BASE_NUMERATOR", dr("BASE_NUMERATOR")))
            End If
            If Not BASE_DENOMINATOR = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_DENOMINATOR", BASE_DENOMINATOR))
            Else
                psList.Add(New SqlParameter("@BASE_DENOMINATOR", dr("BASE_DENOMINATOR")))
            End If
            If Not String.IsNullOrEmpty(BASE_PTB_TYPE) Then
                psList.Add(New SqlParameter("@BASE_PTB_TYPE", BASE_PTB_TYPE))
            Else
                psList.Add(New SqlParameter("@BASE_PTB_TYPE", dr("BASE_PTB_TYPE")))
            End If
            If Not BASE_ALT_AMT = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_ALT_AMT", BASE_ALT_AMT))
            Else
                psList.Add(New SqlParameter("@BASE_ALT_AMT", dr("BASE_ALT_AMT")))
            End If
            If Not String.IsNullOrEmpty(BASE_MEMO1) Then
                psList.Add(New SqlParameter("@BASE_MEMO1", BASE_MEMO1))
            Else
                psList.Add(New SqlParameter("@BASE_MEMO1", dr("BASE_MEMO1")))
            End If
            If Not String.IsNullOrEmpty(BASE_MEMO2) Then
                psList.Add(New SqlParameter("@BASE_MEMO2", BASE_MEMO2))
            Else
                psList.Add(New SqlParameter("@BASE_MEMO2", dr("BASE_MEMO2")))
            End If
            If Not String.IsNullOrEmpty(BASE_MEMO3) Then
                psList.Add(New SqlParameter("@BASE_MEMO3", BASE_MEMO3))
            Else
                psList.Add(New SqlParameter("@BASE_MEMO3", dr("BASE_MEMO3")))
            End If
            If Not String.IsNullOrEmpty(BASE_DCODE_NAME) Then
                psList.Add(New SqlParameter("@BASE_DCODE_NAME", BASE_DCODE_NAME))
            Else
                psList.Add(New SqlParameter("@BASE_DCODE_NAME", dr("BASE_DCODE_NAME")))
            End If
            If Not String.IsNullOrEmpty(BASE_SENTMSG) Then
                psList.Add(New SqlParameter("@BASE_SENTMSG", BASE_SENTMSG))
            Else
                psList.Add(New SqlParameter("@BASE_SENTMSG", dr("BASE_SENTMSG")))
            End If
            If Not BASE_FINS_HEALTH_SELF = Double.MinValue Then
                psList.Add(New SqlParameter("@BASE_FINS_HEALTH_SELF", BASE_FINS_HEALTH_SELF))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_HEALTH_SELF", dr("BASE_FINS_HEALTH_SELF")))
            End If
            If Not String.IsNullOrEmpty(BASE_PROJ_BDATE) Then
                psList.Add(New SqlParameter("@BASE_PROJ_BDATE", BASE_PROJ_BDATE))
            Else
                psList.Add(New SqlParameter("@BASE_PROJ_BDATE", dr("BASE_PROJ_BDATE")))
            End If
            If Not String.IsNullOrEmpty(BASE_PROJ_EDATE) Then
                psList.Add(New SqlParameter("@BASE_PROJ_EDATE", BASE_PROJ_EDATE))
            Else
                psList.Add(New SqlParameter("@BASE_PROJ_EDATE", dr("BASE_PROJ_EDATE")))
            End If
            If Not String.IsNullOrEmpty(BASE_LAB1) Then
                psList.Add(New SqlParameter("@BASE_LAB1", BASE_LAB1))
            Else
                psList.Add(New SqlParameter("@BASE_LAB1", dr("BASE_LAB1")))
            End If
            If Not String.IsNullOrEmpty(BASE_LAB2) Then
                psList.Add(New SqlParameter("@BASE_LAB2", BASE_LAB2))
            Else
                psList.Add(New SqlParameter("@BASE_LAB2", dr("BASE_LAB2")))
            End If
            If Not String.IsNullOrEmpty(BASE_LAB3) Then
                psList.Add(New SqlParameter("@BASE_LAB3", BASE_LAB3))
            Else
                psList.Add(New SqlParameter("@BASE_LAB3", dr("BASE_LAB3")))
            End If
            If Not String.IsNullOrEmpty(BASE_PARTTIME) Then
                psList.Add(New SqlParameter("@BASE_PARTTIME", BASE_PARTTIME))
            Else
                psList.Add(New SqlParameter("@BASE_PARTTIME", dr("BASE_PARTTIME")))
            End If
            If Not String.IsNullOrEmpty(BASE_FINS_SELF_DESC) Then
                psList.Add(New SqlParameter("@BASE_FINS_SELF_DESC", BASE_FINS_SELF_DESC))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_SELF_DESC", dr("BASE_FINS_SELF_DESC")))
            End If
            If Not String.IsNullOrEmpty(BASE_FINS_PAR_DESC) Then
                psList.Add(New SqlParameter("@BASE_FINS_PAR_DESC", BASE_FINS_PAR_DESC))
            Else
                psList.Add(New SqlParameter("@BASE_FINS_PAR_DESC", dr("BASE_FINS_PAR_DESC")))
            End If
            If Not String.IsNullOrEmpty(BASE_SERVICE_PLACE_DESC) Then
                psList.Add(New SqlParameter("@BASE_SERVICE_PLACE_DESC", BASE_SERVICE_PLACE_DESC))
            Else
                psList.Add(New SqlParameter("@BASE_SERVICE_PLACE_DESC", dr("BASE_SERVICE_PLACE_DESC")))
            End If


            DAO.Update(psList.ToArray())


        End Sub

        Public Sub Remove()
            DAO.Delete()
        End Sub

    End Class
End Namespace
