using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Support.V7.App;


namespace com.kinetics.prism
{
    [Activity(Theme = "@style/PrismTheme", Label = "User Registration")]
    public class UserRegistration : BaseActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.User_Register);
        }
    }
}

