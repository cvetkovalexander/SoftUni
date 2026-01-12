using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Utilities;

public static class XmlSerializerWrapper
{
    public static T? Deserialize<T>(string inputXml, string rootAttributeName) 
    {
        XmlRootAttribute rootAttribute = new XmlRootAttribute(rootAttributeName);
        XmlSerializer serializer = new XmlSerializer(typeof(T), rootAttribute);

        using StringReader reader = new StringReader(inputXml);
        var dtos = (T?)serializer.Deserialize(reader);

        return dtos;
    }

    public static T? Deserialize<T>(Stream stream, string rootAttributeName) 
    {
        XmlRootAttribute rootAttribute = new XmlRootAttribute(rootAttributeName);
        XmlSerializer serializer = new XmlSerializer(typeof(T), rootAttribute);

        var dtos = (T?)serializer.Deserialize(stream);

        return dtos;
    }

    public static string Serialize<T>(T objToSerialize, string rootAttributeName, IDictionary<string, string>? namespaces = null) 
    {
        StringBuilder sb = new StringBuilder();
        XmlRootAttribute rootAttribute = new XmlRootAttribute(rootAttributeName);

        XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();

        if (namespaces == null)
            xmlNamespaces.Add(string.Empty, string.Empty);
        else 
        {
            foreach (var nsKvp in namespaces) 
                xmlNamespaces.Add(nsKvp.Key, nsKvp.Value);
        }

            XmlSerializer serializer
                = new XmlSerializer(typeof(T), rootAttribute);

        using StringWriter sw = new StringWriter(sb);

        serializer.Serialize(sw, objToSerialize, xmlNamespaces);

        return sb.ToString().TrimEnd();
    }

    public static void Serialize<T>(T objToSerialize, string rootAttributeName, Stream serializationStream, IDictionary<string, string>? namespaces = null) 
    {
        XmlRootAttribute rootAttribute = new XmlRootAttribute(rootAttributeName);

        XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();

        if (namespaces == null)
            xmlNamespaces.Add(string.Empty, string.Empty);
        else
        {
            foreach (var nsKvp in namespaces)
                xmlNamespaces.Add(nsKvp.Key, nsKvp.Value);
        }

        XmlSerializer serializer
            = new XmlSerializer(typeof(T), rootAttribute);

        serializer.Serialize(serializationStream, objToSerialize, xmlNamespaces);
    }
}
