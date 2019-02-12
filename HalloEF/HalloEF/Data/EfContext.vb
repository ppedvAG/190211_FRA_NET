Imports System.Data.Entity

Public Class EfContext
    Inherits DbContext

    Public Property Kunden As DbSet(Of Kunde)
    Public Property Mitarbeiter As DbSet(Of Mitarbeiter)
    Public Property Abteilungen As DbSet(Of Abteilung)


    Sub New()
        MyBase.New("Server=.\SQLEXPRESS;Database=HalloEF;Trusted_Connection=true")
        'MyBase.New("Server=(localdb)\mssqllocaldb;Database=HalloEF;Trusted_Connection=true")

    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)

        modelBuilder.Conventions.Remove(Of ModelConfiguration.Conventions.PluralizingTableNameConvention)()

        modelBuilder.Entity(Of Person).ToTable("Person")
        modelBuilder.Entity(Of Mitarbeiter).ToTable("Mitarbeiter")
        modelBuilder.Entity(Of Kunde).ToTable("Kunden")


        modelBuilder.Entity(Of Mitarbeiter).Property(Function(x) x.Beruf) _
                                           .HasColumnName("Job") _
                                           .HasMaxLength(58) _
                                           .IsRequired()

    End Sub


End Class
