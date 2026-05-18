using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shouldly;
using Volo.Abp.EntityFrameworkCore.GlobalFilters;
using Volo.Abp.Guids;
using Xunit;

namespace Abp.EntityFrameworkCore.MySQL.Microting.Tests;

public class AbpEntityFrameworkCoreMySQLMicrotingModule_Tests : MySqlMicrotingTestBase
{
    [Fact]
    public void Should_Configure_SequentialGuidGenerator_To_SequentialAsString()
    {
        var options = ServiceProvider.GetRequiredService<IOptions<AbpSequentialGuidGeneratorOptions>>().Value;
        options.DefaultSequentialGuidType.ShouldBe(SequentialGuidType.SequentialAsString);
    }

    [Fact]
    public void Should_Configure_EfCoreGlobalFilter_To_UseDbFunction()
    {
        var options = ServiceProvider.GetRequiredService<IOptions<AbpEfCoreGlobalFilterOptions>>().Value;
        options.UseDbFunction.ShouldBeTrue();
    }
}
