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
    public partial class ClimatePage : ContentPage
    {
        public ClimatePage()
        {
            InitializeComponent();
            ScanOutside();
            ScanInside();
            GetPressure();
        }


        /// <summary>
        /// внутренние датчики
        /// </summary>
        void ScanInside()
        {
            absLayout.Children.Add(new BoxView { Color = Color.LightSalmon }, new Rectangle(130,10,100,70));
            absLayout.Children.Add(
                new Label
                {
                    Text = $"Inside",
                    VerticalTextAlignment = TextAlignment.Start,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 13
                }, new Rectangle(130,17,100,70));

            absLayout.Children.Add(
                new Label
                { 
                    Text = "+ 24 °C", 
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 20
                }, new Rectangle(130,15,100,70));
        }

        void ScanOutside()
        {
            absLayout.Children.Add(new BoxView { Color = Color.BlueViolet }, new Rectangle(10, 10, 100, 70));
            absLayout.Children.Add(
                new Label
                {
                    Text = $"Outside",
                    VerticalTextAlignment = TextAlignment.Start,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 13,
                }, new Rectangle(10, 17, 100, 70));
            absLayout.Children.Add(
                new Label
                {
                    Text = $"- 11 °C",
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 20
                }, new Rectangle(10, 15, 100, 70));
        }

        void GetPressure()
        {
            var box = new BoxView { Color = Color.BurlyWood };
            var boxPosition = new Rectangle(250, 10, 100, 70);
            var pressure = new Label { Text = "770 mm", VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Center, FontSize = 20 };
            var pressurePosition = new Rectangle(250, 15, 100, 70);
            var title = new Label { Text = "Pressure", VerticalTextAlignment = TextAlignment.Start, HorizontalTextAlignment = TextAlignment.Center, FontSize = 13 };
            var titlePosition = new Rectangle(250, 17, 100, 70);

            absLayout.Children.Add(box, boxPosition);
            absLayout.Children.Add(title, titlePosition);
            absLayout.Children.Add(pressure, pressurePosition);

        }
    }
}