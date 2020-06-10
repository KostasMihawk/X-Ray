namespace X_Ray.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timespan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Radiographies", "SuggestedDateTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Radiographies", "SuggestedDateTime");
        }
    }
}
