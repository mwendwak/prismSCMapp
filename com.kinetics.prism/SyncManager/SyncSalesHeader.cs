using Android.Util;
using com.kinetics.prism.Models;
using com.kinetics.prism.Models.JsonObjs;
using Java.Lang;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace com.kinetics.prism.SyncManager
{
    public class SyncSalesHeader : SyncBase
    {
        static string svrUrl;
        JObject allSalesHeaders;  

        public SyncSalesHeader()
        {

        }
        public void SyncAllSalesHeaders()
        {
            InitializeSalesHeaderClient();
            uploadSalesHeaders();
            //UpdateAppSalesHeaders(); //fix this later...separate getting response and updating db
        }
        public void InitializeSalesHeaderClient()
        {
            svrUrl = "http://"+ SYNCIPADDRESS+ "/NAVSCMIntegrator/Service/NAVRouter.svc/SalesHeaders/SalesHeaders";  //GET THIS VALUE FROM A RESOURCE FILE
        }

        public SalesHeader[] GetAppSalesHeaders(int DocType)
        {
            //get all local sales orders not yet synced
            SalesHeader[] pendingHeaders = new SalesHeader[] { };

            return pendingHeaders;
        }

        public void uploadSalesHeaders()
        {
            //CALL GetAppSalesHeaders to Retrieve all pending Sales Headers

        }
    }
}