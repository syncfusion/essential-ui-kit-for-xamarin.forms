using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using EssentialUIKit.Models.Notification;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Notification
{
    /// <summary>
    /// ViewModel for the Notification page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class SocialNotificationViewModel : BaseViewModel
    {
        #region Fields

        private Command<object> itemTappedCommand;

        private Command<object> menuCommand;

        private Command<object> markAllCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="SocialNotificationViewModel"/> class.
        /// </summary>
        public SocialNotificationViewModel()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> ItemTappedCommand
        {
            get
            {
                return this.itemTappedCommand ?? (this.itemTappedCommand = new Command<object>(this.ItemSelected));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> MenuCommand
        {
            get
            {
                return this.menuCommand ?? (this.menuCommand = new Command<object>(this.MenuButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when an mark all as read is selected.
        /// </summary>
        public Command<object> MarkAllCommand
        {
            get
            {
                return this.markAllCommand ?? (this.markAllCommand = new Command<object>(this.MarkAllClicked));
            }
        }

        /// <summary>
        /// Gets or sets a collection of values to be displayed in the social notification page recent list.
        /// </summary>
        [DataMember(Name = "recentSocialNotificationList")]
        public ObservableCollection<SocialNotificationModel> RecentList { get; set; }

        /// <summary>
        /// Gets or sets a collection of values to be displayed in the social notification page earlier list.
        /// </summary>
        [DataMember(Name = "earlierSocialNotificationList")]
        public ObservableCollection<SocialNotificationModel> EarlierList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the navigation list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void ItemSelected(object selectedItem)
        {
            if (((selectedItem as Syncfusion.ListView.XForms.ItemTappedEventArgs)?.ItemData as SocialNotificationModel) != null)
            {
                ((selectedItem as Syncfusion.ListView.XForms.ItemTappedEventArgs)?.ItemData as SocialNotificationModel).IsRead = true;
            }
        }

        /// <summary>
        /// Invoked when menu button is clicked in the social notification page.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void MenuButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when mark all as read button is clicked in the social notification page.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void MarkAllClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
