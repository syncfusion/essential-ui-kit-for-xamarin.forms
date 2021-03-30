using System.Runtime.Serialization;
using EssentialUIKit.ViewModels;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Notification
{
    /// <summary>
    /// Model for the E-Commerce notification page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class ECommerceNotificationsListModel : BaseViewModel
    {
        #region Field

        private bool isRead;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the notification Icon.
        /// </summary>
        [DataMember(Name = "notificationIcon")]
        public string NotificationIcon { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the background color inside the circular border.
        /// </summary>
        [DataMember(Name = "backgroundColor")]
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        [DataMember(Name = "time")]
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the notification item is read or not.
        /// </summary>
        [DataMember(Name = "isRead")]
        public bool IsRead
        {
            get { return this.isRead; }

            set { this.SetProperty(ref this.isRead, value); }
        }

        #endregion
    }
}