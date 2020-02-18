using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Util
{
	class ConvertUtil
	{
		/// <summary>
		/// <para>引数のデータを <see cref="string"/> に変換、返却する。</para>
		/// <para>失敗時は空文字を返却するが、第2引数を指定した場合はそちらを返す。</para>
		/// </summary>
		/// <param name="value">変換したいデータ</param>
		/// <param name="alt">変換失敗時の代替文字列(任意)</param>
		/// <returns>変換した文字列</returns>
		public static string ToString(object value, string alt = "")
		{
			try
			{
				if (value is null) return alt;
				return value.ToString();
			}
			catch (Exception)
			{
				return alt;
			}
		}

		/// <summary>
		/// <para>引数のデータを <see cref="decimal"/> に変換、返却する。</para>
		/// <para>失敗時は 0 を返却するが、第2引数を指定した場合はそちらを返す。</para>
		/// </summary>
		/// <param name="value">変換したいデータ</param>
		/// <param name="alt">変換失敗時の代替値(任意)</param>
		/// <returns>変換した値</returns>
		public static decimal ToDecimal(object value, decimal alt = 0)
		{
			try
			{
				if (value is null) return alt;
				var strValue = value.ToString();
				if (strValue == "") return alt;
				decimal.TryParse(strValue, out decimal dec);
				return dec;
			}
			catch (Exception)
			{
				return alt;
			}
		}

		/// <summary>
		/// <para>引数のデータを <see cref="int"/> に変換、返却する。</para>
		/// <para>失敗時は 0 を返却するが、第2引数を指定した場合はそちらを返す。</para>
		/// </summary>
		/// <param name="value">変換したいデータ</param>
		/// <param name="alt">変換失敗時の代替値(任意)</param>
		/// <returns>変換した値</returns>
		public static int ToInt(object value, int alt = 0)
		{
			return (int)ToDecimal(value, alt);
		}

		/// <summary>
		/// <para>引数のデータを <see cref="double"/> に変換、返却する。</para>
		/// <para>失敗時は 0 を返却するが、第2引数を指定した場合はそちらを返す。</para>
		/// </summary>
		/// <param name="value">変換したいデータ</param>
		/// <param name="alt">変換失敗時の代替値(任意)</param>
		/// <returns>変換した値</returns>
		public static double ToDouble(object value, double alt = 0)
		{
			return (double)ToDecimal(value, (decimal)alt);
		}

		/// <summary>
		/// <para>引数のデータを <see cref="double"/> に変換、返却する。</para>
		/// <para>失敗時は 0 を返却するが、第2引数を指定した場合はそちらを返す。</para>
		/// </summary>
		/// <param name="value">変換したいデータ</param>
		/// <param name="alt">変換失敗時の代替値(任意)</param>
		/// <returns>変換した値</returns>
		public static float ToFloat(object value, float alt = 0)
		{
			return (float)ToDecimal(value, (decimal)alt);
		}

		/// <summary>
		/// <para>引数のデータを <see cref="bool"/> に変換、返却する</para>
		/// <para>失敗時は <see cref="false"/> を返却するが、第2引数を指定した場合はそちらを返す。</para>
		/// </summary>
		/// <param name="value">変換したいデータ</param>
		/// <param name="alt">変換失敗時の代替値(任意)</param>
		/// <returns></returns>
		public static bool ToBool(object value, bool alt = false)
		{
			try
			{
				if (value is null) return alt;
				if (bool.TryParse(ToString(value), out bool result)) return result;
				return alt;
			}
			catch (Exception)
			{
				return alt;
			}
		}
	}
}
