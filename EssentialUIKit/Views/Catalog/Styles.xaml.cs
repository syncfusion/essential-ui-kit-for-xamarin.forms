using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Catalog
{
    /// <summary>
    /// Class helps to reduce repetitive markup, and allows an apps appearance to be more easily changed.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Styles
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Styles" /> class.
        /// </summary>
        public Styles()
        {
            InitializeComponent();
        }
    }
}