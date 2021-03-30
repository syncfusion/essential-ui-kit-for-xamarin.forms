using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Transaction
{
    /// <summary>
    /// Model for my cards page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Card
    {
        #region Properties
        /// <summary>
        /// Gets or sets the card type.
        /// </summary>
        [DataMember(Name = "cardType")]
        public string CardType { get; set; }

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        [DataMember(Name = "number")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets name of the card holder.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the card expiry date.
        /// </summary>
        [DataMember(Name = "expiry")]
        public string Expiry { get; set; }

        /// <summary>
        /// Gets or sets the card cvv.
        /// </summary>
        [DataMember(Name = "cardCvv")]
        public int CardCvv { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays  background gradient start.
        /// </summary>
        [DataMember(Name = "backgroundGradientStart")]
        public string BackgroundGradientStart { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays  background gradient end.
        /// </summary>
        [DataMember(Name = "backgroundGradientEnd")]
        public string BackgroundGradientEnd { get; set; }

        /// <summary>
        /// Gets or sets the card type.
        /// </summary>
        [DataMember(Name = "cardTypeIcon")]
        public string CardTypeIcon { get; set; }

        #endregion
    }
}
