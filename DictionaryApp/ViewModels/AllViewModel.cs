using System;
using DictionaryApp.Services;
using DictionaryApp.Models;
using DictionaryApp.Views;
using Xamarin.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DictionaryApp.ViewModels
{
	public class AllViewModel : BaseViewModel
    {
        WordsService service = new WordsService();

		public Command GetWordsCommand { get; } 

		public List<Word> words = new List<Word>();

        public List<Word> Words
        {
            get
            {
                return words;
            }
            set
            {   SetProperty(ref words, value); }
        }

        private string searchstring;
        public string SearchString
        {
            get => searchstring;
            set { searchstring = value; PerfSearch(); OnPropertyChanged(); }
        }

        public AllViewModel()
		{
            GetWordsCommand = new Command(async()=>await GetWords());
           GetWords();
		}

		public async Task GetWords()
		{
            IsBusy = true;
           
            Words = await service.GetAllWordsAsync();
            IsBusy = false;
		}

        public async void PerfSearch()
        {
            Words = await service.GetAllWordsAsync();
            Words = words.Where(s => s.InEnglish.ToLower().Contains(SearchString.ToLower())
              || s.InUkrainian.ToLower().Contains(SearchString.ToLower())).ToList();
        }

    }
}

