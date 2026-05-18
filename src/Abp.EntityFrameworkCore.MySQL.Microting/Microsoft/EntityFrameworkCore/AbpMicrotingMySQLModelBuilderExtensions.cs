using Volo.Abp.EntityFrameworkCore;

namespace Microsoft.EntityFrameworkCore;

public static class AbpMicrotingMySqlModelBuilderExtensions
{
    public static void UseMySQL(
        this ModelBuilder modelBuilder)
    {
        modelBuilder.SetDatabaseProvider(EfCoreDatabaseProvider.MySql);
    }
}
