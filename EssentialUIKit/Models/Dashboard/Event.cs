using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Dashboard
{
    /// <summary>
    /// Model for the Daily timeline and Company history page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Event
    {
        #region Properties

        /// <summary>
        /// Gets or sets the event name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the event decription.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the event time.
        /// </summary>
        [DataMember(Name = "time")]
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets the event icon.
        /// </summary>
        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the event year.
        /// </summary>
        [DataMember(Name = "year")]
        public int Year { get; set; }

        #endregion
    }
}
