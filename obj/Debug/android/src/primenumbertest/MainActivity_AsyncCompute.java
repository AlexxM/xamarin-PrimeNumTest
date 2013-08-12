package primenumbertest;


public class MainActivity_AsyncCompute
	extends android.os.AsyncTask
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onPreExecute:()V:GetOnPreExecuteHandler\n" +
			"n_onPostExecute:(Ljava/lang/Object;)V:GetOnPostExecute_Ljava_lang_Object_Handler\n" +
			"n_doInBackground:([Ljava/lang/Object;)Ljava/lang/Object;:GetDoInBackground_arrayLjava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("PrimeNumberTest.MainActivity/AsyncCompute, PrimeNumberTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainActivity_AsyncCompute.class, __md_methods);
	}


	public MainActivity_AsyncCompute ()
	{
		super ();
		if (getClass () == MainActivity_AsyncCompute.class)
			mono.android.TypeManager.Activate ("PrimeNumberTest.MainActivity/AsyncCompute, PrimeNumberTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public MainActivity_AsyncCompute (primenumbertest.MainActivity p0)
	{
		super ();
		if (getClass () == MainActivity_AsyncCompute.class)
			mono.android.TypeManager.Activate ("PrimeNumberTest.MainActivity/AsyncCompute, PrimeNumberTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "PrimeNumberTest.MainActivity, PrimeNumberTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public void onPreExecute ()
	{
		n_onPreExecute ();
	}

	private native void n_onPreExecute ();


	public void onPostExecute (java.lang.Object p0)
	{
		n_onPostExecute (p0);
	}

	private native void n_onPostExecute (java.lang.Object p0);


	public java.lang.Object doInBackground (java.lang.Object[] p0)
	{
		return n_doInBackground (p0);
	}

	private native java.lang.Object n_doInBackground (java.lang.Object[] p0);

	java.util.ArrayList refList;
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
