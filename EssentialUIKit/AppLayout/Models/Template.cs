using Xamarin.Forms.Internals;

namespace EssentialUIKit.AppLayout.Models
{
    [Preserve(AllMembers = true)]
    public class Template
    {
        #region Constructor

        public Template()
        {            
        }

        public Template(string name, string description, string pageName, bool layoutFullScreen)
        {
            this.Name = name;
            this.Description = description;
            this.PageName = pageName;
            this.LayoutFullscreen = layoutFullScreen;
        }

        #endregion

        #region Properties

        public string Name { get; set; }

        public string Description { get; set; }

        public string PageName { get; set; }

        public bool LayoutFullscreen { get; set; }

        #endregion
    }
}