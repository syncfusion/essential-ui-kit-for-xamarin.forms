using System.Collections.ObjectModel;
using EssentialUIKit.Models.Chat;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Chat
{
    /// <summary>
    /// View model for recent chat page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class RecentChatViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<ChatDetail> chatItems;

        private string profileImage = App.BaseImageUrl + "ProfileImage1.png";

        private Command itemSelectedCommand;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="RecentChatViewModel" /> class.
        /// </summary>
        public RecentChatViewModel()
        {
            this.ChatItems = new ObservableCollection<ChatDetail>
            {
                new ChatDetail
                {
                    ImagePath = App.BaseImageUrl + "ProfileImage2.png",
                    SenderName = "Alice Russell",
                    MessageType = "Text",
                    Message = "https://app.syncfusion",
                    Time = "15 min",
                    NotificationType = "New"
                },
                new ChatDetail
                {
                    ImagePath = App.BaseImageUrl + "ProfileImage3.png",
                    SenderName = "Danielle Schneider",
                    MessageType = "Audio",
                    Time = "23 min",
                    AvailableStatus = "Available",
                    NotificationType = "Viewed"
                },
                new ChatDetail
                {
                    ImagePath = App.BaseImageUrl + "ProfileImage4.png",
                    SenderName = "Jessica Park",
                    MessageType = "Text",
                    Message = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                    Time = "1 hr",
                    NotificationType = "New"
                },
                new ChatDetail
                {
                    ImagePath = App.BaseImageUrl + "ProfileImage5.png",
                    SenderName = "Julia Grant",
                    MessageType = "Video",
                    Time = "3 hr",
                    AvailableStatus = "Available",
                    NotificationType = "Received"
                },
                new ChatDetail
                {
                    ImagePath = App.BaseImageUrl + "ProfileImage6.png",
                    SenderName = "kyle Greene",
                    MessageType = "Contact",
                    Message = "Jhone Deo Sync",
                    Time = "Yesterday",
                    NotificationType = "Viewed"
                },
                new ChatDetail
                {
                    ImagePath = App.BaseImageUrl + "ProfileImage7.png",
                    SenderName = "Danielle Booker",
                    MessageType = "Text",
                    Message = "Val Geisier is a writer who",
                    Time = "Jan 30",
                    AvailableStatus = "Available",
                    NotificationType = "Sent"
                },
                new ChatDetail
                {
                    ImagePath = App.BaseImageUrl + "ProfileImage8.png",
                    SenderName = "Jazmine Simmons",
                    MessageType = "Text",
                    Message = "Contrary to popular belief, Lorem Ipsum is not simply random text." +
                              "It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.",
                    Time = "12/8/2018",
                    NotificationType = "Sent"
                },
                new ChatDetail
                {
                    ImagePath = App.BaseImageUrl + "ProfileImage9.png",
                    SenderName = "Ira Membrit",
                    MessageType = "Photo",
                    Time = "8/8/2018",
                    AvailableStatus = "Available",
                    NotificationType = "Viewed"
                },
                new ChatDetail
                {
                    ImagePath = App.BaseImageUrl + "ProfileImage10.png",
                    MessageType = "Text",
                    Message = "A customer who bought your",
                    SenderName = "Serina Willams",
                    Time = "10/6/2018",
                    NotificationType = "Sent"
                },
                 new ChatDetail
                 {
                    ImagePath = App.BaseImageUrl + "ProfileImage11.png",
                    SenderName = "Alise Valasquez",
                    MessageType = "Text",
                    Message = "Syncfusion components help you deliver applications with great user experiences across iOS, Android, and Universal Windows Platform from a single code base.",
                    Time = "2/5/2018",
                    NotificationType = "New"
                },
                new ChatDetail
                {
                    ImagePath = App.BaseImageUrl + "ProfileImage12.png",
                    SenderName = "Allie Bellew",
                    MessageType = "Audio",
                    Time = "24/4/2018",
                    AvailableStatus = "Available",
                    NotificationType = "Viewed"
                },
                new ChatDetail
                {
                    ImagePath = App.BaseImageUrl + "ProfileImage13.png",
                    SenderName = "Navya Sharma",
                    MessageType = "Text",
                    Message = "https://www.syncfusion.com",
                    Time = "10/4/2018",
                    NotificationType = "New"
                },
                new ChatDetail
                {
                    ImagePath = App.BaseImageUrl + "ProfileImage14.png",
                    SenderName = "Carly Ling",
                    MessageType = "Video",
                    Time = "22/3/2018",
                    AvailableStatus = "Available",
                    NotificationType = "Received"
                },
                new ChatDetail
                {
                    ImagePath = App.BaseImageUrl + "ProfileImage15.png",
                    SenderName = "Diayana Sebastine",
                    MessageType = "Contact",
                    Message = "Kishore Nisanth",
                    Time = "15/3/2018",
                    NotificationType = "Viewed"
                },
                new ChatDetail
                {
                    ImagePath = App.BaseImageUrl + "ProfileImage16.png",
                    SenderName = "Marc Sherry",
                    MessageType = "Text",
                    Message = "Val Geisier is a writer who",
                    Time = "12/3/2018",
                    AvailableStatus = "Available",
                    NotificationType = "Sent"
                },
                new ChatDetail
                {
                    ImagePath = App.BaseImageUrl + "ProfileImage17.png",
                    SenderName = "Dona Merina",
                    MessageType = "Text",
                    Message = "Contrary to popular belief, Lorem Ipsum is not simply random text." +
                              "It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.",
                    Time = "3/2/2018",
                    NotificationType = "Sent"
                },
            };

            this.MakeVoiceCallCommand = new Command(this.VoiceCallClicked);
            this.MakeVideoCallCommand = new Command(this.VideoCallClicked);
            this.ShowSettingsCommand = new Command(this.SettingsClicked);
            this.MenuCommand = new Command(this.MenuClicked);
            this.ProfileImageCommand = new Command(this.ProfileImageClicked);
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        public string ProfileImage
        {
            get
            {
                return this.profileImage;
            }

            set
            {
                this.profileImage = value;
                this.NotifyPropertyChanged();
            }
        }
        
        /// <summary>
        /// Gets or sets the property that has been bound with a list view, which displays the profile items.
        /// </summary>
        public ObservableCollection<ChatDetail> ChatItems
        {
            get
            {
                return this.chatItems;
            }

            set
            {
                if (this.chatItems == value)
                {
                    return;
                }

                this.chatItems = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Commands
        /// <summary>
        /// Gets or sets the command that is executed when the voice call button is clicked.
        /// </summary>
        public Command MakeVoiceCallCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the video call button is clicked.
        /// </summary>
        public Command MakeVideoCallCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the settings button is clicked.
        /// </summary>
        public Command ShowSettingsCommand { get; set; }
                
        /// <summary>
        /// Gets or sets the command that is executed when the menu button is clicked.
        /// </summary>
        public Command MenuCommand { get; set; }

        /// <summary>
        /// Gets the command that is executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand
        {
            get { return this.itemSelectedCommand ?? (this.itemSelectedCommand = new Command(this.ItemSelected)); }
        }

        /// <summary>
        /// Gets or sets the command that is executed when the profile image is clicked.
        /// </summary>
        public Command ProfileImageCommand { get; set; }

        #endregion

        #region Methods
         
        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        private void ItemSelected(object selectedItem)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Profile image is clicked.
        /// </summary>
        private void ProfileImageClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the voice call button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void VoiceCallClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the video call button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void VideoCallClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the settings button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SettingsClicked(object obj)
        {
            // Do something
        }
        
        /// <summary>
        /// Invoked when the menu button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void MenuClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
