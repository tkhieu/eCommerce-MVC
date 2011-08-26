﻿using System;
using System.Text;
using System.Web.Mvc;
using eCommerce.WebUI.Models;
using eCommerce.WebUI.Models.Supporter;

namespace eCommerce.WebUI.HtmlHelper
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(PagingInfo pagingInfo,Func<int, string> pageUrl)
        {
            var result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                var tag = new TagBuilder("a"); // Construct an <a> tag
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                    tag.AddCssClass("selected");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}