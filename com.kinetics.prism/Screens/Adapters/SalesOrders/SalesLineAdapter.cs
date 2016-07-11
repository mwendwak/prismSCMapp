using Android.App;
using Android.Views;
using Android.Widget;
using com.kinetics.prism.Models;
using System;
using System.Collections.Generic;
using Android.Util;
using com.kinetics.prism.Activitys.Sales;
using System.Collections.ObjectModel;

namespace com.kinetics.prism.Screens.Adapters
{
    class SalesLineAdapter : BaseAdapter<SalesLine>
    {
        public Activity context;
        public ObservableCollection<SalesLine> SalesLineRecs = new ObservableCollection<SalesLine>();
        public View view;

        public SalesLineAdapter(Activity cntxt, ObservableCollection<SalesLine> records) : base()
        {
            this.context = cntxt;
            this.SalesLineRecs = records;
        }

        public override long GetItemId(int position)
        {
            return SalesLineRecs[position].LineNo;
        }
        public override int Count
        {
            get
            {
                return SalesLineRecs.Count;
            }
        }
        public override SalesLine this[int position]
        {
            get
            {
                return SalesLineRecs[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var Record = SalesLineRecs[position];
            view = convertView; //reuses an existing view if it exists            
            if (view == null)
            {
                try
                {
                    view = context.LayoutInflater.Inflate(Resource.Layout.AdapterCreateSalesLine, null);
                    view.FindViewById<TextView>(Resource.Id.SOLineQty).Text = Record.Quantity.ToString ();
                    view.FindViewById<TextView>(Resource.Id.SOLineUnitPrice).Text = Record.UnitPrice.ToString ();
                    view.FindViewById<TextView>(Resource.Id.SOLineTotAmount).Text = Record.LineTotalAmt.ToString ();
                    ImageButton deleteRec = view.FindViewById<ImageButton>(Resource.Id.SOLineDelete);
                    deleteRec.Clickable = true;
                    deleteRec.Click += (sender, args) => DeleteOrderLine(position,parent);
                    }
                catch (Exception e)
                {
                    Log.Error("ERROR", e.Message);
                }
            }
            return view;
        }

        protected void DeleteOrderLine(int position, ViewGroup parent)
        {
            view = parent.GetChildAt(position);
            view.Animate()
                .SetDuration(300)
                .Alpha(0)
                .WithEndAction(new Java.Lang.Runnable(() => {                   
                    this.RemoveRecordItem(position);
                    view.Alpha = 1f;
                }));
        }

        public void AddRecordItem ()
        {
            this.NotifyDataSetChanged();
        }
        public void RemoveRecordItem(int recordPos)
        {
            string msg = ("Deleting: RecLineQty: " + SalesLineRecs[recordPos].Quantity.ToString () + " At Pos: " + recordPos.ToString());
            Log.Info("DELETE", msg);
            SalesLineRecs.RemoveAt(recordPos);
            SalesOrderCreate order = (SalesOrderCreate)this.context;
            order.refreshList(SalesLineRecs);
        }
        public void UpdateAdapter(ObservableCollection<SalesLine> newRecordSet, Activity currActivity)
        {
            this.SalesLineRecs = newRecordSet;
            currActivity.RunOnUiThread( () => this.NotifyDataSetChanged());
        }
    }
}