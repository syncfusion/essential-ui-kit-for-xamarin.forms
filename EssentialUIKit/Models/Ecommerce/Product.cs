using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.ECommerce
{
    /// <summary>
    /// Model for pages with product.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Product : INotifyPropertyChanged
    {
        #region Fields

        private bool isFavourite;

        private string previewImage;

        private List<string> previewImages;

        private int totalQuantity;

        ObservableCollection<Review> reviews = new ObservableCollection<Review>();

        #endregion

        #region Event

        /// <summary>
        /// The declaration of property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the property that holds the product id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with Xamarin.Forms Image, which displays the product image.
        /// </summary>
        [DataMember(Name = "previewimage")]
        public string PreviewImage
        {
            get { return App.BaseImageUrl + this.previewImage; }
            set { this.previewImage = value; }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with SfRotator, which displays the item images.
        /// </summary>
        [DataMember(Name = "previewimages")]
        public List<string> PreviewImages
        {
            get
            {
                for (var i = 0; i < this.previewImages.Count; i++)
                {
                    this.previewImages[i] = this.previewImages[i].Contains(App.BaseImageUrl) ? this.previewImages[i] : App.BaseImageUrl + this.previewImages[i];
                }

                return this.previewImages;
            }

            set
            {
                this.previewImages = value;
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the product name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the product summary.
        /// </summary>
        [DataMember(Name = "summary")]
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the product description.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the actual price of the product.
        /// </summary>
        [DataMember(Name = "actualprice")]
        public double ActualPrice { get; set; }

        /// <summary>
        /// Gets the property that has been bound with a label, which displays the discounted price of the product.
        /// </summary>
        public double DiscountPrice
        {
            get
            {
                return this.ActualPrice - (this.ActualPrice * (this.DiscountPercent / 100));
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the discounted percent of the product.
        /// </summary>
        [DataMember(Name = "discountpercent")]
        public double DiscountPercent { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the overall rating of the product.
        /// </summary>
        [DataMember(Name = "overallrating")]
        public double OverallRating { get; set; }
        
        /// <summary>
        /// Gets or sets the property that has been bound with view, which displays the customer review.
        /// </summary>
        [DataMember(Name = "reviews")]
        public ObservableCollection<Review> Reviews
        {
            get
            {
                return this.reviews;
            }

            set
            {
                reviews = value;
                this.NotifyPropertyChanged("Reviews");
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the seller.
        /// </summary>
        public string Seller { get; set; }

        /// <summary>
        /// Gets or sets the property has been bound with SfCombobox which displays selected quantity of product.
        /// </summary>
        [DataMember(Name = "quantities")]
        public List<object> Quantities { get; set; } = new List<object> { 1, 2, 3, 4, 5 };

        /// <summary>
        /// Gets or sets the property that has been bound with SfCombobox, which displays the product variants.
        /// </summary>
        [DataMember(Name = "sizevariants")]
        public List<string> SizeVariants { get; set; } = new List<string> {"XS", "S", "M", "L", "XL"};

        /// <summary>
        /// Gets or sets the property that has been bound with button, which displays the isfavorite.
        /// </summary>
        [DataMember(Name = "isfavourite")]
        public bool IsFavourite
        {
            get
            {
                return this.isFavourite;
            }

            set
            {
                this.isFavourite = value;
                this.NotifyPropertyChanged("IsFavourite");
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with SfCombobox, which displays the total quantity.
        /// </summary>
        [DataMember(Name = "totalquantity")]
        public int TotalQuantity
        {
            get
            {
                return this.totalQuantity;
            }

            set
            {
                this.totalQuantity = value;
                this.NotifyPropertyChanged("TotalQuantity");
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}