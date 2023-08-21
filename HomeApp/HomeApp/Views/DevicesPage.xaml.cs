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
    public partial class DevicesPage : ContentPage
    {
        public DevicesPage()
        {
            InitializeComponent();
            GetDevices();
        }

        public void GetDevices()
        {
            List<string> homeDevices = new List<string>()
            {
                "Чайник",
                "Стиральная машина",
                "Посудомоечная машина",
                "Мутльтиварка",
                "Водонагреватель",
                "Плита",
                "Микроволновая печь",
                "Духовой шкаф",
                "Холодильник",
                "Увлажнитель воздуха",
                "Телевизор",
                "Пылесос",
                "Музыкальный центр",
                "Компьютер",
                "Игровая консоль"
            };

            var innerStack = new StackLayout();

            foreach(string device in homeDevices)
            {
                var deviceLabel = new Label()
                {
                    Text = $"{device}",
                    FontSize = 17,
                    Padding = new Thickness(10, 0)
                };

                // ?
                innerStack.Children.Add(new Label());
                innerStack.Children.Add(deviceLabel);
            }

            scrollView.Content = innerStack;
        }
    }
}