using EssentialUIKit.ViewModels.ErrorAndEmpty;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.ErrorAndEmpty
{
    /// <summary>
    /// Page to show the something went wrong
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SomethingWentWrongPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SomethingWentWrongPage" /> class.
        /// </summary>
        public SomethingWentWrongPage()
        {
            this.InitializeComponent();
            this.BindingContext = SomethingWentWrongPageViewModel.BindingContext;
        }
    }
}