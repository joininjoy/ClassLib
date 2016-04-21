using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;

namespace DotNet.Utilities
{
    public class SEOHelper
    {
        #region 动态设置页面Head
        /// <summary>
        /// 设置页面Head
        /// </summary>

        public class SetHead
        {
            Page Page;
            public SetHead(Page page)
            {
                Page = page;
            }
            public void SetTitle(string Title)
            {
                //Page title
                Page.Title = Title;
            }
            public void SetEncode()
            {
                SetEncode("text/html; charset=utf-8");
            }
            public void SetEncode(string Encode)
            {
                //Encode/Content type
                HtmlMeta encode = new HtmlMeta();
                encode.HttpEquiv = "Content-Type";
                encode.Content = Encode;
                Page.Header.Controls.Add(encode);
            }
            public void SetLanguage()
            {
                //Language
                HtmlMeta lang = new HtmlMeta();
                lang.HttpEquiv = "Content-Language";
                lang.Content = "zh-cn";
                Page.Header.Controls.Add(lang);
            }
            public void SetKeywords(string Keywords)
            {
                //Keyword
                HtmlMeta keywords = new HtmlMeta();
                keywords.Name = "keywords";
                keywords.Content = Keywords;
                Page.Header.Controls.Add(keywords);
            }
            public void SetDescription(string Description)
            {
                //Description
                HtmlMeta desc = new HtmlMeta();
                desc.Name = "Description";
                desc.Content = Description;
                Page.Header.Controls.Add(desc);
            }
            public void SetCopyright(string Copyright)
            {
                //Copyright
                HtmlMeta copyright = new HtmlMeta();
                copyright.Name = "Copyright";
                copyright.Content = Copyright;
                Page.Header.Controls.Add(copyright);
            }
            public void SetAuthor(string Author)
            {
                //Author
                HtmlMeta author = new HtmlMeta();
                author.Name = "Author";
                author.Content = Author;
                Page.Header.Controls.Add(author);

            }
            public void SetCSS(string CSS)
            {
                //Link/CSS
                HtmlLink cssLink = new HtmlLink();
                cssLink.Href = CSS;
                cssLink.Attributes.Add("rel", "stylesheet");
                cssLink.Attributes.Add("type", "text/css");
                Page.Header.Controls.Add(cssLink);
            }
        }
        #endregion
    }
}
