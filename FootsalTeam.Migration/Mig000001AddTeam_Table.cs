using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootsalTeam.Migration
{
    [Migration(1)]
    public class Mig000001AddTeam_Table : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("Teams")
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity()
             .WithColumn("Name").AsString(30).Unique().NotNullable()
             .WithColumn("FirstColor").AsInt32().NotNullable()
             .WithColumn("SecondaryColor").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Teams");
        }

       
    }
}
