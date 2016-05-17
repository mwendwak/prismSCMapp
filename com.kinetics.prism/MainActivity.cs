using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace com.kinetics.prism
{
    [Activity(Label = "Home", Theme = "@style/PrismTheme.Base")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            //set the action bar tabs          
            //Home Tab
            NavTabHome homeTab = new NavTabHome();
            AddTab(GetString(Resource.String.menu_1), Resource.Drawable.ic_launcher, homeTab);
            //Orders Tab
            NavTabOrder orderTab = new NavTabOrder();
            AddTab(GetString(Resource.String.menu_2), Resource.Drawable.ic_launcher, orderTab);
            //Customers Tab
            NavTabCustomer customerTab = new NavTabCustomer();
            AddTab(GetString(Resource.String.menu_3), Resource.Drawable.ic_launcher, customerTab);
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
            tab.SetText((tabText).ToUpper ());
            //tab.SetIcon(Resource.Drawable.ic_tab_white); //Lets not show icons for now

            // must set event handler before adding tab
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };
            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e) {
                e.FragmentTransaction.Remove(view);
            };

            this.ActionBar.AddTab(tab);
        }

    }
}


