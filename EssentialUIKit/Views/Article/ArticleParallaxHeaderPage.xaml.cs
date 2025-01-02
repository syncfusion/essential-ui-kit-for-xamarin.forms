using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Article
{
    /// <summary>
    /// Article parallax header page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticleParallaxHeaderPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleParallaxHeaderPage"/> class.
        /// </summary>
        public ArticleParallaxHeaderPage ()
        {
            InitializeComponent();
        }
    }
}