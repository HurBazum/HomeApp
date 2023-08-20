using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadingPage : ContentPage
	{
		public LoadingPage ()
		{
			Label header = new Label()
			{
				Text = $"Запуск вашего первого приложения{Environment.NewLine} на Xamarin..."
			};
			//стили и шрифт
			header.Opacity = 0;
			header.HorizontalTextAlignment = TextAlignment.Center;
			header.VerticalTextAlignment = TextAlignment.Center;
			header.TextColor = Color.Cyan;
			header.FontSize = 21;
			//анимация
			header.FadeTo(1, 3000);
			//инициализация св-ва Content новым элементом
			Content = header;
		}
	}
}