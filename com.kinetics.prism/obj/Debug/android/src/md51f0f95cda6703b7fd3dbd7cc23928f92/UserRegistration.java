package md51f0f95cda6703b7fd3dbd7cc23928f92;


public class UserRegistration
	extends md51f0f95cda6703b7fd3dbd7cc23928f92.BaseActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("com.kinetics.prism.UserRegistration, Priscm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", UserRegistration.class, __md_methods);
	}


	public UserRegistration () throws java.lang.Throwable
	{
		super ();
		if (getClass () == UserRegistration.class)
			mono.android.TypeManager.Activate ("com.kinetics.prism.UserRegistration, Priscm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
