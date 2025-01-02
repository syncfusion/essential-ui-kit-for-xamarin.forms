using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Transaction
{
    /// <summary>
    /// Model for list view item in payment view.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Payment
    {
        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the payment mode.
        /// </summary>
        public string PaymentMode { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the card number.
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with an image, which displays the card type.
        /// </summary>
        public string CardTypeIcon { get; set; }
    }
}
