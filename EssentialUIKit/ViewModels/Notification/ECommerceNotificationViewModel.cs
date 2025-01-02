using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using EssentialUIKit.Models.Notification;

namespace EssentialUIKit.ViewModels.Notification
{
    /// <summary>
    /// ViewModel for E-Commerce notification page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class ECommerceNotificationViewModel : BaseViewModel
    {
        #region Fields

        private Command<object> itemTappedCommand;

        private Command<object> backCommand;

        private Command<object> menuCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="ECommerceNotificationViewModel"/> class.
        /// </summary>
        public ECommerceNotificationViewModel()
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
        /// Gets the command that will be executed when back button is clicked.
        /// </summary>
        public Command<object> BackCommand
        {
            get
            {
                return this.backCommand ?? (this.backCommand = new Command<object>(this.BackButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when menu button is clicked.
        /// </summary>
        public Command<object> MenuCommand
        {
            get
            {
                return this.menuCommand ?? (this.menuCommand = new Command<object>(this.MenuButtonClicked));
            }
        }

        /// <summary>
        /// Gets or sets a collction of value to be displayed in E-Commerce notification page.
        /// </summary>
        [DataMember(Name = "ecommerceNotificationPageList")]
        public ObservableCollection<ECommerceNotificationsListModel> ECommerceNotificationsList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the E-Commerce notification page.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void ItemSelected(object selectedItem)
        {
            ((selectedItem as Syncfusion.ListView.XForms.ItemTappedEventArgs)?.ItemData as ECommerceNotificationsListModel).IsRead = true;
            // Do something
        }

        /// <summary>
        /// Invoked when back button is clicked in the E-Commerce notification page.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void BackButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when menu button is clicked in the E-Commerce notification page.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void MenuButtonClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}