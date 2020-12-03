using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelperSample.Services;

namespace TagHelperSample.TagHelpers
{
    public class PersonGridTagHelper : TagHelper
    {
        [HtmlAttributeName("persons")]
        public IEnumerable<Person> Persons { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "table";
            output.Attributes.Add("class", "table");
            output.Content.AppendHtml("<tr>");
            output.Content.AppendHtml("<th>First name</th>");
            output.Content.AppendHtml("<th>Last name</th>");
            output.Content.AppendHtml("<th>Age</th>");
            output.Content.AppendHtml("<th>Email address</th>");
            output.Content.AppendHtml("</tr>");

            foreach (var person in Persons)
            {
                output.Content.AppendHtml("<tr>");
                output.Content.AppendHtml($"<td>{person.FirstName}</td>");
                output.Content.AppendHtml($"<td>{person.LastName}</td>");
                output.Content.AppendHtml($"<td>{person.Age}</td>");
                output.Content.AppendHtml($"<td>{person.EmailAddress}</td>");
                output.Content.AppendHtml("</tr>");
            }
        }
    }
}