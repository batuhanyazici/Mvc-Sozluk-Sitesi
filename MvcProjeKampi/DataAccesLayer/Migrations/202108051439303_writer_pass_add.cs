namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class writer_pass_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterPasswordOrginal", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterPasswordOrginal");
        }
    }
}
