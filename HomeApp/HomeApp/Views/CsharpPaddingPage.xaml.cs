using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CsharpPaddingPage : ContentPage
    {
        public CsharpPaddingPage()
        {
            var stackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(60),
                Children =
                {
                    new BoxView { Color = Color.SkyBlue },
                    new BoxView { Color = Color.LightSteelBlue },
                    new BoxView { Color = Color.MediumTurquoise },
                    new BoxView { Color = Color.SteelBlue }
                }
            };

            // добавление св-в для всех потомков одного типа
            stackLayout.Resources.Add(
                new Style(typeof(BoxView)) 
                { 
                    Setters = 
                    { 
                        new Setter()
                        { 
                            Property = BoxView.MarginProperty,
                            Value = new Thickness(10) 
                        } 
                    } 
                });

            Content = stackLayout;
        }
    }
}