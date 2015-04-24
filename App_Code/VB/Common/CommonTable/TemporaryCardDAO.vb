Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports FSCPLM.Logic
Imports System.Text

Public Class TemporaryCardDAO
    Inherits BaseDAO

    Public Sub New()

    End Sub


    Public Function getQueryData(ByVal orgcode As String, ByVal depart_id As String, ByVal sub_depart_id As String, _
                                 ByVal id_card As String, ByVal personnel_id As String, _
                                 ByVal borrow_sdate As String, ByVal borrow_edate As String, ByVal metadb_id As String) As DataTable
        'Dim sql As New StringBuilder()
        'sql.AppendLine(" select a.*, b.user_name, c.detail_code_name as title_name ")
        'sql.AppendLine(" from ")
        'sql.AppendLine(" temporary_card a ")
        'sql.AppendLine(" inner join member b on a.orgcode=b.orgcode and a.id_card=b.id_card ")
        'sql.AppendLine(" left outer join detail_code c on b.title_no=c.detail_code_id and c.master_code_id='1012' ")
        'sql.AppendLine(" where a.orgcode=@orgcode ")
        'sql.AppendLine(" and b.metadb_id=@metadb_id ")

        'If Not String.IsNullOrEmpty(depart_id) Then
        '    sql.AppendLine("and a.depart_id=@depart_id ")
        'End If

        'If Not String.IsNullOrEmpty(sub_depart_id) Then
        '    sql.AppendLine(" and a.sub_depart_id=@sub_depart_id ")
        'End If
        'If Not String.IsNullOrEmpty(id_card) Then
        '    sql.AppendLine(" and a.id_card=@id_card ")
        'End If
        'If Not String.IsNullOrEmpty(personnel_id) Then
        '    sql.AppendLine(" and a.personnel_id=@personnel_id ")
        'End If
        'If Not String.IsNullOrEmpty(borrow_sdate) Then
        '    sql.AppendLine(" and a.borrow_date>=@borrow_sdate ")
        'End If
        'If Not String.IsNullOrEmpty(borrow_edate) Then
        '    sql.AppendLine(" and a.borrow_date<=@borrow_edate ")
        'End If

        'Dim ps() As SqlParameter = { _
        'New SqlParameter("@orgcode", orgcode), _
        'New SqlParameter("@metadb_id", metadb_id), _
        'New SqlParameter("@depart_id", depart_id), _
        'New SqlParameter("@sub_depart_id", sub_depart_id), _
        'New SqlParameter("@id_card", id_card), _
        'New SqlParameter("@personnel_id", personnel_id), _
        'New SqlParameter("@borrow_sdate", borrow_sdate), _
        'New SqlParameter("@borrow_edate", borrow_edate)}

        'Return Query(sql.ToString(), ps)
        Return getQueryData(orgcode, depart_id, sub_depart_id, id_card, personnel_id, borrow_sdate, borrow_edate, False, metadb_id)

    End Function

    Public Function getQueryData(ByVal orgcode As String, ByVal depart_id As String, ByVal sub_depart_id As String, _
                                 ByVal id_card As String, ByVal personnel_id As String, _
                                 ByVal borrow_sdate As String, ByVal borrow_edate As String, ByVal isInUseOnly As Boolean, ByVal metadb_id As String) As DataTable
        Dim sql As New StringBuilder()
        sql.AppendLine(" select a.*, b.user_name, c.detail_code_name as title_name ")
        sql.AppendLine(" from ")
        sql.AppendLine(" temporary_card a ")
        sql.AppendLine(" inner join member b on a.orgcode=b.orgcode and a.id_card=b.id_card ")
        sql.AppendLine(" left outer join detail_code c on b.title_no=c.detail_code_id and c.master_code_id='1012' ")
        sql.AppendLine(" where a.orgcode=@orgcode ")
        sql.AppendLine(" and b.metadb_id=@metadb_id ")
        If (isInUseOnly) Then
            sql.AppendLine(" and (a.return_date is null or a.return_date='') ")
        End If

        If Not String.IsNullOrEmpty(depart_id) Then
            sql.AppendLine("and a.depart_id=@depart_id ")
        End If

        If Not String.IsNullOrEmpty(sub_depart_id) Then
            sql.AppendLine(" and a.sub_depart_id=@sub_depart_id ")
        End If
        If Not String.IsNullOrEmpty(id_card) Then
            sql.AppendLine(" and a.id_card=@id_card ")
        End If
        If Not String.IsNullOrEmpty(personnel_id) Then
            sql.AppendLine(" and a.personnel_id=@personnel_id ")
        End If
        If Not String.IsNullOrEmpty(borrow_sdate) Then
            sql.AppendLine(" and a.borrow_date>=@borrow_sdate ")
        End If
        If Not String.IsNullOrEmpty(borrow_edate) Then
            sql.AppendLine(" and a.borrow_date<=@borrow_edate ")
        End If

        Dim ps() As SqlParameter = { _
        New SqlParameter("@orgcode", orgcode), _
        New SqlParameter("@metadb_id", metadb_id), _
        New SqlParameter("@depart_id", depart_id), _
        New SqlParameter("@sub_depart_id", sub_depart_id), _
        New SqlParameter("@id_card", id_card), _
        New SqlParameter("@personnel_id", personnel_id), _
        New SqlParameter("@borrow_sdate", borrow_sdate), _
        New SqlParameter("@borrow_edate", borrow_edate)}
        Return Query(sql.ToString(), ps)

        'If (isInUseOnly) Then
        '    Dim ps() As SqlParameter = { _
        '    New SqlParameter("@orgcode", orgcode), _
        '    New SqlParameter("@metadb_id", metadb_id), _
        '    New SqlParameter("@depart_id", depart_id), _
        '    New SqlParameter("@sub_depart_id", sub_depart_id), _
        '    New SqlParameter("@id_card", id_card), _
        '    New SqlParameter("@personnel_id", personnel_id), _
        '    New SqlParameter("@borrow_sdate", borrow_sdate), _
        '    New SqlParameter("@borrow_edate", borrow_edate), _
        '    New SqlParameter("@return_date", DateTimeInfo.GetRocDate(Now))}
        '    Return Query(sql.ToString(), ps)
        'Else
        '    Dim ps() As SqlParameter = { _
        '    New SqlParameter("@orgcode", orgcode), _
        '    New SqlParameter("@metadb_id", metadb_id), _
        '    New SqlParameter("@depart_id", depart_id), _
        '    New SqlParameter("@sub_depart_id", sub_depart_id), _
        '    New SqlParameter("@id_card", id_card), _
        '    New SqlParameter("@personnel_id", personnel_id), _
        '    New SqlParameter("@borrow_sdate", borrow_sdate), _
        '    New SqlParameter("@borrow_edate", borrow_edate)}
        '    Return Query(sql.ToString(), ps)
        'End If        
    End Function

End Class
