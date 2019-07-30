using System.Collections.Generic;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.ECommerce
{
    /// <summary>
    /// Model for category.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Category
    {

        private string icon;

        /// <summary>
        /// Gets or sets the property that has been bound with an image, which displays the category.
        /// </summary>
        [DataMember(Name = "icon")]
        public string Icon
        {
            get { return App.BaseImageUrl + icon; }
            set { icon = value; }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label in SfExpander header, which displays the main category.
        /// </summary>
        [DataMember(Name = "maincategory")]
        public string MainCategory { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label in SfExpander content, which displays the sub category.
        /// </summary>
        [DataMember(Name = "subcategories")]
        public List<string> SubCategories { get; set; }
    }
}