using EssentialUIKit.Models.OnBoarding;
using EssentialUIKit.ViewModels.OnBoarding;
using Syncfusion.SfRotator.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Behaviors.OnBoarding
{
    /// <summary>
    /// This class extends the behavior of the SfRotator control to animate the view.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SfRotatorBehavior : Behavior<SfRotator>
    {
        #region Fields

        int previousIndex;
        
        #endregion

        #region Methods

        /// <summary>
        /// Invoke when adding rotator to view.
        /// </summary>
        /// <param name="rotator"></param>
        protected override void OnAttachedTo(SfRotator rotator)
        {
            base.OnAttachedTo(rotator);
            rotator.SelectedIndexChanged += Rotator_SelectedIndexChanged;
            rotator.BindingContextChanged += Rotator_BindingContextChanged;
        }

        /// <summary>
        /// Invoke when exit from the view.
        /// </summary>
        /// <param name="rotator"></param>
        protected override void OnDetachingFrom(SfRotator rotator)
        {
            base.OnDetachingFrom(rotator);
            rotator.SelectedIndexChanged -= Rotator_SelectedIndexChanged;
            rotator.BindingContextChanged -= Rotator_BindingContextChanged;
        }

        /// <summary>
        /// Invoked when rotator binding context is changed.
        /// </summary>
        private void Rotator_BindingContextChanged(object sender, EventArgs e)
        {
            Animation(sender as SfRotator, 0);
        }

        /// <summary>
        /// Invoked when selected index is changed.
        /// </summary>
        /// <param name="sender">The rotator</param>
        /// <param name="e">The selection changed event args</param>
        private void Rotator_SelectedIndexChanged(object sender, SelectedIndexChangedEventArgs e)
        {
            SfRotator sfRotator = sender as SfRotator;
            Animation(sfRotator, e.Index);
        }

        /// <summary>
        /// Invoke when initialize animate to view.
        /// </summary>
        /// <param name="sfRotator"></param>
        /// <param name="selectedIndex"></param>
        public void Animation(SfRotator sfRotator, double selectedIndex)
        {
            if (sfRotator != null && sfRotator.ItemsSource != null && sfRotator.ItemsSource.Count() > 0)
            {
                int itemsCount = sfRotator.ItemsSource.Count();
                int.TryParse(selectedIndex.ToString(), out int index);

                var viewModel = sfRotator.BindingContext as OnBoardingAnimationViewModel;
                if (selectedIndex == itemsCount - 1)
                {
                    viewModel.NextButtonText = "DONE";
                    viewModel.IsSkipButtonVisible = false;
                }
                else
                {
                    viewModel.NextButtonText = "NEXT";
                    viewModel.IsSkipButtonVisible = true;
                }

                var items = (sfRotator.ItemsSource as IEnumerable<object>).ToList();

                // Start animation to selected view.
                var currentItem = items[index];
                var childElement = (((currentItem as Boarding).RotatorItem as ContentView).Children[0] as StackLayout).Children.ToList();
                if (childElement != null && childElement.Count > 0)
                {
                    StartAnimation(childElement, currentItem as Boarding);
                }

                // Set default value to previous view.
                if (index != previousIndex)
                {
                    var previousItem = items[previousIndex];
                    var previousChildElement = (((previousItem as Boarding).RotatorItem as ContentView).Children[0] as StackLayout).Children.ToList();
                    if (previousChildElement != null && previousChildElement.Count > 0)
                    {
                        previousChildElement[0].FadeTo(0, 250);
                        previousChildElement[1].FadeTo(0, 250);
                        previousChildElement[1].TranslateTo(0, 60, 250);
                        previousChildElement[1].ScaleTo(1, 0);
                        previousChildElement[2].FadeTo(0, 250);
                    }
                }
                previousIndex = index;
            }
        }

        /// <summary>
        /// Animation start to view.
        /// </summary>
        /// <param name="childElement"></param>
        /// <param name="item"></param>
        public async void StartAnimation(List<View> childElement, Boarding item)
        {
            var fadeAnimationImage = childElement[0].FadeTo(1, 250);
            var fadeAnimationtaskTitleTime = childElement[1].FadeTo(1, 1000);
            var translateAnimation = childElement[1].TranslateTo(0, 0, 500);
            var scaleAnimationTitle = childElement[1].ScaleTo(1.5, 500, Easing.SinIn);
            var fadeAnimationTaskDescriptionTime = childElement[2].FadeTo(1, 1000);

            var animation = new Animation();
            var scaleDownAnimation = new Animation(v => childElement[0].Scale = v, 0.5, 1, Easing.SinIn);
            animation.Add(0, 1, scaleDownAnimation);
            animation.Commit((item as Boarding).RotatorItem as ContentView, "animation", 16, 500);

            await Task.WhenAll(fadeAnimationTaskDescriptionTime, fadeAnimationtaskTitleTime, translateAnimation, scaleAnimationTitle);
        }
    }

    #endregion
}
