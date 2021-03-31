using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.History
{
    /// <summary>
    /// Model for transaction history template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class TransactionHistory : INotifyPropertyChanged
    {
        #region Fields

        private static Random random = new Random();

        private string customerName;

        private string transactionDescription;

        private string customerImage;

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
        [DataMember(Name = "customerName")]
        public string CustomerName
        {
            get
            {
                return this.customerName;
            }

            set
            {
                this.customerName = value;
                this.OnPropertyChanged(nameof(this.CustomerName));
            }
        }

        /// <summary>
        /// Gets or sets the transaction description.
        /// </summary>
        [DataMember(Name = "transactionDescription")]
        public string TransactionDescription
        {
            get
            {
                return this.transactionDescription;
            }

            set
            {
                this.transactionDescription = value;
                this.OnPropertyChanged(nameof(this.TransactionDescription));
            }
        }

        /// <summary>
        /// Gets or sets the image of an user.
        /// </summary>
        [DataMember(Name = "customerImage")]
        public string CustomerImage
        {
            get
            {
                return App.ImageServerPath + this.customerImage;
            }

            set
            {
                this.customerImage = value;
                this.OnPropertyChanged(nameof(this.CustomerImage));
            }
        }

        /// <summary>
        /// Gets or sets the transaction amount.
        /// </summary>
        [DataMember(Name = "transactionAmount")]
        public string TransactionAmount
        {
            get
            {
                return this.transactionAmount;
            }

            set
            {
                this.transactionAmount = value;
                this.OnPropertyChanged(nameof(this.TransactionAmount));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the transaction type is credit.
        /// </summary>
        [DataMember(Name = "isCredited")]
        public bool IsCredited
        {
            get
            {
                return this.isCredited;
            }

            set
            {
                this.isCredited = value;
                this.OnPropertyChanged(nameof(this.IsCredited));
            }
        }

        /// <summary>
        /// Gets or sets the transaction amount.
        /// </summary>
        public DateTime Date
        {
            get
            {
                if (random != null)
                {
                    return this.date = DateTime.Now.AddDays(random.Next(-1000, 0));
                }

                return this.date;
            }

            set
            {
                this.date = value;
                this.OnPropertyChanged(nameof(this.Date));
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
