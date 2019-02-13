Public Class ProduktNummer
    Inherits Entity
    Public Property NumTyp As String 'NUMTP
    Public Property ProduktNr As String 'EAN11

    Public Overridable Property Auftraege As HashSet(Of Auftrag) = New HashSet(Of Auftrag)

End Class
