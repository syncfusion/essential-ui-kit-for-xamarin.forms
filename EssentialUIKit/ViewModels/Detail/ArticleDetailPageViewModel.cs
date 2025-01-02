using System.Collections.ObjectModel;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Model = EssentialUIKit.Models.Article;

namespace EssentialUIKit.ViewModels.Detail
{
    /// <summary>
    /// ViewModel for Article Detail page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class ArticleDetailPageViewModel : BaseViewModel
    {
        #region Fields

        /// <summary>
        /// Gets or sets the article name
        /// </summary>
        private string articleName;

        /// <summary>
        /// Gets or sets the article image
        /// </summary>
        private string articleImage;

        /// <summary>
        /// Gets or sets the article sub image
        /// </summary>
        private string articleSubImage;

        /// <summary>
        /// Gets or sets article author
        /// </summary>
        private string articleAuthor;

        /// <summary>
        /// Gets or sets the arrticle published date
        /// </summary>
        private string articleDate;

        /// <summary>
        /// Gets or sets the article content
        /// </summary>
        private string articleContent;

        /// <summary>
        /// Gets or sets the article reading time
        /// </summary>
        private string articleReadingTime;

        /// <summary>
        /// Gets or sets the related stories.
        /// </summary>
        private ObservableCollection<Model> relatedStories;

        /// <summary>
        /// Gets or sets the article content list.
        /// </summary>
        private ObservableCollection<Model> contentList;

        /// <summary>
        /// Gets or sets the articlesub title
        /// </summary>
        private string subTitle1;

        /// <summary>
        /// Gets or sets the article sub title
        /// </summary>
        private string subTitle2;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailViewModel" /> class
        /// </summary>
        public ArticleDetailPageViewModel()
        {
            this.articleName = "Better Brainstorming by Hand";
            this.articleImage = App.BaseImageUrl + "ArticleImage2.png";
            this.articleSubImage = App.BaseImageUrl + "BlogDetail.png";
            this.articleAuthor = "John Doe";
            this.articleDate = "Apr 16";
            this.articleReadingTime = "5 mins read";
            this.articleContent = "Organizing projects is now predominantly a digital endeavor. Physical whiteboards have given way to electronic Gantt charts. Pocket calendars have yielded to smartphone scheduling apps. Even the most popular tool of the most ferocious organizers—the sticky note—now has a digital counterpart. Despite this digitization, one shouldn’t lose sight of the usefulness of articulating ideas on paper. Handwriting is still the most viable means for bringing ideas and concepts into the physical world for organizing and comparing.This isn’t to say you should remain in the archaic world of markers and pens; rather, handwriting should be harnessed as the initial step in understanding a project—a free association of all the ideas that pop into your head. After organizing and reorganizing your thoughts on paper, moving them into the digital realm as tasks, reminders, and schedules serves as the final refinement of what you’re trying to accomplishment and how you plan to accomplish it.";
            this.SubTitle1 = "Procedure for writing out your ideas";
            this.SubTitle2 = "RELATED STORIES";

            this.RelatedStories = new ObservableCollection<Model>
            {
                new Model
                {
                    ImagePath = App.BaseImageUrl + "ArticleImage2.png",
                    Name = "Learning to Reset",
                    Author = "John Doe",
                    Date = "Aug 2010",
                    AverageReadingTime = "5 mins read"
                },
                new Model
                {
                    ImagePath = App.BaseImageUrl + "ArticleImage3.png",
                    Name = "Holistic Approach to UI Design",
                    Author = "John Doe",
                    Date = "Apr 16",
                    AverageReadingTime = "5 mins read"
                },
                new Model
                {
                    ImagePath = App.BaseImageUrl + "ArticleImage4.png",
                    Name = "Guiding Your Flock to Success",
                    Author = "John Doe",
                    Date = "May 2012",
                    AverageReadingTime = "5 mins read"
                },
                new Model
                {
                    ImagePath = App.BaseImageUrl + "ArticleImage5.png",
                    Name = "Be a Nurturing, Fierce Team Leader",
                    Author = "John Doe",
                    Date = "Apr 16",
                    AverageReadingTime = "5 mins read"
                },
                new Model
                {
                    ImagePath = App.BaseImageUrl + "ArticleImage6.png",
                    Name = "Holistic Approach to UI Design",
                    Author = "John Doe",
                    Date = "Dec 2013",
                    AverageReadingTime = "5 mins read"
                }
            };

            this.ContentList = new ObservableCollection<Model>
            {
                new Model { Description = "Write a one- or two-sentence summary of the goal or project you want to complete." },
                new Model { Description = "Then write every idea you associate with the goal or project on separate pieces of paper (sticky notes are ideal). Don’t self-edit at this point, write everything that comes to mind." },
                new Model { Description = "Spread all the pieces of paper onto a table, a desk, a bed, or even the floor." },
                new Model { Description = "Sort the ideas by category—some will be tasks to do, others will be equipment or training you need." },
                new Model { Description = "Organize the categories from top to bottom according to the sequence in which they need to occur. This will help you remove items that are redundant and identify items that need to be added." },
                new Model { Description = "Now you’re ready to enter the items in an organized fashion into your project management software." },
            };

            this.FavouriteCommand = new Command(this.FavouriteButtonClicked);
            this.BookmarkCommand = new Command(this.BookmarkButtonClicked);
            this.ItemSelectedCommand = new Command(this.ItemClicked);
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the article name
        /// </summary>
        public string ArticleName
        {
            get
            {
                return this.articleName;
            }

            set
            {
                if (this.articleName != value)
                {
                    this.articleName = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the article image
        /// </summary>
        public string ArticleImage
        {
            get
            {
                return this.articleImage;
            }

            set
            {
                if (this.articleImage != value)
                {
                    this.articleImage = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the article sub image
        /// </summary>
        public string ArticleSubImage
        {
            get
            {
                return this.articleSubImage;
            }

            set
            {
                if (this.articleSubImage != value)
                {
                    this.articleSubImage = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the articleAuthor
        /// </summary>
        public string ArticleAuthor
        {
            get
            {
                return this.articleAuthor;
            }

            set
            {
                if (this.articleAuthor != value)
                {
                    this.articleAuthor = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the article reading time
        /// </summary>
        public string ArticleReadingTime
        {
            get
            {
                return this.articleReadingTime;
            }

            set
            {
                if (this.articleReadingTime != value)
                {
                    this.articleReadingTime = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the article date
        /// </summary>
        public string ArticleDate
        {
            get
            {
                return this.articleDate;
            }

            set
            {
                if (this.articleDate != value)
                {
                    this.articleDate = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the article content
        /// </summary>
        public string ArticleContent
        {
            get
            {
                return this.articleContent;
            }

            set
            {
                if (this.articleContent != value)
                {
                    this.articleContent = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the property has been bound with the list view which displays the articles related stories items.
        /// </summary>
        public ObservableCollection<Model> RelatedStories
        {
            get
            {
                return this.relatedStories;
            }

            set
            {
                if (this.relatedStories == value)
                {
                    return;
                }

                this.relatedStories = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property has been bound with the list view which displays the articles content list items.
        /// </summary>
        public ObservableCollection<Model> ContentList
        {
            get
            {
                return this.contentList;
            }

            set
            {
                if (this.contentList == value)
                {
                    return;
                }

                this.contentList = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the article sub title
        /// </summary>
        public string SubTitle1
        {
            get
            {
                return this.subTitle1;
            }

            set
            {
                if (this.subTitle1 == value)
                {
                    return;
                }

                this.subTitle1 = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the article sub title
        /// </summary>
        public string SubTitle2
        {
            get
            {
                return this.subTitle2;
            }

            set
            {
                if (this.subTitle2 == value)
                {
                    return;
                }

                this.subTitle2 = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command
        /// <summary>
        /// Gets or sets the command is executed when the favourite button is clicked.
        /// </summary>
        public Command FavouriteCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the book mark button is clicked.
        /// </summary>
        public Command BookmarkCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the related features item is clicked.
        /// </summary>
        public Command ItemSelectedCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the favourite button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void FavouriteButtonClicked(object obj)
        {
            var button = obj as SfButton;

            if (button == null)
            {
                return;
            }

            if (button.Text == "\ue701")
            {
                button.Text = "\ue732";
                Application.Current.Resources.TryGetValue("PrimaryColor", out var retVal);
                button.TextColor = (Color)retVal;
            }
            else
            {
                button.Text = "\ue701";
                Application.Current.Resources.TryGetValue("Gray-600", out var retVal);
                button.TextColor = (Color)retVal;
            }
        }

        /// <summary>
        /// Invoked when the related features item clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void ItemClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the bookmark button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void BookmarkButtonClicked(object obj)
        {
            if (obj != null && (obj is Model))
            {
                (obj as Model).IsBookmarked = (obj as Model).IsBookmarked ? false : true;
            }
            else
            {
                var button = obj as SfButton;
                if (button != null)
                {
                    button.Text = (button.Text == "\ue72f") ? "\ue734" : "\ue72f";
                }
            }
        }

        #endregion
    }
}
