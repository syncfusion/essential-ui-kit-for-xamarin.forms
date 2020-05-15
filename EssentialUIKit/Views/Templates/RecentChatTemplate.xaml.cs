using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Templates
{
    /// <summary>
    /// Recent chat page contact's template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecentChatTemplate : Grid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecentChatTemplate"/> class.
        /// </summary>
		public RecentChatTemplate()
        {
            InitializeComponent();
        }
    }
}