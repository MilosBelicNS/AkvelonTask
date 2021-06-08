namespace AkvelonTaskMilosBelic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Priority = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Priority = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        TaskStatus = c.Int(nullable: false),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectTasks", "Project_Id", "dbo.Projects");
            DropIndex("dbo.ProjectTasks", new[] { "Project_Id" });
            DropTable("dbo.ProjectTasks");
            DropTable("dbo.Projects");
        }
    }
}
