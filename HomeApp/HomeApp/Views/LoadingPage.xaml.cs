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
            Label header = new Label
            {
                Text = $"Запуск вашего первого приложения{Environment.NewLine} на Xamarin...",
                //стили и шрифт
                Opacity = 0,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.Cyan,
                FontSize = 21
            };
            //анимация
            header.FadeTo(1, 3000);
			//инициализация св-ва Content новым элементом
			Content = header;
		}
	}
}