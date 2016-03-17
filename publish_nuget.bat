dotnet restore src\BetterSession.AspNet.Mvc\project.json
dotnet pack src\BetterSession.AspNet.Mvc\project.json -c Release -o artifacts\bin\BetterSession.AspNet.Mvc\Release

set /p version="Version: "
nuget push artifacts\bin\BetterSession.AspNet.Mvc\Release\BetterSession.AspNet.Mvc.%version%.nupkg