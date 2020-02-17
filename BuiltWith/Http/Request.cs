using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BuiltWith.Http
{
    public class Request
    {
        public string ApiKey;

        private readonly Uri _uri;
        private readonly List<KeyValuePair<string , string>> _queryParams;


        public Uri ConstructUrl ( )
        {
            return _queryParams.Count > 0 ?
                new Uri ( _uri.AbsoluteUri + "?" + EncodeParameters ( _queryParams ) ) :
                new Uri ( _uri.AbsoluteUri );
        }

        private static string EncodeParameters ( IEnumerable<KeyValuePair<string , string>> data )
        {
            var result = "";
            var first = true;
            foreach ( var pair in data )
            {
                if ( first )
                {
                    first = false;
                }
                else
                {
                    result += "&";
                }

                result += WebUtility.UrlEncode ( pair.Key ) + "=" + WebUtility.UrlEncode ( pair.Value );

            }

            return result;
        }

        public Request ( string baseUrl, List<KeyValuePair<string , string>> queryParams = null )
        {
            _uri = new Uri ( baseUrl );
            _queryParams = queryParams ?? new List<KeyValuePair<string , string>> ( );
        }

        public void SetKey ( string apiKey )
        {
            ApiKey = apiKey;
        }


        public void AddQueryParam ( string name , string value )
        {
            AddParam ( _queryParams , name , value );
        }

        private static void AddParam ( ICollection<KeyValuePair<string , string>> list , string name , string value )
        {
            list.Add ( new KeyValuePair<string , string> ( name , value ) );
        }
    }
}
