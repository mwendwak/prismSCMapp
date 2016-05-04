using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;

namespace com.kinetics.prism
{
    [Activity(Label = "PrismActivity", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, Theme = "@style/PrismTheme")]
    public class BaseActivity :AppCompatActivity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState);
            base.OnCreate(savedInstanceState, persistentState);

            // Create your application here
        }
    }
}