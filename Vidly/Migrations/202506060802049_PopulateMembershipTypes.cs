namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationMonths, DiscountRate) VALUES (1,0,0,0)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationMonths, DiscountRate) VALUES (2,300,1,10)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationMonths, DiscountRate) VALUES (3,900,3,15)");
            Sql("INSERT INTO MembershipTypes(Id, SignUpFee, DurationMonths, DiscountRate) VALUES (4,3600,12,20)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM MembershipTypes WHERE Id IN (1,2,3,4)");
        }
    }
}
