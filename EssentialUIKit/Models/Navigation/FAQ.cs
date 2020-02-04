using System.Collections.Generic;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Navigation
{
    /// <summary>
    /// Model for the FAQ page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class FAQ
    {
        #region Properties

        /// <summary>
        /// Gets or sets the question for FAQ.
        /// </summary>
        [DataMember(Name = "question")]
        public string Question { get; set; }

        /// <summary>
        /// Gets or sets the answer for FAQ.
        /// </summary>
        [DataMember(Name = "answer")]
        public List<string> Answer { get; set; }

        #endregion

    }
}
