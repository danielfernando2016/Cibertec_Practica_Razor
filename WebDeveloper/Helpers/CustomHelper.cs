using System;
using System.Collections.Generic;

using System.Text;

using System.Web;
using System.Web.Mvc;

using WebDeveloper.Model;

namespace WebDeveloper.Helpers
{
    public static class CustomHelper
    {
        private const string Nbsp = "No esta Ingresado algun Valor";

        public static IHtmlString MessageIfEmpty(this HtmlHelper helper, string value)
        {
            return new HtmlString(string.IsNullOrEmpty(value) ? Nbsp : value);
        }



        public static IHtmlString PageLink(this HtmlHelper html, IEnumerable<ContactType> col, Func<int, string> GetURL)
        {
            StringBuilder result = new StringBuilder();
            TagBuilder tag = new TagBuilder("a");
            
            result.Append("<ul>");

            foreach (var contactTypeObj in col)
            {                
                tag = new TagBuilder("a");
                tag.MergeAttribute("href", GetURL(contactTypeObj.ContactTypeID));
                tag.InnerHtml = contactTypeObj.Name;                
                result.Append("<li>");
                
                result.Append(tag.ToString());
                result.Append("</li>");
            }

            result.Append("</ul>");
            
            return new HtmlString(result.ToString());
            
        }

       




    public static IHtmlString DisplayPriceStatic(double price)
        {
            return new HtmlString(GetHtmlForPrice(price));
        }

        public static IHtmlString DisplayPriceExtension(this HtmlHelper helper, double price)
        {
            return new HtmlString(GetHtmlForPrice(price));
        }
        private static string GetHtmlForPrice(double price)
        {
            return price == 0.0 ? "<span>Free!!!</span>" : $"<span>{price.ToString("C")}</span>";
        }

        public static IHtmlString DisplayDateOrNullExtension(this HtmlHelper helper, DateTime? date)
        {
            return new HtmlString(GetDateHtml(date));
        }

        private static string GetDateHtml(DateTime? date)
        {            
            return date.HasValue ? $"<span>{date.Value.ToString("dd-mm-yyyy")}</span>" : "None";
        }

        

        

    }
}
