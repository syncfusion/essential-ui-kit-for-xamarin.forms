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

        public Category SelectedCategory
        {
            set
            {
                if (value == null) return;

                //XmlSerializer xmlSerializer = new XmlSerializer(typeof(Category));

                //using (StringWriter textWriter = new StringWriter())
                //{
                //    xmlSerializer.Serialize(textWriter, value);

                //    var url = HttpUtility.UrlEncode(textWriter.ToString());

                //    Shell.Current.GoToAsync($@"templatepage?data1={url}", true);
                //}
            }
        }

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
                var runtimePlatform = Device.RuntimePlatform.ToLower();

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
                            if (string.IsNullOrEmpty(platform) || platform.ToLower().Contains(runtimePlatform))
                            {
                                var categoryName = GetDataFromXmlReader(xmlReader, "Name");
                                var description = GetDataFromXmlReader(xmlReader, "Description");
                                var icon =
                                    $"EssentialUIKit.AppLayout.Icons.{GetDataFromXmlReader(xmlReader, "Icon")}";

                                category = new Category(categoryName, icon, description);
                            }

                            break;
                        }

                        case "Page" when xmlReader.IsStartElement() && xmlReader.HasAttributes && category != null:
                        {
                            var platform = GetDataFromXmlReader(xmlReader, "Platform");

                            if (string.IsNullOrEmpty(platform) || platform.ToLower().Contains(runtimePlatform))
                            {
                                var templateName = GetDataFromXmlReader(xmlReader, "Name");
                                var description = GetDataFromXmlReader(xmlReader, "Description");
                                var pageName = GetDataFromXmlReader(xmlReader, "PageName");
                                bool.TryParse(GetDataFromXmlReader(xmlReader, "LayoutFullscreen"),
                                    out var layoutFullScreen);

                                var template = new Template(templateName, description, pageName, layoutFullScreen);
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
            reader.MoveToAttribute(attribute);
            return reader.Value;
        }
    }
}