using EssentialUIKit.ViewModels.ErrorAndEmpty;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.ErrorAndEmpty
{
    /// <summary>
    /// Page to show the no tasks
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoTasksPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoTasksPage" /> class.
        /// </summary>
        public NoTasksPage()
        {
            this.InitializeComponent();
            this.BindingContext = NoTasksPageViewModel.BindingContext;
        }
    }
}