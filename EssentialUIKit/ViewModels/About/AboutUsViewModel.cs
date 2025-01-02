using System.Collections.ObjectModel;
using EssentialUIKit.Models.About;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.About
{
    /// <summary>
    /// ViewModel of AboutUs templates.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class AboutUsViewModel : BaseViewModel
    {
        #region Fields

        private string productDescription;

        private string productVersion;

        private string productIcon;

        private string cardsTopImage;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="T:EssentialUIKit.ViewModels.About.AboutUsViewModel"/> class.
        /// </summary>
        public AboutUsViewModel()
        {
            this.productDescription =
                "Situated in the heart of Smith-town, Acme Products, Inc., has a long-standing tradition of selling the best products while providing the fastest service on the market. Since 1952, we’ve helped our customers identify their needs, understand their wants, and capture their dreams.";
            this.productIcon = App.BaseImageUrl + "Icon.png";
            this.productVersion = "1.0";
            this.cardsTopImage = App.BaseImageUrl + "Mask.png";

            this.EmployeeDetails = new ObservableCollection<AboutUsModel>
            {
                new AboutUsModel
                {
                    EmployeeName = "Alice",
                    Image = App.BaseImageUrl + "ProfileImage15.png",
                    Designation = "Project Manager"
                },
                new AboutUsModel
                {
                    EmployeeName = "Jessica Park",
                    Image = App.BaseImageUrl + "ProfileImage10.png",
                    Designation = "Senior Manager"
                },
                new AboutUsModel
                {
                    EmployeeName = "Lisa",
                    Image = App.BaseImageUrl + "ProfileImage11.png",
                    Designation = "Senior Developer"
                },
                new AboutUsModel
                {
                    EmployeeName = "Rebecca",
                    Image = App.BaseImageUrl + "ProfileImage12.png",
                    Designation = "Senior Designer"
                },
                new AboutUsModel
                {
                    EmployeeName = "Alexander",
                    Image = App.BaseImageUrl + "ProfileImage3.png",
                    Designation = "Senior Manager"
                },
                new AboutUsModel
                {
                    EmployeeName = "Anthony",
                    Image = App.BaseImageUrl + "ProfileImage1.png",
                    Designation = "Senior Developer"
                },
                new AboutUsModel
                {
                    EmployeeName = "Danielle",
                    Image = App.BaseImageUrl + "ProfileImage7.png",
                    Designation = "Senior Developer"
                },
                 new AboutUsModel
                {
                    EmployeeName = "Kyle Greene",
                    Image = App.BaseImageUrl + "ProfileImage6.png",
                    Designation = "Senior Developer"
                },
                  new AboutUsModel
                {
                    EmployeeName = "Navya Sharma",
                    Image = App.BaseImageUrl + "ProfileImage13.png",
                    Designation = "Testing Engineer"
                }
            };
            
            this.ItemSelectedCommand = new Command(this.ItemSelected);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the top image source of the About us with cards view.
        /// </summary>
        /// <value>Image source location.</value>
        public string CardsTopImage
        {
            get
            {
                return this.cardsTopImage;
            }

            set
            {
                this.cardsTopImage = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the description of a product or a company.
        /// </summary>
        /// <value>The product description.</value>
        public string ProductDescription
        {
            get
            {
                return this.productDescription;
            }

            set
            {
                this.productDescription = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the product icon.
        /// </summary>
        /// <value>The product icon.</value>
        public string ProductIcon
        {
            get
            {
                return this.productIcon;
            }

            set
            {
                this.productIcon = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the product version.
        /// </summary>
        /// <value>The product version.</value>
        public string ProductVersion
        {
            get
            {
                return this.productVersion;
            }

            set
            {
                this.productVersion = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the employee details.
        /// </summary>
        /// <value>The employee details.</value>
        public ObservableCollection<AboutUsModel> EmployeeDetails { get; set; }

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