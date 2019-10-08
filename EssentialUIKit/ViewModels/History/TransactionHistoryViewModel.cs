using System;
using System.Collections.ObjectModel;
using EssentialUIKit.Models.History;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.History
{
    /// <summary>
    /// ViewModel of transaction history template.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class TransactionHistoryViewModel
    {
        #region Constructor
        public TransactionHistoryViewModel()
        {
            var randomNum = new Random(0123456789);
            this.TransactionDetails = new ObservableCollection<Transactions>()
            {
                new Transactions
                {
                     CustomerName = "Alice",
                     TransactionDescription = "Cashback",
                     Image = App.BaseImageUrl + "ProfileImage15.png",
                     TransactionAmount = "+ $70",
                     Date = DateTime.Now.AddDays(randomNum.Next(-1000, 0)),
                     IsCredited = true
                },
                new Transactions
                {
                     CustomerName = "Jessica Park",
                     TransactionDescription = "XXXXXXX6585",
                     Image = App.BaseImageUrl + "ProfileImage10.png",
                     TransactionAmount = "+ $80",
                     Date = DateTime.Now.AddDays(randomNum.Next(-1000, 0)),
                     IsCredited = true
                },
                new Transactions
                {
                     CustomerName = "Lisa",
                     TransactionDescription = "Recharge",
                     Image = App.BaseImageUrl + "ProfileImage11.png",
                     TransactionAmount = "- $50",
                     Date = DateTime.Now.AddDays(randomNum.Next(-1000, 0)),
                     IsCredited = false
                },
                new Transactions
                {
                     CustomerName = "Rebecca",
                     TransactionDescription = "Credit Card Bill",
                     Image = App.BaseImageUrl + "ProfileImage12.png",
                     TransactionAmount = "- $180",
                     Date = DateTime.Now.AddDays(randomNum.Next(-1000, 0)),
                     IsCredited = false
                },
            };

            this.ItemSelectedCommand = new Command(this.ItemSelected);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the employee details.
        /// </summary>
        /// <value>The employee details.</value>
        public ObservableCollection<Transactions> TransactionDetails { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        private void ItemSelected(object selectedItem)
        {
            // Do something
        }

        #endregion
    }
}
