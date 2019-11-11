namespace ContactBook.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Valiation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Street = c.String(),
                        HouseNumber = c.String(),
                        PostalCode = c.String(),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name1 = c.String(nullable: false),
                        Name2 = c.String(),
                        Surname1 = c.String(nullable: false),
                        Surname2 = c.String(),
                        Notes = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Company = c.String(),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        EmailID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        EmailAddress = c.String(),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmailID)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        PhoneNumberID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        PhoneNumber = c.String(),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneNumberID)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneNumbers", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Emails", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Addresses", "ContactId", "dbo.Contacts");
            DropIndex("dbo.PhoneNumbers", new[] { "ContactId" });
            DropIndex("dbo.Emails", new[] { "ContactId" });
            DropIndex("dbo.Addresses", new[] { "ContactId" });
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.Emails");
            DropTable("dbo.Contacts");
            DropTable("dbo.Addresses");
        }
    }
}
