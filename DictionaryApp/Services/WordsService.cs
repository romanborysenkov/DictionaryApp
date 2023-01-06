using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DictionaryApp.Models;
using Newtonsoft.Json;

namespace DictionaryApp.Services
{
	public class WordsService
	{
        public async Task<List<Word>> GetAllWordsAsync()
        {
            List<Word> words = new List<Word>();

            using (HttpClient client = new HttpClient())
            {

                client.Timeout = new TimeSpan(0, 0, 0, 5);
                var response = await client.GetStringAsync("http://192.168.1.12:7105/api/Word");

                words = JsonConvert.DeserializeObject<List<Word>>(response);

                return words;
            }

        }

        public async Task<ObservableCollection<Word>> GetHandredWords()
        {
            ObservableCollection<Word> words = new ObservableCollection<Word>();

            using (HttpClient client = new HttpClient())
            {

                // client.Timeout = new TimeSpan(0,0,0,5);

                var response = await client.GetStringAsync("http://192.168.1.12:7105/api/Word/handred");

                words = JsonConvert.DeserializeObject<ObservableCollection<Word>>(response);

                return words;
            }

        }

        public async Task<List<Word>> GetTodayWords()
        {
            List<Word> words = new List<Word>();

            HttpClient client = new HttpClient();

            // client.Timeout = new TimeSpan(0,0,0,5);

            var response = await client.GetStringAsync("http://192.168.1.12:7105/api/Word/today");

            words = JsonConvert.DeserializeObject<List<Word>>(response);
            return words;
        }

        public async void PostWords(List<Word> words)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = JsonConvert.SerializeObject(words);
                var fin = new StringContent(request, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("http://192.168.1.12:7105/api/Word", fin);
             //   var output = JsonConvert.DeserializeObject<List<Word>>(await result.Content.ReadAsStringAsync());

              
            }
        }

        public async Task<ObservableCollection<string>> GetArchiveYears()
        {
            ObservableCollection<string> years = new ObservableCollection<string>();

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync("http://192.168.1.12:7105/api/Word/archiveyears");
                years = JsonConvert.DeserializeObject<ObservableCollection<string>>(response);

            }
            return years; 
        }

        public async Task<ObservableCollection<Word>> GetArchiveWords(string year)
        {
            ObservableCollection<Word> words = new ObservableCollection<Word>();

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync($"http://192.168.1.12:7105/api/Word/archivewords/{year}");
                words = JsonConvert.DeserializeObject<ObservableCollection<Word>>(response);

            }
            return words;
        }
    }
}

