using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Navigation
{
    /// <summary>
    /// Model for the Songs play list page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Song
    {
        #region Field

        private string songImage;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of an song.
        /// </summary>
        [DataMember(Name = "songname")]
        public string SongName { get; set; }

        /// <summary>
        /// Gets or sets the composer.
        /// </summary>

        [DataMember(Name = "composer")]
        public string Composer { get; set; }

        /// <summary>
        /// Gets or sets the image of an item.
        /// </summary>
        [DataMember(Name = "songImage")]
        public string SongImage
        {
            get
            {
                return App.BaseImageUrl + this.songImage;
            }

            set
            {
                this.songImage = value;
            }
        }

        #endregion
    }
}
