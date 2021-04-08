using System.IO;
using System.IO.Compression;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.ResponseCompression;

namespace NetflixGraphQL.Helpers
{
    public class CustomCompressionProvider : ICompressionProvider
    {
        public string EncodingName => "br";
        public bool SupportsFlush => true;
        public Stream CreateStream(Stream outputStream)
        {
            return new BrotliStream(outputStream,
             CompressionLevel.Optimal, false);
        }
    }

}
