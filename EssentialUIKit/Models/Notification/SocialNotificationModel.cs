using System.Runtime.Serialization;
using EssentialUIKit.ViewModels;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Notification
{
    /// <summary>
    /// Model for the Notification page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class SocialNotificationModel : BaseViewModel
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
            get { return this.isRead; }

            set
            {
                this.SetProperty(ref this.isRead, value);
            }
        }

        #endregion

    }
}
