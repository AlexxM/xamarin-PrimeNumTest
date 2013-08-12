using System;
using System.Collections.Generic;
using System.Numerics;
namespace PrimeNumberTest
{
	public class Extensions
	{
		public static bool MillerPrimaryTest(BigInteger num, int round = 20)
		{
			int t;
			BigInteger x, s, a;
			bool flag;

			if (num == 2 || num==3)
			{
				return true;
			}

			if (num < 2)
			{
				throw new InvalidOperationException ("Введите натуральное число больше 1");
			}

			if (num % 2 == 0)
			{
				return false;
			}

			s = num - 1;
			t = 0;
			while (s % 2 == 0)
			{
				s /= 2;
				t++;
			}

			for (int i = 0; i < round; i++)
			{

				flag = false;
				Random rnd = new Random();

				int l = num.ToByteArray().Length;

				do
				{

					byte[] arr = new byte[l];
					rnd.NextBytes(arr);
					a = new BigInteger(arr);
					a = BigInteger.Abs(a);

				}
				while (a < 2 || a >= num - 2);

				x = BigInteger.ModPow(a, s, num);
				x = x % num;

				if (x == 1 || x == num - 1)
					continue;

				for (int j = 1; j < t; j++)
				{

					x = x * x;
					x = x % num;

					if (x == 1)
						return false;

					if (x == num - 1)
					{
						flag = true;
						break;
					}
				}

				if (flag == true)
					continue;

				return false;


			}
			return true;
		}

		public static List<BigInteger> Factorization(BigInteger num, int start = 2)
		{
			if (num < 1)
				return null;

			BigInteger d = start;
			List<BigInteger> lst = new List<BigInteger>();

			while (num >= d * d)
			{
				if (num % d == 0)
				{
					lst.Add(d);
					num = num / d;

				}
				else if (d >= 1024)
				{
					if (MillerPrimaryTest(num) == true)
						break;

					d = RHOPollard(num);
					lst.Add(d);
					num = num / d;

				}
				else
				{

					d = d + 1 + d % 2;
				}

			}


			lst.Add(num);
			return lst;

		}


		public static BigInteger RHOPollard(BigInteger n)
		{

			Byte[] b = n.ToByteArray();
			Random rnd = new Random();
			int newLen = rnd.Next(1, b.Length);
			BigInteger x = BigInteger.Abs(new BigInteger(CreateSubArray<byte>(b, 0, newLen)));

			BigInteger y = 1, i = 0, stage = 2;

			while (BigInteger.GreatestCommonDivisor(n, BigInteger.Abs(x - y)) == 1)
			{
				if (i == stage)
				{
					y = x;
					stage = stage * 2;
				}
				x = (x * x + 1) % n;
				i += 1;
			}


			return BigInteger.GreatestCommonDivisor(n, BigInteger.Abs(x - y));

		}

		public static T[] CreateSubArray<T>(T[] input,int index,int length)
		{
			T[] newArr = new T[length];

			Array.Copy(input, index,newArr,0,length);

			return newArr;

		}


	}
}

