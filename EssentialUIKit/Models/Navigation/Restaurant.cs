using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Navigation
{
    /// <summary>
    /// Model for the Restaurant page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Restaurant
    {
        #region Field

        private string itemImage;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the image of an item.
        /// </summary>
        [DataMember(Name = "itemImage")]
        public string ItemImage
        {
            get
            {
                return App.BaseImageUrl + this.itemImage;
            }

            set
            {
                this.itemImage = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of an Restaurant.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of food varieties.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Offer of a Restaurant.
        /// </summary>
        [DataMember(Name = "offer")]
        public string Offer { get; set; }

        /// <summary>
        /// Gets or sets the average rating of an Restaurant.
        /// </summary>
        [DataMember(Name = "itemRating")]
        public string ItemRating { get; set; }

        #endregion

    }
}
