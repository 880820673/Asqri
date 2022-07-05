namespace DominClass.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dorehs", "GroupId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dorehs", "GroupId", c => c.String());
        }
    }
}
