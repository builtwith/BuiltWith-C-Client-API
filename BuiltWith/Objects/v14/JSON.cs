namespace BuiltWith.Objects.v14
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using J = Newtonsoft.Json.JsonPropertyAttribute;
    using R = Newtonsoft.Json.Required;
    using N = Newtonsoft.Json.NullValueHandling;


    public partial class DomainAPI
    {
        public static DomainAPI FromJson ( string json ) => JsonConvert.DeserializeObject<DomainAPI> ( json , BuiltWith.Objects.v14.Converter.Settings );
    }

    public partial class DomainAPI
    {
        [J ( "Results" )] public ResultElement [ ] Results { get; set; }
        [J ( "Errors" )] public object [ ] Errors { get; set; }
    }

    public partial class ResultElement
    {
        [J ( "Result" )] public ResultResult Result { get; set; }
        [J ( "Meta" )] public Meta Meta { get; set; }
        [J ( "Attributes" )] public Dictionary<string , long> Attributes { get; set; }
        [J ( "FirstIndexed" )] public long FirstIndexed { get; set; }
        [J ( "LastIndexed" )] public long LastIndexed { get; set; }
        [J ( "Lookup" )] public string Lookup { get; set; }
    }

    public partial class Meta
    {
        [J ( "Majestic" )] public long Majestic { get; set; }
        [J ( "Umbrella" )] public long Umbrella { get; set; }
        [J ( "Vertical" )] public string Vertical { get; set; }
        [J ( "Social" )] public Uri [ ] Social { get; set; }
        [J ( "CompanyName" )] public string CompanyName { get; set; }
        [J ( "Telephones" )] public string [ ] Telephones { get; set; }
        [J ( "Emails" )] public object [ ] Emails { get; set; }
        [J ( "City" )] public string City { get; set; }
        [J ( "State" )] public string State { get; set; }
        [J ( "Postcode" )]  public string Postcode { get; set; }
        [J ( "Country" )] public string Country { get; set; }
        [J ( "Names" )] public Name [ ] Names { get; set; }
        [J ( "ARank" )] public long ARank { get; set; }
        [J ( "QRank" )] public long QRank { get; set; }
    }

    public partial class Name
    {
        [J ( "Name" )] public string NameName { get; set; }
        [J ( "Type" )] public long Type { get; set; }
        [J ( "Email" )] public string Email { get; set; }
    }

    public partial class ResultResult
    {
        [J ( "IsDB" )] public string IsDb { get; set; }
        [J ( "Spend" )] public long Spend { get; set; }
        [J ( "Paths" )] public Path [ ] Paths { get; set; }
    }

    public partial class Path
    {
        [J ( "FirstIndexed" )] public long FirstIndexed { get; set; }
        [J ( "LastIndexed" )] public long LastIndexed { get; set; }
        [J ( "Domain" )] public string Domain { get; set; }
        [J ( "Url" )] public string Url { get; set; }
        [J ( "SubDomain" )] public string SubDomain { get; set; }
        [J ( "Technologies" )] public Technology [ ] Technologies { get; set; }
    }

    public partial class Technology
    {
        [J ( "Categories" )] public string [ ] Categories { get; set; }
        [J ( "IsPremium" )] public IsPremium IsPremium { get; set; }
        [J ( "Name" )] public string Name { get; set; }
        [J ( "Description" )] public string Description { get; set; }
        [J ( "Link" )] public Uri Link { get; set; }
        [J ( "Tag" )] public string Tag { get; set; }
        [J ( "FirstDetected" )] public long FirstDetected { get; set; }
        [J ( "LastDetected" )] public long LastDetected { get; set; }
    }


    public enum IsPremium { Maybe, No, Yes };


    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore ,
            DateParseHandling = DateParseHandling.None ,
            Converters =
            {
                IsPremiumConverter.Singleton,
                
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            } ,
        };
    }

   

    

    internal class IsPremiumConverter : JsonConverter
    {
        public override bool CanConvert ( Type t ) => t == typeof ( IsPremium ) || t == typeof ( IsPremium? );

        public override object ReadJson ( JsonReader reader , Type t , object existingValue , JsonSerializer serializer )
        {
            if ( reader.TokenType == JsonToken.Null ) return null;
            var value = serializer.Deserialize<string> ( reader );
            switch ( value )
            {
                case "maybe":
                    return IsPremium.Maybe;
                case "no":
                    return IsPremium.No;
                case "yes":
                    return IsPremium.Yes;
            }
            throw new Exception ( "Cannot unmarshal type IsPremium" );
        }

        public override void WriteJson ( JsonWriter writer , object untypedValue , JsonSerializer serializer )
        {
            if ( untypedValue == null )
            {
                serializer.Serialize ( writer , null );
                return;
            }
            var value = ( IsPremium ) untypedValue;
            switch ( value )
            {
                case IsPremium.Maybe:
                    serializer.Serialize ( writer , "maybe" );
                    return;
                case IsPremium.No:
                    serializer.Serialize ( writer , "no" );
                    return;
                case IsPremium.Yes:
                    serializer.Serialize ( writer , "yes" );
                    return;
            }
            throw new Exception ( "Cannot marshal type IsPremium" );
        }

        public static readonly IsPremiumConverter Singleton = new IsPremiumConverter ( );
    }

    
}
