using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Numerics;
using System.Threading;
using Android.Content.PM;
using System.Collections.Generic;
namespace PrimeNumberTest
{
	[Activity (Label = "PrimeNumberTest", MainLauncher = true, ConfigurationChanges=ConfigChanges.Orientation|ConfigChanges.KeyboardHidden)]
	public partial class MainActivity : Activity
	{
		private EditText _testedNum;
		private TextView _result;
		private AsyncCompute _ac;
		private TextView _sequence;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);
			_testedNum = FindViewById<EditText> (Resource.Id.txtNum);
			_result = FindViewById<TextView> (Resource.Id.lblResult);
			_sequence = FindViewById<TextView> (Resource.Id.lblFactorization);
			FindViewById<Button> (Resource.Id.btnStart).Click += delegate {

				if (_testedNum.Text.Length != 0)
				{
					_ac=new AsyncCompute(this);
					_ac.Execute();
				} 
				else
				{
					LabelReport("Введите число",true);
				}

			};

		}
		
		private void LabelReport(string text,bool isError)
		{
			this.RunOnUiThread(()=>
			{
				_result.Text = text;
				if(isError)
				{	
					_result.SetTextColor(Android.Graphics.Color.Red);
				}
				else
				{
					_result.SetTextColor(Android.Graphics.Color.Green);
				}

			});
		}

		public void FormatPrimeSequence(List<BigInteger> lst)
		{
			string output=_testedNum.Text+"=";
			foreach (BigInteger item in lst)
			{
				output += item.ToString ();
				output += "*";
			}
			output=output.Remove (output.Length-1);

			this.RunOnUiThread (()=>{
				FindViewById<TextView> (Resource.Id.lblFactorization).Text = output;
			});
		}

	}

}


