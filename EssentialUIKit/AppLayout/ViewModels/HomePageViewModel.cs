using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using EssentialUIKit.AppLayout.Models;

namespace EssentialUIKit.AppLayout.ViewModels
{
    [Preserve(AllMembers = true)]
    public class HomePageViewModel
    {
        private const string sampleListFile = "EssentialUIKit.AppLayout.TemplateList.xml";

        public List<Category> Templates { get; set; }

        /// <summary>
        /// Initializes a new instance for the <see cref="HomePageViewModel" /> class.
        /// </summary>
        public HomePageViewModel()
        {
            Templates = new List<Category>();
            PopulateList();
        }

        private void PopulateList()
        {
            Templates.Clear();

            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(sampleListFile);

            using (var reader = new StreamReader(stream))
            {
                var xmlReader = XmlReader.Create(reader);
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
                                Templates.Add(category);
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

                                    if (null != xmlReader.GetAttribute("IsUpdated"))
                                    {
                                        if (GetDataFromXmlReader(xmlReader, "IsUpdated") == "True")
                                        {
                                            updateType = "Updated";
                                            isUpdate = true;
                                        }
                                    }

                                    if (null != xmlReader.GetAttribute("IsNew"))
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
                                bool.TryParse(GetDataFromXmlReader(xmlReader, "LayoutFullscreen"),
                                    out var layoutFullScreen);
                                    string updateType = string.Empty;
                                    bool isUpdate = false;

                                    if (null != xmlReader.GetAttribute("IsUpdated"))
                                    {
                                        if (GetDataFromXmlReader(xmlReader, "IsUpdated") == "True")
                                        {
                                            updateType = "Updated";
                                            isUpdate = true;
                                        }
                                    }

                                    if (null != xmlReader.GetAttribute("IsNew"))
                                    {
                                        if (GetDataFromXmlReader(xmlReader, "IsNew") == "True")
                                        {
                                            updateType = "New";
                                            isUpdate = true;
                                        }
                                    }

                                    var template = new Template(templateName, description, pageName, layoutFullScreen, updateType, isUpdate);
                                Routing.RegisterRoute(templateName,
                                    assembly.GetType($"EssentialUIKit.{pageName}"));

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
                    Templates.Add(category);
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

        private string GetUpdateType(string value, string type)
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