Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class SettlementAnnual
        Private DAO As SettlementAnnualDAO

#Region "property"
        Private _Orgcode As String
        Private _Depart_id As String
        Private _Id_card As String
        Private _Personnel_id As String
        Private _User_name As String
        Private _Title As String
        Private _Annual_Year As String
        Private _Budget_type As String
        Private _Annual_Days As Double
        Private _Reserve_Days As Double
        Private _Reserve_Days1 As Double
        Private _Reserve_Days2 As Double
        Private _Vacation_Days As Double
        Private _Pay_Days As Double
        Private _Abroad_Days As Double
        Private _Over_Days_Kind As String
        Private _Hour_Pay As Double
        Private _Settle_Date As String
        Private _History_Mark As String
        Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Property Depart_id() As String
            Get
                Return _Depart_id
            End Get
            Set(ByVal value As String)
                _Depart_id = value
            End Set
        End Property
        Property Id_card() As String
            Get
                Return _Id_card
            End Get
            Set(ByVal value As String)
                _Id_card = value
            End Set
        End Property
        Property Personnel_id() As String
            Get
                Return _Personnel_id
            End Get
            Set(ByVal value As String)
                _Personnel_id = value
            End Set
        End Property
        Property User_name() As String
            Get
                Return _User_name
            End Get
            Set(ByVal value As String)
                _User_name = value
            End Set
        End Property
        Property Title() As String
            Get
                Return _Title
            End Get
            Set(ByVal value As String)
                _Title = value
            End Set
        End Property
        Property Annual_Year() As String
            Get
                Return _Annual_Year
            End Get
            Set(ByVal value As String)
                _Annual_Year = value
            End Set
        End Property
        Property Budget_type() As String
            Get
                Return _Budget_type
            End Get
            Set(ByVal value As String)
                _Budget_type = value
            End Set
        End Property
        Property Annual_Days() As Double
            Get
                Return _Annual_Days
            End Get
            Set(ByVal value As Double)
                _Annual_Days = value
            End Set
        End Property
        Property Reserve_Days() As Double
            Get
                Return _Reserve_Days
            End Get
            Set(ByVal value As Double)
                _Reserve_Days = value
            End Set
        End Property
        Property Reserve_Days1() As Double
            Get
                Return _Reserve_Days1
            End Get
            Set(ByVal value As Double)
                _Reserve_Days1 = value
            End Set
        End Property
        Property Reserve_Days2() As Double
            Get
                Return _Reserve_Days2
            End Get
            Set(ByVal value As Double)
                _Reserve_Days2 = value
            End Set
        End Property
        Property Vacation_Days() As Double
            Get
                Return _Vacation_Days
            End Get
            Set(ByVal value As Double)
                _Vacation_Days = value
            End Set
        End Property
        Property Pay_Days() As Double
            Get
                Return _Pay_Days
            End Get
            Set(ByVal value As Double)
                _Pay_Days = value
            End Set
        End Property
        Property Abroad_Days() As Double
            Get
                Return _Abroad_Days
            End Get
            Set(ByVal value As Double)
                _Abroad_Days = value
            End Set
        End Property
        Property Over_Days_Kind() As String
            Get
                Return _Over_Days_Kind
            End Get
            Set(ByVal value As String)
                _Over_Days_Kind = value
            End Set
        End Property
        Property Hour_Pay() As Double
            Get
                Return _Hour_Pay
            End Get
            Set(ByVal value As Double)
                _Hour_Pay = value
            End Set
        End Property
        Property Settle_Date() As String
            Get
                Return _Settle_Date
            End Get
            Set(ByVal value As String)
                _Settle_Date = value
            End Set
        End Property
        Property History_Mark() As String
            Get
                Return _History_Mark
            End Get
            Set(ByVal value As String)
                _History_Mark = value
            End Set
        End Property
#End Region

        Public Sub New()
            DAO = New SettlementAnnualDAO()
        End Sub


        Public Function GetYearData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Annual_Year As String) As DataTable
            Return DAO.GetYearData(Orgcode, Depart_id, Id_card, Annual_Year)
        End Function

        Public Function updateTransFlag(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Annual_Year As String, ByVal Id_card As String, ByVal Trans_falg As String) As Boolean

            Dim d As New Dictionary(Of String, Object)
            d.Add("Trans_flag", Trans_falg)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Orgcode", Orgcode)
            If Not String.IsNullOrEmpty(Depart_id) Then
                cd.Add("Depart_id", Depart_id)
            End If
            cd.Add("Annual_year", Annual_Year)
            cd.Add("Id_card", Id_card)

            Return DAO.UpdateByExample("FSC_Settlement_annual", d, cd) >= 1
        End Function

        ''' <summary>
        ''' 未休假日時數
        ''' </summary>
        ''' <param name="Annual_Days"></param>
        ''' <param name="Reserve_Days1"></param>
        ''' <param name="Reserve_Days2"></param>
        ''' <param name="Vacation_Days"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDay1(ByVal Annual_Days As Double, ByVal Reserve_Days1 As Double, ByVal Reserve_Days2 As Double, ByVal Vacation_Days As Double) As Double
            Return Content.ConvertDayHours(Content.ConvertToHours(Annual_Days) + Content.ConvertToHours(Reserve_Days1) + Content.ConvertToHours(Reserve_Days2) - Content.ConvertToHours(Vacation_Days))
        End Function

        ''' <summary>
        ''' 應休未休日時數
        ''' </summary>
        ''' <param name="Annual_Days"></param>
        ''' <param name="Vacation_Days"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDay2(ByVal Annual_Days As Double, ByVal Vacation_Days As Double) As Double
            '應休未休日數 = 本年休假日數 >= 14 ? ( 本年已休 >=14 ? 0 : 14 - 本年已休  ) : 0  
            Dim day2 As Double = 0
            If Annual_Days >= 14 Then
                day2 = IIf(Vacation_Days >= 14, 0, Content.ConvertDayHours(14 * 8 - Content.ConvertToHours(Vacation_Days)))
            Else
                day2 = 0
            End If
            Return day2
        End Function

        ''' <summary>
        ''' 休假超過應休日時數
        ''' </summary>
        ''' <param name="Annual_Days"></param>
        ''' <param name="Vacation_Days"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDay3(ByVal Annual_Days As Double, ByVal Vacation_Days As Double) As Double
            Dim day3 As Double = 0
            If Annual_Days >= 14 Then
                day3 = IIf(Vacation_Days >= 14, Content.ConvertDayHours(Content.ConvertToHours(Vacation_Days) - 14 * 8), 0)
            Else
                day3 = 0
            End If
            Return day3
        End Function

        ''' <summary>
        ''' 可請領日時數
        ''' </summary>
        ''' <param name="Annual_Days"></param>
        ''' <param name="day1"></param>
        ''' <param name="day2"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDay4(ByVal Annual_Days As Double, ByVal day1 As Double, ByVal day2 As Double) As Double
            '可請領日數 = 本年休假日數 >= 14 ? 本年未休(day1) - 應休未休日數(day2)
            Dim day4 As Double = 0

            Dim day1hours As Integer = Content.ConvertToHours(day1)
            Dim day2hours As Integer = Content.ConvertToHours(day2)

            If Annual_Days >= 14 Then
                day4 = Content.ConvertDayHours(day1hours - day2hours)
                If day4 > Content.ConvertDayHours(Content.ConvertToHours(Annual_Days) - 14 * 8) Then
                    day4 = Content.ConvertDayHours(Content.ConvertToHours(Annual_Days) - 14 * 8)
                End If
            Else
                day4 = 0
            End If
            Return day4
        End Function


        ''' <summary>
        ''' 擬保留至年底休假日時數
        ''' </summary>
        ''' <param name="day4"></param>
        ''' <param name="Reserve_Days"></param>
        ''' <param name="Pay_Days"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDay5(ByVal day4 As Double, ByVal Reserve_Days As Double, ByVal Pay_Days As Double) As Double
            Return Content.ConvertDayHours(Content.ConvertToHours(day4) - Content.ConvertToHours(Reserve_Days) - Content.ConvertToHours(Pay_Days))
        End Function

        Public Function UpdateHistoryMark(ByVal History_mark As String, ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Annual_year As String) As Boolean
            Return DAO.UpdateHistoryMark(History_mark, Orgcode, Depart_id, Id_card, Annual_year) > 0
        End Function

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Annual_Year As String, ByVal History_mark As String) As DataTable
            Return DAO.GetData(Orgcode, Depart_id, Annual_Year, History_mark)
        End Function

        Public Function getDataByOrgFid(ByVal Orgcode As String, ByVal Flow_id As String) As DataTable
            Return DAO.getDataByOrgFid(Orgcode, Flow_id)
        End Function
    End Class
End Namespace