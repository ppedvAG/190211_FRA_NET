Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class InitialCreate
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Abteilung",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Bezeichnung = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.Person",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Name = c.String(),
                        .GebDatum = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.MitarbeiterAbteilung",
                Function(c) New With
                    {
                        .Mitarbeiter_Id = c.Int(nullable := False),
                        .Abteilung_Id = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.Mitarbeiter_Id, t.Abteilung_Id }) _
                .ForeignKey("dbo.Mitarbeiter", Function(t) t.Mitarbeiter_Id, cascadeDelete := True) _
                .ForeignKey("dbo.Abteilung", Function(t) t.Abteilung_Id, cascadeDelete := True) _
                .Index(Function(t) t.Mitarbeiter_Id) _
                .Index(Function(t) t.Abteilung_Id)
            
            CreateTable(
                "dbo.Kunden",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False),
                        .Mitarbeiter_Id = c.Int(),
                        .KdNummer = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Person", Function(t) t.Id) _
                .ForeignKey("dbo.Mitarbeiter", Function(t) t.Mitarbeiter_Id) _
                .Index(Function(t) t.Id) _
                .Index(Function(t) t.Mitarbeiter_Id)
            
            CreateTable(
                "dbo.Mitarbeiter",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False),
                        .Job = c.String(nullable := False, maxLength := 58)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Person", Function(t) t.Id) _
                .Index(Function(t) t.Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Mitarbeiter", "Id", "dbo.Person")
            DropForeignKey("dbo.Kunden", "Mitarbeiter_Id", "dbo.Mitarbeiter")
            DropForeignKey("dbo.Kunden", "Id", "dbo.Person")
            DropForeignKey("dbo.MitarbeiterAbteilung", "Abteilung_Id", "dbo.Abteilung")
            DropForeignKey("dbo.MitarbeiterAbteilung", "Mitarbeiter_Id", "dbo.Mitarbeiter")
            DropIndex("dbo.Mitarbeiter", New String() { "Id" })
            DropIndex("dbo.Kunden", New String() { "Mitarbeiter_Id" })
            DropIndex("dbo.Kunden", New String() { "Id" })
            DropIndex("dbo.MitarbeiterAbteilung", New String() { "Abteilung_Id" })
            DropIndex("dbo.MitarbeiterAbteilung", New String() { "Mitarbeiter_Id" })
            DropTable("dbo.Mitarbeiter")
            DropTable("dbo.Kunden")
            DropTable("dbo.MitarbeiterAbteilung")
            DropTable("dbo.Person")
            DropTable("dbo.Abteilung")
        End Sub
    End Class
End Namespace
