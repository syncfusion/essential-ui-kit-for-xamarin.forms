using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Transaction
{
    /// <summary>
    /// ViewModel for Payment page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class PaymentViewModel
    {
        #region Fields

        private string paymentSuccessIcon;
        private string paymentFailureIcon;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="PaymentViewModel"/> class.
        /// </summary>
        public PaymentViewModel()
        {
            this.paymentSuccessIcon = "PaymentSuccess.svg";
            this.paymentFailureIcon = "PaymentFailure.svg";
            this.TrackOrderCommand = new Command(this.TrackOrderClicked);
            this.MakePaymentCommand = new Command(this.MakePaymentClicked);
        }
        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the command that will be executed when track order button is clicked.
        /// </summary>
        public Command TrackOrderCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when make payment button is clicked.
        /// </summary>
        public Command MakePaymentCommand { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the payment success icon.
        /// </summary>
        public string PaymentSuccessIcon
        {
            get
            {
                return this.paymentSuccessIcon;
            }

            set
            {
                this.paymentSuccessIcon = value;
            }
        }

        /// <summary>
        /// Gets or sets the payment failure icon.
        /// </summary>
        public string PaymentFailureIcon
        {
            get
            {
                return this.paymentFailureIcon;
            }

            set
            {
                this.paymentFailureIcon = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when track order button is clicked.
        /// </summary>
        private void TrackOrderClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when make payment button is clicked.
        /// </summary>
        private void MakePaymentClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
