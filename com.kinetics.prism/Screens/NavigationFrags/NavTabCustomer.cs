using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using com.kinetics.prism.Models;
using com.kinetics.prism.Screens.Adapters;
using System.Collections.Generic;
using System.Linq;

namespace com.kinetics.prism
{
    class NavTabCustomer: Fragment
    {
        List<Customer> Customers = new List<Customer>();

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            /*CAPTURE PAGE ELEMENTS*/
            base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.Menu_Customers, container, false);

            if (Customers == null || Customers.Count == 0) { loadCustomers(); }

            ListView CustomerListView = view.FindViewById<ListView>(Resource.Id.CustomerListView);
            CustomerListView.Adapter = new CustomerHomeAdapter(Activity, Customers);
            CustomerListView.ItemClick += ListItemClick;
            return view;
        }

        void ListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = Customers[e.Position];
            Toast.MakeText(Activity, "Clicked: " + t.CustomerID, ToastLength.Short);
        }

        public void loadCustomers()
        {
            Customers = Customer.getCustomers().ToList();
        }

    }
}