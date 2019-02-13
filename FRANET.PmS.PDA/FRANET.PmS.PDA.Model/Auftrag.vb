Public Class Auftrag
    Inherits Entity

    Public Property Auftragsnummer As String
    Public Property SAPRegion As String
    Public Property Abteilung As String
    Public Property SAPCreated As Date
    Public Property Produktext As String
    Public Property Serialisierung As Integer
    Public Property ProduktMaterialNummer As String

    Public Overridable Property Land As Land
    Public Overridable Property Landanforderung As Landanforderung
    Public Overridable Property Linie As Linie
    Public Overridable Property ProduktNummern As HashSet(Of ProduktNummer) = New HashSet(Of ProduktNummer)()
    Public Overridable Property Chargen As HashSet(Of Charge) = New HashSet(Of Charge)()

End Class
