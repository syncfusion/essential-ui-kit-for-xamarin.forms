using Syncfusion.SfMaps.XForms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.ContactUs
{
    [Preserve(AllMembers = true)]
    public class LocationMarker : MapMarker
    {
        #region Properties

        /// <summary>
        /// Gets or sets the image to pin location.
        /// </summary>
        public string PinImage { get; set; }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the email id.
        /// </summary>
        public string EmailId { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the close icon image.
        /// </summary>
        public string CloseImage { get; set; }

        #endregion
    }
}
