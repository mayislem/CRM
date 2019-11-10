namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        AgentId = c.Int(nullable: false),
                        AgentName = c.String(),
                        Type = c.String(),
                        TasktId = c.Int(),
                    })
                .PrimaryKey(t => t.AgentId)
                .ForeignKey("dbo.Users", t => t.AgentId)
                .Index(t => t.AgentId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false),
                        ClientName = c.String(),
                        Address = c.String(),
                        CIN = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.Users", t => t.ClientId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false),
                        Content = c.String(),
                        ForumId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Fora", t => t.CommentId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.Fora",
                c => new
                    {
                        ForumId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Date_Pub = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ForumId);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        OfferId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ImgUrl = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.OfferId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Type = c.String(),
                        Price = c.Single(nullable: false),
                        ImageUrl = c.String(),
                        Quantity = c.Long(nullable: false),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.reclamations",
                c => new
                    {
                        Idrec = c.Int(nullable: false, identity: true),
                        titre = c.String(),
                        date = c.DateTime(nullable: false),
                        objet = c.String(),
                        contenu = c.String(),
                        etat = c.String(),
                        ImageURL = c.String(),
                        type = c.Int(nullable: false),
                        ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.Idrec)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Prospects",
                c => new
                    {
                        ProspectId = c.Int(nullable: false),
                        ProspectName = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ProspectId)
                .ForeignKey("dbo.Users", t => t.ProspectId)
                .Index(t => t.ProspectId);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        ResourceId = c.Int(nullable: false, identity: true),
                        TypeResource = c.String(),
                        Date_Location = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ResourceId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserType = c.String(),
                        ClientId = c.Int(),
                        AgentId = c.Int(),
                        ProspectId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prospects", "ProspectId", "dbo.Users");
            DropForeignKey("dbo.Clients", "ClientId", "dbo.Users");
            DropForeignKey("dbo.Agents", "AgentId", "dbo.Users");
            DropForeignKey("dbo.reclamations", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Comments", "CommentId", "dbo.Fora");
            DropIndex("dbo.Prospects", new[] { "ProspectId" });
            DropIndex("dbo.reclamations", new[] { "ProductId" });
            DropIndex("dbo.Comments", new[] { "CommentId" });
            DropIndex("dbo.Clients", new[] { "ClientId" });
            DropIndex("dbo.Agents", new[] { "AgentId" });
            DropTable("dbo.Users");
            DropTable("dbo.Resources");
            DropTable("dbo.Prospects");
            DropTable("dbo.reclamations");
            DropTable("dbo.Products");
            DropTable("dbo.Offers");
            DropTable("dbo.Fora");
            DropTable("dbo.Comments");
            DropTable("dbo.Clients");
            DropTable("dbo.Agents");
        }
    }
}
