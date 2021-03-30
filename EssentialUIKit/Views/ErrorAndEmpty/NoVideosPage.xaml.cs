using EssentialUIKit.ViewModels.ErrorAndEmpty;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.ErrorAndEmpty
{
    /// <summary>
    /// Page to show no videos
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoVideosPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoVideosPage" /> class.
        /// </summary>
        public NoVideosPage()
        {
            this.InitializeComponent();
            this.BindingContext = NoVideosPageViewModel.BindingContext;
        }
    }
}