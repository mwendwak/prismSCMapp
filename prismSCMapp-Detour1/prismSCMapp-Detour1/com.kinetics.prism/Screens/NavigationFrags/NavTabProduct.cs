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
    class NavTabProduct: Fragment
    {
        List<Product> products = new List<Product> ();

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            /*CAPTURE PAGE ELEMENTS*/
            base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.Menu_Products, container, false);

            if (products == null || products.Count == 0) { loadProducts(); }
            
            ListView ProductListView = view.FindViewById<ListView>(Resource.Id.ProductListView);            
            ProductListView.Adapter = new ProductHomeAdapter(Activity, products);
            ProductListView.ItemClick += ListItemClick;
            return view;
        }

        void ListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = products[e.Position];
            Toast.MakeText(Activity, "Clicked: "+t.ItemCode, ToastLength.Short);
        }

        public void loadProducts ()
        {            
            products = Product.getProducts().ToList ();
        }

    }
}