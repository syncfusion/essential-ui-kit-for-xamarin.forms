using System.Collections.ObjectModel;
using EssentialUIKit.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System.Runtime.Serialization;
using EssentialUIKit.Controls;

namespace EssentialUIKit.ViewModels.Bookmarks
{
    /// <summary>
    /// ViewModel for cart page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class CartPageViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<Product> cartDetails;

        private double totalPrice;

        private double discountPrice;

        private double discountPercent;

        private double percent;
        
        private ObservableCollection<Product> produts;
        
        private Command placeOrderCommand;
        
        private Command removeCommand;
        
        private Command quantitySelectedCommand;
        
        private Command variantSelectedCommand;
        
        private Command applyCouponCommand;

        private Command backButtonCommand;

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the property that has been bound with a list view, which displays the cart details.
        /// </summary>
        public ObservableCollection<Product> CartDetails
        {
            get
            {
                return this.cartDetails;
            }

            set
            {
                if (this.cartDetails == value)
                {
                    return;
                }

                this.cartDetails = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the total price.
        /// </summary>
        public double TotalPrice
        {
            get
            {
                return this.totalPrice;
            }

            set
            {
                if (this.totalPrice == value)
                {
                    return;
                }

                this.totalPrice = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays total discount price.
        /// </summary>
        public double DiscountPrice
        {
            get
            {
                return this.discountPrice;
            }

            set
            {
                if (this.discountPrice == value)
                {
                    return;
                }

                this.discountPrice = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays discount.
        /// </summary>
        public double DiscountPercent
        {
            get
            {
                return this.discountPercent;
            }
        
            set
            {
                if (this.discountPercent == value)
                {
                    return;
                }

                this.discountPercent = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with list view, which displays the collection of products from json.
        /// </summary>

        [DataMember(Name = "products")]
        public ObservableCollection<Product> Products
        {
            get
            {
                return this.produts;
            }

            set
            {
                if (this.produts == value)
                {
                    return;
                }
                this.produts = value;
                this.NotifyPropertyChanged();
                this.GetProducts(Products);
                this.UpdatePrice();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that will be executed when the Edit button is clicked.
        /// </summary>
        public Command PlaceOrderCommand
        {
            get { return this.placeOrderCommand ?? (this.placeOrderCommand = new Command(this.PlaceOrderClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the Remove button is clicked.
        /// </summary>
        public Command RemoveCommand
        {
            get { return this.removeCommand ?? (this.removeCommand = new Command(this.RemoveClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the quantity is selected.
        /// </summary>
        public Command QuantitySelectedCommand
        {
            get { return this.quantitySelectedCommand ?? (this.quantitySelectedCommand = new Command(this.QuantitySelected)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the variant is selected.
        /// </summary>
        public Command VariantSelectedCommand
        {
            get { return this.variantSelectedCommand ?? (this.variantSelectedCommand = new Command(this.VariantSelected)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the apply coupon is clicked.
        /// </summary>
        public Command ApplyCouponCommand
        {
            get { return this.applyCouponCommand ?? (this.applyCouponCommand = new Command(this.ApplyCouponClicked)); }
        }

        /// <summary>
        /// Gets or sets the command is executed when the back button is clicked.
        /// </summary>
        public Command BackButtonCommand
        {
            get { return this.backButtonCommand ?? (this.backButtonCommand = new Command(this.BackButtonClicked)); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void PlaceOrderClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void RemoveClicked(object obj)
        {
            if (obj is Product product)
            {
                this.CartDetails.Remove(product);
                this.UpdatePrice();

                if(this.CartDetails.Count == 0)
                {
                    SfPopupView sfPopupView = new SfPopupView();
                    sfPopupView.ShowPopUp(content: "Your cart is empty!",buttonText:"CONTINUE SHOPPING");
                }
            }
        }

        /// <summary>
        /// Invoked when the quantity is selected.
        /// </summary>
        /// <param name="selectedItem">The Object</param>
        private void QuantitySelected(object selectedItem)
        {
            //Incident - 249030 - Issue in ComboBox Slection changed event.

            //var item = selectedItem as CartProduct;

            //this.UpdatePrice();
            //item.ActualPrice = item.ActualPrice * item.TotalQuantity;
            //item.DiscountPrice = item.DiscountPrice * item.TotalQuantity;
        }

        /// <summary>
        /// Invoked when the variant is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void VariantSelected(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the apply coupon button is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ApplyCouponClicked(object obj)
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

        /// <summary>
        /// This method is used to get the products from json.
        /// </summary>
        /// <param name="Products">The Products</param>
        private void GetProducts(ObservableCollection<Product> Products)
        {
            this.CartDetails = new ObservableCollection<Product>();
            if (Products != null && Products.Count > 0)
                this.CartDetails = Products;
        }

        /// <summary>
        /// This method is used to update the price amount.
        /// </summary>
        private void UpdatePrice()
        {
            this.ResetPriceValue();

            if (this.CartDetails != null && this.CartDetails.Count > 0)
            {
                foreach (var cartDetail in this.CartDetails)
                {
                    if (cartDetail.TotalQuantity == 0)
                        cartDetail.TotalQuantity = 1;
                    this.TotalPrice += (cartDetail.ActualPrice * cartDetail.TotalQuantity);
                    this.DiscountPrice += (cartDetail.DiscountPrice * cartDetail.TotalQuantity);
                    this.percent += cartDetail.DiscountPercent;
                }

                this.DiscountPercent = this.percent > 0 ? this.percent / this.CartDetails.Count : 0;
            }
        }

        /// <summary>
        /// This method is used to reset the price amount.
        /// </summary>
        private void ResetPriceValue()
        {
            this.TotalPrice = 0;
            this.DiscountPercent = 0;
            this.DiscountPrice = 0;
            this.percent = 0;
        }

        #endregion
    }
}
