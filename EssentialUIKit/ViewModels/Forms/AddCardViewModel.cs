using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for add card page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class AddCardViewModel : BaseViewModel
    {
        #region Fields

        private string cardNumber;

        private string expireDate;

        private string cvv;

        private string name;

        private bool isChecked;

        #endregion

        #region Constrctor

        public AddCardViewModel()
        {
            this.AddCardCommand = new Command(this.AddCardClicked);
        }

        #endregion
        
        #region Properties

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

                this.cardNumber = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the expire date from user.
        /// </summary>
        public string ExpireDate
        {
            get
            {
                return this.expireDate;
            }

            set
            {
                if (this.expireDate == value)
                {
                    return;
                }

                this.expireDate = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the cvv number from user.
        /// </summary>
        public string CVV
        {
            get
            {
                return this.cvv;
            }

            set
            {
                if (this.cvv == value)
                {
                    return;
                }

                this.cvv = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the name from user.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name == value)
                {
                    return;
                }

                this.name = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the item is checked.
        /// </summary>
        public bool IsChecked
        {
            get
            {
                return this.isChecked;
            }

            set
            {
                if (this.isChecked == value)
                {
                    return;
                }

                this.isChecked = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion
        
        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the add card button is clicked.
        /// </summary>
        public Command AddCardCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the add card button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void AddCardClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
