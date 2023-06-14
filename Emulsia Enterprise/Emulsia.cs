using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulsia_Enterprise
{
	internal class Emulsia
	{
		public Emulsia(int level, int emulsed, int balance, int multiplyer, int stored, int emulsiacost, int storecost)
		{
			Level = level;
			Emulsed = emulsed;
			Balance = balance;
			Multiplyer = multiplyer;
			Stored = stored;
			EmulsiaCost = emulsiacost;
			StoreCost = storecost;
		}

		public int Level { get; set; }
		public int Emulsed { get; set; }
		public int Balance { get; set; }
		public int Multiplyer { get; set; }
		public int Stored { get; set; }
		public int EmulsiaCost { get; set; }
		public int StoreCost { get; set; }

	}
}
