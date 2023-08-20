using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HomeApp.Infrastructure.Enums;

namespace HomeApp.Infrastructure.Extensions
{
    class ButtonViewExtension : BaseMarkupExtention
    {
        public ButtonStyle ButtonStyle { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            switch (ButtonStyle)
            {
                case ButtonStyle.Default:
                    return 0;
                case ButtonStyle.SemiRound:
                    return 15;
                case ButtonStyle.Round:
                    return 30;
                default: 
                    return 0;
            }
        }
    }
}