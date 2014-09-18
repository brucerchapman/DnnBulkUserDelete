using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;

namespace Dnn.BulkUserDelete.Console
{
    internal enum ContentType
    {
        JSON, XML, Text
    }
    internal class DnnRequest
    {
        internal static string GetRequest(string url, string username, string password, ContentType contentType
                , out HttpStatusCode statusCode, out string errorMsg)
        {
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.Credentials = new NetworkCredential(username, password);
            wr.Accept = TranslateContentType(contentType);
            CookieContainer cookies = null;
            string responseString = DoRequest(wr, out statusCode, out errorMsg, ref cookies);
            return responseString;
        }
        internal static string GetRequest(string url, out HttpStatusCode statusCode, ContentType contentType, out string errorMsg, ref CookieContainer cookies)
        {
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            if (cookies != null)
                wr.CookieContainer = cookies;
            //wr.Credentials = new NetworkCredential(username, password);
            wr.Accept = TranslateContentType(contentType);
            string responseString = DoRequest(wr, out statusCode, out errorMsg, ref cookies);
            return responseString;
        }
        internal static string GetRequest(string url, string username, string password, ContentType contentType, out HttpStatusCode statusCode, out string errorMsg, ref CookieContainer cookies)
        {
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            if (cookies != null)
                wr.CookieContainer = cookies;
            wr.Credentials = new NetworkCredential(username, password);
            wr.Accept = TranslateContentType(contentType);
            string responseString = DoRequest(wr, out statusCode, out errorMsg, ref cookies);
            return responseString;
        }
        internal static string PostRequest(string url, string username, string password, string body, ContentType contentType, out HttpStatusCode statusCode, out string errorMsg, ref CookieContainer cookies)
        {
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.Credentials = new NetworkCredential(username, password);
            wr.Method = "POST";
            wr.ContentType = TranslateContentType(contentType);
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(body);
            wr.ContentLength = byteArray.Length;
            using (System.IO.Stream dataStream = wr.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            string responseString = DoRequest(wr, out statusCode, out errorMsg, ref cookies);
            return responseString;
        }
        private static string TranslateContentType(ContentType contentType)
        {
            switch (contentType)
            {
                case ContentType.JSON:
                    return "application/json";
                case ContentType.XML:
                    return "application/xml";
                case ContentType.Text:
                    return "application/text";
                default:
                    return "";
            }
        }
        private static string DoRequest(HttpWebRequest wr, out HttpStatusCode statusCode, out string errorMsg, ref CookieContainer cookies)
        {
            string responseString = ""; errorMsg = null; statusCode = HttpStatusCode.NoContent;
            try
            {
                using (WebResponse response = wr.GetResponse())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
                    {
                        responseString = sr.ReadToEnd();
                    }
                    statusCode = ((HttpWebResponse)response).StatusCode;
                }
            }
            catch (System.Net.WebException ex)
            {
                HttpWebResponse errResponse = (HttpWebResponse)ex.Response;
                errorMsg = ex.Message;
                if (errResponse != null)
                {
                    statusCode = errResponse.StatusCode;
                    //read the response stream for the error message
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(errResponse.GetResponseStream()))
                    {
                        responseString = sr.ReadToEnd();
                    }
                }
            }
            return responseString;
        }


        internal static string GetUrl(string portalAlias, string modulePath, string controllerName, string callName, bool secure)
        {

            string scheme = "";
            if (secure)
                scheme = Uri.UriSchemeHttps + Uri.SchemeDelimiter;
            else
                scheme = Uri.UriSchemeHttp + Uri.SchemeDelimiter;

            string url = string.Format("{0}{1}/DesktopModules/{2}/API/{3}/{4}", scheme, portalAlias, modulePath, controllerName, callName);

            return url;

        }
    }
}
