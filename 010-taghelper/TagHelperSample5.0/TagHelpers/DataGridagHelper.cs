using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperSample.TagHelpers
{
    public class DataGridTagHelper : TagHelper
    {
        [HtmlAttributeName("Items")]
        public IEnumerable<object> Items { get; set; }

        public override void Process(
            TagHelperContext context,
            TagHelperOutput output)
        {
            output.TagName = "table";
            output.Attributes.Add("class", "table");
            var props = GetItemProperties();

            TableHeader(output, props);
            TableBody(output, props);
        }

        private PropertyInfo[] GetItemProperties()
        {
            var listType = Items.GetType();
            Type itemType;
            if (listType.IsGenericType)
            {
                itemType = listType.GetGenericArguments()
                    .First();
                return itemType.GetProperties(
                    BindingFlags.Public |
                    BindingFlags.Instance);
            }
            return new PropertyInfo[] { };
        }

        private void TableHeader(
            TagHelperOutput output,
            PropertyInfo[] props)
        {
            output.Content.AppendHtml("<thead>");
            output.Content.AppendHtml("<tr>");
            foreach (var prop in props)
            {
                var name = GetPropertyName(prop);
                output.Content.AppendHtml($"<th>{name}</th>");
            }
            output.Content.AppendHtml("</tr>");
            output.Content.AppendHtml("</thead>");
        }

        private string GetPropertyName(
            PropertyInfo property)
        {
            var attribute = property
                .GetCustomAttribute<DisplayNameAttribute>();
            if (attribute != null)
            {
                return attribute.DisplayName;
            }
            return property.Name;
        }

        private void TableBody(
            TagHelperOutput output,
            PropertyInfo[] props)
        {
            output.Content.AppendHtml("<tbody>");
            foreach (var item in Items)
            {
                output.Content.AppendHtml("<tr>");
                foreach (var prop in props)
                {
                    var value = GetPropertyValue(prop, item);
                    output.Content.AppendHtml(
                        $"<td>{value}</td>");
                }
                output.Content.AppendHtml("</tr>");
            }
            output.Content.AppendHtml("</tbody>");
        }
        private object GetPropertyValue(
            PropertyInfo property,
            object instance)
        {
            return property.GetValue(instance);
        }


    }

}