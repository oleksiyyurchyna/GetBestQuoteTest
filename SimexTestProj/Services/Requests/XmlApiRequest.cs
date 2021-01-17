using System.Xml.Serialization;

namespace SimexTestProj.Services.Requests
{
    public class XmlApiRequest
    {
        [XmlElement(ElementName = "source")]
        public string SourceAddress { get; set; }
        [XmlElement(ElementName = "destination")]
        public string DestinationAddress { get; set; }
        [XmlElement(ElementName = "packages")]
        public string[] CartonDimensions { get; set; }
    }
}
