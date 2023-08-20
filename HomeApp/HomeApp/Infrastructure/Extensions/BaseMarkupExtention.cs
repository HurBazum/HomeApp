using System;
using Xamarin.Forms.Xaml;

namespace HomeApp.Infrastructure.Extensions
{
    class BaseMarkupExtention : IMarkupExtension
    {
        public virtual object ProvideValue(IServiceProvider serviceProvider)
        {
            return null;
        }
    }
}