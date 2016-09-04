# BetterSession

Extension methods for helping deal with complex types for TempData and Session.

| DEV |MASTER|BLEEDING|NUGET|
|-----|------|--------|-----|
|[![CI status][1]][2]|[![Release Build status][3]][4]|[![MyGet CI][5]][6]|[![NuGet CI][7]][8]|

# Usage

## Session

The ISession has a `void Set<T>(string key, T value)` and `T Get<T>(string key)` methods.

`using BetterSession.AspNet.Mvc;`

```csharp
var model = new TestModel()
{
    Nr = 1,
    Name = "D"
};
session.Set("t", model);
var value = session.Get<TestModel>("t");
```

## TempData

The ITempDataDictionary has a `void Set<T>(string key, T value)` and `T Get<T>(string key)` methods.

`using BetterSession.AspNet.Mvc;`

```csharp
var model = new TestModel()
{
    Nr = 1,
    Name = "D"
};
tempData.Set("t", model);
var value = tempData.Get<TestModel>("t");
```

[1]: https://ci.appveyor.com/api/projects/status/3tifnpya6kvai7p8?svg=true
[2]: https://ci.appveyor.com/project/dburriss/bettersession-aspnet-mvc
[3]: https://ci.appveyor.com/api/projects/status/3tifnpya6kvai7p8/branch/master?svg=true
[4]: https://ci.appveyor.com/project/dburriss/bettersession-aspnet-mvc/branch/master
[5]: https://img.shields.io/myget/dburriss-ci/vpre/BetterSession.AspNetCore.svg
[6]: http://myget.org/gallery/dburriss-ci
[7]: https://img.shields.io/nuget/v/BetterSession.AspNetCore.svg
[8]: https://www.nuget.org/packages/BetterSession.AspNetCore/