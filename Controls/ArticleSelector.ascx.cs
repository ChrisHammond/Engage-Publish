// <copyright file="ArticleSelector.ascx.cs" company="Engage Software">
// Engage: Publish - http://www.engagemodules.com
// Copyright (c) 2004-2008
// by Engage Software ( http://www.engagesoftware.com )
// </copyright>
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.

namespace Engage.Dnn.Publish.Controls
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Web.UI.WebControls;
    using DotNetNuke.Services.Localization;
    using Util;

    /// <summary>
    /// A control for selecting an article (with the ability to filter by category)
    /// </summary>
    public partial class ArticleSelector : ModuleBase
    {
        /// <summary>
        /// Backing field for <see cref="ArticleId"/>
        /// </summary>
        private int? articleId;

        /// <summary>
        /// Gets or sets the ID of the selected article.
        /// </summary>
        /// <value>The ID of the selected article.</value>
        public int? ArticleId
        {
            get { return this.articleId; }
            set { this.articleId = value; }
        }

        /// <summary>
        /// Gets the ID of the selected category, or <c>null</c> if none is selected.
        /// </summary>
        /// <value>The ID of the selected category, or <c>null</c> if none is selected</value>
        private int? CategoryId
        {
            get
            {
                int categoryId;
                if (int.TryParse(this.CategoriesDropDownList.SelectedValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out categoryId))
                {
                    return categoryId;
                }

                return null;
            }
        }

        /// <summary>
        /// Raises the <see cref="ModuleBase.Init"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            if (this.IsPostBack)
            {
                this.ArticleId = this.GetArticleId();
            }

            this.Load += this.Page_Load;
            this.CategoriesDropDownList.SelectedIndexChanged += this.CategoriesDropDownList_SelectedIndexChanged;
            this.LocalResourceFile = this.AppRelativeTemplateSourceDirectory + Localization.LocalResourceDirectory + "/" + Path.GetFileNameWithoutExtension(this.TemplateControl.AppRelativeVirtualPath);
            base.OnInit(e);
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Page_Load(object sender, EventArgs e)
        {
            this.FillCategoryDropDown();
            if (!this.IsPostBack)
            {
                this.SelectCategory();
            }

            this.FillArticlesDropDown();
            if (!this.IsPostBack)
            {
                this.SelectArticle();
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the CategoriesDropDownList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CategoriesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillArticlesDropDown();
            this.SelectArticle();
        }

        /// <summary>
        /// Gets the selected article ID.
        /// </summary>
        /// <returns>The selected article ID</returns>
        private int? GetArticleId()
        {
            int newArticleId;
            if (int.TryParse(this.Request.Params[this.ArticlesDropDownList.UniqueID], NumberStyles.Integer, CultureInfo.InvariantCulture, out newArticleId))
            {
                return newArticleId;
            }

            return null;
        }

        /// <summary>
        /// Fills <see cref="CategoriesDropDownList"/> with the list of categories.
        /// </summary>
        private void FillCategoryDropDown()
        {
            this.CategoriesDropDownList.Items.Clear();
            ItemRelationship.DisplayCategoryHierarchy(this.CategoriesDropDownList, -1, this.PortalId, false);
            this.CategoriesDropDownList.Items.Insert(0, new ListItem(Localization.GetString("ChooseOne", Utility.LocalSharedResourceFile), "-1"));
        }

        /// <summary>
        /// Fills <see cref="ArticlesDropDownList"/> with the list of articles in the category selected in <see cref="CategoriesDropDownList"/>.
        /// </summary>
        private void FillArticlesDropDown()
        {
            if (this.CategoryId.HasValue)
            {
                this.ArticlesDropDownList.DataSource = Article.GetArticles(this.CategoryId.Value, this.PortalId);
                this.ArticlesDropDownList.DataBind();
            }
        }

        /// <summary>
        /// Selects the current category in the <see cref="CategoriesDropDownList"/>, if this is the first time loading the page and there is a category to select
        /// </summary>
        private void SelectCategory()
        {
            if (this.articleId.HasValue)
            {
                Article article = Article.GetArticle(this.articleId.Value, this.PortalId);
                if (article != null)
                {
                    this.CategoriesDropDownList.SelectedValue = article.GetParentCategoryId().ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        /// <summary>
        /// Selects the current article in the <see cref="ArticlesDropDownList"/>, if this is the first time loading the page and there is an article to select
        /// </summary>
        private void SelectArticle()
        {
            if (this.articleId.HasValue)
            {
                this.ArticlesDropDownList.SelectedValue = this.articleId.Value.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}

