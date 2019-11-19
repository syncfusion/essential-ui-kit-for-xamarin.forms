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
        private bool isExpanded;

        /// <summary>
        /// Gets or sets the property that has been bound with an image, which displays the category.
        /// </summary>
        [DataMember(Name = "icon")]
        public string Icon
        {
            get { return App.BaseImageUrl + this.icon; }
            set { this.icon = value; }
        }
		
		/// <summary>
        /// Gets or sets the property that is Expanded.
        /// </summary>
		public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                isExpanded = value;
            }
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