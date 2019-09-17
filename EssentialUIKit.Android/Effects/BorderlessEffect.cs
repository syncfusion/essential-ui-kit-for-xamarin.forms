using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("EssentialUIKit")]
[assembly: ExportEffect(typeof(EssentialUIKit.Droid.Effects.BorderlessEffect), nameof(EssentialUIKit.Droid.Effects.BorderlessEffect))]
namespace EssentialUIKit.Droid.Effects
{
    public class BorderlessEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (this.Control != null)
            {
                this.Control.SetBackground(null);
                this.Control.SetPadding(0, 0, 0, 0);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}