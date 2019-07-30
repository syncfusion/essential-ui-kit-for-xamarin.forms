using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.AppLayout.Controls
{
    [Preserve(AllMembers = true)]
    public class TemplateHostView : View
    {
        public Page Template { get; set; }
    }
}