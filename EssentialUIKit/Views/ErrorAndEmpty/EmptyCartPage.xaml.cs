using EssentialUIKit.ViewModels.ErrorAndEmpty;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.ErrorAndEmpty
{
    /// <summary>
    /// Page to show the empty cart
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmptyCartPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyCartPage" /> class.
        /// </summary>
        public EmptyCartPage()
        {
            this.InitializeComponent();
            this.BindingContext = EmptyCartPageViewModel.BindingContext;
        }
    }
}