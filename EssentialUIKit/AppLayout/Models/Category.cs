using System.Collections.Generic;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.AppLayout.Models
{
    [Preserve(AllMembers = true)]
    public class Category
    {
        #region Constructor

        public Category(string name, string icon, string description)
        {
            this.Pages = new List<Template>();

            this.Name = name;
            this.Icon = icon;
            this.Description = description;
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
                return this.Pages.Count > 1 ? $"{this.Pages.Count.ToString()} Templates" : $"{this.Pages.Count.ToString()} Template";
            }
        }

        #endregion
    }
}