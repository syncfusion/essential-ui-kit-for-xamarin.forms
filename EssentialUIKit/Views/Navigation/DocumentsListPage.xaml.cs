using EssentialUIKit.DataService;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Navigation
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DocumentsListPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentsPage" /> class.
        /// </summary>
        public DocumentsListPage()
        {
            this.InitializeComponent();
            this.BindingContext = DocumentsListDataService.Instance.DocumentsViewModel;
        }
    }
}