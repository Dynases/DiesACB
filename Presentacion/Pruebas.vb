Imports DevComponents.Schedule.Model
Imports DevComponents.DotNetBar.Schedule

Public Class Pruebas
#Region "METODOS PRIVADOS"
    Private Function AddNewAppointment(ByVal startDate As DateTime, ByVal endDate As DateTime) As Appointment
        ' Create new appointment and add it to the model
        ' Appointment will show up in the view automatically

        Dim appointment As New Appointment()

        appointment.StartTime = startDate
        appointment.EndTime = endDate

        appointment.Subject = "New " & appointment.CategoryColor & " appointment!"

        appointment.Description = "This is a new appointment"
        appointment.Tooltip = "This is a Custom tooltip for this new appointment"

        ''poner recurrencia
        appointment.Recurrence = New AppointmentRecurrence()
        appointment.Recurrence.RecurrenceType = eRecurrencePatternType.Daily
        appointment.Recurrence.RecurrenceStartDate = startDate
        appointment.Recurrence.RangeEndDate = startDate.AddDays(3)

        ' Add appointment to the model

        CalendarView1.CalendarModel.Appointments.Add(appointment)

        Return (appointment)
    End Function
#End Region

    Private Sub Pruebas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '' Create our Model
        Dim _Model As New CalendarModel()

        CalendarView1.CalendarModel = _Model

        Dim workDay As WorkDay = _Model.WorkDays(DayOfWeek.Monday)

        Dim workStartTime As New WorkTime()

        workStartTime.Hour = 10
        workStartTime.Minute = 30
        workDay.WorkStartTime = workStartTime

        ' Set working day end time
        ' 8:00 PM, 24 hour format is used

        Dim workEndTime As New WorkTime()

        workEndTime.Hour = 12
        workEndTime.Minute = 0
        workDay.WorkEndTime = workEndTime

        '' Mark time slots every Sunday from 12:00 to 17:00

        'Dim dsa As New DaySlotAppearance(New WorkTime(12, 0), New WorkTime(17, 0), Color.LightCyan, Color.SkyBlue, Color.LightBlue)
        'Dim dsb As New DaySlotBackground(DayOfWeek.Sunday, dsa)

        'CalendarView1.ViewDisplayCustomizations.DaySlotBackgrounds.Add(dsb)

        '' Mark time slots for today from 9:00 to 13:30

        'dsa = New DaySlotAppearance(New WorkTime(9, 0), New WorkTime(13, 30), Color.LightYellow, Color.Orange, Color.Yellow)
        'dsb = New DaySlotBackground(DateTime.Today, dsa)

        'CalendarView1.ViewDisplayCustomizations.DaySlotBackgrounds.Add(dsb)
    End Sub

    Private Sub CalendarView1_ItemDoubleClick(sender As Object, e As MouseEventArgs) Handles CalendarView1.ItemDoubleClick
        Dim startDate As DateTime = CalendarView1.DateSelectionStart.GetValueOrDefault()
        Dim endDate As DateTime = CalendarView1.DateSelectionEnd.GetValueOrDefault()

        AddNewAppointment(startDate, endDate)
    End Sub
End Class