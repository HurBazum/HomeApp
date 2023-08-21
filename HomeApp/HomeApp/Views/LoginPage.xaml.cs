using HomeApp.Infrastructure.Extensions;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		// делегат для изменения стилей объектов посредством extentions
		delegate object MarkupDelegate(IServiceProvider serviceProvider);
		MarkupDelegate Markuper { get; set; }

		// Константа для текста кнопки
		public const string BUTTON_TEXT = "Войти";

		// Переменная счётчика
		public static int loginCounter = 0;

		public LoginPage ()
		{
			InitializeComponent();
        }

		/// <summary>
		/// По клику обрабатываем счётчик и выводим разные сообщения
		/// </summary>
		void Login_Click(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;

            if (button == null)
            {
                return;
            }


            // для работы с делегатами
            // ?
            IServiceProvider serviceProvider = sender as IServiceProvider;

            if (loginCounter == 0)
			{
                // Если первая попытка - просто меняем сообщения
                loginButton.Text = "Выполняется вход...";
            }
			else if(loginCounter > 5) 
			{
				// Деактивируем кнопку
				loginButton.IsEnabled = false;

				// для цвета сообщения об ошибке
				var colorRgb = new ColorFromRGBExtention() { Red = 201, Green = 134, Blue = 12 };

				// добавляем метод в делегат
				Markuper = colorRgb.ProvideValue;


				infoMessage.TextColor = (Color)Markuper.GetInvocationList().ElementAt(0).DynamicInvoke(serviceProvider); // ColorFromRGBExtention.ProvideValue()

                infoMessage.Text = "Слишком много попыток! Попробуйте позже.";
			}
			else
			{
				loginButton.Text = $"Выполняется вход... Попыток входа: {loginCounter}";
			}

			loginCounter++;
		}
	}
}