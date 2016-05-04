using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using System.Threading.Tasks;
using Android.Support.V7.App;

namespace com.kinetics.prism
{
    [Activity(Theme = "@style/PrismTheme.Splash",MainLauncher = true, NoHistory = true)]
    public class SplashSC : AppCompatActivity
    {
        static readonly string TAG = "X: " + typeof(SplashSC).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            Log.Debug(TAG, "Splash Activity.OnCreate");
        }
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => {
                Log.Debug(TAG, "Performing some staryup activities");
                Task.Delay(5000);
                Log.Debug(TAG, "Running background processes");
            });
            startupWork.ContinueWith( t => {
                Log.Debug(TAG, "Work is finished");
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            }, TaskScheduler.FromCurrentSynchronizationContext());
            startupWork.Start();
        }
    }
}