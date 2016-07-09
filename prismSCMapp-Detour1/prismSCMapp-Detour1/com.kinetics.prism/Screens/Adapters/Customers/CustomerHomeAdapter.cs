using Android.App;
using Android.Views;
using Android.Widget;
using com.kinetics.prism.Models;
using System;
using System.Collections.Generic;
using Android.Util;

namespace com.kinetics.prism.Screens.Adapters
{
    class CustomerHomeAdapter : BaseAdapter<Customer>
    {
        public Activity context;
        public List<Customer> CustomerRecs = new List<Customer>();

        public CustomerHomeAdapter(Activity cntxt, List<Customer> records) : base()
        {
            this.context = cntxt;
            this.CustomerRecs = records;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override int Count
        {
            get
            {
                return CustomerRecs.Count;
            }
        }
        public override Customer this[int position]
        {
            get
            {
                return CustomerRecs[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var Record = CustomerRecs[position];
            View view = convertView; //reuses an existing view if it exists
            if (view == null)
            {
                try
                {
                    view = context.LayoutInflater.Inflate(Resource.Layout.AdapterCustomersHomeView, null);
                    view.FindViewById<TextView>(Resource.Id.CustomerName).Text = (Record.CustomerNames);
                    view.FindViewById<TextView>(Resource.Id.CustomerID).Text = Record.CustomerID;
                    view.FindViewById<TextView>(Resource.Id.CustomerBalance).Text = "Bal. KES " + Record.getCustomerBalance().ToString();
                    view.FindViewById<TextView>(Resource.Id.CustomerDetails).Text = Record.Address;
                }catch (Exception e)
                {
                    Log.Error("ERROR", e.Message);
                }
            }
            return view;
        }


    }
}