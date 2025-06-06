namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Web.UI.WebControls.WebParts;

    public partial class SetNameOfMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name ='Pay as you Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name ='Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name ='Quaterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name ='Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
            Sql("UPDATE MembershipTypes SET Name = NULL WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = NULL WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = NULL WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = NULL WHERE Id = 4");
        }
    }
}
