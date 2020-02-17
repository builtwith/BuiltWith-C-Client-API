# BuiltWith C# Client SDK

Provides a C# client SDK providing functions to access the BuiltWith API.

## Getting Started

```
BuiltWith.BuiltWithClient.Init ( "YOUR_API_KEY" );
BuiltWith.Objects.v14.DomainAPI domain = BuiltWith.BuiltWithClient.GetDomain ( "example.com" );
```

Get your API key by creating a free account at BuiltWith and visiting https://api.builtwityh.com

### Installing

Download and build or 

```
dotnet add package BuiltWith
```

https://www.nuget.org/packages/BuiltWith/


## Supported Endpoints

- [x] [Domain API](https://api.builtwith.com/domain-api)
- [ ] [Free API](https://api.builtwith.com/free-api)
- [ ] [Lists API](https://api.builtwith.com/lists-api)
- [ ] [Relationships API](https://api.builtwith.com/relationships-api)
- [ ] [Keywords API](https://api.builtwith.com/keywords-api)
- [ ] [Trends API](https://api.builtwith.com/trends-api)
- [ ] [Company to URL API](https://api.builtwith.com/company-to-url)

## Dependencies

* .NETStandard 2.0
* Newtonsoft.Json (>= 12.0.3)


## Licence
MIT

## Authors
Gary Brewer