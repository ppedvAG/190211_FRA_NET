Public Class Linie
    Inherits Entity

    Public Property Name As String
    Public Property Arbeitsplatz As String

    Public Overridable Property Auftraege As HashSet(Of Auftrag) = New HashSet(Of Auftrag)

End Class
