namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class priceoffer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offers", "Price", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offers", "Price");
        }
    }
}
