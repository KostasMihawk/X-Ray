namespace X_Ray.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedandModifiedprops : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Radiographies", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Radiographies", "Modified", c => c.DateTime());
            AddColumn("dbo.Radiographies", "CreatedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Radiographies", "ModifiedBy_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Radiographies", "CreatedBy_Id");
            CreateIndex("dbo.Radiographies", "ModifiedBy_Id");
            AddForeignKey("dbo.Radiographies", "CreatedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Radiographies", "ModifiedBy_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Radiographies", "ModifiedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Radiographies", "CreatedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Radiographies", new[] { "ModifiedBy_Id" });
            DropIndex("dbo.Radiographies", new[] { "CreatedBy_Id" });
            DropColumn("dbo.Radiographies", "ModifiedBy_Id");
            DropColumn("dbo.Radiographies", "CreatedBy_Id");
            DropColumn("dbo.Radiographies", "Modified");
            DropColumn("dbo.Radiographies", "Created");
        }
    }
}
