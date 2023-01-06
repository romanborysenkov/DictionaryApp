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
	public class RandomViewModel: BindableObject// BaseViewModel
	{
		WordsService service = new WordsService();

		public Command CheckCommand { get; }

		public Command GetWordsCommnad { get; }

		private ObservableCollection<Word> randomWords = new ObservableCollection<Word>();


        public ObservableCollection<Word> RandomWords
        {
            get
            {
                return randomWords;
            }
            set
            { randomWords = value; OnPropertyChanged(); }//  SetProperty(ref randomWords, value); }
        }


		private ObservableCollection<Word> inputWords = new ObservableCollection<Word>();

        public ObservableCollection<Word> InputWords
        {
            get
            {
                return inputWords;
            }
            set
            { inputWords = value; OnPropertyChanged(); }// SetProperty(ref inputWords, value); }
        }
        Page page;

        public RandomViewModel(Page page)
		{
            this.page = page;
			GetWordsCommnad = new Command(async()=>await GetWords());
			CheckCommand = new Command(CheckWords);
			GetWords();
		}

       

		public async Task GetWords()
		{
          //  IsBusy = true;
            if (InputWords == null || InputWords.Count <= 1)
            {
                InputWords = new ObservableCollection<Word>();
                for (int i = 0; i < 10; i++)
                {
                    InputWords.Add(new Word());
                    InputWords[i].Id = i;
                }
            }

            if (RandomWords == null || RandomWords.Count == 0)
            {
                RandomWords = await service.GetHandredWords();
            }

         //   IsBusy = false;
         /**  

            if (!string.IsNullOrEmpty(InputWords[0].InUkrainian))
            {
                for (int i = 0; i < InputWords.Count; i++)
                {
                    if (RandomWords[i].InUkrainian == InputWords[i].InUkrainian)
                    {
                        RandomWords.Remove(randomWords[i]);
                    }
                }
            }
         */

        }

		public async void CheckWords()
		{
			for(int i=0;i<inputWords.Count;i++)
			{
				if (RandomWords[i].InUkrainian == InputWords[i].InUkrainian)
				{
                    InputWords.Remove(InputWords[i]);
					RandomWords.Remove(randomWords[i]);
					i--;
				}
			}
            if (randomWords.Count == 0) {
               await page.DisplayAlert("Successful!", "You are success answered to all words", "Ok!");
                await Shell.Current.GoToAsync("//MainPage"); }
		}

       
    }
}

