namespace PersonDetails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonDB1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 50),
                        Occupation = c.String(nullable: false, maxLength: 50),
                        Area = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        ContactNo = c.String(nullable: false, maxLength: 50),
                        Code = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Persons");
        }
    }
}
