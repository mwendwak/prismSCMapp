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
    class NavTabSync: Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.Menu_Syncs, container, false);
            /*CAPTURE PAGE ELEMENTS*/
                var btnClearDB = view.FindViewById<Button>(Resource.Id.clearDB);
                var btnSyncProducts = view.FindViewById<Button>(Resource.Id.syncProducts);
                var btnSyncCustomers = view.FindViewById<Button>(Resource.Id.syncCustomers);
                var btnInstDB = view.FindViewById<Button>(Resource.Id.dbCreate);
                var btngenOrders = view.FindViewById<Button>(Resource.Id.genOrders);
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
                btngenOrders.Click += delegate {
                    SalesHeader salesHeader = new SalesHeader();
                    List<SalesHeader> newSalesHeaders = new List<SalesHeader>();
                    for (int s =1; s<15; s++)
                    {
                        SalesHeader salesHeaderRec = new SalesHeader();
                        SalesHeader.genSalesHeaders(salesHeaderRec);
                        newSalesHeaders.Add(salesHeaderRec);
                        
                    }
                    salesHeader.insertSalesHeaderList(newSalesHeaders);
                };
            /*HANDLE VIEW EVENTS*/
            return view;
        }

    }
}