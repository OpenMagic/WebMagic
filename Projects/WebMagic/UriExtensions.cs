using System;

namespace WebMagic
{
    public static class UriExtensions
    {
        public static Uri Combine(this Uri uri, string url)
        {
            return new Uri(uri, url);
        }
    }
}
