using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DictionaryApp.Models;
using DictionaryApp.Services;
using DictionaryApp.Views;
using Xamarin.Forms;

namespace DictionaryApp.ViewModels
{
	public class ArchivesViewModel:BaseViewModel
	{
		private ObservableCollection<string> years = new ObservableCollection<string>();
        readonly WordsService service = new WordsService();

		

		public ObservableCollection<string> Years
		{
			get => years;
			set { years = value; OnPropertyChanged(); }
		}

		public ArchivesViewModel()
		{
		//	GetArchive();
		}

	     public async Task GetArchive()
		{
			//Years = await service.GetArchiveYears();
		}
	}
}

