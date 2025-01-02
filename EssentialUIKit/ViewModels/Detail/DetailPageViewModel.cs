using System.Collections.Generic;
using System.Collections.ObjectModel;
using EssentialUIKit.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Detail
{
    /// <summary>
    /// ViewModel for detail page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class DetailPageViewModel : BaseViewModel
    {
        #region Fields

        private readonly double productRating;

        private Product productDetail;

        private ObservableCollection<Category> categories;

        private ObservableCollection<Review> reviews;

        private bool isFavourite;

        private bool isReviewVisible;

        private int? cartItemCount;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance for the <see cref="DetailPageViewModel" /> class.
        /// </summary>
        public DetailPageViewModel()
        {
            this.reviews = new ObservableCollection<Review>
            {
                new Review
                {
                    CustomerImage = "ProfileImage10.png",
                    CustomerName = "Serina Williams",
                    Comment = "Greatest purchase I have ever made in my life.",
                    ReviewedDate = "29 Dec, 2019",
                    Rating = 5,
                    Images = new List<string>
                    {
                        "Image1.png",
                        "Image1.png",
                        "Image1.png",
                        "Image1.png"
                    }
                },
                new Review
                {
                    CustomerImage = "ProfileImage11.png",
                    CustomerName = "Alise Valasquez",
                    Comment = "Absolutely love them! Can't stop wearing!",
                    ReviewedDate = "29 Dec, 2019",
                    Rating = 3,
                    Images = new List<string>
                    {
                       "Image1.png",
                       "Image1.png",
                       "Image1.png"
                    }
                }
            };

            this.ProductDetail = new Product
            {
                Name = "Full-Length Skirt",
                Summary = "This plaid, cotton skirt will keep you warm in the air-conditioned office or outside on cooler days.",
                ActualPrice = 245,
                DiscountPercent = 30,
                Description = "Ankle-length skirt with high waistband. Lightweight, comfortable cotton construction with side zipper.",
                PreviewImages = new List<string>
                {
                    "Image1.png",
                    "Image1.png",
                    "Image1.png",
                    "Image1.png",
                    "Image1.png",
                },

                Reviews = new ObservableCollection<Review>(reviews)
            };

            if (this.ProductDetail.Reviews == null || this.ProductDetail.Reviews.Count == 0)
            {
                this.IsReviewVisible = true;
            }
            else
            {
                foreach (var review in this.ProductDetail.Reviews)
                {
                    this.productRating += review.Rating;
                }
            }

            if (this.productRating > 0)
                this.ProductDetail.OverallRating = this.productRating / this.ProductDetail.Reviews.Count;

            this.Categories = new ObservableCollection<Category>
            {
                new Category
                {
                    Name = "Electronics",
                    SubCategories = new List<string>
                    {
                        "Laptops", "Mobiles", "Tablets", "Televisions", "Printers and Monitors"
                    }
                },
                new Category
                {
                    Name = "Fashion",
                    SubCategories = new List<string>
                    {
                        "Shirts", "Skirts", "Casual Wear", "Jeans", "Kurtis"
                    }
                },
                new Category
                {
                    Name = "Home and Furniture",
                    SubCategories = new List<string>
                    {
                        "Diwans", "Sofas", "Curtains"
                    }
                },
                new Category
                {
                    Name = "Personal Care",
                    SubCategories = new List<string>
                    {
                        "Laptops", "Mobiles", "Tablets", "Televisions", "Printers and Monitors"
                    }
                },
                new Category
                {
                    Name = "Sports and Books",
                    SubCategories = new List<string>
                    {
                        "Laptops", "Mobiles", "Tablets", "Televisions", "Printers and Monitors"
                    }
                },
                new Category
                {
                    Name = "Grocery",
                    SubCategories = new List<string>
                    {
                        "Laptops", "Mobiles", "Tablets", "Televisions", "Printers and Monitors"
                    }
                },
                new Category
                {
                    Name = "Toys and Baby",
                    SubCategories = new List<string>
                    {
                        "Laptops", "Mobiles", "Tablets", "Televisions", "Printers and Monitors"
                    }
                },
            };

            this.AddFavouriteCommand = new Command(this.AddFavouriteClicked);
            this.AddToCartCommand = new Command(this.AddToCartClicked);
            this.ShareCommand = new Command(this.ShareClicked);
            this.VariantCommand = new Command(this.VariantClicked);
            this.ItemSelectedCommand = new Command(this.ItemSelected);
            this.CardItemCommand = new Command(this.CartClicked);
            this.LoadMoreCommand = new Command(this.LoadMoreClicked);
            this.BackButtonCommand = new Command(BackButtonClicked);
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the property that has been bound with SfRotator and labels, which display the product images and details.
        /// </summary>
        public Product ProductDetail
        {
            get
            {
                return this.productDetail;
            }

            set
            {
                if (this.productDetail == value)
                {
                    return;
                }

                this.productDetail = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with StackLayout, which displays the categories using ComboBox.
        /// </summary>
        public ObservableCollection<Category> Categories
        {
            get
            {
                return this.categories;
            }

            set
            {
                if (this.categories == value)
                {
                    return;
                }

                this.categories = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with view, which displays the Favourite.
        /// </summary>
        public bool IsFavourite
        {
            get
            {
                return this.isFavourite;
            }
            set
            {
                this.isFavourite = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with view, which displays the empty message.
        /// </summary>
        public bool IsReviewVisible
        {
            get
            {
                if (productDetail.Reviews.Count == 0)
                {
                    this.isReviewVisible = true;
                }

                return this.isReviewVisible;
            }
            set
            {
                this.isReviewVisible = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with view, which displays the cart items count.
        /// </summary>
        public int? CartItemCount
        {
            get
            {
                return this.cartItemCount;
            }
            set
            {
                this.cartItemCount = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the command that will be executed when the Favourite button is clicked.
        /// </summary>
        public Command AddFavouriteCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the AddToCart button is clicked.
        /// </summary>
        public Command AddToCartCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the Share button is clicked.
        /// </summary>
        public Command ShareCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the size button is clicked.
        /// </summary>
        public Command VariantCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when cart button is clicked.
        /// </summary>
        public Command CardItemCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the Show All button is clicked.
        /// </summary>
        public Command LoadMoreCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the back button is clicked.
        /// </summary>
        public Command BackButtonCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Favourite button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void AddFavouriteClicked(object obj)
        {
            if (obj is DetailPageViewModel model)
            {
                model.ProductDetail.IsFavourite = !model.ProductDetail.IsFavourite;
            }
        }

        /// <summary>
        /// Invoked when the Cart button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void AddToCartClicked(object obj)
        {
            this.cartItemCount = this.cartItemCount ?? 0;
            this.CartItemCount += 1;
            // Do something
        }

        /// <summary>
        /// Invoked when the Share button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ShareClicked(object obj)
        {
            // Do something.
        }

        /// <summary>
        /// Invoked when the variant button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void VariantClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="attachedObject">The Object</param>
        private void ItemSelected(object attachedObject)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when cart icon button is clicked.
        /// </summary>
        /// <param name="obj"></param>
        private void CartClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when Load more button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoadMoreClicked (object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when an back button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void BackButtonClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
