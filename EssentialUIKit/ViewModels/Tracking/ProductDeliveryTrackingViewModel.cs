using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using EssentialUIKit.Models.Tracking;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Tracking
{
    /// <summary>
    /// ViewModel for ProductDeliveryTracking page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class ProductDeliveryTrackingViewModel : BaseViewModel
    {
        #region Fields

        private string productName;

        private string description;

        private string status;

        private string orderId;

        private string productImage;

        private ObservableCollection<ProductDeliveryTrackingModel> productDeliveryTrackings;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the property that has been bound with bindable layout, which displays the collection of delivery tracking.
        /// </summary>
        [DataMember(Name = "productdeliverytrackings")]
        public ObservableCollection<ProductDeliveryTrackingModel> ProductDeliveryTrackings
        {
            get
            {
                return this.productDeliveryTrackings;
            }

            set
            {
                this.SetProperty(ref this.productDeliveryTrackings, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with Xamarin.Forms Image, which displays the product image.
        /// </summary>
        [DataMember(Name = "productimage")]
        public string ProductImage
        {
            get
            {
                return App.ImageServerPath + this.productImage;
            }

            set
            {
                this.SetProperty(ref this.productImage, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the product name.
        /// </summary>
        [DataMember(Name = "productname")]
        public string ProductName
        {
            get
            {
                return this.productName;
            }

            set
            {
                this.SetProperty(ref this.productName, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the order description.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                this.SetProperty(ref this.description, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the status of the order.
        /// </summary>
        [DataMember(Name = "status")]
        public string Status
        {
            get
            {
                return this.status;
            }

            set
            {
                this.SetProperty(ref this.status, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the order id.
        /// </summary>
        [DataMember(Name = "orderid")]
        public string OrderID
        {
            get
            {
                return this.orderId;
            }

            set
            {
                this.SetProperty(ref this.orderId, value);
            }
        }

        #endregion
    }
}
