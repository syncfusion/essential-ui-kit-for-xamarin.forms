using EssentialUIKit.Models.Feedback;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Detail
{
    /// <summary>
    /// ViewModel for detail page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class DetailViewModel : BaseViewModel
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
            var randomNum = new Random(0123456789);
            this.FeedbackInfo = new ObservableCollection<Review>
            {
                new Review
                {
                    CustomerName = "Jessica Park",
                    Comment = "These boots are stunning and I look stunning in them.",
                    ReviewedDate = DateTime.Now.AddDays(randomNum.Next(0, 1000)),
                    CustomerImage = App.BaseImageUrl + "ProfileImage" + randomNum.Next(1, 19) + ".png",
                    Rating = randomNum.Next(0, 5),
                    Images = new List<string>
                    {
                        App.BaseImageUrl + "ReviewShoe.png",
                        App.BaseImageUrl + "ReviewShoe.png"
                    }
                },
                new Review
                {
                    CustomerName = "Alice",
                    Comment = "Greatest purchase I have ever made in my life. No lie.",
                    ReviewedDate = DateTime.Now.AddDays(randomNum.Next(0, 1000)),
                    CustomerImage = App.BaseImageUrl + "ProfileImage" + randomNum.Next(1, 19) + ".png",
                    Rating = randomNum.Next(0, 5)
                },
                new Review
                {
                    CustomerName = "John",
                    Comment = "Absolutely love them! Can’t stop wearing!",
                    ReviewedDate = DateTime.Now.AddDays(randomNum.Next(0, 1000)),
                    CustomerImage = App.BaseImageUrl + "ProfileImage" + randomNum.Next(1, 19) + ".png",
                    Rating = randomNum.Next(0, 5)
                },
                new Review
                {
                    CustomerName = "Lisa",
                    Comment = "These boots are very much comfortable for wearing.",
                    ReviewedDate = DateTime.Now.AddDays(randomNum.Next(0, 1000)),
                    CustomerImage = App.BaseImageUrl + "ProfileImage" + randomNum.Next(1, 19) + ".png",
                    Rating = randomNum.Next(0, 5),
                    Images = new List<string>
                    {
                        App.BaseImageUrl + "ReviewShoe.png",
                        App.BaseImageUrl + "ReviewShoe.png",
                        App.BaseImageUrl + "ReviewShoe.png"
                    }
                },
                new Review
                {
                    CustomerName = "Rebacca",
                    Comment = "Absolutely love them! Can’t stop wearing!",
                    ReviewedDate = DateTime.Now.AddDays(randomNum.Next(0, 1000)),
                    CustomerImage = App.BaseImageUrl + "ProfileImage" + randomNum.Next(1, 19) + ".png",
                    Rating = randomNum.Next(0, 5)
                },
                new Review
                {
                    CustomerName = "Jessica Park",
                    Comment = "Happy purchasing!",
                    ReviewedDate = DateTime.Now.AddDays(randomNum.Next(0, 1000)),
                    CustomerImage = App.BaseImageUrl + "ProfileImage" + randomNum.Next(1, 19) + ".png",
                    Rating = randomNum.Next(4, 5)
                },
                new Review
                {
                    CustomerName = "Alice",
                    Comment = "Happy buying!",
                    ReviewedDate = DateTime.Now.AddDays(randomNum.Next(0, 1000)),
                    CustomerImage = App.BaseImageUrl + "ProfileImage" + randomNum.Next(1, 19) + ".png",
                    Rating = randomNum.Next(0, 5),
                    Images = new List<string>
                    {
                        App.BaseImageUrl + "ReviewShoe.png",
                        App.BaseImageUrl + "ReviewShoe.png",
                        App.BaseImageUrl + "ReviewShoe.png",
                        App.BaseImageUrl + "ReviewShoe.png"
                    }
                }
            };

            this.Images = new List<string>
            {
                App.BaseImageUrl + "Shoe1.png",
                App.BaseImageUrl + "Shoe1.png",
                App.BaseImageUrl + "Shoe1.png"
            };
            this.CloseCommand = new Command(this.OnCloseButtonTapped);
            this.ProfileCommand = new Command(this.ProfileClicked);
            this.ItemSelectedCommand = new Command(this.ItemSelected);
            this.SortCommand = new Command(this.OnSortTapped);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value for feedback info.
        /// </summary>
        public ObservableCollection<Review> FeedbackInfo { get; set; }

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

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the sorting button is clicked.
        /// </summary>
        public Command SortCommand { get; set; }

        #endregion

        #region Methods

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

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        private void ItemSelected(object selectedItem)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the sorting button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void OnSortTapped(object obj)
        {
            // Do something
        }

        #endregion
    }
}
