using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore.ConnectionStrings;
using Xunit;

namespace Abp.EntityFrameworkCore.MySQL.Microting.Tests;

public class MicrotingMySQLConnectionStringChecker_Tests : MySqlMicrotingTestBase
{
    [Fact]
    public void Should_Be_Registered_As_IConnectionStringChecker()
    {
        var checker = ServiceProvider.GetRequiredService<IConnectionStringChecker>();
        checker.ShouldBeOfType<MicrotingMySQLConnectionStringChecker>();
    }

    [Fact]
    public async Task Should_Return_NotConnected_For_Unreachable_Host()
    {
        var checker = ServiceProvider.GetRequiredService<IConnectionStringChecker>();

        var result = await checker.CheckAsync(
            "Server=127.0.0.1;Port=1;Database=any;Uid=root;Pwd=invalid;ConnectionTimeout=1");

        result.Connected.ShouldBeFalse();
        result.DatabaseExists.ShouldBeFalse();
    }
}
