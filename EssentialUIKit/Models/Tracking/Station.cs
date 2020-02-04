using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Syncfusion.XForms.ProgressBar;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Tracking
{
    /// <summary>
    /// Model for TrainTracking
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Station : INotifyPropertyChanged
    {
        #region Fields

        private string name;
        private string arrival;
        private DateTime arrivalDateTime;
        private DateTime departureDateTime;
        private string departure;
        private double progressDistance;
        private string distance;
        private StepStatus status;

        #endregion

        #region event

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the arrival
        /// </summary>
        [DataMember(Name = "arrival")]
        public string Arrival
        {
            get
            {
                return this.arrival;
            }

            set
            {
                if (this.arrival != value)
                {
                    this.arrival = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the arrival date time
        /// </summary>        
        public DateTime ArrivalDateTime
        {
            get
            {
                DateTime arrivalStringDate = Convert.ToDateTime(this.ArrivalStringDate,
                    CultureInfo.CurrentCulture);
                return DateTime.MinValue != arrivalStringDate ? arrivalStringDate : this.arrivalDateTime;

            }

            set
            {
                if (this.arrivalDateTime != value)
                {
                    this.arrivalDateTime = value;
                    this.OnPropertyChanged();
                }
            }
        }

        [DataMember(Name = "arrivaldatetime")]
        public string ArrivalStringDate { get; set; }

        /// <summary>
        /// Gets or sets the departure date time
        /// </summary>
        public DateTime DepartureDateTime
        {
            get
            {
                DateTime departureStringDate = Convert.ToDateTime(this.DepartureStringDate,
                     CultureInfo.CurrentCulture);
                return DateTime.MinValue != departureStringDate ? departureStringDate : this.departureDateTime;
            }

            set
            {
                if (this.departureDateTime != value)
                {
                    this.departureDateTime = value;
                    this.OnPropertyChanged();
                }
            }
        }

        [DataMember(Name = "departuredatetime")]
        public string DepartureStringDate { get; set; }

        /// <summary>
        /// Gets or sets the departure
        /// </summary>
        [DataMember(Name = "departure")]
        public string Departure
        {
            get
            {
                return this.departure;
            }

            set
            {
                if (this.departure != value)
                {
                    this.departure = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the progressed distance
        /// </summary>
        [DataMember(Name = "progresseddistance")]
        public double ProgressedDistance
        {
            get
            {
                return this.progressDistance;
            }

            set
            {
                if (this.progressDistance != value)
                {
                    this.progressDistance = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the distance
        /// </summary>
        [DataMember(Name = "distance")]
        public string Distance
        {
            get
            {
                return this.distance;
            }

            set
            {
                if (this.distance != value)
                {
                    this.distance = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the status
        /// </summary>
        public StepStatus Status
        {
            get
            {
                return this.status;
            }

            set
            {
                if (this.status != value)
                {
                    this.status = value;
                    this.OnPropertyChanged();
                }
            }
        }        

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
