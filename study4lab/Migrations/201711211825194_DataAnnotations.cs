namespace study4lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "Name", c => c.String(maxLength: 150));
            AlterColumn("dbo.Books", "Title", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Title", c => c.String());
            AlterColumn("dbo.Authors", "Name", c => c.String());
        }
    }
}
