using System.Xml.Serialization;

namespace SimexTestProj.Services.Responses
{
    public class XmlApiResponse
    {
        [XmlElement(ElementName = "quote")]
        public double Quote { get; set; }
    }
}
