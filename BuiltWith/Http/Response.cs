using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BuiltWith.Http
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; }

        public string Content { get; }

        public Response ( HttpStatusCode statusCode , string content )
        {
            StatusCode = statusCode;
            Content = content;
        }
    }
}
