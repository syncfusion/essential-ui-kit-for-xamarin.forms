using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("EssentialUIKit")]
[assembly: ExportEffect(typeof(EssentialUIKit.iOS.Effects.BorderlessEffect), nameof(EssentialUIKit.iOS.Effects.BorderlessEffect))]

namespace EssentialUIKit.iOS.Effects
{
    public class BorderlessEffect : PlatformEffect
    {
    
        protected override void OnAttached()
        {
            UITextField uITextField = this.Control as UITextField;
            if (uITextField != null)
            {
                uITextField.BorderStyle = UITextBorderStyle.None;
            }
        }

        protected override void OnDetached()
        {
            
        }
    }
}
