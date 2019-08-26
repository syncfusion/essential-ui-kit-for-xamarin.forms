using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Navigation
{
    /// <summary>
    /// Model for the Navigation List with Cards page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class NavigationListModel
    {
        /// <summary>
        /// Gets or sets the name of an item.
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets the description of an item.
        /// </summary>
        public string ItemDescription { get; set; }

        /// <summary>
        /// Gets or sets the image of an item.
        /// </summary>
        public string ItemImage { get; set; }

        /// <summary>
        /// Gets or sets the average rating of an item.
        /// </summary>
        public double ItemRating { get; set; }
    }
}