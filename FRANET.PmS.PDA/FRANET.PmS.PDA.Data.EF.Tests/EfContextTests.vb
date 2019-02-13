Imports System.Text
Imports FRANET.PmS.PDA.Model
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class EfContextTests

    <TestMethod()>
    Public Sub EfContext_can_create_database()

        Dim con As New EfContext("Server=.\SQLEXPRESS;Database=PDA_dev_CreateTest;Trusted_Connection=true")

        If con.Database.Exists() Then
            con.Database.Delete()
        End If

        con.Database.Create()

        Assert.IsTrue(con.Database.Exists())
    End Sub

    <TestMethod()>
    Public Sub EfContext_can_CRUD_Auftrag()

        Dim auf As New Auftrag
        auf.Auftragsnummer = $"0001-{Guid.NewGuid()}"

        Dim newAufNr = $"1110-{Guid.NewGuid()}"

        'CREATE
        Using con As New EfContext()
            con.Auftraege.Add(auf)
            con.SaveChanges()
        End Using

        'check CREATE(READ) + UPDATE
        Using con As New EfContext()
            Dim loaded = con.Auftraege.Find(auf.Id)
            Assert.AreEqual(auf.Auftragsnummer, loaded.Auftragsnummer)

            'UPDATE
            loaded.Auftragsnummer = newAufNr
            con.SaveChanges()
        End Using

        'check UPDATE + DELETE
        Using con As New EfContext()
            Dim loaded = con.Auftraege.Find(auf.Id)
            Assert.AreEqual(newAufNr, loaded.Auftragsnummer)

            'DELETE
            con.Auftraege.Remove(loaded)
            con.SaveChanges()
        End Using

        'check DELETE
        Using con As New EfContext()
            Dim loaded = con.Auftraege.Find(auf.Id)
            Assert.IsNull(loaded)
        End Using

    End Sub

End Class