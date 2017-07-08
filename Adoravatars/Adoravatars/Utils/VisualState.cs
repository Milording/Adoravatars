using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro;

namespace Adoravatars.Utils
{
    public static class VisualState
    {
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached(
                "Value",
                typeof(string),
                typeof(VisualState),
                new PropertyMetadata(string.Empty, ValuePropertyChanged));

        private static async void ValuePropertyChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            var control = element as Control;
            if (control == null || e.NewValue == null) return;

            await Execute.OnUIThreadAsync(() => VisualStateManager.GoToState(control, e.NewValue.ToString(), true));
        }

        public static async void SetValue(DependencyObject element, string value)
        {
            var control = element as Control;
            if (control == null || value == null) return;

            await Execute.OnUIThreadAsync(() => VisualStateManager.GoToState(control, value, true));
        }

        public static string GetValue(DependencyObject element)
        {
            var value = (string)element.GetValue(ValueProperty);
            return value;
        }
    }
}
