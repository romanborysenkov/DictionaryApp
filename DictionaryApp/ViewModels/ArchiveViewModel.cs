using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DictionaryApp.Models;
using DictionaryApp.Services;
using DictionaryApp.Views;
using Xamarin.Forms;

namespace DictionaryApp.ViewModels
{
	[QueryProperty(nameof(Year),nameof(Year))]
	public class ArchiveViewModel:BaseViewModel
	{
		WordsService service = new WordsService();

		private ObservableCollection<Word> words = new ObservableCollection<Word>();

		public ObservableCollection<Word> Words
		{
			get => words;
            set { words = value; OnPropertyChanged(); }
        }

		private string year;
		public string Year
		{
			get { return year; }
			set { year = value; DownloadWords(); }
		}

		private string searchstring;
		public string SearchString
		{
			get => searchstring;
			set { searchstring = value; PerfSearch(); OnPropertyChanged(); }
		}

		public ArchiveViewModel()
		{
			DownloadWords();
		}

		public async void DownloadWords()
		{
			if (Year != null)
			{
				Words = await service.GetArchiveWords(Year);
			}
		}

		public async void PerfSearch()
		{            Words = await service.GetArchiveWords(Year);
            Words = new ObservableCollection<Word>(words.Where(s => s.InEnglish.ToLower().Contains(SearchString.ToLower())
         || s.InUkrainian.ToLower().Contains(SearchString.ToLower())));
        }

		/*public ICommand PerformSearch => new Command<string>(async(string query) =>
        {
			Words = await service.GetArchiveWords(Year);
			Words = new ObservableCollection<Word>(words.Where(s => s.InEnglish.ToLower().Contains(SearchString.ToLower())
             || s.InUkrainian.ToLower().Contains(SearchString.ToLower())));
        });*/
	}
}

