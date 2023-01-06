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
	public class MainViewModel:BaseViewModel
	{
		WordsService servce = new WordsService();

		public Command GoToWordsCommand { get; }

		public Command GoToAddCommand { get; }

		public Command GoToRandCommand { get; }

		public Command GoToArchiveCommand { get; }

		public Command<Year> YearTapped { get; }

		public Command OnHideUkr { get; }
		public Command OnHideEn { get; }

		private bool added;

		public bool Added
		{
			get => added;
			set { added = value; OnPropertyChanged(); }
		}

		private bool notadded;

		public bool NotAdded
		{
			get => notadded;
			set { notadded = value; OnPropertyChanged(); }
		}

		private List<Word> todaywords;

		public List<Word> TodayWords
		{
			get => todaywords;
			set { todaywords = value; OnPropertyChanged(); }
		}

		private ObservableCollection<Year> years = new ObservableCollection<Year>();


        public ObservableCollection<Year> Years
        {
            get => years;
            set { years = value; OnPropertyChanged(); }
        }

        public string HideUkrText { get; set; } = "Hide ukrainian";

		public string HideEnText { get; set; } = "Hide english";

		public bool visibleEn { get; set; } = true;
		public bool visibleUkr { get; set; } = true;

		private bool archiveVisible;

		public bool ArchivesVisible { get => archiveVisible; set
			{
				archiveVisible = value;
				OnPropertyChanged();
			}
		}



		public  MainViewModel()
		{
			GoToWordsCommand = new Command(GoToWords);

			GoToAddCommand = new Command(GoToAdd);

			GoToRandCommand = new Command(GoToRandom);

			YearTapped = new Command<Year>(OnSelected);


			GetTodayWords();

			GetArchive();
		}


		public async Task GetTodayWords()
		{
			TodayWords = await servce.GetTodayWords();
			if(TodayWords.Count==0)
			{
				NotAdded = false;
				Added = true;
			}
			else { NotAdded = true; Added = false; }
		}

        public async Task GetArchive()
        {
			IsBusy = true;
			var res = await servce.GetArchiveYears();

			Years = new ObservableCollection<Year>();

            for (int i=0;i<res.Count;i++)
			{
				Years.Add(new Year(res[i]));
				//Years[i].YearOld = res[i];
			}
			IsBusy = false;
        }


        public async void GoToWords()
		{
			await Shell.Current.GoToAsync("/AllWords");
		}

        public async void GoToAdd()
        {
           await Shell.Current.GoToAsync("/AddWords");
        }

		public async void GoToRandom()
		{
			await Shell.Current.GoToAsync("/RandomPage");
		}

        private Year _selectedyear;
        public Year SelectedYear
		{
			get => _selectedyear;
			set
			{
				SetProperty(ref _selectedyear, value);
				OnSelected(value);
			}
		}

		public async void OnSelected(Year year)
		{
			if (year == null)
				return;

			await Shell.Current.GoToAsync($"{nameof(ArchivePage)}?{nameof(ArchiveViewModel.Year)}={year.YearOld}");
		}

    }
}

