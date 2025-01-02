using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Transaction
{
    /// <summary>
    /// Model for my cards page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Card
    {
        #region Properties
        /// <summary>
        /// Gets or sets the card type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets name of the card holder.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the card expiry date.
        /// </summary>
        public string Expiry { get; set; }

        /// <summary>
        /// Gets or sets the card cvv.
        /// </summary>
        public int Cvv { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays  background gradient start.
        /// </summary>
        public string BackgroundGradientStart { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays  background gradient end.
        /// </summary>
        public string BackgroundGradientEnd { get; set; }

        /// <summary>
        /// Gets or sets the card type.
        /// </summary>
        public string CardTypeIcon { get; set; }

        #endregion
    }
}
