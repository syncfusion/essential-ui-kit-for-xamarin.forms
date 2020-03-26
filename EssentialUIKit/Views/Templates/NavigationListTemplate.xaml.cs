using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Templates
{
    /// <summary>
    /// Navigation list template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationListTemplate : Grid
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationListTemplate"/> class.
        /// </summary>
		public NavigationListTemplate ()
		{
			InitializeComponent ();
		}
	}
}