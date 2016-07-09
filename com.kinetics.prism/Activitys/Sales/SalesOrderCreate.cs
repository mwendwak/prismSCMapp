
using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace com.kinetics.prism.Activitys.Sales
{
    [Activity(Label = "Create Sales Order")]
    public class SalesOrderCreate :Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ActionBar.SetIcon(Android.Resource.Color.Transparent);
            SetContentView(Resource.Layout.SalesOrderCreate);

        }
        protected override void OnSaveInstanceState(Bundle outState)
        {
           
        }
    }
}