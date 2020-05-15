﻿using System.Reflection;
using System.Runtime.Serialization.Json;
using Xamarin.Forms.Internals;
using EssentialUIKit.ViewModels.Navigation;

namespace EssentialUIKit.DataService
{
    /// <summary>
    /// Data service for app usage page to load the data from json file.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class AppUsageDataService
    {
        #region fields 

        private static AppUsageDataService appUsageDataService;

        private AppUsageViewModel appUsageViewModel;

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="AppUsageDataService"/>.
        /// </summary>
        public static AppUsageDataService Instance => appUsageDataService ?? (appUsageDataService = new AppUsageDataService());

        /// <summary>
        /// Gets or sets the value of app usage page view model.
        /// </summary>
        public AppUsageViewModel AppUsageViewModel =>
            this.appUsageViewModel ??
            (this.appUsageViewModel = PopulateData<AppUsageViewModel>("navigation.json"));

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

            T data;

            using (var stream = assembly.GetManifestResourceStream(file))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                data = (T)serializer.ReadObject(stream);
            }

            return data;
        }

        #endregion
    }
}