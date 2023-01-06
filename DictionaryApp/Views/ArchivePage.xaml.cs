using System;
using System.Collections.Generic;
using DictionaryApp.ViewModels;


using Xamarin.Forms;

namespace DictionaryApp.Views
{	
	public partial class ArchivePage : ContentPage
	{
		public ArchiveViewModel viewModel;

		public ArchivePage ()
		{
			InitializeComponent ();
			BindingContext = viewModel = new ArchiveViewModel();
		}
	}
}

