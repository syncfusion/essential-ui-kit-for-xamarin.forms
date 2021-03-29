using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EssentialUIKit.Models;
using Syncfusion.XForms.ComboBox;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Controls
{
    [Preserve(AllMembers = true)]
    public class CountryComboBox : SfComboBox, INotifyPropertyChanged
    {
        #region Fields

        private object country;

        private string phoneNumberPlaceHolder = "Phone Number";

        private string phoneNumber;

        private string city;

        private object state;

        private IReadOnlyCollection<string> states;

        private string countryCode;

        /// <summary>
        /// Gets or sets string property that represents mask format for phone number. 
        /// </summary>
        private string mask = string.Empty;

        #endregion

        #region Constructor

        public CountryComboBox()
        {
            this.BindingContext = this;

            this.Countries = new List<CountryModel>();
            this.Countries.Add(new CountryModel()
            {
                Country = "Australia",
                States = new string[] { "Tasmania", "Victoria", "Queensland", "Northen Territory" },
            });
            this.Countries.Add(new CountryModel()
            {
                Country = "Brazil",
                States = new string[] { "Bahia", "Ceara", "Goias", "Maranhao" },
            });
            this.Countries.Add(new CountryModel()
            {
                Country = "Canada",
                States = new string[] { "Manitoba", "Ontario", "Quebec", "Yukon" },
            });
            this.Countries.Add(new CountryModel()
            {
                Country = "India",
                States = new string[] { "Assam", "Gujarat", "Haryana", "Tamil Nadu" },
            });
            this.Countries.Add(new CountryModel()
            {
                Country = "USA",
                States = new string[] { "California", "Florida", "New York", "Washington" },
            });

            this.DataSource = this.Countries;
            this.SetBinding(SfComboBox.SelectedItemProperty, "Country", BindingMode.TwoWay);
            this.DisplayMemberPath = "Country";
            this.Watermark = "Select Country";
            this.VerticalOptions = LayoutOptions.CenterAndExpand;
        }

        #endregion

        #region Event handler

        /// <summary>
        /// Occurs when the property is changed.
        /// </summary>
        public new event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the property that bounds with a ComboBox that gets the Country from user.
        /// </summary>
        public object Country
        {
            get { return this.country; }

            set
            {
                this.country = value;
                this.UpdateStateAndPhoneNumberFormat();
            }
        }

        /// <summary>
        /// Gets or set the string property, that represents the phone number format based on country. 
        /// </summary>
        public string PhoneNumberPlaceHolder
        {
            get { return this.phoneNumberPlaceHolder; }

            set
            {
                this.phoneNumberPlaceHolder = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or set the string property, that represents the phone number based on country. 
        /// </summary>
        public string PhoneNumber
        {
            get { return this.phoneNumber; }

            set
            {
                this.phoneNumber = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the string property, which holds the contry code based on user input. 
        /// </summary>
        public string CountryCode
        {
            get { return this.countryCode; }

            set
            {
                this.countryCode = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or set the string property, that represents the user given city. 
        /// </summary>
        public string City
        {
            get { return this.city; }

            set
            {
                this.city = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with a ComboBox that gets the State from user.
        /// </summary>
        public object State
        {
            get { return this.state; }

            set
            {
                this.state = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets array collection that contains states based on country selection. 
        /// </summary>
        public IReadOnlyCollection<string> States
        {
            get { return this.states; }

            set
            {
                this.states = value;
                this.NotifyPropertyChanged();
            }
        }

        public string Mask
        {
            get => this.mask;
            set
            {
                this.mask = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the collection property, which contains the countries data. 
        /// </summary>
        public List<CountryModel> Countries { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Method used to rest State and City and update PhoneNumber format. 
        /// </summary>
        private void UpdateStateAndPhoneNumberFormat()
        {
            this.State = null;
            this.PhoneNumber = string.Empty;
            this.City = string.Empty;
            CountryModel countryModel = this.Country as CountryModel;
            this.States = countryModel.States;

            switch (countryModel.Country)
            {
                case "Australia":
                    this.PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    this.Mask = "(+61)X XXXX XXXX";
                    this.CountryCode = "(+61)";
                    break;
                case "Brazil":
                    this.PhoneNumberPlaceHolder = "e.g. XX XXXX XXXX";
                    this.Mask = "(+55)XX XXXX XXXX";
                    this.CountryCode = "(+55)";
                    break;
                case "Canada":
                    this.PhoneNumberPlaceHolder = "e.g. XXXXXXXXX";
                    this.Mask = "(+1)XXXXXXXXX";
                    this.CountryCode = "(+1)";
                    break;
                case "India":
                    this.PhoneNumberPlaceHolder = "e.g. XXXXX-XXXXX";
                    this.Mask = "(+91)XXXXX-XXXXX";
                    this.CountryCode = "(+91)";
                    break;
                case "USA":
                    this.PhoneNumberPlaceHolder = "e.g. XXX-XXX-XXX";
                    this.Mask = "(+1)XXX-XXX-XXX";
                    this.CountryCode = "(+1)";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}