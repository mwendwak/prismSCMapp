using Android.App;
using Android.Views;
using Android.Widget;
using com.kinetics.prism.Models;
using System;
using System.Collections.Generic;
using Android.Util;

namespace com.kinetics.prism.Screens.Adapters
{
    class ProductHomeAdapter : BaseAdapter<Product>
    {
        public Activity context;
        public List<Product> ProductRecs = new List<Product>();

        public ProductHomeAdapter(Activity cntxt, List<Product> records) : base()
        {
            this.context = cntxt;
            this.ProductRecs = records;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override int Count
        {
            get
            {
                return ProductRecs.Count;
            }
        }
        public override Product this[int position]
        {
            get
            {
                return ProductRecs[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var Record = ProductRecs[position];
            View view = convertView; //reuses an existing view if it exists
            if (view == null)
            {
                try
                {
                    view = context.LayoutInflater.Inflate(Resource.Layout.AdapterProductsHomeView, null);
                    view.FindViewById<TextView>(Resource.Id.ProductName).Text = (Record.Name);
                    view.FindViewById<TextView>(Resource.Id.ProductID).Text = Record.ItemCode;
                    view.FindViewById<TextView>(Resource.Id.ProductQty).Text = Record.getProductQty().ToString() + " Cases Avail.";
                    view.FindViewById<TextView>(Resource.Id.ProductPrice).Text = "KES. " + Record.UnitPrice.ToString();
                }catch (Exception e)
                {
                    Log.Error("ERROR", e.Message);
                }
            }
            return view;
        }


    }
}