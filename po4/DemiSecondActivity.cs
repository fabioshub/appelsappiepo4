using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Support.V7.App;
using System.Linq;

namespace po4
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppCompat.Light.NoActionBar", MainLauncher = false)]
    public class DemiSecondActivity : AppCompatActivity
    {
        RecyclerView                mRecyclerView;
        RecyclerView.LayoutManager  mLayoutManager;
        DemiProductGroupListAdapter mAdapter;
        DemiProductList             mProductList;
        Button                      button;
        DemiProductCategory         CategoryID;
        List<string> ListOfProducts = new List<string>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate   (bundle);
            SetContentView  (Resource.Layout.Demiactivity_main);
            mRecyclerView   = FindViewById<RecyclerView>(Resource.Id.recyclerView1);

            if (this.Intent.Extras != null)
            {
                var category = (DemiProductCategory)Intent.Extras.GetInt("CategoryID");
                CategoryID = category;
                var productlist = Intent.Extras.GetStringArray("lijst");
                ListOfProducts = productlist.ToList();
            }

            mProductList = new DemiProductList(CategoryID);

            button = FindViewById<Button>(Resource.Id.button1);

            //----------------------------------------------------------------------------------------
            // Layout Managing Set-up

            mLayoutManager = new GridLayoutManager(this, 2, GridLayoutManager.Vertical, false);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            //----------------------------------------------------------------------------------------
            // Adapter Set-up
            mAdapter = new DemiProductGroupListAdapter(mProductList);
            mAdapter.ItemClick += OnItemClick;

            button.Click += Button_Click; ;

            mRecyclerView.SetAdapter(mAdapter);

        }

        void OnItemClick(object sender, int position)
        {
            var intent = new Intent(this, typeof(DemiThirdActivity));

            Bundle b = new Bundle();
            b.PutInt("CategoryID", (int)mProductList[position].category);
            b.PutInt("GroupID", (int)mProductList[position].group);
            b.PutStringArray("lijst", ListOfProducts.ToArray());
            intent.PutExtras(b);

            Toast.MakeText(this, "This is in group " + mProductList[position].group, ToastLength.Short).Show();

            StartActivity(intent);
        }


        void Button_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(FabioActivity));

            intent.PutExtra("lijst", ListOfProducts.ToArray());

            StartActivity(intent);
        }
    }
}


