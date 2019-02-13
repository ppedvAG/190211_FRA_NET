Public Class Land
    Inherits Entity

    Public Property Name As String
    Public Property Kurzname As String

    Public Overridable Property Auftraege As HashSet(Of Auftrag) = New HashSet(Of Auftrag)

End Class
