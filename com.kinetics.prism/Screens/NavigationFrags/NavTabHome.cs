using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using com.kinetics.prism.DBstorage;
using com.kinetics.prism.Models;
using com.kinetics.prism.SyncManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace com.kinetics.prism
{
    class NavTabHome: Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            /*CAPTURE PAGE ELEMENTS*/
                var view = inflater.Inflate(Resource.Layout.Menu_Home, container, false);
                var btnGenProducts = view.FindViewById<Button>(Resource.Id.genProducts);
                var btnSyncProducts = view.FindViewById<Button>(Resource.Id.syncProducts);
                var btnInstDB = view.FindViewById<Button>(Resource.Id.dbCreate);
            /*PAGE ELEMENTS*/

            /*HANDLE VIEW EVENTS HERE*/
                btnInstDB.Click += delegate {
                    string dbInstMsg = "";
                    
                    DBCreateTables dbManager = new DBCreateTables(); //USE OPEN & CLOSE CMDS??
                    dbInstMsg =  dbManager.createTables();
              
                };
                btnGenProducts.Click += delegate {                   
                    Product tempProd = new Product();
                    tempProd.updateItemDetails(tempProd);  //USE OPEN & CLOSE CMDS ??
                    tempProd.insertProduct(tempProd);  //USE OPEN & CLOSE CMDS ??
                };
                btnSyncProducts.Click += delegate {
                    SyncProduct syncProducts = new SyncProduct();
                    ThreadPool.QueueUserWorkItem (o => syncProducts.SyncAllProducts ());
                    Activity.RunOnUiThread(() => Toast.MakeText(Activity, "ProdsUpdated", ToastLength.Long).Show());
                };
            /*HANDLE VIEW EVENTS*/
            return view;
        }

    }
}