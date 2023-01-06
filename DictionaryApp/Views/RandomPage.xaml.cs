using System;
using System.Collections.Generic;
using DictionaryApp.ViewModels;
using Xamarin.Forms;
using DictionaryApp.Models;


namespace DictionaryApp.Views
{	
	public partial class RandomPage : ContentPage
	{
		RandomViewModel viewModel;

		public RandomPage ()
		{
			InitializeComponent ();
			BindingContext = viewModel = new RandomViewModel(this);
		}

       
    }
}

