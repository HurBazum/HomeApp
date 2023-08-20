using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
		}

        private void RegisterButton_Clicked(object sender, System.EventArgs e)
        {
			if(registerEntry.Text != null) 
			{
				if(registerEntry.Text == "mail@mail.ru")
				{
					errorMessage.Text = "Already have an account";
				}
				else
				{
					eventMessage.Text = $"Welcome, {registerEntry.Text}!";
				}
			}
        }
    }
}