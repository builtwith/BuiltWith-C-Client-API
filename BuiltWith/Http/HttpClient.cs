using System;
using System.Collections.Generic;
using System.Text;

namespace BuiltWith.Http
{
    public abstract class HttpClient
    {
        public abstract Response MakeRequest ( Request request );

        public abstract System.Threading.Tasks.Task<Response> MakeRequestAsync ( Request request );
    }
}
