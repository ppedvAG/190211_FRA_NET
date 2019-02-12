Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class v2
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Mitarbeiter", "Alter", Function(c) c.Long(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.Mitarbeiter", "Alter")
        End Sub
    End Class
End Namespace
