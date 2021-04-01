using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Chat
{
    /// <summary>
    /// Model for chat message 
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class ChatMessage : INotifyPropertyChanged
    {
        #region Fields

        private string message;

        private DateTime time;

        private string imagePath;

        #endregion

        #region Event

        /// <summary>
        /// The declaration of property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [DataMember(Name = "message")]
        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
                this.OnPropertyChanged("Message");
            }
        }

        /// <summary>
        /// Gets or sets the message sent/received time.
        /// </summary>
        [DataMember(Name = "time")]
        public DateTime Time
        {
            get
            {
                return this.time;
            }

            set
            {
                this.time = value;
                this.OnPropertyChanged("Time");
            }
        }

        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        [DataMember(Name = "imagePath")]
        public string ImagePath
        {
            get
            {
                return this.imagePath;
            }

            set
            {
                this.imagePath = App.ImageServerPath + value;
                this.OnPropertyChanged("ImagePath");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the message is received or sent.
        /// </summary>
        [DataMember(Name = "isReceived")]
        public bool IsReceived { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when property value is changed.
        /// </summary>
        /// <param name="property">property name</param>
        protected void OnPropertyChanged(string property)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }
}
