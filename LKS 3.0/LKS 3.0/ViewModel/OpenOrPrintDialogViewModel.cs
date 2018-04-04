using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WORD = Microsoft.Office.Interop.Word; // исспользую для печати файла


namespace LKS_3._0.ViewModel
{
	public class OpenOrPrintDialogViewModel : INotifyPropertyChanged
	{
		private string filePath;
		private int count;

		private RelayCommand open, print, close;
		public Action CloseAction { get; set; }
		/// <summary>
		/// После создания шаблона вызывается окно с различными вариантами действий: открыть шаблон в ворде
		/// ,распечатать, закрыть окно.
		/// </summary>
		/// <param name="FilePath">Полный путь к файлу</param>
		/// <param name="count">Кол-во экземпляров печатуемого файла(по умолчанию = 1)</param>
		public OpenOrPrintDialogViewModel(string FilePath, int count = 1)
		{
			this.filePath = FilePath;
			this.count = count;
		}
		public RelayCommand Close
		{
			get
			{
				return close ?? (close = new RelayCommand(obj =>
				{
					CloseAction();
				}));
			}
		}
		public RelayCommand Open
		{
			get
			{
				return open ?? (open = new RelayCommand(obj =>
				{
					PrintOrOpenDocument(filePath, count, false);
					CloseAction();
				}));
			}
		}
		public RelayCommand Print
		{
			get
			{
				return print ?? (print = new RelayCommand(obj =>
				{
					PrintOrOpenDocument(filePath, count, true);
					CloseAction();
				}));
			}
		}
		public string FileName // возвращаем имя файла
		{
			get
			{
				if(filePath.LastIndexOf('\\') != -1) 
					return filePath.Substring(filePath.LastIndexOf('\\') + 1, filePath.LastIndexOf('.') - filePath.LastIndexOf('\\') - 1) + " ";
				else
					return filePath.Substring(0, filePath.LastIndexOf('.') - 1) + " ";
			}

		}


		/// <summary>
		/// Печать файла
		/// </summary>
		/// <param name="path">Путь к файлу</param>
		/// <param name="count">Кол-во копий</param>
		/// <param name="isPrint">Вызывть ли диалог печати?</param>
		public static void PrintOrOpenDocument(string path, int count, bool isPrint = false)
		{
			try
			{
				WORD.Application app = new WORD.Application();
				app.Documents.Open(path);
				if (isPrint) // выбранный параметр
				{ // печать документа
					dynamic dlg = app.Dialogs[WORD.WdWordDialog.wdDialogFilePrint];
					dlg.NumCopies = count;
					dlg.Show();
					app.ActiveDocument.Close();
					app.Quit();
				}
				else
				{ // открытие документа
					//app.Documents.op
					app.Visible = true;
				}
			}
			catch (System.Runtime.InteropServices.COMException ex)
			{
				System.Windows.MessageBox.Show(ex.Message);
			}


		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}
