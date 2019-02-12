Public Class Calc

    Public Function Sum(a As Integer, b As Integer) As Integer
        Return a + b
    End Function

    Public Function Minus(v1 As Integer, v2 As Integer) As Object
        Throw New NotImplementedException()
    End Function

    Public Function IsWeekend() As Boolean
        'Return Date.Now.DayOfWeek = DayOfWeek.Saturday Or Date.Now.DayOfWeek = DayOfWeek.Sunday
        Return IsWeekend(Date.Now)
    End Function

    Public Function IsWeekend(now As Date) As Boolean
        Return now.DayOfWeek = DayOfWeek.Saturday Or now.DayOfWeek = DayOfWeek.Sunday
    End Function
End Class
