using System;
using System.Collections.Generic;
using System.Text;

namespace BuiltWith.Client
{
    public interface IBuiltWithRestClient
    {
        string ApiKey { get; }

        Http.HttpClient HttpClient { get; }

        Http.Response Request ( Http.Request request );
    }
}
