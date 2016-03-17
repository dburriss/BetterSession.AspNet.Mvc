# BetterSession
Extension methods for helping deal with complex types for TempData and Session.

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