using Android.Util;
using com.kinetics.prism.Models;
using com.kinetics.prism.Models.JsonObjs;
using Java.Lang;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace com.kinetics.prism.SyncManager
{
    public class SyncProduct : SyncBase
    {
        static string svrUrl;
        JObject allProducts;  //CONTAINS ALL PRODUCTS FROM SERVER

        public SyncProduct()
        {

        }
        public void SyncAllProducts()
        {
            InitializeProductClient();
            GetSvrProducts();
            //UpdateAppProducts(); //fix this later...separate getting response and updating db
        }
        public void InitializeProductClient()
        {
            svrUrl = "http://192.168.0.14:80/NAVSCMIntegrator/Service/NAVRouter.svc/Products";  //GET THIS VALUE FROM A RESOURCE FILE
        }

        public async void GetSvrProducts()
        {
            string tagGetProds = "Products";
            InitializeProductClient();
            allProducts = await getServerResponse(svrUrl, tagGetProds);
            if (allProducts != null) { UpdateAppProducts(allProducts); } else {Log.Error("WEBSERVICEFAIL", "Null Return"); };
        }

        public void UpdateAppProducts (JObject jRootObject)
        {
            bool updateCompleted = false;     //handle status return
            try
            {
                Product product = new Product();
                JObject JsonproductSet = JObject.Parse(jRootObject.ToString ());
                var results = JsonproductSet["getProductsAllResult"];
                //Log.Info("PROD COUNT", results.);
                foreach (JObject c in results.Children())
                {
                    JsonProduct jsonProduct = new JsonProduct();
                    jsonProduct = JsonConvert.DeserializeObject<JsonProduct>(c.ToString());
                    product.insertProduct(product.CreateProdFromJson(jsonProduct));
                    Log.Info("ITEM", "-ID:" + jsonProduct.ProductID);
                 
                }
                Log.Info("Finito", "Produits");
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