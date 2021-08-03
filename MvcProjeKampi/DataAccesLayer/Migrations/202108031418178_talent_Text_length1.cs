namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class talent_Text_length1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TalentCards", "Skill", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TalentCards", "Skill", c => c.String(maxLength: 100));
        }
    }
}
