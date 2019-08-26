using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Syncfusion.SfMaps.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using EssentialUIKit.Models.ContactUs;

namespace EssentialUIKit.ViewModels.ContactUs
{
    /// <summary>
    /// ViewModel for contact us page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ContactUsViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<MapMarker> customMarkers;

        private Point geoCoordinate;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactUsViewModel" /> class.
        /// </summary>
        public ContactUsViewModel()
        {
            this.SendCommand = new Command(this.Send);
            this.CustomMarkers = new ObservableCollection<MapMarker>
            {
                new LocationMarker
                {
                    PinImage = "Pin.png",
                    Header = "Sipes Inc",
                    Address = "7654 Cleveland street, Phoenixville, PA 19460",
                    EmailId = "dopuyi@hostguru.info",
                    PhoneNumber = "+1-202-555-0101",
                    CloseImage = "Close.png",
                    Latitude = "40.133808",
                    Longitude = "-75.516279"
                }
            };

            foreach (var marker in this.CustomMarkers)
            {
                this.GeoCoordinate = new Point(Convert.ToDouble(marker.Latitude), Convert.ToDouble(marker.Longitude));
            }            
        }

        #endregion   

        #region Event

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the command that is executed when the Send button is clicked.
        /// </summary>
        public ICommand SendCommand { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the CustomMarkers collection.
        /// </summary>
        public ObservableCollection<MapMarker> CustomMarkers
        {
            get
            {
                return this.customMarkers;
            }

            set
            {
                this.customMarkers = value;
                this.OnPropertyChanged();
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
                this.geoCoordinate = value;
                this.OnPropertyChanged();
            }
        }

        #endregion
                     
        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Invoked when the send button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void Send(object obj)
        {
            // Do something
        }

        #endregion
    }
}
