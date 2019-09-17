using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Forms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    [Preserve(AllMembers =true)]
	public partial class TabbedForm : ContentPage
	{
		public TabbedForm ()
		{
			InitializeComponent ();
		}
	}
}