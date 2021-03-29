using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using EssentialUIKit.Models.Chat;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Chat
{
    /// <summary>
    /// View model for recent chat page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    [DataContract]
    public class RecentChatViewModel : BaseViewModel
    {
        #region Fields

        private static RecentChatViewModel recentChatViewModel;

        private ObservableCollection<ChatDetail> chatItems;

        private string profileImage;

        private Command itemSelectedCommand;

        private Command makeVoiceCallCommand;

        private Command makeVideoCallCommand;

        private Command showSettingsCommand;

        private Command menuCommand;

        private Command profileImageCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RecentChatViewModel" /> class.
        /// </summary>
        static RecentChatViewModel()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the value of recent chat page view model.
        /// </summary>
        public static RecentChatViewModel BindingContext =>
            recentChatViewModel = PopulateData<RecentChatViewModel>("chat.json");

        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        [DataMember(Name = "profileImage")]
        public string ProfileImage
        {
            get
            {
                return App.ImageServerPath + this.profileImage;
            }

            set
            {
                this.SetProperty(ref this.profileImage, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a list view, which displays the profile items.
        /// </summary>
        [DataMember(Name = "chatItems")]
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

                this.SetProperty(ref this.chatItems, value);
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the command that is executed when the voice call button is clicked.
        /// </summary>
        public Command MakeVoiceCallCommand
        {
            get { return this.makeVoiceCallCommand ?? (this.makeVoiceCallCommand = new Command(this.VoiceCallClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that is executed when the video call button is clicked.
        /// </summary>
        public Command MakeVideoCallCommand
        {
            get { return this.makeVideoCallCommand ?? (this.makeVideoCallCommand = new Command(this.VideoCallClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that is executed when the settings button is clicked.
        /// </summary>
        public Command ShowSettingsCommand
        {
            get { return this.showSettingsCommand ?? (this.showSettingsCommand = new Command(this.SettingsClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that is executed when the menu button is clicked.
        /// </summary>
        public Command MenuCommand
        {
            get { return this.menuCommand ?? (this.menuCommand = new Command(this.MenuClicked)); }
        }

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
        public Command ProfileImageCommand
        {
            get { return this.profileImageCommand ?? (this.profileImageCommand = new Command(this.ProfileImageClicked)); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Populates the data for view model from json file.
        /// </summary>
        /// <typeparam name="T">Type of view model.</typeparam>
        /// <param name="fileName">Json file to fetch data.</param>
        /// <returns>Returns the view model object.</returns>
        private static T PopulateData<T>(string fileName)
        {
            var file = "EssentialUIKit.Data." + fileName;

            var assembly = typeof(App).GetTypeInfo().Assembly;

            T data;

            using (var stream = assembly.GetManifestResourceStream(file))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                data = (T)serializer.ReadObject(stream);
            }

            return data;
        }

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
