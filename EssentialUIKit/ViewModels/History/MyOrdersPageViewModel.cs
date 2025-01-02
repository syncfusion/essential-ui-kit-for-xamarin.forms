using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using EssentialUIKit.Models.History;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.History
{
    /// <summary>
    /// ViewModel for my orders page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class MyOrdersPageViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<Orders> orderDetails;

        private ObservableCollection<Orders> myOrders;

        private Command itemSelectedCommand;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the property that has been bound with list view, which displays the collection of orders from json.
        /// </summary>
        [DataMember(Name = "orders")]
        public ObservableCollection<Orders> MyOrders
        {
            get
            {
                return this.myOrders;
            }

            set
            {
                if (this.myOrders == value)
                {
                    return;
                }

                this.myOrders = value;
                this.NotifyPropertyChanged();
                this.GetProducts(this.MyOrders);
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a list view, which displays the order details in list.
        /// </summary>
        public ObservableCollection<Orders> OrderDetails
        {
            get
            {
                return this.orderDetails;
            }

            set
            {
                if (this.orderDetails == value)
                {
                    return;
                }

                this.orderDetails = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand
        {
            get
            {
                return this.itemSelectedCommand ?? (this.itemSelectedCommand = new Command(this.ItemSelected));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="attachedObject">The Object</param>
        private void ItemSelected(object attachedObject)
        {
            // Do something
        }

        /// <summary>
        /// This method is used to get the ordered items from json.
        /// </summary>
        /// <param name="items">Ordered items</param>
        private void GetProducts(ObservableCollection<Orders> items)
        {
            this.OrderDetails = new ObservableCollection<Orders>();
            if (items != null && items.Count > 0)
            {
                this.OrderDetails = items;
            }
        }

        #endregion
    }
}
