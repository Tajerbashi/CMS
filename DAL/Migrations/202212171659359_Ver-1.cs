namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ver1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PageComments", "Email", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PageComments", "Email", c => c.String(maxLength: 200));
        }
    }
}
