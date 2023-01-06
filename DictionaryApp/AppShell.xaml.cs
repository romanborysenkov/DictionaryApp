using System;
using System.Collections.Generic;
using DictionaryApp.ViewModels;
using DictionaryApp.Views;
using Xamarin.Forms;

namespace DictionaryApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
           
            Routing.RegisterRoute(nameof(AddWords), typeof(AddWords));
            Routing.RegisterRoute(nameof(AllWords), typeof(AllWords));
            Routing.RegisterRoute(nameof(RandomPage), typeof(RandomPage));
            Routing.RegisterRoute(nameof(ArchivePage), typeof(ArchivePage));
        }

     
    }
}

