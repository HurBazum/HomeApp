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
		MarkupDelegate markupDelegate { get; set; }

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

			// для изменения углов кнопки
            var buttonBorder = new ButtonViewExtension() { ButtonStyle = Infrastructure.Enums.ButtonStyle.SemiRound };
			markupDelegate = buttonBorder.ProvideValue;

            if (loginCounter == 0)
			{
                // Если первая попытка - просто меняем сообщения
                loginButton.Text = "Выполняется вход...";
                button.CornerRadius = (int)markupDelegate.Invoke(serviceProvider);
            }
			else if(loginCounter > 5) 
			{
				// Деактивируем кнопку
				loginButton.IsEnabled = false;

				// для цвета сообщения об ошибке
				var colorRgb = new ColorFromRGBExtention() { Red = 201, Green = 134, Blue = 12 };

				// добавляем метод в делегат
				markupDelegate += colorRgb.ProvideValue;

				stackLayout.Children.Add(new Label
				{
					Text = "Слишком много попыток! Попробуйте позже.",
					TextColor = (Color)markupDelegate.GetInvocationList().ElementAt(1).DynamicInvoke(serviceProvider), // ColorFromRGBExtention.ProvideValue()
					VerticalTextAlignment = TextAlignment.Center,
					HorizontalTextAlignment = TextAlignment.Center,
					Padding = new Thickness()
					{
						Bottom = 30,
						Left = 10,
						Top = 30,
						Right = 10
					}
				});

				buttonBorder.ButtonStyle = Infrastructure.Enums.ButtonStyle.Default;

				button.CornerRadius = (int)markupDelegate.GetInvocationList().ElementAt(0).DynamicInvoke(serviceProvider); // ButtonViewExtention.ProvideValue()
			}
			else
			{
				loginButton.Text = $"Выполняется вход... Попыток входа: {loginCounter}";
			}

			loginCounter++;
		}


	}
}