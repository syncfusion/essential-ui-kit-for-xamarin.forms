using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace EssentialUIKit.Views.Templates
{
    /// <summary>
    /// Cart item list template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartItemListTemplate : Grid
	{
        /// <summary>
        /// Bindable property to set the parent bindingcontext.
        /// </summary>
        public static BindableProperty ParentBindingContextProperty =
         BindableProperty.Create(nameof(ParentBindingContext), typeof(object),
         typeof(CartItemListTemplate), null);

        /// <summary>
        /// Gets or sets the parent bindingcontext.
        /// </summary>
        public object ParentBindingContext
        {
            get { return GetValue(ParentBindingContextProperty); }
            set { SetValue(ParentBindingContextProperty, value); }
        }

        /// <summary>
        /// Bindable property to set the parent element.
        /// </summary>
        public static BindableProperty ParentElementProperty =
         BindableProperty.Create(nameof(ParentElement), typeof(object),
         typeof(CartItemListTemplate), null);

        /// <summary>
        /// Gets or sets the Parent element.
        /// </summary>
        public object ParentElement
        {
            get { return GetValue(ParentElementProperty); }
            set { SetValue(ParentElementProperty, value); }
        }

        /// <summary>
        /// Bindable property to set the child element.
        /// </summary>
        public static BindableProperty ChildElementProperty =
         BindableProperty.Create(nameof(ChildElement), typeof(object),
         typeof(CartItemListTemplate), null);

        /// <summary>
        /// Gets or sets the child element.
        /// </summary>
        public object ChildElement
        {
            get { return GetValue(ChildElementProperty); }
            set { SetValue(ChildElementProperty, value); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CartItemListTemplate"/> class.
        /// </summary>
		public CartItemListTemplate ()
		{
			InitializeComponent ();
		}
    }
}