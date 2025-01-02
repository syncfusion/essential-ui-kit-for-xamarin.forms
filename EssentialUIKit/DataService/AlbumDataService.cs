using System.Reflection;
using System.Runtime.Serialization.Json;
using EssentialUIKit.ViewModels.Navigation;

namespace EssentialUIKit.DataService
{
    public class AlbumDataService
    {
        #region fields

        private static AlbumDataService instance;

        private AlbumViewModel albumViewModel;

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="AlbumDataService"/>.
        /// </summary>
        public static AlbumDataService Instance => instance ?? (instance = new AlbumDataService());

        /// <summary>
        /// Gets or sets the value of album page view model.
        /// </summary>
        public AlbumViewModel AlbumViewModel =>
            this.albumViewModel ??
            (this.albumViewModel = PopulateData<AlbumViewModel>("navigation.json"));
               
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
