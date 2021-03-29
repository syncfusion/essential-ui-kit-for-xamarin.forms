using EssentialUIKit.ViewModels.ErrorAndEmpty;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.ErrorAndEmpty
{
    /// <summary>
    /// Page to show the not enough credit
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotEnoughCreditPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotEnoughCreditPage" /> class.
        /// </summary>
        public NotEnoughCreditPage()
        {
            this.InitializeComponent();
            this.BindingContext = NotEnoughCreditPageViewModel.BindingContext;
        }
    }
}