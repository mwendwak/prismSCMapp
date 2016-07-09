using Android;
using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace com.kinetics.prism
{
    [Activity(MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            
            // Set our view from the "main" layout resource
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
           
            //set the action bar tabs          
                //1.Home Tab
                NavTabHome homeTab = new NavTabHome();
                AddTab(GetString(Resource.String.menu_1), Resource.Drawable.ic_launcher, homeTab);
                //2.Products Tab
                NavTabProduct productTab = new NavTabProduct();
                AddTab(GetString(Resource.String.menu_2), Resource.Drawable.ic_launcher, productTab);
                //3.Customers Tab
                NavTabCustomer customerTab = new NavTabCustomer();
                AddTab(GetString(Resource.String.menu_3), Resource.Drawable.ic_launcher, customerTab);
                //4.Orders Tab
                NavTabSalesOrder orderTab = new NavTabSalesOrder();
                AddTab(GetString(Resource.String.menu_4), Resource.Drawable.ic_launcher, orderTab);
                //5.Cash Tab

                //6.Cash Tab
                NavTabSync syncTab  = new NavTabSync();
                AddTab(GetString(Resource.String.menu_6), Resource.Drawable.ic_launcher, syncTab);
            /*ADD DISPLAY FOR THIS TABS*/
            //action bar tabs
            if (bundle != null)
                this.ActionBar.SelectTab(this.ActionBar.GetTabAt(bundle.GetInt("tab")));

        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("tab", this.ActionBar.SelectedNavigationIndex);

            base.OnSaveInstanceState(outState);
        }

        void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText((tabText).ToUpper());
            //tab.SetIcon(Resource.Drawable.ic_tab_white); //Lets not show icons for now

            // must set event handler before adding tab
            tab.TabSelected += delegate (object sender, Android.App.ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };
            tab.TabUnselected += delegate (object sender, Android.App.ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(view);
            };
            this.ActionBar.AddTab(tab);
        }

    }
}


