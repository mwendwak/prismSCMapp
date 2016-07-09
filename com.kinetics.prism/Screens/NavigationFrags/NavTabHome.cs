using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using com.kinetics.prism.DBstorage;
using com.kinetics.prism.Models;
using com.kinetics.prism.SyncManager;
using MikePhil.Charting.Charts;
using MikePhil.Charting.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace com.kinetics.prism
{
    class NavTabHome: Fragment
    {
        //LIST ALL DASH CHARTS HERE
        LineChart SalesPerPeriodchart;
        //DASH CHARTS

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            /*CAPTURE PAGE ELEMENTS*/
                var view = inflater.Inflate(Resource.Layout.Menu_Home, container, false);
            //DEFINES ALL DASH CHARTS HERE
                SalesPerPeriodchart = view.FindViewById<LineChart>(Resource.Id.saleschart);
            //DASH CHARTS
            DrawDashBoards ();
            /*PAGE ELEMENTS*/
            return view;
        }

        public void DrawDashBoards()
        {
            DrawSalesPerPeriodChart();
        }

        public void DrawSalesPerPeriodChart()
        {
            SalesPerPeriodchart.SetBackgroundColor(new Android.Graphics.Color(Resource.Color.prismWhite));
            SalesPerPeriodchart.SetTouchEnabled(true);
            SalesPerPeriodchart.SetScaleEnabled(true);
            
        }
    }
}