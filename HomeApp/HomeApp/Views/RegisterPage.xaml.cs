using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent();
			PlatformAdjust();
		}

		private void RegisterButton_Clicked(object sender, System.EventArgs e)
		{
			if (registerEntry.Text != null)
			{
				if (registerEntry.Text == "mail@mail.ru")
				{
					errorMessage.Text = "Already have an account";
				}
				else
				{
					eventMessage.Text = $"Welcome, {registerEntry.Text}!";
				}
			}
		}

		void PlatformAdjust()
		{
			if (Device.RuntimePlatform == Device.UWP)
			{
				registerEntry.PlaceholderColor = Color.SlateGray;
				registerButton.TextColor = Color.AliceBlue;
				registerButton.Margin = new Thickness(0, 5);
                registerButton.BackgroundColor = Color.FromRgba(4, 4, 255, 0.12);
				
            }
			if(Device.RuntimePlatform == Device.Android)
			{
				registerButton.BackgroundColor = Color.FromRgba(4, 4, 255, 0.12);
			}
		}
	}
}