using System;
using System.Collections.Generic;
using DictionaryApp.ViewModels;
using Xamarin.Forms;
using DictionaryApp.Models;


namespace DictionaryApp.Views
{	
	public partial class AllWords : ContentPage
	{
		public AllViewModel _viewModel;

		public AllWords ()
		{
            InitializeComponent ();
			BindingContext = _viewModel = new AllViewModel();
        }
    }
}

