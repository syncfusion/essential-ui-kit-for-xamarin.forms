using System;
using System.Runtime.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for card payment page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class CardPaymentPageViewModel : BaseViewModel
    {
        #region Fields

        private string cardNumber = "XXXX-XXXX-XXXX-XXXX";

        private string cardCvv;

        private string cardHolderName;

        private DateTime cardExpirationDate = DateTime.Now;

        private DateTime minimumDate;

        private Command addCardCommand;

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the card holder name from user.
        /// </summary>
        public string CardHolderName
        {
            get
            {
                return this.cardHolderName;
            }

            set
            {
                if (this.cardHolderName == value)
                {
                    return;
                }

                this.SetProperty(ref this.cardHolderName, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the card number from user.
        /// </summary>
        public string CardNumber
        {
            get
            {
                return this.cardNumber;
            }

            set
            {
                if (this.cardNumber == value)
                {
                    return;
                }

                this.SetProperty(ref this.cardNumber, value);
            }
        }

        /// <summary>
        /// Gets or sets the card type.
        /// </summary>
        public string CardType { get; set; } = "CREDIT CARD";

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the cvv number from user.
        /// </summary>
        public string CardCvv
        {
            get
            {
                return this.cardCvv;
            }

            set
            {
                if (this.cardCvv == value)
                {
                    return;
                }

                this.SetProperty(ref this.cardCvv, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the expire date from user.
        /// </summary>
        public DateTime CardExpirationDate
        {
            get
            {
                return this.cardExpirationDate;
            }

            set
            {
                if (this.cardExpirationDate == value)
                {
                    return;
                }

                this.SetProperty(ref this.cardExpirationDate, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the expire date from user.
        /// </summary>
        public DateTime MinimumDate
        {
            get
            {
                return this.minimumDate = DateTime.Now.AddDays(1);
            }

            set
            {
                if (this.minimumDate == value)
                {
                    return;
                }

                this.SetProperty(ref this.minimumDate, value);
            }
        }

        #endregion

        #region commands

        /// <summary>
        /// Gets or sets the command is executed when the add card button is clicked.
        /// </summary>
        public Command AddCardCommand
        {
            get
            {
                return this.addCardCommand ?? (this.addCardCommand = new Command(this.AddCardButtonClicked));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the add card button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void AddCardButtonClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
