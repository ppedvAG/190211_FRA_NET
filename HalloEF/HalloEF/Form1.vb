Imports System.Data.Entity

Public Class Form1
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Dim context As New EfContext()

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim abt1 As New Abteilung
        abt1.Bezeichnung = "PG5"

        Dim abt2 As New Abteilung
        abt2.Bezeichnung = "PG2"

        For i = 1 To 100
            Dim m As New Mitarbeiter With {
                .Name = $"Fred #{i:000}",
                .Beruf = "Macht dinge",
                .GebDatum = Date.Now.AddYears(-40).AddDays(i * 17)
            }

            If i Mod 2 = 0 Then
                m.Abteilungen.Add(abt1)
            End If

            If i Mod 3 = 0 Then
                m.Abteilungen.Add(abt2)
            End If

            context.Mitarbeiter.Add(m)
        Next
        context.SaveChanges()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        context = New EfContext()
        DataGridView1.DataSource = context.Mitarbeiter.Include(Function(x) x.Abteilungen).Include(Function(x) x.Kunden).Where(Function(x) x.Name.StartsWith("F") AndAlso x.GebDatum.Month > 3 AndAlso x.Abteilungen.Any(Function(y) y.Mitarbeiter.Count() > 3)).OrderBy(Function(x) x.Name).Take(300).ToList()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        context.SaveChanges()

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        Dim abts = TryCast(e.Value, IEnumerable(Of Abteilung))
        If Not abts Is Nothing Then
            e.Value = String.Join(", ", abts.Select(Function(x As Abteilung) x.Bezeichnung))
        End If


        Dim kund = TryCast(e.Value, IEnumerable(Of Kunde))
        If Not kund Is Nothing Then e.Value = String.Join(", ", kund.Select(Function(x) $"{x.Name} ({x.KdNummer})"))


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim mits = TryCast(DataGridView1.CurrentRow.DataBoundItem, Mitarbeiter)

        If Not mits Is Nothing Then

            Dim dlg = MessageBox.Show($"Soll der Mitarbeiter {mits.Name} wirklich gelöscht werden?", "Löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlg = DialogResult.Yes Then
                context.Mitarbeiter.Remove(mits)
                context.SaveChanges()
                Button5_Click(Nothing, Nothing)
            End If
        End If


    End Sub
End Class
