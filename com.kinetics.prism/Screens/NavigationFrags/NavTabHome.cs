using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using com.kinetics.prism.DBstorage;
using com.kinetics.prism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            /*HANDLE VIEW EVENTS*/
            return view;
        }

    }
}