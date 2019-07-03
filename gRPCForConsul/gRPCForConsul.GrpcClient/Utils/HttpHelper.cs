using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace gRPCForConsul.GrpcClient.Utils
{
    public class HttpHelper
    {
        public static string HttpGet(string url,Dictionary<string,string> headers = null,int timeout = 0)
        {
            using (var client = new HttpClient())
            {
                if (headers != null && headers.Count > 0)
                {
                    foreach (KeyValuePair<string,string> header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key,header.Value);
                    }
                }

                if (timeout > 0)
                {
                    client.Timeout = new TimeSpan(0,0,timeout);
                }

                var resultBytes = client.GetByteArrayAsync(url).Result;
                return Encoding.UTF8.GetString(resultBytes);
            }
        }


        public static async Task<string> HttpGetAsync(string url, Dictionary<string, string> headers = null, int timeout = 0)
        {
            using (var client = new HttpClient())
            {
                if (headers != null && headers.Count > 0)
                {
                    foreach (KeyValuePair<string, string> header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                if (timeout > 0)
                {
                    client.Timeout = new TimeSpan(0, 0, timeout);
                }

                var resultBytes = await client.GetByteArrayAsync(url);
                return Encoding.UTF8.GetString(resultBytes);
            }
        }

        public static string HttpPost(string url,string postData,Dictionary<string,string> headers = null,string contentType = null,int timeout = 0,Encoding encoding = null)
        {
            using (var client = new HttpClient())
            {
                if (headers != null && headers.Count > 0)
                {
                    foreach (KeyValuePair<string, string> header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                if (timeout > 0)
                {
                    client.Timeout = new TimeSpan(0, 0, timeout);
                }

                using (var content = new StringContent(postData ?? "",encoding ?? Encoding.UTF8))
                {
                    if (contentType != null)
                    {
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                    }

                    using (var responseMessage = client.PostAsync(url,content).Result)
                    {
                        var resultBytes = responseMessage.Content.ReadAsByteArrayAsync().Result;
                        return Encoding.UTF8.GetString(resultBytes);
                    }
                }
            }
        }

        public static async Task<string> HttpPostAsync(string url, string postData, Dictionary<string, string> headers = null, string contentType = null, int timeout = 0, Encoding encoding = null)
        {
            using (var client = new HttpClient())
            {
                if (headers != null && headers.Count > 0)
                {
                    foreach (KeyValuePair<string, string> header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                if (timeout > 0)
                {
                    client.Timeout = new TimeSpan(0, 0, timeout);
                }

                using (var content = new StringContent(postData ?? "", encoding ?? Encoding.UTF8))
                {
                    if (contentType != null)
                    {
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                    }

                    using (var responseMessage = await client.PostAsync(url, content))
                    {
                        var resultBytes = await responseMessage.Content.ReadAsByteArrayAsync();
                        return Encoding.UTF8.GetString(resultBytes);
                    }
                }
            }
        }
    }
}
