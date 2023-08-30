using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDevicePage : ContentPage
    {
        public NewDevicePage()
        {
            InitializeComponent();
            OpenEditor();
        }

        void OpenEditor()
        {
            // Создание однострочного текстового поля для названия
            var newDeviceName = new Entry
            {
                BackgroundColor = Color.AliceBlue,
                Margin = new Thickness(30, 10),
                Placeholder = "Название"
            };

            // Создание многострочного поля для описания
            var newDeviceDescription = new Editor
            {
                HeightRequest = 200,
                BackgroundColor = Color.AliceBlue,
                Margin = new Thickness(30, 10),
                Placeholder = "Описание"
            };

            // Создание заголовка для переключателя
            var switchHeader = new Label { Text = "Не использует газ", HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(0, 5, 0, 0) };

            // Создание переключателя
            Switch switchControl = new Switch
            {
                IsToggled = false,
                HorizontalOptions= LayoutOptions.Center,
                ThumbColor = Color.DodgerBlue,
                OnColor = Color.LightSteelBlue
            };

            switchControl.Toggled += (s, e) => SwitchHandler(s, e, switchHeader);

            stackLayout.Children.Add(switchHeader);
            stackLayout.Children.Add(switchControl);

            // Создание кнопки
            var addButton = new Button
            {
                Text = "Добавить",
                Margin = new Thickness(30, 10),
                BackgroundColor = Color.Silver
            };

            // Добавляем всё на страницу
            stackLayout.Children.Add(newDeviceName);
            stackLayout.Children.Add(newDeviceDescription);
            stackLayout.Children.Add(addButton);
        }

        void SwitchHandler(object sender, ToggledEventArgs e, Label header)
        {
            if(!e.Value)
            {
                header.Text = "Не использует газ";
                return;
            }

            header.Text = "Использует газ";
        }
    }
}