using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EssentialUIKit.Models.Navigation
{
    /// <summary>
    /// Photo model.
    /// </summary>
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
        [DataMember(Name="imageURL")]
        public string ImageURL
        {
            get
            {
                return App.BaseImageUrl + imageURL;
            }
            set
            {
                imageURL = value;
            }
        }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        [DataMember(Name ="updatedDate")]
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        public DateTime UpdatedDate
        {
            get
            {
                var date = Convert.ToDateTime(Date);
                return DateTime.MinValue != date
                     ? date
                     : updatedDate;
            }
            set
            {
                updatedDate = value;
            }
        }

        #endregion
    }
}
