using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Notification
{
    /// <summary>
    /// Model for the task notifications list page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class TaskNotificationsListModel : INotifyPropertyChanged
    {
        #region Field

        private bool isRead;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        [DataMember(Name = "userName")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the background color inside the circular avatar.
        /// </summary>
        [DataMember(Name = "backgroundColor")]
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }
        
        /// <summary>
        /// Gets or sets the detailed description.
        /// </summary>
        [DataMember(Name = "detail")]
        public string Detail { get; set; }

        /// <summary>
        /// Gets or sets the task-id.
        /// </summary>
        [DataMember(Name = "taskID")]
        public string TaskID { get; set; }

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
            get { return isRead; }
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