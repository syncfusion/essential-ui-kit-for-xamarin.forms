﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Detail
{
    /// <summary>
    /// ViewModel for detail page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class DetailViewModel : INotifyPropertyChanged
    {
        #region Fields

        private List<string> images;

        #endregion

        #region Constrctor
        /// <summary>
        /// Initializes a new instance for the <see cref="DetailViewModel" /> class.
        /// </summary>
        public DetailViewModel()
        {
            this.Images = new List<string>
            {
                App.BaseImageUrl + "Shoe1.png",
                App.BaseImageUrl + "Shoe1.png",
                App.BaseImageUrl + "Shoe1.png"
            };
            this.CloseCommand = new Command(this.OnCloseButtonTapped);
            this.ProfileCommand = new Command(this.ProfileClicked);
        }

        #endregion

        #region Event

        /// <summary>
        /// /// The declaration of the property changed event.
        /// /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties
        
        /// <summary>
        /// Gets or sets the value for images.
        /// </summary>
        public List<string> Images
        {
            get
            {
                return this.images;
            }

            set
            {
                if (this.images == value)
                {
                    return;
                }

                this.images = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the close button is clicked.
        /// </summary>
        public Command CloseCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the profile is clicked.
        /// </summary>
        public Command ProfileCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Invoked when the close button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void OnCloseButtonTapped(object obj)
        {
            // Do Something
        }

        /// <summary>
        /// Invoked when the profile is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ProfileClicked(object obj)
        {
            // Do Something
        }

        #endregion
    }
}
