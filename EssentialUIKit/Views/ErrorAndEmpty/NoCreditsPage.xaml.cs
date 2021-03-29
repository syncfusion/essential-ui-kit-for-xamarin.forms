using EssentialUIKit.ViewModels.ErrorAndEmpty;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.ErrorAndEmpty
{
    /// <summary>
    /// Page to show the no credits
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoCreditsPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoCreditsPage" /> class.
        /// </summary>
        public NoCreditsPage()
        {
            this.InitializeComponent();
            this.BindingContext = NoCreditsPageViewModel.BindingContext;
        }
    }
}