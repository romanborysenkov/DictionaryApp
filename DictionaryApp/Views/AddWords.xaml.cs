using System;
using System.Collections.Generic;
using DictionaryApp.ViewModels;
using Xamarin.Forms;

namespace DictionaryApp.Views
{
    public partial class AddWords : ContentPage
    {

        AddViewModel _viewModel;
        public AddWords()
        {
            InitializeComponent();
            BindingContext = _viewModel = new AddViewModel();
        }
    }
}

