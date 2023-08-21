using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestPage : ContentPage
	{
		public TestPage ()
        {
            InitializeComponent();
            GetStackLayout();
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
                        new Span() { Text = "Learn more at" },
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
                Text = "CHANGE IT"
            };

            // удаляет и добавляет элементы на странице
            button.Clicked += (s, e) =>
            {
                if (!(s is Button b))
                {
                    return;
                }

                if (testStack.Children[0] != b)
                {
                    testStack.Children.RemoveAt(0);
                    ChangePage();
                }
                else
                {
                    testStack.Children.RemoveAt(1);
                    testStack.Children.Insert(0, GetLabel());
                }
            };

            return button;
        }

        void GetStackLayout()
        {
            testStack.Children.Add(GetLabel());
            testStack.Children.Add(GetButton());
        }

        #endregion

        #region change elements
        void ChangePage()
        {
            testStack.Children.Add(
                new Label { Text = "Вы нажали на кнопку!", HorizontalTextAlignment = TextAlignment.Center });
        }
        #endregion
    }
}