using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoomsPage : ContentPage
	{
		public static readonly string ADD_BUTTON_TEXT = "Добавить комнату";
		public RoomsPage ()
		{
			InitializeComponent ();
		}

		void RoomsAdd_Click(object sender, EventArgs e)
		{

		}
	}
}