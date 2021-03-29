using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using EssentialUIKit.AppLayout.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.AppLayout.ViewModels
{
    [Preserve(AllMembers = true)]
    public class HomePageViewModel
    {
        private const string SampleListFile = "EssentialUIKit.AppLayout.TemplateList.xml";

        /// <summary>
        /// Initializes a new instance for the <see cref="HomePageViewModel" /> class.
        /// </summary>
        public HomePageViewModel()
        {
            this.Templates = new List<Category>();
            this.PopulateList();
        }

        public List<Category> Templates { get; private set; }

        private void PopulateList()
        {
            this.Templates.Clear();

            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(SampleListFile);

            using (var reader = new StreamReader(stream))
            {
#pragma warning disable CA2000 // Dispose objects before losing scope
                var xmlReader = XmlReader.Create(reader);
#pragma warning restore CA2000 // Dispose objects before losing scope
                xmlReader.Read();
                Category category = null;
                var hasAdded = false;
                var runtimePlatform = Device.RuntimePlatform.ToUpperInvariant();

                while (!xmlReader.EOF)
                {
                    switch (xmlReader.Name)
                    {
                        case "Category" when xmlReader.IsStartElement() && xmlReader.HasAttributes:
                            {
                                if (!hasAdded && category != null)
                                {
                                    this.Templates.Add(category);
                                    category = null;
                                    hasAdded = true;
                                }

                                var platform = GetDataFromXmlReader(xmlReader, "Platform");
                                if (string.IsNullOrEmpty(platform) || platform.ToUpperInvariant().Contains(runtimePlatform))
                                {
                                    var categoryName = GetDataFromXmlReader(xmlReader, "Name");
                                    var description = GetDataFromXmlReader(xmlReader, "Description");
                                    var icon =
                                        $"EssentialUIKit.AppLayout.Icons.{GetDataFromXmlReader(xmlReader, "Icon")}";

                                    string updateType = string.Empty;
                                    bool isUpdate = false;

                                    if (xmlReader.GetAttribute("IsUpdated") != null)
                                    {
                                        if (GetDataFromXmlReader(xmlReader, "IsUpdated") == "True")
                                        {
                                            updateType = "Updated";
                                            isUpdate = true;
                                        }
                                    }

                                    if (xmlReader.GetAttribute("IsNew") != null)
                                    {
                                        if (GetDataFromXmlReader(xmlReader, "IsNew") == "True")
                                        {
                                            updateType = "New";
                                            isUpdate = true;
                                        }
                                    }

                                    category = new Category(categoryName, icon, description, updateType, isUpdate);
                                }

                                break;
                            }

                        case "Page" when xmlReader.IsStartElement() && xmlReader.HasAttributes && category != null:
                            {
                                var platform = GetDataFromXmlReader(xmlReader, "Platform");

                                if (string.IsNullOrEmpty(platform) || platform.ToUpperInvariant().Contains(runtimePlatform))
                                {
                                    var templateName = GetDataFromXmlReader(xmlReader, "Name");
                                    var description = GetDataFromXmlReader(xmlReader, "Description");
                                    var pageName = GetDataFromXmlReader(xmlReader, "PageName");
                                    var templateImage = $"EssentialUIKit.TemplateImage.LightTheme.{GetDataFromXmlReader(xmlReader, "Image")}";
                                    var templateDarkImage = $"EssentialUIKit.TemplateImage.DarkTheme.{GetDataFromXmlReader(xmlReader, "DarkImage")}";

                                    if (bool.TryParse(GetDataFromXmlReader(xmlReader, "LayoutFullscreen"), out var layoutFullScreen))
                                    {
                                        // Do Nothing
                                    }

                                    string updateType = string.Empty;
                                    bool isUpdate = false;

                                    if (xmlReader.GetAttribute("IsUpdated") != null)
                                    {
                                        if (GetDataFromXmlReader(xmlReader, "IsUpdated") == "True")
                                        {
                                            updateType = "Updated";
                                            isUpdate = true;
                                        }
                                    }

                                    if (xmlReader.GetAttribute("IsNew") != null)
                                    {
                                        if (GetDataFromXmlReader(xmlReader, "IsNew") == "True")
                                        {
                                            updateType = "New";
                                            isUpdate = true;
                                        }
                                    }

                                    var template = new Template(templateName, description, pageName, layoutFullScreen, updateType, isUpdate, templateImage, templateDarkImage);

                                    Routing.RegisterRoute(templateName, assembly.GetType($"EssentialUIKit.{pageName}"));

                                    category.Pages.Add(template);
                                    hasAdded = false;
                                }

                                break;
                            }
                    }

                    xmlReader.Read();
                }

                if (!hasAdded)
                {
                    this.Templates.Add(category);
                }
            }
        }

        public static string GetDataFromXmlReader(XmlReader reader, string attribute)
        {
            if (reader != null)
            {
                reader.MoveToAttribute(attribute);
                return reader.Value;
            }

            return string.Empty;
        }

        private static string GetUpdateType(string value, string type)
        {
            if (value == "true" && (type == "IsNew" || type == "IsPreview"))
            {
                return (Device.RuntimePlatform == Device.iOS) ? "Tags/newimage.png" : "Tags/preview.png";
            }

            if (value == "true" && type == "IsUpdated")
            {
                return "Tags/updated.png";
            }

            return string.Empty;
        }
    }
}