
using Android.Views;
using Xamarin.Forms;

using Android.Support.V7.Widget;

using Android.Support.V4.Graphics.Drawable;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android.AppCompat;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using System.ComponentModel;
using System;

[assembly: ExportRenderer(typeof(MaterialButton), typeof(MaterialButtonRenderer))]
namespace Hello.Android
{
    public class MaterialButtonRenderer : Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer
    {
        AppCompatButton btn;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Android.OS.Build.VERSION.SdkInt <= Android.OS.BuildVersionCodes.Kitkat)
                return;

            if (e.OldElement != null)
            {
                btn.Click -= Btn_Click;
            }

            if (e.NewElement != null)
            {
                btn = new AppCompatButton(base.Context);
                btn.Click += Btn_Click;
                btn.SetTextColor(Element.TextColor.ToAndroid());
                btn.Enabled = Element.IsEnabled;
               
                if (((MaterialButton)Element).IsFlat)
                    btn.StateListAnimator = new Android.Animation.StateListAnimator();

                Drawable drawable = DrawableCompat.Wrap(btn.Background);
                DrawableCompat.SetTint(drawable.Mutate(), Element.BackgroundColor.ToAndroid());

                SetNativeControl(btn);

                SetTextColor(btn.Enabled);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "IsEnabled" && Control != null)
            {
                Control.Enabled = Element.IsEnabled;

                SetTextColor(Control.Enabled);
            }
        }

        private void SetTextColor(bool enabled)
        {
            if (enabled)
                Control.SetTextColor(Element.TextColor.ToAndroid());
            else
                Control.SetTextColor(Element.TextColor.MultiplyAlpha(0.5).ToAndroid());
        }

        private void Btn_Click(object sender, System.EventArgs e)
        {
            Element.Command?.Execute(Element.CommandParameter ?? null);
        }

    }
}