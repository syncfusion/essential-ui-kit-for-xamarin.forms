using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Shopping
{
    /// <summary>
    /// Model for OnBoarding
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Boarding
    {
        #region Fields

        private View rotatorView;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        public View RotatorView
        {
            get { return this.rotatorView; }
            set { this.rotatorView = value; }
        }

        #endregion
    }
}
