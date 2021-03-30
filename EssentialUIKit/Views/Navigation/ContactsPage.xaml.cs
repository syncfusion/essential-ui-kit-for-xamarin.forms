using EssentialUIKit.DataService;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Navigation
{
    /// <summary>
    /// Page to display the Contacts list.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactsPage" /> class.
        /// </summary>
        public ContactsPage()
        {
            this.InitializeComponent();
            this.BindingContext = ContactsDataService.Instance.ContactsViewModel;
        }
    }
}