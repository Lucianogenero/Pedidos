using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace Orders.Infra.Migrations.Versions
{
    public abstract class VersionBase : ForwardOnlyMigration
    {
        public ICreateTableColumnOptionOrWithColumnSyntax CreateTableBase(string table)
        {
               return Create.Table(table)
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("CreateOn").AsDateTime().NotNullable();
        }
            
    }
}
