namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class talentskill_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TalentCardSkills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        Skill = c.String(maxLength: 20),
                        SkillPoint = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.SkillId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TalentCardSkills");
        }
    }
}
