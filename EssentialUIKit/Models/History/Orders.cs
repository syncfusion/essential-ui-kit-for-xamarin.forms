using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.History
{
    /// <summary>
    /// Model for pages with order.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Orders
    {
        #region Fields

        private string productImage;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the property that has been bound with Xamarin.Forms Image, which displays the product image.
        /// </summary>
        [DataMember(Name = "productimage")]
        public string ProductImage
        {
            get { return App.BaseImageUrl + this.productImage; }
            set { this.productImage = value; }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the product name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the order description.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the status of the order.
        /// </summary>
        [DataMember(Name = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the order id.
        /// </summary>
        [DataMember(Name = "orderid")]
        public string OrderID { get; set; }

        #endregion
    }
}
