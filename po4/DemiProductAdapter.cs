﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace po4
{
    //----------------------------------------------------------------------
    // Adapter for the actual products
    //----------------------------------------------------------------------
    public class DemiProductAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public DemiProductList mProductList;


        public DemiProductAdapter(DemiProductList productlist)
        {
            mProductList = productlist;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.DemiProductCardView, parent, false);
            DemiRecycleViewHolderClass vh = new DemiRecycleViewHolderClass(itemView, OnClick);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            DemiRecycleViewHolderClass vh = holder as DemiRecycleViewHolderClass;
            //vh.Category.Text = mProductList[position].category.ToString();
            //vh.Group.Text = mProductList[position].group.ToString();
            vh.Name.Text = mProductList[position].name.ToString();
        }

        public override int ItemCount
        {
            get { return mProductList.NumProducts; }
        }

        void OnClick(int position)
        {
            if (ItemClick != null) ItemClick(this, position);
        }


    }



    //----------------------------------------------------------------------
    // Adapter for the groups
    //----------------------------------------------------------------------
    public class DemiProductGroupListAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public DemiProductList mGroupList;


        public DemiProductGroupListAdapter(DemiProductList grouplist)
        {
            mGroupList = grouplist;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.DemiGroupCardView, parent, false);
            DemiRecycleViewHolderClass vh = new DemiRecycleViewHolderClass(itemView, OnClick);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            DemiRecycleViewHolderClass vh = holder as DemiRecycleViewHolderClass;
            //vh.Category.Text = mGroupList[position].CategoryName;
            vh.Group.Text = mGroupList[position].group.ToString();
        }

        public override int ItemCount
        {
            get { return mGroupList.NumProducts; }
        }

        void OnClick(int position)
        {
            if (ItemClick != null) ItemClick(this, position);
        }


    }



    //----------------------------------------------------------------------
    // Adapter for the categories
    //----------------------------------------------------------------------
    public class DemiProductListAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public DemiProductList mProductList;


        public DemiProductListAdapter(DemiProductList productList)
        {
            mProductList = productList;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.DemiCategoryCardView, parent, false);
            DemiRecycleViewHolderClass vh = new DemiRecycleViewHolderClass(itemView, OnClick);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            DemiRecycleViewHolderClass vh = holder as DemiRecycleViewHolderClass;
            vh.Category.Text = mProductList[position].category.ToString();
            //vh.Group.Text = mProductList[position].GroupName;
        }

        public override int ItemCount
        {
            get { return mProductList.NumProducts; }
        }

        void OnClick(int position)
        {
            if (ItemClick != null) ItemClick(this, position);
        }


    }
}