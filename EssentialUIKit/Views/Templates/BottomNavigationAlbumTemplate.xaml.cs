using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Templates
{
    /// <summary>
    /// Bottom navigation page album tab section tile template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomNavigationAlbumTemplate : Grid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BottomNavigationAlbumTemplate"/> class.
        /// </summary>
        public BottomNavigationAlbumTemplate()
        {
            this.InitializeComponent();
        }
    }
}