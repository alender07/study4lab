namespace study4lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Regs", "email", c => c.String(nullable: false));
            AddColumn("dbo.Regs", "PasswordConfirm", c => c.String(nullable: false));
            AlterColumn("dbo.Regs", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Regs", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Regs", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Regs", "Password", c => c.String());
            AlterColumn("dbo.Regs", "Phone", c => c.String());
            AlterColumn("dbo.Regs", "LastName", c => c.String());
            DropColumn("dbo.Regs", "PasswordConfirm");
            DropColumn("dbo.Regs", "email");
        }
    }
}
