using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuiltWithTest
{
    [TestClass]
    public class DomainAPITest
    {






        public const string APIKEY = "ENTER YOUR API KEY HERE FOUND AT https://api.builtwith.com";
        




        [TestMethod]
        [ExpectedException ( typeof ( BuiltWith.Exceptions.BuiltWithException ) )]
        public void NoAPIKey ( )
        {
            BuiltWith.BuiltWithClient.GetDomain ( "builtwith.com" );
        }


        [ TestMethod]
        public void DomainAPISingle ( )
        {
            BuiltWith.BuiltWithClient.Init ( APIKEY );
            BuiltWith.Objects.v14.DomainAPI domain = BuiltWith.BuiltWithClient.GetDomain ( "builtwith.com" );
            Assert.IsTrue ( domain != null && domain.Results != null && domain.Results.Length == 1 && domain.Results [ 0 ].Result.IsDb.Equals("True") );
        }



        [TestMethod]
        
        public void DomainAPIMulti ( )
        {
            BuiltWith.BuiltWithClient.Init ( APIKEY );
            BuiltWith.Objects.v14.DomainAPI domain = BuiltWith.BuiltWithClient.GetDomain ( "builtwith.com","overstock.com" );
            Assert.IsTrue ( domain != null && domain.Results != null && domain.Results.Length ==2 && domain.Results [ 0 ].Result.IsDb.Equals ( "True" ) && domain.Results [ 1 ].Result.IsDb.Equals ( "True" ) );
        }
    }
}
