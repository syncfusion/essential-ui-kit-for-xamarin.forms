using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Transaction
{
    /// <summary>
    /// Model for review list.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Customer
    {
        /// <summary>
        /// Gets or sets the property that holds the customer id.
        /// </summary>
        [DataMember(Name = "customerId")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the customer name.
        /// </summary>
        [DataMember(Name = "customerName")]
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the address type.
        /// </summary>
        [DataMember(Name = "addressType")]
        public string AddressType { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the customer address.
        /// </summary>
        [DataMember(Name = "address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the customer mobile number.
        /// </summary>
        [DataMember(Name = "mobileNumber")]
        public string MobileNumber { get; set; }
    }
}
