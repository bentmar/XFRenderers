using UIKit;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;
using XFRenderers.iOS.Renderers;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Frame), typeof(CardViewRenderer))]
namespace XFRenderers.iOS.Renderers
{   
   /* Elegant looking frame (CardView) on iOS
    * This totally ignores some Element properties
      with minor modifications to this post http://stackoverflow.com/a/40820035 */

    public class CardViewRenderer : FrameRenderer
    {
        public override void Draw(CGRect rect)
        {
            SetupShadowLayer();
            base.Draw(rect);
        }

        void SetupShadowLayer()
        {
            Layer.CornerRadius = 2; // 5 Default
            if (Element.BackgroundColor == Xamarin.Forms.Color.Default)
            {
                Layer.BackgroundColor = UIColor.White.CGColor;
            }
            else
            {
                Layer.BackgroundColor = Element.BackgroundColor.ToCGColor();
            }

            Layer.ShadowRadius = 2; // 5 Default
            Layer.ShadowColor = UIColor.Black.CGColor;
            Layer.ShadowOpacity = 0.2f; // 0.8f Default
            Layer.ShadowOffset = new CGSize(0f, 2.5f);

            if (Element.OutlineColor == Xamarin.Forms.Color.Default)
            {
                Layer.BorderColor = UIColor.Clear.CGColor;
            }
            else
            {
                Layer.BorderColor = Element.OutlineColor.ToCGColor();
                Layer.BorderWidth = 1;
            }

            Layer.RasterizationScale = UIScreen.MainScreen.Scale;
            Layer.ShouldRasterize = true;

        }
    }
}