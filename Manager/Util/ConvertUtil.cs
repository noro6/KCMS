using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
				if ((int)ToDecimal(value) == 1) return true;
				return alt;
			}
			catch (Exception)
			{
				return alt;
			}
		}

		/// <summary>
		/// CSVファイルを読み込み、各string配列として返却
		/// </summary>
		/// <returns></returns>
		public static List<List<string>> ReadCSV()
		{
			var list = new List<List<string>>();
			try
			{
				//OpenFileDialogクラスのインスタンスを作成
				var ofd = new OpenFileDialog
				{
					InitialDirectory = @"D:\Downloads\",
					Filter = "CSVファイル(*.csv)|*.csv",
					Title = "ファイルを選択してください",
					RestoreDirectory = true,
				};

				//ダイアログを表示する
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					var parser = new TextFieldParser(ofd.FileName, Encoding.GetEncoding("UTF-8"))
					{
						TextFieldType = FieldType.Delimited
					};
					parser.SetDelimiters(",");

					while (parser.EndOfData == false)
					{
						var column = parser.ReadFields();
						var row = new List<string>();

						for (int i = 0; i < column.Length; i++)
						{
							row.Add(column[i]);
						}

						if (row.Count > 0)
						{
							list.Add(row);
						}
					}
				}

				if(list.Count > 0 )
				{
					return list;
				}
				return null;
			}
			catch (IOException ex)
			{
				MessageBox.Show("失敗しました。" + Environment.NewLine + ex.Message, "CSV読込失敗", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return null;
			}
		}
	}
}
