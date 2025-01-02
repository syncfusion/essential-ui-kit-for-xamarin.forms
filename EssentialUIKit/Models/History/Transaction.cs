using System;
using System.ComponentModel;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.History
{
    /// <summary>
    /// Model for transaction history template.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Transactions : INotifyPropertyChanged
    {
        #region Fields

        private string customerName;

        private string transactionDescription;

        private string image;

        private DateTime date;

        private string transactionAmount;

        private bool isCredited;

        #endregion

        #region EventHandler

        /// <summary>
        /// EventHandler of property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of an customer.
        /// </summary>
        public string CustomerName
        {
            get
            {
                return this.customerName;
            }

            set
            {
                this.customerName = value;
                this.OnPropertyChanged(nameof(CustomerName));
            }
        }

        /// <summary>
        /// Gets or sets the transaction description.
        /// </summary>
        public string TransactionDescription
        {
            get
            {
                return this.transactionDescription;
            }

            set
            {
                this.transactionDescription = value;
                this.OnPropertyChanged(nameof(TransactionDescription));
            }
        }

        /// <summary>
        /// Gets or sets the image of an user.
        /// </summary>
        public string Image
        {
            get
            {
                return this.image;
            }

            set
            {
                this.image = value;
                this.OnPropertyChanged(nameof(Image));
            }
        }

        /// <summary>
        /// Gets or sets the transaction amount.
        /// </summary>
        public string TransactionAmount
        {
            get
            {
                return this.transactionAmount;
            }

            set
            {
                this.transactionAmount = value;
                this.OnPropertyChanged(nameof(TransactionAmount));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the transaction type is credit.
        /// </summary>
        public bool IsCredited
        {
            get
            {
                return this.isCredited;
            }

            set
            {
                this.isCredited = value;
                this.OnPropertyChanged(nameof(IsCredited));
            }
        }

        /// <summary>
        /// Gets or sets the transaction amount.
        /// </summary>
        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                this.date = value;
                this.OnPropertyChanged(nameof(Date));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
