using System;
using System.Globalization;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Navigation
{
    /// <summary>
    /// Photo model.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Photo
    {
        #region Fields

        private DateTime updatedDate;

        private string imageURL;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>The image URL.</value>
        [DataMember(Name = "imageURL")]
        public string ImageURL
        {
            get
            {
                return App.BaseImageUrl + this.imageURL;
            }

            set
            {
                this.imageURL = value;
            }
        }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        [DataMember(Name = "updatedDate")]
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        public DateTime UpdatedDate
        {
            get
            {
                var date = Convert.ToDateTime(this.Date, CultureInfo.CurrentCulture);
                return DateTime.MinValue != date
                     ? date
                     : this.updatedDate;
            }

            set
            {
                this.updatedDate = value;
            }
        }

        #endregion
    }
}
