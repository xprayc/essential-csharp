using System;
using System.Dynamic;
using System.Xml.Linq;
using System.Linq;

public class DynamicXml : DynamicObject
{
    private XElement Element { get; set; }

    public DynamicXml(XElement element)
    {
        Element = element;
    }

    public static DynamicXml Parse(string text)
    {
        return new DynamicXml(XElement.Parse(text));
    }

    public override bool TryGetMember(
        GetMemberBinder binder, out object result)
    {
        bool success = false;
        result = null;
        XElement firstDescendant = Element.Descendants(binder.Name).FirstOrDefault();
        if (firstDescendant != null)
        {
            if (firstDescendant.Descendants().Count() > 0)
            {
                result = new DynamicXml(firstDescendant);
            }
            else
            {
                result = firstDescendant.Value;
            }
            success = true;
        }

        return success;
    }

    public override bool TrySetMember(
        SetMemberBinder binder, object value)
    {
        bool success = false;
        XElement firstDescendant = Element.Descendants(binder.Name).FirstOrDefault();
        if (firstDescendant != null)
        {
            if (value is XElement)
            {
                firstDescendant.ReplaceWith(value);
            }
            else
            {
                firstDescendant.Value = value.ToString();
            }
            success = true;
        }

        return success;
    }
}

class Program
{
    static void Main(string[] args)
    {
        dynamic person = DynamicXml.Parse(
            @"<Person>
                <FirstName>Lazy</FirstName>
                <LastName>Dreamer</LastName>
              </Person>");

        Console.WriteLine(
            "{0} {1}", person.FirstName, person.LastName);

    }
}
