using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Util
{
	public static class Const
	{
		/// <summary>
		/// 制空権に関わる装備(偵察機なし)
		/// </summary>
		public static List<int> PLANES = new List<int>() { 6, 7, 8, 11, 45, 47, 48, 53, 56, 57, 58, 59 };

		/// <summary>
		/// 基地を含めた制空権に関わる装備(偵察機あり)
		/// </summary>
		public static List<int> PLANES_ALL = new List<int>() { 6, 7, 8, 9, 10, 11, 41, 45, 47, 48, 49, 53, 56, 57, 58, 59 };
	}
}
