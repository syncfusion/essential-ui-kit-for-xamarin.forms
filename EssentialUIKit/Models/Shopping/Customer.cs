using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Shopping
{
    /// <summary>
    /// Model for review list.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Customer
    {
        /// <summary>
        /// Gets or sets the property that holds the customer id.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the customer name.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the address type.
        /// </summary>
        public string AddressType { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the customer address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the customer mobile number.
        /// </summary>
        public string MobileNumber { get; set; }
    }
}
