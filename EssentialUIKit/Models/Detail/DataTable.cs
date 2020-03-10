using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Detail
{
    /// <summary>
    /// Model for Data table
    /// /// </summary>
    [Preserve(AllMembers = true)]
    public class DataTable
    {
        #region fields

        private string imagePath;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the club image.
        /// </summary>
        public string ImagePath
        {
            get { return App.BaseImageUrl + this.imagePath; }
            set { this.imagePath = value; }
        }

        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the club name.
        /// </summary>
        public string ClubName { get; set; }
      
        /// <summary>
        /// Gets or sets the gold points.
        /// </summary>
        public string GoldPoints { get; set; }

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        public string Points { get; set; }

        /// <summary>
        /// Gets or sets the match results.
        /// </summary>
        public string[] MatchResults { get; set; }

    #endregion
    }
}
