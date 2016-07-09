using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace com.kinetics.prism
{
    class NavTabOrder: Fragment
    {

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.Menu_Sales, container, false);
            var demoText = view.FindViewById<TextView>(Resource.Id.demoText);
            
            return view;
        }

    }
}