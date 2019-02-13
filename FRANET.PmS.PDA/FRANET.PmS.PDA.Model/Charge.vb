Public Class Charge
    Inherits Entity

    Public Property ChargeBez As String
    Public Property HerstellDatum As Date
    Public Property AndruckHerstellDatum As String
    Public Property VerfallDatum As Date
    Public Property AndruckVerfallDatum As String
    Public Property Menge As Long

    Public Overridable Property Auftrag As Auftrag

End Class
