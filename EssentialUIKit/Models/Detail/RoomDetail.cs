using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EssentialUIKit.ViewModels;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Detail
{
    /// <summary>
    /// Model for room booking page
    /// </summary>
    [Preserve(AllMembers = true)]
    public class RoomDetail : BaseViewModel
    {
        #region Fields

        private string imagePath;

        private int cost;

        private string selectedRanges;

        private IReadOnlyCollection<Review> reviews = new ObservableCollection<Review>();

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        public string ImagePath
        {
            get { return App.ImageServerPath + this.imagePath; }
            set { this.imagePath = value; }
        }

        /// <summary>
        /// Gets or sets the selected ranges 
        /// </summary>
        public string SelectedRanges
        {
            get
            {
                return this.selectedRanges;
            }

            set
            {
                this.SetProperty(ref this.selectedRanges, value);
            }
        }

        /// <summary>
        /// Gets or sets the cost of resort.
        /// </summary>
        public int Cost
        {
            get
            {
                return this.cost;
            }

            set
            {
                this.SetProperty(ref this.cost, value);
            }
        }

        /// <summary>
        /// Gets or sets the total days.
        /// </summary>
        public int TotalDays { get; set; }

        /// <summary>
        /// Gets or sets the name of the resort.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display text.
        /// </summary>
        public string DisplayText { get; set; }

        /// <summary>
        /// Gets or sets the value text.
        /// </summary>
        public int ValueText { get; set; }

        /// <summary>
        /// Gets or sets the description of the resort.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the overall of the resort.
        /// </summary>
        public double OverallRating { get; set; }

        /// <summary>
        /// Gets or sets the reviews of the resort.
        /// </summary>
        public string TotalReviews { get; set; }

        /// <summary>
        /// Gets or sets the resort description.
        /// </summary>
        public string ResortDescription { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the facility of resort.
        /// </summary>
        public string Facility { get; set; }

        /// <summary>
        /// Gets or sets the count of bed.
        /// </summary>
        public ReadOnlyCollection<string> BedCount { get; set; }

        /// <summary>
        /// Gets or sets the addresss of the resort.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the resort.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with a date picker .
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the review of the customers .
        /// </summary>
        public IReadOnlyCollection<Review> Reviews
        {
            get
            {
                return this.reviews;
            }

            set
            {
                this.reviews = value;
                this.NotifyPropertyChanged(nameof(this.Reviews));
            }
        }

        #endregion    
    }
}
