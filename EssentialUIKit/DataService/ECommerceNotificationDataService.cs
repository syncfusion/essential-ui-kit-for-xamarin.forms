using System.Reflection;
using System.Runtime.Serialization.Json;
using Xamarin.Forms.Internals;
using EssentialUIKit.ViewModels.Notification;

namespace EssentialUIKit.DataService
{
    /// <summary>
    /// Data service for E-Commerce notification page to load the data from json file.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ECommerceNotificationDataService
    {
        #region fields 

        private static ECommerceNotificationDataService instance;

        private ECommerceNotificationViewModel ecommerceNotificationViewModel;

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="ECommerceNotificationDataService"/>.
        /// </summary>
        public static ECommerceNotificationDataService Instance => instance ?? (instance = new ECommerceNotificationDataService());

        /// <summary>
        /// Gets or sets the value of E-Commerce notification page view model.
        /// </summary>
        public ECommerceNotificationViewModel ECommerceNotificationViewModel =>
            this.ecommerceNotificationViewModel ??
            (this.ecommerceNotificationViewModel = PopulateData<ECommerceNotificationViewModel>("notification.json"));

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