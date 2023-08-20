using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestPage : ContentPage
	{
		public TestPage ()
        {
            Content = GetStackLayout();
        }

        #region get elements
        Label GetLabel ()
        {
            Label label = new Label()
            {
                TextColor = Color.Crimson,
                FontSize = 16,
                Padding = new Thickness(30, 24, 30, 0),
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FormattedText = new FormattedString()
                {
                    Spans =
                    {
                        new Span() { Text = "Learn mare at" },
                        new Span() { Text = $"{Environment.NewLine}" },
                        new Span() { Text = "https://aka.ms/xamarin-quickstart", FontAttributes = FontAttributes.Bold }
                    }
                }

            };

            return label;
        }

        Button GetButton ()
        {
            Button button = new Button()
            {
                Text = "OK"
            };

            return button;
        }

        StackLayout GetStackLayout()
        {
            var stack = new StackLayout()
            {
                Spacing = 20,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    GetLabel(),
                    GetButton()
                }
            };

            return stack;
        }

        #endregion
    }
}