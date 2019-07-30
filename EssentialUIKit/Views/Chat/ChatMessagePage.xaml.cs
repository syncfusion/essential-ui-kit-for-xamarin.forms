using Syncfusion.DataSource;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using EssentialUIKit.Models.Chat;

namespace EssentialUIKit.Views.Chat
{
    /// <summary>
    /// Page to show chat message list
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatMessagePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChatMessagePage" /> class.
        /// </summary>
        public ChatMessagePage()
        {
            this.InitializeComponent();

            ListView.DataSource.GroupDescriptors.Add(new GroupDescriptor
            {
                PropertyName = "Time",
                KeySelector = obj =>
                {
                    var item = obj as ChatMessage;
                    return item.Time.Date;
                }
            });
        }
    }
}