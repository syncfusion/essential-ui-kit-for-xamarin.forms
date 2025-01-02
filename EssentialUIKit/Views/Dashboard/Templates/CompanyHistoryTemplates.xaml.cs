using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Dashboard
{
    /// <summary>
    /// Class helps to reduce repetitive markup, and allows an apps appearance to be more easily changed.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanyHistoryTemplates 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyHistoryTemplates" /> class.
        /// </summary>
        public CompanyHistoryTemplates()
        {
            InitializeComponent();
        }
    }
}