Public Class Abteilung
    Public Property Id As Integer
    Public Property Bezeichnung As String
    Public Overridable Property Mitarbeiter As HashSet(Of Mitarbeiter) = New HashSet(Of Mitarbeiter)()
End Class
