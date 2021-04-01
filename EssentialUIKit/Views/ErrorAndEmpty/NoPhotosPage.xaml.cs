using EssentialUIKit.ViewModels.ErrorAndEmpty;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.ErrorAndEmpty
{
    /// <summary>
    /// Page to show the no photos
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoPhotosPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoPhotosPage" /> class.
        /// </summary>
        public NoPhotosPage()
        {
            this.InitializeComponent();
            this.BindingContext = NoPhotosPageViewModel.BindingContext;
        }
    }
}