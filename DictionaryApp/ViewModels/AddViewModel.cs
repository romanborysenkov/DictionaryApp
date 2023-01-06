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
using System.Globalization;


namespace DictionaryApp.ViewModels
{
	public class AddViewModel:BaseViewModel
	{
		WordsService service = new WordsService();

        public List<Word> words = new List<Word>();

        public Command AddWordsCommand { get; }

        public List<Word> NewWords
        {
            get
            {
                return words;
            }
            set
            { SetProperty(ref words, value); }
        }


        public AddViewModel()
		{
            AddWordsCommand = new Command(async()=>await AddWords());
            SetWords();
		}

        public async Task SetWords()
        {
            for(int i=0;i<10;i++)
            {
                words.Add(new Word());
            }
        }

        public async Task AddWords()
        {
           /* for (int i = 0; i < 10; i++)
            {
                words[i].Created = DateTime.Now.ToShortDateString();
            }*/
            service.PostWords(words);
            await Shell.Current.GoToAsync("//MainPage");
        }
	}
}

