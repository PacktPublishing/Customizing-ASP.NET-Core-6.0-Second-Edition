using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperSample.TagHelpers
{
    public class GreeterTagHelper : TagHelper
    {
        [HtmlAttributeName("name")]
        public string Name { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "p";
            output.Content.SetContent($"Hello {Name}");
        }
    }
}