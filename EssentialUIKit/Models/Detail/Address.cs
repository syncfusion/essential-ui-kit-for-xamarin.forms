using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Detail
{
    /// <summary>
    /// Model for my address page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Address
    {
        #region Properties
        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address type.
        /// </summary>
        public string AddressType { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the contact number.
        /// </summary>
        public string ContactNumber { get; set; }

        #endregion
    }
}
