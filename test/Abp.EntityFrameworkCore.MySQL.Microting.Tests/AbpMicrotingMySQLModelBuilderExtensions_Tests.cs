using Microsoft.EntityFrameworkCore;
using Shouldly;
using Volo.Abp.EntityFrameworkCore;
using Xunit;

namespace Abp.EntityFrameworkCore.MySQL.Microting.Tests;

public class AbpMicrotingMySQLModelBuilderExtensions_Tests
{
    [Fact]
    public void UseMySQL_Should_Set_DatabaseProvider_To_MySql()
    {
        var modelBuilder = new ModelBuilder();

        modelBuilder.UseMySQL();

        modelBuilder.GetDatabaseProvider().ShouldBe(EfCoreDatabaseProvider.MySql);
    }
}
