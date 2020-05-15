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
            this.AddCardCommand = new Command(this.AddCardButtonClicked);
            this.MenuCommand = new Command(this.MenuButtonClicked);

            this.CardDetails = new ObservableCollection<Card>()
            {
                new Card
                {
                  CardType = "CREDIT CARD",
                  Number = "XXXX  XXXX  XXXX  5838",
                  Name = "Peter Wilson",
                  Expiry = "08/20",
                  CardCvv = 846,
                  BackgroundGradientStart = "#d54381",
                  BackgroundGradientEnd = "#7644ad",
                  CardTypeIcon = "Card.png"
                },
                new Card
                {
                  CardType = "DEBIT CARD",
                  Number = "XXXX  XXXX  XXXX  0743",
                  Name = "Peter Wilson",
                  Expiry = "03/21",
                  CardCvv = 543,
                  BackgroundGradientStart = "#af4aff",
                  BackgroundGradientEnd = "#3e5aff",
                  CardTypeIcon = "Visa.png"
                },
                 new Card
                {
                  CardType = "CREDIT CARD",
                  Number = "XXXX  XXXX  XXXX  0629",
                  Name = "Peter Wilson",
                  Expiry = "18/22",
                  CardCvv = 346,
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
        private void MenuButtonClicked(object obj)
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
        /// Gets or sets the command is executed when the more button is clicked.
        /// </summary>
        public Command MenuCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the add card button is clicked.
        /// </summary>
        public Command AddCardCommand { get; set; }

        #endregion
    }
}
