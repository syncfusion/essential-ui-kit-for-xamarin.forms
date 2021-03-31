using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Transaction
{
    /// <summary>
    /// Model for list view item in payment view.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Payment
    {
        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the payment mode.
        /// </summary>
        [DataMember(Name = "paymentMode")]
        public string PaymentMode { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the card number.
        /// </summary>
        [DataMember(Name = "cardNumber")]
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with an image, which displays the card type.
        /// </summary>
        [DataMember(Name = "cardTypeIcon")]
        public string CardTypeIcon { get; set; }
    }
}
