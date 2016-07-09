using Android.App;
using Android.Database;
using Android.Views;
using Android.Widget;
using com.kinetics.prism.Models;
using System;
using System.Collections.Generic;

namespace com.kinetics.prism.Screens.Adapters
{
    public class PriscmAdapter : BaseAdapter<BaseModel>
    {
        //ARE THESE ACCESS MODIFIERS ON FLEEK???

        public List<BaseModel> recs;
        public Activity context;
        public string viewerName;

        public PriscmAdapter(Activity cntxt, List<BaseModel> records) : base()
        {
            this.context = cntxt;
            this.recs = records;
        }

        public PriscmAdapter()
        {

        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override BaseModel this[int position]
        {
            get
            {
                return recs[position];
            }
        }
        public override int Count
        {
            get
            {
                return recs.Count;
            }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var Record = recs[position];
            View view = convertView; //reuses an existing view if it exists
            if (view == null)
            {
                view = context.LayoutInflater.Inflate((int) typeof(Resource.Layout).GetField(viewerName).GetValue(null) , null);           
            }
            return view;
        }


    }
}