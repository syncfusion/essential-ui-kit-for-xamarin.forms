using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Triggers
{
    /// <summary>
    /// This class extends the behavior of the SfButton control to invoke a command when a click event triggers.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ButtonTextTriggerAction : TriggerAction<SfButton>
    {
        /// <summary>
        /// Change the button text when the click event is triggered
        /// </summary>
        /// <param name="button">The button to change text</param>
        protected override void Invoke(SfButton button)
        {
            if (button != null)
            {
                if (button.Text == "FOLLOW")
                {
                    button.Text = "FOLLOWED";
                }
                else if (button.Text == "FOLLOWED")
                {
                    button.Text = "FOLLOW";
                }
            }
        }
    }
}
