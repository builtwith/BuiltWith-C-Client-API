using System;
using System.Collections.Generic;
using System.Text;

namespace BuiltWith.Exceptions
{
    public class BuiltWithException : Exception
    {

        public BuiltWithException ( string message ) : base ( message ) { }

        public BuiltWithException ( ) : base ( ) { }

        public BuiltWithException ( string message , Exception exception ) : base ( message , exception ) { }

    }
}
