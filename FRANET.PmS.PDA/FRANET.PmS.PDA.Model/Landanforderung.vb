Public Class Landanforderung
    Inherits Entity

    Public Property Name As String
    Public Property Kurzname As String
    'todo LSserial hier einbauen...
    Public Overridable Property Auftraege As HashSet(Of Auftrag) = New HashSet(Of Auftrag)

End Class


