namespace yStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Error", newName: "ErrorLog");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ErrorLog", newName: "Error");
        }
    }
}
