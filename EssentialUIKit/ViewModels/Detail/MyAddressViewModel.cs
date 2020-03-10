using Xamarin.Forms;
using EssentialUIKit.Models.Detail;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Detail
{
    /// <summary>
    /// ViewModel for my address page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class MyAddressViewModel : BaseViewModel
    {
        #region Properties
        public ObservableCollection<Address> AddressDetails { get; set; }
        #endregion

        #region Constructor
        public MyAddressViewModel()
        {
            this.BackCommand = new Command(this.BackButtonClicked);
            this.EditCommand = new Command(this.EditButtonClicked);
            this.DeleteCommand = new Command(this.DeleteButtonClicked);
            this.AddCardCommand = new Command(this.AddCardButtonClicked);

            this.AddressDetails = new ObservableCollection<Address>()
            {
                new Address
                {
                    Name = "John Doe",
                    AddressType = "Home",
                    Location = "Akshya Nagar 1st Block 1st Cross, Rammurthy Nagar, Bangalore-560016",
                    ContactNumber = "+91 984-356-2332"
                },
                new Address
                {
                    Name = "John Doe",
                    AddressType = "Work",
                    Location = "126/3, Sarjapur Main Rd, opp. KEB, near Bharat Petroleum, Sulikunte, Banglore-562125",
                    ContactNumber = "+91 984-356-2332"
                },
            };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the back button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void BackButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the edit button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void EditButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the delete button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void DeleteButtonClicked(object obj)
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
        public Command BackCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the edit button is clicked.
        /// </summary>
        public Command EditCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the delete button is clicked.
        /// </summary>
        public Command DeleteCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the add card button is clicked.
        /// </summary>
        public Command AddCardCommand { get; set; }

        #endregion
    }
}
