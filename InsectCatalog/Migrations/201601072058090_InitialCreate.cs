namespace InsectCatalog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Hosts",
                c => new
                    {
                        HostId = c.Int(nullable: false, identity: true),
                        CommonName = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.HostId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        S3Id = c.String(nullable: false),
                        Caption = c.String(nullable: false),
                        Display = c.Boolean(nullable: false),
                        Photographer_PersonId = c.Int(nullable: false),
                        Insect_InsectId = c.Int(),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.People", t => t.Photographer_PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Insects", t => t.Insect_InsectId)
                .Index(t => t.Photographer_PersonId)
                .Index(t => t.Insect_InsectId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Insects",
                c => new
                    {
                        InsectId = c.Int(nullable: false, identity: true),
                        Family = c.String(nullable: false),
                        Tribe = c.String(nullable: false),
                        Genus = c.String(nullable: false),
                        Species = c.String(nullable: false),
                        Subspecies = c.String(nullable: false),
                        CommonName = c.String(nullable: false),
                        County = c.String(nullable: false),
                        CollectionDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        Author_AuthorId = c.Int(nullable: false),
                        Collector_PersonId = c.Int(nullable: false),
                        Host_HostId = c.Int(nullable: false),
                        Identifier_PersonId = c.Int(),
                        Location_LocationId = c.Int(nullable: false),
                        Method_MethodId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InsectId)
                .ForeignKey("dbo.Authors", t => t.Author_AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Collector_PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Hosts", t => t.Host_HostId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Identifier_PersonId)
                .ForeignKey("dbo.Locations", t => t.Location_LocationId, cascadeDelete: true)
                .ForeignKey("dbo.Methods", t => t.Method_MethodId, cascadeDelete: true)
                .Index(t => t.Author_AuthorId)
                .Index(t => t.Collector_PersonId)
                .Index(t => t.Host_HostId)
                .Index(t => t.Identifier_PersonId)
                .Index(t => t.Location_LocationId)
                .Index(t => t.Method_MethodId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.Methods",
                c => new
                    {
                        MethodId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.MethodId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Insects", "Method_MethodId", "dbo.Methods");
            DropForeignKey("dbo.Insects", "Location_LocationId", "dbo.Locations");
            DropForeignKey("dbo.Images", "Insect_InsectId", "dbo.Insects");
            DropForeignKey("dbo.Insects", "Identifier_PersonId", "dbo.People");
            DropForeignKey("dbo.Insects", "Host_HostId", "dbo.Hosts");
            DropForeignKey("dbo.Insects", "Collector_PersonId", "dbo.People");
            DropForeignKey("dbo.Insects", "Author_AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Images", "Photographer_PersonId", "dbo.People");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Insects", new[] { "Method_MethodId" });
            DropIndex("dbo.Insects", new[] { "Location_LocationId" });
            DropIndex("dbo.Insects", new[] { "Identifier_PersonId" });
            DropIndex("dbo.Insects", new[] { "Host_HostId" });
            DropIndex("dbo.Insects", new[] { "Collector_PersonId" });
            DropIndex("dbo.Insects", new[] { "Author_AuthorId" });
            DropIndex("dbo.Images", new[] { "Insect_InsectId" });
            DropIndex("dbo.Images", new[] { "Photographer_PersonId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Methods");
            DropTable("dbo.Locations");
            DropTable("dbo.Insects");
            DropTable("dbo.People");
            DropTable("dbo.Images");
            DropTable("dbo.Hosts");
            DropTable("dbo.Authors");
        }
    }
}
