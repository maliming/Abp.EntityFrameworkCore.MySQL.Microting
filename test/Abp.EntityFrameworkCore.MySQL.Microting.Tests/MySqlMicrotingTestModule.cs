using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;

namespace Abp.EntityFrameworkCore.MySQL.Microting.Tests;

[DependsOn(
    typeof(AbpEntityFrameworkCoreMySQLMicrotingModule),
    typeof(AbpAutofacModule),
    typeof(AbpTestBaseModule)
)]
public class MySqlMicrotingTestModule : AbpModule
{
}
