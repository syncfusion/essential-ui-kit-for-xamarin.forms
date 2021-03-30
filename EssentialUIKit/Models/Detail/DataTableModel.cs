using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Detail
{
    /// <summary>
    /// Model for Data table
    /// /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class DataTableModel
    {
        #region fields

        private string imageIcon;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the club image.
        /// </summary>
        [DataMember(Name = "imageIcon")]
        public string ImageIcon
        {
            get { return App.ImageServerPath + this.imageIcon; }
            set { this.imageIcon = value; }
        }

        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        [DataMember(Name = "serialNumber")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the club name.
        /// </summary>
        [DataMember(Name = "clubName")]
        public string ClubName { get; set; }

        /// <summary>
        /// Gets or sets the gold points.
        /// </summary>
        [DataMember(Name = "goldPoints")]
        public string GoldPoints { get; set; }

        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        [DataMember(Name = "points")]
        public string Points { get; set; }

        /// <summary>
        /// Gets or sets the match results.
        /// </summary>
        [DataMember(Name = "matchResults")]
        public ObservableCollection<string> MatchResults { get; set; }

        #endregion
    }
}
