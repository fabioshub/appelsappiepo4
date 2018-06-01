using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;

using Object = Java.Lang.Object;

namespace po4
{
    class GroceryListItem : Object, IParcelable
    {
        [ExportField("CREATOR")]
        public static ListCreator InitializeCreator()
        {
            return new ListCreator();
        }

        public string ProductName
        {
            get;
            private set;
        }

        public string ProductAmount
        {
            get;
            private set;
        }

        public GroceryListItem(string ProductName, string ProductAmount)
        {
            this.ProductName = ProductName;
            this.ProductAmount = ProductAmount;
        }

        public int DescribeContents()
        {
            return 0;
        }

        public void WriteToParcel(Parcel dest, ParcelableWriteFlags flags)
        {
            dest.WriteString(this.ProductName);
            dest.WriteString(this.ProductAmount);
        }
    }

    class ListCreator : Object, IParcelableCreator
    {
        public Object CreateFromParcel(Parcel source)
        {
            return new GroceryListItem(source.ReadString(), source.ReadString());
        }

        public Object[] NewArray(int size)
        {
            return new Object[size];
        }
    }
}