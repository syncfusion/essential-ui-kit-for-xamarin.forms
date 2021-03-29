﻿using System.Reflection;
using System.Runtime.Serialization.Json;
using EssentialUIKit.ViewModels.Navigation;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.DataService
{
    /// <summary>
    /// Data service for documents list page to load the data from json file.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class DocumentsListDataService
    {
        #region fields 

        private static DocumentsListDataService documentsListDataService;

        private DocumentsViewModel documentsViewModel;

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="DocumentsDataService"/>.
        /// </summary>
        public static DocumentsListDataService Instance => documentsListDataService ?? (documentsListDataService = new DocumentsListDataService());

        /// <summary>
        /// Gets or sets the value of documents page view model.
        /// </summary>
        public DocumentsViewModel DocumentsViewModel =>
            this.documentsViewModel ??
            (this.documentsViewModel = PopulateData<DocumentsViewModel>("navigation.json"));

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