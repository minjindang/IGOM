Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Imports System.Text

Namespace SYS.Logic
    Public Class CustomForm
        Public DAO As CustomFormDAO
        Public Sub New()
            DAO = New CustomFormDAO
        End Sub

#Region "Fields"
        Private _Orgcode As String
        Private _Depart_id As String
        'Private _CFIDNO As String
        Private _CFNAME As String
        Private _CFCARD As String
        Private _CFVTYPE As String
        Private _CFVDATEB As String
        Private _CFVDATEE As String
        Private _CFVTIMEB As String
        Private _CFVTIMEE As String
        'Private _CFVDAYS As Double
        ' Private _CFHOLIDAY As String
        'Private _CFTDATE As String
        'Private _CFREMARK As String
        Private _CFGUID As String
        Private _Change_userid As String
        'Private _CFREMARK_TYPE As String
#End Region

#Region "Property"
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Public Property Depart_id() As String
            Get
                Return _Depart_id
            End Get
            Set(ByVal value As String)
                _Depart_id = value
            End Set
        End Property
        Public Property CFNAME() As String
            Get
                Return _CFNAME
            End Get
            Set(ByVal value As String)
                _CFNAME = value
            End Set
        End Property
        Public Property CFCARD() As String
            Get
                Return _CFCARD
            End Get
            Set(ByVal value As String)
                _CFCARD = value
            End Set
        End Property
        Public Property CFVTYPE() As String
            Get
                Return _CFVTYPE
            End Get
            Set(ByVal value As String)
                _CFVTYPE = value
            End Set
        End Property
        Public Property CFVDATEB() As String
            Get
                Return _CFVDATEB
            End Get
            Set(ByVal value As String)
                _CFVDATEB = value
            End Set
        End Property
        Public Property CFVDATEE() As String
            Get
                Return _CFVDATEE
            End Get
            Set(ByVal value As String)
                _CFVDATEE = value
            End Set
        End Property
        Public Property CFVTIMEB() As String
            Get
                Return _CFVTIMEB
            End Get
            Set(ByVal value As String)
                _CFVTIMEB = value
            End Set
        End Property
        Public Property CFVTIMEE() As String
            Get
                Return _CFVTIMEE
            End Get
            Set(ByVal value As String)
                _CFVTIMEE = value
            End Set
        End Property
        'Public Property CFVDAYS() As Double
        '    Get
        '        Return _CFVDAYS
        '    End Get
        '    Set(ByVal value As Double)
        '        _CFVDAYS = value
        '    End Set
        'End Property
        'Public Property CFHOLIDAY() As String
        '    Get
        '        Return _CFHOLIDAY
        '    End Get
        '    Set(ByVal value As String)
        '        _CFHOLIDAY = value
        '    End Set
        'End Property
        'Public Property CFTDATE() As String
        '    Get
        '        Return _CFTDATE
        '    End Get
        '    Set(ByVal value As String)
        '        _CFTDATE = value
        '    End Set
        'End Property
        'Public Property CFREMARK() As String
        '    Get
        '        Return _CFREMARK
        '    End Get
        '    Set(ByVal value As String)
        '        _CFREMARK = value
        '    End Set
        'End Property
        Public Property CFGUID() As String
            Get
                Return _CFGUID
            End Get
            Set(ByVal value As String)
                _CFGUID = value
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
        'Public Property CFREMARK_TYPE() As String
        '    Get
        '        Return _CFREMARK_TYPE
        '    End Get
        '    Set(ByVal value As String)
        '        _CFREMARK_TYPE = value
        '    End Set
        'End Property
#End Region

        Public Function Update() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.add("Depart_id", Depart_id)
            d.add("CFNAME", CFNAME)
            d.add("CFCARD", CFCARD)
            d.add("CFVTYPE", CFVTYPE)
            d.add("CFVDATEB", CFVDATEB)
            d.add("CFVDATEE", CFVDATEE)
            d.add("CFVTIMEB", CFVTIMEB)
            d.add("CFVTIMEE", CFVTIMEE)
            d.add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("CFGUID", CFGUID)
            cd.Add("Orgcode", Orgcode)

            Return DAO.UpdateByExample("SYS_Custom_Form", d, cd)
        End Function

        Public Function Insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Depart_id", Depart_id)
            d.Add("CFNAME", CFNAME)
            d.Add("CFCARD", CFCARD)
            d.Add("CFVTYPE", CFVTYPE)
            d.Add("CFVDATEB", CFVDATEB)
            d.Add("CFVDATEE", CFVDATEE)
            d.Add("CFVTIMEB", CFVTIMEB)
            d.Add("CFVTIMEE", CFVTIMEE)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)
            d.Add("CFGUID", CFGUID)
            d.Add("Orgcode", Orgcode)

            Return DAO.InsertByExample("SYS_Custom_Form", d)
        End Function

    End Class
End Namespace
