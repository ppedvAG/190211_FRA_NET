Imports System.Data.Entity
Imports FRANET.PmS.PDA.Model

Public Class EfContext
    Inherits DbContext

    Public Property Auftraege As DbSet(Of Auftrag)
    Public Property Chargen As DbSet(Of Charge)
    Public Property Laender As DbSet(Of Land)
    Public Property Landanforderungen As DbSet(Of Landanforderung)
    Public Property Linien As DbSet(Of Linie)
    Public Property ProduktNummern As DbSet(Of ProduktNummer)

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        modelBuilder.Conventions.Remove(Of ModelConfiguration.Conventions.PluralizingTableNameConvention)()

        modelBuilder.Properties(Of Date).Configure(Function(c) c.HasColumnType("datetime2"))

    End Sub

    Sub New(connectionString As String)
        MyBase.New(connectionString)
    End Sub

    Sub New()
        MyBase.New("Server=.\SQLEXPRESS;Database=PDA_dev;Trusted_Connection=true")
        'MyBase.New("Server=(localdb)\mssqllocaldb;Database=PDA_dev;Trusted_Connection=true")
    End Sub

End Class
