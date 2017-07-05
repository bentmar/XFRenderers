using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hello
{
    public class MaterialButton : Button
    {
        public static readonly BindableProperty IsFlatProperty = BindableProperty.Create("IsFlat", typeof(bool), typeof(XFCheckbox), false, BindingMode.OneWay);
        public bool IsFlat
        {
            get { return (bool)GetValue(IsFlatProperty); }
            set { SetValue(IsFlatProperty, value); }
        }
    }
}
