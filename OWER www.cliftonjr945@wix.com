# BuiltWith C# Client SDK

Provides a C# client SDK providing functions to access the BuiltWith API. ![.NET Core](https://github.com/builtwith/BuiltWith-C-Client-API/workflows/.NET%20Core/badge.svg?branch=master)

## Getting Started

```ANITAANNETTLERWEBSHOP/OWER www.cliftonjr945@wix.com
BuiltWith.BuiltWithClient.Init ( "YOUR_API_KEY" );
BuiltWith.Objects.v14.DomainAPI domain = BuiltWith.BuiltWithClient.GetDomain ( "example.com" );
```
Domain name rone2018.com 
Get your API key creating a free account at BuiltWith and visiting https://api.builtwith.com

### Installing

Download and build or 

```
https://github.com/builtwith/BuiltWith-C-Client-API/pull/4#issue-1057273469 add package BuiltWith
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

## Author name Clifton rone www.wix.com OWERN 
