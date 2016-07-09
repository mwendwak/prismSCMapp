using Android.App;
using Android.Views;
using Android.Widget;
using com.kinetics.prism.Models;
using System;
using System.Collections.Generic;
using Android.Util;

namespace com.kinetics.prism.Screens.Adapters
{
    class SalesHeaderHomeAdapter : BaseAdapter<SalesHeader>
    {
        public Activity context;
        public List<SalesHeader> SalesHeaderRecs = new List<SalesHeader>();

        public SalesHeaderHomeAdapter(Activity cntxt, List<SalesHeader> records) : base()
        {
            this.context = cntxt;
            this.SalesHeaderRecs = records;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override int Count
        {
            get
            {
                return SalesHeaderRecs.Count;
            }
        }
        public override SalesHeader this[int position]
        {
            get
            {
                return SalesHeaderRecs[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var Record = SalesHeaderRecs[position];
            View view = convertView; //reuses an existing view if it exists
            if (view == null)
            {
                try
                {
                    view = context.LayoutInflater.Inflate(Resource.Layout.AdapterSalesHeadersHomeView, null);
                    view.FindViewById<TextView>(Resource.Id.SalesHeaderName).Text = Customer.getCustomerNames(Record.Customer);
                    view.FindViewById<TextView>(Resource.Id.SalesHeaderID).Text = Record.DocNo;
                    view.FindViewById<TextView>(Resource.Id.SalesHeaderDate).Text = Record.OrderDate.ToString ();
                    view.FindViewById<TextView>(Resource.Id.SalesHeaderAmount).Text = "KES. " + Record.OrderAmt.ToString();
                }catch (Exception e)
                {
                    Log.Error("ERROR", e.Message);
                }
            }
            return view;
        }


    }
}