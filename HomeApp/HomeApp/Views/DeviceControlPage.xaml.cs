using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceControlPage : ContentPage
    {
        public DeviceControlPage()
        {
            InitializeComponent();
            GetContent();
        }

        void GetContent()
        {
            #region Виджет выбора даты

            var datePicker = new DatePicker
            {
                Format = "D",
                // Диапазон дат: +/- неделя
                MaximumDate = DateTime.Now.AddDays(7),
                MinimumDate = DateTime.Now.AddDays(-7)
            };

            var datePickerText = new Label { Text = "Дата запуска ", Margin = new Thickness(0,20,0,0) };
            stackLayout.Children.Add(new Label { Text = "Устройство" });
            stackLayout.Children.Add(new Entry { BackgroundColor = Color.AliceBlue, Text = "Холодильник" });
            stackLayout.Children.Add(datePickerText);
            stackLayout.Children.Add(datePicker);
            #endregion

            #region Виджет выбора времени
            var timePickerText = new Label { Text = "Время запуска ", Margin = new Thickness(0, 20, 0, 0) };
            var timePicker = new TimePicker
            {
                Time = new TimeSpan(13,0,0)
            };

            stackLayout.Children.Add(timePickerText);
            stackLayout.Children.Add(timePicker);

            #endregion

            #region Напряжение
            //Создаём меню выбора в виде выпадающего списка с текстовым заголовком
            var pickerText = new Label { Text = "Напряжение сети, В", Margin = new Thickness(0, 20, 0, 0) };
            
            var picker = new Picker 
            {
                Title = "Выберите напряжение сети"
            };

            //Добавляем значения выпадающего списка для пользовательского выбора
            picker.Items.Add("220");
            picker.Items.Add("120");

            stackLayout.Children.Add(pickerText);
            stackLayout.Children.Add(picker);
            #endregion

            #region Переключатель(stepper)
            //// Установим текст текущего значения переключателя Stepper
            //var stepperText = new Label { Text = "Температура: 5.0 °C", HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(0, 30, 0, 0) };

            //// Установим сам переключатель
            //var stepper = new Stepper
            //{
            //    Minimum = -30,
            //    Maximum = 30,
            //    Increment = 1,
            //    Value = 5,
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.CenterAndExpand
            //};

            //stepper.ValueChanged += (s, e) => TempChangedHandler(s, e, stepperText);

            //stackLayout.Children.Add(stepperText);
            //stackLayout.Children.Add(stepper);

            #endregion

            #region Переключатель(slider)
            Slider slider = new Slider
            {
                Minimum = -30,
                Maximum = 30,
                Value = 5,
                ThumbColor = Color.DodgerBlue,
                MinimumTrackColor = Color.DodgerBlue,
                MaximumTrackColor = Color.Gray
            };

            var sliderText = new Label { Text = $"Температура: {slider.Value} °C", HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(0, 30, 0, 0) };

            slider.ValueChanged += (s, e) => TempChangedHandler(s, e, sliderText);

            stackLayout.Children.Add(sliderText);
            stackLayout.Children.Add(slider);

            #endregion

            stackLayout.Children.Add(new Button { Text = "Сохранить", BackgroundColor = Color.Silver, Margin = new Thickness(0, 5, 0, 0) });

            // Регистрируем обработчик события выбора даты
            datePicker.DateSelected += (s, e) => DateSelectedHandler(s, e, datePickerText);
            timePicker.PropertyChanged += (s, e) => TimeChangedHandler(s, e, timePickerText, timePicker);
        }

        /// <summary>
        /// Обработчик изменения даты
        /// </summary>
        void DateSelectedHandler(object sender, DateChangedEventArgs e, Label datePickerText)
        {
            // При срабатывании выбора - будет меняться информационное сообщение
            datePickerText.Text = "Запустится " + e.NewDate.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Обработчик изменения времени
        /// </summary>
        void TimeChangedHandler(object sender, PropertyChangedEventArgs e, Label timePickerText, TimePicker timePicker)
        {
            // Обновляем текст сообщения, когда появляется новое значение времени
            if(e.PropertyName == "Time")
            {
                timePickerText.Text = "В " + timePicker.Time;
            }
        }

        /// <summary>
        /// Обработчик изменения температуры
        /// </summary>
        void TempChangedHandler(object sender, ValueChangedEventArgs e, Label header)
        {
            header.Text = string.Format("Температура: {0:F1}°C", e.NewValue);
        }
    }
}