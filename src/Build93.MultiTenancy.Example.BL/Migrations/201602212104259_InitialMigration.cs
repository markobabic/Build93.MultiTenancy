namespace Build93.MultiTenancy.Example.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        TenantId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tenants", t => t.TenantId)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.Tenants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Domain = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TenantId", "dbo.Tenants");
            DropIndex("dbo.Courses", new[] { "TenantId" });
            DropTable("dbo.Tenants");
            DropTable("dbo.Courses");
        }
    }
}
