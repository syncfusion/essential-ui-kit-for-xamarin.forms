using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using EssentialUIKit.Models.Tracking;
using Syncfusion.XForms.ProgressBar;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Tracking
{
    /// <summary>
    /// ViewModel for train status page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class TrainStatusPageViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<Station> stationInfoCollection;
        private string nextStationTime;
        private double trainStartTimeDiff;
        private StepStatus lastStationStatus;
        private DateTime duration;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="TrainStatusPageViewModel" /> class.
        /// </summary>
        public TrainStatusPageViewModel()
        {
        }

        #endregion

        #region Events

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the station info collection.
        /// </summary>
        [DataMember(Name = "stationinfo")]
        public ObservableCollection<Station> StationInfoCollection
        {
            get
            {
                return this.stationInfoCollection;
            }

            set
            {
                this.stationInfoCollection = value;
                this.OnPropertyChanged();
                this.UpdateStatus();
            }
        }

        /// <summary>
        /// Gets or sets the next station time
        /// </summary>
        public string NextStationTime
        {
            get
            {
                return this.nextStationTime;
            }

            set
            {
                this.nextStationTime = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the train name
        /// </summary>
        [DataMember(Name = "trainname")]
        public string TrainName { get; set; }

        /// <summary>
        /// Gets or sets the  train number
        /// </summary>
        [DataMember(Name = "trainnumber")]
        public string TrainNumber { get; set; }

        /// <summary>
        /// Gets or sets the  departure station shortcut
        /// </summary>
        [DataMember(Name = "departurestationshortcut")]
        public string DepartureStationShortcut { get; set; }

        /// <summary>
        /// Gets or sets the departure station
        /// </summary>
        [DataMember(Name = "departurestation")]
        public string DepartureStation { get; set; }

        /// <summary>
        /// Gets or sets the arrival station shortcut
        /// </summary>
        [DataMember(Name = "arrivalstationshortcut")]
        public string ArrivalStationShortcut { get; set; }

        /// <summary>
        /// Gets or sets the arrival station
        /// </summary>
        [DataMember(Name = "arrivalstation")]
        public string ArrivalStation { get; set; }

        /// <summary>
        /// Gets or sets the duration
        /// </summary>
        public DateTime Duration
        {
            get
            {
                DateTime stringDuration = Convert.ToDateTime(this.StringDuration, 
                    CultureInfo.CurrentCulture);
                return DateTime.MinValue != stringDuration? stringDuration : this.duration;

            }

            set
            {
                if (this.duration != value)
                {
                    this.duration = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the string duration
        /// </summary>
        [DataMember(Name = "duration")]
        public string StringDuration { get; set; }

        /// <summary>
        /// Gets or sets the stop count
        /// </summary>
        [DataMember(Name = "stopcount")]
        public int StopCount { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// This method is used to update the status of the train
        /// </summary>
        public void UpdateStatus()
        {
            DateTime toStartTime;
            DateTime.TryParse("7:15:00 AM", out toStartTime);
            this.trainStartTimeDiff = DateTime.Now.Subtract(toStartTime).TotalSeconds;

            foreach (var stationInfo in this.StationInfoCollection)
            {
                var station = this.CreateStationInfo(stationInfo.Name, stationInfo.ArrivalDateTime.ToString(CultureInfo.CurrentCulture), double.Parse(stationInfo.Distance, CultureInfo.CurrentCulture));
                stationInfo.Name = station.Name;
                stationInfo.Arrival = station.Arrival;
                stationInfo.Departure = station.Departure;
                stationInfo.ArrivalDateTime = station.ArrivalDateTime;
                stationInfo.DepartureDateTime = station.DepartureDateTime;
                stationInfo.Distance = station.Distance;
                stationInfo.ProgressedDistance = station.ProgressedDistance;
                stationInfo.Status = station.Status;
            }
        }        
        
        /// <summary>
        /// This method is used to create the station information
        /// </summary>
        /// <param name="name">String value</param>
        /// <param name="toArrival">String value</param>
        /// <param name="toDistance">Double value</param>
        /// <returns>Date time</returns>
        public Station CreateStationInfo(string name, string toArrival, double toDistance)
        {
            DateTime dateTimeArr;

            DateTime toStartTime;
            DateTime.TryParse("7:00:00 AM", out toStartTime);
            DateTime toEndTime;
            DateTime.TryParse("7:00:00 PM", out toEndTime);

            StepStatus currentStatus = StepStatus.NotStarted;

            DateTime.TryParse(toArrival, out dateTimeArr);
            dateTimeArr = this.SetTrainTiming(dateTimeArr);

            if (this.lastStationStatus == StepStatus.Completed)
            {
                currentStatus = StepStatus.InProgress;
            }

            if (dateTimeArr <= DateTime.Now)
            {
                currentStatus = StepStatus.Completed;
            }

            this.lastStationStatus = currentStatus;

            var station = new Station()
            {
                Name = name,
                Arrival = dateTimeArr.TimeOfDay.ToString().Remove(5),
                Departure = dateTimeArr.AddMinutes(2).TimeOfDay.ToString().Remove(5),
                ArrivalDateTime = dateTimeArr,
                DepartureDateTime = dateTimeArr.AddMinutes(2),
                Distance = "Station at " + toDistance.ToString(CultureInfo.CurrentCulture) + " km",
                Status = currentStatus
            };

            if (station.Status == StepStatus.Completed)
            {
                station.ProgressedDistance = 100;
            }           

            return station;
        }

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Set the train timing
        /// </summary>
        /// <param name="dateTime">The Datetime</param>
        /// <returns>Date Time</returns>
        private DateTime SetTrainTiming(DateTime dateTime)
        {
            return dateTime.AddSeconds(this.trainStartTimeDiff - 6090);
        }
        #endregion
    }
}
