using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Navigation
{
    /// <summary>
    /// Model for Album list.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Album
    {
        /// <summary>
        /// Gets or sets the album name.
        /// </summary>
        public string AlbumName { get; set; }

        /// <summary>
        /// Gets or sets the album image.
        /// </summary>
        public string AlbumImage { get; set; }

        /// <summary>
        /// Gets the total photos.
        /// </summary>
        public string TotalPhotos { get; internal set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public string Category { get; set; }
    }
}
