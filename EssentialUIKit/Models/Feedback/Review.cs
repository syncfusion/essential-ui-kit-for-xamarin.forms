using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Feedback
{
    /// <summary>
    /// Model for feedback list.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Review
    {
        private static Random randomNum = new Random(0123456789);

        private string customerImage;

        private DateTime reviewDate;

        /// <summary>
        /// Gets or sets the value for rating.
        /// </summary>
        [DataMember(Name = "rating")]
        public double Rating { get; set; }

        /// <summary>
        /// Gets or sets the value for date.
        /// </summary>
        public DateTime ReviewedDate
        {
            get
            {
                if (randomNum != null)
                {
                    return this.reviewDate = DateTime.Now.AddDays(randomNum.Next(0, 1000));
                }

                return this.reviewDate;
            }

            set
            {
                this.reviewDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        [DataMember(Name = "customerName")]
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        [DataMember(Name = "customerImage")]
        public string CustomerImage
        {
            get
            {
                return App.ImageServerPath + this.customerImage;
            }

            set
            {
                this.customerImage = value;
            }
        }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the list of images.
        /// </summary>
        public List<string> Images { get; private set; }
    }
}
