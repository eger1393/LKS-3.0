using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.Entity;
using System.Windows;
using LKS_3._0.Model;

namespace LKS_3._0.ViewModel
{
	class InfoAdministrationMilKafViewModel : INotifyPropertyChanged
	{
		public ApplicationContext DataBaseR;
		public InfoAdministrationMilKafViewModel(ref ApplicationContext DataBase)
		{
			DataBaseR = DataBase;
		}
		private RelayCommand saveChangedCommand;
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
		public RelayCommand SaveChangedCommand
		{
			get
			{
				return saveChangedCommand ??
					(saveChangedCommand = new RelayCommand(obj =>
					{
                        DataBaseR.SaveChanges();
					}));
			}
		}
	}
}
