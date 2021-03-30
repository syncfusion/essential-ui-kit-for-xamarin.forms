using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Templates
{
    /// <summary>
    /// Task notification template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskNotificationTemplate : Grid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskNotificationTemplate"/> class.
        /// </summary>
        public TaskNotificationTemplate()
        {
            this.InitializeComponent();
        }
    }
}