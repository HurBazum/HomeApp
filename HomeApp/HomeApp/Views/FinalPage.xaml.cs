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
	public partial class FinalPage : ContentPage
	{
		public FinalPage ()
		{
			InitializeComponent();
			Content = GetStart();
		}

        #region relative layout
        RelativeLayout GetBody()
		{
			var relativeLayout = new RelativeLayout();

            #region inside block

            relativeLayout.Children.Add(
				new BoxView { Color = Color.DarkOliveGreen },
				Constraint.RelativeToParent((parent) => { return 0; }), // x
				Constraint.RelativeToParent((parent) => { return 0; }), // y
				Constraint.RelativeToParent((parent) => { return parent.Width; }), // width
				Constraint.RelativeToParent((parent) => { return parent.Height * 0.337; })); //height

			relativeLayout.Children.Add(
				new Label { Text = "Inside", FontSize = 50, HorizontalTextAlignment = TextAlignment.Center, 
					VerticalTextAlignment = TextAlignment.Center, Padding = new Thickness(10, 20) },
				Constraint.RelativeToParent((parent) => { return 0; }), // x
				Constraint.RelativeToParent((parent) => { return 0; }), // y
				Constraint.RelativeToParent((parent) => { return parent.Width; }));

			relativeLayout.Children.Add(
				new Label { Text= "+ 26 °C", FontSize= 70, HorizontalTextAlignment = TextAlignment.Center, 
				VerticalTextAlignment = TextAlignment.Center, Padding = new Thickness(10,20) },
				Constraint.RelativeToParent((parent) => { return 0; }),
				Constraint.RelativeToParent((parent) => { return parent.Height * 0.168; }),
				Constraint.RelativeToParent((parent) => { return parent.Width; }));

            #endregion

            #region outside block

            relativeLayout.Children.Add(
				new BoxView { Color = Color.Aquamarine },
				Constraint.RelativeToParent((parent) => { return 0; }), // x
				Constraint.RelativeToParent((parent) => { return parent.Height * 0.337; }), // y
				Constraint.RelativeToParent((parent) => { return parent.Width; }), // width
				Constraint.RelativeToParent((parent) => { return parent.Height * 0.337; })); //height
            
            relativeLayout.Children.Add(
                new Label
                {
                    Text = "Outside",
                    FontSize = 50,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    Padding = new Thickness(10, 20)
                },
                Constraint.RelativeToParent((parent) => { return 0; }), // x
                Constraint.RelativeToParent((parent) => { return parent.Height * 0.337; }), // y
                Constraint.RelativeToParent((parent) => { return parent.Width; }));

            relativeLayout.Children.Add(
                new Label
                {
                    Text = "- 14 °C",
                    FontSize = 70,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    Padding = new Thickness(10, 20)
                },
                Constraint.RelativeToParent((parent) => { return 0; }),
                Constraint.RelativeToParent((parent) => { return parent.Height * 0.505; }),
                Constraint.RelativeToParent((parent) => { return parent.Width; }));

            #endregion

            #region pressure block

            relativeLayout.Children.Add(
                new BoxView { Color = Color.Bisque },
                Constraint.RelativeToParent((parent) => { return 0; }), // x
                Constraint.RelativeToParent((parent) => { return parent.Height * 0.667; }), // y
                Constraint.RelativeToParent((parent) => { return parent.Width; }), // width
                Constraint.RelativeToParent((parent) => { return parent.Height * 0.337; })); //height
           
            relativeLayout.Children.Add(
                new Label
                {
                    Text = "Pressure",
                    FontSize = 50,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    Padding = new Thickness(10, 20)
                },
                Constraint.RelativeToParent((parent) => { return 0; }), // x
                Constraint.RelativeToParent((parent) => { return parent.Height * 0.667; }), // y
                Constraint.RelativeToParent((parent) => { return parent.Width; }));

            relativeLayout.Children.Add(
                new Label
                {
                    Text = "770 mm",
                    FontSize = 70,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    Padding = new Thickness(10, 20)
                },
                Constraint.RelativeToParent((parent) => { return 0; }),
                Constraint.RelativeToParent((parent) => { return parent.Height * 0.835; }),
                Constraint.RelativeToParent((parent) => { return parent.Width; }));

            #endregion

            return relativeLayout;
		}
        #endregion

        #region start layout
        StackLayout GetStart()
        {
            var stackLayout = new StackLayout()
            {
                WidthRequest = 400,
                HeightRequest = 1000,
                BackgroundColor = Color.LemonChiffon
            };

            stackLayout.HorizontalOptions = LayoutOptions.Center;
            stackLayout.VerticalOptions = LayoutOptions.Center;

            Button button = new Button
            {
                Text = "GET WEATHER"
            };

            button.Clicked += (s, e) =>
            {
                Content = GetBody();
            };

            stackLayout.Children.Add(button);

            return stackLayout;
        }

        #endregion
    }
}