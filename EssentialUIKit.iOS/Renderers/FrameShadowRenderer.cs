using EssentialUIKit.Controls;
using EssentialUIKit.iOS;
using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomShadowFrame), typeof(FrameShadowRenderer))]

namespace EssentialUIKit.iOS
{
    /// <summary>
    /// Customize the shadow effects of the Frame control in iOS to make the shadow effects looks similar to Android
    /// </summary>
    public class FrameShadowRenderer : FrameRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> element)
        {
            base.OnElementChanged(element);
            var customShadowFrame = (CustomShadowFrame)this.Element;
            if (customShadowFrame != null)
            {
                this.Layer.CornerRadius = customShadowFrame.Radius;
                this.Layer.ShadowOpacity = customShadowFrame.ShadowOpacity;
                this.Layer.ShadowOffset = new CGSize(customShadowFrame.ShadowOffsetWidth, customShadowFrame.ShadowOffSetHeight);
                this.Layer.Bounds.Inset(customShadowFrame.BorderWidth, customShadowFrame.BorderWidth);
                Layer.BorderColor = customShadowFrame.CustomBorderColor.ToCGColor();
                Layer.BorderWidth = (float)customShadowFrame.BorderWidth;
            }
        }
    }
}