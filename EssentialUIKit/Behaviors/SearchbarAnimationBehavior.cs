using System;
using System.Collections.Generic;
using Syncfusion.XForms.Border;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;

namespace EssentialUIKit.Behaviors
{
    public enum AnimationType
    {
        /// <summary>
        /// expand animation.
        /// </summary>
        expand,

        /// <summary>
        /// shrink animation.
        /// </summary>
        shrink,
    }

    public class SearchBarAnimationBehavior : Behavior<SfButton>
    {
        #region fileds

        /// <summary>
        /// Gets or sets the AnimationTypeProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty AnimationTypeProperty =
           BindableProperty.Create(nameof(AnimationType), typeof(AnimationType), typeof(SearchBarAnimationBehavior), AnimationType.expand);

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Animation type.
        /// </summary>
        public AnimationType AnimationType
        {
            get { return (AnimationType)this.GetValue(AnimationTypeProperty); }
            set { this.SetValue(AnimationTypeProperty, value); }
        }

        /// <summary>
        /// Gets the sfButton.
        /// </summary>
        public SfButton SfButton { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when adding the sfbutton to view.
        /// </summary>
        /// <param name="button">The button</param>
        protected override void OnAttachedTo(SfButton button)
        {
            if (button != null)
            {
                base.OnAttachedTo(button);
                this.SfButton = button;
                button.BindingContextChanged += this.OnBindingContextChanged;
                button.Clicked += this.SfButton_Clicked;
            }
        }

        /// <summary>
        /// Invoked when exit from the view.
        /// </summary>
        /// <param name="button">The button</param>
        protected override void OnDetachingFrom(SfButton button)
        {
            if (button != null)
            {
                base.OnDetachingFrom(button);
                button.BindingContextChanged -= this.OnBindingContextChanged;
                button.Clicked -= this.SfButton_Clicked;
                this.SfButton = null;
            }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            this.BindingContext = this.SfButton.BindingContext;
        }

        /// <summary>
        /// Invoked when binding context is changed.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            this.OnBindingContextChanged();
        }

        /// <summary>
        /// Invoked when button is clicked.
        /// </summary>
        /// <param name="sender">The borderlessEntry</param>
        /// <param name="e">The Text Changed Event args</param>
        private void SfButton_Clicked(object sender, EventArgs e)
        {
            var button = (SfButton)sender;

            if (button != null)
            {
                if (this.AnimationType == AnimationType.expand)
                {
                    double opacity;

                    var searchLayout = button.Parent as StackLayout;

                    button.IsVisible = false;
                    var children = searchLayout.Children;

                    if (children != null)
                    {
                        StackLayout searchLayoutChildren = children[1] as StackLayout;
                        searchLayoutChildren.IsVisible = true;

                        StackLayout titleLayoutChildren = children[0] as StackLayout;
                        titleLayoutChildren.IsVisible = false;

                        var expandAnimation = new Animation(
                        property =>
                        {
                            searchLayoutChildren.WidthRequest = property;
                            opacity = property / searchLayout.Width;
                            searchLayoutChildren.Opacity = opacity;
                        },
                        0,
                        searchLayout.Width,
                        Easing.Linear);
                        expandAnimation.Commit(searchLayoutChildren, "Expand", 16, 250, Easing.Linear, (p, q) => this.SearchExpandAnimationCompleted(children));
                    }
                }
                else if (this.AnimationType == AnimationType.shrink)
                {
                    double opacity;
                    var searchLayout = button.Parent as StackLayout;
                    var searchLayoutChildren = (searchLayout.Parent as StackLayout).Children;

                    if (searchLayoutChildren != null)
                    {
                        SfButton searchButton = searchLayoutChildren[2] as SfButton;
                        searchButton.IsVisible = true;
                    }

                    // Animating Width of the search box, from full width to 0 before it removed from view.
                    var shrinkAnimation = new Animation(
                        property =>
                        {
                            searchLayout.WidthRequest = property;
                            opacity = property / (button.Parent.Parent as StackLayout).Width;
                            searchLayout.Opacity = opacity;
                        },
                        searchLayout.Width,
                        0,
                        Easing.Linear);
                    shrinkAnimation.Commit(searchLayout, "Shrink", 16, 250, Easing.Linear, (p, q) => this.SearchBoxAnimationCompleted(searchLayout));

                    var children = searchLayout.Children;
                    if (children != null)
                    {
                        var searchEntry = (children[1] as SfBorder).Content;
                        (searchEntry as Entry).Text = string.Empty;
                    }
                }
            }
        }

        private void SearchExpandAnimationCompleted(IList<View> children)
        {
            if (children != null)
            {
                StackLayout searchLayout = children[1] as StackLayout;
                var searchEntry = (searchLayout.Children[1] as SfBorder).Content;
                (searchEntry as Entry).Focus();
            }
        }

        private void SearchBoxAnimationCompleted(StackLayout searchLayout)
        {
            var searchLayoutChildren = (searchLayout.Parent as StackLayout).Children;

            searchLayout.IsVisible = false;

            if (searchLayoutChildren != null)
            {
                StackLayout titleLayout = searchLayoutChildren[0] as StackLayout;
                titleLayout.IsVisible = true;
            }
        }

        #endregion
    }
}
