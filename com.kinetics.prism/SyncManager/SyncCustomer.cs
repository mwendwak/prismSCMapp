using Android.Util;
using com.kinetics.prism.Models;
using com.kinetics.prism.Models.JsonObjs;
using Java.Lang;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace com.kinetics.prism.SyncManager
{
    public class SyncCustomer : SyncBase
    {
        static string svrUrl;
        JObject allCustomers;  //CONTAINS ALL CustomerS FROM SERVER

        public SyncCustomer()
        {

        }
        public void SyncAllCustomers()
        {
            InitializeCustomerClient();
            GetSvrCustomers();
            //UpdateAppCustomers(); //fix this later...separate getting response and updating db
        }
        public void InitializeCustomerClient()
        {
            svrUrl = "http://" + SYNCIPADDRESS + "/NAVSCMIntegrator/Service/NAVRouter.svc/Customers/Customers";  //GET THIS VALUE FROM A RESOURCE FILE
        }

        public async void GetSvrCustomers()
        {
            string tagGetProds = "Customers";
            InitializeCustomerClient();
            allCustomers = await getServerResponse(svrUrl, tagGetProds);
            if (allCustomers != null) { UpdateAppCustomers(allCustomers); } else {Log.Error("WEBSERVICEFAIL", "Null Return"); };
        }

        public void UpdateAppCustomers (JObject jRootObject)
        {
            bool updateCompleted = false;     //handle status return
            try
            {
                Customer Customer = new Customer();
                JObject JsonCustomerSet = JObject.Parse(jRootObject.ToString ());
                var results = JsonCustomerSet["NavCustomersResult"];
                //Log.Info("CUSTOMER COUNT", results.);
                foreach (JObject c in results.Children())
                {
                    JsonCustomer jsonCustomer = new JsonCustomer();
                    jsonCustomer = JsonConvert.DeserializeObject<JsonCustomer>(c.ToString());
                    Customer.insertCustomer(Customer.CreateCustFromJson(jsonCustomer));
                    Log.Info("CUSTOMER", "-ID:" + jsonCustomer.CustomerID);
                 
                }
                Log.Info("Download Complete", "Customers");
            }
            catch (Exception e)
            {
                Log.Error("JSONCONVERSIONFAIL: ", e.Message);
            }
            updateCompleted = true;            //handle status return
            //return updateCompleted;            //handle status return
        }
    }
}