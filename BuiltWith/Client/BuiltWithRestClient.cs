using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BuiltWith.Client
{
    public class BuiltWithRestClient
    {
        public string ApiKey { get; }

        public Http.HttpClient HttpClient { get; }

        public BuiltWithRestClient ( string apiKey , Http.HttpClient client = null )
        {
            ApiKey = apiKey;
            HttpClient = client ?? new Http.BasicHttpClient ( );
        }


        public Http.Response Request ( Http.Request request )
        {
            request.SetKey ( ApiKey );
            Http.Response response;
            try
            {
                response = HttpClient.MakeRequest ( request );
            }
            catch ( Exception clientException )
            {
                throw new Exceptions.APIConnectionException (
                    "Connection Error: " + request.ConstructUrl ( ) ,
                    clientException
                );
            }
            return ProcessResponse ( response );
        }


        private static Http.Response ProcessResponse ( Http.Response response )
        {
            if ( response == null )
            {
                throw new Exceptions.APIConnectionException ( "Connection Error: No response received." );
            }

            if ( response.StatusCode == HttpStatusCode.OK ) return response;
            else throw new Exceptions.APIConnectionException ( "Connection Error: Status Code - " + response.StatusCode );

        }
    }

}

