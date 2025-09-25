using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp_Net_Core_Mvc_Store.Helpers.Html
{
    public static class PriceHelper
    {
        private static string FormatPrice(decimal price)
        {
            return $"{price} ₽";
        }

        private static TagBuilder CreateLabel(string text)
        {
            TagBuilder span = new TagBuilder("span");
            span.InnerHtml.Append(text);

            return span;
        }

        public static IHtmlContent CreatePriceLabel(this IHtmlHelper helper, decimal price)
        {
            return CreateLabel(FormatPrice(price));
        }

        public static IHtmlContent CreatePriceLabel(this IHtmlHelper helper, decimal price, string prefix)
        {
            return CreateLabel($"{prefix}: {FormatPrice(price)}");
        }

        public static IHtmlContent CreatePriceBox(this IHtmlHelper helper, decimal price)
        {
            TagBuilder label = CreateLabel(FormatPrice(price));
            label.Attributes.Add("class", "btn btn-outline-dark");

            return label;
        }

        public static IHtmlContent CreatePriceBox(this IHtmlHelper helper, decimal price, string prefix)
        {
            TagBuilder label = CreateLabel($"{prefix}: {FormatPrice(price)}");
            label.Attributes.Add("class", "btn btn-outline-dark");

            return label;
        }
    }
}
