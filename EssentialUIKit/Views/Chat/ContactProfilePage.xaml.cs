using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Chat
{
    /// <summary>
    /// Page to show Contact profile page
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactProfilePage
    {
        public ContactProfilePage()
        {
            this.InitializeComponent();
            this.ProfileImage.Source = App.BaseImageUrl + "ContactProfileImage.png";
        }
    }
}