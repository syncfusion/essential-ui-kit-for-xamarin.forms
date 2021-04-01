using System.Collections.Generic;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models
{
    /// <summary>
    /// Model for review list.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Review
    {
        #region Field

        /// <summary>
        /// Gets or sets the images
        /// </summary>
        private List<string> customerReviewImages;

        /// <summary>
        /// Gets or sets the profile image
        /// </summary>
        private string customerImage;

        #endregion

        /// <summary>
        /// Gets or sets the property that has been bound with an image, which displays the customer image.
        /// </summary>
        [DataMember(Name = "profileimage")]
        public string CustomerImage
        {
            get { return App.ImageServerPath + this.customerImage; }
            set { this.customerImage = value; }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with an image, which displays the customer added image.
        /// </summary>
        [DataMember(Name = "images")]
        public List<string> CustomerReviewImages
        {
            get
            {
                if (this.customerReviewImages != null)
                {
                    for (var i = 0; i < this.customerReviewImages.Count; i++)
                    {
                        this.customerReviewImages[i] = this.customerReviewImages[i].Contains(App.ImageServerPath) ? this.customerReviewImages[i] : App.ImageServerPath + this.customerReviewImages[i];
                    }
                }

                return this.customerReviewImages;
            }

            set
            {
                this.customerReviewImages = value;
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the customer name.
        /// </summary>
        [DataMember(Name = "customername")]
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the commented date.
        /// </summary>
        [DataMember(Name = "revieweddate")]
        public string ReviewedDate { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with SfRating control, which displays the rating of the item.
        /// </summary>
        [DataMember(Name = "rating")]
        public double Rating { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the comment updated by the customer.
        /// </summary>
        [DataMember(Name = "comment")]
        public string Comment { get; set; }
    }
}
