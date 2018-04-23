namespace TheAmazingRace.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PitStop",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PitStopName = c.String(maxLength: 50),
                        ChallengDescription = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PostalCode = c.String(maxLength: 6),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedById = c.String(maxLength: 128),
                        UpdatedOn = c.DateTime(),
                        UpdatedById = c.String(maxLength: 128),
                        RaceEvent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RaceEvent", t => t.RaceEvent_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedById)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById)
                .Index(t => t.RaceEvent_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        PhotoData = c.Binary(),
                        PhotoContentType = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedById = c.String(maxLength: 128),
                        UpdatedOn = c.DateTime(),
                        UpdatedById = c.String(maxLength: 128),
                        TeamId = c.Int(),
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
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.Team", t => t.TeamId)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedById)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById)
                .Index(t => t.TeamId)
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
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        RaceEventId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedById = c.String(maxLength: 128),
                        UpdatedOn = c.DateTime(),
                        UpdatedById = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.RaceEvent", t => t.RaceEventId)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedById)
                .Index(t => t.RaceEventId)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById);
            
            CreateTable(
                "dbo.RaceEvent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventName = c.String(nullable: false, maxLength: 50),
                        EventDate = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                        PostalCode = c.String(maxLength: 6),
                        StartLatitude = c.Double(nullable: false),
                        StartLongitude = c.Double(nullable: false),
                        AdditionalInfo = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedById = c.String(maxLength: 128),
                        UpdatedOn = c.DateTime(),
                        UpdatedById = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedById)
                .Index(t => t.EventName, unique: true)
                .Index(t => t.CreatedById)
                .Index(t => t.UpdatedById);
            
            CreateTable(
                "dbo.RaceEventPitStop",
                c => new
                    {
                        RaceEventId = c.Int(nullable: false),
                        PitStopId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RaceEventId, t.PitStopId })
                .ForeignKey("dbo.PitStop", t => t.PitStopId, cascadeDelete: true)
                .ForeignKey("dbo.RaceEvent", t => t.RaceEventId, cascadeDelete: true)
                .Index(t => t.RaceEventId)
                .Index(t => t.PitStopId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RaceEventPitStop", "RaceEventId", "dbo.RaceEvent");
            DropForeignKey("dbo.RaceEventPitStop", "PitStopId", "dbo.PitStop");
            DropForeignKey("dbo.PitStop", "UpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.PitStop", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "UpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Team", "UpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "TeamId", "dbo.Team");
            DropForeignKey("dbo.Team", "RaceEventId", "dbo.RaceEvent");
            DropForeignKey("dbo.RaceEvent", "UpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.PitStop", "RaceEvent_Id", "dbo.RaceEvent");
            DropForeignKey("dbo.RaceEvent", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Team", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RaceEventPitStop", new[] { "PitStopId" });
            DropIndex("dbo.RaceEventPitStop", new[] { "RaceEventId" });
            DropIndex("dbo.RaceEvent", new[] { "UpdatedById" });
            DropIndex("dbo.RaceEvent", new[] { "CreatedById" });
            DropIndex("dbo.RaceEvent", new[] { "EventName" });
            DropIndex("dbo.Team", new[] { "UpdatedById" });
            DropIndex("dbo.Team", new[] { "CreatedById" });
            DropIndex("dbo.Team", new[] { "RaceEventId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "TeamId" });
            DropIndex("dbo.AspNetUsers", new[] { "UpdatedById" });
            DropIndex("dbo.AspNetUsers", new[] { "CreatedById" });
            DropIndex("dbo.PitStop", new[] { "RaceEvent_Id" });
            DropIndex("dbo.PitStop", new[] { "UpdatedById" });
            DropIndex("dbo.PitStop", new[] { "CreatedById" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RaceEventPitStop");
            DropTable("dbo.RaceEvent");
            DropTable("dbo.Team");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.PitStop");
        }
    }
}
