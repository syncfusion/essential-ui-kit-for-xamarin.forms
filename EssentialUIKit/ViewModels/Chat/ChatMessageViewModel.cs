using System;
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
    /// ViewModel for chat message page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class ChatMessageViewModel : BaseViewModel
    {
        #region Fields

        private static ChatMessageViewModel chatMessageViewModel;

        private string profileName;

        private string newMessage;

        private string profileImage;

        private ObservableCollection<ChatMessage> chatMessageInfo = new ObservableCollection<ChatMessage>();

        private Command makeVoiceCall;

        private Command makeVideoCall;

        private Command menuCommand;

        private Command showCamera;

        private Command sendAttachment;

        private Command sendCommand;

        private Command profileCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatMessageViewModel" /> class.
        /// </summary>
        public ChatMessageViewModel()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the value of Chat message view model.
        /// </summary>
        public static ChatMessageViewModel BindingContext =>
            chatMessageViewModel = PopulateData<ChatMessageViewModel>("chat.json");

        /// <summary>
        /// Gets or sets the profile name.
        /// </summary>
        [DataMember(Name = "profileName")]
        public string ProfileName
        {
            get
            {
                return this.profileName;
            }

            set
            {
                this.SetProperty(ref this.profileName, value);
            }
        }

        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        [DataMember(Name = "image")]
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
        /// Gets or sets a collection of chat messages.
        /// </summary>
        [DataMember(Name = "chatMessageInfo")]
        public ObservableCollection<ChatMessage> ChatMessageInfo
        {
            get
            {
                return this.chatMessageInfo;
            }

            set
            {
                this.SetProperty(ref this.chatMessageInfo, value);
            }
        }

        /// <summary>
        /// Gets or sets a new message.
        /// </summary>
        public string NewMessage
        {
            get
            {
                return this.newMessage;
            }

            set
            {
                this.SetProperty(ref this.newMessage, value);
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets the command that is executed when the profile name is clicked.
        /// </summary>
        public Command ProfileCommand
        {
            get { return this.profileCommand ?? (this.profileCommand = new Command(this.ProfileClicked)); }
        }

        /// <summary>
        /// Gets the command that is executed when the voice call button is clicked.
        /// </summary>
        public Command MakeVoiceCall
        {
            get { return this.makeVoiceCall ?? (this.makeVoiceCall = new Command(this.VoiceCallClicked)); }
        }

        /// <summary>
        /// Gets the command that is executed when the video call button is clicked.
        /// </summary>
        public Command MakeVideoCall
        {
            get { return this.makeVideoCall ?? (this.makeVideoCall = new Command(this.VideoCallClicked)); }
        }

        /// <summary>
        /// Gets the command that is executed when the menu button is clicked.
        /// </summary>
        public Command MenuCommand
        {
            get { return this.menuCommand ?? (this.menuCommand = new Command(this.MenuClicked)); }
        }

        /// <summary>
        /// Gets the command that is executed when the camera button is clicked.
        /// </summary>
        public Command ShowCamera
        {
            get { return this.showCamera ?? (this.showCamera = new Command(this.CameraClicked)); }
        }

        /// <summary>
        /// Gets the command that is executed when the attachment button is clicked.
        /// </summary>
        public Command SendAttachment
        {
            get { return this.sendAttachment ?? (this.sendAttachment = new Command(this.AttachmentClicked)); }
        }

        /// <summary>
        /// Gets the command that is executed when the send button is clicked.
        /// </summary>
        public Command SendCommand
        {
            get { return this.sendCommand ?? (this.sendCommand = new Command(this.SendClicked)); }
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
        /// Invoked when the Profile name is clicked.
        /// </summary>
        private void ProfileClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the voice call button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void VoiceCallClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the video call button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void VideoCallClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the menu button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void MenuClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the camera icon is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void CameraClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the attachment icon is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void AttachmentClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the send button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void SendClicked(object obj)
        {
            if (!string.IsNullOrWhiteSpace(this.NewMessage))
            {
                this.ChatMessageInfo.Add(new ChatMessage
                {
                    Message = this.NewMessage,
                    Time = DateTime.Now,
                });
            }

            this.NewMessage = null;
        }

        #endregion
    }
}
