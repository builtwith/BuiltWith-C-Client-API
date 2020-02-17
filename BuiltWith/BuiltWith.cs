
using System;
using System.Collections.Generic;
using System.Text;

namespace BuiltWith
{

    public class BuiltWithClient
    {

        private static string _key;
        private static Client.BuiltWithRestClient _restClient;


        public static void Init ( string apiKey )
        {
            _key = apiKey;
            if ( string.IsNullOrEmpty ( _key ) ) throw new Exceptions.BuiltWithException ( "Key cannot be blank or null" );
        }

        public static void Init ( Guid apiKey )
        {
            _key = apiKey.ToString ( );
            if ( string.IsNullOrEmpty ( _key ) ) throw new Exceptions.BuiltWithException ( "Key cannot be blank or null" );
        }


        private static Client.BuiltWithRestClient _getRestClient ( )
        {
            if ( _restClient != null )
            {
                return _restClient;
            }

            if ( string.IsNullOrEmpty ( _key ) )
            {
                throw new Exceptions.BuiltWithException ( "No API Key - call BuiltWithClient.Init(\"your api key\"); first" );
            }

            _restClient = new Client.BuiltWithRestClient ( _key );
            return _restClient;

        }


        public static Objects.v14.DomainAPI GetDomain ( params string[] domain )
        {

            if ( string.IsNullOrEmpty ( _key ) ) throw new Exceptions.BuiltWithException ( "No API Key - call BuiltWithClient.Init(\"your api key\"); first" );

            if ( domain.Length > 16 )
            {
                throw new Exceptions.BuiltWithException ( "Maximum 16 domains at a time." );
            }

            List<KeyValuePair<string , string>> @params = new List<KeyValuePair<string , string>> ( );
            @params.Add ( new KeyValuePair<string , string> ( "KEY" , _key ) );
            @params.Add ( new KeyValuePair<string , string> ( "LOOKUP" , string.Join(",",domain) ) );
            System.Threading.Tasks.Task<Http.Response> task = _getRestClient ( ).HttpClient.MakeRequestAsync ( new Http.Request ( "https://api.builtwith.com/v14/api.json" , @params ) );
            task.Wait ( );

            if ( task.Result != null && task.Result.StatusCode == System.Net.HttpStatusCode.OK )
            {
                return Objects.v14.DomainAPI.FromJson ( task.Result.Content );
            }
            else
            {
                throw new Exceptions.APIConnectionException ( "API Error: " + ( task.Result == null ? "Result is NULL" : "Status code - " + task.Result.StatusCode ) );
            }


        }



        public static Objects.v14.DomainAPI GetDomain ( string domain )
        {
            if ( string.IsNullOrEmpty ( _key ) ) throw new Exceptions.BuiltWithException ( "No API Key - call BuiltWithClient.Init(\"your api key\"); first" );


            List<KeyValuePair<string , string>> @params = new List<KeyValuePair<string , string>> ( );
            @params.Add ( new KeyValuePair<string , string> ( "KEY" , _key ) );
            @params.Add ( new KeyValuePair<string , string> ( "LOOKUP" , domain ) );
            System.Threading.Tasks.Task<Http.Response> task = _getRestClient ( ).HttpClient.MakeRequestAsync ( new Http.Request ( "https://api.builtwith.com/v14/api.json" , @params ) );
            task.Wait ( );

            if ( task.Result != null && task.Result.StatusCode == System.Net.HttpStatusCode.OK )
            {
                return Objects.v14.DomainAPI.FromJson ( task.Result.Content );
            }
            else
            {
                throw new Exceptions.APIConnectionException ( "API Error: " + ( task.Result == null ? "Result is NULL" : "Status code - " + task.Result.StatusCode ) );
            }


        }




    }
}
