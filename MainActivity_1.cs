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
using System.Numerics;
namespace PrimeNumberTest
{
	partial class MainActivity
	{
	    class AsyncCompute : AsyncTask
		{
			private MainActivity _mainActivity; 
			private ProgressDialog _pd;
			private List<BigInteger> _seq;

			public AsyncCompute(MainActivity a)
			{
				_mainActivity=a;

			}

			protected override void OnPreExecute ()
			{
				base.OnPreExecute ();
				_pd = ProgressDialog.Show (_mainActivity, null, "Проверка на простоту...", true);
			}

			protected override void OnPostExecute (Java.Lang.Object result)
			{
				base.OnPostExecute (result);
				if (_seq != null)
					_mainActivity.FormatPrimeSequence (_seq);
				else
					_mainActivity._sequence.Text = "";

				if (_pd != null)
					_pd.Dismiss ();

			}
		

			protected override Java.Lang.Object DoInBackground (params Java.Lang.Object[] @params)
			{

				try 
				{
					if(_mainActivity._testedNum==null || _mainActivity._testedNum.Text.Length==0)
						return null;

					BigInteger bi = BigInteger.Parse (_mainActivity._testedNum.Text);
					bool b = Extensions.MillerPrimaryTest (bi);
					if (b)
					{
						_mainActivity.LabelReport("Число простое",false);
					
					} 
					else 
					{
						_seq = Extensions.Factorization(bi);
						_mainActivity.LabelReport("Число составное",true);
						//_mainActivity.FormatPrimeSequence(lst);
					}

				} 
				catch (InvalidOperationException ex)
				{

					_mainActivity.LabelReport (ex.Message,true);

				}

				return null;
			
			}
		}	
	}
}

