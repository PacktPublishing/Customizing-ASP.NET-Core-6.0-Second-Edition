using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using OutputFormatterSample.Models;

namespace OutputFormatterSample;

public class VcardOutputFormatter : TextOutputFormatter
{
    public string ContentType { get; } = "text/vcard";

    public VcardOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(ContentType));

        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }

    protected override bool CanWriteType(Type? type)
    {
        if (typeof(Person).IsAssignableFrom(type) || typeof(IEnumerable<Person>).IsAssignableFrom(type))
        {
            return base.CanWriteType(type);
        }
        return false;
    }

    public override Task WriteResponseBodyAsync(
        OutputFormatterWriteContext context,
         Encoding selectedEncoding)
    {
        var serviceProvider = context.HttpContext.RequestServices;
        var logger = serviceProvider.GetService(typeof(ILogger<VcardOutputFormatter>)) as ILogger;

        var response = context.HttpContext.Response;

        var buffer = new StringBuilder();
        if (context.Object is IEnumerable<Person> enumerable)
        {
            foreach (var person in enumerable)
            {
                FormatVcard(buffer, person, logger);
            }
        }
        else
        {
            var person = context.Object as Person;
            FormatVcard(buffer, person, logger);
        }
        return response.WriteAsync(buffer.ToString());

    }

    private static void FormatVcard(StringBuilder buffer, Person? person, ILogger? logger)
    {
        if (person is null)
            return;
        buffer.AppendLine("BEGIN:VCARD");
        buffer.AppendLine("VERSION:2.1");
        buffer.AppendLine($"FN:{person.FirstName} {person.LastName}");
        buffer.AppendLine($"N:{person.LastName};{person.FirstName}");
        buffer.AppendLine($"EMAIL:{person.EmailAddress}");
        buffer.AppendLine($"TEL;TYPE=VOICE,HOME:{person.Phone}");
        buffer.AppendLine($"ADR;TYPE=home:;;{person.Address};{person.City}");
        buffer.AppendLine($"UID:{person.Id}");
        buffer.AppendLine("END:VCARD");

        if (logger is not null)
            logger.LogInformation($"Writing {person.FirstName} {person.LastName}");

    }
}
