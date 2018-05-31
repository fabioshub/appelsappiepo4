package md589fc277b20e6f95fd4fe6e44dd4ffae5;


public class DemiRecycleViewHolderClass
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("po4.DemiRecycleViewHolderClass, po4", DemiRecycleViewHolderClass.class, __md_methods);
	}


	public DemiRecycleViewHolderClass (android.view.View p0)
	{
		super (p0);
		if (getClass () == DemiRecycleViewHolderClass.class)
			mono.android.TypeManager.Activate ("po4.DemiRecycleViewHolderClass, po4", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
