using System;
using EssentialUIKit.Validators;
using EssentialUIKit.Validators.Rules;
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

        private ValidatableObject<string> cardNumber;

        private ValidatableObject<string> expireDate;

        private ValidatableObject<string> cvv;

        private ValidatableObject<string> name;

        private DateTime date = DateTime.Now;

        private bool isChecked;

        #endregion

        #region Constrctor

        /// <summary>
        /// Initializes a new instance of the <see cref="AddCardViewModel" /> class
        /// </summary>
        public AddCardViewModel()
        {
            this.InitializeProperties();
            this.AddValidationRules();
            this.AddCardCommand = new Command(this.AddCardClicked);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the card number from user.
        /// </summary>
        public ValidatableObject<string> CardNumber
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
        /// Gets or sets the property that bounds with an entry that gets the expire date from user.
        /// </summary>
        public ValidatableObject<string> ExpireDate
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

                this.SetProperty(ref this.expireDate, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the cvv number from user.
        /// </summary>
        public ValidatableObject<string> CVV
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

                this.SetProperty(ref this.cvv, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the name from user.
        /// </summary>
        public ValidatableObject<string> Name
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

                this.SetProperty(ref this.name, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with a date picker that gets the date from user in the Add Card page.
        /// </summary>
        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                if (this.date == value)
                {
                    return;
                }

                this.SetProperty(ref this.date, value);
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

                this.SetProperty(ref this.isChecked, value);
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
        /// Intialize the property of name.
        /// </summary>
        private void InitializeProperties()
        {
            this.Name = new ValidatableObject<string>();
            this.CardNumber = new ValidatableObject<string>();
            this.CVV = new ValidatableObject<string>();
            this.ExpireDate = new ValidatableObject<string>();
        }

        /// <summary>
        /// Invoked when validation for name
        /// </summary>
        private void AddValidationRules()
        {
            this.Name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Name Required" });
            this.CardNumber.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Card Number Required" });
            this.CVV.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "CVV Required" });
            this.ExpireDate.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Select Expiry" });
        }

        /// <summary>
        /// Invoked when the add card button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void AddCardClicked(object obj)
        {
            if (this.IsNameValid())
            {
                // Do something
            }
        }

        /// <summary>
        /// check the name is empty or not
        /// </summary>
        /// <returns>returns bool value</returns>
        public bool IsNameValid()
        {
            bool isNameValid = this.Name.Validate();
            bool isNumberValid = this.CardNumber.Validate();
            bool isCvvValid = this.CVV.Validate();
            bool isExpireValid = this.ExpireDate.Validate();
            return isNameValid && isNumberValid && isCvvValid && isExpireValid;
        }

        #endregion
    }
}
