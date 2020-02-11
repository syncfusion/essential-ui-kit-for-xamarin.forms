using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Notification
{
    /// <summary>
    /// Model for the Notification page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class SocialNotificationModel : INotifyPropertyChanged
    {

        #region Field

        private bool isRead;

        #endregion
        
        #region Properties

        /// <summary>
        /// Gets or sets the name of an item.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the received time of an item.
        /// </summary>
        [DataMember(Name = "receivedTime")]
        public string ReceivedTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the notification item is read or not.
        /// </summary>
        [DataMember(Name = "isRead")]
        public bool IsRead
        {
            get { return isRead;}
            set
            {
                isRead = value;
                this.NotifyPropertyChanged();
            }
        }
        
        #endregion

        #region Event handler

        /// <summary>
        /// Occurs when the property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
