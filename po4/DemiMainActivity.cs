using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Support.V7.App;
using Android;

namespace po4
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppCompat.Light.NoActionBar", MainLauncher = true)]
    public class DemiMainActivity : AppCompatActivity
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        DemiProductListAdapter mAdapter;
        DemiProductList mProductList;
        Button button;

        List<string> ListOfProducts = new List<string>();


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            mProductList = new DemiProductList();

            SetContentView(Resource.Layout.Demiactivity_main);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);

            if (this.Intent.Extras != null)
            {
                var productlist = Intent.Extras.GetStringArray("lijst");
                ListOfProducts = productlist.ToList();
            }

            ListOfProducts.Add("8");

            button = FindViewById<Button>(Resource.Id.button1);

     
            //----------------------------------------------------------------------------------------
            // Layout Managing Set-up

            mLayoutManager = new GridLayoutManager(this, 2, GridLayoutManager.Vertical, false);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            //----------------------------------------------------------------------------------------
            // Adapter Set-up
            mAdapter = new DemiProductListAdapter(mProductList);
            mAdapter.ItemClick += OnItemClick;
            button.Click += Button_Click;;
            mRecyclerView.SetAdapter(mAdapter);

        }

        void OnItemClick(object sender, int position)
        {
            //var intent = new Intent(this, typeof(DemiSecondActivity));

            //Bundle b = new Bundle();
            //b.PutInt("CategoryID", (int)mProductList[position].category);
            //intent.PutExtras(b);

            //Toast.MakeText(this, "This is in category " + mProductList[position].category, ToastLength.Short).Show();

            //StartActivity(intent);

            Toast.MakeText(this, "List has as first product " + ListOfProducts[0], ToastLength.Short).Show();
        }



        void Button_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(FabioActivity));
            StartActivity(intent);
        }

    }
}
