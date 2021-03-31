using System.Collections.Generic;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models
{
    /// <summary>
    /// Model for category.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Category
    {
        private string icon;
        private bool isSelected;

        /// <summary>
        /// Gets or sets the property that has been bound with an image, which displays the category.
        /// </summary>
        [DataMember(Name = "icon")]
        public string Icon
        {
            get { return App.ImageServerPath + this.icon; }
            set { this.icon = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether it is selected or not.
        /// </summary>
        public bool IsSelected
        {
            get { return this.isSelected; }

            set { this.isSelected = value; }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label in SfExpander header, which displays the category name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label in SfExpander content, which displays the sub category.
        /// </summary>
        [DataMember(Name = "subcategories")]
        public List<string> SubCategories { get; set; }
    }
}