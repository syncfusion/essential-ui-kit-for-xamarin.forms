using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Detail
{
    /// <summary>
    /// The Feedback view
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingFeedbackView 
    {
        /// <summary>
        /// Bindable property to set the parent bindingcontext.
        /// </summary>
        public static BindableProperty ParentBindingContextProperty =
         BindableProperty.Create(nameof(ParentBindingContext), typeof(object),
         typeof(BookingFeedbackView), null);

        /// <summary>
        /// Gets or sets the parent bindingcontext.
        /// </summary>
        public object ParentBindingContext
        {
            get { return GetValue(ParentBindingContextProperty); }
            set { SetValue(ParentBindingContextProperty, value); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingFeedbackView" /> class.
        /// </summary>
        public BookingFeedbackView()
        {
            InitializeComponent();
        }
    }
}