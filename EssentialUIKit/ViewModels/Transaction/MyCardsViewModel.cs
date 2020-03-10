using Xamarin.Forms;
using EssentialUIKit.Models.Transaction;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Transaction
{
    /// <summary>
    /// ViewModel for my cards page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class MyCardsViewModel : BaseViewModel
    {
        #region Properties

        public ObservableCollection<Card> CardDetails { get; set; }

        #endregion

        #region Constructor 

        public MyCardsViewModel()
        {
            this.BackButtonCommand = new Command(this.BackButtonClicked);
            this.MoreButtonCommand = new Command(this.MoreButtonClicked);
            this.AddCardCommand = new Command(this.AddCardButtonClicked);

            this.CardDetails = new ObservableCollection<Card>()
            {
                new Card
                {
                  Type = "CREDIT CARD",
                  Number = "XXXX  XXXX  XXXX  5838",
                  Name = "Peter Wilson",
                  Expiry = "08/20",
                  Cvv = 846,
                  BackgroundGradientStart = "#d54381",
                  BackgroundGradientEnd = "#7644ad",
                  CardTypeIcon = "Card.png"
                },
                new Card
                {
                  Type = "DEBIT CARD",
                  Number = "XXXX  XXXX  XXXX  0743",
                  Name = "Peter Wilson",
                  Expiry = "03/21",
                  Cvv = 543,
                  BackgroundGradientStart = "#af4aff",
                  BackgroundGradientEnd = "#3e5aff",
                  CardTypeIcon = "Visa.png"
                },
                 new Card
                {
                  Type = "CREDIT CARD",
                  Number = "XXXX  XXXX  XXXX  0629",
                  Name = "Peter Wilson",
                  Expiry = "18/22",
                  Cvv = 346,
                  BackgroundGradientStart = "#d54381",
                  BackgroundGradientEnd = "#7644ad",
                  CardTypeIcon = "Card.png"
                }
            };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the more button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void MoreButtonClicked(object obj)
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

        /// <summary>
        /// Invoked when the add card button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void AddCardButtonClicked(object obj)
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
        /// Gets or sets the command is executed when the more button is clicked.
        /// </summary>
        public Command MoreButtonCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the add card button is clicked.
        /// </summary>
        public Command AddCardCommand { get; set; }

        #endregion
    }
}
