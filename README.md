# Abp.EntityFrameworkCore.MySQL.Microting

An ABP EF Core MySQL provider package backed by the [Microting fork](https://github.com/microting/Pomelo.EntityFrameworkCore.MySql) of `Pomelo.EntityFrameworkCore.MySql`.

## Why?

As of 2026, the official `Pomelo.EntityFrameworkCore.MySql` is still stuck on EF Core 9 (no `net10.0` release yet), and `MySql.EntityFrameworkCore` 10.x from Oracle still has open translation bugs (see [`Contains` is broken on EF Core 10](https://github.com/abpframework/abp/issues/24213)). The Microting fork is currently the only Pomelo-compatible MySQL provider that:

- Targets `net10.0` and tracks EF Core 10.x releases
- Is actively maintained
- Keeps Pomelo's public API surface intact (namespace `Microsoft.EntityFrameworkCore`, `UseMySql` extension, `MySqlDbContextOptionsBuilder`)

This package is a thin wrapper that lets ABP 10.x projects use Microting's fork as a drop-in replacement for the Pomelo provider.

## Status

This is a **reference / community package**. It is **not** part of the official ABP framework. The maintainer publishes it so that ABP users blocked on EF Core 10 + MySQL have a working option today. If the official Pomelo provider releases an EF Core 10 version, prefer that one.

## Install

```bash
dotnet add package Abp.EntityFrameworkCore.MySQL.Microting
```

> Not published to NuGet yet. Clone or reference the project locally for now.

## Dependencies

This project uses ABP 10.4.0, Microting 10.0.13, and EF Core 10.0.13. Keep the EF Core package versions aligned in your application.

Microting 10.0.13 includes the [fix for `ExecuteDelete` with `LEFT JOIN`](https://github.com/microting/Pomelo.EntityFrameworkCore.MySql/pull/461), which resolves MySQL error 1093 during OpenIddict token cleanup.

## Usage

```csharp
[DependsOn(typeof(AbpEntityFrameworkCoreMySQLMicrotingModule))]
public class MyProjectEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbContextOptions>(options =>
        {
            options.UseMySQL();
        });
    }
}
```

API is intentionally identical to `Volo.Abp.EntityFrameworkCore.MySQL.Pomelo`, so switching is just:

1. Replace the `Volo.Abp.EntityFrameworkCore.MySQL.Pomelo` package reference with `Abp.EntityFrameworkCore.MySQL.Microting`.
2. Replace `AbpEntityFrameworkCoreMySQLPomeloModule` with `AbpEntityFrameworkCoreMySQLMicrotingModule` in your `[DependsOn(...)]`.
3. Nothing else changes.

## Caveats

- The Microting fork is **community-maintained for the company's own products** (Microting A/S). If the company drops .NET, the fork may stall.
- This package's API is identical to the Pomelo one — you **cannot** reference both at the same time (the `UseMySQL` extension would collide).
- Always check the [Microting fork release notes](https://github.com/microting/Pomelo.EntityFrameworkCore.MySql/commits/master) before upgrading.

## License

MIT
