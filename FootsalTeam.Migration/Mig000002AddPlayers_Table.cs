using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootsalTeam.Migration
{
    [Migration(2)]
    public class Mig000002AddPlayers_Table:FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("Players")
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity()
             .WithColumn("Name").AsString(30).Unique().NotNullable()
             .WithColumn("BirthDay").AsDateTime().NotNullable()
             .WithColumn("TeamId").AsInt32().NotNullable();
                 Create.ForeignKey("FK_Players_Teams").FromTable("Players").ForeignColumn("TeamId")
                .ToTable("Teams").PrimaryColumns("Id");
        }

        public override void Down()
        {
            Delete.Table("Teams");
        }
    }
}
