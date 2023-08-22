using Xamarin.Forms;
using HomeApp.Views;

namespace HomeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FinalPage();//new LoadingPage();//new RegisterPage();//new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}