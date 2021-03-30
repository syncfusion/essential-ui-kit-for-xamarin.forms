using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Detail
{
    /// <summary>
    /// Model for my address page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Address
    {
        #region Properties
        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address type.
        /// </summary>
        [DataMember(Name = "addressType")]
        public string AddressType { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        [DataMember(Name = "location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the contact number.
        /// </summary>
        [DataMember(Name = "contactNumber")]
        public string ContactNumber { get; set; }

        #endregion
    }
}
