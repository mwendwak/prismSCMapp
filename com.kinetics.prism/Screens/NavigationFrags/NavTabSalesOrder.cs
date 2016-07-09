using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using com.kinetics.prism.Models;
using com.kinetics.prism.Screens.Adapters;
using System.Collections.Generic;
using com.refractored.fab;
using System;

namespace com.kinetics.prism
{
    class NavTabSalesOrder: Fragment, IScrollDirectorListener
    {

        List<SalesHeader> SalesHeaders = new List<SalesHeader>();

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            /*CAPTURE PAGE ELEMENTS*/
            base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.Menu_SalesHeaders, container, false);

            if (SalesHeaders == null || SalesHeaders.Count == 0) { loadSalesHeaders(); }

            ListView SalesHeaderListView = view.FindViewById<ListView>(Resource.Id.SalesHeaderListView);

            //PLUGIN THE FAB THINGIE
            FloatingActionButton fab = view.FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.AttachToListView(view,this);
            fab.Show();

            SalesHeaderListView.Adapter = new SalesHeaderHomeAdapter(Activity, SalesHeaders);
            SalesHeaderListView.ItemClick += ListItemClick;
            return view;
        }

        void ListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = SalesHeaders[e.Position];
            Toast.MakeText(Activity, "Clicked: " + t.DocNo, ToastLength.Short);
        }

        public void loadSalesHeaders()
        {
            SalesHeaders = SalesHeader.getSalesHeaders(0); //returns sales orders
        }

        public void OnScrollDown()
        {
            Console.WriteLine("ListViewFragment: OnScrollDown");
        }

        public void OnScrollUp()
        {
            Console.WriteLine("ListViewFragment: OnScrollUp");
        }
        public void OnScrollStateChanged(AbsListView view, ScrollState scrollState)
        {
            Console.WriteLine("ListViewFragment: OnScrollChanged");
        }
    }
}