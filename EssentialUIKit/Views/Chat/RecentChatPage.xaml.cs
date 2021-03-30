using EssentialUIKit.ViewModels.Chat;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Chat
{
    /// <summary>
    /// Page to show recent chat list.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecentChatPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecentChatPage" /> class.
        /// </summary>
        public RecentChatPage()
        {
            this.InitializeComponent();
            this.BindingContext = RecentChatViewModel.BindingContext;
        }
    }
}