using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Settings
{
    /// <summary>
    /// ViewModel for Help page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class HelpViewModel : BaseViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="HelpViewModel" /> class
        /// </summary>
        public HelpViewModel()
        {
            this.BackButtonCommand = new Command(this.BackButtonClicked);
            this.IssuePreviousOrderCommand = new Command(this.IssuePreviousOrderClicked);
            this.Return_RefundCommand = new Command(this.RefundClicked);
            this.PaymentQueriesCommand = new Command(this.PaymentQueriesClicked);
            this.OffersQueriesCommand = new Command(this.OffersQueriesClicked);
            this.AccountQueriesCommand = new Command(this.AccountQueriesClicked);
            this.OtherQueriesCommand = new Command(this.OtherQueriesClicked);
           
        }
        #endregion

        #region Method

        /// <summary>
        /// Invoked when the other queries option clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void OtherQueriesClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the account queries option clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void AccountQueriesClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the offers queries option clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void OffersQueriesClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the payment queries option clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void PaymentQueriesClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the refund option clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void RefundClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the issue previous order option clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void IssuePreviousOrderClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the back button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void BackButtonClicked(object obj)
        {
            // Do something
        }
        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command is executed when the back button is clicked.
        /// </summary>
        public Command BackButtonCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the issue previous order option is clicked.
        /// </summary>
        public Command IssuePreviousOrderCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the return refund option is clicked.
        /// </summary>
        public Command Return_RefundCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the payment queries option is clicked.
        /// </summary>
        public Command PaymentQueriesCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the offer queries  option is clicked.
        /// </summary>
        public Command OffersQueriesCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the account queries option is clicked.
        /// </summary>
        public Command AccountQueriesCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the other queries option is clicked.
        /// </summary>
        public Command OtherQueriesCommand { get; set; }
        #endregion
    }


}
