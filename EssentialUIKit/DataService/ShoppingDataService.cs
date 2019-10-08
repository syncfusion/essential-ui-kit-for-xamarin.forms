using System.Reflection;
using System.Runtime.Serialization.Json;
using EssentialUIKit.ViewModels.Shopping;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.DataService
{
    /// <summary>
    /// Data service to load the data from json file.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ShoppingDataService
    {
        #region fields

        private static ShoppingDataService instance;

        private CatalogPageViewModel catalogPageViewModel;

        private CartPageViewModel cartPageViewModel;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance for the <see cref="ShoppingDataService"/> class.
        /// </summary>
        private ShoppingDataService()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="CatalogDataService"/>.
        /// </summary>
        public static ShoppingDataService Instance => instance ?? (instance = new ShoppingDataService());

        /// <summary>
        /// Gets or sets the value of catalog page view model.
        /// </summary>
        public CatalogPageViewModel CatalogPageViewModel =>
            this.catalogPageViewModel ??
            (this.catalogPageViewModel = PopulateData<CatalogPageViewModel>("ecommerce.json"));

        /// <summary>
        /// Gets or sets the value of cart page view model.
        /// </summary>
        public CartPageViewModel CartPageViewModel =>
            (this.cartPageViewModel = PopulateData<CartPageViewModel>("ecommerce.json"));

        #endregion

        #region Methods

        /// <summary>
        /// Populates the data for view model from json file.
        /// </summary>
        /// <typeparam name="T">Type of view model.</typeparam>
        /// <param name="fileName">Json file to fetch data.</param>
        /// <returns>Returns the view model object.</returns>
        private static T PopulateData<T>(string fileName)
        {
            var file = "EssentialUIKit.Data." + fileName;

            var assembly = typeof(App).GetTypeInfo().Assembly;

            T obj;

            using (var stream = assembly.GetManifestResourceStream(file))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                obj = (T)serializer.ReadObject(stream);
            }

            return obj;
        }

        #endregion
    }
}
