using System;
using System.Collections.Generic;
using System.Text;

namespace BuiltWith.Exceptions
{
    public class APIConnectionException : BuiltWithException
    {
        public APIConnectionException ( string message ) : base ( message ) { }

        public APIConnectionException ( string message , Exception exception ) : base ( message , exception ) { }
    }
}
