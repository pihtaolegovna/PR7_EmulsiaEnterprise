using Emulsia_Enterprise.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace Emulsia_Enterprise.Model
{
	internal class EmulsiaViewModel : BindingHelper
	{
		#region Команды

		public BindableCommand Multiplying { get; set; }
		public BindableCommand Emulsing { get; set; }
		public BindableCommand Selling { get; set; }
		public BindableCommand Buying { get; set; }
		public BindableCommand LevelUp { get; set; }

		#endregion

		private ObservableCollection<Emulsia> stats;

		public ObservableCollection<Emulsia> Stats
		{
			get { return stats; }
			set
			{
				stats = value;
				OnPropertyChanged();
			}
		}

		public EmulsiaViewModel()
		{
			Multiplying = new BindableCommand(_ => MultiplyClick());
			Emulsing = new BindableCommand(_ => EmulsingClick());
			Selling = new BindableCommand(_ => SellingClick());
			Buying = new BindableCommand(_ => BuyClick());
			LevelUp = new BindableCommand(_ => LevelUpClick());

			Stats = new ObservableCollection<Emulsia>()
			{
				new Emulsia(1, 0, 100, 1, 0, 2, 1)
			};
		}

		void LevelUpClick()
		{
			Emulsia Item = Stats.FirstOrDefault();
			Emulsia emu = new Emulsia(Item.Level, Item.Emulsed, Item.Balance, Item.Multiplyer, Item.Stored, Item.EmulsiaCost, Item.StoreCost);
			emu.Level++;
			emu.Multiplyer++;
			emu.StoreCost += emu.Level;
			emu.EmulsiaCost += emu.Level * 2;

			Stats.RemoveAt(0);
			Stats.Add(emu);
		}

		void EmulsingClick()
		{
			Emulsia Item = Stats.FirstOrDefault();
			Emulsia emu = new Emulsia(Item.Level, Item.Emulsed, Item.Balance, Item.Multiplyer, Item.Stored, Item.EmulsiaCost, Item.StoreCost);
			emu.Emulsed += (Item.Multiplyer == 0 ? 1 : Item.Multiplyer);
			emu.Stored-= (Item.Multiplyer == 0 ? 1 : Item.Multiplyer);
			Stats.RemoveAt(0);
			Stats.Add(emu);
		}

		void SellingClick()
		{
			Emulsia Item = Stats.FirstOrDefault();
			Emulsia emu = new Emulsia(Item.Level, Item.Emulsed, Item.Balance, Item.Multiplyer, Item.Stored, Item.EmulsiaCost, Item.StoreCost);
			emu.Emulsed -= Item.Multiplyer == 0 ? 1 : Item.Multiplyer;
			emu.Balance += (Item.Multiplyer == 0 ? 1 : Item.Multiplyer) * Item.EmulsiaCost;
			Stats.RemoveAt(0);
			Stats.Add(emu);
		}

		void BuyClick()
		{
			Emulsia Item = Stats.FirstOrDefault();
			Emulsia emu = new Emulsia(Item.Level, Item.Emulsed, Item.Balance, Item.Multiplyer, Item.Stored, Item.EmulsiaCost, Item.StoreCost);
			emu.Balance -= (Item.Multiplyer == 0 ? 1 : Item.Multiplyer) * Item.StoreCost;
			emu.Stored += (Item.Multiplyer == 0 ? 1 : Item.Multiplyer);
			Stats.RemoveAt(0);
			Stats.Add(emu);
		}

		void MultiplyClick()
		{
			Emulsia Item = Stats.FirstOrDefault();
			Emulsia emu = new Emulsia(Item.Level, Item.Emulsed, Item.Balance, Item.Multiplyer, Item.Stored, Item.EmulsiaCost, Item.StoreCost);
			emu.Multiplyer++;
			Stats.RemoveAt(0);
			Stats.Add(emu);
		}
	}
}
