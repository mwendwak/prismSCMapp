using System.Threading.Tasks;
using System.Net;
using System;
using System.IO;
using Android.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using com.kinetics.prism.Models.JsonObjs;

namespace com.kinetics.prism.SyncManager
{
    public class SyncBase
    {
        public SyncBase ()
        {

        }
        public async Task<JObject> getServerResponse(string url, string tag)    //MOVE THIS WHOLE CODE SECTION TO A GENERIC FUNCTION FOR ABSTRACTION
        {
            string tagHeader = "Getting Server Responses: ";

            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
                request.ContentType = "application/json";
                request.Method = "GET";              
                //Send the request to the server and await for the response;
                using (WebResponse response = await request.GetResponseAsync())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(stream))
                            using (JsonTextReader jsonStreamReader = new JsonTextReader(sr))
                            {
                                JObject jsonDoc = await Task.Run(() => JObject.Load(jsonStreamReader));
                                Log.Info(tagHeader, jsonDoc.ToString());
                                return jsonDoc;
                            }
                    }
                }
            }catch (Exception e)
            {
                JObject jsonFailText = new JObject();
                jsonFailText.Add("ErrMessage",("HTTP WEBSERVICE FAIL: " + e.Message));
                Log.Error("WEBSERVICEFAIL", e.Message);
                return jsonFailText;
            }
        }
    }
}