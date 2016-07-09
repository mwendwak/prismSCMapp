using Android.Support.V7.App;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace com.kinetics.prism
{
    [Activity(Theme = "@android:style/Theme.Holo.Light", MainLauncher = true)]
    public class UserLogin : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //page variables
            Button registerBtn;
            Button userLoginBtn;
            //page variables
            base.OnCreate(savedInstanceState);

            //set page display elements
            SetContentView(Resource.Layout.User_Login);
            userLoginBtn = FindViewById<Button>(Resource.Id.btn_login);
            registerBtn = FindViewById<Button>(Resource.Id.btn_register);
            //page elements

            //register page actions
            registerBtn.Click += (sender, args) =>
            {
                StartActivity(new Intent(Application.Context, typeof(UserRegistration)));
            };
            userLoginBtn.Click += (sender, args) =>
            {
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            };
            //page actionsS


        }
       
    }
}