using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Navigation
{
    /// <summary>
    /// Model for the file explorer list page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class File
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the folder.
        /// </summary>
        [DataMember(Name = "folderName")]
        public string FolderName { get; set; }

        /// <summary>
        /// Gets or sets the number of items in the folder.
        /// </summary>
        [DataMember(Name = "items")]
        public string Items { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the folder.
        /// </summary>
        [DataMember(Name = "dateTime")]
        public string DateTime { get; set; }

        #endregion
    }
}