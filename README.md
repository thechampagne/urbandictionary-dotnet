# Urbandic

[![](https://img.shields.io/github/v/tag/thechampagne/urbandictionary-dotnet?label=version)](https://github.com/thechampagne/urbandictionary-dotnet/releases/latest) [![](https://img.shields.io/github/license/thechampagne/urbandictionary-dotnet)](https://github.com/thechampagne/urbandictionary-dotnet/blob/main/LICENSE)

Urban Dictionary API client for **.NET**

### Download
[NuGet](https://www.nuget.org/packages/Urbandic/)

**.NET CLI**
```
dotnet add package Urbandic
```
**NuGet CLI**
```
nuget install Urbandic
```
**Package Manager**
```
Install-Package Urbandic
```

### Example

```csharp
static void Main(string[] args)
{
    foreach (var i in UrbanDictionary.Search("Dictionary"))
    {
        Console.WriteLine(i.definition);
    }
}
```

### License

Urbandic is released under the [MIT License](https://github.com/thechampagne/urbandictionary-dotnet/blob/main/LICENSE).