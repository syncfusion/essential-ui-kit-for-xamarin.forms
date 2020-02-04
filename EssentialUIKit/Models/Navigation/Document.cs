using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Navigation
{
    /// <summary>
    /// Model for the documents list page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Document
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the document.
        /// </summary>
        [DataMember(Name = "documentName")]
        public string DocumentName { get; set; }

        /// <summary>
        /// Gets or sets the received time of the document.
        /// </summary>
        [DataMember(Name = "time")]
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets the size of the document.
        /// </summary>
        [DataMember(Name = "documentSize")]
        public string DocumentSize { get; set; }

        #endregion
    }
}