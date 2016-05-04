using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Support.V7.App;


namespace com.kinetics.prism
{
    [Activity(Theme = "@style/PrismTheme", Label = "Landing Page")]
    public class MainActivity : BaseActivity
    {
        static readonly string TAG = "X: " + typeof(MainActivity).Name;
        int _clickCount;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += (sender, args) => {
                string message = string.Format("You clicked {0} times.", ++_clickCount);
                button.Text = message;
                Log.Debug(TAG, message);
            };
            Log.Debug(TAG, "Main Activity is Loaded");
        }
    }
}

