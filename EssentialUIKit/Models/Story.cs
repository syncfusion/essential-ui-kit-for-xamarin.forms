using System.Runtime.Serialization;
using EssentialUIKit.ViewModels;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models
{
    /// <summary>
    /// Model for Article templates.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Story : BaseViewModel
    {
        #region Fields

        /// <summary>
        /// Gets or sets a value indicating whether the article is bookmarked
        /// </summary>
        private bool isBookmarked;

        /// <summary>
        /// Gets or sets a value indicating whether the article is favourite.
        /// </summary>
        private bool isFavourite;

        /// <summary>
        /// Gets or sets a value indicating image path.
        /// </summary>
        private string imagePath;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the article image path.
        /// </summary>
        [DataMember(Name = "itemImage")]
        public string ImagePath
        {
            get
            {
                return App.ImageServerPath + this.imagePath;
            }

            set
            {
                this.SetProperty(ref this.imagePath, value);
            }
        }

        /// <summary>
        /// Gets or sets the article name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the article author name.
        /// </summary>
        [DataMember(Name = "author")]
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the article publish date.
        /// </summary>
        [DataMember(Name = "date")]
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the article read time.
        /// </summary>
        [DataMember(Name = "averageReadingTime")]
        public string AverageReadingTime { get; set; }

        /// <summary>
        /// Gets or sets the article description
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the article is bookmarked.
        /// </summary>
        [DataMember(Name = "isBookmarked")]
        public bool IsBookmarked
        {
            get
            {
                return this.isBookmarked;
            }

            set
            {
                this.SetProperty(ref this.isBookmarked, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the article is favourite.
        /// </summary>
        public bool IsFavourite
        {
            get
            {
                return this.isFavourite;
            }

            set
            {
                this.SetProperty(ref this.isFavourite, value);
            }
        }

        /// <summary>
        /// Gets or sets the bookmarked count.
        /// </summary>
        [DataMember(Name = "bookmarkedCount")]
        public int BookmarkedCount { get; set; }

        /// <summary>
        /// Gets or sets the favourite count.
        /// </summary>
        [DataMember(Name = "favouritesCount")]
        public int FavouritesCount { get; set; }

        /// <summary>
        /// Gets or sets the shared count.
        /// </summary>
        [DataMember(Name = "sharedCount")]
        public int SharedCount { get; set; }

        #endregion
    }
}