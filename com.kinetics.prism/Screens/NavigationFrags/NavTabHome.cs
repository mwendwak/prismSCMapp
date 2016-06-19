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
                var btnClearDB = view.FindViewById<Button>(Resource.Id.clearDB);
                var btnSyncProducts = view.FindViewById<Button>(Resource.Id.syncProducts);
                var btnSyncCustomers = view.FindViewById<Button>(Resource.Id.syncCustomers);
                var btnInstDB = view.FindViewById<Button>(Resource.Id.dbCreate);
            /*PAGE ELEMENTS*/

            /*HANDLE VIEW EVENTS HERE*/
                btnInstDB.Click += delegate {
                    string dbInstMsg = "";
                    
                    DBCreateTables dbManager = new DBCreateTables(); //USE OPEN & CLOSE CMDS??
                    dbInstMsg =  dbManager.createTables();
              
                };
                btnClearDB.Click += delegate {
                    DBCreateTables dbUtility = new DBCreateTables();
                    dbUtility.clearTables();
                };
                btnSyncProducts.Click += delegate {
                    SyncProduct syncProducts = new SyncProduct();
                    ThreadPool.QueueUserWorkItem (o => syncProducts.SyncAllProducts ());
                    Activity.RunOnUiThread(() => Toast.MakeText(Activity, "ProdsUpdated", ToastLength.Long).Show());
                };
                btnSyncCustomers.Click += delegate {
                    SyncCustomer syncCustomers = new SyncCustomer();
                    ThreadPool.QueueUserWorkItem(o => syncCustomers.SyncAllCustomers());
                    Activity.RunOnUiThread(() => Toast.MakeText(Activity, "CustomersUpdated", ToastLength.Long).Show());
                };
            /*HANDLE VIEW EVENTS*/
            return view;
        }

    }
}