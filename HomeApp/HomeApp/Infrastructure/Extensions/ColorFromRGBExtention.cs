using System;
using Xamarin.Forms;

namespace HomeApp.Infrastructure.Extensions
{
    class ColorFromRGBExtention : BaseMarkupExtention
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Color.FromRgb(Red, Green, Blue);
        }
    }
}