using Android.App;
using Android.OS;
using Android.Support.V7.App;


namespace com.kinetics.prism
{
    [Activity(ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, Theme = "@style/PrismTheme.Base")]
    public class BaseActivity :AppCompatActivity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState);
            base.OnCreate(savedInstanceState, persistentState);
        }     

    }
}