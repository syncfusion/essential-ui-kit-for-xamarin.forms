using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Templates
{
    /// <summary>
    /// Review template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewTemplate : Grid
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewTemplate"/> class.
        /// </summary>
        public ReviewTemplate ()
		{
			InitializeComponent ();
		}
	}
}