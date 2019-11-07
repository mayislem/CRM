namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pack_fix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Packs",
                c => new
                    {
                        PackId = c.Int(nullable: false, identity: true),
                        TypePack = c.String(),
                        PackName = c.String(),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.PackId);
            
            AddColumn("dbo.Products", "Pack_PackId", c => c.Int());
            CreateIndex("dbo.Products", "Pack_PackId");
            AddForeignKey("dbo.Products", "Pack_PackId", "dbo.Packs", "PackId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Pack_PackId", "dbo.Packs");
            DropIndex("dbo.Products", new[] { "Pack_PackId" });
            DropColumn("dbo.Products", "Pack_PackId");
            DropTable("dbo.Packs");
        }
    }
}
