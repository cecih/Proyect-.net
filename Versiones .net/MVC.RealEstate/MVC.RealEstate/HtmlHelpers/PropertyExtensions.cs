using MVC.RealEstate.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC.RealEstate.WebUI.HtmlHelpers
{
    public static class PropertyExtensions
    {
        public static MvcHtmlString DisplayAdResume<TModel, TResult>(this HtmlHelper<TModel> html,
                                                                     Expression<Func<TModel, TResult>> expression)
        {
            var ads = ModelMetadata.FromLambdaExpression(expression, html.ViewData).Model as IEnumerable<Property>;
            StringBuilder sb = new StringBuilder();
            if (ads != null)
            {
                var index = 0;
                foreach (var item in ads)
                {
                    if (index == 0 || index == 3 || index==6)
                    {
                        sb.AppendLine(@"<div class=""property-featured-container row-item span12"">");
                    }
                    sb.AppendLine(@"<div class="" thumbnail row-item span2"">");
                    sb.AppendLine(@"    <div class=""image-container"">");
                    sb.AppendLine(@"        <img src=""Images/1.jpg""/>");
                    sb.AppendLine(@"    </div>");
                    sb.AppendLine(@"    <div class=""row-item span"">");
                    sb.AppendLine(@"        <a href=""properties/details/" + item.PropertyID + @""">" + item.Title + @"</a>");
                    sb.AppendLine(@"        <p>" + item.Description + @"</p>");
                    sb.AppendLine(@"        <p>" + item.Address + @"</p>");
                    sb.AppendLine(@"        <p>" + item.Price + @"</p>");
                    sb.AppendLine(@"    </div>");
                    sb.AppendLine(@"</div>");

                    if (index == 2 || index == 5 || index == 8)
                    {
                        sb.AppendLine(@"</div>");
                    }
                    index++;
                }
               
            }
            
            return MvcHtmlString.Create(sb.ToString());
        }
   
    }
}