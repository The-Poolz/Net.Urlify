# Net.Urlify

**Net.Urlify** is a lightweight and powerful NuGet package designed to simplify the construction of URLs with query parameters in .NET applications.
It provides a clean and fluent way to append query string parameters to URLs using property attributes.

## Features
- **Attribute-based Query Parameters**: Define query parameters directly on model properties using the `QueryStringPropertyAttribute`, including control over the order in which parameters appear in the URL.
- **Automatic URL Encoding**: Automatically handles the URL encoding of query parameters, unless explicitly stated otherwise.
- **Flexible URL Construction**: Seamlessly construct URLs with base paths and append query parameters dynamically extracted from object properties.

## Getting Started

### Usage

1. **Define Your Model**

    Start by decorating your model's properties with the `QueryStringPropertyAttribute` to specify which properties should be included as query string parameters, and optionally specify their order:

```csharp
using Net.Urlify.Attributes;

public class MyModel
{
    [QueryStringProperty("user", false, 2)]
    public string Username { get; set; }

    [QueryStringProperty("age", true, 1)]
    public int Age { get; set; }
}
```
In the above model, Username and Age are marked as query parameters. Username will use "user" as the query parameter name and will not be URL-encoded.
The order property ensures that "user" appears before "age" in the URL query string.

2. **Inherit from Urlify**

    Inherits from `Urlify` and defines a base URL. This class will use the properties of your model to build the full URL.

```csharp
public class MyModel : Urlify
{
    [QueryStringProperty("user", false, 1)]
    public string Username { get; set; }

    [QueryStringProperty("age", true, 2)]
    public int Age { get; set; }

    public MyModel(string baseUrl) : base(baseUrl) { }
}
```

3. **Construct the URL**

    Call the `BuildUrl()` method to construct your URL:

```csharp
var model = new MyModel("http://example.com")
{
    Username = "John Doe",
    Age = 28
};

var url = model.BuildUrl(); // Outputs: http://example.com?user=John%20Doe&age=28
```
