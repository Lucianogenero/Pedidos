using FluentMigrator;
using Orders.Infra.Migrations.Migrations;

namespace Orders.Infra.Migrations.Versions
{
    [Migration(DataBaseVersions.TABLE_USER,"Create table to save the user´s information")]
    public class Migration0000001 : VersionBase
    {
        public override void Up()
        {
            CreateTableBase("Order")
                .WithColumn("IsFinished").AsBoolean().WithDefaultValue(false);

            CreateTableBase("Item")
                .WithColumn("name").AsString(40).NotNullable()
                .WithColumn("Quantidade").AsInt32().NotNullable()
                .WithColumn("OrderId").AsInt64().NotNullable().ForeignKey("FK_Order_Id", "Order", "Id")
                .OnDelete(System.Data.Rule.Cascade);
        }
    }
}
