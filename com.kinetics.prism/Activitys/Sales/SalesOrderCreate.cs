
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using com.kinetics.prism.Models;
using com.kinetics.prism.Screens.Adapters;
using System.Collections.Generic;
using System;
using Java.Lang;
using System.Collections.ObjectModel;

namespace com.kinetics.prism.Activitys.Sales
{
    [Activity(Label = "Create Sales Order",MainLauncher = true)]
    public class SalesOrderCreate :Activity
    {
        ObservableCollection<SalesLine> SalesLines = new ObservableCollection<SalesLine>();
        public ListView SalesLineView;
        SalesLineAdapter thisAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ActionBar.SetIcon(Android.Resource.Color.Transparent);
            SetContentView(Resource.Layout.SalesOrderCreate);

            //if (SalesLines ==null || SalesLines.Count ==0) { loadSalesLines();  }
            //if (SalesLines == null || SalesLines.Count == 0) { loadDummySalesLines(); }
            SalesLineView  = FindViewById<ListView>(Resource.Id.SalesLineView);
            SalesLineView.Adapter = new SalesLineAdapter(this, SalesLines);
            thisAdapter = (SalesLineAdapter)SalesLineView.Adapter;
            Button addItemsImg = FindViewById<Button>(Resource.Id.AddSalesLine);
            addItemsImg.Clickable = true;
            addItemsImg.Click += AddItemClick;
        }

        protected void AddItemClick(object sender, EventArgs e)
        {
            SalesLines.Clear();
            loadDummySalesLines();
            thisAdapter.UpdateAdapter(SalesLines, this);
            this.SalesLineView.Adapter = thisAdapter;
        }

        public void refreshList(ObservableCollection<SalesLine> newList)
        {
            //SalesLines.Clear();
            SalesLines = newList;
            thisAdapter.UpdateAdapter(SalesLines, this);
            this.SalesLineView.Adapter = thisAdapter;
        }

        private void loadSalesLines()
        {
            
        }

        private void loadDummySalesLines()
        {            
            SalesLines =  new ObservableCollection<SalesLine>(SalesLine.genSalesLines());
        }


        protected override void OnSaveInstanceState(Bundle outState)
        {
           
        }
    }
}