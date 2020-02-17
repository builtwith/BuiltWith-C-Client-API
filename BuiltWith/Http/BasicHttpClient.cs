using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BuiltWith.Http
{
    public class BasicHttpClient : HttpClient
    {

        public BasicHttpClient ( System.Net.Http.HttpClient httpClient = null )
        {
            _httpClient = httpClient ?? new System.Net.Http.HttpClient ( );
        }


        private readonly System.Net.Http.HttpClient _httpClient;
        public override Response MakeRequest ( Request request )
        {
            try
            {
                var task = MakeRequestAsync ( request );
                task.Wait ( );
                return task.Result;
            }
            catch ( AggregateException ae )
            {
                // Combine nested AggregateExceptions
                ae = ae.Flatten ( );
                throw ae.InnerExceptions [ 0 ];
            }
        }

        public override async Task<Response> MakeRequestAsync ( Request request )
        {
            var httpRequest = BuildHttpRequest ( request );


            var httpResponse = await _httpClient.SendAsync ( httpRequest ).ConfigureAwait ( false );
            var reader = new StreamReader ( await httpResponse.Content.ReadAsStreamAsync ( ).ConfigureAwait ( false ) );

            // Create and return a new Response. Keep a reference to the last
            // response for debugging, but don't return it as it may be shared
            // among threads.
            var response = new Response ( httpResponse.StatusCode , await reader.ReadToEndAsync ( ).ConfigureAwait ( false ) );
            return response;
        }





        private HttpRequestMessage BuildHttpRequest ( Request request )
        {
            var httpRequest = new HttpRequestMessage (
                new System.Net.Http.HttpMethod ("GET") ,
                request.ConstructUrl ( )
            );

            httpRequest.Headers.TryAddWithoutValidation ( "User-Agent" , "builtwith-csharp-lib" );

            return httpRequest;
        }
    }
}
