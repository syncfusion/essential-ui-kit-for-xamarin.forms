using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.AppLayout.Models
{
    [Preserve(AllMembers = true)]
    public class Category
    {
        #region Constructor

        public Category(string name, string icon, string description, string updateType, bool isUpdate)
        {
            this.Pages = new List<Template>();
            this.Name = name;
            this.Icon = icon;
            this.Description = description;
            this.UpdateType = updateType;
            this.IsUpdate = isUpdate;
        }

        #endregion

        #region Properties

        public string Name { get; set; }

        public string Icon { get; set; }

        public string Description { get; set; }

        public List<Template> Pages { get; set; }

        public string TemplateCount
        {
            get
            {
                return this.Pages.Count > 1 ? $"{this.Pages.Count.ToString(CultureInfo.InvariantCulture)} Templates" : $"{this.Pages.Count.ToString(CultureInfo.InvariantCulture)} Template";
            }
        }

        public string UpdateType { get; set; }

        public bool IsUpdate { get; set; }
        #endregion
    }
}