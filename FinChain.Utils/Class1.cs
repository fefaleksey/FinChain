namespace FinChain.Utils
{
    public class UrlBuilder
    {
        public UrlBuilder(string baseUrl)
        {
            new UrlBuilder("localhost:500/api")
                .WithPath("transactions")
                .WithPath("1"); 
        }

        public UrlBuilder WithPath(string part)
        {
            //path = string.Join("/", );
            return this;
        }

        private string _path;
    }
}