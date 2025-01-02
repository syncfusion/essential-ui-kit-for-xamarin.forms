using EssentialUIKit.Models;
using Syncfusion.XForms.ComboBox;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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

        private string[] states;

        private string countryCode;

        #endregion

        #region Constructor
        public CountryComboBox()
        {
            BindingContext = this;

            Countries = new List<CountryModel>();
            Countries.Add(new CountryModel()
            {
                Country = "Australia",
                States = new string[] { "Tasmania", "Victoria", "Queensland", "Northen Territory" }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Brazil",
                States = new string[] { "Bahia", "Ceara", "Goias", "Maranhao" }
            });
            Countries.Add(new CountryModel()
            {
                Country = "Canada",
                States = new string[] { "Manitoba", "Ontario", "Quebec", "Yukon" }
            });
            Countries.Add(new CountryModel()
            {
                Country = "India",
                States = new string[] { "Assam", "Gujarat", "Haryana", "Tamil Nadu" }
            });
            Countries.Add(new CountryModel()
            {
                Country = "USA",
                States = new string[] { "California", "Florida", "New York", "Washington" }
            });

            DataSource = Countries;
            this.SetBinding(SfComboBox.SelectedItemProperty, "Country",BindingMode.TwoWay);
            DisplayMemberPath = "Country";
            Watermark = "Select Country";
            this.VerticalOptions = LayoutOptions.CenterAndExpand;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the property that bounds with a ComboBox that gets the Country from user.
        /// </summary>
        public object Country
        {
            get { return country; }
            set
            {
                country = value;
                UpdateStateAndPhoneNumberFormat();
            }
        }

        /// <summary>
        /// Gets or set the string property, that represents the phone number format based on country. 
        /// </summary>
        public string PhoneNumberPlaceHolder
        {
            get { return phoneNumberPlaceHolder; }
            set
            {
                phoneNumberPlaceHolder = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or set the string property, that represents the phone number based on country. 
        /// </summary>
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                NotifyPropertyChanged();
            }
        }

       
        /// <summary>
        /// Gets or sets the string property, which holds the contry code based on user input. 
        /// </summary>
        public string CountryCode
        {
            get { return countryCode; }
            set 
            {
                countryCode = value;
                NotifyPropertyChanged();
            }
        }


        /// <summary>
        /// Gets or set the string property, that represents the user given city. 
        /// </summary>
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that bounds with a ComboBox that gets the State from user.
        /// </summary>
        public object State
        {
            get { return state; }
            set
            {
                state = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets array collection that contains states based on country selection. 
        /// </summary>
        public string[] States
        {
            get { return states; }
            set 
            {
                states = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets string property that represents mask format for phone number. 
        /// </summary>
        private string _mask = "";
        public string Mask
        {
            get => _mask;
            set
            {
                _mask = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the collection property, which contains the countries data. 
        /// </summary>
        public List<CountryModel> Countries { get; set; }

        #endregion

        #region Event handler

        /// <summary>
        /// Occurs when the property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        /// <summary>
        /// Method used to rest State and City and update PhoneNumber format. 
        /// </summary>
        private void UpdateStateAndPhoneNumberFormat()
        {
            State = null;
            PhoneNumber = string.Empty;
            City = string.Empty;
            CountryModel countryModel = Country as CountryModel;
            States = countryModel.States;

            switch (countryModel.Country)
            {
                case "Australia":
                    PhoneNumberPlaceHolder = "e.g. X XXXX XXXX";
                    Mask = "(+61)X XXXX XXXX";
                    CountryCode = "(+61)";
                    break;
                case "Brazil":
                    PhoneNumberPlaceHolder = "e.g. XX XXXX XXXX";
                    Mask = "(+55)XX XXXX XXXX";
                    CountryCode = "(+55)";
                    break;
                case "Canada":
                    PhoneNumberPlaceHolder = "e.g. XXXXXXXXX";
                    Mask = "(+1)XXXXXXXXX";
                    CountryCode = "(+1)";
                    break;
                case "India":
                    PhoneNumberPlaceHolder = "e.g. XXXXX-XXXXX";
                    Mask = "(+91)XXXXX-XXXXX";
                    CountryCode = "(+91)";
                    break;
                case "USA":
                    PhoneNumberPlaceHolder = "e.g. XXX-XXX-XXX";
                    Mask = "(+1)XXX-XXX-XXX";
                    CountryCode = "(+1)";
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