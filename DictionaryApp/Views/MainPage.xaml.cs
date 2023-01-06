using System;
using System.Collections.Generic;
using DictionaryApp.Models;
using DictionaryApp.ViewModels;
using Xamarin.Forms;

namespace DictionaryApp.Views
{
    public partial class MainPage : ContentPage
    {

        public MainViewModel _viewModel;
        

        public MainPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MainViewModel();
        }
    }
}

