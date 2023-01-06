using System;
using System.Collections.Generic;
using Xamarin.Forms;
using DictionaryApp.ViewModels;
using DictionaryApp.Models;

namespace DictionaryApp.Views
{	
	public partial class ArchivesView : ContentView
	{
		ArchivesViewModel viewModel;

		public ArchivesView ()
		{
			InitializeComponent ();
			BindingContext = viewModel = new ArchivesViewModel();
		}
	}
}

