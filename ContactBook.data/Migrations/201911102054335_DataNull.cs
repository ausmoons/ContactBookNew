namespace ContactBook.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
