using System;
using System.Globalization;
using System.Windows.Input;
using EssentialUIKit.Validators;
using EssentialUIKit.Validators.Rules;
using EssentialUIKit.ViewModels.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.ContactUs
{
    /// <summary>
    /// ViewModel for contact us page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ContactUsViewModel : LoginViewModel
    {
        #region Fields

        private string mapMarkerLatitude;

        private string mapMarkerLongitude;

        private string mapMarkerImage;

        private string mapMarkerCloseImage;

        private string mapMarkerHeader;

        private string mapMarkerAddress;

        private string mapMarkerPhoneNumber;

        private string mapMarkerEmailId;

        private Point geoCoordinate;

        private ValidatableObject<string> name;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactUsViewModel" /> class.
        /// </summary>
        public ContactUsViewModel()
        {
            this.InitializeProperties();
            this.AddValidationRules();
            this.SendCommand = new Command(this.Send);
            this.MapMarkerImage = "Pin.png";
            this.MapMarkerLatitude = "40.133808";
            this.MapMarkerLongitude = "-75.516279";
            this.MapMarkerHeader = "Sipes Inc";
            this.MapMarkerAddress = "7654 Cleveland street, Phoenixville, PA 19460";
            this.MapMarkerEmailId = "dopuyi@hostguru.info";
            this.MapMarkerPhoneNumber = "+1-202-555-0101";
            this.MapMarkerCloseImage = "Close.png";
            this.GetPinLocation();
        }

        #endregion   

        #region Commands

        /// <summary>
        /// Gets or sets the command that is executed when the Send button is clicked.
        /// </summary>
        public ICommand SendCommand { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value of map marker latitude.
        /// </summary>
        public string MapMarkerLatitude
        {
            get
            {
                return this.mapMarkerLatitude;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerLatitude, value);
            }
        }

        /// <summary>
        /// Gets or sets a value of map marker longitude.
        /// </summary>
        public string MapMarkerLongitude
        {
            get
            {
                return this.mapMarkerLongitude;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerLongitude, value);
            }
        }

        /// <summary>
        /// Gets or sets a value for map marker template image.
        /// </summary>
        public string MapMarkerImage
        {
            get
            {
                return this.mapMarkerImage;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerImage, value);
            }
        }

        /// <summary>
        /// Gets or sets a value of map marker address.
        /// </summary>
        public string MapMarkerAddress
        {
            get
            {
                return this.mapMarkerAddress;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerAddress, value);
            }
        }

        /// <summary>
        /// Gets or sets a value of map marker phone number.
        /// </summary>
        public string MapMarkerPhoneNumber
        {
            get
            {
                return this.mapMarkerPhoneNumber;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerPhoneNumber, value);
            }
        }

        /// <summary>
        /// Gets or sets a value of map marker header.
        /// </summary>
        public string MapMarkerHeader
        {
            get
            {
                return this.mapMarkerHeader;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerHeader, value);
            }
        }

        /// <summary>
        /// Gets or sets a value for map marker email id.
        /// </summary>
        public string MapMarkerEmailId
        {
            get
            {
                return this.mapMarkerEmailId;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerEmailId, value);
            }
        }

        /// <summary>
        /// Gets or sets a value for map marker close image.
        /// </summary>
        public string MapMarkerCloseImage
        {
            get
            {
                return this.mapMarkerCloseImage;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerCloseImage, value);
            }
        }

        /// <summary>
        /// Gets or sets the geo coordinate.
        /// </summary>
        public Point GeoCoordinate
        {
            get
            {
                return this.geoCoordinate;
            }

            set
            {
                this.SetProperty(ref this.geoCoordinate, value);
            }
        }

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the name from user.
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

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the send button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void Send(object obj)
        {
            if (this.AreFieldsValid())
            {
                // Do Something
            }
        }

        /// <summary>
        /// This method is for getting the pin location detail.
        /// </summary>
        private void GetPinLocation()
        {
            this.GeoCoordinate = new Point(Convert.ToDouble(this.MapMarkerLatitude, CultureInfo.CurrentCulture), Convert.ToDouble(this.MapMarkerLongitude, CultureInfo.CurrentCulture));
        }

        /// <summary>
        /// Initializing the properties.
        /// </summary>
        private void InitializeProperties()
        {
            this.Name = new ValidatableObject<string>();
        }

        /// <summary>
        /// Validation rule for password
        /// </summary>
        private void AddValidationRules()
        {
            this.Name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Name Required" });
        }

        /// <summary>
        /// Check the entry is null or empty
        /// </summary>
        /// <returns></returns>
        public bool AreFieldsValid()
        {
            bool isEmailValid = this.Email.Validate();
            bool isNameValid = this.Name.Validate();
            return isEmailValid && isNameValid;
        }

        #endregion
    }
}
