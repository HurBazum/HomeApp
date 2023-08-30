using HomeApp.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
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

        /// <summary>
        /// метод выгрузки устройств
        /// </summary>
        public void GetDevices()
        {
            var homeDevices = new List<HomeDevice>()
            {
                new HomeDevice("Чайник", "kettle.jpg"),
                new HomeDevice("Стиральная машина"),
                new HomeDevice("Посудомоечная машина"),
                new HomeDevice("Мутльтиварка"),
                new HomeDevice("Водонагреватель"),
                new HomeDevice("Плита"),
                new HomeDevice("Микроволновая печь"),
                new HomeDevice("Духовой шкаф"),
                new HomeDevice("Холодильник"),
                new HomeDevice("Увлажнитель воздуха"),
                new HomeDevice("Телевизор"),
                new HomeDevice("Пылесос"),
                new HomeDevice("Музыкальный центр"),
                new HomeDevice("Компьютер"),
                new HomeDevice("Игровая консоль")
            };

            var innerStack = new StackLayout();

            foreach(var device in homeDevices)
            {
                var deviceLabel = new Label() { Text = device.Name, FontSize = 17 };

                var frame = new Frame
                {
                    BorderColor = Color.Gray,
                    BackgroundColor = Color.FromHex("#e1e1e1"),
                    CornerRadius = 4,
                    Margin = new Thickness(10, 1),
                    Content = deviceLabel
                };


                // создаём объект, отвечающий за распознавание нажатий
                var gesture = new TapGestureRecognizer();

                // Устанавливаем по событию нажатия вызщов метода  ShowImage()
                // со ссылкой на изображение в качестве аргумента
                gesture.Tapped += async (s, e) =>
                {
                    ShowImage(s, e, device.Image);
                };

                // Добавляем настроенный распознаватель нажатий в текущий фрейм
                frame.GestureRecognizers.Add(gesture);

                // Добавляем фрейм в стек для его отображения в едином списке по 
                // по порядку
                innerStack.Children.Add(frame);

            }

            scrollView.Content = innerStack;
        }

        public void ShowImage(object sender, EventArgs e, string imageName)
        {
            // Если изображение отсутствует - показываем информационное окно
            if (string.IsNullOrEmpty(imageName))
            {
                Image imageEmpty = new Image
                {
                    Source = new UriImageSource
                    {
                        Uri = new Uri("https://i.stack.imgur.com/y9DpT.jpg"),
                        CachingEnabled = false
                    }
                };

                Content = imageEmpty;
                return;
            }

            // При наличии изображения - загружаеи его по заданному пути
            Image image = new Image
            {
                // !!! Действие при сборке - встроенный ресурс
                Source = ImageSource.FromResource($"HomeApp.Infrastructure.Images.{imageName}")
            };

            Content = image;
        }
    }
}