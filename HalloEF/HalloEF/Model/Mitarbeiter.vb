﻿Public Class Mitarbeiter
    Inherits Person
    Public Property Beruf As String
    Public Overridable Property Kunden As HashSet(Of Kunde) = New HashSet(Of Kunde)()
    Public Overridable Property Abteilungen As HashSet(Of Abteilung) = New HashSet(Of Abteilung)()


    'Public Property Alter As Long

    'Public Property Geschlecht As String

End Class
